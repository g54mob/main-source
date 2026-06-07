using System;
using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/states/climb")]
	public class Climb : State
	{
		[Serializable]
		public struct ClimbRayOverride
		{
			public StateID state;

			public float length;

			public float sprintLength;
		}

		[Header("Climb Parameters")]
		[Space]
		[Tooltip("Layer to identify climbable surfaces")]
		public LayerReference ClimbLayer = new LayerReference(1);

		public PhysicMaterial Surface;

		[Tooltip("Climb automatically when is near a climbable surface")]
		public BoolReference automatic = new BoolReference();

		[Tooltip("Disable the Main Collider while the state is active (Main Collider can Interfiere with the animation)")]
		public BoolReference DisableMainCollider = new BoolReference(value: true);

		[Tooltip("Disable Moving on Left and Right while climbing")]
		public BoolReference NoHorizontal = new BoolReference();

		[Header("Climb Pivot")]
		[Space]
		[Tooltip("Pivot to Cast a Ray from the Chest")]
		public Vector3 ClimbChest = Vector3.up;

		[Tooltip("Pivot to Cast a Ray from the Hip")]
		public Vector3 ClimbHip = Vector3.zero;

		[Tooltip("Distance of the Climb Point Ray")]
		public float ClimbRayLength = 1f;

		[Tooltip("Distance of the Climb Point Ray when sprinting")]
		public float SprintClimbRayLength = 2f;

		[Tooltip("LedgeGrab will be set automatic if any of these state are playing")]
		public List<StateID> automaticByState = new List<StateID>();

		[Tooltip("Changes the Ray Lenght depending the current active state")]
		public List<ClimbRayOverride> ClimbRayLengthOverride = new List<ClimbRayOverride>();

		protected float CurrentRayLength;

		protected float CurrentRayLengthSprint;

		[Tooltip("Disable the pivot chest to calculate Falling from Pivot Hip instead")]
		public bool DisablePivotChest = true;

		[Tooltip("Radius of the Ray to find a Climable Wall")]
		[Min(0.01f)]
		public float m_rayRadius = 0.1f;

		[Header("Wall Detection")]
		[Space]
		[Tooltip("This is the distance to align the character to the wall while climbing")]
		public float WallDistance = 0.2f;

		[Tooltip("When using the Start Climb animations this is the distance to position the character in the correct position on the wall")]
		public float StartWallDistance;

		[Tooltip("Smoothness value to align the animal to the wall")]
		public float AlignSmoothness = 10f;

		[Tooltip("Distance from the Hip Pivot to the Ground")]
		public float GroundDistance = 0.5f;

		[Tooltip("Length of the Horizontal Rays to detect Inner Corners")]
		[Min(0f)]
		public float InnerCorner = 0.4f;

		[Min(0f)]
		public float InnerCornerLerp = 5f;

		[Tooltip("Speed Multiplier to move faster around outter corners")]
		[Min(0f)]
		public float OuterCornerSpeed = 0.4f;

		[Range(0f, 90f)]
		public float ExitSlope = 30f;

		[Tooltip("Transform Created to Store the Hit Position of the Climb Rays. Use it to show UI When a WAll ")]
		public string HitTransform = "ClimbHit";

		[Header("Ledge Detection (Exit Status: Climb Ledge)")]
		[Tooltip("Checks On top of the Climb to Exit\nDisable this if your Animal has the <[Grab Ledge]> State")]
		public bool UseLedgeDetection = true;

		[Hide("UseLedgeDetection", false)]
		public string LedgeTag = "ClimbEdge";

		private int LedgeHash;

		[Tooltip("Offset Position to Cast the First Ray on top on the animal to find the ledge")]
		[Hide("UseLedgeDetection", false)]
		public Vector3 RayLedgeOffset = Vector3.up;

		[Tooltip("Length of the Ledge Ray")]
		[Hide("UseLedgeDetection", false)]
		[Min(0f)]
		public float RayLedgeLength = 0.4f;

		[Tooltip("MinDistance to exit Climb over a ledge")]
		[Hide("UseLedgeDetection", false)]
		[Min(0f)]
		public float LedgeExitDistance = 0.175f;

		[Tooltip("Minimun Ledge Angle ")]
		[Hide("UseLedgeDetection", false)]
		[Min(0f)]
		public float MinLedgeAngle = 65f;

		[Header("Exit State Status")]
		[Tooltip("When the Exit Condition Climb Up an edge is executed. The State Exit Status will change to this value")]
		public int ClimbLedge = 1;

		[Tooltip("When the Exit Condition Climb Off is executed. The State Exit Status will change to this value")]
		public int ClimbOff = 2;

		[Tooltip("If the character is Climbing Down and a Ground is found. The State Exit Status will change to this value to execute the ClimbDown Animation")]
		public int ClimbDown = 3;

		[Tooltip("When the Exit Condition Climb Down to the Ground executed. The State Exit Status will change to this value")]
		public int ClimbExitSlope = 4;

		private bool InInnerCorner;

		private readonly RaycastHit[] EdgeHit = new RaycastHit[1];

		private RaycastHit HitChest;

		private RaycastHit HitHip;

		private RaycastHit HitSide;

		private Transform m_HitTransform;

		private Transform validwall;

		private bool FoundTargetPos;

		private GameObject GameObjectHit;

		private bool IsDebree;

		public override string StateName => "Climb/Free Climb";

		public override string StateIDName => "Climb";

		public bool Automatic_By_State { get; private set; }

		public float RayRadius => m_rayRadius * animal.ScaleFactor;

		public Transform WallChest { get; private set; }

		public Vector3 AverageNormal { get; private set; }

		public Transform ValidWall
		{
			get
			{
				return validwall;
			}
			set
			{
				validwall = value;
			}
		}

		public Transform LastWall { get; private set; }

		public bool ExitOnLedge { get; private set; }

		public float WallAngle { get; private set; }

		private Vector3 StartPosition { get; set; }

		private Vector3 TargetPosition { get; set; }

		public Vector3 ClimbPivotChest(Transform transform)
		{
			return transform.TransformPoint(ClimbChest);
		}

		public Vector3 ClimbPivotHip(Transform transform)
		{
			return transform.TransformPoint(ClimbHip);
		}

		public override void NewActiveState(StateID newState)
		{
			if (newState == ID)
			{
				return;
			}
			Automatic_By_State = false;
			if (automaticByState.Count > 0)
			{
				Automatic_By_State = automaticByState.Contains(newState);
			}
			if (ClimbRayLengthOverride.Count > 0)
			{
				CurrentRayLength = ClimbRayLength;
				CurrentRayLengthSprint = SprintClimbRayLength;
				ClimbRayOverride climbRayOverride = ClimbRayLengthOverride.FirstOrDefault((ClimbRayOverride x) => x.state == newState);
				if (climbRayOverride.state != null)
				{
					CurrentRayLength = climbRayOverride.length;
					CurrentRayLengthSprint = climbRayOverride.sprintLength;
				}
			}
		}

		public override void AwakeState()
		{
			base.AwakeState();
			CurrentRayLength = ClimbRayLength;
			CurrentRayLengthSprint = SprintClimbRayLength;
			m_HitTransform = animal.transform.FindGrandChild(HitTransform);
			if (m_HitTransform == null)
			{
				m_HitTransform = new GameObject(HitTransform).transform;
				m_HitTransform.parent = transform;
				m_HitTransform.ResetLocal();
			}
			LedgeHash = Animator.StringToHash(LedgeTag);
			EnableHitTransform(v: false);
		}

		public override void StatebyInput()
		{
			ValidWall = null;
			if (InputValue && (bool)CheckClimbRay())
			{
				Activate();
			}
		}

		public override void StateExitByInput()
		{
			SetExitStatus(ClimbOff);
			Debugging("Exit with Climb Input [" + ExitInput.Value + "]");
		}

		public override void Activate()
		{
			FoundTargetPos = false;
			Vector3 targetPosition = (StartPosition = animal.Position);
			TargetPosition = targetPosition;
			AverageNormal = -transform.forward;
			ValidWall = CheckClimbRay();
			if ((bool)ValidWall)
			{
				base.Activate();
				animal.UseCameraInput = false;
				if (DisablePivotChest)
				{
					animal.DisablePivotChest();
				}
				InInnerCorner = false;
				EnableHitTransform(v: false);
				animal.Reset_Movement();
				animal.Force_Remove();
				if (DisableMainCollider.Value && (bool)animal.MainCollider)
				{
					animal.MainCollider.enabled = false;
				}
			}
		}

		public override bool TryActivate()
		{
			Transform validWall = CheckClimbRay();
			if ((animal.MovementDetected && animal.VerticalSmooth > 0.9f && automatic.Value) || Automatic_By_State)
			{
				ValidWall = validWall;
				return ValidWall != null;
			}
			return false;
		}

		public override void ResetStateValues()
		{
			WallChest = null;
			WallAngle = 90f;
			ExitOnLedge = false;
			animal.ResetCameraInput();
			InInnerCorner = false;
			ExitInputValue = false;
			if ((bool)m_HitTransform)
			{
				EnableHitTransform(v: false);
				m_HitTransform.ResetLocal();
			}
			if (DisableMainCollider.Value && (bool)animal.MainCollider)
			{
				animal.MainCollider.enabled = true;
			}
		}

		public override void RestoreAnimalOnExit()
		{
			if (DisablePivotChest)
			{
				animal.ResetPivotChest();
			}
			animal.ResetCameraInput();
		}

		public override Vector3 Speed_Direction()
		{
			return base.Up * animal.VerticalSmooth + base.Right * animal.HorizontalSmooth;
		}

		private Transform CheckClimbRay()
		{
			if (InInnerCorner)
			{
				return ValidWall;
			}
			Vector3 vector = ClimbPivotChest(transform);
			Vector3 vector2 = ClimbPivotHip(transform);
			float num = ((!animal.Sprint) ? CurrentRayLength : CurrentRayLengthSprint);
			float maxDistance = animal.ScaleFactor * num;
			HitChest = default(RaycastHit);
			HitHip = default(RaycastHit);
			Vector3 vector3 = base.Forward * base.ScaleFactor;
			if (base.GizmoDebug)
			{
				MDebug.DrawRay(vector, vector3 * num, Color.green);
				MDebug.DrawRay(vector, vector3 * WallDistance, Color.red);
				MDebug.DrawRay(vector2, vector3 * num, Color.green);
				MDebug.DrawRay(vector2, vector3 * WallDistance, Color.red);
			}
			AverageNormal = -vector3;
			if (Physics.SphereCast(vector, RayRadius, base.Forward, out HitChest, maxDistance, ClimbLayer.Value, base.IgnoreTrigger))
			{
				bool flag = HitChest.collider.sharedMaterial == Surface;
				if (flag)
				{
					AverageNormal = HitChest.normal;
					DebugRays(HitChest.point, HitChest.normal);
					if (Physics.SphereCast(vector2, RayRadius, base.Forward, out HitHip, maxDistance, ClimbLayer.Value, base.IgnoreTrigger))
					{
						flag = HitHip.collider.sharedMaterial == Surface;
						DebugRays(HitHip.point, HitHip.normal);
						Vector3 lhs = HitChest.point - HitHip.point;
						Vector3 vector4 = AverageNormal + HitHip.normal;
						Vector3 rhs = Vector3.Cross(lhs, -vector4);
						Vector3 averageNormal = Vector3.Cross(lhs, rhs);
						AverageNormal = averageNormal;
						if (!FoundTargetPos)
						{
							TargetPosition = base.Position.ProjectPointOnPlane(HitHip.normal, HitHip.point);
							TargetPosition += -HitHip.normal.normalized * StartWallDistance;
							Quaternion quaternion = Quaternion.FromToRotation(base.Forward, -HitHip.normal) * base.Rotation;
							_ = Quaternion.Inverse(base.Rotation) * quaternion;
							int num2 = 0;
							MDebug.DrawWireSphere(TargetPosition, Color.yellow, 0.05f * base.ScaleFactor, num2);
							MDebug.DrawWireSphere(TargetPosition, Color.yellow, 0.04f * base.ScaleFactor, num2);
							MDebug.DrawWireSphere(TargetPosition, Color.yellow, 0.03f * base.ScaleFactor, num2);
							MDebug.DrawWireSphere(HitHip.point, Color.cyan, 0.05f * base.ScaleFactor, num2);
						}
					}
					if (base.IsActiveState && animal.platform != HitChest.transform && HitChest.transform != null)
					{
						animal.SetPlatform(HitChest.transform);
					}
					WallAngle = Vector3.SignedAngle(AverageNormal, animal.UpVector, animal.Right);
					if (animal.activeState != this)
					{
						m_HitTransform.position = HitChest.point;
						EnableHitTransform(flag);
					}
					return HitChest.transform;
				}
			}
			else
			{
				if (base.GizmoDebug)
				{
					MDebug.DrawWireSphere(vector2 + num * base.ScaleFactor * base.Forward, Color.gray, RayRadius);
					MDebug.DrawWireSphere(vector + num * base.ScaleFactor * base.Forward, Color.gray, RayRadius);
				}
				EnableHitTransform(v: false);
			}
			return null;
		}

		public override void OnStateMove(float deltatime)
		{
			if (base.CurrentAnimTag == LedgeHash || base.CurrentAnimTag == base.ExitTagHash)
			{
				return;
			}
			if (base.InCoreAnimation)
			{
				if ((bool)NoHorizontal)
				{
					animal.MovementAxis.x = 0f;
					animal.MovementAxisRaw.x = 0f;
				}
				if (LastWall != ValidWall)
				{
					LastWall = ValidWall;
				}
				Vector3 right = animal.Right;
				ValidWall = CheckClimbRay();
				if ((bool)ValidWall)
				{
					animal.SetPlatform(HitChest.transform);
					if (base.MovementRaw.x > 0f)
					{
						CalculateSideClimbHit(right);
					}
					else if (base.MovementRaw.x < 0f)
					{
						CalculateSideClimbHit(-right);
					}
					OrientToWall(AverageNormal, deltatime);
					AlignToWall(HitChest.distance, deltatime);
				}
				if (InInnerCorner)
				{
					OrientToWall(AverageNormal, deltatime);
					if (Vector3.Angle(animal.Forward, -AverageNormal) < 5f)
					{
						InInnerCorner = false;
					}
				}
			}
			else if (base.InEnterAnimation)
			{
				if (base.Anim.IsInTransition(0))
				{
					float normalizedTime = base.Anim.GetAnimatorTransitionInfo(0).normalizedTime;
					animal.AdditivePosition = Vector3.zero;
					animal.AdditiveRotation = Quaternion.identity;
					transform.position = Vector3.Lerp(StartPosition, TargetPosition, normalizedTime);
					FoundTargetPos = true;
				}
				OrientToWall(AverageNormal, deltatime);
				animal.SetPlatform(HitChest.transform);
			}
		}

		private void AlignToWall(float distance, float deltatime)
		{
			float num = distance - WallDistance * animal.ScaleFactor;
			if (!Mathf.Approximately(distance, WallDistance * animal.ScaleFactor))
			{
				Vector3 vector = AlignSmoothness * deltatime * num * base.ScaleFactor * animal.Forward;
				animal.Position += vector;
			}
		}

		private void OrientToWall(Vector3 normal, float deltatime)
		{
			Quaternion quaternion = Quaternion.FromToRotation(base.Forward, -normal) * transform.rotation;
			Quaternion b = Quaternion.Inverse(transform.rotation) * quaternion;
			Quaternion quaternion2 = Quaternion.Lerp(Quaternion.identity, b, deltatime * AlignSmoothness);
			animal.AdditiveRotation *= quaternion2;
			Vector3 lhs = Vector3.Cross(base.Forward, base.UpVector);
			lhs = Vector3.Cross(lhs, base.Forward);
			quaternion = Quaternion.FromToRotation(transform.up, lhs) * transform.rotation;
			b = Quaternion.Inverse(transform.rotation) * quaternion;
			animal.AdditiveRotation *= b;
		}

		public override void TryExitState(float DeltaTime)
		{
			Vector3 vector = ClimbPivotChest(transform) + animal.AdditivePosition;
			if (base.CurrentAnimTag == base.ExitTagHash && animal.CheckIfGrounded())
			{
				AllowExit();
				return;
			}
			if (!ValidWall)
			{
				Debugging("[Allow Exit] Exit when Wall is not Climbable");
				ValidWall = LastWall;
				AllowExit();
				return;
			}
			if (Mathf.Abs(WallAngle) < ExitSlope)
			{
				Debugging("[Allow Exit] Slope is walkable");
				AllowExit(StateEnum.Locomotion, ClimbExitSlope);
				animal.CheckIfGrounded();
				return;
			}
			if (base.MovementRaw.z < 0f)
			{
				MDebug.DrawRay(vector, GroundDistance * base.ScaleFactor * -base.Up, Color.white);
				if (Physics.Raycast(vector, -base.Up, out var hitInfo, base.ScaleFactor * GroundDistance, animal.GroundLayer, base.IgnoreTrigger))
				{
					bool num = Mathf.Abs(Vector3.SignedAngle(hitInfo.normal, animal.UpVector, animal.Right)) >= animal.SlopeLimit;
					if (hitInfo.transform.gameObject != GameObjectHit)
					{
						GameObjectHit = hitInfo.transform.gameObject;
						IsDebree = GameObjectHit.CompareTag(animal.DebrisTag);
					}
					if (!num || IsDebree)
					{
						Debugging("[Allow Exit] when Grounded and pressing Down and touched the ground");
						AllowExit(StateEnum.Idle, ClimbDown);
						animal.CheckIfGrounded();
					}
				}
				Vector3 vector2 = ClimbPivotHip(transform) + base.DeltaPos;
				float num2 = animal.ScaleFactor * ClimbRayLength;
				MDebug.DrawRay(vector2, base.Forward * num2, Color.white);
				if (!Physics.Raycast(vector2, base.Forward, out var _, num2, animal.GroundLayer, base.IgnoreTrigger))
				{
					Debugging("[Allow Exit] No Front Wall ");
					AllowExit();
				}
			}
			if (!ExitOnLedge)
			{
				CheckLedgeExit();
			}
		}

		private void EnableHitTransform(bool v)
		{
			m_HitTransform.gameObject.SetActive(v);
		}

		private void DebugRays(Vector3 p, Vector3 Normal)
		{
		}

		private void CalculateSideClimbHit(Vector3 Direction)
		{
			Color color = Color.blue;
			Color color2 = Color.blue;
			Color color3 = Color.blue;
			Vector3 forward = animal.Forward;
			float num = InnerCorner * animal.ScaleFactor;
			Vector3 vector = ClimbPivotChest(transform);
			MovementAxisMult.x = 1f;
			if (Physics.Raycast(vector, Direction, out HitSide, num, ClimbLayer, base.IgnoreTrigger))
			{
				color = Color.green;
				if (HitSide.collider.sharedMaterial == Surface)
				{
					AverageNormal = HitSide.normal;
					ValidWall = HitSide.transform;
					InInnerCorner = true;
				}
			}
			else
			{
				Vector3 vector2 = vector + Direction * num;
				if (Physics.Raycast(vector2, forward, out HitSide, num, ClimbLayer, base.IgnoreTrigger))
				{
					color2 = Color.green;
					if (HitSide.transform != HitChest.transform && HitSide.collider.sharedMaterial != Surface)
					{
						MovementAxisMult.x = 0f;
						animal.additivePosition.x = 0f;
					}
				}
				else
				{
					Vector3 vector3 = vector2 + forward * num;
					if (Physics.Raycast(vector3, -Direction, out HitSide, num, ClimbLayer, base.IgnoreTrigger))
					{
						color3 = Color.green;
						if (HitSide.collider.sharedMaterial != Surface)
						{
							MovementAxisMult.x = 0f;
							color3 = Color.red;
						}
						else
						{
							animal.AdditivePosition += animal.DeltaTime * OuterCornerSpeed * Direction;
						}
					}
					MDebug.DrawRay(vector3, -Direction * num, color3);
				}
				MDebug.DrawRay(vector2, forward * num, color2);
			}
			MDebug.DrawRay(vector, Direction * num, color);
		}

		private void CheckLedgeExit()
		{
			if (!UseLedgeDetection)
			{
				return;
			}
			Vector3 vector = transform.TransformPoint(ClimbChest + RayLedgeOffset + 2f * m_rayRadius * base.ScaleFactor * base.Up) + base.DeltaPos;
			bool num = Physics.Raycast(vector, base.Forward, out EdgeHit[0], base.ScaleFactor * RayLedgeLength, ClimbLayer.Value, base.IgnoreTrigger);
			MDebug.DrawWireSphere(vector, Color.green, 0.01f * base.ScaleFactor);
			MDebug.DrawWireSphere(EdgeHit[0].point, Color.green, 0.01f * base.ScaleFactor);
			Debug.DrawRay(vector, RayLedgeLength * base.ScaleFactor * base.Forward, Color.green);
			if (num)
			{
				return;
			}
			Vector3 point = new Ray(vector, base.Forward * base.ScaleFactor).GetPoint(RayLedgeLength * base.ScaleFactor);
			MDebug.DrawWireSphere(point, Color.green, 0.01f * base.ScaleFactor);
			Debug.DrawRay(point, LedgeExitDistance * base.ScaleFactor * base.Gravity, Color.yellow);
			if (Physics.Raycast(point, base.Gravity, out var hitInfo, base.ScaleFactor * RayLedgeLength * 2f, ClimbLayer.Value, base.IgnoreTrigger))
			{
				MDebug.DrawWireSphere(hitInfo.point, Color.white, 0.01f * base.ScaleFactor);
				if (hitInfo.distance > LedgeExitDistance * base.ScaleFactor)
				{
					ExitOnLedge = true;
					Debugging("Allow Exit - Exit on a Ledge [" + hitInfo.collider.name + "]");
					SetExitStatus(ClimbLedge);
				}
			}
		}

		public override void StateGizmos(MAnimal animal)
		{
			if (m_debug && !Application.isPlaying)
			{
				Vector3 forward = animal.Forward;
				Vector3 right = animal.Right;
				Transform transform = animal.transform;
				Vector3 gravity = animal.Gravity;
				float scaleFactor = animal.ScaleFactor;
				Vector3 vector = ClimbPivotChest(transform);
				Vector3 vector2 = ClimbPivotHip(transform);
				if (UseLedgeDetection)
				{
					Vector3 vector3 = transform.TransformPoint(ClimbChest + RayLedgeOffset);
					Vector3 point = new Ray(vector3, scaleFactor * scaleFactor * scaleFactor * animal.Forward).GetPoint(RayLedgeLength * scaleFactor);
					Gizmos.color = Color.green;
					Gizmos.DrawRay(point, 2f * RayLedgeLength * scaleFactor * gravity);
					Gizmos.color = Color.cyan;
					Gizmos.DrawRay(point, LedgeExitDistance * scaleFactor * gravity);
					Gizmos.color = Color.green;
					Gizmos.DrawRay(vector3, RayLedgeLength * scaleFactor * forward);
				}
				Gizmos.DrawRay(vector, ClimbRayLength * scaleFactor * forward);
				Gizmos.DrawRay(vector2, ClimbRayLength * scaleFactor * forward);
				Gizmos.color = Color.cyan;
				Gizmos.DrawRay(vector, scaleFactor * WallDistance * forward);
				Gizmos.DrawRay(vector2, scaleFactor * WallDistance * forward);
				Gizmos.color = Color.green;
				Gizmos.DrawWireSphere(vector + forward * scaleFactor * (ClimbRayLength - m_rayRadius * scaleFactor), m_rayRadius * scaleFactor);
				Gizmos.DrawWireSphere(vector2 + (ClimbRayLength - m_rayRadius * scaleFactor) * scaleFactor * forward, m_rayRadius * scaleFactor);
				if (!NoHorizontal)
				{
					Gizmos.DrawRay(vector, InnerCorner * scaleFactor * right);
					Gizmos.DrawRay(vector, InnerCorner * scaleFactor * -right);
				}
				Gizmos.color = Color.white;
				Gizmos.DrawRay(ClimbPivotChest(transform), GroundDistance * scaleFactor * -animal.Up);
			}
		}

		private void OnValidate()
		{
			LedgeExitDistance = Mathf.Clamp(LedgeExitDistance, 0f, RayLedgeLength);
			if (SprintClimbRayLength < ClimbRayLength)
			{
				SprintClimbRayLength = ClimbRayLength;
			}
		}
	}
}
