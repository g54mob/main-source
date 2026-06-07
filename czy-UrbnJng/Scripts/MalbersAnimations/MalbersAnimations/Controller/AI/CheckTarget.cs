using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check Target", order = -100)]
	public class CheckTarget : MAIDecision
	{
		public enum CompareTarget
		{
			IsNull = 0,
			isTransformVar = 1,
			IsInRuntimeSet = 2,
			HasName = 3,
			IsActiveInHierarchy = 4
		}

		public CompareTarget compare;

		[Hide("compare", new int[] { 2 })]
		public RuntimeGameObjects set;

		[Hide("compare", new int[] { 1 })]
		public TransformVar transform;

		[Hide("compare", new int[] { 3 })]
		public string m_name;

		public override string DisplayName => "Movement/Check Target";

		public override bool Decide(MAnimalBrain brain, int index)
		{
			switch (compare)
			{
			case CompareTarget.IsNull:
				return brain.Target == null;
			case CompareTarget.isTransformVar:
				if (transform.Value != null)
				{
					return brain.Target == transform.Value;
				}
				return false;
			case CompareTarget.IsInRuntimeSet:
				if (set != null)
				{
					return set.Items.Contains(brain.Target.gameObject);
				}
				return false;
			case CompareTarget.HasName:
				if (string.IsNullOrEmpty(m_name))
				{
					return brain.Target.name.Contains(m_name);
				}
				return false;
			case CompareTarget.IsActiveInHierarchy:
				if ((bool)brain.Target)
				{
					return brain.Target.gameObject.activeInHierarchy;
				}
				return false;
			default:
				return false;
			}
		}
	}
}
