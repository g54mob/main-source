using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS
{
	[AddComponentMenu("JU Foot Placement/JU Foot Placement")]
	public class JUFootPlacement : MonoBehaviour
	{
		private bool Started;

		[HideInInspector]
		public bool BlockBodyPositioning;

		private Animator anim;

		private RaycastHit LeftHitPlaceBase;

		private RaycastHit RightHitPlaceBase;

		private Transform RightFootPlaceBase;

		private Transform LeftFootPlaceBase;

		private Vector3 SmothedLeftFootPosition;

		private Vector3 SmothedRightFootPosition;

		private Quaternion SmothedLeftFootRotation;

		private Quaternion SmothedRightFootRotation;

		[JUHeader("FOOT PLACEMENT")]
		public bool EnableFootPlacement = true;

		public bool AdvancedMode;

		[JUSubHeader("Raycasts Settings")]
		[Space]
		public LayerMask GroundLayers;

		private Transform LeftFoot;

		private Transform LeftFootBase_UP;

		private Transform RightFoot;

		private Transform RightFootBase_UP;

		[JUReadOnly("AdvancedMode", false, true)]
		public float RaycastMaxDistance = 2f;

		[JUReadOnly("AdvancedMode", false, true)]
		public float RaycastHeight = 1f;

		[Range(0f, 1f)]
		[JUSubHeader("Foot Placing System")]
		[Space]
		public float FootHeight = 0.1f;

		private float LeftFootHeight;

		private float RightFootHeight;

		[JUReadOnly("AdvancedMode", false, true)]
		public float MaxStepHeight = 0.6f;

		public bool UseDynamicFootPlacing = true;

		[JUReadOnly("UseDynamicFootPlacing", true, true)]
		public string LeftFootHeightCurveName = "LeftFootHeight";

		[JUReadOnly("UseDynamicFootPlacing", true, true)]
		public string RightFootHeightCurveName = "RightFootHeight";

		private float AnimationLeftFootPositionY;

		private float AnimationRightFootPositionY;

		[JUReadOnly("AdvancedMode", false, true)]
		public bool SmoothIKTransition = true;

		[JUReadOnly("AdvancedMode", false, true)]
		public float FootHeightMultiplier = 0.6f;

		[Range(0f, 1f)]
		public float GlobalWeight = 1f;

		private float TransitionIKtoFKWeight;

		[HideInInspector]
		public float LeftFootHeightFromGround;

		[HideInInspector]
		public float RightFootHeightFromGround;

		[HideInInspector]
		public float LeftFootRotationWeight;

		[HideInInspector]
		public float RightFootRotationWeight;

		private bool LeftHit;

		private bool RightHit;

		[JUReadOnly("AdvancedMode", false, true)]
		public float radius = 0.1f;

		[JUHeader("DYNAMIC BODY PLACEMENT")]
		[Space]
		[Tooltip("When enabled, it will change your character's position according to the terrain.")]
		public bool EnableDynamicBodyPlacing = true;

		[JUReadOnly("EnableDynamicBodyPlacing", false, true)]
		public float UpAndDownForce = 10f;

		[JUReadOnly("AdvancedMode", false, true)]
		public float MaxBodyCrouchHeight = 0.65f;

		[Tooltip("If true, it will only calculate the ideal body position, but it will not affect the body position of the character, useful if you want to make a custom Body Placement.  Use ' GetCalculatedAnimatorCenterOfMass(); ' to have the calculated position of the body. ")]
		[JUReadOnly("AdvancedMode", false, true)]
		public bool JustCalculateBodyPosition;

		[Space]
		[Tooltip("This will keep your character grounded.")]
		public bool KeepCharacterOnGround;

		[JUReadOnly("KeepCharacterOnGround", false, true)]
		public float RaycastDistanceToGround = 1.2f;

		[JUReadOnly("KeepCharacterOnGround", false, true)]
		public float BodyHeightPosition = 0.01f;

		[JUReadOnly("KeepCharacterOnGround", false, true)]
		public float Force = 10f;

		private float MinBodyHeightPosition = 0.005f;

		private float MaxBodyPositionHeight = 1f;

		[Header("Ground Check")]
		[JUReadOnly("", false, true)]
		[Space]
		public bool TheresGroundBelow;

		[JUReadOnly("AdvancedMode", false, true)]
		public float GroundCheckRadius = 0.1f;

		private RaycastHit HitGroundBodyPlacement;

		[HideInInspector]
		public float LastBodyPositionY;

		[HideInInspector]
		public Vector3 NewAnimationBodyPosition;

		private float BodyPositionOffset;

		[HideInInspector]
		public float Animation_Y_BodyPosition;

		private float GroundAngle;

		private void Start()
		{
			Invoke("StartFootPlacement", 0.1f);
			GetFootPlacementDependencies();
			Invoke("GetFootPlacementDependencies", 0.01f);
		}

		private void LateUpdate()
		{
			_ = Started;
		}

		public void StartFootPlacement()
		{
			Started = true;
			LeftFootPlaceBase.position = LeftFoot.position;
			RightFootPlaceBase.position = RightFoot.position;
		}

		private void GetFootPlacementDependencies()
		{
			if (GroundLayers.value == 0)
			{
				GroundLayers = LayerMask.GetMask("Default");
			}
			if (LeftFoot == null && RightFoot == null)
			{
				anim = GetComponent<Animator>();
				LeftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
				RightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
				if (!(LeftFoot == null) && !(RightFoot == null))
				{
					SmothedLeftFootPosition = LeftFoot.position - base.transform.forward * 0.1f;
					SmothedRightFootPosition = RightFoot.position - base.transform.forward * 0.1f;
					SmothedLeftFootRotation = LeftFoot.rotation;
					SmothedRightFootRotation = RightFoot.rotation;
					LeftFootPlaceBase = new GameObject("Left Foot Position").transform;
					RightFootPlaceBase = new GameObject("Right Foot Position").transform;
					LeftFootPlaceBase.position = LeftFoot.position;
					RightFootPlaceBase.position = RightFoot.position;
					LeftFootPlaceBase.gameObject.hideFlags = HideFlags.HideAndDontSave;
					RightFootPlaceBase.gameObject.hideFlags = HideFlags.HideAndDontSave;
					LeftFootBase_UP = new GameObject("Left Foot BASE UP").transform;
					RightFootBase_UP = new GameObject("Right Foot BASE UP").transform;
					LeftFootBase_UP.position = LeftFoot.position;
					RightFootBase_UP.position = RightFoot.position;
					LeftFootBase_UP.transform.SetParent(LeftFoot);
					RightFootBase_UP.transform.SetParent(RightFoot);
					LeftFootBase_UP.gameObject.hideFlags = HideFlags.HideAndDontSave;
					RightFootBase_UP.gameObject.hideFlags = HideFlags.HideAndDontSave;
				}
			}
		}

		private void FootPlacementPositions()
		{
			if (RightFoot == null || LeftFoot == null || LeftFootBase_UP == null || RightFootBase_UP == null)
			{
				return;
			}
			if (UseDynamicFootPlacing)
			{
				LeftFootHeightFromGround = FootHeightMultiplier * AnimationLeftFootPositionY;
				RightFootHeightFromGround = FootHeightMultiplier * AnimationRightFootPositionY;
			}
			else
			{
				LeftFootHeightFromGround = Mathf.Lerp(LeftFootHeightFromGround, anim.GetFloat(LeftFootHeightCurveName) / 2f, 20f * Time.deltaTime);
				RightFootHeightFromGround = Mathf.Lerp(RightFootHeightFromGround, anim.GetFloat(RightFootHeightCurveName) / 2f, 20f * Time.deltaTime);
			}
			Physics.SphereCast(LeftFoot.position + base.transform.up * RaycastHeight + LeftFootBase_UP.forward * 0.12f, radius, -base.transform.up, out LeftHitPlaceBase, RaycastMaxDistance, GroundLayers);
			Physics.SphereCast(RightFoot.position + base.transform.up * RaycastHeight + RightFootBase_UP.forward * 0.12f, radius, -base.transform.up, out RightHitPlaceBase, RaycastMaxDistance, GroundLayers);
			if (LeftHitPlaceBase.point != Vector3.zero)
			{
				LeftFootPlaceBase.position = LeftHitPlaceBase.point;
				LeftFootPlaceBase.rotation = Quaternion.FromToRotation(base.transform.up, LeftHitPlaceBase.normal) * base.transform.rotation;
				LeftHit = true;
			}
			else
			{
				LeftFootPlaceBase.position = LeftFoot.position;
				LeftHit = false;
			}
			if (RightHitPlaceBase.point != Vector3.zero)
			{
				RightFootPlaceBase.position = RightHitPlaceBase.point;
				RightFootPlaceBase.rotation = Quaternion.FromToRotation(base.transform.up, RightHitPlaceBase.normal) * base.transform.rotation;
				RightHit = true;
			}
			else
			{
				RightFootPlaceBase.position = RightFoot.position;
				RightHit = false;
			}
			LeftFootHeight = FootHeight - Vector3.SignedAngle(LeftFootBase_UP.up, base.transform.up, base.transform.right) / 500f;
			RightFootHeight = FootHeight - Vector3.SignedAngle(RightFootBase_UP.up, base.transform.up, base.transform.right) / 500f;
			LeftFootHeight = Mathf.Clamp(LeftFootHeight, -0.2f, 0.2f);
			RightFootHeight = Mathf.Clamp(RightFootHeight, -0.2f, 0.2f);
			if (LeftHit)
			{
				if (LeftHitPlaceBase.point.y < base.transform.position.y + MaxStepHeight)
				{
					SmothedLeftFootPosition = Vector3.Lerp(SmothedLeftFootPosition, LeftFootPlaceBase.position + LeftHitPlaceBase.normal * LeftFootHeight + base.transform.up * LeftFootHeightFromGround, 15f * Time.deltaTime);
				}
				else
				{
					SmothedLeftFootPosition = Vector3.Lerp(SmothedLeftFootPosition, base.transform.position + base.transform.up * FootHeight + base.transform.up * LeftFootHeightFromGround, 15f * Time.deltaTime);
				}
			}
			else
			{
				SmothedLeftFootPosition = LeftFoot.position;
			}
			if (RightHit)
			{
				if (RightHitPlaceBase.point.y < base.transform.position.y + MaxStepHeight)
				{
					SmothedRightFootPosition = Vector3.Lerp(SmothedRightFootPosition, RightFootPlaceBase.position + RightHitPlaceBase.normal * RightFootHeight + base.transform.up * RightFootHeightFromGround, 20f * Time.deltaTime);
				}
				else
				{
					SmothedRightFootPosition = Vector3.Lerp(SmothedRightFootPosition, base.transform.position + base.transform.up * FootHeight + base.transform.up * RightFootHeightFromGround, 20f * Time.deltaTime);
				}
			}
			else
			{
				SmothedRightFootPosition = RightFoot.position;
			}
			Vector3 axis = Vector3.Cross(Vector3.up, LeftHitPlaceBase.normal);
			Quaternion rotation = Quaternion.AngleAxis(Vector3.Angle(Vector3.up, LeftHitPlaceBase.normal) * GlobalWeight, axis);
			LeftFootPlaceBase.rotation = rotation;
			SmothedLeftFootRotation = Quaternion.Lerp(SmothedLeftFootRotation, LeftFootPlaceBase.rotation, 20f * Time.deltaTime);
			Vector3 axis2 = Vector3.Cross(Vector3.up, RightHitPlaceBase.normal);
			Quaternion rotation2 = Quaternion.AngleAxis(Vector3.Angle(Vector3.up, RightHitPlaceBase.normal) * GlobalWeight, axis2);
			RightFootPlaceBase.rotation = rotation2;
			SmothedRightFootRotation = Quaternion.Lerp(SmothedRightFootRotation, RightFootPlaceBase.rotation, 20f * Time.deltaTime);
			if (LeftFootHeightFromGround < 0.3f)
			{
				LeftFootRotationWeight = Mathf.Lerp(LeftFootRotationWeight, 1f, 8f * Time.deltaTime);
			}
			else
			{
				LeftFootRotationWeight = Mathf.Lerp(LeftFootRotationWeight, 0f, 1f * Time.deltaTime);
			}
			if (RightFootHeightFromGround < 0.3f)
			{
				RightFootRotationWeight = Mathf.Lerp(RightFootRotationWeight, 1f, 8f * Time.deltaTime);
			}
			else
			{
				RightFootRotationWeight = Mathf.Lerp(RightFootRotationWeight, 0f, 1f * Time.deltaTime);
			}
			if (SmoothIKTransition)
			{
				TransitionIKtoFKWeight = Mathf.Lerp(TransitionIKtoFKWeight, 1f, 5f * Time.deltaTime);
			}
			else
			{
				TransitionIKtoFKWeight = Mathf.Lerp(TransitionIKtoFKWeight, 0f, 5f * Time.deltaTime);
			}
		}

		private void BodyPlacement()
		{
			Physics.SphereCast(base.transform.position + base.transform.up * RaycastDistanceToGround, GroundCheckRadius, -base.transform.up, out HitGroundBodyPlacement, RaycastDistanceToGround + 0.2f, GroundLayers);
			if (HitGroundBodyPlacement.point != Vector3.zero)
			{
				TheresGroundBelow = true;
			}
			else
			{
				TheresGroundBelow = false;
			}
			GroundAngle = Vector3.Angle(Vector3.up, HitGroundBodyPlacement.normal);
			if (KeepCharacterOnGround)
			{
				BodyHeightPosition = Mathf.Clamp(BodyHeightPosition, MinBodyHeightPosition, MaxBodyPositionHeight);
				if (TheresGroundBelow)
				{
					float b = HitGroundBodyPlacement.point.y - BodyHeightPosition;
					float y = Mathf.Lerp(base.transform.position.y, b, Force * Time.fixedDeltaTime);
					Vector3 position = new Vector3(base.transform.position.x, y, base.transform.position.z);
					base.transform.position = position;
				}
			}
			if (TheresGroundBelow && !IsInvoking("DisableBlock") && BlockBodyPositioning)
			{
				Invoke("DisableBlock", 0.5f);
			}
			if (EnableDynamicBodyPlacing && !BlockBodyPositioning)
			{
				if (LeftHitPlaceBase.point == Vector3.zero || RightHitPlaceBase.point == Vector3.zero || LastBodyPositionY == 0f)
				{
					LastBodyPositionY = Animation_Y_BodyPosition;
					BodyPositionOffset = 0f;
					NewAnimationBodyPosition = anim.bodyPosition;
					return;
				}
				float num = LeftHitPlaceBase.point.y - base.transform.position.y - RightFootHeightFromGround / 2f;
				float num2 = RightHitPlaceBase.point.y - base.transform.position.y - LeftFootHeightFromGround / 2f;
				BodyPositionOffset = ((num < num2) ? num : num2);
				BodyPositionOffset = Mathf.Clamp(BodyPositionOffset, 0f - MaxBodyCrouchHeight, 0f);
				float num3 = UpAndDownForce + GroundAngle / 20f;
				NewAnimationBodyPosition = anim.bodyPosition + base.transform.up * BodyPositionOffset;
				NewAnimationBodyPosition.y = Mathf.Lerp(LastBodyPositionY, NewAnimationBodyPosition.y, num3 * Time.deltaTime);
				float num4 = Mathf.Abs(Animation_Y_BodyPosition - LastBodyPositionY);
				if (!JustCalculateBodyPosition && num4 < 1f)
				{
					anim.bodyPosition = NewAnimationBodyPosition;
				}
				LastBodyPositionY = anim.bodyPosition.y;
			}
			else if (TheresGroundBelow && !BlockBodyPositioning)
			{
				NewAnimationBodyPosition = anim.bodyPosition + base.transform.up * BodyPositionOffset;
				NewAnimationBodyPosition.y = Mathf.Lerp(LastBodyPositionY, Animation_Y_BodyPosition, UpAndDownForce * Time.deltaTime);
				anim.bodyPosition = NewAnimationBodyPosition;
				LastBodyPositionY = anim.bodyPosition.y;
			}
		}

		private void DisableBlock()
		{
			BlockBodyPositioning = false;
			LastBodyPositionY = Animation_Y_BodyPosition;
		}

		public Vector3 GetCalculatedAnimatorCenterOfMass()
		{
			return NewAnimationBodyPosition;
		}

		private void OnAnimatorIK(int layerIndex)
		{
			if (Vector3.Angle(base.transform.up, Vector3.up) > 30f && EnableFootPlacement)
			{
				SmoothIKTransition = false;
			}
			if (layerIndex != 0)
			{
				return;
			}
			FootPlacementPositions();
			Animation_Y_BodyPosition = anim.bodyPosition.y;
			if (!(TransitionIKtoFKWeight < 0.1f) && !(GlobalWeight < 0.01f) && !(RightHitPlaceBase.point == Vector3.zero) && !(RightHitPlaceBase.point == Vector3.zero) && EnableFootPlacement)
			{
				AnimationLeftFootPositionY = base.transform.position.y - (LeftFoot.position.y - FootHeight);
				AnimationRightFootPositionY = base.transform.position.y - (RightFoot.position.y - FootHeight);
				AnimationLeftFootPositionY = Mathf.Abs(AnimationLeftFootPositionY);
				AnimationRightFootPositionY = Mathf.Abs(AnimationRightFootPositionY);
				AnimationLeftFootPositionY = Mathf.Clamp(AnimationLeftFootPositionY, 0f, 1f);
				AnimationRightFootPositionY = Mathf.Clamp(AnimationRightFootPositionY, 0f, 1f);
				if (Vector3.Angle(base.transform.up, Vector3.up) < 40f)
				{
					BodyPlacement();
				}
				if (LeftHit && LeftHitPlaceBase.point.y < base.transform.position.y + RaycastHeight)
				{
					Vector3 goalPosition = new Vector3(LeftFoot.position.x, SmothedLeftFootPosition.y, LeftFoot.position.z);
					anim.SetIKPosition(AvatarIKGoal.LeftFoot, goalPosition);
					anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, GlobalWeight * TransitionIKtoFKWeight);
					anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, GlobalWeight * TransitionIKtoFKWeight * LeftFootRotationWeight);
					anim.SetIKRotation(AvatarIKGoal.LeftFoot, SmothedLeftFootRotation * anim.GetIKRotation(AvatarIKGoal.LeftFoot));
				}
				if (RightHit && RightHitPlaceBase.point.y < base.transform.position.y + RaycastHeight)
				{
					Vector3 goalPosition2 = new Vector3(RightFoot.position.x, SmothedRightFootPosition.y, RightFoot.position.z);
					anim.SetIKPosition(AvatarIKGoal.RightFoot, goalPosition2);
					anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, GlobalWeight * TransitionIKtoFKWeight);
					anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, GlobalWeight * TransitionIKtoFKWeight * RightFootRotationWeight);
					anim.SetIKRotation(AvatarIKGoal.RightFoot, SmothedRightFootRotation * anim.GetIKRotation(AvatarIKGoal.RightFoot));
				}
			}
		}
	}
}
