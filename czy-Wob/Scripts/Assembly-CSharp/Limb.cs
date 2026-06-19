using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
	private LimbStrengthModifier reusableMod;

	private List<int> modsToRemove = new List<int>();

	private float limbStrength = 1f;

	private static float compensationMax = 0.25f;

	private float currentCompensation;

	private float restoreRate = 0.05f;

	private float restThresholdMin;

	private float restThresholdMax = 0.9f;

	private float strainThreshold = 0.6f;

	private float strainTimerRequired = 2f;

	private float strainTimerCurrent;

	private bool isResting;

	private float fatigueMultiplier = 5E-06f;

	private float maxFatigueLoss = 0.25f;

	private Dictionary<int, float> XMotorValues = new Dictionary<int, float>();

	private Dictionary<int, float> YZMotorValues = new Dictionary<int, float>();

	private Dictionary<int, float> XLowBounceValues = new Dictionary<int, float>();

	private Dictionary<int, float> XHighBounceValues = new Dictionary<int, float>();

	private Dictionary<int, float> YBounceValues = new Dictionary<int, float>();

	private Dictionary<int, float> ZBounceValues = new Dictionary<int, float>();

	private Dictionary<int, float> XSpringValues = new Dictionary<int, float>();

	private JointDrive tempDrive;

	private SoftJointLimit tempJointLimit;

	private SoftJointLimitSpring tempJointLimitSpring;

	private float uselessJointDriveMultiplierX = 0.5f;

	private float uselessJointDriveMultiplierYZ = 0.5f;

	private float uselessJointBounceMultiplier;

	private float uselessJointSpringMultiplier = 0.1f;

	private float velDriveMultX = 0.5f;

	private float velDriveMultYZ = 0.75f;

	private float velDriveBounce = 0.5f;

	private float velDriveSpring = 0.5f;

	private float ungroundedJointDriveMultiplierX = 2f;

	private float ungroundedJointDriveMultiplierYZ = 2f;

	private float ungroundedJointBounceMultiplier;

	private float ungroundedJointSpringMultiplier = 0.1f;

	private TensionContainer sleepContainer;

	private TensionContainer velocityToleranceContainer;

	private bool tensionGone;

	private float ungroundedTimer;

	private float ungroundedTensionLossTimer = 0.2f;

	private bool isPlanted;

	private bool needsPlant;

	private FixedJoint plantedJoint;

	private float breakForce = 1000f;

	private float breakTorque = 1000f;

	private Color defaultLimbColor;

	private int velToleranceKey = -1;

	private float velToleranceModTimer = 5f;

	private float velToleranceModTimerWiggle = 0.5f;

	private float currentLimbVelocityTolerance;

	private float toleranceIncrease = 0.01f;

	private bool isSuppressed;

	private Dictionary<int, LimbStrengthModifier> strengthMods = new Dictionary<int, LimbStrengthModifier>();

	private List<int> strengthModKeys = new List<int>();

	private int modKey;

	private Color suppressedColor = new Color(1f, 0f, 1f);

	private Dictionary<GameObject, float> initialLimbSegmentPositions = new Dictionary<GameObject, float>();

	private float limbPositionTolerance = 2f;

	private float currentPlantedRecheckTimer;

	private float plantedRecheckTimer = 0.25f;

	private List<Rigidbody> jointChainRigidbodies = new List<Rigidbody>();

	private List<ConfigurableJoint> jointChainJoints = new List<ConfigurableJoint>();

	private int cacheEulerRotationFrame = -1;

	private int cacheTargetJointRotFrame = -1;

	private Vector3 cachedEulerRotation = Vector3.zero;

	private Vector3 cachedTargetJointRot = Vector3.zero;

	private DoggyBrain brainRef;

	private Vector3 targetJointRot;

	private Rigidbody selfRigidbody;

	private Transform yReferenceObj;

	private GameObject referenceLimb;

	private LegController controller;

	private ConfigurableJoint jointRef;

	private bool debugVis;

	private void Update()
	{
		if (!(controller == null) && !(brainRef == null) && brainRef.isInitialized())
		{
			UpdateStrengthMods();
			UpdateStrainTimer();
			PassiveRestoreLegStrength();
			CheckUngroundedness();
			if (needsPlant)
			{
				PlantLeg();
			}
			else if (isPlanted)
			{
				CheckPlantedness();
			}
			CheckVelocityTolerance();
		}
	}

	private void FixedUpdate()
	{
		CheckLimbPositions();
	}

	public TensionContainer GetSleepMod()
	{
		return sleepContainer;
	}

	public void Initialize(LegController controller)
	{
		brainRef = base.transform.root.gameObject.GetComponent<DoggyBrain>();
		this.controller = controller;
		defaultLimbColor = GetComponent<Renderer>().material.color;
		selfRigidbody = GetComponent<Rigidbody>();
		for (int i = 0; i < base.transform.parent.childCount; i++)
		{
			ConfigurableJoint component = base.transform.parent.GetChild(i).GetComponent<ConfigurableJoint>();
			if (!(component == null))
			{
				GameObject gameObject = component.connectedBody.gameObject;
				if ((referenceLimb == null && gameObject == controller.bodyFront) || gameObject == controller.bodyBack)
				{
					referenceLimb = base.transform.parent.GetChild(i).gameObject;
				}
				GameObject gameObject2 = base.transform.parent.GetChild(i).gameObject;
				initialLimbSegmentPositions[gameObject2] = Vector3.Distance(gameObject2.transform.localPosition, gameObject.transform.localPosition);
			}
		}
		jointRef = referenceLimb.GetComponent<ConfigurableJoint>();
		yReferenceObj = jointRef.connectedBody.transform;
		targetJointRot = referenceLimb.transform.localEulerAngles;
		ShadeLimb(new Color(1f - limbStrength, 0f, limbStrength));
		float num = Mathf.Max(controller.GetScaleMod(), 1f);
		float x = controller.transform.localScale.x;
		for (int j = 0; j < base.transform.parent.childCount; j++)
		{
			ConfigurableJoint component2 = base.transform.parent.GetChild(j).GetComponent<ConfigurableJoint>();
			if (!(component2 == null))
			{
				component2.GetComponent<Rigidbody>().mass *= x;
				SoftJointLimit lowAngularXLimit = component2.lowAngularXLimit;
				SoftJointLimit highAngularXLimit = component2.highAngularXLimit;
				SoftJointLimit angularYLimit = component2.angularYLimit;
				SoftJointLimit angularZLimit = component2.angularZLimit;
				SoftJointLimitSpring angularXLimitSpring = component2.angularXLimitSpring;
				SoftJointLimitSpring angularYZLimitSpring = component2.angularYZLimitSpring;
				JointDrive angularXDrive = component2.angularXDrive;
				JointDrive angularYZDrive = component2.angularYZDrive;
				lowAngularXLimit.bounciness *= num;
				component2.lowAngularXLimit = lowAngularXLimit;
				highAngularXLimit.bounciness *= num;
				component2.highAngularXLimit = highAngularXLimit;
				angularYLimit.bounciness *= num;
				component2.angularYLimit = angularYLimit;
				angularZLimit.bounciness *= num;
				component2.angularZLimit = angularZLimit;
				angularXLimitSpring.spring *= num * GlobalProperties.gravMod;
				component2.angularXLimitSpring = angularXLimitSpring;
				angularYZLimitSpring.spring *= num * GlobalProperties.gravMod;
				component2.angularYZLimitSpring = angularYZLimitSpring;
				angularXDrive.positionSpring *= num * GlobalProperties.gravMod;
				angularXDrive.maximumForce *= num * GlobalProperties.gravMod;
				component2.angularXDrive = angularXDrive;
				angularYZDrive.positionSpring *= num * GlobalProperties.gravMod;
				angularYZDrive.maximumForce *= num * GlobalProperties.gravMod;
				component2.angularYZDrive = angularYZDrive;
				XMotorValues[j] = component2.angularXDrive.positionSpring;
				YZMotorValues[j] = component2.angularYZDrive.positionSpring;
				XLowBounceValues[j] = component2.lowAngularXLimit.bounciness;
				XHighBounceValues[j] = component2.highAngularXLimit.bounciness;
				YBounceValues[j] = component2.angularYLimit.bounciness;
				ZBounceValues[j] = component2.angularZLimit.bounciness;
				XSpringValues[j] = component2.angularXLimitSpring.spring;
			}
		}
		sleepContainer = default(TensionContainer);
		sleepContainer.jointDriveX = uselessJointDriveMultiplierX;
		sleepContainer.jointDriveYZ = uselessJointDriveMultiplierYZ;
		sleepContainer.jointBounce = uselessJointBounceMultiplier;
		sleepContainer.jointSpring = uselessJointSpringMultiplier;
		velocityToleranceContainer = default(TensionContainer);
		velocityToleranceContainer.jointDriveX = velDriveMultX;
		velocityToleranceContainer.jointDriveYZ = velDriveMultYZ;
		velocityToleranceContainer.jointBounce = velDriveBounce;
		velocityToleranceContainer.jointSpring = velDriveSpring;
		jointChainRigidbodies.Clear();
		for (int k = 0; k < base.transform.parent.childCount; k++)
		{
			Rigidbody component3 = base.transform.parent.GetChild(k).GetComponent<Rigidbody>();
			if (!(component3 == null))
			{
				jointChainRigidbodies.Add(component3);
				ConfigurableJoint component4 = base.transform.parent.GetChild(k).GetComponent<ConfigurableJoint>();
				if (component4 != null)
				{
					jointChainJoints.Add(component4);
				}
			}
		}
	}

	public int RequestSleep()
	{
		return AddMod(sleepContainer);
	}

	public void RequestWakeUp(int key)
	{
		RemoveMod(key);
	}

	public bool IsLegPlanted()
	{
		if (plantedJoint == null)
		{
			return false;
		}
		return isPlanted;
	}

	public void PlantLeg(float customBreakForce = -1f, float customBreakTorque = -1f)
	{
		if (isPlanted)
		{
			return;
		}
		if (!controller.IsLegGrounded(base.gameObject))
		{
			needsPlant = true;
			return;
		}
		currentPlantedRecheckTimer = 0f;
		isPlanted = true;
		needsPlant = false;
		plantedJoint = controller.GetFootForLeg(base.gameObject).AddComponent<FixedJoint>();
		if (customBreakForce != -1f)
		{
			plantedJoint.breakForce = customBreakForce;
		}
		else
		{
			plantedJoint.breakForce = breakForce;
		}
		if (customBreakTorque != -1f)
		{
			plantedJoint.breakTorque = customBreakTorque;
		}
		else
		{
			plantedJoint.breakTorque = breakTorque;
		}
	}

	public void UnplantLeg()
	{
		needsPlant = false;
		if (isPlanted)
		{
			Object.Destroy(plantedJoint);
			plantedJoint = null;
			isPlanted = false;
		}
	}

	private void CheckPlantedness()
	{
		if (currentPlantedRecheckTimer < plantedRecheckTimer)
		{
			currentPlantedRecheckTimer += Time.deltaTime;
			return;
		}
		currentPlantedRecheckTimer = 0f;
		if (isPlanted && !needsPlant && !(plantedJoint != null))
		{
			UnplantLeg();
			PlantLeg();
		}
	}

	public void SetLimbStrength(float newVal)
	{
		if (newVal < 0f || newVal > 1f)
		{
			Debug.LogError("Attempting to set limb strength to an invalid number: " + newVal + " Value must be between 0 and 1");
			return;
		}
		limbStrength = newVal;
		ShadeLimb(new Color(1f - limbStrength, 0f, limbStrength));
		if (!isResting && limbStrength <= restThresholdMin)
		{
			GiveOut();
		}
		if (isResting && limbStrength >= restThresholdMax)
		{
			Recover();
		}
		controller.OnLegStrengthUpdated();
	}

	public void OnLimbMovement()
	{
		if (!isResting && !isSuppressed)
		{
			ungroundedTimer = 0f;
			RestoreTension();
		}
	}

	public void ResetLimbAngularDrag()
	{
		SetLimbAngularDrag(0f);
	}

	public void SetLimbAngularDrag(float newDrag)
	{
		for (int i = 0; i < jointChainRigidbodies.Count; i++)
		{
			jointChainRigidbodies[i].angularDrag = newDrag;
		}
	}

	private void CheckVelocityTolerance()
	{
		if (selfRigidbody.velocity.magnitude > controller.GetLimbVelocityTolerance() + currentLimbVelocityTolerance)
		{
			VelocityGiveOut();
		}
	}

	private void CheckLimbPositions()
	{
		if (brainRef.IsDead())
		{
			return;
		}
		for (int i = 0; i < jointChainRigidbodies.Count; i++)
		{
			GameObject gameObject = jointChainRigidbodies[i].gameObject;
			GameObject gameObject2 = jointChainJoints[i].connectedBody.gameObject;
			if (Vector3.Distance(gameObject2.transform.localPosition, gameObject.transform.localPosition) > initialLimbSegmentPositions[gameObject] + limbPositionTolerance)
			{
				gameObject.transform.position = gameObject2.transform.position;
			}
		}
	}

	public void ResetLimbPositions()
	{
		for (int i = 0; i < jointChainRigidbodies.Count; i++)
		{
			GameObject obj = jointChainRigidbodies[i].gameObject;
			GameObject gameObject = jointChainJoints[i].connectedBody.gameObject;
			obj.transform.position = gameObject.transform.position;
		}
	}

	private void UpdateStrengthMods()
	{
		modsToRemove.Clear();
		for (int i = 0; i < strengthModKeys.Count; i++)
		{
			int num = strengthModKeys[i];
			reusableMod = strengthMods[num];
			if (reusableMod.removeOnTimer)
			{
				reusableMod.timer -= Time.deltaTime;
				if (reusableMod.timer <= 0f)
				{
					modsToRemove.Add(num);
				}
			}
			strengthMods[num] = reusableMod;
		}
		for (int j = 0; j < modsToRemove.Count; j++)
		{
			RemoveMod(modsToRemove[j]);
		}
	}

	public int AddOrUpdateMod(TensionContainer container, int key = -1, float timer = -1f)
	{
		if (strengthModKeys.Contains(key))
		{
			UpdateMod(key, timer);
			return key;
		}
		return AddMod(container, timer);
	}

	private void UpdateMod(int key, float timer)
	{
		LimbStrengthModifier value = strengthMods[key];
		if (timer != -1f)
		{
			value.removeOnTimer = true;
			value.timer = timer;
		}
		else
		{
			value.removeOnTimer = false;
		}
		strengthMods[key] = value;
	}

	public int AddMod(TensionContainer tensionInfo, float timer = -1f)
	{
		if (strengthMods.Count == 0)
		{
			ShadeLimb(suppressedColor);
			isSuppressed = true;
		}
		modKey++;
		LimbStrengthModifier value = new LimbStrengthModifier
		{
			tensionInfo = tensionInfo
		};
		if (timer != -1f)
		{
			value.removeOnTimer = true;
			value.timer = timer;
		}
		strengthMods[modKey] = value;
		strengthModKeys.Add(modKey);
		UpdateModTension();
		return modKey;
	}

	private void RemoveMod(int key)
	{
		strengthMods.Remove(key);
		strengthModKeys.Remove(key);
		if (strengthMods.Count == 0)
		{
			RemoverShade();
			isSuppressed = false;
			Recover(fromModRemoval: true);
		}
		else
		{
			UpdateModTension();
		}
	}

	private void UpdateModTension()
	{
		float num = float.PositiveInfinity;
		float num2 = float.PositiveInfinity;
		float num3 = float.PositiveInfinity;
		float num4 = float.PositiveInfinity;
		for (int i = 0; i < strengthModKeys.Count; i++)
		{
			TensionContainer tensionInfo = strengthMods[strengthModKeys[i]].tensionInfo;
			if (tensionInfo.jointDriveX < num)
			{
				num = tensionInfo.jointDriveX;
			}
			if (tensionInfo.jointDriveYZ < num2)
			{
				num2 = tensionInfo.jointDriveYZ;
			}
			if (tensionInfo.jointBounce < num3)
			{
				num3 = tensionInfo.jointBounce;
			}
			if (tensionInfo.jointSpring < num4)
			{
				num4 = tensionInfo.jointSpring;
			}
		}
		RemoveTension(num, num2, num3, num4);
	}

	private void CheckUngroundedness()
	{
		if (isResting || isSuppressed)
		{
			return;
		}
		if (ungroundedTimer >= ungroundedTensionLossTimer && controller.IsLegGrounded(base.gameObject))
		{
			ungroundedTimer = 0f;
			RestoreTension();
		}
		else if (ungroundedTimer < ungroundedTensionLossTimer)
		{
			ungroundedTimer += Time.deltaTime;
			if (ungroundedTimer >= ungroundedTensionLossTimer)
			{
				RemoveTension(ungroundedJointDriveMultiplierX, ungroundedJointDriveMultiplierYZ, ungroundedJointBounceMultiplier, ungroundedJointSpringMultiplier, topLevelOnly: true);
			}
		}
	}

	private void RemoveTension(float newSpringMultX, float newSpringMultYZ, float newBounceMultiplier, float newJointSpringMultiplier, bool topLevelOnly = false)
	{
		controller.OnLimbTensionRemoved(base.gameObject);
		for (int i = 0; i < base.transform.parent.childCount; i++)
		{
			if (!topLevelOnly || i == 0)
			{
				RemoveTensionInternal(base.transform.parent.GetChild(i), newSpringMultX, newSpringMultYZ, newBounceMultiplier, newJointSpringMultiplier);
			}
		}
	}

	private void RemoveTensionInternal(Transform transform, float newSpringMultX, float newSpringMultYZ, float newBounceMultiplier, float newJointSpringMultiplier)
	{
		tensionGone = true;
		tempDrive = transform.GetComponent<ConfigurableJoint>().angularXDrive;
		tempDrive.positionSpring *= newSpringMultX;
		transform.GetComponent<ConfigurableJoint>().angularXDrive = tempDrive;
		tempDrive = transform.GetComponent<ConfigurableJoint>().angularYZDrive;
		tempDrive.positionSpring *= newSpringMultYZ;
		transform.GetComponent<ConfigurableJoint>().angularYZDrive = tempDrive;
		tempJointLimit = transform.GetComponent<ConfigurableJoint>().lowAngularXLimit;
		tempJointLimit.bounciness *= newBounceMultiplier;
		transform.GetComponent<ConfigurableJoint>().lowAngularXLimit = tempJointLimit;
		tempJointLimit = transform.GetComponent<ConfigurableJoint>().highAngularXLimit;
		tempJointLimit.bounciness *= newBounceMultiplier;
		transform.GetComponent<ConfigurableJoint>().highAngularXLimit = tempJointLimit;
		tempJointLimit = transform.GetComponent<ConfigurableJoint>().angularYLimit;
		tempJointLimit.bounciness *= newBounceMultiplier;
		transform.GetComponent<ConfigurableJoint>().angularYLimit = tempJointLimit;
		tempJointLimit = transform.GetComponent<ConfigurableJoint>().angularZLimit;
		tempJointLimit.bounciness *= newBounceMultiplier;
		transform.GetComponent<ConfigurableJoint>().angularZLimit = tempJointLimit;
		tempJointLimitSpring = transform.GetComponent<ConfigurableJoint>().angularXLimitSpring;
		tempJointLimitSpring.spring *= newJointSpringMultiplier;
		transform.GetComponent<ConfigurableJoint>().angularXLimitSpring = tempJointLimitSpring;
	}

	private void RestoreTension()
	{
		if (tensionGone)
		{
			controller.OnLimbTensionRestored(base.gameObject);
			for (int i = 0; i < jointChainJoints.Count; i++)
			{
				tempDrive = jointChainJoints[i].angularXDrive;
				tempDrive.positionSpring = XMotorValues[i];
				jointChainJoints[i].angularXDrive = tempDrive;
				tempDrive = jointChainJoints[i].angularYZDrive;
				tempDrive.positionSpring = YZMotorValues[i];
				jointChainJoints[i].angularYZDrive = tempDrive;
				tempJointLimit = jointChainJoints[i].lowAngularXLimit;
				tempJointLimit.bounciness = XLowBounceValues[i];
				jointChainJoints[i].lowAngularXLimit = tempJointLimit;
				tempJointLimit = jointChainJoints[i].highAngularXLimit;
				tempJointLimit.bounciness = XHighBounceValues[i];
				jointChainJoints[i].highAngularXLimit = tempJointLimit;
				tempJointLimit = jointChainJoints[i].angularYLimit;
				tempJointLimit.bounciness = YBounceValues[i];
				jointChainJoints[i].angularYLimit = tempJointLimit;
				tempJointLimit = jointChainJoints[i].angularZLimit;
				tempJointLimit.bounciness = ZBounceValues[i];
				jointChainJoints[i].angularZLimit = tempJointLimit;
				tempJointLimitSpring = jointChainJoints[i].angularXLimitSpring;
				tempJointLimitSpring.spring = XSpringValues[i];
				jointChainJoints[i].angularXLimitSpring = tempJointLimitSpring;
			}
			tensionGone = false;
		}
	}

	public void ForceGiveOut()
	{
		VelocityGiveOut();
	}

	private void VelocityGiveOut()
	{
		velToleranceKey = AddOrUpdateMod(velocityToleranceContainer, velToleranceKey, velToleranceModTimer + Random.Range(0f - velToleranceModTimerWiggle, velToleranceModTimerWiggle));
		currentLimbVelocityTolerance += toleranceIncrease * Time.deltaTime;
	}

	private void GiveOut()
	{
		isResting = true;
		RemoveTension(uselessJointDriveMultiplierX, uselessJointDriveMultiplierYZ, uselessJointBounceMultiplier, uselessJointSpringMultiplier);
	}

	private void Recover(bool fromModRemoval = false)
	{
		if (fromModRemoval)
		{
			if (isResting)
			{
				return;
			}
		}
		else
		{
			isResting = false;
			if (isSuppressed)
			{
				return;
			}
		}
		RestoreTension();
	}

	public float GetLimbStrength(bool applyLimbCompensation = true)
	{
		if (isResting || isSuppressed)
		{
			return 0f;
		}
		if (applyLimbCompensation)
		{
			return limbStrength + currentCompensation;
		}
		return limbStrength;
	}

	public Vector3 ModifyTorqueFromJointLimits(Vector3 torqueVector, bool useFuckedUpTorqueDamping = false, bool dampX = true, bool dampY = true, bool dampZ = true)
	{
		Vector3 currentRot = GetCurrentRot();
		Vector3 vector = GetTargetJointRot();
		float x = torqueVector.x;
		float y = torqueVector.y;
		float z = torqueVector.z;
		if (dampX)
		{
			x = ((!useFuckedUpTorqueDamping) ? GetTorqueValueForAxis(torqueVector.x, currentRot.x, vector.x, 0f - jointRef.angularZLimit.limit, jointRef.angularZLimit.limit) : GetFuckedUpTorqueValueForAxis(torqueVector.x, currentRot.x, vector.x, 0f - jointRef.angularZLimit.limit, jointRef.angularZLimit.limit));
		}
		if (dampY)
		{
			y = ((!useFuckedUpTorqueDamping) ? GetTorqueValueForAxis(torqueVector.y, currentRot.y, vector.y, 0f - jointRef.angularYLimit.limit, jointRef.angularYLimit.limit) : GetFuckedUpTorqueValueForAxis(torqueVector.y, currentRot.y, vector.y, 0f - jointRef.angularYLimit.limit, jointRef.angularYLimit.limit));
		}
		if (dampZ)
		{
			z = ((!useFuckedUpTorqueDamping) ? GetTorqueValueForAxis(torqueVector.z, currentRot.z, vector.z, jointRef.lowAngularXLimit.limit, jointRef.highAngularXLimit.limit) : GetFuckedUpTorqueValueForAxis(torqueVector.z, currentRot.z, vector.z, jointRef.lowAngularXLimit.limit, jointRef.highAngularXLimit.limit));
		}
		return new Vector3(x, y, z);
	}

	private Vector3 GetCurrentRot()
	{
		if (cacheEulerRotationFrame != Time.frameCount)
		{
			cacheEulerRotationFrame = Time.frameCount;
			cachedEulerRotation = referenceLimb.transform.eulerAngles;
		}
		return cachedEulerRotation;
	}

	private Vector3 GetTargetJointRot()
	{
		if (cacheTargetJointRotFrame != Time.frameCount)
		{
			cacheTargetJointRotFrame = Time.frameCount;
			cachedTargetJointRot = new Vector3(targetJointRot.x, yReferenceObj.rotation.eulerAngles.y, targetJointRot.z);
		}
		return cachedTargetJointRot;
	}

	private float GetTorqueValueForAxis(float torque, float currentRot, float targetRot, float lowRotLimit, float highRotLimit)
	{
		if (torque == 0f)
		{
			return torque;
		}
		currentRot %= 360f;
		targetRot %= 360f;
		if (currentRot == targetRot)
		{
			return torque;
		}
		if ((currentRot > targetRot && torque < 0f) || (currentRot < targetRot && torque > 0f))
		{
			return torque;
		}
		float num = torque;
		if (torque > 0f)
		{
			if (highRotLimit == 0f)
			{
				num = 0f;
			}
			else
			{
				highRotLimit += targetRot;
				num *= Mathf.Max(highRotLimit - currentRot, 0f) / (highRotLimit - targetRot);
				num = Mathf.Clamp(num, 0f, torque);
			}
		}
		else if (torque < 0f)
		{
			if (MathUtil.AlmostEqual(targetRot - (lowRotLimit + targetRot), 0f))
			{
				num = 0f;
			}
			else
			{
				lowRotLimit += targetRot;
				num *= Mathf.Max(currentRot - lowRotLimit, 0f) / (targetRot - lowRotLimit);
				num = Mathf.Clamp(num, torque, 0f);
			}
		}
		if ((torque > 0f && num < 0f) || (torque < 0f && num > 0f))
		{
			Debug.LogError("Torque switched signs when being damped.");
		}
		return num;
	}

	private float GetFuckedUpTorqueValueForAxis(float torque, float currentRot, float targetRot, float lowRotLimit, float highRotLimit)
	{
		if (torque == 0f)
		{
			return torque;
		}
		if (currentRot > 180f)
		{
			currentRot -= 360f;
		}
		if (targetRot > 180f)
		{
			targetRot -= 360f;
		}
		if (currentRot == targetRot)
		{
			return torque;
		}
		if ((currentRot > targetRot && torque < 0f) || (currentRot < targetRot && torque > 0f))
		{
			return torque;
		}
		float num = torque;
		if (torque > 0f)
		{
			highRotLimit += targetRot;
			if (highRotLimit == 0f)
			{
				return 0f;
			}
			num *= Mathf.Max(highRotLimit - currentRot, 0f) / highRotLimit;
			return Mathf.Clamp(num, 0f, torque);
		}
		if (torque < 0f)
		{
			lowRotLimit += targetRot;
			if (lowRotLimit == 0f)
			{
				return 0f;
			}
			num *= Mathf.Min(lowRotLimit - currentRot, 0f) / lowRotLimit;
			return Mathf.Clamp(num, torque, 0f);
		}
		return torque;
	}

	public float GetRawLimbStrength()
	{
		return limbStrength;
	}

	public void UpdateLimbCompensation(float newCompensation)
	{
		if (currentCompensation < 0f || currentCompensation > compensationMax)
		{
			Debug.LogError("Attempting to set limb compensation to an invalid number; " + newCompensation + " Value must be between 0 and compensationMax.");
		}
		currentCompensation = newCompensation;
	}

	public static float GetMaxCompensation()
	{
		return compensationMax;
	}

	public void ShadeLimb(Color newColor, bool debugOverride = false)
	{
		if ((debugVis || debugOverride) && !isSuppressed)
		{
			for (int i = 0; i < base.transform.parent.childCount; i++)
			{
				base.transform.parent.GetChild(i).GetComponent<Renderer>().material.color = newColor;
			}
		}
	}

	public void RemoverShade(bool debugOverride = false)
	{
		if (debugVis || debugOverride)
		{
			ShadeLimb(defaultLimbColor, debugOverride);
		}
	}

	private void UpdateStrainTimer()
	{
		if (isSuppressed)
		{
			strainTimerCurrent = 0f;
		}
		else if (!isResting && limbStrength <= strainThreshold)
		{
			strainTimerCurrent += Time.deltaTime;
			if (strainTimerCurrent >= strainTimerRequired)
			{
				GiveOut();
			}
		}
		else if (strainTimerCurrent > 0f)
		{
			strainTimerCurrent = Mathf.Max(strainTimerCurrent - Time.deltaTime, 0f);
		}
	}

	public void OnTorqueExherted(Vector3 torque)
	{
		UpdateLimbFatigue(torque);
	}

	private void UpdateLimbFatigue(Vector3 torqueExhertion)
	{
		if (!isSuppressed && limbStrength > 0f)
		{
			torqueExhertion *= fatigueMultiplier * Time.fixedDeltaTime;
			float a = Mathf.Abs(torqueExhertion.x) + Mathf.Abs(torqueExhertion.y) + Mathf.Abs(torqueExhertion.z);
			a = Mathf.Min(a, maxFatigueLoss);
			SetLimbStrength(Mathf.Max(limbStrength - a, 0f));
		}
	}

	private void PassiveRestoreLegStrength()
	{
		if (!isSuppressed && limbStrength < 1f)
		{
			SetLimbStrength(Mathf.Min(limbStrength + Time.deltaTime * restoreRate, 1f));
		}
	}
}
