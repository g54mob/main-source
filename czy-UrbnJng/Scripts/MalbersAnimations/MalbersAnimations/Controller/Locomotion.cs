using System;
using System.Collections.Generic;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class Locomotion : State
	{
		[Serializable]
		public class WallStopProfiles
		{
			[Tooltip("Speed Index to Identify the Profile (Walk = 1, Trot = 2, etc)")]
			public float SpeedIndex;

			[Tooltip("Speed Index to Identify the Profile (Walk = 1, Trot = 2, etc)")]
			public float RayLength;

			[Tooltip("Reaction to do if the Animal touches a Wall")]
			[SerializeReference]
			[SubclassSelector]
			public Reaction reaction;

			[Tooltip("Reaction if there's no wall detected in front of the animal")]
			[SerializeReference]
			[SubclassSelector]
			public Reaction NoWallDetected;
		}

		[Header("Locomotion Parameters")]
		[Tooltip("Backward Offset Position of the BackFall Ray")]
		public FloatReference FallRayBackwards = new FloatReference(0.3f);

		[Tooltip("Reset Inertia On Enter")]
		public BoolReference ResetIntertia = new BoolReference(value: false);

		[Space(10f)]
		[Tooltip("Makes the Animal Stop Moving when is near a Wall")]
		public bool WallStop;

		[Hide("WallStop")]
		public LayerMask StopLayer = 1;

		private Transform WallHit;

		private WallStopProfiles currentProfile;

		[Tooltip("Profiles to increase or decrease the WallRayLength depending the current Speed (Walk,Trot,Run).\nX:Speed Index (Walk = 1, Trot = 2, etc)\nY:Additional Value for the Ray when the Character is on that speed.")]
		[Hide("WallStop", false, false)]
		public List<WallStopProfiles> wallStopProfiles = new List<WallStopProfiles>();

		[Space(10f)]
		[Tooltip("Makes the Animal avoid ledges, Useful when the Animal without a Fall State, like the Elephant")]
		public bool AntiFall;

		[Hide("AntiFall")]
		public float frontDistance = 0.5f;

		[Hide("AntiFall")]
		public float frontSpace = 0.2f;

		[Space]
		[Hide("AntiFall")]
		public float BackDistance = 0.5f;

		[Hide("AntiFall")]
		public float BackSpace = 0.2f;

		[Space]
		[Hide("AntiFall")]
		public float FallMultiplier = 1f;

		[Hide("AntiFall")]
		public Color DebugColor = Color.yellow;

		private readonly RaycastHit[] hits = new RaycastHit[1];

		public override string StateName => "Locomotion";

		public override string StateIDName => "Locomotion";

		public bool HasIdle { get; private set; }

		public override void InitializeState()
		{
			HasIdle = animal.HasState(StateEnum.Idle);
		}

		public override bool TryActivate()
		{
			if (animal.Grounded)
			{
				if (!HasIdle)
				{
					return true;
				}
				if (animal.MovementAxisSmoothed != Vector3.zero || animal.MovementDetected)
				{
					return true;
				}
			}
			return false;
		}

		public override void Activate()
		{
			animal.UseSprintState = true;
			base.Activate();
			if (!animal.UseSmoothVertical || (animal.UseSmoothVertical && (double)animal.RawInputAxis.magnitude > 0.7))
			{
				SetEnterStatus((int)animal.CurrentSpeedModifier.Vertical.Value);
			}
			CheckCurrentWallProfile(animal.CurrentSpeedIndex);
			animal.OnMovementDetected.AddListener(OnMovementDetected);
			OnMovementDetected(movementDetected: true);
			InputAxisUpdate();
		}

		public override void ExitState()
		{
			base.ExitState();
			animal.OnMovementDetected.RemoveListener(OnMovementDetected);
		}

		private void OnMovementDetected(bool movementDetected)
		{
			if (base.InCoreAnimation && base.IsActiveState && !movementDetected)
			{
				int exitStatus = ((!animal.sprint || !animal.UseSprintState || animal.CurrentSpeedSetIsLocked) ? animal.CurrentSpeedIndex : animal.CurrentSpeedSet.SprintIndex);
				SetExitStatus(exitStatus);
				if (animal.Rotate_at_Direction)
				{
					animal.MovementAxis.z = 1f;
					animal.MovementAxisRaw.z = 1f;
				}
			}
		}

		public override void EnterCoreAnimation()
		{
			SetExitStatus(0);
			SetEnterStatus((int)base.CurrentSpeed.Vertical.Value);
			animal.TryAnimParameter(animal.hash_LastState, 1);
			if ((int)animal.LastState.ID == StateEnum.Climb)
			{
				animal.ResetCameraInput();
			}
			if (ResetIntertia.Value)
			{
				animal.ResetInertiaSpeed();
			}
		}

		public override void EnterTagAnimation()
		{
			if (base.CurrentAnimTag == base.EnterTagHash)
			{
				animal.VerticalSmooth = animal.CurrentSpeedModifier.Vertical;
				SetEnterStatus(0);
			}
		}

		public override void OnStatePreMove(float deltatime)
		{
			Wall_Stop();
			Anti_Fall();
		}

		public override void OnStateMove(float deltatime)
		{
			SetFloatSmooth(0f, deltatime * (float)base.CurrentSpeed.lerpPosition);
			if (General.Gravity)
			{
				if (!animal.Grounded)
				{
					animal.CheckIfGrounded_Height();
				}
				else if (!animal.FrontRay && !animal.MainRay)
				{
					animal.Grounded = false;
				}
			}
			if (base.InExitAnimation && base.Anim.IsInTransition(0))
			{
				animal.MovementAxis.z = 1f;
				animal.MovementAxisRaw.z = 1f;
			}
		}

		public override void SpeedModifierChanged(MSpeed speed, int SpeedIndex)
		{
			SetEnterStatus((int)speed.Vertical.Value);
			CheckCurrentWallProfile(SpeedIndex);
		}

		private void Wall_Stop()
		{
			if (!WallStop || currentProfile == null || !(base.MovementRaw.z > 0f))
			{
				return;
			}
			float num = currentProfile.RayLength * base.ScaleFactor;
			Vector3 main_Pivot_Point = animal.Main_Pivot_Point;
			Debug.DrawRay(main_Pivot_Point, animal.Forward * num, Color.yellow);
			MDebug.DrawWireSphere(main_Pivot_Point + animal.Forward * num, Color.yellow, 0.02f);
			if (Physics.Raycast(main_Pivot_Point, animal.Forward, out var hitInfo, num, StopLayer, base.IgnoreTrigger))
			{
				animal.MovementAxis.z = 0f;
				if ((bool)hitInfo.transform && WallHit != hitInfo.transform)
				{
					currentProfile.reaction?.React(animal);
					WallHit = hitInfo.transform;
				}
			}
			else
			{
				Debug.DrawRay(main_Pivot_Point, animal.Forward * num, DebugColor);
				if ((bool)WallHit)
				{
					WallHit = null;
					currentProfile.NoWallDetected?.React(animal);
				}
			}
		}

		private void CheckCurrentWallProfile(int SpeedIndex)
		{
			if (!WallStop)
			{
				return;
			}
			foreach (WallStopProfiles wallStopProfile in wallStopProfiles)
			{
				if (wallStopProfile.SpeedIndex <= (float)SpeedIndex)
				{
					currentProfile = wallStopProfile;
				}
			}
		}

		public override void ResetStateValues()
		{
			currentProfile = null;
			WallHit = null;
		}

		private void Anti_Fall()
		{
			if (!AntiFall)
			{
				return;
			}
			MovementAxisMult = Vector3.one;
			if (animal.UseCameraInput)
			{
				bool flag = false;
				float z = base.MovementRaw.z;
				Vector3 vector = ((animal.TerrainSlope > 0f) ? base.Gravity : (-animal.Up));
				float value = animal.CurrentSpeedModifier.Vertical.Value;
				value += (animal.Sprint ? 1f : 0f);
				float num = animal.Pivot_Multiplier * FallMultiplier * base.ScaleFactor;
				Vector3 vector2 = animal.Pivot_Chest.World(animal.transform);
				Vector3 vector3;
				Vector3 vector4;
				Vector3 vector5;
				if (z > 0f)
				{
					vector3 = vector2 + frontDistance * base.ScaleFactor * value * animal.Forward;
					vector4 = vector3 + frontSpace * base.ScaleFactor * animal.Right;
					vector5 = vector3 + frontSpace * base.ScaleFactor * -animal.Right;
				}
				else
				{
					if (!(z < 0f))
					{
						return;
					}
					vector3 = vector2 - BackDistance * base.ScaleFactor * value * animal.Forward;
					vector4 = vector3 + BackSpace * base.ScaleFactor * animal.Right;
					vector5 = vector3 + BackSpace * base.ScaleFactor * -animal.Right;
				}
				Debug.DrawRay(vector3, vector * num, DebugColor);
				Debug.DrawRay(vector4, vector * num, DebugColor);
				Debug.DrawRay(vector5, vector * num, DebugColor);
				int num2 = Physics.RaycastNonAlloc(vector3, vector, hits, num, base.GroundLayer, base.IgnoreTrigger);
				if (num2 == 0)
				{
					flag = true;
				}
				else
				{
					num2 = Physics.RaycastNonAlloc(vector4, vector, hits, num, base.GroundLayer, base.IgnoreTrigger);
				}
				if (num2 == 0)
				{
					flag = true;
				}
				else if (Physics.RaycastNonAlloc(vector5, vector, hits, num, base.GroundLayer, base.IgnoreTrigger) == 0)
				{
					flag = true;
				}
				if (flag)
				{
					MovementAxisMult.z = 0f;
				}
			}
			else if (base.MovementRaw.z < 0f)
			{
				Vector3 vector6 = (animal.Has_Pivot_Hip ? animal.Pivot_Hip.World(transform) : animal.Pivot_Chest.World(transform)) + base.Forward * (0f - (float)FallRayBackwards * base.ScaleFactor);
				float num3 = animal.Pivot_Multiplier * base.ScaleFactor;
				Debug.DrawRay(vector6, -base.Up * num3, Color.white);
				if (Physics.RaycastNonAlloc(vector6, -base.Up, hits, num3, base.GroundLayer, base.IgnoreTrigger) == 0)
				{
					MovementAxisMult.z = 0f;
				}
			}
		}
	}
}
