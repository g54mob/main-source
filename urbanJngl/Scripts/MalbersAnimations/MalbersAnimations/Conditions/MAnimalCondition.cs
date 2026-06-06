using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public abstract class MAnimalCondition : MCondition
	{
		[RequiredField]
		public MAnimal Target;

		public virtual void SetTarget(MAnimal n)
		{
			Target = n;
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			VerifyTarget(target, ref Target);
		}
	}
}
