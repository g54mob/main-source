namespace DV.Game.Tutorial
{
	public enum ControlHint
	{
		[ControlHint("", "", null, false, PreferencesExclusivity.Any, null, false)]
		None = 0,
		[ControlHint("tutorial/controlhint/hotbar", "|Hotbar[0]|", null, true, PreferencesExclusivity.NonVR, null, false)]
		OpenHotbar = 1,
		[ControlHint("tutorial/controlhint/open_inventory", "|!InventoryOpen|", null, false, PreferencesExclusivity.Any, null, false)]
		OpenInventory = 2,
		[ControlHint("tutorial/controlhint/close_inventory", "|!InventoryOpen|", null, false, PreferencesExclusivity.Any, null, false)]
		CloseInventory = 3,
		[ControlHint("tutorial/controlhint/item_placement", "|Place|", null, true, PreferencesExclusivity.NonVR, null, false)]
		ItemPlacement = 4,
		[ControlHint("tutorial/controlhint/open_container", "|!Use|", null, false, PreferencesExclusivity.Any, null, false)]
		OpenHeldContainer = 5,
		[ControlHint("tutorial/controlhint/open_container", "|!Use|", null, false, PreferencesExclusivity.VR, null, false)]
		OpenWorldContainer = 6,
		[ControlHint("tutorial/controlhint/drop_item", "|!Drop|", null, false, PreferencesExclusivity.Any, null, false)]
		DropItem = 7,
		[ControlHint("tutorial/controlhint/dash", "|!Teleport|", null, false, PreferencesExclusivity.Any, null, false)]
		Dash = 8,
		[ControlHint("tutorial/controlhint/remote_operation", "tutorial/controlhint/remote_opration_vrvalue", null, false, PreferencesExclusivity.VR, "tutorial/controlhint/remote_opreration_wandvalue", true)]
		RemoteOperation = 9,
		[ControlHint("tutorial/controlhint/flip_pages", "|!Scroll|", null, false, PreferencesExclusivity.Any, null, false)]
		FlipPages = 10,
		[ControlHint("tutorial/controlhint/toggle_mouse_mode", "|MouseLook|", null, false, PreferencesExclusivity.NonVR, null, false)]
		ToggleMouseMode = 11,
		[ControlHint("tutorial/controlhint/quick_select_vr", "tutorial/controlhint/quick_select_vr_value", null, false, PreferencesExclusivity.VR, null, true)]
		QuickSelectVR = 12,
		[ControlHint("tutorial/controlhint/quick_stash", "tutorial/controlhint/quick_stash_nonvr_value", "tutorial/controlhint/quick_stash_vr_value", false, PreferencesExclusivity.Any, null, true)]
		QuickStash = 13,
		[ControlHint("tutorial/controlhint/grab_item", "|!Grab|", null, false, PreferencesExclusivity.Any, null, false)]
		GrabItem = 14,
		[ControlHint("tutorial/controlhint/insert_item", "|!Use|", "", false, PreferencesExclusivity.Any, null, false)]
		InsertItem = 15
	}
}
