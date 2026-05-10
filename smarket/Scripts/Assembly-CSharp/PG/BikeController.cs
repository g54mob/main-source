using System;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

namespace PG
{
	public class BikeController : CarController
	{
		[Serializable]
		public class BikeConfig
		{
			public AnimationCurve SpeedRollAngle;

			public AnimationCurve RollAngualrLimit;

			public float WheelOffsetInMaxRoll;

			public float MaxHeightDiffWheelsForChangeCom;

			public float MaxPitchAngularInAir;

			public float MaxYawAngularInAir;

			public float MaxReverseSpeedForCrash;

			public float MaxSqrGForceForCrash;

			public float TargetReverseSpeed;
		}

		[Header("Bike Settings")]
		public BikeConfig Bike;

		public Transform Handlebar;

		public Transform FrontFork;

		public Transform RearForkParent;

		public Transform RearFork;

		public Transform FrontComPosition;

		public Transform RearComPosition;

		private Quaternion HandlebarAwakeRotation;

		private Vector3 FrontForkAwakePosition;

		private Quaternion RearForkAwakeLockRotation;

		private Vector3 PrevVelocity;

		private float AdditionalPitchAngular;

		private float AdditionalYawAngular;

		private PhotonView m_PhotonView;

		public bool InCrash { get; private set; }

		public Wheel FrontWheel => null;

		public Wheel RearWheel => null;

		public PhotonView PhotonView => null;

		public event Action OnCrashAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void FixedUpdate()
		{
		}

		protected override void LateUpdate()
		{
		}

		public override void ResetVehicle()
		{
		}
	}
}
