using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class JumpBasic : State
	{
		private int JumpEndHash = Animator.StringToHash("JumpEnd");

		private int JumpStartHash = Animator.StringToHash("JumpStart");

		[Header("Jump Parameters")]
		[Tooltip("How much Rotation the character can do while Jumping")]
		public FloatReference AirRotation = new FloatReference(10f);

		[Tooltip("How much movement is allowed when the character is on the air")]
		public FloatReference AirMovement = new FloatReference(5f);

		[Tooltip("Smooth Value for Changing Speed Movement on the Air")]
		public FloatReference AirSmooth = new FloatReference(5f);

		[Tooltip("Keep the  Up Inertia from platforms or going upwards to keep the height of the jump")]
		public BoolReference KeepUPIntertia = new BoolReference(value: true);

		[Tooltip("Amount of jumps the character can do (Double and Triple Jumps)")]
		public IntReference Jumps = new IntReference(1);

		[Tooltip("Time needed to use the Double Jump again, so you don't have jumps to close to each other")]
		public FloatReference DoubleJumpTime = new FloatReference(0.3f);

		[Tooltip("The Jump can be interrupted if a ground is found in the middle of the jump. This is the multiplier to cast the Ray using the Animal Height.")]
		public FloatReference JumpInterruptRay = new FloatReference(0.9f);

		[Tooltip("Lerp Value for Pressing Jump. THis will smooth out exiting the height of the jump ")]
		public FloatReference JumpPressedLerp = new FloatReference(5f);

		[Space]
		[Tooltip("Which states will reset the Jump Count. Idle and Locomotion are set by default. E.g. Swim can Reset the Jump State and the character can jump while swimming ")]
		public List<StateID> ResetJump;

		public List<JumpBasicProfile> profiles = new List<JumpBasicProfile>();

		public List<JumpDoubleProfile> multipleJumps = new List<JumpDoubleProfile>();

		private JumpBasicProfile activeJump;

		protected MSpeed JumpSpeed;

		private bool IsDoubleJump;

		private bool ActivateJumpLogic;

		private bool justJumpPressed;

		private float StartedJumpLogicTime;

		private float JumpStartTime;

		private float JumpPressHeight_Value = 1f;

		private Transform LastPlatform;

		public override string StateName => "Jump/Basic Jump";

		public override string StateIDName => "Jump";

		public override bool InputValue
		{
			get
			{
				return base.InputValue;
			}
			set
			{
				base.InputValue = value;
				if (!value)
				{
					CanMultipleJump = true;
				}
			}
		}

		public Vector3 StartingSpeedDirection { get; private set; }

		public override bool KeepForwardMovement => !activeJump.AirControl.Value;

		public int JumpsPerformanced { get; set; }

		public bool CanMultipleJump { get; internal set; }

		public override void AwakeState()
		{
			base.AwakeState();
			activeJump = profiles[0];
			if (base.EnterTagHash != 0)
			{
				JumpStartHash = base.EnterTagHash;
			}
			if (base.ExitTagHash != 0)
			{
				JumpEndHash = base.ExitTagHash;
			}
		}

		public override void ResetStateValues()
		{
			JumpPressHeight_Value = 1f;
			ActivateJumpLogic = false;
			justJumpPressed = false;
			StartedJumpLogicTime = 0f;
			JumpStartTime = Time.time;
			IsDoubleJump = false;
			StartingSpeedDirection = Vector3.zero;
		}

		public override bool TryActivate()
		{
			if (animal.LockInput)
			{
				return false;
			}
			if (InputValue && JumpsPerformanced < (int)Jumps)
			{
				return CanMultipleJump;
			}
			return false;
		}

		public override void StatebyInput()
		{
			if (InputValue && JumpsPerformanced < (int)Jumps && CanMultipleJump)
			{
				Activate();
			}
		}

		public void ActivateJump()
		{
			ActivateJumpLogic = true;
			justJumpPressed = true;
			animal.Grounded = false;
			StartedJumpLogicTime = 0f;
			JumpStartTime = Time.time;
			animal.GravityTime = activeJump.StartGravityTime;
			StartingSpeedDirection = animal.HorizontalVelocity;
			Debugging("[Basic Jump] Activate JumpLogic");
			animal.platform = null;
			LastPlatform = null;
		}

		public override void Activate()
		{
			if (JumpsPerformanced < (int)Jumps && MTools.ElapsedTime(JumpStartTime, DoubleJumpTime))
			{
				CanMultipleJump = false;
				base.Activate();
				animal.State_SetFloat(0f);
				JumpsPerformanced++;
				JumpStartTime = Time.time;
				General.Gravity = false;
				base.IsPersistent = true;
				animal.currentSpeedModifier.animator = 1f;
				animal.Gravity_ResetValues();
				StartingSpeedDirection = animal.HorizontalVelocity;
				FindJumpProfile();
			}
			LastPlatform = animal.platform;
			animal.UpInertia_Clear();
			if (animal.platform != null)
			{
				animal.UpInertia_Store();
			}
		}

		public void LockJumpProfile(int index)
		{
			index = Mathf.Clamp(index, 0, profiles.Count - 1);
			activeJump = profiles[index];
			animal.VerticalSmooth = activeJump.VerticalSpeed;
			animal.SetAnimParameter(animal.hash_Vertical, animal.VerticalSmooth);
		}

		private void FindJumpProfile()
		{
			activeJump = ((profiles != null && profiles.Count > 0) ? profiles[0] : default(JumpBasicProfile));
			foreach (JumpBasicProfile profile in profiles)
			{
				if (profile.LastState == null)
				{
					if (profile.VerticalSpeed <= animal.VerticalSmooth)
					{
						activeJump = profile;
					}
				}
				else if (profile.VerticalSpeed <= animal.VerticalSmooth && profile.LastState == animal.LastState.ID)
				{
					activeJump = profile;
				}
			}
			int enterStatus = 0;
			if ((int)Jumps > 1 && JumpsPerformanced > 1 && multipleJumps != null && multipleJumps.Count > 0)
			{
				JumpDoubleProfile jumpDoubleProfile = new JumpDoubleProfile
				{
					JumpNumber = -1
				};
				foreach (JumpDoubleProfile multipleJump in multipleJumps)
				{
					if (JumpsPerformanced == multipleJump.JumpNumber)
					{
						jumpDoubleProfile = multipleJump;
					}
				}
				if (jumpDoubleProfile.JumpNumber != -1)
				{
					activeJump.name = jumpDoubleProfile.name;
					activeJump.GravityPower = jumpDoubleProfile.GravityPower;
					activeJump.Height = jumpDoubleProfile.Height;
					activeJump.JumpTime = jumpDoubleProfile.JumpTime;
					activeJump.StartGravityTime = jumpDoubleProfile.StartGravityTime;
					activeJump.WaitForAnimation = jumpDoubleProfile.WaitForAnimation;
					activeJump.AirControl = jumpDoubleProfile.AirControl;
					enterStatus = jumpDoubleProfile.JumpNumber;
					IsDoubleJump = true;
				}
			}
			SetEnterStatus(enterStatus);
		}

		public override void EnterCoreAnimation()
		{
			Debugging($"Jump Profile: [{activeJump.name}] Jumps <B> Performanced:[{JumpsPerformanced}] </B>");
			JumpPressHeight_Value = 1f;
			animal.ResetSlopeValues();
			float num = animal.HorizontalSpeed / base.ScaleFactor;
			if ((float)activeJump.JumpInterruptRay == 0f)
			{
				activeJump.JumpInterruptRay = 1f;
			}
			if (activeJump.ClampForward > 0f)
			{
				num = Mathf.Clamp(num, 0f, activeJump.ClampForward);
			}
			if (animal.HasExternalForce)
			{
				Vector3 vector = Vector3.ProjectOnPlane(animal.ExternalForce, animal.UpVector);
				num = (Vector3.ProjectOnPlane(animal.Inertia, animal.UpVector) - vector).magnitude / base.ScaleFactor;
			}
			if (!animal.ExternalForceAirControl)
			{
				num = 0f;
			}
			JumpSpeed = new MSpeed(animal.CurrentSpeedModifier)
			{
				name = "Jump [" + activeJump.name + "] Speed",
				position = (General.RootMotion ? 0f : num),
				strafeSpeed = (General.RootMotion ? 0f : num),
				lerpPosition = AirSmooth.Value,
				lerpStrafe = AirSmooth.Value,
				rotation = AirRotation.Value,
				animator = 1f
			};
			animal.SetCustomSpeed(JumpSpeed);
			animal.GravityExtraPower = activeJump.GravityPower.Value;
			if (IsDoubleJump)
			{
				ActivateJump();
				animal.UpInertia_Clear();
			}
			else if (!activeJump.WaitForAnimation)
			{
				ActivateJump();
			}
			else
			{
				Vector3 last_Platform_Pos = animal.Last_Platform_Pos;
				animal.SetPlatform(LastPlatform);
				animal.Last_Platform_Pos = last_Platform_Pos;
			}
		}

		public override Vector3 Speed_Direction()
		{
			if (base.GizmoDebug)
			{
				MDebug.Draw_Arrow(base.Position, StartingSpeedDirection * 2f, Color.red);
			}
			if (!activeJump.AirControl.Value)
			{
				return StartingSpeedDirection;
			}
			return base.Speed_Direction();
		}

		public override void EnterTagAnimation()
		{
			if (base.CurrentAnimTag == JumpStartHash && !animal.RootMotion)
			{
				float num = animal.HorizontalSpeed / base.ScaleFactor;
				if (animal.HasExternalForce)
				{
					Vector3 vector = Vector3.ProjectOnPlane(animal.ExternalForce, animal.UpVector);
					num = (Vector3.ProjectOnPlane(animal.Inertia, animal.UpVector) - vector).magnitude / base.ScaleFactor;
				}
				MSpeed mSpeed = new MSpeed(animal.CurrentSpeedModifier);
				mSpeed.name = "JumpStartSpeed";
				mSpeed.position = num;
				mSpeed.Vertical = animal.CurrentSpeedModifier.Vertical;
				mSpeed.animator = 1f;
				mSpeed.rotation = ((!activeJump.AirControl.Value) ? 0f : ((!animal.UseCameraInput) ? AirRotation.Value : (AirRotation.Value / 10f)));
				mSpeed.strafeSpeed = num;
				mSpeed.lerpStrafe = AirSmooth;
				MSpeed customSpeed = mSpeed;
				Debugging("[EnterTag-JumpStart]");
				animal.SetCustomSpeed(customSpeed);
				if (animal.TerrainSlope > 0f)
				{
					animal.UseCustomRotation = true;
				}
			}
			else if (base.CurrentAnimTag == JumpEndHash)
			{
				Debugging("[EnterTag-JumpEnd]");
				AllowExit();
			}
		}

		public override void OnStateMove(float deltaTime)
		{
			if (!base.InCoreAnimation)
			{
				return;
			}
			StartedJumpLogicTime += deltaTime;
			if (ActivateJumpLogic)
			{
				if (KeepUPIntertia.Value)
				{
					animal.UpInertia_Apply();
				}
				if (activeJump.JumpPressed.Value)
				{
					if (!InputValue)
					{
						justJumpPressed = false;
					}
					JumpPressHeight_Value = Mathf.Lerp(JumpPressHeight_Value, (InputValue && justJumpPressed) ? 1 : 0, deltaTime * (float)JumpPressedLerp);
				}
				if (activeJump.ForwardPush > 0f)
				{
					animal.AdditivePosition += activeJump.ForwardPush * deltaTime * base.ScaleFactor * base.Forward;
				}
				if ((float)AirMovement > base.CurrentSpeedPos && (bool)activeJump.AirControl)
				{
					if (!animal.ExternalForceAirControl)
					{
						return;
					}
					base.CurrentSpeedPos = Mathf.Lerp(base.CurrentSpeedPos, AirMovement, ((float)AirSmooth != 0f) ? (deltaTime * (float)AirSmooth) : 1f);
				}
				Vector3 vector = base.UpVector * activeJump.Height.Value;
				animal.AdditivePosition += deltaTime * JumpPressHeight_Value * base.ScaleFactor * vector;
				if (StartedJumpLogicTime < activeJump.JumpTime)
				{
					base.IsPersistent = false;
				}
				if (!animal.IgnoreModeGravity)
				{
					animal.AdditivePosition += activeJump.GravityPower.Value * deltaTime * animal.StoredGravityVelocity();
					animal.GravityOffset = JumpPressHeight_Value * base.ScaleFactor * vector;
					animal.GravityTime++;
				}
			}
			else if (!General.RootMotion)
			{
				animal.AdditivePosition += Vector3.Project(base.Anim.deltaPosition, base.Up);
			}
		}

		public override void TryExitState(float deltaTime)
		{
			if (ActivateJumpLogic && StartedJumpLogicTime >= activeJump.JumpTime)
			{
				AllowExit(3, 0);
				Debugging("[Allow Exit]");
			}
		}

		public override void NewActiveState(StateID newState)
		{
			if (newState.ID != (int)ID)
			{
				if ((int)newState <= 1 || ResetJump.Contains(newState))
				{
					JumpsPerformanced = 0;
					CanMultipleJump = true;
				}
				else if ((int)newState == StateEnum.Fall && (bool)animal.LastState && animal.LastState.ID != ID)
				{
					JumpsPerformanced++;
				}
			}
		}
	}
}
