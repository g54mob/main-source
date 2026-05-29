using UnityEngine;

namespace Rewired
{
	public struct ElementAssignment
	{
		public ElementAssignmentType type;

		public int elementMapId;

		public int elementIdentifierId;

		public AxisRange axisRange;

		public KeyCode keyboardKey;

		public ModifierKeyFlags modifierKeyFlags;

		public int actionId;

		public Pole axisContribution;

		public bool invert;

		public ElementAssignment(ElementAssignmentType elementAssignmentType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert, int elementMapId)
		{
			type = default(ElementAssignmentType);
			this.elementMapId = 0;
			this.elementIdentifierId = 0;
			this.axisRange = default(AxisRange);
			this.keyboardKey = default(KeyCode);
			this.modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			this.invert = false;
		}

		public ElementAssignment(ControllerType controllerType, ControllerElementType elementType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert, int elementMapId)
		{
			type = default(ElementAssignmentType);
			this.elementMapId = 0;
			this.elementIdentifierId = 0;
			this.axisRange = default(AxisRange);
			this.keyboardKey = default(KeyCode);
			this.modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			this.invert = false;
		}

		public ElementAssignment(ElementAssignmentType elementAssignmentType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			this.elementIdentifierId = 0;
			this.axisRange = default(AxisRange);
			this.keyboardKey = default(KeyCode);
			this.modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			this.invert = false;
		}

		public ElementAssignment(ControllerType controllerType, ControllerElementType elementType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			this.elementIdentifierId = 0;
			this.axisRange = default(AxisRange);
			this.keyboardKey = default(KeyCode);
			this.modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			this.invert = false;
		}

		public ElementAssignment(int elementIdentifierId, int actionId, bool invert)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			this.elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			axisContribution = default(Pole);
			this.invert = false;
		}

		public ElementAssignment(int elementIdentifierId, int actionId, bool invert, int elementMapId)
		{
			type = default(ElementAssignmentType);
			this.elementMapId = 0;
			this.elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			axisContribution = default(Pole);
			this.invert = false;
		}

		public ElementAssignment(int elementIdentifierId, AxisRange axisRange, int actionId, Pole axisContribution)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			this.elementIdentifierId = 0;
			this.axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(int elementIdentifierId, AxisRange axisRange, int actionId, Pole axisContribution, int elementMapId)
		{
			type = default(ElementAssignmentType);
			this.elementMapId = 0;
			this.elementIdentifierId = 0;
			this.axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(int elementIdentifierId, int actionId, Pole axisContribution)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			this.elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(int elementIdentifierId, int actionId, Pole axisContribution, int elementMapId)
		{
			type = default(ElementAssignmentType);
			this.elementMapId = 0;
			this.elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			this.keyboardKey = default(KeyCode);
			this.modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, int elementMapId)
		{
			type = default(ElementAssignmentType);
			this.elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			this.keyboardKey = default(KeyCode);
			this.modifierKeyFlags = default(ModifierKeyFlags);
			this.actionId = 0;
			this.axisContribution = default(Pole);
			invert = false;
		}

		public static ElementAssignment CompleteAssignment(ElementAssignmentType elementAssignmentType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert, int elementMapId)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment CompleteAssignment(ControllerType controllerType, ControllerElementType elementType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert, int elementMapId)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment CompleteAssignment(ElementAssignmentType elementAssignmentType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment CompleteAssignment(ControllerType controllerType, ControllerElementType elementType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment FullAxisAssignment(int elementIdentifierId, int actionId, bool invert)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment FullAxisAssignment(int elementIdentifierId, int actionId, bool invert, int elementMapId)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment SplitAxisAssignment(int elementIdentifierId, AxisRange axisRange, int actionId, Pole axisContribution)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment SplitAxisAssignment(int elementIdentifierId, AxisRange axisRange, int actionId, Pole axisContribution, int elementMapId)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment ButtonAssignment(int elementIdentifierId, int actionId, Pole axisContribution)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment ButtonAssignment(int elementIdentifierId, int actionId, Pole axisContribution, int elementMapId)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment KeyboardKeyAssignment(KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution)
		{
			return default(ElementAssignment);
		}

		public static ElementAssignment KeyboardKeyAssignment(KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, int elementMapId)
		{
			return default(ElementAssignment);
		}

		public ElementAssignmentConflictCheck ToElementAssignmentConflictCheck()
		{
			return default(ElementAssignmentConflictCheck);
		}
	}
}
