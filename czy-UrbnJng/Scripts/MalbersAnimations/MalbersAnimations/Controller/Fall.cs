using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/states/fall")]
	public class Fall : State
	{
		public enum FallBlending
		{
			DistanceNormalized = 0,
			Distance = 1,
			VerticalVelocity = 2
		}

		[Header("Fall Parameters")]
		[Tooltip("Can the Animal be controller while falling?")]
		public BoolReference AirControl = new BoolReference(value: true);

		[Tooltip("Rotation while falling")]
		public FloatReference AirRotation = new FloatReference(10f);

		[Tooltip("Maximum Movement while falling")]
		public FloatReference AirMovement = new FloatReference(0f);

		[Tooltip("Lerp value for the Air Movement adjusment")]
		public FloatReference AirSmooth = new FloatReference(2f);

		[Space]
		[Tooltip("Forward Offset Position of the Fall Ray")]
		public FloatReference Offset = new FloatReference();

		[Tooltip("Forward Offset Multiplier Position of the Fall Ray while moving")]
		public FloatReference MoveMultiplier = new FloatReference(0.1f);

		[Hide("ShowFront")]
		[Tooltip("A ray will be cast in front of the animal to check if there's an obstacle in front of it")]
		public bool CheckFrontObstacle = true;

		[Tooltip("Multiplier for the Fall Ray Length. The Default Value is the Animal's Height")]
		public FloatReference lengthMultiplier = new FloatReference(1f);

		[Tooltip("RayHits Allowed on the Raycast NonAloc (Try Fall Logic)")]
		public IntReference rayHits = new IntReference(6);

		[Space]
		[Tooltip("State Float Value in the animator. This is used to blend between different Fall Animations")]
		public FallBlending BlendFall;

		[Tooltip("Used to Set fallBlend to zero before reaching the ground")]
		public FloatReference LowerBlendDistance;

		[Space]
		[Header("Fall Damage")]
		public StatID AffectStat;

		[Tooltip("Minimum Distance to Apply Fall Damage, If the distance falled is lesser than this value, no damage will be applied")]
		public FloatReference FallMinDistance = new FloatReference(5f);

		[Tooltip("Maximum Distance to Apply Fall Damage, If the distance falled is greater  than this value,the animal will die")]
		public FloatReference FallMaxDistance = new FloatReference(15f);

		[Tooltip("The Fall State will set the Exit State Status Depending the Fall Distance (X: Distance Y:Exit Status Value)")]
		[NonReorderable]
		public Vector2[] landStatus;

		[Tooltip("Fix the animal when is stuck on weird places (Experimental)")]
		public bool StuckAnimal = true;

		[Tooltip("When Falling, the animal may get stuck falling. The animal will be force to move forward.")]
		public FloatReference PushForward = new FloatReference(2f);

		protected Vector3 fall_Point;

		private RaycastHit[] FallHits;

		private RaycastHit FallRayCast;

		private GameObject GameObjectHit;

		private bool IsDebree;

		private float DistanceToGround;

		private float Fall_Float;

		private MSpeed FallSpeed = MSpeed.Default;

		private bool GoingDown;

		private int Hits;

		private bool KeepForwardFall;

		private Vector3 StartingSpeedDirection;

		private Stats animalStats;

		private int ResetCount;

		public override string StateName => "Fall";

		public override string StateIDName => "Fall";

		public float MaxHeight { get; set; }

		public float FallCurrentDistance { get; set; }

		public Vector3 FallPoint { get; private set; }

		public override void AwakeState()
		{
			base.AwakeState();
			animalStats = animal.FindComponent<Stats>();
			FallHits = new RaycastHit[(int)rayHits];
		}

		public override bool TryActivate()
		{
			float verticalSmooth = animal.VerticalSmooth;
			Vector3 vector = animal.Main_Pivot_Point + (float)Offset * base.ScaleFactor * animal.Forward + (float)MoveMultiplier * base.ScaleFactor * verticalSmooth * animal.Forward;
			if (CheckFrontObstacle && (float)MoveMultiplier > 0f)
			{
				if (base.GizmoDebug)
				{
					MDebug.DrawLine(vector, vector, Color.magenta);
				}
				if (Physics.Linecast(vector, vector, base.GroundLayer, base.IgnoreTrigger))
				{
					return false;
				}
			}
			float multiplier = animal.Pivot_Multiplier * (float)lengthMultiplier * 0.999f * base.ScaleFactor;
			return TryFallRayCasting(vector, multiplier);
		}

		private bool TryFallRayCasting(Vector3 fall_Pivot, float Multiplier)
		{
			Vector3 gravity = base.Gravity;
			float radius = animal.RayCastRadius * base.ScaleFactor;
			Hits = Physics.SphereCastNonAlloc(fall_Pivot, radius, gravity, FallHits, Multiplier, base.GroundLayer, base.IgnoreTrigger);
			if (base.GizmoDebug)
			{
				MDebug.DrawRay(fall_Pivot, gravity * Multiplier, Color.black);
				MDebug.DrawRay(fall_Pivot, gravity * Multiplier, Color.magenta);
				MDebug.DrawRay(FallRayCast.point, 0.2f * base.ScaleFactor * FallRayCast.normal, Color.magenta);
			}
			if (Hits > 0)
			{
				if (animal.Grounded)
				{
					for (int i = 0; i < Hits; i++)
					{
						RaycastHit fallRayCast = FallHits[i];
						float num = Vector3.SignedAngle(fallRayCast.normal, animal.UpVector, animal.Right);
						MDebug.DrawWireSphere(fall_Pivot + gravity * DistanceToGround, Color.magenta, radius);
						FallRayCast = fallRayCast;
						if (num > 0f - animal.SlopeLimit)
						{
							break;
						}
					}
					if (FallRayCast.transform.gameObject != GameObjectHit)
					{
						GameObjectHit = FallRayCast.transform.gameObject;
						IsDebree = GameObjectHit.CompareTag(animal.DebrisTag);
					}
				}
				else
				{
					FallRayCast = FallHits[0];
					DistanceToGround = FallRayCast.distance;
					float num2 = Vector3.Angle(FallRayCast.normal, animal.UpVector);
					if (num2 > animal.SlopeLimit)
					{
						Debugging($"[Try] The Animal is on the Air and the angle SLOPE of the ground hitted is too Deep [{num2}].  " + "- [" + FallRayCast.transform.name + "]");
						return true;
					}
					if (base.Height >= DistanceToGround)
					{
						if (animal.ExternalForce != Vector3.zero)
						{
							return true;
						}
						bool flag = animal.CheckIfGrounded();
						Debugging($"[Try Failed] Distance to the ground is very small. Checking if we are grounded [{flag}]");
						if (animal.Grounded)
						{
							animal.Grounded = true;
							animal.UseGravity = false;
							animal.AlignPosLerpDelta = (float)animal.AlignPosLerp * 5f;
							Vector3 vector = Vector3.Project(FallRayCast.point - animal.transform.position, base.Gravity);
							animal.Teleport_Internal(animal.transform.position + vector);
							animal.ResetUPVector();
							animal.hit_Hip.distance = base.Height;
						}
						return false;
					}
				}
				return false;
			}
			Debugging("[Try] There's no Ground beneath the Animal");
			return true;
		}

		public override void Activate()
		{
			KeepForwardFall = !AirControl.Value;
			base.Activate();
			StartingSpeedDirection = animal.DeltaPos;
			if ((int)animal.LastState.ID == StateEnum.Jump || animal.LastState.ID.ID <= 2)
			{
				StartingSpeedDirection = animal.HorizontalVelocity;
				KeepForwardFall = animal.LastState.KeepForwardMovement;
			}
			ResetStateValues();
			Fall_Float = animal.State_Float;
		}

		public override void EnterCoreAnimation()
		{
			SetEnterStatus(0);
			base.IgnoreLowerStates = false;
			float num = animal.HorizontalSpeed / base.ScaleFactor;
			if (animal.HasExternalForce)
			{
				Vector3 vector = Vector3.ProjectOnPlane(animal.ExternalForce, animal.UpVector);
				num = (Vector3.ProjectOnPlane(animal.Inertia, animal.UpVector) - vector).magnitude / base.ScaleFactor;
			}
			if (!animal.ExternalForceAirControl)
			{
				num = 0f;
			}
			FallSpeed = new MSpeed(animal.CurrentSpeedModifier)
			{
				name = "FallSpeed",
				position = num,
				strafeSpeed = num,
				animator = 1f,
				rotation = AirRotation.Value,
				lerpPosition = AirSmooth.Value,
				lerpStrafe = AirSmooth.Value,
				lerpAnimator = 8f
			};
			animal.SetCustomSpeed(FallSpeed);
			if (animal.HasExternalForce && animal.InZone)
			{
				animal.UseGravity = false;
			}
			base.CanExit = true;
			if (animal.TargetSpeed == Vector3.zero)
			{
				animal.DeltaRootMotion = Vector3.zero;
				animal.UpInertia_Store();
				animal.ResetInertiaSpeed(animal.HorizontalVelocity * animal.DeltaTime);
			}
		}

		public override Vector3 Speed_Direction()
		{
			if (base.GizmoDebug)
			{
				MDebug.Draw_Arrow(transform.position, StartingSpeedDirection, Color.magenta);
			}
			if (!KeepForwardFall)
			{
				return base.Speed_Direction();
			}
			return StartingSpeedDirection;
		}

		public override void OnStateMove(float deltaTime)
		{
			if (!base.InCoreAnimation)
			{
				return;
			}
			if (animal.InZone && animal.HasExternalForce)
			{
				animal.GravityTime = 0f;
			}
			if (!KeepForwardFall && (float)AirMovement > 0f && (float)AirMovement > base.CurrentSpeedPos)
			{
				if (!animal.ExternalForceAirControl)
				{
					return;
				}
				base.CurrentSpeedPos = Mathf.Lerp(base.CurrentSpeedPos, AirMovement, ((float)AirSmooth != 0f) ? (deltaTime * (float)AirSmooth) : 1f);
			}
			animal.UpInertia_Apply();
		}

		public override void TryExitState(float DeltaTime)
		{
			float radius = animal.RayCastRadius * base.ScaleFactor;
			float verticalSmooth = animal.VerticalSmooth;
			Vector3 vector = animal.Main_Pivot_Point + (float)Offset * base.ScaleFactor * animal.Forward + animal.Forward * (verticalSmooth * (float)MoveMultiplier * base.ScaleFactor);
			vector += animal.AdditivePosition;
			float num = 0f;
			GoingDown = Vector3.Dot(base.DeltaPos, base.Gravity) > 0f;
			if (GoingDown)
			{
				num = Vector3.Project(base.DeltaPos, base.Gravity).magnitude / base.ScaleFactor;
				FallCurrentDistance += num;
			}
			if (base.GizmoDebug)
			{
				MDebug.DrawWireSphere(vector, Color.magenta, radius);
				MDebug.DrawWireSphere(vector + base.Gravity * base.Height, Color.white, radius);
				Debug.DrawRay(vector, base.Gravity * 100f, Color.magenta);
			}
			if (Physics.Raycast(vector, base.Gravity, out FallRayCast, 100f, base.GroundLayer, base.IgnoreTrigger))
			{
				DistanceToGround = FallRayCast.distance;
				if (base.GizmoDebug)
				{
					MDebug.DrawWireSphere(vector, Color.magenta, radius);
				}
				switch (BlendFall)
				{
				case FallBlending.DistanceNormalized:
				{
					float num2 = DistanceToGround - base.Height;
					if (MaxHeight < num2)
					{
						MaxHeight = num2;
						Fall_Float = Mathf.Lerp(Fall_Float, 0f, DeltaTime * 5f);
						animal.State_SetFloat(Fall_Float);
					}
					else
					{
						num2 -= (float)LowerBlendDistance;
						Fall_Float = Mathf.Lerp(Fall_Float, 1f - num2 / MaxHeight, DeltaTime * 10f);
						animal.State_SetFloat(Fall_Float);
					}
					break;
				}
				case FallBlending.Distance:
					animal.State_SetFloat(FallCurrentDistance);
					break;
				case FallBlending.VerticalVelocity:
				{
					float magnitude = Vector3.Project(animal.DeltaPos, animal.UpVector).magnitude;
					animal.State_SetFloat(magnitude / animal.DeltaTime * (float)(GoingDown ? 1 : (-1)));
					break;
				}
				}
				if (base.Height >= DistanceToGround || DistanceToGround - num < 0f)
				{
					float num3 = Vector3.SignedAngle(FallRayCast.normal, animal.UpVector, animal.Right);
					if (FallRayCast.transform.gameObject != GameObjectHit)
					{
						GameObjectHit = FallRayCast.transform.gameObject;
						IsDebree = GameObjectHit.CompareTag(animal.DebrisTag);
					}
					if (Mathf.Abs(num3) >= animal.SlopeLimit && !IsDebree)
					{
						FallCurrentDistance = 0f;
						return;
					}
					AllowExit();
					animal.CheckIfGrounded();
					if (base.IsActiveState)
					{
						animal.Grounded = true;
						animal.UseGravity = false;
						animal.AlignPosLerpDelta = (float)animal.AlignPosLerp * 5f;
						Vector3 vector2 = Vector3.Project(FallRayCast.point - animal.transform.position, base.Gravity);
						animal.Teleport_Internal(animal.transform.position + vector2);
						animal.ResetUPVector();
						animal.hit_Hip.distance = base.Height;
						animal.InertiaPositionSpeed = Vector3.ProjectOnPlane(animal.InertiaPositionSpeed, animal.UpVector);
						Debugging($"[Try Exit] (Grounded) + [Terrain Angle = {num3:F2}]. [Align to Ground]");
						return;
					}
				}
			}
			ResetRigidbody(DeltaTime, base.Gravity);
		}

		public override void ExitState()
		{
			int exitStatus = 0;
			if (landStatus != null && landStatus.Length >= 1)
			{
				Vector2[] array = landStatus;
				for (int i = 0; i < array.Length; i++)
				{
					Vector2 vector = array[i];
					if (vector.x < FallCurrentDistance)
					{
						exitStatus = (int)vector.y;
					}
				}
			}
			SetExitStatus(exitStatus);
			if (AffectStat != null && animalStats != null && FallCurrentDistance > FallMinDistance.Value && animal.Grounded)
			{
				float value = FallCurrentDistance * 100f / (float)FallMaxDistance;
				animalStats.Stat_ModifyValue(AffectStat, value, StatOption.ReduceByPercent);
			}
			base.ExitState();
		}

		private void ResetRigidbody(float DeltaTime, Vector3 Gravity)
		{
			if (!StuckAnimal || !GoingDown)
			{
				return;
			}
			Vector3 vector = Vector3.Project(animal.RB.velocity, Gravity);
			Vector3 vector2 = Vector3.Project(animal.DesiredRBVelocity, Gravity);
			float magnitude = vector2.magnitude;
			float magnitude2 = vector.magnitude;
			if (base.GizmoDebug)
			{
				MDebug.Draw_Arrow(animal.Main_Pivot_Point + base.Forward * 0.02f, vector * 0.5f, Color.white);
				MDebug.Draw_Arrow(animal.Main_Pivot_Point + base.Forward * 0.04f, vector2 * 0.5f, Color.green);
			}
			ResetCount++;
			if (magnitude != magnitude2 && magnitude > magnitude2 * magnitude2 && magnitude2 < 0.1f && ResetCount > 5 && animal.DesiredRBVelocity.magnitude > base.Height)
			{
				Debugging("Reset Rigidbody Velocity. Animal may be stuck");
				animal.ResetUPVector();
				animal.GravityTime = animal.StartGravityTime;
				if ((float)PushForward > 0f)
				{
					animal.InertiaPositionSpeed = animal.ScaleFactor * DeltaTime * (float)PushForward * animal.Forward;
				}
				ResetCount = 0;
			}
		}

		public override void ResetStateValues()
		{
			DistanceToGround = float.PositiveInfinity;
			GoingDown = false;
			IsDebree = false;
			FallSpeed = default(MSpeed);
			FallRayCast = default(RaycastHit);
			GameObjectHit = null;
			FallHits = new RaycastHit[(int)rayHits];
			MaxHeight = float.NegativeInfinity;
			FallCurrentDistance = 0f;
			Fall_Float = 0f;
		}

		public override void StateGizmos(MAnimal animal)
		{
			if (!Application.isPlaying)
			{
				Vector3 start = animal.transform.position + (animal.Forward * Offset + new Vector3(0f, animal.height)) * animal.ScaleFactor;
				float num = animal.Pivot_Multiplier * (float)lengthMultiplier;
				Debug.DrawRay(start, animal.Gravity.normalized * num, Color.magenta);
			}
		}
	}
}
