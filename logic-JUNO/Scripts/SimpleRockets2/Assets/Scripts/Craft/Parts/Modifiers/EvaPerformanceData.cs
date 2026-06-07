using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	public class EvaPerformanceData
	{
		[SerializeField]
		[Range(0f, 50000f)]
		public float ForceForwardGround = 1000f;

		[SerializeField]
		[Range(0f, 50000f)]
		public float ForceForwardJetpack = 1000f;

		[SerializeField]
		[Range(0f, 50000f)]
		public float ForceStrafeGround = 1000f;

		[SerializeField]
		[Range(0f, 50000f)]
		public float ForceStrafeJetpack = 500f;

		[SerializeField]
		[Range(0f, 50000f)]
		public float ForceUpJetpack = 300f;

		[SerializeField]
		[Range(0f, 10f)]
		public float JumpStrength = 1f;

		[SerializeField]
		[Range(0f, 500f)]
		public float MaxForwardSpeedGround = 15f;

		[SerializeField]
		[Range(0f, 500f)]
		public float MaxStrafeSpeedGround = 5f;

		[SerializeField]
		[Range(0f, 1f)]
		public float TurningResponsivenessAir;

		[SerializeField]
		[Range(0f, 1f)]
		public float TurningResponsivenessGround = 1f;

		[SerializeField]
		[Range(0f, 10f)]
		public float TurningSpeedGround = 3f;

		[SerializeField]
		[Range(0f, 1000f)]
		public float TurningTorqueAir = 100f;

		private const int MaxForceRange = 50000;

		private const int MaxSpeedRange = 500;
	}
}
