using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/states/ledge-grab")]
	public class LedgeGrab : State
	{
		[Header("Ledge Parameters")]
		[Space]
		[Tooltip("Layer to identify climbable surfaces")]
		public LayerReference LedgeLayer = new LayerReference(1);

		[Tooltip("Climb the Ledge automatically when is near a climbable surface")]
		public BoolReference automatic = new BoolReference();

		[Tooltip("LedgeGrab will be set automatic if any of these state are playing")]
		public List<StateID> automaticByState = new List<StateID>();

		[Tooltip("Set the Animal Rigidbody to Kinematic while is on this state. This avoid the colliders to interfiere with ledge.")]
		public BoolReference Kinematic = new BoolReference(value: true);

		[Tooltip("Disable the Main Collider while the state is active (Main Collider can Interfiere with the animation)")]
		public BoolReference DisableMainCollider = new BoolReference(value: true);

		[Tooltip("Correct Distance from the wall to the character")]
		[Min(0f)]
		public float wallDistance = 0.5f;

		[Tooltip("Min Angle needed to enable the Ledge Grab State")]
		public float MinTerrainAngle = 45f;

		[Tooltip("Distance required to check a wall in front of the character")]
		[Min(0f)]
		public float ForwardLength = 1f;

		[Tooltip("Correct Distance from the wall to the character")]
		[Min(0f)]
		public float WallChecker = 0.1f;

		[Tooltip("Transform Created to Store the Hit Position of the Ledge Rays. Use it to show UI When a wall  ")]
		public string HitTransform = "LedgeHit";

		public List<LedgeProfiles> profiles = new List<LedgeProfiles>();

		private Vector3 AlignmentOffset;

		private float AngleDifference;

		private Vector3 StartPosition;

		private Quaternion StartRotation;

		private Vector3 TargetPosition;

		private Vector3 WallNormal;

		private LedgeProfiles LedgeProfile;

		private RaycastHit FoundLedgeHit;

		private RaycastHit FoundWallHit;

		private bool OrientToWall;

		private Transform m_HitTransform;

		private List<LedgeProfiles> UpdatedProfiles = new List<LedgeProfiles>();

		private Vector3 AlignDir;

		private Vector3 AlignDirDelta;

		private bool InTransition;

		private bool ExitTransition;

		private bool InClimb;

		public override string StateName => "Ledge Grab";

		public override string StateIDName => "LedgeGrab";

		public bool Automatic_By_State { get; private set; }

		public void LedgeAutomatic()
		{
			automatic.Value = true;
		}

		public override Vector3 Speed_Direction()
		{
			return Vector3.zero;
		}

		public override void AwakeState()
		{
			base.AwakeState();
			m_HitTransform = animal.transform.FindGrandChild(HitTransform);
			if (m_HitTransform == null)
			{
				m_HitTransform = new GameObject(HitTransform).transform;
				m_HitTransform.parent = transform;
				m_HitTransform.ResetLocal();
			}
			EnableHitTransform(v: false);
		}

		public override bool TryActivate()
		{
			if (InClimb && base.MovementRaw.z < 0f)
			{
				return false;
			}
			if ((bool)automatic || Automatic_By_State || InputValue)
			{
				return FindLedge();
			}
			if (!string.IsNullOrEmpty(HitTransform))
			{
				FindLedge();
			}
			return false;
		}

		public bool FindLedge()
		{
			foreach (LedgeProfiles updatedProfile in UpdatedProfiles)
			{
				if ((updatedProfile.OnlyGrounded && !animal.Grounded) || (updatedProfile.MaxVSpeed != 0f && updatedProfile.MaxVSpeed > animal.CurrentSpeedModifier.Vertical.Value) || (updatedProfile.LastState != null && updatedProfile.LastState != animal.ActiveStateID))
				{
					continue;
				}
				Vector3 vector = transform.TransformPoint(new Vector3(0f, updatedProfile.Height, 0f)) + base.DeltaPos;
				Vector3 vector2 = animal.transform.TransformPoint(new Vector3(0f, updatedProfile.Height - updatedProfile.LedgeExitDistance - WallChecker, 0f)) + base.DeltaPos;
				float num = ForwardLength * base.ScaleFactor * updatedProfile.ForwardMultiplier;
				float num2 = updatedProfile.LedgeExitDistance * base.ScaleFactor;
				Vector3 vector3 = vector + base.Forward * num;
				if (animal.debugGizmos)
				{
					MDebug.DrawRay(vector, base.Forward * num, Color.green);
					MDebug.DrawRay(vector2, base.Forward * num, Color.yellow);
					MDebug.DrawRay(vector3, -base.Up * num2, Color.red);
				}
				RaycastHit hitInfo;
				if (updatedProfile.CheckUpwards)
				{
					Vector3 vector4 = animal.transform.TransformPoint(new Vector3(0f, animal.Height, 0f)) + base.DeltaPos;
					MDebug.DrawLine(vector4, vector, Color.gray);
					if (Physics.Linecast(vector4, vector, out hitInfo, LedgeLayer.Value, base.IgnoreTrigger))
					{
						MDebug.DrawLine(vector4, vector, Color.red);
						continue;
					}
				}
				float num3 = 3f;
				if (!Physics.Raycast(vector, base.Forward, out hitInfo, num, LedgeLayer.Value, base.IgnoreTrigger) && Physics.Raycast(vector3, -base.Up, out FoundLedgeHit, num2, LedgeLayer.Value, base.IgnoreTrigger))
				{
					MDebug.DrawRay(FoundLedgeHit.point, FoundLedgeHit.normal, Color.cyan, num3);
					float num4 = Vector3.Angle(FoundLedgeHit.normal, base.Up);
					if (num4 < animal.SlopeLimit && Physics.Raycast(vector2, base.Forward, out FoundWallHit, num, LedgeLayer.Value, base.IgnoreTrigger) && !(Mathf.Abs(Vector3.Angle(FoundWallHit.normal, base.Up) - num4) < MinTerrainAngle))
					{
						Vector3 vector5 = Vector3.Cross(-FoundLedgeHit.normal, FoundWallHit.normal);
						WallNormal = Vector3.Cross(FoundLedgeHit.normal, vector5).normalized;
						Vector3 vector6 = MTools.ClosestPointOnPlane(transform.position, WallNormal, FoundLedgeHit.point);
						MDebug.DrawWireSphere(vector6, Color.green, 0.02f, num3);
						vector6 = vector6.ClosestPointOnLine(transform.position + base.UpVector * 5f, transform.position - base.UpVector * 5f);
						MDebug.DrawWireSphere(vector6, Color.yellow, 0.02f, num3);
						Vector3 vector7 = MTools.ClosestPointOnPlane(FoundWallHit.point, WallNormal, transform.position);
						LedgeProfile = updatedProfile;
						float num5 = Vector3.Distance(vector6, transform.position) + LedgeProfile.AlingOffset.y * base.ScaleFactor;
						float num6 = wallDistance * base.ScaleFactor - Vector3.Distance(vector7, transform.position) + LedgeProfile.AlingOffset.x * base.ScaleFactor;
						Vector3 vector8 = num5 * FoundLedgeHit.normal;
						Vector3 vector9 = num6 * WallNormal;
						AlignmentOffset = vector8 + vector9;
						AngleDifference = Vector3.SignedAngle(base.Forward, -WallNormal, base.Up);
						StartPosition = base.Position;
						StartRotation = base.Rotation;
						TargetPosition = StartPosition + AlignmentOffset;
						MDebug.DrawRay(FoundLedgeHit.point, vector5, Color.white, num3);
						MDebug.DrawRay(FoundLedgeHit.point, WallNormal * 5f, Color.green, num3);
						MDebug.DrawWireSphere(vector6, Color.red, 0.1f, num3);
						MDebug.DrawWireSphere(FoundLedgeHit.point, Color.yellow, 0.1f, num3);
						MDebug.DrawWireSphere(vector7, Color.red, 0.1f, num3);
						MDebug.DrawWireSphere(transform.position, Color.yellow, 0.1f, num3);
						MDebug.DrawLine(vector6, FoundLedgeHit.point, Color.yellow, num3);
						MDebug.DrawLine(vector7, transform.position, Color.red, num3);
						MDebug.DrawWireSphere(StartPosition, Color.white, 0.02f, num3);
						MDebug.DrawWireSphere(TargetPosition, Color.green, 0.02f, num3);
						MDebug.DrawLine(StartPosition, TargetPosition, Color.white, num3);
						OrientToWall = updatedProfile.Orient;
						m_HitTransform.position = vector6;
						EnableHitTransform(v: true);
						Debugging($"Try [Ledge-Grab] Wall and Ledge found. <B>[{updatedProfile.name}]</B>. Wall-Hit Difference: [{vector9}]");
						return true;
					}
				}
			}
			EnableHitTransform(v: false);
			return false;
		}

		public override void Activate()
		{
			base.Activate();
			SetEnterStatus(LedgeProfile.EnterStatus);
			animal.Reset_Movement();
			animal.Force_Remove();
			EnableHitTransform(v: false);
			animal.InertiaPositionSpeed = Vector3.zero;
			animal.AdditivePosition = Vector3.zero;
			CheckKinematic();
			animal.SetPlatform(FoundLedgeHit.transform);
			AlignDir = (TargetPosition - StartPosition) / 2f;
			AlignDirDelta = Vector3.zero;
			UpdateProfileLastState();
		}

		private void CheckKinematic()
		{
			animal.InertiaPositionSpeed = Vector3.zero;
			animal.DeltaPos = Vector3.zero;
			animal.DeltaRootMotion = Vector3.zero;
			if (Kinematic.Value)
			{
				animal.RB.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
				animal.RB.isKinematic = true;
			}
			if (DisableMainCollider.Value && (bool)animal.MainCollider)
			{
				animal.MainCollider.enabled = false;
			}
		}

		public override void OnStateMove(float deltatime)
		{
			if (!base.InCoreAnimation)
			{
				return;
			}
			InTransition = false;
			if (base.Anim.IsInTransition(0))
			{
				float normalizedTime = base.Anim.GetAnimatorTransitionInfo(0).normalizedTime;
				animal.AdditivePosition = Vector3.zero;
				animal.AdditiveRotation = Quaternion.identity;
				Quaternion b = Quaternion.FromToRotation(base.Forward, -WallNormal) * transform.rotation;
				Vector3 vector = Vector3.Lerp(Vector3.zero, AlignDir, normalizedTime);
				AlignDirDelta = vector - AlignDirDelta;
				transform.position += AlignDirDelta;
				if (OrientToWall)
				{
					transform.rotation = Quaternion.Lerp(StartRotation, b, normalizedTime);
				}
				InTransition = true;
			}
			if (!InTransition && !ExitTransition && base.IsActiveState)
			{
				ExitTransition = true;
			}
			animal.InertiaPositionSpeed = Vector3.zero;
			if (LedgeProfile != null)
			{
				if (LedgeProfile.Orient)
				{
					float num = Mathf.Lerp(0f, AngleDifference, deltatime * LedgeProfile.OrientSmoothness * 2f);
					AngleDifference -= num;
					animal.transform.rotation *= Quaternion.Euler(0f, num, 0f);
				}
				if (LedgeProfile.AdditivePosition)
				{
					float normalizedTime2 = animal.AnimState.normalizedTime;
					animal.AdditivePosition += deltatime * LedgeProfile.HeightCurve.Evaluate(normalizedTime2) * LedgeProfile.HeightSpeed * base.Up;
					animal.AdditivePosition += deltatime * LedgeProfile.ForwardCurve.Evaluate(normalizedTime2) * LedgeProfile.ForwardSpeed * base.Forward;
				}
			}
		}

		public override void TryExitState(float DeltaTime)
		{
			if (animal.AnimState.normalizedTime > LedgeProfile.ExitTime)
			{
				AllowExit();
				animal.Grounded = true;
				Debugging($"Allow Exit - {LedgeProfile.name} After Exit Time {animal.AnimState.normalizedTime:F3} > {LedgeProfile.ExitTime}");
			}
		}

		public override void NewActiveState(StateID newState)
		{
			UpdateProfileLastState();
			Automatic_By_State = false;
			if (automaticByState.Count > 0)
			{
				Automatic_By_State = automaticByState.Contains(newState);
			}
			InClimb = (int)newState == StateEnum.Climb;
		}

		private void UpdateProfileLastState()
		{
			UpdatedProfiles = profiles;
			List<LedgeProfiles> list = profiles.FindAll((LedgeProfiles p) => p.LastState != null && p.LastState == animal.ActiveStateID);
			if (list != null && list.Count != 0)
			{
				UpdatedProfiles = list;
			}
		}

		private void EnableHitTransform(bool v)
		{
			m_HitTransform.gameObject.SetActive(v);
		}

		public override void ResetStateValues()
		{
			UpdatedProfiles = profiles;
			LedgeProfile = null;
			InTransition = false;
			ExitTransition = false;
			OrientToWall = false;
			AngleDifference = 0f;
			StartPosition = (TargetPosition = (WallNormal = (AlignmentOffset = Vector3.zero)));
			StartRotation = Quaternion.identity;
			FoundLedgeHit = default(RaycastHit);
			FoundWallHit = default(RaycastHit);
			if (Kinematic.Value && (bool)animal)
			{
				animal.RB.isKinematic = false;
			}
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
	}
}
