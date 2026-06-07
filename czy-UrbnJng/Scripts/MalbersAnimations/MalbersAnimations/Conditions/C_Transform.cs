using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_Transform : MCondition
	{
		[Tooltip("Target to check for the condition ")]
		public TransformReference Target;

		[Tooltip("Conditions types")]
		public TransformCondition Condition;

		[Tooltip("Transform Value to compare with")]
		public TransformReference Value;

		[Tooltip("Name to compare")]
		[SerializeField]
		private string checkName;

		public override string DisplayName => "Unity/Transform";

		public string CheckName
		{
			get
			{
				return checkName;
			}
			set
			{
				checkName = value;
			}
		}

		public override bool _Evaluate()
		{
			if (Condition == TransformCondition.Null)
			{
				return Target.Value == null;
			}
			if (Target.Value != null)
			{
				return Condition switch
				{
					TransformCondition.Name => Target.Value.name.Contains(CheckName), 
					TransformCondition.ChildOf => Target.Value.IsChildOf(Value.Value), 
					TransformCondition.Equal => Target.Value == Value.Value, 
					TransformCondition.ParentOf => Value.Value.IsChildOf(Target.Value), 
					TransformCondition.IsGrandChildOf => Target.Value.SameHierarchy(Value.Value), 
					TransformCondition.IsGrandParentOf => Value.Value.SameHierarchy(Target.Value), 
					_ => false, 
				};
			}
			return false;
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			Transform component = Target.Value;
			VerifyTarget(target, ref component);
			Target.Value = component;
		}

		public void SetValue(UnityEngine.Object target)
		{
			_SetTarget(target);
		}

		private void Reset()
		{
			Name = "New Transform Condition";
		}
	}
}
