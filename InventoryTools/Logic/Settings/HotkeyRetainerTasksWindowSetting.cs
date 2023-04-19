using Dalamud.Game.ClientState.Keys;
using InventoryTools.Logic.Settings.Abstract;
using OtterGui.Classes;

namespace InventoryTools.Logic.Settings
{
    public class HotkeyRetainerTasksWindowSetting : HotKeySetting
    {
        public override ModifiableHotkey DefaultValue { get; set; } = new(VirtualKey.NO_KEY);
        public static string AsKey => "HotkeyRetainerTasksWindow";
        public override string Key { get; set; } = AsKey;
        public override string Name { get; set; } = "Toggle Retainer Ventures Window";

        public override string HelpText { get; set; } =
            "The hotkey to toggle the retainer ventures window.";

        public override SettingCategory SettingCategory { get; set; } = SettingCategory.Hotkeys;
        public override SettingSubCategory SettingSubCategory { get; } = SettingSubCategory.General;
    }
}