using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class TimeValidator : Validator
	{
		[Tooltip("Determines the time which must elapse before this validator reacts.")]
		public float ElapsedTime = 10f;

		private float currentElapsedTime;

		public override bool Validate()
		{
			currentElapsedTime += Time.deltaTime;
			if (currentElapsedTime > ElapsedTime)
			{
				currentElapsedTime = 0f;
				return false;
			}
			return true;
		}
	}
}
