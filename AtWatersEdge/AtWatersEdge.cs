using atwatersedge.Items;
using AtWatersEdge.BlockEntities;
using AtWatersEdge.Blocks;
using AtWatersEdge.Util;
using System;
using Vintagestory.API.Common;

namespace AtWatersEdge
{
    public class AtWatersEdge : ModSystem
    {
        public static double daysPerMonthMod;

        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            //Register Block Entities
            api.RegisterBlockEntityClass("awebetransient", typeof(AWEBETransient));

            //Register Items
            api.RegisterItemClass("awereeditem", typeof(AWECattailRoot));

            //Register Blocks
            api.RegisterBlockClass("awereeds", typeof(AWEReeds));

            try
            {
                var Config = api.LoadModConfig<AtWatersEdgeConfig>("atwatersedge.json");
                if (Config != null)
                {
                    api.Logger.Notification("Mod Config successfully loaded.");
                    AtWatersEdgeConfig.Current = Config;
                }
                else
                {
                    api.Logger.Notification("No Mod Config specified. Falling back to default settings");
                    AtWatersEdgeConfig.Current = AtWatersEdgeConfig.GetDefault();
                }
            }
            catch
            {
                AtWatersEdgeConfig.Current = AtWatersEdgeConfig.GetDefault();
                api.Logger.Error("Failed to load custom mod configuration. Falling back to default settings!");
            }
            finally
            {

                api.StoreModConfig(AtWatersEdgeConfig.Current, "atwatersedge.json");

            }

            daysPerMonthMod = AtWatersEdgeConfig.Current.useDaysPerMonthmod?(float)api.World.Config.GetAsInt("daysPerMonth") / 9f:1f;
        }
    }
}
