using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class EquipmentPhysics : PlayerComponent, IEquipmentComponent
	{
		[Serializable]
		public class BaseSettings
		{
			public Transform Pivot;

			[EnableIf("Pivot", true, 0f)]
			public Vector3 BasePosOffset;

			[EnableIf("Pivot", true, 0f)]
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
		public BaseSettings GeneralSettings;

		[Space]
		public SwayModule Sway;

		public JumpModule Jump;

		public FallImpactModule FallImpact;

		[Space(3f)]
		[BHeader("Step Forces", true, order = 2)]
		public StepForceModule WalkStepForce;

		public StepForceModule CrouchStepForce;

		public StepForceModule RunStepForce;

		[Space(3f)]
		[BHeader("States", true, order = 2)]
		public EquipmentMotionState IdleState;

		public EquipmentMotionState WalkState;

		public EquipmentMotionState RunState;

		public EquipmentMotionState AimState;

		public EquipmentMotionState CrouchState;

		public EquipmentMotionState ProneState;

		private EquipmentPhysicsHandler m_EPhysicsHandler;

		public void Initialize(EquipmentItem equipmentItem)
		{
			m_EPhysicsHandler = equipmentItem.EHandler.EPhysicsHandler;
			if (GeneralSettings.Pivot == null)
			{
				GeneralSettings.Pivot = base.transform.Find("Pivot");
				if (GeneralSettings.Pivot == null)
				{
					Transform pivot = new GameObject("Pivot").transform;
					GeneralSettings.Pivot = pivot;
				}
			}
		}

		public void OnSelected()
		{
		}

		private void OnValidate()
		{
			if (m_EPhysicsHandler != null)
			{
				m_EPhysicsHandler.ReadjustSprings();
				m_EPhysicsHandler.SetOffset();
			}
		}
	}
}
