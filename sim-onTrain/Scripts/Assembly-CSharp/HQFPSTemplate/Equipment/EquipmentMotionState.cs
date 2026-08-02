using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[Serializable]
	public class EquipmentMotionState : ICloneable
	{
		[Serializable]
		public class EntryOffsetModule : CloneableObject<EntryOffsetModule>
		{
			public bool Enabled;

			[EnableIf("Enabled", true, 0f)]
			public float EntryOffsetDuration = 1f;

			[EnableIf("Enabled", true, 0f)]
			public float LerpToOffsetSpeed = 4f;

			[EnableIf("Enabled", true, 0f)]
			public OffsetModule Offset;
		}

		[Serializable]
		public class OffsetModule : CloneableObject<OffsetModule>
		{
			public bool Enabled = true;

			[EnableIf("Enabled", true, 0f)]
			public Vector3 PositionOffset;

			[EnableIf("Enabled", true, 0f)]
			public Vector3 RotationOffset;
		}

		[Serializable]
		public class BobModule : CloneableObject<BobModule>
		{
			public bool Enabled = true;

			[EnableIf("Enabled", true, 0f)]
			[Clamp(0f, 1000f)]
			public float BobSpeed = 1f;

			[EnableIf("Enabled", true, 0f)]
			public Vector3 PositionAmplitude = new Vector3(0.35f, 0.5f, 0f);

			[EnableIf("Enabled", true, 0f)]
			public Vector3 RotationAmplitude = new Vector3(0.35f, 0.5f, 0f);
		}

		[Serializable]
		public class NoiseModule : CloneableObject<NoiseModule>
		{
			public bool Enabled = true;

			[EnableIf("Enabled", true, 0f)]
			[Range(0f, 1f)]
			public float MaxJitter;

			[EnableIf("Enabled", true, 0f)]
			[Range(0f, 1f)]
			public float NoiseSpeed = 1f;

			[EnableIf("Enabled", true, 0f)]
			public Vector3 PosNoiseAmplitude;

			[EnableIf("Enabled", true, 0f)]
			public Vector3 RotNoiseAmplitude;
		}

		[BHeader("Main Settings")]
		[Group]
		public SpringSettings SpringSettings;

		[Space(3f)]
		[Group("1: ", true)]
		public EntryOffsetModule EntryOffset;

		[Group("2: ", true)]
		public OffsetModule Offset;

		[Group("3: ", true)]
		public BobModule Bob;

		[Group("4: ", true)]
		public NoiseModule Noise;

		[BHeader("Additional Forces")]
		[Group("5: ", true)]
		public SpringForce PosEnterForce;

		[Group("6: ", true)]
		public SpringForce PosExitForce;

		[Group("7: ", true)]
		public SpringForce EnterForce;

		[Group("8: ", true)]
		public SpringForce ExitForce;

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
