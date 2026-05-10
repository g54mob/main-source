using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class OffsetEffector : OffsetModifier
	{
		[Serializable]
		public class EffectorLink
		{
			public FullBodyBipedEffector effectorType;

			public float weightMultiplier;

			[HideInInspector]
			public Vector3 localPosition;
		}

		[Tooltip("Optional. Assign the bone Transform that is closest to this OffsetEffector to be able to call OffsetEffector.Anchor() in LateUpdate to match its position and rotation to animation.")]
		public Transform anchor;

		public EffectorLink[] effectorLinks;

		private Vector3 posRelToAnchor;

		private Quaternion rotRelToAnchor;

		protected override void Start()
		{
		}

		protected override void OnModifyOffset()
		{
		}

		public void Anchor()
		{
		}
	}
}
