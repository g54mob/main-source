using Brewery.DrinkingSystem;
using UnityEngine;

namespace Brewery.Vehicle
{
	public class MopedRiderIK : MonoBehaviour
	{
		[Header("IK Weights")]
		[Range(0f, 1f)]
		[SerializeField]
		private float handIkWeight;

		[Range(0f, 1f)]
		[SerializeField]
		private float footIkWeight;

		[SerializeField]
		private float ikBlendSpeed;

		[Header("Rider Lean")]
		[SerializeField]
		private float riderLeanMaxAngle;

		[SerializeField]
		private float riderLeanSmoothTime;

		[SerializeField]
		private float riderLeanReturnSmoothTime;

		[SerializeField]
		private float riderLeanSpeedInfluence;

		[SerializeField]
		private float riderLeanStrength;

		[SerializeField]
		private float spineLeanScale;

		[SerializeField]
		private float chestLeanScale;

		[SerializeField]
		private float headLeanScale;

		[SerializeField]
		private float boneLeanSmoothTime;

		[SerializeField]
		private bool useMopedLeanAxis;

		[SerializeField]
		private Vector3 leanAxisLocal;

		[SerializeField]
		private bool flattenLeanAxisToWorldUp;

		private Animator animator;

		private MopedController moped;

		private Transform leftHandTarget;

		private Transform rightHandTarget;

		private Transform leftFootTarget;

		private Transform rightFootTarget;

		private float currentHandWeight;

		private float currentFootWeight;

		private float riderLeanAngle;

		private float riderLeanVelocity;

		private DrinkingController drinkingController;

		private bool isActiveRider;

		[Header("Rider Bones (Overrides)")]
		[Tooltip("Optional override for upper spine (e.g., Spine_03).")]
		[SerializeField]
		private Transform spineOverride;

		[Tooltip("Optional override for chest (e.g., Spine_02).")]
		[SerializeField]
		private Transform chestOverride;

		[Tooltip("Optional override for head (e.g., Head).")]
		[SerializeField]
		private Transform headOverride;

		private Transform spine;

		private Transform chest;

		private Transform head;

		private float lastSpineLean;

		private float lastChestLean;

		private float lastHeadLean;

		private float spineLeanVelocity;

		private float chestLeanVelocity;

		private float headLeanVelocity;

		private bool warnedIkPass;

		public bool IsActive => false;

		public void Initialize(MopedController controller, Transform leftHand, Transform rightHand, Transform leftFoot, Transform rightFoot)
		{
		}

		public void ClearTargets()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void CacheBones()
		{
		}

		private Transform FindBoneByName(params string[] names)
		{
			return null;
		}

		private void Update()
		{
		}

		private void UpdateRiderLean()
		{
		}

		private void OnAnimatorIK(int layerIndex)
		{
		}

		private void ApplyIkTargets()
		{
		}

		private float GetMopedHandWeightScale(bool isLeftHand)
		{
			return 0f;
		}

		private void ApplyRiderLeanOnAnimatorIK()
		{
		}

		private void ApplyLeanToBone(HumanBodyBones bone, Transform overrideTransform, float scale, ref float lastLean)
		{
		}

		private float GetLeanVelocity(HumanBodyBones bone)
		{
			return 0f;
		}

		private void SetLeanVelocity(HumanBodyBones bone, float value)
		{
		}

		private Quaternion GetLeanOffset(Transform boneTransform, Transform overrideTransform, float lean)
		{
			return default(Quaternion);
		}

		private static float GetSuspensionOffset(WheelCollider wheel)
		{
			return 0f;
		}
	}
}
