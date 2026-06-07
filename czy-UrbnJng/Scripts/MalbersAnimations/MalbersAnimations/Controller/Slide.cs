using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class Slide : State
	{
		[Header("Slide Movement & Rotation")]
		[Tooltip("Lerp value for the Aligment to the surface")]
		public FloatReference OrientLerp = new FloatReference(10f);

		[Tooltip("The rotation of the character while sliding will be ignored. This value is overriden by the Ground Slide Data")]
		public BoolReference ignoreRotation = new BoolReference();

		private bool IgnoreRotation;

		[Tooltip("When Sliding the Animal will be able to orient towards the direction of this given angle")]
		public FloatReference RotationAngle = new FloatReference(30f);

		[Tooltip("When Sliding the Animal will be able to Move horizontally with this value")]
		public FloatReference SideMovement = new FloatReference(5f);

		[Header("Enter Conditions")]
		[Tooltip("If the Slope of the Slide ground is greater that this value, the Slide State be Activated. Zero value will ignore Enter by Slope")]
		public FloatReference EnterAngleSlope = new FloatReference(0f);

		[Tooltip("Enter the Slide state if the Character is facing the slope.. Default value 90")]
		public FloatReference FacingAngleSlope = new FloatReference(90f);

		[Header("Exit Conditions")]
		[Tooltip("If the Speed is lower than this value the Slide state will end.")]
		public FloatReference ExitSpeed = new FloatReference(0.5f);

		[Tooltip("If the Slope of the Slide ground is greater that this value, the Slide State will exit")]
		public FloatReference ExitAngleSlope = new FloatReference(60f);

		[Tooltip("When a Flat terrain is reached. it will wait this time to transition to Locomotion or Idle")]
		public FloatReference ExitWaitTime = new FloatReference(0.5f);

		private float currentExitTime;

		private float additiveSide;

		private float DeltaAngle;

		public override string StateName => "Slide";

		public override string StateIDName => "Slide";

		public override bool KeepForwardMovement => true;

		private Vector3 HorizontalLerp { get; set; }

		public override bool TryActivate()
		{
			return TrySlideGround();
		}

		public override void OnPlataformChanged(Transform newPlatform)
		{
			if (!base.IsActiveState && TrySlideGround() && base.CanBeActivated)
			{
				Activate();
			}
		}

		public override void Activate()
		{
			base.Activate();
			IgnoreRotation = ignoreRotation.Value;
			additiveSide = 0f;
			if (animal.InGroundChanger)
			{
				animal.CurrentSpeedModifier.position.Value += animal.GroundChanger.SlideData.AdditiveForwardSpeed;
				IgnoreRotation = animal.GroundChanger.SlideData.IgnoreRotation;
				additiveSide = animal.GroundChanger.SlideData.AdditiveHorizontalSpeed;
			}
			currentExitTime = 0f;
		}

		private bool TrySlideGround()
		{
			if (m_debug && animal.debugGizmos && animal.Grounded)
			{
				MDebug.Draw_Arrow(base.Position, Vector3.ProjectOnPlane(animal.SlopeDirection, base.Up), Color.white);
			}
			if (animal.InGroundChanger && animal.GroundChanger.SlideData.Slide && animal.SlopeDirectionAngle >= animal.GroundChanger.SlideData.MinAngle && animal.SlopeDirectionAngle <= (float)ExitAngleSlope)
			{
				if (Vector3.Angle(animal.Forward, animal.SlopeDirection) < animal.GroundChanger.SlideData.ActivationAngle / 2f)
				{
					return true;
				}
			}
			else if ((float)EnterAngleSlope > 0f && animal.Grounded && animal.SlopeDirectionAngle > EnterAngleSlope.Value && Vector3.Angle(animal.Forward, Vector3.ProjectOnPlane(animal.SlopeDirection, base.Up)) < FacingAngleSlope.Value / 2f)
			{
				return true;
			}
			return false;
		}

		public override void InputAxisUpdate()
		{
			Vector3 vector = animal.RawInputAxis;
			if ((bool)AlwaysForward)
			{
				animal.RawInputAxis.z = 1f;
			}
			DeltaAngle = vector.x;
			Vector3 vector2 = Vector3.ProjectOnPlane(animal.SlopeDirection, animal.UpVector);
			if ((bool)animal.MainCamera)
			{
				Vector3 normalized = Vector3.ProjectOnPlane(animal.MainCamera.forward, base.UpVector).normalized;
				Vector3 normalized2 = Vector3.ProjectOnPlane(animal.MainCamera.right, base.UpVector).normalized;
				vector = animal.RawInputAxis.z * normalized + animal.RawInputAxis.x * normalized2;
				DeltaAngle = Vector3.Dot(animal.Right, vector);
			}
			vector2 = Quaternion.AngleAxis((float)RotationAngle * DeltaAngle, animal.Up) * vector2;
			if (currentExitTime > 0f)
			{
				vector2 = Vector3.zero;
			}
			animal.MoveFromDirection(vector2);
			HorizontalLerp = Vector3.Lerp(HorizontalLerp, Vector3.Project(vector, animal.Right), animal.DeltaTime * (float)base.CurrentSpeed.lerpPosition);
			if (base.GizmoDebug)
			{
				MDebug.Draw_Arrow(transform.position, HorizontalLerp, Color.white);
			}
		}

		public override Vector3 Speed_Direction()
		{
			Vector3 vector = animal.SlopeDirection;
			if (!IgnoreRotation)
			{
				vector = Quaternion.AngleAxis((float)RotationAngle * DeltaAngle, animal.Up) * vector;
			}
			return vector;
		}

		public override void OnStateMove(float deltatime)
		{
			if (base.InCoreAnimation)
			{
				Vector3 onNormal = Vector3.Cross(animal.Up, animal.SlopeDirection);
				onNormal = Vector3.Project(animal.MovementAxisSmoothed, onNormal);
				if (base.GizmoDebug)
				{
					MDebug.Draw_Arrow(transform.position, onNormal, Color.red);
				}
				animal.AdditivePosition += deltatime * ((float)SideMovement + additiveSide) * HorizontalLerp;
				animal.AlignRotation(animal.SlopeNormal, deltatime, OrientLerp);
				if (IgnoreRotation)
				{
					animal.AlignRotation(animal.Forward, animal.SlopeDirection, deltatime, OrientLerp);
					animal.UseAdditiveRot = false;
				}
				if (!animal.Grounded)
				{
					animal.UseGravity = true;
				}
			}
		}

		public override void TryExitState(float DeltaTime)
		{
			if (animal.SlopeDirectionAngle > (float)ExitAngleSlope || !animal.MainRay)
			{
				animal.Grounded = false;
				Debugging("[Allow Exit] Exit to Fall. Terrain Slope is too deep");
				AllowExit(3, 0);
			}
			else if (animal.InGroundChanger)
			{
				if (!animal.GroundChanger.SlideData.Slide)
				{
					Debugging("[Allow Exit] No longer in a Slide Ground Changer");
					AllowExit();
				}
			}
			else if ((float)EnterAngleSlope > 0f && animal.SlopeDirectionAngle < (float)EnterAngleSlope)
			{
				currentExitTime += DeltaTime;
				if (currentExitTime > (float)ExitWaitTime)
				{
					Debugging("[Allow Exit] No longer in a slope angle");
					AllowExit();
					currentExitTime = 0f;
				}
			}
			else
			{
				currentExitTime = 0f;
			}
			if (animal.HorizontalSpeed <= (float)ExitSpeed)
			{
				Debugging("[Allow Exit] Speed is Slow");
				AllowExit();
			}
		}

		internal override void Reset()
		{
			base.Reset();
			General = new AnimalModifier
			{
				RootMotion = true,
				Grounded = true,
				Sprint = true,
				OrientToGround = false,
				CustomRotation = true,
				IgnoreLowerStates = true,
				AdditivePosition = true,
				AdditiveRotation = true,
				Gravity = false,
				modify = (modifier)(-1)
			};
		}
	}
}
