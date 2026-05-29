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

		public ElementAssignment(ElementAssignmentType P_0, int P_1, AxisRange P_2, KeyCode P_3, ModifierKeyFlags P_4, int P_5, Pole P_6, bool P_7, int P_8)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(ControllerType P_0, ControllerElementType P_1, int P_2, AxisRange P_3, KeyCode P_4, ModifierKeyFlags P_5, int P_6, Pole P_7, bool P_8, int P_9)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(ElementAssignmentType P_0, int P_1, AxisRange P_2, KeyCode P_3, ModifierKeyFlags P_4, int P_5, Pole P_6, bool P_7)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(ControllerType P_0, ControllerElementType P_1, int P_2, AxisRange P_3, KeyCode P_4, ModifierKeyFlags P_5, int P_6, Pole P_7, bool P_8)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(int P_0, int P_1, bool P_2)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(int P_0, int P_1, bool P_2, int P_3)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(int P_0, AxisRange P_1, int P_2, Pole P_3)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(int P_0, AxisRange P_1, int P_2, Pole P_3, int P_4)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(int P_0, int P_1, Pole P_2)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(int P_0, int P_1, Pole P_2, int P_3)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(KeyCode P_0, ModifierKeyFlags P_1, int P_2, Pole P_3)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
			invert = false;
		}

		public ElementAssignment(KeyCode P_0, ModifierKeyFlags P_1, int P_2, Pole P_3, int P_4)
		{
			type = default(ElementAssignmentType);
			elementMapId = 0;
			elementIdentifierId = 0;
			axisRange = default(AxisRange);
			keyboardKey = default(KeyCode);
			modifierKeyFlags = default(ModifierKeyFlags);
			actionId = 0;
			axisContribution = default(Pole);
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
