using System;
using HQFPSTemplate.Equipment;
using UnityEngine;

namespace HQFPSTemplate
{
	[CreateAssetMenu(fileName = "Camera Physics Preset", menuName = "HQ FPS Template/Camera Physics Preset")]
	public class CameraPhysicsPreset : ScriptableObject
	{
		public struct CustomSprings
		{
			public SpringSettings ForceSpringSettings;
		}

		[Serializable]
		public struct ShakesModule
		{
			[Group]
			public SpringSettings ShakeSpringSettings;

			[Group]
			public CameraShakeSettings ExplosionShake;
		}

		[Serializable]
		public struct FallImpactModule
		{
			[MinMax(0f, 50f, true)]
			public Vector2 FallImpactRange;

			[Space(3f)]
			public SpringForce PosForce;

			public SpringForce RotForce;
		}

		[BHeader("General", true)]
		[Group]
		public EquipmentPhysics.SwayModule Sway;

		[Group]
		public EquipmentPhysics.JumpModule Jump;

		[Space]
		[Group]
		public FallImpactModule FallImpact;

		[Group]
		public SimpleSpringForce GetHitForce;

		[Group]
		public ShakesModule CameraShakes;

		[Space(3f)]
		[BHeader("States", true, order = 2)]
		[Group]
		public SimpleCameraMotionState AimState;

		[Space(3f)]
		[Group]
		public CameraMotionState IdleState;

		[Group]
		public CameraMotionState WalkState;

		[Group]
		public CameraMotionState RunState;

		[Group]
		public CameraMotionState CrouchState;

		[Group]
		public CameraMotionState ProneState;
	}
}
