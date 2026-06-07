using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Animation Curves (obsolete)")]
	[Category("Animation Curves (obsolete)")]
	[Description("Uses the Phases properties to detect footsteps based on the Animation Clip curves data")]
	[Image(typeof(IconFootprint), ColorTheme.Type.Red)]
	public class FootstepDetectorAnimationCurves : FootstepDetectorBase
	{
		private Dictionary<Transform, Footprint> m_Footprints = new Dictionary<Transform, Footprint>();

		public override void OnEnable(Character character)
		{
		}

		public override void OnDisable(Character character)
		{
		}

		public override void OnUpdate(Character character)
		{
			Animator animator = character.Animim.Animator;
			if (animator == null)
			{
				return;
			}
			bool isGrounded = character.Driver.IsGrounded;
			for (int i = 0; i < character.Footsteps.Length && i < Phases.Count; i++)
			{
				Transform transform = character.Footsteps.Feet[i].Bone.GetTransform(animator);
				if (transform == null)
				{
					continue;
				}
				bool flag = character.Phases.IsGround(i);
				if (isGrounded && m_Footprints.TryGetValue(transform, out var value))
				{
					if (flag && !value.WasGrounded)
					{
						character.Footsteps.OnStep(transform);
					}
					value.WasGrounded = flag;
				}
				else
				{
					m_Footprints[transform] = new Footprint
					{
						WasGrounded = true
					};
				}
			}
		}

		public override void OnGizmos(Character character)
		{
		}
	}
}
