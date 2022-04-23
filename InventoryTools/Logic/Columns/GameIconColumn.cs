using System.Collections.Generic;
using System.Numerics;
using CriticalCommonLib.Models;
using ImGuiNET;
using Lumina.Excel.GeneratedSheets;

namespace InventoryTools.Logic.Columns
{
    public abstract class GameIconColumn : Column<ushort?>
    {
        public virtual Vector2 IconSize
        {
            get
            {
                return new Vector2(32, 32);
            }
        }
        public virtual string EmptyText
        {
            get
            {
                return "N/A";
            }
        }
        public override void Draw(InventoryItem item, int rowIndex)
        {
            DoDraw(CurrentValue(item), rowIndex);
        }
        public override void Draw(SortingResult item, int rowIndex)
        {
            DoDraw(CurrentValue(item), rowIndex);
        }
        public override void Draw(Item item, int rowIndex)
        {
            DoDraw(CurrentValue(item), rowIndex);
        }

        public override IEnumerable<Item> Filter(IEnumerable<Item> items)
        {
            return items;
        }

        public override IEnumerable<InventoryItem> Filter(IEnumerable<InventoryItem> items)
        {
            return items;
        }

        public override IEnumerable<SortingResult> Filter(IEnumerable<SortingResult> items)
        {
            return items;
        }

        public override IEnumerable<InventoryItem> Sort(ImGuiSortDirection direction, IEnumerable<InventoryItem> items)
        {
            return items;
        }

        public override IEnumerable<Item> Sort(ImGuiSortDirection direction, IEnumerable<Item> items)
        {
            return items;
        }

        public override IEnumerable<SortingResult> Sort(ImGuiSortDirection direction, IEnumerable<SortingResult> items)
        {
            return items;
        }

        public override void DoDraw(ushort? currentValue, int rowIndex)
        {
            ImGui.TableNextColumn();
            if (currentValue != null)
            {
                PluginService.PluginLogic.DrawIcon(currentValue.Value, IconSize);
            }
        }

        public override void Setup(int columnIndex)
        {
            ImGui.TableSetupColumn(Name, ImGuiTableColumnFlags.WidthFixed, Width, (uint)columnIndex);
        }
    }
}