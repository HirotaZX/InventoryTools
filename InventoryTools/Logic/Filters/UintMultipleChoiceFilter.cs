using System.Collections.Generic;

namespace InventoryTools.Logic.Filters
{
    public abstract class UintMultipleChoiceFilter : MultipleChoiceFilter<uint>
    {
        public override List<uint> CurrentValue(FilterConfiguration configuration)
        {
            return configuration.GetUintChoiceFilter(Key);
        }
        
        public override void UpdateFilterConfiguration(FilterConfiguration configuration, List<uint> newValue)
        {
            configuration.UpdateUintChoiceFilter(Key, newValue);
        }
    }
}