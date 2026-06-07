using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Fulcrum Plane")]
	[Category("Fulcrum Plane")]
	[Description("Uses the bone data to detect when it goes below a plane at the ground level")]
	[Image(typeof(IconFootprint), ColorTheme.Type.Green)]
	public class FootstepDetectorFulcrum : FootstepDetectorBase
	{
		[SerializeField]
		private float m_Fulcrum = -0.85f;

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
			float y = character.transform.TransformPoint(Vector3.up * m_Fulcrum).y;
			for (int i = 0; i < character.Footsteps.Length && i < Phases.Count; i++)
			{
				Transform transform = character.Footsteps.Feet[i].Bone.GetTransform(animator);
				if (transform == null)
				{
					continue;
				}
				bool flag = transform.position.y <= y;
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
			Gizmos.color = (Application.isPlaying ? new Color(0f, 0f, 1f, 0.1f) : new Color(0f, 0f, 1f, 0.5f));
			GizmosExtension.Circle(character.transform.TransformPoint(Vector3.up * m_Fulcrum), 0.5f, character.transform.up, solid: true);
		}
	}
}
