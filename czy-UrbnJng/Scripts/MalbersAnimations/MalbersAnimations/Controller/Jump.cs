using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class Jump : State
	{
		[Header("Jump Parameters")]
		[Tooltip("If the Jump input is pressed, the Animal will keep going Up while the Jump Animation is Playing")]
		public BoolReference JumpPressed;

		[Tooltip("Check if the Animal can control the Forward Movement of the Jump")]
		public BoolReference ForwardPressed;

		[Tooltip("Lerp Value for Pressing Jump. THis will smooth out exiting the height of the jump ")]
		public float JumpPressedLerp = 5f;

		[Tooltip("Can the Animal be Rotated while Jumping?")]
		public BoolReference AirControl = new BoolReference(value: true);

		[Tooltip("How much Rotation the Animal can do while Jumping")]
		public FloatReference AirRotation = new FloatReference(10f);

		[Tooltip("Amount of jumps the Animal can do (Double and Triple Jumps)")]
		public IntReference Jumps = new IntReference(1);

		[Space]
		[Tooltip("How much Movement the Animal can do while Jumping")]
		public List<StateID> ResetJump = new List<StateID>();

		[Tooltip("It will use the Index of the jumps profiles instead of getting the Index from ")]
		public int lockJumpProfile = -1;

		private float JumpPressHeight_Value = 1f;

		private float JumpPressForward = 1f;

		private float JumpPressForwardAdditive;

		[Tooltip("If the animal is going up a hill, the Jump will align to the Slope of the Terrain.")]
		public bool KeepHeightOnHighSlope;

		public List<JumpProfile> jumpProfiles = new List<JumpProfile>();

		protected MSpeed JumpSpeed;

		protected bool OneCastingFall_Ray;

		protected JumpProfile activeJump;

		private RaycastHit JumpRay;

		private Vector3 JumpStartDirection;

		public override string StateName => "Jump/Root Motion Jump";

		public override string StateIDName => "Jump";

		public int JumpsPerformanced { get; set; }

		public void LockJumpProfile(int index)
		{
			index = Mathf.Clamp(index, 0, jumpProfiles.Count - 1);
			activeJump = jumpProfiles[index];
			animal.VerticalSmooth = activeJump.VerticalSpeed;
			animal.SetAnimParameter(animal.hash_Vertical, animal.VerticalSmooth);
		}

		public override bool TryActivate()
		{
			if (InputValue)
			{
				return JumpsPerformanced < (int)Jumps;
			}
			return false;
		}

		public override void ResetStateValues()
		{
			JumpPressHeight_Value = 1f;
			JumpPressForward = 1f;
			JumpPressForwardAdditive = 0f;
			OneCastingFall_Ray = false;
		}

		public override void AwakeState()
		{
			if (string.IsNullOrEmpty(EnterTag))
			{
				EnterTag.Value = "JumpStart";
			}
			if (string.IsNullOrEmpty(ExitTag))
			{
				ExitTag.Value = "JumpEnd";
			}
			if (!CanTransitionToItself)
			{
				CanTransitionToItself = true;
			}
			base.AwakeState();
		}

		public override void Activate()
		{
			if (JumpsPerformanced < (int)Jumps && (!(base.ActiveState == this) || !(animal.StateTime < 0.25f)))
			{
				base.Activate();
				base.IgnoreLowerStates = true;
				animal.currentSpeedModifier.animator = 1f;
				JumpsPerformanced++;
				SetEnterStatus(JumpsPerformanced);
				FindJumpProfile();
			}
		}

		public override void EnterTagAnimation()
		{
			if (base.CurrentAnimTag == base.EnterTagHash)
			{
				Debugging("[EnterTag - " + EnterTag.Value + "]");
				animal.DeltaPos = Vector3.zero;
				if (!animal.RootMotion)
				{
					MSpeed mSpeed = new MSpeed(animal.CurrentSpeedModifier);
					mSpeed.name = "JumpStartSpeed";
					mSpeed.position = animal.HorizontalSpeed;
					mSpeed.Vertical = animal.CurrentSpeedModifier.Vertical.Value;
					mSpeed.animator = 1f;
					mSpeed.rotation = AirRotation.Value;
					MSpeed customSpeed = mSpeed;
					animal.SetCustomSpeed(customSpeed);
				}
				JumpStartDirection = animal.Forward;
				if (animal.TerrainSlope > 0f)
				{
					animal.UseCustomRotation = true;
				}
			}
			else if (base.CurrentAnimTag == base.ExitTagHash)
			{
				base.CanExit = true;
				Debugging("[Using ExitTag - " + ExitTag.Value + "] - Allow Exit");
				AllowExit();
			}
		}

		public override Vector3 Speed_Direction()
		{
			if (animal.HasExternalForce)
			{
				return Vector3.ProjectOnPlane(animal.ExternalForce, animal.UpVector);
			}
			if ((bool)AirControl)
			{
				return base.Speed_Direction();
			}
			return JumpStartDirection;
		}

		public override void EnterCoreAnimation()
		{
			Debugging("[Enter Core Tag - [Jump]");
			animal.ResetSlopeValues();
			OneCastingFall_Ray = false;
			JumpPressHeight_Value = 1f;
			JumpPressForward = 1f;
			JumpPressForwardAdditive = 0f;
			animal.UseGravity = false;
			animal.Gravity_ResetValues();
			JumpSpeed = new MSpeed(animal.CurrentSpeedModifier)
			{
				name = "Jump [" + activeJump.name + "]",
				position = (animal.RootMotion ? 0f : (animal.HorizontalSpeed * activeJump.ForwardMultiplier)),
				animator = 1f,
				rotation = AirRotation.Value,
				lerpPosAnim = JumpPressedLerp,
				lerpPosition = JumpPressedLerp
			};
			animal.SetCustomSpeed(JumpSpeed);
			JumpStartDirection = animal.Forward;
			if (animal.TerrainSlope > 0f && animal.MovementDetected && KeepHeightOnHighSlope)
			{
				animal.UseCustomRotation = true;
			}
		}

		private void FindJumpProfile()
		{
			activeJump = ((jumpProfiles != null) ? jumpProfiles[0] : default(JumpProfile));
			bool flag = false;
			foreach (JumpProfile jumpProfile in jumpProfiles)
			{
				if (jumpProfile.LastState == null)
				{
					if (jumpProfile.VerticalSpeed <= animal.VerticalSmooth && !flag)
					{
						activeJump = jumpProfile;
					}
				}
				else if (jumpProfile.VerticalSpeed <= animal.VerticalSmooth && jumpProfile.LastState == animal.LastState.ID)
				{
					activeJump = jumpProfile;
					flag = true;
				}
			}
			if (activeJump.CliffTime.minValue == 0f && activeJump.CliffTime.maxValue == 0f)
			{
				activeJump.CliffTime = new RangedFloat(0.333f, 0.666f);
			}
			Debugging($"Jump Profile: <B>[{activeJump.name}] - Speed [{activeJump.VerticalSpeed}] Current Speed: [{animal.VerticalSmooth:F2}]</B>");
		}

		public override void OnStateMove(float deltaTime)
		{
			if (base.InCoreAnimation)
			{
				if (animal.StateTime >= activeJump.fallingTime)
				{
					base.IsPersistent = false;
				}
				if (activeJump.JumpLandDistance == 0f)
				{
					return;
				}
				if ((bool)JumpPressed)
				{
					JumpPressHeight_Value = Mathf.MoveTowards(JumpPressHeight_Value, InputValue ? 1 : 0, deltaTime * JumpPressedLerp);
				}
				if ((bool)ForwardPressed)
				{
					JumpPressForward = Mathf.MoveTowards(JumpPressForward, animal.MovementAxis.z, deltaTime * JumpPressedLerp);
					JumpPressForwardAdditive = Mathf.MoveTowards(JumpPressForwardAdditive, animal.MovementAxis.z, deltaTime * JumpPressedLerp);
				}
				if (!General.RootMotion)
				{
					Vector3 vector = animal.Up * activeJump.HeightMultiplier;
					animal.AdditivePosition += deltaTime * JumpPressHeight_Value * vector;
					return;
				}
				Vector3 vector2 = Vector3.Project(base.Anim.deltaPosition, animal.Up);
				if (Vector3.Dot(vector2, animal.Up) > 0f)
				{
					animal.AdditivePosition -= vector2;
					animal.AdditivePosition += activeJump.HeightMultiplier * JumpPressHeight_Value * vector2;
				}
				Vector3 vector3 = base.Anim.deltaPosition - vector2;
				animal.AdditivePosition -= vector3;
				if (!AirControl.Value)
				{
					animal.AdditivePosition += activeJump.ForwardMultiplier * vector3.magnitude * JumpStartDirection;
				}
				else
				{
					animal.AdditivePosition += activeJump.ForwardMultiplier * JumpPressForward * vector3 + activeJump.ForwardPressed * deltaTime * JumpPressForwardAdditive * animal.Forward;
				}
			}
			else if (base.ExitTagHash == base.CurrentAnimTag && !animal.CheckIfGrounded())
			{
				animal.UseGravity = true;
			}
		}

		public override void TryExitState(float DeltaTime)
		{
			if (animal.StateTime >= activeJump.fallingTime && !OneCastingFall_Ray)
			{
				Check_for_Falling();
			}
			if (activeJump.ExitTime >= activeJump.fallingTime && animal.StateTime >= activeJump.ExitTime)
			{
				Debugging($"[Allow Exit] - Exit Time [{activeJump.ExitTime}] ");
				animal.CheckIfGrounded();
				AllowExit();
			}
			CheckForGround(animal.StateTime);
		}

		private void CheckForGround(float normalizedTime)
		{
			if (activeJump.CliffLandDistance == 0f || !activeJump.CliffTime.IsInRange(normalizedTime))
			{
				return;
			}
			float num = activeJump.CliffLandDistance * base.ScaleFactor;
			Vector3 main_Pivot_Point = animal.Main_Pivot_Point;
			if (m_debug)
			{
				Debug.DrawRay(main_Pivot_Point, -animal.Up * num, Color.black, 0.1f);
			}
			if (Physics.Raycast(main_Pivot_Point, -animal.Up, out JumpRay, num, base.GroundLayer, base.IgnoreTrigger))
			{
				if (m_debug)
				{
					MDebug.DebugTriangle(JumpRay.point, 0.1f, Color.black);
				}
				if (!(Vector3.Angle(JumpRay.normal, animal.UpVector) > animal.SlopeLimit))
				{
					Debugging($"[Allow Exit] Cliff Time - Near Ground. Normalized time: {normalizedTime:F2} ");
					AllowExit();
					animal.CheckIfGrounded();
				}
			}
		}

		private void Check_for_Falling()
		{
			AllowExit();
			OneCastingFall_Ray = true;
			if (activeJump.JumpLandDistance == 0f)
			{
				animal.CheckIfGrounded();
				return;
			}
			float num = animal.ScaleFactor * activeJump.JumpLandDistance;
			Vector3 main_Pivot_Point = animal.Main_Pivot_Point;
			Vector3 vector = -animal.Up;
			if (!(activeJump.JumpLandDistance > 0f))
			{
				return;
			}
			if (m_debug)
			{
				Debug.DrawRay(main_Pivot_Point, vector * num, Color.red, 0.25f);
			}
			if (Physics.Raycast(main_Pivot_Point, vector, out JumpRay, num, base.GroundLayer, base.IgnoreTrigger))
			{
				Debugging($"Min Distance to complete <B>[{activeJump.name}]-> <Color=green>[[{JumpRay.distance:F4}]]</color></B>");
				if (m_debug)
				{
					MDebug.DebugTriangle(JumpRay.point, 0.1f, Color.yellow);
				}
				float num2 = Vector3.Angle(JumpRay.normal, animal.UpVector);
				if (num2 > animal.SlopeLimit)
				{
					Debugging($"[AllowExit] Try to Land but the Sloope was too Deep. Slope: {num2:F2}");
					animal.UseGravity = General.Gravity;
				}
				else if (JumpRay.distance < animal.Height)
				{
					Debugging($"Allow Exit, Near the Ground  Jump Distance: [{JumpRay.distance}]. Height {animal.Height}");
					AllowExit();
				}
				else
				{
					base.IgnoreLowerStates = true;
					Debugging("Can finish the Jump. Going to Jump End");
				}
			}
			else
			{
				animal.UseGravity = General.Gravity;
				Debugging("[Allow Exit] - <B>Jump [" + activeJump.name + "] </B> Go to Fall..No Ground was found");
			}
		}

		public override void NewActiveState(StateID newState)
		{
			if (newState.ID != (int)ID)
			{
				if ((int)newState <= 1 || ResetJump.Contains(newState))
				{
					JumpsPerformanced = 0;
					base.OnHoldByReset = false;
				}
				else if ((int)newState == StateEnum.Fall && (bool)animal.LastState && (int)animal.LastState.ID <= 1)
				{
					JumpsPerformanced++;
					base.OnHoldByReset = false;
				}
			}
		}
	}
}
