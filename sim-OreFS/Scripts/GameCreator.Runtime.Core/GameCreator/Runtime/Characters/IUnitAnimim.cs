using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Title("Animation")]
	public interface IUnitAnimim : IUnitCommon
	{
		Transform Mannequin { get; set; }

		Animator Animator { get; set; }

		Reaction Reaction { get; set; }

		float SmoothTime { get; set; }

		Vector3 Position { get; set; }

		Quaternion Rotation { get; set; }

		Vector3 Scale { get; set; }

		Vector3 RootMotionDeltaPosition { get; }

		Quaternion RootMotionDeltaRotation { get; }

		event Action<int> EventOnAnimatorIK;

		void ApplyMannequinPosition();

		void ApplyMannequinRotation();

		void ApplyMannequinScale();
	}
}
