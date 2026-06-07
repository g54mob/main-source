using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_RuntimeGameObjectSet : MCondition
	{
		public enum RuntimeGameObjectCondition
		{
			Empty = 0,
			Size = 1,
			HasItem = 2
		}

		[RequiredField]
		public RuntimeGameObjects Target;

		public RuntimeGameObjectCondition Condition;

		[Hide("Condition", false, true, new int[] { 1 })]
		public int Size;

		public GameObjectReference item;

		public override string DisplayName => "Values/Runtime GameObject Set";

		protected override void _SetTarget(UnityEngine.Object target)
		{
			if (target == null && target is RuntimeGameObjects)
			{
				Target = target as RuntimeGameObjects;
			}
		}

		public override bool _Evaluate()
		{
			return Condition switch
			{
				RuntimeGameObjectCondition.Empty => Target.IsEmpty, 
				RuntimeGameObjectCondition.Size => Target.Count == Size, 
				RuntimeGameObjectCondition.HasItem => Target.Has_Item(item.Value), 
				_ => false, 
			};
		}

		private void Reset()
		{
			Name = "New RuntimeGameObject Set Comparer";
		}
	}
}
