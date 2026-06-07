using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_GameObject : MCondition
	{
		public GameObjectReference Target;

		public GOCondition Condition;

		public GameObjectReference Value;

		public StringReference checkName;

		public LayerReference Layer;

		public Tag[] tags;

		public override string DisplayName => "Unity/GameObject";

		public override bool _Evaluate()
		{
			if (Condition == GOCondition.Null)
			{
				return Target.Value == null;
			}
			if ((bool)Target.Value)
			{
				return Condition switch
				{
					GOCondition.Name => Target.Value.name.Contains(checkName), 
					GOCondition.Prefab => Target.Value.IsPrefab(), 
					GOCondition.ActiveInHierarchy => Target.Value.activeInHierarchy, 
					GOCondition.ActiveSelf => Target.Value.activeSelf, 
					GOCondition.Equal => Target.Value == Value.Value, 
					GOCondition.Layer => MTools.Layer_in_LayerMask(Target.Value.layer, Layer.Value), 
					GOCondition.Tag => Target.Value.CompareTag(checkName), 
					GOCondition.MalbersTag => Target.Value.HasMalbersTag(tags), 
					_ => false, 
				};
			}
			return false;
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			GameObject component = Target.Value;
			VerifyTarget(target, ref component);
			Target.Value = component;
		}

		private void Reset()
		{
			Name = "New GameObject Condition";
		}
	}
}
