using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Serialization;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/states/fly")]
	public class Fly : State
	{
		public enum FlyInput
		{
			Toggle = 0,
			Press = 1,
			None = 2
		}

		[Header("Fly Parameters")]
		[Tooltip("Bank amount used when turning")]
		public float Bank = 30f;

		[Tooltip("Pitch Limit to Rotate the Rotator Up and Down")]
		[FormerlySerializedAs("Ylimit")]
		public float PitchLimit = 80f;

		[Tooltip("Bank amount used when turning while straffing")]
		public float BankStrafe;

		[Tooltip("Limit to go Up and Down while straffing")]
		public float PitchStrafe;

		[Space]
		[Tooltip("Max Y Height the Animal Can Fly. If this value is Zero this value will be ignored")]
		public float MaxFlyHeight;

		[Tooltip("When Entering the Fly State... The animal will keep the Velocity from the last State if this value is greater than zero")]
		public FloatReference InertiaLerp = new FloatReference(1f);

		[Header("TakeOff")]
		[Tooltip("Impulse to push the animal Upwards for a time to help him take off.\nIf set to zero this logic will be ignored, the Animation needs to be tagged with the Enter animation tag")]
		public FloatReference Impulse = new FloatReference();

		[Tooltip("Time the Impulse will be applied")]
		public FloatReference ImpulseTime = new FloatReference(0.5f);

		[Tooltip("Curve to apply to the Impulse Logic")]
		public AnimationCurve ImpulseCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));

		private float elapsedImpulseTime;

		[Header("Landing")]
		[Tooltip("When the Animal is close to the Ground it will automatically Land")]
		public BoolReference canLand = new BoolReference(value: true);

		[Tooltip("Layers to Land on")]
		public LayerMask LandOn = 1;

		[Tooltip("Ray Length multiplier to check for ground and automatically land (increases or decreases the MainPivot Lenght for the Fall Ray")]
		public FloatReference LandMultiplier = new FloatReference(1f);

		[Space]
		[Tooltip("Avoids a surface to land when Flying. E.g. if the animal does not have a swim state, set this to void landing/entering the water")]
		public bool AvoidSurface;

		[Tooltip("RayCast distance to find the Surface to avoid")]
		[Hide("AvoidSurface", false)]
		public float SurfaceDistance = 0.5f;

		[Tooltip("Which layers to search to avoid that surface. Triggers are not inlcuded")]
		[Hide("AvoidSurface", false)]
		public LayerMask SurfaceLayer = 16;

		[Tooltip("Check if it can collide with triggers")]
		[Hide("AvoidSurface", false)]
		public QueryTriggerInteraction trigger = QueryTriggerInteraction.Collide;

		[Hide("AvoidSurface", false)]
		public float avoidLerp = 7f;

		[Header("Gliding")]
		[Tooltip("Vertical Speed on the Animator set to Flap the wings")]
		public float FlapSpeed = 1f;

		[Tooltip("Vertical Speed on the Animator set as Glide")]
		public float GlideSpeed = 2f;

		[Space]
		[Tooltip("The character will activate only the glide animations and it cannot go upwards")]
		public BoolReference GlideOnly = new BoolReference(value: false);

		[Tooltip("When the Forward Input is Released,this will be the movement speed the gliding will have")]
		public FloatReference GlideOnlyIdleS = new FloatReference(0.5f);

		[Tooltip("When the Forward Input is Pressed ,this will be the movement speed the gliding will have")]
		public FloatReference GlideOnlyIdleV = new FloatReference(1f);

		[Header("Auto Glide")]
		[Tooltip("It will do Auto gliding while flying")]
		public BoolReference AutoGlide = new BoolReference(value: true);

		[MinMaxRange(0f, 10f)]
		public RangedFloat GlideChance = new RangedFloat(0.8f, 4f);

		[MinMaxRange(0f, 10f)]
		public RangedFloat FlapChange = new RangedFloat(0.5f, 4f);

		[Tooltip("Variation to make Random Flap and Glide Animation")]
		public float Variation = 0.3f;

		protected bool isGliding;

		protected float FlyStyleTime = 1f;

		protected float AutoGlide_CurrentTime = 1f;

		[Header("Down Acceleration")]
		public FloatReference GravityDrag = new FloatReference(0f);

		public FloatReference DownAcceleration = new FloatReference(0.5f);

		private float acceleration;

		protected Vector3 verticalInertia;

		[Tooltip("Somethimes the Head blocks the Landing Ray.. this will solve the landing by raycasting a ray from the Bone that is blocking the Logic")]
		public bool BoneBlockingLanding;

		[Hide("BoneBlockingLanding", true)]
		[Tooltip("Name of the blocker bone")]
		public string BoneName = "Head";

		[Hide("BoneBlockingLanding", true)]
		[Tooltip("Local Offset from the Blocker Bone")]
		public Vector3 BoneOffsetPos = Vector3.zero;

		[Hide("BoneBlockingLanding", true)]
		[Tooltip("Distance of the Landing Ray from the blocking Bone")]
		public float BlockLandDist = 0.4f;

		private Transform BlockingBone;

		public override string StateName => "Fly";

		public override string StateIDName => "Fly";

		public override bool KeepForwardMovement => AlwaysForward.Value;

		public override void InitializeState()
		{
			AutoGlide_CurrentTime = Time.time;
			FlyStyleTime = GlideChance.RandomValue;
			SearchForContactBone();
		}

		private void SearchForContactBone()
		{
			BlockingBone = null;
			if (BoneBlockingLanding)
			{
				BlockingBone = animal.transform.FindGrandChild(BoneName);
			}
		}

		public override void Activate()
		{
			base.Activate();
			InputValue = true;
		}

		public override void EnterCoreAnimation()
		{
			verticalInertia = Vector3.Project(animal.DeltaPos, animal.UpVector);
			animal.PitchDirection = animal.Forward;
			animal.DeltaPos = Vector3.zero;
			acceleration = 0f;
			animal.InertiaPositionSpeed = animal.HorizontalVelocity * animal.DeltaTime;
			if (GlideOnly.Value)
			{
				animal.currentSpeedModifier.Vertical = GlideSpeed;
				animal.UseSprintState = false;
			}
			else
			{
				animal.currentSpeedModifier.Vertical = FlapSpeed;
				isGliding = true;
			}
		}

		public override Vector3 Speed_Direction()
		{
			if ((bool)GlideOnly)
			{
				MovementAxisMult.y = 0f;
				float num = (((double)animal.MovementAxis.z < 0.1) ? GlideOnlyIdleS.Value : 1f);
				animal.currentSpeedModifier.Vertical = (((double)animal.MovementAxis.z < 0.1) ? GlideOnlyIdleV.Value : GlideSpeed);
				animal.MovementAxis.z = 1f;
				return animal.Forward * num;
			}
			if (animal.FreeMovement)
			{
				return animal.PitchDirection;
			}
			return animal.Forward;
		}

		public override void OnStateMove(float deltatime)
		{
			if (base.InCoreAnimation)
			{
				float ylimit = PitchLimit;
				float bank = Bank;
				if (animal.Strafe)
				{
					ylimit = PitchStrafe;
					bank = BankStrafe;
				}
				if ((bool)AutoGlide && !GlideOnly.Value)
				{
					AutoGliding();
				}
				if (MaxFlyHeight > 0f && animal.transform.position.y > MaxFlyHeight)
				{
					ylimit = 0f;
					Vector3 position = animal.transform.position;
					position.y = MaxFlyHeight;
					animal.transform.position = position;
				}
				if (TryAvoidSurface(deltatime))
				{
					animal.FreeMovementRotator(0f, 0f);
					acceleration = 0f;
					return;
				}
				GravityPush(deltatime);
				animal.FreeMovementRotator(ylimit, bank);
				if (InertiaLerp.Value > 0f)
				{
					animal.AddInertia(ref verticalInertia, InertiaLerp);
				}
			}
			if (base.InEnterAnimation && (float)Impulse > 0f && (float)ImpulseTime > 0f && animal.LastState.ID.ID <= 1 && elapsedImpulseTime <= (float)ImpulseTime)
			{
				float num = (float)Impulse * ImpulseCurve.Evaluate(elapsedImpulseTime / (float)ImpulseTime);
				animal.AdditivePosition += deltatime * num * animal.UpVector;
				elapsedImpulseTime += deltatime;
			}
		}

		public override void OnModeStart(Mode mode)
		{
			if (!mode.AllowMovement)
			{
				verticalInertia = Vector3.zero;
			}
		}

		public virtual void SetAvoidSurface(bool value)
		{
			AvoidSurface = value;
		}

		private bool TryAvoidSurface(float deltatime)
		{
			if (AvoidSurface)
			{
				Vector3 vector = transform.position + animal.AdditivePosition;
				float num = SurfaceDistance * base.ScaleFactor;
				if (Physics.Raycast(vector, base.Gravity, out var hitInfo, num, SurfaceLayer, trigger))
				{
					Color cyan = Color.cyan;
					if (animal.MovementAxis.y < 0f)
					{
						animal.MovementAxis.y = 0f;
					}
					if (hitInfo.distance < num * 0.75f)
					{
						animal.AdditivePosition += (0f - (num * 0.75f - hitInfo.distance)) * deltatime * avoidLerp * base.Gravity;
					}
					if (m_debug)
					{
						MDebug.DrawRay(vector, base.Gravity * num, cyan);
					}
					return true;
				}
			}
			return false;
		}

		public override void TryExitState(float DeltaTime)
		{
			if (!InputValue)
			{
				AllowExit();
			}
			if (canLand.Value)
			{
				RaycastHit hitInfo2;
				if (Physics.Raycast(BlockingBone ? BlockingBone.TransformPoint(BoneOffsetPos) : animal.Main_Pivot_Point, maxDistance: (BlockingBone ? BlockLandDist : LandMultiplier.Value) * animal.ScaleFactor, direction: base.Gravity, hitInfo: out var hitInfo, layerMask: LandOn, queryTriggerInteraction: base.IgnoreTrigger))
				{
					FlyAllowExit(hitInfo);
					Debugging($"[AllowExit] Can Land on <{hitInfo.collider.name}> [Using Blocking Bone: {BlockingBone != null}]");
				}
				else if (Physics.Raycast(animal.Main_Pivot_Point, base.Gravity, out hitInfo2, LandMultiplier.Value * animal.ScaleFactor, LandOn, base.IgnoreTrigger))
				{
					FlyAllowExit(hitInfo2);
					Debugging("[AllowExit] Can Land on <" + hitInfo2.collider.name + "> ");
				}
			}
		}

		private void FlyAllowExit(RaycastHit hit)
		{
			float distance = hit.distance;
			if (base.Height >= distance)
			{
				float num = Vector3.SignedAngle(hit.normal, animal.UpVector, animal.Right);
				if (!(Mathf.Abs(num) >= animal.SlopeLimit))
				{
					AllowExit();
					animal.CheckIfGrounded();
					if (base.IsActiveState)
					{
						animal.Grounded = true;
						animal.UseGravity = false;
						animal.AlignPosLerpDelta = (float)animal.AlignPosLerp * 5f;
						Vector3 vector = Vector3.Project(hit.point - animal.transform.position, base.Gravity);
						animal.Teleport_Internal(animal.transform.position + vector);
						animal.ResetUPVector();
						animal.hit_Hip.distance = base.Height;
						Debugging($"[Try Exit] (Grounded) + [Terrain Angle = {num:F2}]. [Align to Ground]");
						return;
					}
				}
			}
			animal.FreeMovement = false;
			animal.UseGravity = true;
			AllowExit();
		}

		private void GravityPush(float deltaTime)
		{
			if (!animal.Strafe)
			{
				if (animal.MovementAxisRaw.y < 0f)
				{
					acceleration += Mathf.Abs(animal.MovementAxis.y) * deltaTime * (float)DownAcceleration;
				}
				else
				{
					acceleration = Mathf.MoveTowards(acceleration, 0f, deltaTime * (float)DownAcceleration);
				}
				if (acceleration != 0f)
				{
					animal.AdditivePosition += acceleration * deltaTime * animal.InertiaPositionSpeed.normalized;
				}
				if ((float)GravityDrag > 0f)
				{
					animal.AdditivePosition += (float)GravityDrag * animal.ScaleFactor * deltaTime * base.Gravity;
				}
			}
		}

		private void AutoGliding()
		{
			if (MTools.ElapsedTime(FlyStyleTime, AutoGlide_CurrentTime))
			{
				AutoGlide_CurrentTime = Time.time;
				isGliding = !isGliding;
				FlyStyleTime = (isGliding ? GlideChance.RandomValue : FlapChange.RandomValue);
				float num = Random.Range(GlideSpeed - Variation, GlideSpeed);
				float num2 = Random.Range(FlapSpeed, FlapSpeed + Variation);
				animal.currentSpeedModifier.Vertical = ((isGliding && !animal.Strafe) ? num : num2);
			}
		}

		public override void ResetStateValues()
		{
			verticalInertia = Vector3.zero;
			acceleration = 0f;
			isGliding = false;
			InputValue = false;
			elapsedImpulseTime = 0f;
		}

		public override void RestoreAnimalOnExit()
		{
			animal.FreeMovement = false;
			animal.InputSource?.SetInput(Input, value: false);
			animal.LockUpDownMovement = false;
		}

		public override void AllowStateExit()
		{
			base.InputValue = false;
			base.ExitInputValue = false;
		}
	}
}
