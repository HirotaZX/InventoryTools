using System.Numerics;
using Dalamud.Interface.Colors;
using ImGuiNET;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Logic.Settings.Abstract
{
    public abstract class ColorSetting : Setting<Vector4>
    {
        public ColorSetting(ILogger logger, ImGuiService imGuiService) : base(logger, imGuiService)
        {
        }
        public override void Draw(InventoryToolsConfiguration configuration)
        {
            var value = CurrentValue(configuration);

            if (ImGui.ColorEdit4("##" + Key + "Color", ref value, ImGuiColorEditFlags.NoInputs | ImGuiColorEditFlags.NoLabel))
            {
                UpdateFilterConfiguration(configuration, value);
            }
            ImGui.SameLine();
            if (HasValueSet(configuration) && value.W == 0)
            {
                ImGui.SameLine();
                ImGui.TextColored(ImGuiColors.DalamudRed, "The alpha is currently set to 0, this will be invisible.");
            }
            ImGui.SameLine();
            ImGui.SetNextItemWidth(LabelSize);
            if (ColourModified && HasValueSet(configuration))
            {
                ImGui.PushStyleColor(ImGuiCol.Text,ImGuiColors.HealerGreen);
                ImGui.LabelText("##" + Key + "Label", Name);
                ImGui.PopStyleColor();
            }
            else
            {
                ImGui.LabelText("##" + Key + "Label", Name);
            }
            ImGui.SameLine();
            ImGuiService.HelpMarker(HelpText, Image, ImageSize);
            if (!HideReset && HasValueSet(configuration))
            {
                ImGui.SameLine();
                if (ImGui.Button("Reset##" + Key + "Reset"))
                {
                    Reset(configuration);
                }
            }
        }
    }
}