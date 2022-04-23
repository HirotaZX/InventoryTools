using CriticalCommonLib.Models;
using Lumina.Excel.GeneratedSheets;

namespace InventoryTools.Logic.Filters
{
    public class SourceAllCharactersFilter : BooleanFilter
    {
        public override string Key { get; set; } = "SourceAllCharacters";
        public override string Name { get; set; } = "Source from all Characters?";
        public override string HelpText { get; set; } = "Use every characters inventory as a source. This will generally only be your own character unless you have cross-character inventory tracking enabled.";
        public override FilterCategory FilterCategory { get; set; } = FilterCategory.Inventories;
        public override FilterType AvailableIn { get; set; } = FilterType.SearchFilter | FilterType.SortingFilter;
        public override bool FilterItem(FilterConfiguration configuration, InventoryItem item)
        {
            return true;
        }

        public override bool FilterItem(FilterConfiguration configuration, Item item)
        {
            return true;
        }

        public override bool? CurrentValue(FilterConfiguration configuration)
        {
            return configuration.SourceAllCharacters;
        }

        public override void UpdateFilterConfiguration(FilterConfiguration configuration, bool? newValue)
        {
            configuration.SourceAllCharacters = newValue;
        }
    }
}