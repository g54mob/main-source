public static class ObjectNames
{
	public const string BlockCollider = "BlockCollider";

	public const string BlockModel = "BlockModel";

	public const string BlockScalable = "BlockScalable";

	public const string BlockGhost = "BlockGhost";

	public const string BlockTransparent = "BlockTransparent";

	public const string BlockView = "BlockView";

	public const string BlockLevel = "BlockLevel";

	public const string Connectors = "Connectors";

	public const string Line = "Line";

	public const string LineStart = "LineStart";

	public const string LineEnd = "LineEnd";

	public const string SelectedConnector = "SelectedConnector";

	public const string MouseOverConnector = "MouseOverConnector";

	public const string GuiTab = "Tab";

	public const string GuiNewTab = "NewTab";

	public const string GuiSlot = "Slot";

	public const string GuiLevelSlotPrefix = "LevelSlot_";

	public const string UserCategory = "User";

	public const string GameplayScene = "Gameplay";

	public const string Camera = "Camera";

	public const string CreationFolder = "CreationFolder";

	public const string CreationView = "CreationView";

	public const string RigidbodyEffects = "Rigidbody Effects";

	public const string HingeJointButton3Did = "hinge_joint_button_3d";

	public const string AllJointsButton3Did = "all_joints_button_3d";

	public const string QuickKeysGroupId = "quick_keys_group";

	public const string QuickKeySlotId = "quick_key_slot";

	public const string KeyTriggerInstructionSlotId = "key_trigger_instruction_slot";

	public const string ComparatorInstructionSlotId = "comparator_instruction_slot";

	public const string SetInstructionSlotId = "set_instruction_slot";

	public const string AccumulatorInstructionSlotId = "accumulator_instruction_slot";

	public const string OperationInstructionSlotId = "operation_instruction_slot";

	public const string DelayInstructionSlotId = "delay_instruction_slot";

	public const string GroupInstructionSlotId = "group_instruction_slot";

	public const string QuickInventoryTabId = "quick_inventory_tab";

	public const string QuickInventorySlotId = "quick_inventory_slot";

	public const string LEQuickInventoryTabId = "le_quick_inventory_tab";

	public const string LEQuickInventorySlotId = "le_quick_inventory_slot";

	public static string SchematicIdForModel(string schematicId)
	{
		return schematicId + "_model";
	}

	public static string SchematicIdForPlaceholder(string schematicId)
	{
		return schematicId + "_placeholder";
	}

	public static string SchematicIdForRigid(string schematicId)
	{
		return schematicId + "_rigid";
	}

	public static string SchematicIdForButton(string schematicId)
	{
		return schematicId + "_button";
	}
}
