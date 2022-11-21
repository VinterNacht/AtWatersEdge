using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtWatersEdge.Util
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    class AtWatersEdgeConfig
    {
        public bool cattailUseConfigValues = false;
        public double cattailSproutingToHarvestable = 84;
        public double cattailHarvestableToFullGrown = 168;
        public bool papyrusUseConfigValues = false;
        public double papyrusSproutingToHarvestable = 66;
        public double papyrusHarvestableToFullGrown = 132;
        public bool useDaysPerMonthmod = true;

        public AtWatersEdgeConfig()
        { }

        public static AtWatersEdgeConfig Current { get; set; }

        public static AtWatersEdgeConfig GetDefault()
        {
            AtWatersEdgeConfig defaultConfig = new();

            defaultConfig.cattailUseConfigValues = false;
            defaultConfig.cattailSproutingToHarvestable = 84;
            defaultConfig.cattailHarvestableToFullGrown = 168;
            defaultConfig.papyrusUseConfigValues = false;
            defaultConfig.papyrusSproutingToHarvestable = 66;
            defaultConfig.papyrusHarvestableToFullGrown = 132;
            defaultConfig.useDaysPerMonthmod = true;

            return defaultConfig;
        }
    }
}
