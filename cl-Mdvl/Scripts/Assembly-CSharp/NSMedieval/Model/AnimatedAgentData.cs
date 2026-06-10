using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AnimatedAgentData : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private float rotationSpeed;

		[SerializeField]
		private float minRunSpeedThreshold;

		[SerializeField]
		private float walkAnimationSpeedAdd;

		[SerializeField]
		private float walkAnimationSpeedMultiply = 0.57f;

		[SerializeField]
		private float runAnimationSpeedAdd = 0.43f;

		[SerializeField]
		private float runAnimationSpeedMultiply = 0.35f;

		public float RotationSpeed => rotationSpeed;

		public float MinRunSpeedThreshold => minRunSpeedThreshold;

		public float WalkAnimationSpeedAdd => walkAnimationSpeedAdd;

		public float WalkAnimationSpeedMultiply => walkAnimationSpeedMultiply;

		public float RunAnimationSpeedAdd => runAnimationSpeedAdd;

		public float RunAnimationSpeedMultiply => runAnimationSpeedMultiply;

		public override string GetID()
		{
			return id;
		}
	}
}
