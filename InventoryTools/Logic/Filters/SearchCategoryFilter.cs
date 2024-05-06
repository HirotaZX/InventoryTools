using System.Collections.Generic;
using System.Linq;
using CriticalCommonLib.Models;
using CriticalCommonLib.Services;
using CriticalCommonLib.Sheets;
using Dalamud.Utility;
using InventoryTools.Logic.Filters.Abstract;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Logic.Filters
{
    public class SearchCategoryFilter : UintMultipleChoiceFilter
    {
        private readonly ExcelCache _excelCache;
        public override string Key { get; set; } = "SchCategory";
        
        public override string Name { get; set; } = "Market Board Categories";
        
        public override string HelpText { get; set; } = "Filter by the categories available on the market board.";
        public override FilterCategory FilterCategory { get; set; } = FilterCategory.Searching;

        private Dictionary<uint, string> _choices = new();
        private bool _choicesLoaded = false;

        public override List<uint> DefaultValue { get; set; } = new();

        public override FilterType AvailableIn { get; set; } =
            FilterType.SearchFilter | FilterType.SortingFilter | FilterType.GameItemFilter | FilterType.HistoryFilter;
        
        public override bool? FilterItem(FilterConfiguration configuration, InventoryItem item)
        {
            return FilterItem(configuration, item.Item);
        }

        public override bool? FilterItem(FilterConfiguration configuration, ItemEx item)
        {
            var currentValue = CurrentValue(configuration);
            if (currentValue.Count != 0 && !currentValue.Contains(item.ItemSearchCategory.Row))
            {
                return false;
            }

            return true;
        }

        public override Dictionary<uint, string> GetChoices(FilterConfiguration configuration)
        {
            if (!_choicesLoaded)
            {
                _choices = _excelCache.GetAllItemSearchCategories()
                    .ToDictionary(c => c.Key, c => c.Value.Name.ToDalamudString().ToString());
                _choicesLoaded = true;
            }

            return _choices;
        }

        public override Dictionary<uint, string> GetActiveChoices(FilterConfiguration configuration)
        {
            var choices = GetChoices(configuration);
            if (HideAlreadyPicked)
            {
                var currentChoices = CurrentValue(configuration);
                return choices.Where(c => !currentChoices.Contains(c.Key)).ToDictionary(c => c.Key, c => c.Value);
            }

            return choices;
        }

        public override bool HideAlreadyPicked { get; set; } = true;

        public SearchCategoryFilter(ILogger<SearchCategoryFilter> logger, ImGuiService imGuiService, ExcelCache excelCache) : base(logger, imGuiService)
        {
            _excelCache = excelCache;
        }
    }
}