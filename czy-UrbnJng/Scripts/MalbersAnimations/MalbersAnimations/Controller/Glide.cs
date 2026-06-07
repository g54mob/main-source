using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/states/glide")]
	public class Glide : State
	{
		[Header("Glide Parameters")]
		public FloatReference GravityDrag = new FloatReference(3f);

		[Tooltip("Minimun Height required to activate the glide")]
		public FloatReference StartHeight = new FloatReference(0f);

		[Header("Free Movement Parameters")]
		[Tooltip("Bank amount used when turning")]
		public float Bank = 30f;

		[Tooltip("Limit to go Pitch")]
		public float PitchLimit;

		[Tooltip("Bank amount used when turning while straffing")]
		public float BankStrafe;

		[Tooltip("Limit to go Up and Down while straffing")]
		public float PitchStrafe;

		[Tooltip("When Entering the Glide State... The animal will keep the Velocity from the last State if this value is greater than zero")]
		public FloatReference InertiaLerp = new FloatReference(1f);

		[Tooltip("The animal will move forward while Gliding, without the need to push the W Key, or Move forward Input")]
		public BoolReference KeepForward = new BoolReference(value: false);

		[Tooltip("The animal will change the Camera Input while the Animal is using this State")]
		public BoolReference UseCameraInput = new BoolReference(value: true);

		[Header("Landing")]
		[Tooltip("Layers to Land on")]
		public LayerMask LandOn = 1;

		[Tooltip("Ray Length multiplier to check for ground near")]
		public FloatReference CheckLandDistance = new FloatReference(3f);

		[Tooltip("Ray Length multiplier to check for ground and automatically land (increases or decreases the MainPivot Lenght for the Fall Ray")]
		public FloatReference LandDistance = new FloatReference(1f);

		[Tooltip("Minimum Distance to Clamp the State Float")]
		public FloatReference LowerBlendDistance = new FloatReference(0.5f);

		public FloatReference LerpDistance = new FloatReference(2f);

		protected Vector3 verticalInertia;

		protected Vector3 DownPush;

		public override string StateName => "Glide";

		public override string StateIDName => "Glide";

		public override bool KeepForwardMovement => KeepForward.Value;

		public override bool InputValue
		{
			get
			{
				return base.InputValue;
			}
			set
			{
				base.InputValue = value;
				if (base.InCoreAnimation && base.IsActiveState && !value && base.CanExit)
				{
					AllowExit();
				}
			}
		}

		private bool CheckStartHeight()
		{
			if ((float)StartHeight <= 0f)
			{
				return true;
			}
			RaycastHit hitInfo;
			bool num = Physics.Raycast(animal.Main_Pivot_Point, animal.Gravity, out hitInfo, animal.Height + (float)StartHeight * base.ScaleFactor, animal.GroundLayer);
			if (num)
			{
				ResetInputOnFailed();
			}
			return !num;
		}

		public override bool TryActivate()
		{
			if (base.TryActivate() && TryOverride)
			{
				return CheckStartHeight();
			}
			return false;
		}

		public override void Activate()
		{
			base.Activate();
			animal.UseCameraInput = UseCameraInput;
			InputValue = true;
			animal.Force_Reset();
		}

		public override void EnterCoreAnimation()
		{
			verticalInertia = Vector3.Project(animal.DeltaPos, animal.UpVector);
			animal.PitchDirection = animal.Forward;
			animal.InertiaPositionSpeed = animal.HorizontalVelocity * animal.DeltaTime;
		}

		public override void OnStateMove(float deltaTime)
		{
			if (base.InCoreAnimation)
			{
				Vector3 b = ((animal.ExternalForce != Vector3.zero) ? Vector3.zero : ((float)GravityDrag * animal.ScaleFactor * deltaTime * base.Gravity));
				DownPush = Vector3.Lerp(DownPush, b, deltaTime * (float)InertiaLerp);
				animal.AdditivePosition += DownPush;
				float num = PitchLimit;
				float bank = Bank;
				if (animal.Strafe)
				{
					num = PitchStrafe;
					bank = BankStrafe;
				}
				animal.CalculateBank(bank);
				animal.PitchAngle = Mathf.Lerp(animal.PitchAngle, num * animal.VerticalSmooth, deltaTime * (float)animal.CurrentSpeedSet.PitchLerpOn);
				animal.CalculateRotator();
				if (InertiaLerp.Value > 0f)
				{
					animal.AddInertia(ref verticalInertia, InertiaLerp);
				}
			}
		}

		public override void TryExitState(float DeltaTime)
		{
			float num = CheckLandDistance.Value * animal.ScaleFactor;
			if (num <= 0f)
			{
				num = animal.Height;
			}
			float value = 1f;
			Debug.DrawRay(animal.Main_Pivot_Point, base.Gravity * num, Color.yellow);
			Debug.DrawRay(animal.Main_Pivot_Point, animal.ScaleFactor * (float)LandDistance * base.Gravity, Color.green);
			if (Physics.Raycast(animal.Main_Pivot_Point, base.Gravity, out var hitInfo, num, LandOn, base.IgnoreTrigger))
			{
				if ((float)LandDistance >= hitInfo.distance)
				{
					Debugging("[AllowExit] Can Land on <" + hitInfo.collider.name + "> ");
					animal.FreeMovement = false;
					animal.UseGravity = true;
					AllowExit();
					return;
				}
				value = Mathf.Clamp01(1f - (float)LandDistance / (hitInfo.distance - (float)LowerBlendDistance));
			}
			animal.State_SetFloat(value, LerpDistance);
		}

		public override void ResetStateValues()
		{
			verticalInertia = Vector3.zero;
			DownPush = Vector3.zero;
			InputValue = false;
		}

		public override void RestoreAnimalOnExit()
		{
			animal.FreeMovement = false;
			animal.ResetCameraInput();
			animal.Speed_Lock(lockSpeed: false);
			animal.LockUpDownMovement = false;
		}

		public override void AllowStateExit()
		{
			base.InputValue = false;
			base.ExitInputValue = false;
		}
	}
}
