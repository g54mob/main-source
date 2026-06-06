using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Set VarListener")]
	public class SetVarListener : MTask
	{
		public enum VarType
		{
			Bool = 0,
			Int = 1,
			Float = 2
		}

		public enum BoolType
		{
			True = 0,
			False = 1
		}

		[Space]
		[Tooltip("Check the Variable Listener ID Value, when this value is Zero, the ID is ignored")]
		public IntReference ListenerID = 0;

		[Space]
		[Tooltip("Check the Decision on the Animal(Self) or the Target(Target), or on an object with a tag")]
		public Affected checkOn;

		[Space]
		[Tooltip("Check on the Target or Self if it has a Listener Variable Component <Int><Bool><Float> and compares it with the local variable)")]
		public VarType varType;

		[Hide("varType", new int[] { 0 })]
		public bool boolValue = true;

		[Hide("varType", new int[] { 1 })]
		public int intValue;

		[Hide("varType", new int[] { 2 })]
		public float floatValue;

		public override string DisplayName => "Variables/Set Var Listener";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			switch (checkOn)
			{
			case Affected.Self:
				Set_VarListener(brain.Animal);
				break;
			case Affected.Target:
				Set_VarListener(brain.Target);
				break;
			}
			brain.TaskDone(index);
		}

		public void Set_VarListener(Component comp)
		{
			VarListener[] componentsInChildren = comp.GetComponentsInChildren<VarListener>();
			foreach (VarListener varListener in componentsInChildren)
			{
				if ((int)ListenerID != 0 && varListener.ID.Value != ListenerID.Value)
				{
					continue;
				}
				switch (varType)
				{
				case VarType.Bool:
					if (varListener is BoolVarListener)
					{
						(varListener as BoolVarListener).value.Value = boolValue;
					}
					break;
				case VarType.Int:
					if (varListener is IntVarListener)
					{
						(varListener as IntVarListener).value.Value = intValue;
					}
					break;
				case VarType.Float:
					if (varListener is FloatVarListener)
					{
						(varListener as FloatVarListener).value.Value = floatValue;
					}
					break;
				}
			}
		}

		private void Reset()
		{
			Description = "Search for any Var listener in the Animal or the Target and sets a value";
		}
	}
}
