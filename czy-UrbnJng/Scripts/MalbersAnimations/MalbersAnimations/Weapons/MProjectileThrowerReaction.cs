using System;
using MalbersAnimations.Reactions;
using UnityEngine;

namespace MalbersAnimations.Weapons
{
	[Serializable]
	[AddTypeMenu("Tools/Projectile Thrower", 0)]
	public class MProjectileThrowerReaction : Reaction
	{
		public enum ProjectileThrowerActions
		{
			SetProjectile = 0,
			SetTarget = 1,
			SetDamageMultiplier = 2,
			SetScaleMultiplier = 3,
			SetForceMultiplier = 4,
			SetForce = 5,
			SetAngle = 6,
			SetAfterDistance = 7,
			Fire = 8
		}

		public ProjectileThrowerActions action;

		[Hide("action", new int[] { 0 })]
		public GameObject projectile;

		[Hide("action", new int[] { 1 })]
		public Transform target;

		[Hide("action", true, new int[] { 0, 1, 8 })]
		public float value;

		public override Type ReactionType => typeof(MProjectileThrower);

		protected override bool _TryReact(Component reactor)
		{
			if (reactor is MProjectileThrower mProjectileThrower)
			{
				switch (action)
				{
				case ProjectileThrowerActions.SetProjectile:
					mProjectileThrower.SetProjectile(projectile);
					break;
				case ProjectileThrowerActions.SetTarget:
					mProjectileThrower.SetTarget(target);
					break;
				case ProjectileThrowerActions.SetDamageMultiplier:
					mProjectileThrower.SetDamageMultiplier(value);
					break;
				case ProjectileThrowerActions.SetScaleMultiplier:
					mProjectileThrower.SetScaleMultiplier(value);
					break;
				case ProjectileThrowerActions.SetForceMultiplier:
					mProjectileThrower.SetForceMultiplier(value);
					break;
				case ProjectileThrowerActions.SetForce:
					mProjectileThrower.Power = value;
					break;
				case ProjectileThrowerActions.SetAngle:
					mProjectileThrower.Angle = value;
					break;
				case ProjectileThrowerActions.SetAfterDistance:
					mProjectileThrower.AfterDistance = value;
					break;
				case ProjectileThrowerActions.Fire:
					mProjectileThrower.Fire();
					break;
				}
			}
			return true;
		}
	}
}
