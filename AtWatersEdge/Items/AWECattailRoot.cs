using System;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace atwatersedge.Items
{
	// Token: 0x0200000C RID: 12
	public class AWECattailRoot : ItemCattailRoot
	{
		public override void OnHeldInteractStart(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
		{
			if (blockSel == null || ((byEntity != null) ? byEntity.World : null) == null || !byEntity.Controls.Sneak)
			{
				base.OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
				return;
			}
			bool flag = byEntity.World.BlockAccessor.GetBlock(blockSel.Position.AddCopy(blockSel.Face), 2).LiquidCode == "water";
			bool flag2 = false;
			Block block = null;
			string a = itemslot.Itemstack.Collectible.FirstCodePart(0);
			if ((a == "halvedcattailroot" || a == "cattailroot") && flag)
			{
				block = this.api.World.GetBlock(new AssetLocation("atwatersedge", "tallplant-coopersreed-water-growing-free"));
				flag2 = true;
			}
			else if ((a == "halvedpapyrusroot" || a == "papyrusroot") && flag)
			{
				block = this.api.World.GetBlock(new AssetLocation("atwatersedge", "tallplant-papyrus-water-growing-free"));
				flag2 = true;
			}
			if (!flag2)
			{
				//base.OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
				return;
			}
			IPlayer player = null;
			EntityPlayer entityPlayer = byEntity as EntityPlayer;
			if (entityPlayer != null)
			{
				player = byEntity.World.PlayerByUid(entityPlayer.PlayerUID);
			}
			blockSel = blockSel.Clone();
			blockSel.Position.Add(blockSel.Face, 1);
			string text = "";
			if (block.TryPlaceBlock(byEntity.World, player, itemslot.Itemstack, blockSel, ref text))
			{
				byEntity.World.PlaySoundAt(block.Sounds.GetBreakSound(player), (double)blockSel.Position.X + 0.5, (double)blockSel.Position.Y + 0.5, (double)blockSel.Position.Z + 0.5, player, true, 32f, 1f);
				itemslot.TakeOut(1);
				itemslot.MarkDirty();
				handHandling = EnumHandHandling.PreventDefaultAction;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003948 File Offset: 0x00001B48
		public override WorldInteraction[] GetHeldInteractionHelp(ItemSlot inSlot)
		{
			return new WorldInteraction[]
			{
				new WorldInteraction
				{
					HotKeyCode = "sneak",
					ActionLangCode = "heldhelp-plant",
					MouseButton = EnumMouseButton.Right
				}
			}.Append(base.GetHeldInteractionHelp(inSlot));
		}
	}
}
