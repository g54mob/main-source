using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[CreateAssetMenu(fileName = "Equipment Physics", menuName = "HQ FPS Template/Equipment Component/Physics")]
	public class EquipmentPhysicsInfo : ScriptableObject
	{
		[Serializable]
		public class GeneralSettingsInfo
		{
			public Vector3 BasePosOffset;

			public Vector3 BaseRotOffset;
		}

		[Serializable]
		public class SwayModule : CloneableObject<SwayModule>
		{
			[Range(0f, 20f)]
			public float LookInputMultiplier = 1f;

			[Clamp(0f, 100f)]
			public float MaxLookInput = 5f;

			[Clamp(0f, 100f)]
			public float AimMultiplier = 0.2f;

			[Space]
			public Vector3 LookPositionSway;

			public Vector3 LookRotationSway;

			[Space]
			public Vector3 StrafePositionSway;

			public Vector3 StrafeRotationSway;

			[Space]
			public Vector3 FallSway;
		}

		[Serializable]
		public class JumpModule : CloneableObject<JumpModule>
		{
			public bool Enabled = true;

			[EnableIf("Enabled", true, 0f)]
			public SpringForce PositionForce;

			[EnableIf("Enabled", true, 0f)]
			public SpringForce RotationForce;
		}

		[Serializable]
		public class FallImpactModule : CloneableObject<FallImpactModule>
		{
			public bool Enabled = true;

			[EnableIf("Enabled", true, 0f)]
			public SpringForce PositionForce;

			[EnableIf("Enabled", true, 0f)]
			public SpringForce RotationForce;
		}

		[Serializable]
		public class StepForceModule : CloneableObject<StepForceModule>
		{
			public bool Enabled = true;

			[EnableIf("Enabled", true, 0f)]
			public SpringForce PositionForce;

			[EnableIf("Enabled", true, 0f)]
			public SpringForce RotationForce;
		}

		[BHeader("Main Settings", true)]
		[Group]
		public GeneralSettingsInfo GeneralSettings;

		[Space]
		[Group]
		public SwayModule Sway;

		[Group]
		public JumpModule Jump;

		[Group]
		public FallImpactModule FallImpact;

		[Space(3f)]
		[BHeader("Step Forces", true, order = 2)]
		[Group]
		public StepForceModule WalkStepForce;

		[Group]
		public StepForceModule CrouchStepForce;

		[Group]
		public StepForceModule RunStepForce;

		[Space(3f)]
		[BHeader("States", true, order = 2)]
		[Group]
		public EquipmentMotionState IdleState;

		[Group]
		public EquipmentMotionState WalkState;

		[Group]
		public EquipmentMotionState RunState;

		[Group]
		public EquipmentMotionState AimState;

		[Group]
		public EquipmentMotionState CrouchState;

		[Group]
		public EquipmentMotionState ProneState;
	}
}
