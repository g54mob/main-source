using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class TargetValidator : Validator
	{
		[Tooltip("The observed target.")]
		public GameObject Target;

		[Tooltip("Determines the maximum distance that the 'Target' can move.")]
		public float MaxDeltaPosition = 1f;

		private Vector3 previousPosition;

		public TargetValidator()
		{
			Enabled = true;
		}

		public override bool Validate()
		{
			if (Target != null && Vector3.Distance(Target.transform.position, previousPosition) > MaxDeltaPosition)
			{
				previousPosition = Target.transform.position;
				return false;
			}
			return true;
		}
	}
}
