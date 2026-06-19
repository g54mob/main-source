using System.Collections;
using UnityEngine;

public class ReactiveRider : MonoBehaviour
{
	[Header("Rider References")]
	[SerializeField]
	private GameObject rider;

	[SerializeField]
	private Transform riderRightHand;

	[Header("Base Rider Position Settings")]
	[SerializeField]
	private bool updatePositionEveryFrame;

	[Range(-2f, 2f)]
	[SerializeField]
	private float riderHeightAdjustment;

	[Range(-1.5f, 1.5f)]
	[SerializeField]
	private float riderSaddlePosition;

	[Range(-1f, 1f)]
	[SerializeField]
	private float riderXPositionAdjustment;

	[Range(0f, 0.5f)]
	[SerializeField]
	private float riderDefaultForwardLean = 0.1f;

	[Range(0f, 1f)]
	[SerializeField]
	private float riderForwardLeanMultiplier = 1f;

	[Header("Head LookAt Settings")]
	[SerializeField]
	private bool useHeadIK = true;

	[Range(-2f, 2f)]
	[SerializeField]
	private float defaultHeadTilt;

	[Header("Leg and Foot Position Settings")]
	[Range(0f, 1f)]
	[SerializeField]
	private float riderLegSpread = 0.4f;

	[Range(-1f, 1f)]
	[SerializeField]
	private float riderFootSpread;

	[Range(-1f, 1f)]
	[SerializeField]
	private float riderFootHeight;

	[Range(-1f, 1f)]
	[SerializeField]
	private float riderFootPosition;

	[Range(-45f, 45f)]
	[SerializeField]
	private float riderFootAngle;

	[Range(-45f, 45f)]
	[SerializeField]
	private float riderFootTilt;

	[Header("Hand Position Settings")]
	[SerializeField]
	private bool useHandIK = true;

	private bool allowHandIKDisable;

	[Range(-1f, 1f)]
	[SerializeField]
	private float riderHandSpread;

	[Range(-1f, 1f)]
	[SerializeField]
	private float riderHandHeight;

	[Range(-1f, 1f)]
	[SerializeField]
	private float riderHandPosition;

	private Vector3 handRotationCorrection = Vector3.zero;

	private Vector3 standardHandRotationCorrection = new Vector3(36.64f, 20f, -90f);

	[Header("External Targeting")]
	[Range(0f, 30f)]
	[SerializeField]
	private float chestTwistSpeed = 10f;

	[Range(0f, 180f)]
	[SerializeField]
	private float maxChestTwist = 180f;

	[Range(0f, 180f)]
	[SerializeField]
	private float maxChestTwistWithHandIKEnabled = 80f;

	[Header("Horse References")]
	[SerializeField]
	private GameObject horse;

	[SerializeField]
	private GameObject saddleBindPointsPrefab;

	[SerializeField]
	private GameObject staticBindPointsPrefab;

	private Transform rightLegIKTarget;

	private Transform leftLegIKTarget;

	private Transform combinedHandIKTarget;

	private Transform rightHandIKTarget;

	private Transform leftHandIKTarget;

	private Transform humanHeadIKTarget;

	private Transform staticHumanHeadIKTarget;

	private Transform humanParent;

	private Transform saddleBindPoint;

	private Transform actualHorseHead;

	private Transform staticHorseHead;

	private bool HandIKPassEnabled = true;

	private float handIKWeight = 1f;

	private bool chestForwardLeanEnabled = true;

	private float LastForwardLean;

	private float calcForwardLean;

	private Transform exteneralTarget;

	private float actualChestTwist = 180f;

	private float externalTargetYOffset;

	private Vector3 rightLegIKPosStart = Vector3.zero;

	private Vector3 leftLegIKPosStart = Vector3.zero;

	private Quaternion rightLegIKRotStart = Quaternion.identity;

	private Quaternion leftLegIKRotStart = Quaternion.identity;

	private Vector3 rightHandIKPosStart = Vector3.zero;

	private Vector3 leftHandIKPosStart = Vector3.zero;

	private Quaternion rightHandIKRotStart = Quaternion.identity;

	private Quaternion leftHandIKRotStart = Quaternion.identity;

	private Vector3 startCombinedHandPosition = Vector3.zero;

	private float distanceCalcAtStartPosition;

	private Animator animator;

	private Quaternion startRot = Quaternion.identity;

	private bool forwardLeanTransitionRunning;

	public void SetHandIKPassEnabled(bool isEnabled, float time)
	{
		if (HasReactiveRiderPrereqs())
		{
			if (!isEnabled)
			{
				StartCoroutine(DisableHandIKOverTime(time));
			}
			else
			{
				StartCoroutine(EnableHandIKOverTime(time));
			}
		}
	}

	public void SetChestForwardLeanEnabled(bool isEnabled, float time)
	{
		if (HasReactiveRiderPrereqs())
		{
			if (!isEnabled)
			{
				StartCoroutine(DisableChestForwardLeanOverTime(time));
			}
			else
			{
				StartCoroutine(EnableChestForwardLeanOverTime(time));
			}
		}
	}

	public void SetExternalTarget(Transform transform, float yOffset)
	{
		if (HasReactiveRiderPrereqs())
		{
			exteneralTarget = transform;
			externalTargetYOffset = yOffset;
		}
	}

	private void Start()
	{
		if (HasReactiveRiderPrereqs())
		{
			startRot = base.transform.parent.rotation;
			base.transform.parent.rotation = Quaternion.identity;
			EnableIKRelayOnCharacter();
			PopulateSaddleBind();
			InstansiateIKTargets();
			PopulateBindPoints();
			PopulateRiderAnimator();
			SetRiderParent();
			PopulateStartCombinedHandPosition();
			SetRiderForwardLean();
			SetRiderLegSpread();
			SetIKStartPositions();
			SetIKStartRotations();
			SetFootPosition();
			SetHandPosition();
			StartCoroutine(PopulateDistanceCalcStartPosition());
		}
	}

	private bool HasReactiveRiderPrereqs()
	{
		bool result = true;
		if (horse == null)
		{
			Debug.LogError(base.gameObject.transform.parent.name + ": Reactive Rider: horse variable: has not been assigned!");
			result = false;
		}
		if (staticBindPointsPrefab == null)
		{
			Debug.LogError(base.gameObject.transform.parent.name + ": Reactive Rider: staticBindPointsPrefab: has not been assigned!");
			result = false;
		}
		if (saddleBindPointsPrefab == null)
		{
			Debug.LogError(base.gameObject.transform.parent.name + ": Reactive Rider: saddleBindPointsPrefab: has not been assigned!");
			result = false;
		}
		if (rider == null)
		{
			Debug.LogError(base.gameObject.transform.parent.name + ": Reactive Rider: rider: has not been assigned!");
			result = false;
		}
		if (riderRightHand == null)
		{
			Debug.LogError(base.gameObject.transform.parent.name + ": Reactive Rider: riderRightHand: has not been assigned!");
			result = false;
		}
		return result;
	}

	private void EnableIKRelayOnCharacter()
	{
		if (rider.GetComponent<OnAnimatorIKRelay>() == null)
		{
			rider.AddComponent<OnAnimatorIKRelay>();
		}
		rider.GetComponent<OnAnimatorIKRelay>().Saddle = this;
	}

	private void CheckHandIKEnabled()
	{
		allowHandIKDisable = false;
		if (!useHandIK)
		{
			SetHandIKPassEnabled(useHandIK, 0.1f);
		}
	}

	private void PopulateSaddleBind()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.name == "CharacterBindPoint")
			{
				saddleBindPoint = transform;
				break;
			}
		}
	}

	private void InstansiateIKTargets()
	{
		Object.Instantiate(staticBindPointsPrefab, base.transform.parent.position, base.transform.parent.rotation).transform.SetParent(horse.transform);
		Object.Instantiate(saddleBindPointsPrefab, base.transform.parent.position, base.transform.parent.rotation).transform.SetParent(saddleBindPoint.transform);
	}

	private void PopulateBindPoints()
	{
		Transform[] componentsInChildren = saddleBindPoint.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.name == "RR_RightFootIK")
			{
				rightLegIKTarget = transform;
			}
			else if (transform.name == "RR_LeftFootIK")
			{
				leftLegIKTarget = transform;
			}
			else if (transform.name == "RR_CombinedHandIK")
			{
				combinedHandIKTarget = transform;
			}
			else if (transform.name == "RR_RightHandIK")
			{
				rightHandIKTarget = transform;
			}
			else if (transform.name == "RR_LeftHandIK")
			{
				leftHandIKTarget = transform;
			}
			else if (transform.name == "RR_SaddleHeadTarget")
			{
				humanHeadIKTarget = transform;
			}
			else if (transform.name == "RR_HumanParent")
			{
				humanParent = transform;
			}
			else if (transform.name == "RR_StaticHorseHead")
			{
				staticHorseHead = transform;
			}
		}
		componentsInChildren = horse.GetComponentsInChildren<Transform>();
		foreach (Transform transform2 in componentsInChildren)
		{
			if (transform2.name == "RR_StaticHumanHeadTarget")
			{
				staticHumanHeadIKTarget = transform2;
			}
			else if (transform2.name == "Head")
			{
				actualHorseHead = transform2;
			}
		}
	}

	private void PopulateRiderAnimator()
	{
		animator = rider.GetComponent<Animator>();
		if (animator == null)
		{
			Debug.LogError(base.gameObject.transform.parent.name + ": Reactive Rider: animator: could not find animator on rider!");
		}
	}

	private void SetRiderParent()
	{
		rider.transform.parent = humanParent;
		rider.transform.localPosition = Vector3.zero;
		rider.transform.Translate(new Vector3(riderXPositionAdjustment, riderHeightAdjustment + 1.6f, riderSaddlePosition));
	}

	private IEnumerator PopulateDistanceCalcStartPosition()
	{
		animator.SetFloat("ForwardLean", riderDefaultForwardLean);
		yield return new WaitForSeconds(1f);
		distanceCalcAtStartPosition = Vector3.Distance(riderRightHand.position, actualHorseHead.position);
		allowHandIKDisable = true;
		base.transform.parent.rotation = startRot;
	}

	private void PopulateStartCombinedHandPosition()
	{
		startCombinedHandPosition = combinedHandIKTarget.localPosition;
	}

	private void SetRiderForwardLean()
	{
		animator.SetFloat("HipsPosition", riderDefaultForwardLean);
	}

	private void SetRiderLegSpread()
	{
		animator.SetFloat("LegSpread", riderLegSpread);
	}

	private void SetIKStartPositions()
	{
		rightLegIKPosStart = rightLegIKTarget.localPosition;
		leftLegIKPosStart = leftLegIKTarget.localPosition;
		rightHandIKPosStart = rightHandIKTarget.localPosition;
		leftHandIKPosStart = leftHandIKTarget.localPosition;
	}

	private void SetIKStartRotations()
	{
		rightLegIKPosStart = rightLegIKTarget.localPosition;
		leftLegIKPosStart = leftLegIKTarget.localPosition;
		rightHandIKPosStart = rightHandIKTarget.localPosition;
		leftHandIKPosStart = leftHandIKTarget.localPosition;
	}

	private void SetFootPosition()
	{
		rightLegIKTarget.localRotation = Quaternion.identity;
		leftLegIKTarget.localRotation = Quaternion.identity;
		rightLegIKTarget.localPosition = rightLegIKPosStart;
		rightLegIKTarget.Translate(riderFootSpread, riderFootHeight, riderFootPosition, Space.Self);
		leftLegIKTarget.localPosition = leftLegIKPosStart;
		leftLegIKTarget.Translate(0f - riderFootSpread, riderFootHeight, riderFootPosition, Space.Self);
		rightLegIKTarget.localRotation = rightLegIKRotStart;
		rightLegIKTarget.Rotate(new Vector3(riderFootTilt, riderFootAngle, 0f));
		leftLegIKTarget.localRotation = leftLegIKRotStart;
		leftLegIKTarget.Rotate(new Vector3(riderFootTilt, 0f - riderFootAngle, 0f));
	}

	private void SetHandPosition()
	{
		rightHandIKTarget.localRotation = Quaternion.identity;
		leftHandIKTarget.localRotation = Quaternion.identity;
		rightHandIKTarget.localPosition = rightHandIKPosStart;
		rightHandIKTarget.Translate(riderHandSpread, riderHandHeight, riderHandPosition, Space.Self);
		leftHandIKTarget.localPosition = leftHandIKPosStart;
		leftHandIKTarget.Translate(0f - riderHandSpread, riderHandHeight, riderHandPosition, Space.Self);
		if (updatePositionEveryFrame)
		{
			SetHandRotation(rightHandIKTarget, isRightHand: true);
			SetHandRotation(leftHandIKTarget, isRightHand: false);
		}
	}

	public void OnRelayedAnimatorIK()
	{
		if (HasReactiveRiderPrereqs() && HasIKPrereqs())
		{
			if (allowHandIKDisable)
			{
				CheckHandIKEnabled();
			}
			SetRiderIK();
		}
	}

	private bool HasIKPrereqs()
	{
		bool result = true;
		if (animator == null)
		{
			Debug.LogError(base.gameObject.transform.parent.name + ": Reactive Rider: animator: could not find animator on rider!");
			result = false;
		}
		if (!RiderHasIKTargets())
		{
			Debug.LogError(base.gameObject.transform.parent.name + ": Reactive Rider: bool HasIKPrereqs(): Internal Error.");
			result = false;
		}
		return result;
	}

	private void SetRiderIK()
	{
		SetRiderIKPositionWeights();
		SetRiderIKRotationWeights();
		SetRiderIKPositionGoals();
		SetRiderIKRotationGoals();
		if (useHeadIK)
		{
			SetRiderHeadIKWeight();
			if (exteneralTarget == null)
			{
				SetRiderHeadIKGoals(GetHeadLookAtPosition());
			}
			else
			{
				SetRiderHeadIKGoals(GetExternalTargetPosition());
			}
		}
	}

	private void SetRiderIKPositionWeights()
	{
		animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
		animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
		if (HandIKPassEnabled)
		{
			animator.SetIKPositionWeight(AvatarIKGoal.RightHand, handIKWeight);
			animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, handIKWeight);
		}
	}

	private void SetRiderIKRotationWeights()
	{
		animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1f);
		animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);
		if (HandIKPassEnabled)
		{
			animator.SetIKRotationWeight(AvatarIKGoal.RightHand, handIKWeight);
			animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, handIKWeight);
		}
	}

	private void SetRiderIKPositionGoals()
	{
		animator.SetIKPosition(AvatarIKGoal.RightFoot, rightLegIKTarget.position);
		animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftLegIKTarget.position);
		if (HandIKPassEnabled)
		{
			animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandIKTarget.position);
			animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIKTarget.position);
		}
	}

	private void SetRiderIKRotationGoals()
	{
		animator.SetIKRotation(AvatarIKGoal.RightFoot, rightLegIKTarget.rotation);
		animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftLegIKTarget.rotation);
		if (HandIKPassEnabled)
		{
			animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandIKTarget.rotation);
			animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandIKTarget.rotation);
		}
	}

	private void SetRiderHeadIKWeight()
	{
		animator.SetLookAtWeight(1f);
	}

	private void SetRiderHeadIKGoals(Vector3 target)
	{
		animator.SetLookAtPosition(target);
	}

	private void LateUpdate()
	{
		if (HasReactiveRiderPrereqs())
		{
			if (updatePositionEveryFrame)
			{
				AdjustRiderPosition();
			}
			else
			{
				SetHandRotation(rightHandIKTarget, isRightHand: true);
				SetHandRotation(leftHandIKTarget, isRightHand: false);
			}
			SetCombinedHandLocation();
			SetRuntimeRiderForwardLean();
			UpdateChestTwistValues();
			SetChestTwist();
		}
	}

	private void SetHandRotation(Transform hand, bool isRightHand)
	{
		hand.LookAt(actualHorseHead);
		if (isRightHand)
		{
			hand.Rotate(standardHandRotationCorrection);
			return;
		}
		Vector3 eulers = standardHandRotationCorrection;
		eulers.y *= -1f;
		eulers.z *= -1f;
		hand.Rotate(eulers);
	}

	private void SetCombinedHandLocation()
	{
		Vector3 position = staticHorseHead.position;
		if (actualHorseHead.position.y < staticHorseHead.position.y)
		{
			position.y = (actualHorseHead.position.y + staticHorseHead.position.y) / 2f;
		}
		position.z = (actualHorseHead.position.z + staticHorseHead.position.z) / 2f;
		position.x = (actualHorseHead.position.x + staticHorseHead.position.x) / 2f;
		combinedHandIKTarget.position = position;
		if (combinedHandIKTarget.transform.localPosition.z > startCombinedHandPosition.z)
		{
			Vector3 localPosition = combinedHandIKTarget.localPosition;
			localPosition.z = startCombinedHandPosition.z;
			combinedHandIKTarget.localPosition = localPosition;
		}
	}

	private void SetRuntimeRiderForwardLean()
	{
		if (distanceCalcAtStartPosition != 0f)
		{
			float num = Vector3.Distance(riderRightHand.position, actualHorseHead.position);
			calcForwardLean = Mathf.Clamp((num - distanceCalcAtStartPosition) * riderForwardLeanMultiplier + riderDefaultForwardLean, 0f, 0.5f);
			if (chestForwardLeanEnabled)
			{
				LastForwardLean = calcForwardLean;
			}
			else if (!forwardLeanTransitionRunning)
			{
				LastForwardLean = riderDefaultForwardLean;
			}
			animator.SetFloat("ForwardLean", LastForwardLean);
		}
	}

	private void UpdateChestTwistValues()
	{
		float b = 180f;
		if (exteneralTarget != null)
		{
			b = GetLookAtYVector(exteneralTarget.position, rider.transform.position);
			b = LimitTwist(b);
		}
		actualChestTwist = Mathf.Lerp(actualChestTwist, b, chestTwistSpeed * Time.deltaTime);
	}

	private void SetChestTwist()
	{
		animator.SetFloat("ChestTwist", actualChestTwist);
	}

	private void AdjustRiderPosition()
	{
		rider.transform.localPosition = Vector3.zero;
		rider.transform.Translate(new Vector3(riderXPositionAdjustment, riderHeightAdjustment + 1.6f, riderSaddlePosition));
		SetRiderLegSpread();
		SetFootPosition();
		SetHandPosition();
		SetRiderForwardLean();
	}

	private Vector3 GetHeadLookAtPosition()
	{
		Vector3 midpoint = GetMidpoint(humanHeadIKTarget.position, staticHumanHeadIKTarget.position);
		midpoint.y += defaultHeadTilt;
		return midpoint;
	}

	private Vector3 GetMidpoint(Vector3 position1, Vector3 position2)
	{
		return (position1 + position2) / 2f;
	}

	private bool RiderHasIKTargets()
	{
		if (rightLegIKTarget == null)
		{
			return false;
		}
		if (leftLegIKTarget == null)
		{
			return false;
		}
		if (rightHandIKTarget == null)
		{
			return false;
		}
		if (leftHandIKTarget == null)
		{
			return false;
		}
		return true;
	}

	private Vector3 GetExternalTargetPosition()
	{
		return exteneralTarget.position + new Vector3(0f, externalTargetYOffset, 0f);
	}

	private float LimitTwist(float yVector)
	{
		if (HandIKPassEnabled)
		{
			return Mathf.Clamp(yVector, 0f + (180f - maxChestTwistWithHandIKEnabled), 360f - (180f - maxChestTwistWithHandIKEnabled));
		}
		return Mathf.Clamp(yVector, 0f + (180f - maxChestTwist), 360f - (180f - maxChestTwist));
	}

	private float GetLookAtYVector(Vector3 position, Vector3 target)
	{
		return Quaternion.LookRotation(target - position).eulerAngles.y;
	}

	private IEnumerator DisableHandIKOverTime(float time)
	{
		float newWeight = 1f;
		while (newWeight != 0f)
		{
			newWeight = (handIKWeight = Mathf.Clamp01(newWeight - Time.deltaTime / time));
			yield return 0;
		}
		HandIKPassEnabled = false;
	}

	private IEnumerator DisableChestForwardLeanOverTime(float time)
	{
		forwardLeanTransitionRunning = true;
		chestForwardLeanEnabled = false;
		float newWeight = 1f;
		while (newWeight != 0f)
		{
			newWeight = Mathf.Clamp01(newWeight - Time.deltaTime / time);
			LastForwardLean = Mathf.Clamp(newWeight * calcForwardLean, riderDefaultForwardLean, 0.5f);
			yield return 0;
		}
		forwardLeanTransitionRunning = false;
	}

	private IEnumerator EnableHandIKOverTime(float time)
	{
		handIKWeight = 0f;
		HandIKPassEnabled = true;
		float newWeight = 0f;
		while (newWeight != 1f)
		{
			newWeight = (handIKWeight = Mathf.Clamp01(newWeight + Time.deltaTime / time));
			yield return 0;
		}
	}

	private IEnumerator EnableChestForwardLeanOverTime(float time)
	{
		forwardLeanTransitionRunning = true;
		float newWeight = 0f;
		while (newWeight != 1f)
		{
			newWeight = Mathf.Clamp01(newWeight + Time.deltaTime / time);
			LastForwardLean = Mathf.Clamp(newWeight * calcForwardLean, riderDefaultForwardLean, 0.5f);
			yield return 0;
		}
		chestForwardLeanEnabled = true;
		forwardLeanTransitionRunning = false;
	}
}
