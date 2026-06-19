using System.Collections.Generic;
using HighlightingSystem;
using UnityEngine;

public class LegController : MonoBehaviour
{
	public GameObject internalFacingObj;

	public GameObject bodyFront;

	public GameObject bodyBack;

	public GameObject collisionHelperBack;

	public GameObject collisionHelperFront;

	public GameObject collisionHelperBackBody;

	public GameObject collisionHelperFrontBody;

	public List<LegPair> legPairs;

	public GameObject mouth;

	public GameObject butt;

	private ConfigurableJoint absJoint;

	private Dictionary<Rigidbody, Rigidbody> muscleMap = new Dictionary<Rigidbody, Rigidbody>();

	private Dictionary<int, Vector3> torqueMap = new Dictionary<int, Vector3>();

	private float lastTorqueCall = -1f;

	private List<Rigidbody> torqueKeys = new List<Rigidbody>();

	private Dictionary<int, Rigidbody> rbCache = new Dictionary<int, Rigidbody>();

	private List<Limb> reusableLimbList = new List<Limb>();

	private GameObject reusableObj;

	private int anyLegGroundedCacheFrame = -1;

	private bool cachedAnyLegGrounded;

	private int allLegsGroundedCacheFrame = -1;

	private bool cachedAllLegsGrounded;

	private int numLegsGroundedCacheFrame = -1;

	private int cachedNumLegsGrounded;

	private float bodyObstructionCheckDist = 2f;

	private bool bodyLeftObstructionCacheVal;

	private bool bodyRightObstructionCacheVal;

	private float bodyLeftObstructionCacheFrame = -1f;

	private float bodyRightObstructionCacheFrame = -1f;

	private string footName = "foot";

	public float rightWalkStartOffset;

	public float rightWalkEndOffset;

	public float leftWalkStartOffset;

	public float leftWalkEndOffset;

	public Vector3 leftLegWalkModifier;

	public Vector3 rightLegWalkModifier;

	public List<WalkingGroup> walkForwardGroups;

	public float walkForwardLoopTime = 1f;

	public float maxLegAngularVelocity = 25f;

	public float legAngularDrag;

	public float maxBodyAngularVelocity = 15f;

	public float bodyAngularDrag;

	public float legWeight = 3f;

	public float bodyFrontWeight = 5f;

	public float bodyBackWeight = 7.5f;

	private float scaleMod = 1f;

	private float dogWeight;

	private float defaultDogWeight = 38.85f;

	private float dogWeightPercentage;

	private float scaledDogWeightPercentage;

	private float dogMouthHeight;

	private Vector3? dogBodyHalfExtents;

	private Vector3 bodyFrontCenterOfMassOffset = new Vector3(-0.1f, -0.45f, 0f);

	private Vector3 bodyBackCenterOfMassOffset = new Vector3(0.25f, -0.35f, 0f);

	private List<LegStructure> allLegStructures = new List<LegStructure>();

	private Dictionary<int, int> legToStructureMap = new Dictionary<int, int>();

	private Dictionary<int, int> footToStructureMap = new Dictionary<int, int>();

	private Dictionary<int, List<int>> bodyToStructuresMap = new Dictionary<int, List<int>>();

	public Vector3 walkRestoreMod = new Vector3(0.5f, 0.5f, 0f);

	private Vector3 defaultRestoreMod = Vector3.one;

	private bool isDead;

	private List<float> compensationList = new List<float>();

	private Dictionary<int, float> rawStrengthDict = new Dictionary<int, float>();

	private List<RestoreGroup> restoreGroups = new List<RestoreGroup>();

	private List<KeyCode> simulatedKeyPresses = new List<KeyCode>();

	private InputSimulator inputSim;

	private bool frozen;

	private bool xStepsLocked;

	private bool zStepsLocked;

	private bool stabilityStepsAllowed = true;

	private bool bodyStabilityLocked;

	private Vector3 lockedBodyStability = Vector3.zero;

	private bool updateLegStrength;

	private bool absNeedTightening;

	private float absTensionRestoreTimer = 1f;

	private float currentAbsTensionRestoreTimer;

	private float defaultAbsTensionX;

	private float defaultAbsTensionYZ;

	private float minisculeAbsTension = 0.5f;

	private float absTensionPercentageTarget = -1f;

	private SoftJointLimit defaultAbsLimit;

	private SoftJointLimit loosenedAbsLimit;

	private List<LooseAbsLock> absLocks = new List<LooseAbsLock>();

	private float limbVelocityTolerance = 50f;

	private List<GameObject> limbsWithoutTension = new List<GameObject>();

	private Dictionary<GameObject, float> initialBodyPositions = new Dictionary<GameObject, float>();

	private List<GameObject> initialBodyPositionKeys = new List<GameObject>();

	private List<Joint> initialBodyPositionJoints = new List<Joint>();

	private Dictionary<GameObject, float> initialBodyMeshPositions = new Dictionary<GameObject, float>();

	private List<GameObject> initialBodyMeshPositionKeys = new List<GameObject>();

	private List<Joint> initialBodyMeshPositionJoints = new List<Joint>();

	private float positionTolerance = 1f;

	private float unmovingVelocity = 1f;

	private float standUpTimer = 1f;

	private float needsStandupTimerCurrent;

	private bool initialized;

	private bool isWalking;

	private WalkController walkControllerRef;

	private DogAI aiRef;

	private BodyBuck buckRef;

	private DogLooks looksRef;

	private DoggyBrain brainRef;

	private FaceController faceRef;

	private DogRegistration dogRegRef;

	private MasterDogGene masterDogGeneRef;

	private ObjectRegistration registration;

	public void PreInitialize()
	{
		aiRef = GetComponent<DogAI>();
		looksRef = GetComponent<DogLooks>();
		brainRef = GetComponent<DoggyBrain>();
		faceRef = GetComponent<FaceController>();
		masterDogGeneRef = GetComponent<MasterDogGene>();
		registration = ObjectRegistration.GetRegistrationScript();
		inputSim = registration.GetGlobalComponent<InputSimulator>(GlobalObject.INPUT_SIMULATOR);
		dogRegRef = registration.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION, nullAllowed: true);
		AddNeededComponents();
		bodyFront.GetComponent<Rigidbody>().maxAngularVelocity = maxBodyAngularVelocity;
		bodyBack.GetComponent<Rigidbody>().maxAngularVelocity = maxBodyAngularVelocity;
		bodyFront.GetComponent<Rigidbody>().angularDrag = bodyAngularDrag;
		bodyBack.GetComponent<Rigidbody>().angularDrag = bodyAngularDrag;
		SetBodyWeight(bodyFrontWeight, bodyBackWeight);
	}

	public void PostInitialize()
	{
		initialized = true;
		buckRef = GetComponent<BodyBuck>();
	}

	public float GetScaleMod()
	{
		return scaleMod;
	}

	private float GetGirthAndScaleMod(bool frontLeg)
	{
		float num = ((!frontLeg) ? looksRef.GetBackLegGirth() : looksRef.GetFrontLegGirth());
		if (num < 0f)
		{
			num = 0f;
		}
		return scaleMod + num;
	}

	public void Initialize()
	{
		scaleMod = 1f;
		if (base.transform.localScale.x < 1f)
		{
			scaleMod = Mathf.Max(1f + (base.transform.localScale.x - 1f) * 2f, 0.25f);
			if (scaleMod < 1f)
			{
				scaleMod += (1f - scaleMod) * 0.25f;
			}
		}
		else if (base.transform.localScale.x > 1f)
		{
			scaleMod += (base.transform.localScale.x - 1f) * 3f;
		}
		for (int i = 0; i < legPairs.Count; i++)
		{
			SetupLegPair(legPairs[i]);
		}
		InitializeWalkingGroups();
		ConfigurableJoint[] components = bodyFront.GetComponents<ConfigurableJoint>();
		foreach (ConfigurableJoint configurableJoint in components)
		{
			if (!(configurableJoint.connectedBody != bodyBack.GetComponent<Rigidbody>()))
			{
				absJoint = configurableJoint;
				JointDrive angularXDrive = absJoint.angularXDrive;
				JointDrive angularYZDrive = absJoint.angularYZDrive;
				angularXDrive.positionSpring *= scaleMod * GlobalProperties.gravMod;
				angularXDrive.maximumForce *= scaleMod * GlobalProperties.gravMod;
				angularYZDrive.positionSpring *= scaleMod * GlobalProperties.gravMod;
				angularYZDrive.maximumForce *= scaleMod * GlobalProperties.gravMod;
				absJoint.angularXDrive = angularXDrive;
				absJoint.angularYZDrive = angularYZDrive;
				defaultAbsTensionX = absJoint.angularYZDrive.positionSpring;
				defaultAbsTensionYZ = absJoint.angularYZDrive.positionSpring;
				defaultAbsLimit = absJoint.lowAngularXLimit;
				loosenedAbsLimit = default(SoftJointLimit);
				loosenedAbsLimit.bounciness = defaultAbsLimit.bounciness;
				loosenedAbsLimit.contactDistance = defaultAbsLimit.contactDistance;
				loosenedAbsLimit.limit = -90f;
				break;
			}
		}
		FillMuscleMap();
		FillTorqueAndRigidbodyMaps();
		UpdateCenterOfMass();
		AddNeededComponentsWithDependencies();
		SetUpBodyPositions();
		FindMouthHeight();
		StoreDogWeight();
	}

	private void AddNeededComponents()
	{
		base.gameObject.AddComponent<TurnInPlace>();
		walkControllerRef = base.gameObject.AddComponent<WalkController>();
	}

	private void AddNeededComponentsWithDependencies()
	{
		BodyBuck bodyBuck = base.gameObject.AddComponent<BodyBuck>();
		GetComponent<TurnInPlace>().SetBuckRef(bodyBuck);
	}

	private void FixedUpdate()
	{
		CheckBodyPositions();
		if (!isDead && initialized && brainRef.isInitialized())
		{
			if (!frozen)
			{
				UpdateSimulatedInput();
				HandleInput();
			}
			ApplyTorques();
		}
	}

	private void Update()
	{
		if (!isDead && initialized)
		{
			if (absNeedTightening)
			{
				TightenAbsInternal();
			}
			TryToStandIfNeeded();
		}
	}

	private void LateUpdate()
	{
		if (!isDead && initialized && updateLegStrength)
		{
			UpdateLegCompensation();
		}
	}

	public void OnDie(InventoryItem legItem, float force, Vector3 dogCenter, float radius, float upwardsMod, List<GameObject> dogParts, List<GutFloraResource> additionalFlora, List<GutFloraResource> additionalFloraBoosted, GameObject deathParticles = null)
	{
		isDead = true;
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			ConfigurableJoint[] componentsInChildren = allLegStructures[i].legHolder.GetComponentsInChildren<ConfigurableJoint>();
			foreach (ConfigurableJoint configurableJoint in componentsInChildren)
			{
				if (configurableJoint.connectedBody.gameObject == bodyFront || configurableJoint.connectedBody.gameObject == bodyBack)
				{
					if (deathParticles != null)
					{
						Object.Instantiate(deathParticles, configurableJoint.connectedBody.transform.TransformPoint(configurableJoint.connectedAnchor), Quaternion.identity);
					}
					Object.Destroy(configurableJoint);
					Object.Destroy(allLegStructures[i].limb);
					Object.Destroy(allLegStructures[i].stabilizer);
				}
			}
			GameObject gameObject = new GameObject("Dog Leg");
			GameObject legHolder = allLegStructures[i].legHolder;
			LegMeshLinker component = legHolder.GetComponent<LegMeshLinker>();
			GameObject legBaseObject = component.legBaseObject;
			allLegStructures[i].limb.AddMod(allLegStructures[i].limb.GetSleepMod());
			legHolder.transform.SetParent(gameObject.transform);
			legBaseObject.transform.SetParent(gameObject.transform);
			ObjectUtil.ConvertObjectToFood(gameObject, legItem, component.legMesh.GetComponent<SkinnedMeshRenderer>().material.color, canSaveLoad: false, null, additionalFlora, additionalFloraBoosted);
			dogParts.Add(gameObject);
			Rigidbody[] componentsInChildren2 = gameObject.GetComponentsInChildren<Rigidbody>();
			foreach (Rigidbody obj in componentsInChildren2)
			{
				obj.mass *= 10f;
				obj.AddExplosionForce(force, dogCenter, radius, upwardsMod);
			}
			Highlighter[] componentsInChildren3 = gameObject.GetComponentsInChildren<Highlighter>();
			for (int j = 0; j < componentsInChildren3.Length; j++)
			{
				componentsInChildren3[j].ConstantOffImmediate();
			}
		}
		legPairs.Clear();
		allLegStructures.Clear();
		legToStructureMap.Clear();
		footToStructureMap.Clear();
		bodyToStructuresMap.Clear();
		muscleMap.Clear();
		torqueMap.Clear();
		torqueKeys.Clear();
		rbCache.Clear();
		reusableLimbList.Clear();
		walkForwardGroups.Clear();
		limbsWithoutTension.Clear();
		Object.Destroy(collisionHelperBack);
		Object.Destroy(collisionHelperFront);
		Object.Destroy(collisionHelperBackBody);
		Object.Destroy(collisionHelperFrontBody);
	}

	public float GetHeadLength()
	{
		return 1f;
	}

	public Vector3 GetDefaultRestoreMod()
	{
		return defaultRestoreMod;
	}

	public void LockStabilitySteps()
	{
		stabilityStepsAllowed = false;
	}

	public void UnlockStabilitySteps()
	{
		stabilityStepsAllowed = true;
	}

	public void SetXStepsLocked(bool val)
	{
		xStepsLocked = val;
	}

	public void SetZStepsLocked(bool val)
	{
		zStepsLocked = val;
	}

	public void LockBodyStability(Vector3 newLock)
	{
		if (bodyStabilityLocked)
		{
			Debug.LogError("Attempting to lock body stability but it's already locked");
			return;
		}
		bodyStabilityLocked = true;
		lockedBodyStability = newLock;
	}

	public void UnlockBodyStability()
	{
		if (!bodyStabilityLocked)
		{
			Debug.LogError("Attempting to unlock body stability but it isn't locked.");
			return;
		}
		bodyStabilityLocked = false;
		lockedBodyStability = Vector3.zero;
	}

	public bool IsBodyStabilityLocked()
	{
		return bodyStabilityLocked;
	}

	public Vector3 GetBodyStabilityLock()
	{
		return lockedBodyStability;
	}

	public Vector3 GetDogBodyHalfExtents()
	{
		if (!dogBodyHalfExtents.HasValue)
		{
			float num = bodyFront.transform.localScale.y / 2f;
			dogBodyHalfExtents = new Vector3(num, 0f, num);
		}
		return dogBodyHalfExtents.Value;
	}

	public float GetMouthHeight()
	{
		return dogMouthHeight;
	}

	private void FindMouthHeight()
	{
		BoundingBoxComponent boundingBoxComponent = base.gameObject.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = base.gameObject.AddComponent<BoundingBoxComponent>();
		}
		Vector3 position = faceRef.GetDogHeadForIndex(0).mouthTransform.position;
		Vector3 vector = boundingBoxComponent.GetBoxCenter() + Vector3.down * boundingBoxComponent.GetBoxSize().y;
		dogMouthHeight = position.y - vector.y;
	}

	public float GetWeightPercentage(float additionalCarriedMass = 0f)
	{
		if (additionalCarriedMass > 0f)
		{
			return (dogWeight + additionalCarriedMass) / defaultDogWeight;
		}
		return dogWeightPercentage;
	}

	public float GetScaledWeightPercentage()
	{
		return scaledDogWeightPercentage;
	}

	private void StoreDogWeight()
	{
		dogWeight = 0f;
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			dogWeight += rigidbody.mass;
		}
		dogWeightPercentage = dogWeight / defaultDogWeight;
		scaledDogWeightPercentage = dogWeightPercentage * dogWeightPercentage;
		scaledDogWeightPercentage += dogWeightPercentage;
		scaledDogWeightPercentage /= 2f;
	}

	public float GetLimbVelocityTolerance()
	{
		return limbVelocityTolerance;
	}

	public int GetNumPlantedLegs()
	{
		int num = 0;
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			if (allLegStructures[i].limb.IsLegPlanted())
			{
				num++;
			}
		}
		return num;
	}

	public void PlantLegs(float customBreakForce = -1f, float customBreakTorque = -1f)
	{
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			allLegStructures[i].limb.PlantLeg(customBreakForce, customBreakTorque);
		}
	}

	public void UnplantLegs()
	{
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			allLegStructures[i].limb.UnplantLeg();
		}
	}

	public void SetBodyWeight(float front, float back)
	{
		bodyFront.GetComponent<Rigidbody>().mass = front * base.transform.localScale.x;
		bodyBack.GetComponent<Rigidbody>().mass = back * base.transform.localScale.x;
	}

	public GameObject GetAFoot()
	{
		if (allLegStructures.Count == 0)
		{
			return bodyFront;
		}
		return allLegStructures[0].foot;
	}

	public List<LegStructure> GetAllLegStructures()
	{
		return allLegStructures;
	}

	public List<GameObject> GetAllLegs()
	{
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			list.Add(allLegStructures[i].leg);
		}
		return list;
	}

	public GameObject GetBodySegmentForLeg(GameObject leg)
	{
		int instanceID = leg.GetInstanceID();
		if (!legToStructureMap.ContainsKey(instanceID))
		{
			Debug.LogError("Invalid leg passed to GetBodySegmentForLeg: " + leg);
			return null;
		}
		return allLegStructures[legToStructureMap[instanceID]].attachedBody;
	}

	public GameObject GetFootForLeg(GameObject leg)
	{
		int instanceID = leg.GetInstanceID();
		if (!legToStructureMap.ContainsKey(instanceID))
		{
			Debug.LogError("Invalid leg passed to GetFootForLeg: " + leg);
			return null;
		}
		return allLegStructures[legToStructureMap[instanceID]].foot;
	}

	public GameObject GetParallelLeg(GameObject leg)
	{
		int instanceID = leg.GetInstanceID();
		if (!legToStructureMap.ContainsKey(instanceID))
		{
			Debug.LogError("Invalid leg passed to GetParallelLeg: " + leg);
			return null;
		}
		int parallelStructureIndex = allLegStructures[legToStructureMap[instanceID]].parallelStructureIndex;
		if (parallelStructureIndex < 0)
		{
			return null;
		}
		return allLegStructures[parallelStructureIndex].leg;
	}

	public LegGroup GetLegGroupForLegHolder(GameObject holder)
	{
		GameObject legForLegHolder = GetLegForLegHolder(holder);
		if (legForLegHolder == null)
		{
			return null;
		}
		return walkControllerRef.GetLegGroupForLeg(legForLegHolder);
	}

	public int GetLegCount()
	{
		return allLegStructures.Count;
	}

	public int GetLegCountForBodySegment(GameObject segment)
	{
		int result = 0;
		int instanceID = segment.GetInstanceID();
		if (bodyToStructuresMap.ContainsKey(instanceID))
		{
			result = bodyToStructuresMap[instanceID].Count;
		}
		return result;
	}

	public List<GameObject> GetLegsForBodySegment(GameObject segment)
	{
		int instanceID = segment.GetInstanceID();
		List<GameObject> list = new List<GameObject>();
		if (bodyToStructuresMap.ContainsKey(instanceID))
		{
			for (int i = 0; i < bodyToStructuresMap[instanceID].Count; i++)
			{
				list.Add(allLegStructures[bodyToStructuresMap[instanceID][i]].leg);
			}
		}
		return list;
	}

	public GameObject GetLegForLegHolder(GameObject holder)
	{
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			if (allLegStructures[i].legHolder == holder)
			{
				return allLegStructures[i].leg;
			}
		}
		return null;
	}

	public bool IsLegHolder(GameObject potentialHolder)
	{
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			if (allLegStructures[i].legHolder == potentialHolder)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsLegHolderAndGrounded(GameObject potentialHolder)
	{
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			if (allLegStructures[i].legHolder == potentialHolder)
			{
				if (!IsLegStructureGrounded(allLegStructures[i]))
				{
					break;
				}
				return true;
			}
		}
		return false;
	}

	public bool IsLegGrounded(GameObject leg, bool debugvis = false)
	{
		if (leg == null)
		{
			return false;
		}
		int instanceID = leg.GetInstanceID();
		if (legToStructureMap.ContainsKey(instanceID))
		{
			return IsLegStructureGrounded(allLegStructures[legToStructureMap[instanceID]], debugvis);
		}
		Debug.LogError("Invalid leg passed to IsLegGrounded.");
		return false;
	}

	public bool AnyLegGrounded(bool debugvis = false)
	{
		int frameCount = Time.frameCount;
		if (anyLegGroundedCacheFrame == frameCount)
		{
			return cachedAnyLegGrounded;
		}
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			if (IsLegStructureGrounded(allLegStructures[i], debugvis))
			{
				cachedAnyLegGrounded = true;
				anyLegGroundedCacheFrame = frameCount;
				return true;
			}
		}
		cachedAnyLegGrounded = false;
		anyLegGroundedCacheFrame = frameCount;
		return false;
	}

	public bool AllLegsGrounded(bool debugvis = false)
	{
		int frameCount = Time.frameCount;
		if (allLegsGroundedCacheFrame == frameCount)
		{
			return cachedAllLegsGrounded;
		}
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			if (!IsLegStructureGrounded(allLegStructures[i], debugvis))
			{
				cachedAllLegsGrounded = false;
				allLegsGroundedCacheFrame = frameCount;
				return false;
			}
		}
		cachedAllLegsGrounded = true;
		allLegsGroundedCacheFrame = frameCount;
		return true;
	}

	public int GetNumberOfGroundedLegs(bool debugvis = false)
	{
		int frameCount = Time.frameCount;
		if (numLegsGroundedCacheFrame == frameCount)
		{
			return cachedNumLegsGrounded;
		}
		int num = 0;
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			if (IsLegStructureGrounded(allLegStructures[i], debugvis))
			{
				num++;
			}
		}
		numLegsGroundedCacheFrame = frameCount;
		cachedNumLegsGrounded = num;
		return num;
	}

	public bool AnyLegsForSegmentGrounded(GameObject segment)
	{
		int instanceID = segment.GetInstanceID();
		if (bodyToStructuresMap.ContainsKey(instanceID))
		{
			for (int i = 0; i < bodyToStructuresMap[instanceID].Count; i++)
			{
				if (IsLegStructureGrounded(allLegStructures[bodyToStructuresMap[instanceID][i]]))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool IsLegStructureGrounded(LegStructure structure, bool debugvis = false)
	{
		if (structure.groundedCacheFrame != (float)Time.frameCount)
		{
			structure.groundedCacheFrame = Time.frameCount;
			structure.isGrounded = ObjectStatusUtil.CheckObjectGrounded(structure.foot, 0.01f, base.transform.localScale.x, debugvis);
		}
		return structure.isGrounded;
	}

	public bool IsLeftFrontObscured(bool debugVis = false)
	{
		if (bodyLeftObstructionCacheFrame != (float)Time.frameCount)
		{
			bodyLeftObstructionCacheFrame = Time.frameCount;
			bodyLeftObstructionCacheVal = RaycastUtil.StageRaycast(bodyFront.transform.position, -bodyFront.transform.forward, bodyObstructionCheckDist);
			if (debugVis)
			{
				Debug.DrawLine(bodyFront.transform.position, bodyFront.transform.position - bodyFront.transform.forward, Color.blue, bodyObstructionCheckDist);
			}
		}
		return bodyLeftObstructionCacheVal;
	}

	public bool IsRightFrontObscured(bool debugVis = false)
	{
		if (bodyRightObstructionCacheFrame != (float)Time.frameCount)
		{
			bodyRightObstructionCacheFrame = Time.frameCount;
			bodyRightObstructionCacheVal = RaycastUtil.StageRaycast(bodyFront.transform.position, bodyFront.transform.forward, bodyObstructionCheckDist);
			if (debugVis)
			{
				Debug.DrawLine(bodyFront.transform.position, bodyFront.transform.position + bodyFront.transform.forward, Color.blue, bodyObstructionCheckDist);
			}
		}
		return bodyRightObstructionCacheVal;
	}

	public void FreezeMotion()
	{
		frozen = true;
	}

	public void UnfreezeMotion()
	{
		frozen = false;
	}

	public void OnLimbTensionRemoved(GameObject limb)
	{
		if (!limbsWithoutTension.Contains(limb))
		{
			limbsWithoutTension.Add(limb);
			if (limbsWithoutTension.Count == allLegStructures.Count)
			{
				LoosenAbs(LooseAbsLock.LEG_TENSION);
			}
		}
	}

	public void OnLimbTensionRestored(GameObject limb)
	{
		limbsWithoutTension.Remove(limb);
		TightenAbs(LooseAbsLock.LEG_TENSION);
	}

	private void SetUpBodyPositions()
	{
		initialBodyPositions[bodyFront] = Vector3.Distance(bodyFront.transform.localPosition, bodyBack.transform.localPosition);
		initialBodyPositionKeys.Add(bodyFront);
		initialBodyPositionJoints.Add(bodyFront.GetComponent<Joint>());
		initialBodyMeshPositions[looksRef.bodyBackBone] = Vector3.Distance(looksRef.bodyBackBone.transform.position, bodyBack.transform.position);
		initialBodyMeshPositionKeys.Add(looksRef.bodyBackBone);
		initialBodyMeshPositionJoints.Add(looksRef.bodyBackBone.GetComponent<Joint>());
	}

	private void CheckBodyPositions()
	{
		for (int i = 0; i < initialBodyPositionKeys.Count; i++)
		{
			reusableObj = initialBodyPositionJoints[i].connectedBody.gameObject;
			if (Vector3.Distance(reusableObj.transform.localPosition, initialBodyPositionKeys[i].transform.localPosition) > initialBodyPositions[initialBodyPositionKeys[i]] + positionTolerance)
			{
				initialBodyPositionKeys[i].transform.position = reusableObj.transform.position;
			}
		}
		for (int j = 0; j < initialBodyMeshPositionKeys.Count; j++)
		{
			reusableObj = initialBodyMeshPositionJoints[j].connectedBody.gameObject;
			if (Vector3.Distance(reusableObj.transform.position, initialBodyMeshPositionKeys[j].transform.position) > initialBodyMeshPositions[initialBodyMeshPositionKeys[j]] + positionTolerance)
			{
				initialBodyMeshPositionKeys[j].transform.position = reusableObj.transform.position;
			}
		}
	}

	private void FillTorqueAndRigidbodyMaps()
	{
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			torqueMap[rigidbody.GetInstanceID()] = Vector3.zero;
			torqueKeys.Add(rigidbody);
			rbCache[rigidbody.gameObject.GetInstanceID()] = rigidbody;
		}
	}

	private void FillMuscleMap()
	{
		MuscleFillHelper(bodyFront.GetComponent<Rigidbody>(), bodyBack.GetComponent<Rigidbody>());
		List<LegStructure> list = GetAllLegStructures();
		for (int i = 0; i < list.Count; i++)
		{
			Rigidbody component = list[i].attachedBody.GetComponent<Rigidbody>();
			Rigidbody rigidbody = list[i].foot.GetComponent<Rigidbody>();
			while (rigidbody != component)
			{
				MuscleFillHelper(rigidbody, rigidbody.GetComponent<ConfigurableJoint>().connectedBody);
				rigidbody = rigidbody.GetComponent<ConfigurableJoint>().connectedBody.GetComponent<ConfigurableJoint>().connectedBody;
			}
		}
	}

	private void MuscleFillHelper(Rigidbody bodyA, Rigidbody bodyB)
	{
		muscleMap[bodyA] = bodyB;
		muscleMap[bodyB] = bodyA;
	}

	private void TightenAbsInternal()
	{
		JointDrive angularXDrive = absJoint.angularXDrive;
		JointDrive angularYZDrive = absJoint.angularYZDrive;
		angularXDrive.positionSpring = Mathf.Min((defaultAbsTensionX - absTensionPercentageTarget * defaultAbsTensionX) * (currentAbsTensionRestoreTimer / absTensionRestoreTimer) + absTensionPercentageTarget * defaultAbsTensionX, defaultAbsTensionX);
		angularYZDrive.positionSpring = Mathf.Min((defaultAbsTensionYZ - absTensionPercentageTarget * defaultAbsTensionYZ) * (currentAbsTensionRestoreTimer / absTensionRestoreTimer) + absTensionPercentageTarget * defaultAbsTensionYZ, defaultAbsTensionYZ);
		absJoint.angularXDrive = angularXDrive;
		absJoint.angularYZDrive = angularYZDrive;
		if (currentAbsTensionRestoreTimer >= absTensionRestoreTimer)
		{
			absNeedTightening = false;
		}
		currentAbsTensionRestoreTimer += Time.deltaTime;
	}

	public void TightenAbs(LooseAbsLock reason)
	{
		if (!absLocks.Contains(reason))
		{
			return;
		}
		absLocks.Remove(reason);
		if (absLocks.Count <= 0)
		{
			JointDrive angularXDrive = absJoint.angularXDrive;
			JointDrive angularYZDrive = absJoint.angularYZDrive;
			if (angularXDrive.positionSpring < defaultAbsTensionX || angularYZDrive.positionDamper < defaultAbsTensionYZ)
			{
				absNeedTightening = true;
				currentAbsTensionRestoreTimer = 0f;
			}
			absJoint.lowAngularXLimit = defaultAbsLimit;
		}
	}

	public void LoosenAbs(LooseAbsLock reason)
	{
		bool num = absLocks.Count > 0;
		if (!absLocks.Contains(reason))
		{
			absLocks.Add(reason);
		}
		if (!num)
		{
			absTensionPercentageTarget = minisculeAbsTension;
			JointDrive angularXDrive = absJoint.angularXDrive;
			JointDrive angularYZDrive = absJoint.angularYZDrive;
			angularXDrive.positionSpring = defaultAbsTensionX * minisculeAbsTension;
			angularYZDrive.positionSpring = defaultAbsTensionYZ * minisculeAbsTension;
			absJoint.angularXDrive = angularXDrive;
			absJoint.angularYZDrive = angularYZDrive;
			absJoint.lowAngularXLimit = loosenedAbsLimit;
			absNeedTightening = false;
		}
	}

	public int restoreGroupsCount()
	{
		return restoreGroups.Count;
	}

	public void OnLegStrengthUpdated()
	{
		updateLegStrength = true;
	}

	private void SetupLegPair(LegPair pair)
	{
		LegStructure legStructure = SetupLeg(pair.leftLeg);
		LegStructure legStructure2 = SetupLeg(pair.rightLeg);
		if (legStructure != null)
		{
			if (legStructure2 != null)
			{
				legStructure.parallelStructureIndex = allLegStructures.Count - 1;
			}
			else
			{
				legStructure.parallelStructureIndex = -1;
			}
		}
		if (legStructure2 != null)
		{
			if (legStructure != null)
			{
				legStructure2.parallelStructureIndex = allLegStructures.Count - 2;
			}
			else
			{
				legStructure2.parallelStructureIndex = -1;
			}
		}
	}

	private LegStructure SetupLeg(GameObject leg)
	{
		if (leg == null)
		{
			return null;
		}
		GameObject gameObject = leg.transform.parent.Find(footName).gameObject;
		GameObject gameObject2 = leg.transform.parent.GetChild(0).GetComponent<ConfigurableJoint>().connectedBody.gameObject;
		Stabilizer component = leg.GetComponent<Stabilizer>();
		component.SetLegController(this);
		component.SetBodySegment(gameObject2);
		Limb limb = leg.AddComponent<Limb>();
		limb.Initialize(this);
		LegStructure legStructure = new LegStructure(leg, gameObject, gameObject2, component, limb, leg.transform.parent.gameObject);
		leg.AddComponent<RotationRestore>().SetControllerRef(this);
		leg.GetComponent<Rigidbody>().mass = legWeight * base.transform.localScale.x;
		for (int i = 0; i < leg.transform.parent.childCount; i++)
		{
			Rigidbody component2 = leg.transform.parent.GetChild(i).GetComponent<Rigidbody>();
			if (!(component2 == null))
			{
				component2.maxAngularVelocity = maxLegAngularVelocity;
				component2.angularDrag = legAngularDrag;
			}
		}
		List<GameObject> list = new List<GameObject>();
		list.Add(leg);
		restoreGroups.Add(new RestoreGroup(list));
		UpdateSingleLegCollision(leg);
		int instanceID = gameObject2.GetInstanceID();
		allLegStructures.Add(legStructure);
		legToStructureMap[leg.GetInstanceID()] = allLegStructures.Count - 1;
		footToStructureMap[gameObject.GetInstanceID()] = allLegStructures.Count - 1;
		if (!bodyToStructuresMap.ContainsKey(instanceID))
		{
			bodyToStructuresMap[instanceID] = new List<int>();
		}
		bodyToStructuresMap[instanceID].Add(allLegStructures.Count - 1);
		component.Initialize();
		return legStructure;
	}

	private void InitializeWalkingGroups()
	{
		walkForwardGroups.Clear();
		List<GameObject> list = new List<GameObject>();
		List<GameObject> list2 = new List<GameObject>();
		for (int i = 0; i < legPairs.Count; i++)
		{
			int num;
			float x;
			if (legPairs[i].leftLeg != null)
			{
				num = 0;
				x = bodyFront.transform.InverseTransformPoint(legPairs[i].leftLeg.transform.position).x;
				for (int j = 0; j < list.Count; j++)
				{
					float x2 = bodyFront.transform.InverseTransformPoint(list[j].transform.position).x;
					if (x > x2)
					{
						break;
					}
					num++;
				}
				list.Insert(num, legPairs[i].leftLeg);
			}
			if (!(legPairs[i].rightLeg != null))
			{
				continue;
			}
			num = 0;
			x = bodyFront.transform.InverseTransformPoint(legPairs[i].rightLeg.transform.position).x;
			for (int k = 0; k < list2.Count; k++)
			{
				float x2 = bodyFront.transform.InverseTransformPoint(list2[k].transform.position).x;
				if (x > x2)
				{
					break;
				}
				num++;
			}
			list2.Insert(num, legPairs[i].rightLeg);
		}
		for (int l = 0; l < list.Count; l++)
		{
			WalkingGroup walkingGroup = new WalkingGroup();
			walkingGroup.legs = new List<GameObject>();
			walkingGroup.groundedRequirements = new List<GameObject>();
			walkingGroup.legs.Add(list[l]);
			walkingGroup.groundedRequirements.Add(list[l].transform.parent.GetChild(3).gameObject);
			walkingGroup.jiggleTorque = true;
			walkingGroup.multiplier = leftLegWalkModifier;
			if (l < list.Count / 2)
			{
				walkingGroup.offset = leftWalkStartOffset;
			}
			else
			{
				walkingGroup.offset = leftWalkEndOffset;
			}
			walkForwardGroups.Add(walkingGroup);
		}
		for (int m = 0; m < list2.Count; m++)
		{
			WalkingGroup walkingGroup2 = new WalkingGroup();
			walkingGroup2.legs = new List<GameObject>();
			walkingGroup2.groundedRequirements = new List<GameObject>();
			walkingGroup2.legs.Add(list2[m]);
			walkingGroup2.groundedRequirements.Add(list2[m].transform.parent.GetChild(3).gameObject);
			walkingGroup2.jiggleTorque = true;
			walkingGroup2.multiplier = rightLegWalkModifier;
			if (m < list2.Count / 2)
			{
				walkingGroup2.offset = rightWalkStartOffset;
			}
			else
			{
				walkingGroup2.offset = rightWalkEndOffset;
			}
			walkForwardGroups.Add(walkingGroup2);
		}
	}

	private void UpdateSingleLegCollision(GameObject leg)
	{
		if (collisionHelperFront != null)
		{
			Physics.IgnoreCollision(leg.transform.parent.GetChild(0).GetComponent<Collider>(), collisionHelperFront.GetComponent<Collider>());
			Physics.IgnoreCollision(leg.transform.parent.GetChild(0).GetComponent<Collider>(), collisionHelperBack.GetComponent<Collider>());
		}
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			for (int j = 0; j < leg.transform.parent.childCount; j++)
			{
				for (int k = 0; k < allLegStructures[i].leg.transform.parent.childCount; k++)
				{
					Physics.IgnoreCollision(leg.transform.parent.GetChild(j).GetComponent<Collider>(), allLegStructures[i].leg.transform.parent.GetChild(k).GetComponent<Collider>());
				}
			}
		}
	}

	private void UpdateCenterOfMass()
	{
		Vector3 inertiaTensor = bodyBack.GetComponent<Rigidbody>().inertiaTensor;
		Quaternion inertiaTensorRotation = bodyBack.GetComponent<Rigidbody>().inertiaTensorRotation;
		Vector3 inertiaTensor2 = bodyFront.GetComponent<Rigidbody>().inertiaTensor;
		Quaternion inertiaTensorRotation2 = bodyFront.GetComponent<Rigidbody>().inertiaTensorRotation;
		Vector3 centerOfMass = bodyBack.GetComponent<Rigidbody>().centerOfMass + bodyBackCenterOfMassOffset;
		Vector3 centerOfMass2 = bodyFront.GetComponent<Rigidbody>().centerOfMass + bodyFrontCenterOfMassOffset;
		if (collisionHelperFront != null)
		{
			collisionHelperBack.SetActive(value: true);
			collisionHelperFront.SetActive(value: true);
			collisionHelperBackBody.SetActive(value: true);
			collisionHelperFrontBody.SetActive(value: true);
		}
		bodyBack.GetComponent<Rigidbody>().centerOfMass = centerOfMass;
		bodyFront.GetComponent<Rigidbody>().centerOfMass = centerOfMass2;
		bodyBack.GetComponent<Rigidbody>().inertiaTensor = inertiaTensor;
		bodyBack.GetComponent<Rigidbody>().inertiaTensorRotation = inertiaTensorRotation;
		bodyFront.GetComponent<Rigidbody>().inertiaTensor = inertiaTensor2;
		bodyFront.GetComponent<Rigidbody>().inertiaTensorRotation = inertiaTensorRotation2;
		dogRegRef.UpdateDogCollision(base.gameObject);
	}

	private void TryToStandIfNeeded()
	{
		if (!aiRef.IsValidRotation() && GetCachedRigidbody(bodyFront).velocity.magnitude < unmovingVelocity && !AnyLegGrounded())
		{
			needsStandupTimerCurrent += Time.deltaTime;
		}
		else
		{
			needsStandupTimerCurrent = 0f;
		}
		if (needsStandupTimerCurrent >= standUpTimer)
		{
			needsStandupTimerCurrent /= 2f;
			if (Random.value >= 0.9f)
			{
				buckRef.RequestBuck();
			}
			for (int i = 0; i < restoreGroups.Count; i++)
			{
				restoreGroups[i].AllowRestorationOverride(Random.Range(0.25f, 0.5f));
			}
		}
	}

	private void UpdateLegCompensation()
	{
		float maxCompensation = Limb.GetMaxCompensation();
		rawStrengthDict.Clear();
		compensationList.Clear();
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			compensationList.Add(0f);
		}
		int num = 0;
		for (int j = 0; j < allLegStructures.Count; j++)
		{
			float rawStrength = GetRawStrength(j);
			if (rawStrength == 1f)
			{
				continue;
			}
			num = 0;
			for (int k = 0; k < allLegStructures.Count; k++)
			{
				if (k != j && GetRawStrength(k) > rawStrength)
				{
					num++;
				}
			}
			float num2 = (1f - rawStrength) * maxCompensation / (float)num;
			for (int l = 0; l < allLegStructures.Count; l++)
			{
				if (l != j && GetRawStrength(l) > rawStrength)
				{
					compensationList[l] = Mathf.Min(compensationList[l] + num2, maxCompensation);
				}
			}
		}
		for (int m = 0; m < allLegStructures.Count; m++)
		{
			allLegStructures[m].limb.UpdateLimbCompensation(compensationList[m]);
		}
	}

	private float GetRawStrength(int index)
	{
		if (!rawStrengthDict.ContainsKey(index))
		{
			rawStrengthDict[index] = allLegStructures[index].limb.GetRawLimbStrength();
		}
		return rawStrengthDict[index];
	}

	public void StartSimulatedWalk()
	{
		isWalking = true;
	}

	public void StopSimulatedWalk()
	{
		isWalking = false;
	}

	private void UpdateSimulatedInput()
	{
		if (!(inputSim == null))
		{
			if (simulatedKeyPresses.Count > 0)
			{
				simulatedKeyPresses.Clear();
			}
			if (inputSim.HasSimulatedInput())
			{
				simulatedKeyPresses.AddRange(inputSim.GetSimulatedInput());
			}
		}
	}

	public void SetRestoreMod(Vector3 mod)
	{
		if (defaultRestoreMod != Vector3.one)
		{
			Debug.LogError(string.Concat("Restore mod already set to: ", defaultRestoreMod, ". Combining values is not supported at this time."));
		}
		else
		{
			defaultRestoreMod = mod;
		}
	}

	public void ClearRestoreMod()
	{
		defaultRestoreMod = Vector3.one;
	}

	private bool KeyDown(KeyCode key)
	{
		if (!Input.GetKey(key))
		{
			return simulatedKeyPresses.Contains(key);
		}
		return true;
	}

	public bool IsWalking()
	{
		return isWalking;
	}

	private void HandleInput()
	{
		if (isWalking)
		{
			walkControllerRef.UpdateWalk();
			return;
		}
		walkControllerRef.ResetLimbsAngularDrag();
		RestoreRotation(defaultRestoreMod);
		Stabilize();
	}

	public void MoveLegGroup(LegGroup group)
	{
		group.CheckRequirements();
		MoveLegs(group.legs, group.EvaluationRotation());
		group.AddActiveTime(Time.fixedDeltaTime);
	}

	public bool IsLegGroupMovingUp(LegGroup groupRef)
	{
		return groupRef.IsMovingUp();
	}

	public void MoveBodyGroup(BodyGroup group)
	{
		group.CheckRequirements();
		MoveBodies(group.legs, group.EvaluationRotation());
		group.AddActiveTime(Time.fixedDeltaTime);
	}

	private void MoveLegs(List<GameObject> legs, Vector3 torque)
	{
		for (int i = 0; i < legs.Count; i++)
		{
			TorqueLeg(legs[i], torque);
		}
	}

	private void MoveBodies(List<GameObject> legs, Vector3 torque)
	{
		for (int i = 0; i < legs.Count; i++)
		{
			TorqueBody(legs[i], torque);
		}
	}

	public void RestoreRotation(Vector3 modifier)
	{
		for (int i = 0; i < restoreGroups.Count; i++)
		{
			restoreGroups[i].RestoreLegs(modifier);
		}
	}

	public void StabilizeBody(GameObject body, float xDiffAngle = 35f, float dampingMultiplier = 300f)
	{
		if (!IsOffBalance(body, xDiffAngle))
		{
			Vector3 zero = Vector3.zero;
			Vector3 eulerAngles = body.transform.rotation.eulerAngles;
			float x = 1f;
			float y = 0f;
			float z = 0f;
			Vector3 torqueForTargetAngle = PhysicalAnimationUtil.GetTorqueForTargetAngle(eulerAngles, zero, new Vector3(x, y, z), dampingMultiplier);
			TorqueBody(body, torqueForTargetAngle, applyLimbCompensation: true, modifyLegStrength: false, useTorqueDamping: false, rawTorque: false, useFuckedUpTorqueDamping: false, dampX: false);
		}
	}

	private bool IsOffBalance(GameObject body, float xDiffAngle = 35f)
	{
		if (AngleUtil.GetAngleDiff(0f, body.transform.rotation.eulerAngles.x) > xDiffAngle)
		{
			return true;
		}
		return false;
	}

	public void TorqueBodyTowardsPoint(GameObject body, Vector3 point, float dampingMultiplier = 300f)
	{
		if (!IsOffBalance(body))
		{
			float yFacingAngle = AngleUtil.GetYFacingAngle(point, body.transform);
			Vector3 eulerAngles = body.transform.rotation.eulerAngles;
			if (!(AngleUtil.GetAngleDiff(yFacingAngle, eulerAngles.y) > 45f))
			{
				Vector3 torque = PhysicalAnimationUtil.GetTorqueForTargetAngle(targetRot: new Vector3(eulerAngles.x, yFacingAngle, eulerAngles.z), currentRot: eulerAngles, restoreSpeed: new Vector3(0f, 1f, 0f), dampingMultiplier: dampingMultiplier);
				TorqueBody(body, torque, applyLimbCompensation: true, modifyLegStrength: false, useTorqueDamping: false, rawTorque: false, useFuckedUpTorqueDamping: false, dampX: false);
			}
		}
	}

	public void Stabilize()
	{
		if (stabilityStepsAllowed)
		{
			for (int i = 0; i < allLegStructures.Count; i++)
			{
				allLegStructures[i].stabilizer.FixedUpdateStabilize(xStepsLocked, zStepsLocked);
			}
		}
	}

	public float GetLimbStrength(GameObject obj, bool applyLimbCompensation = true)
	{
		if (obj == null)
		{
			return 0f;
		}
		return allLegStructures[legToStructureMap[obj.GetInstanceID()]].limb.GetLimbStrength(applyLimbCompensation);
	}

	public float GetBodyStrength(GameObject obj, bool applyLimbCompensation = true)
	{
		int instanceID = obj.GetInstanceID();
		if (footToStructureMap.ContainsKey(instanceID))
		{
			GameObject leg = allLegStructures[footToStructureMap[instanceID]].leg;
			return GetLimbStrength(leg, applyLimbCompensation) + GetLimbStrength(GetParallelLeg(leg), applyLimbCompensation);
		}
		if (bodyToStructuresMap.ContainsKey(instanceID))
		{
			float num = 0f;
			for (int i = 0; i < bodyToStructuresMap[instanceID].Count; i++)
			{
				num += GetLimbStrength(allLegStructures[bodyToStructuresMap[instanceID][i]].leg, applyLimbCompensation);
			}
			return num;
		}
		return 1f;
	}

	private Limb GetCachedLimbForLeg(GameObject leg)
	{
		return allLegStructures[legToStructureMap[leg.GetInstanceID()]].limb;
	}

	private Rigidbody GetCachedRigidbody(GameObject obj)
	{
		return rbCache[obj.GetInstanceID()];
	}

	public void TorqueLeg(GameObject leg, Vector3 torque, bool applyLimbCompensation = true, bool modifyLegStrength = true, bool restoreTension = true, bool rawTorque = false, bool useTorqueDamping = true, bool useFuckedUpTorqueDamping = false, bool dampX = true, bool dampY = true, bool dampZ = true)
	{
		Limb cachedLimbForLeg = GetCachedLimbForLeg(leg);
		Rigidbody cachedRigidbody = GetCachedRigidbody(leg);
		GameObject bodySegmentForLeg = GetBodySegmentForLeg(leg);
		if (rawTorque)
		{
			if (bodySegmentForLeg == bodyFront)
			{
				AddCalculatedTorque(cachedRigidbody, torque, frontLeg: true);
			}
			else if (bodySegmentForLeg == bodyBack)
			{
				AddCalculatedTorque(cachedRigidbody, torque, frontLeg: false, backleg: true);
			}
			else
			{
				AddCalculatedTorque(cachedRigidbody, torque);
			}
			return;
		}
		torque *= GetLimbStrength(leg, applyLimbCompensation);
		if (modifyLegStrength)
		{
			cachedLimbForLeg.OnTorqueExherted(torque);
		}
		if (restoreTension)
		{
			cachedLimbForLeg.OnLimbMovement();
		}
		if (useTorqueDamping)
		{
			torque = cachedLimbForLeg.ModifyTorqueFromJointLimits(torque, useFuckedUpTorqueDamping, dampX, dampY, dampZ);
		}
		if (bodySegmentForLeg == bodyFront)
		{
			AddCalculatedTorque(cachedRigidbody, torque, frontLeg: true);
		}
		else if (bodySegmentForLeg == bodyBack)
		{
			AddCalculatedTorque(cachedRigidbody, torque, frontLeg: false, backleg: true);
		}
		else
		{
			AddCalculatedTorque(cachedRigidbody, torque);
		}
	}

	public void TorqueBody(GameObject body, Vector3 torque, bool applyLimbCompensation = true, bool modifyLegStrength = true, bool useTorqueDamping = true, bool rawTorque = false, bool useFuckedUpTorqueDamping = false, bool dampX = true, bool dampY = true, bool dampZ = true)
	{
		Rigidbody cachedRigidbody = GetCachedRigidbody(body);
		if (rawTorque)
		{
			AddCalculatedTorque(cachedRigidbody, torque);
			return;
		}
		if (body == bodyFront)
		{
			bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_LEFT_LEG, log: false);
			bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_RIGHT_LEG, log: false);
			if (domRecPropertyStatus && domRecPropertyStatus2)
			{
				torque *= 0.5f;
			}
			else if (domRecPropertyStatus || domRecPropertyStatus2)
			{
				torque *= 0.75f;
			}
		}
		else if (body == bodyBack)
		{
			bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_LEFT_LEG, log: false);
			bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_RIGHT_LEG, log: false);
			if (domRecPropertyStatus3 && domRecPropertyStatus4)
			{
				torque *= 0.5f;
			}
			else if (domRecPropertyStatus3 || domRecPropertyStatus4)
			{
				torque *= 0.75f;
			}
		}
		reusableLimbList.Clear();
		int instanceID = body.GetInstanceID();
		if (footToStructureMap.ContainsKey(instanceID))
		{
			reusableLimbList.Add(allLegStructures[footToStructureMap[instanceID]].limb);
			GameObject parallelLeg = GetParallelLeg(allLegStructures[footToStructureMap[instanceID]].leg);
			if (parallelLeg != null)
			{
				reusableLimbList.Add(allLegStructures[legToStructureMap[parallelLeg.GetInstanceID()]].limb);
			}
		}
		else
		{
			if (!bodyToStructuresMap.ContainsKey(instanceID))
			{
				AddCalculatedTorque(cachedRigidbody, torque);
				return;
			}
			for (int i = 0; i < bodyToStructuresMap[instanceID].Count; i++)
			{
				reusableLimbList.Add(allLegStructures[bodyToStructuresMap[instanceID][i]].limb);
			}
		}
		float num = GetBodyStrength(body, applyLimbCompensation);
		if (num != 0f)
		{
			num += 2f;
			num /= 4f;
		}
		torque *= num;
		if (modifyLegStrength)
		{
			for (int j = 0; j < reusableLimbList.Count; j++)
			{
				reusableLimbList[j].OnTorqueExherted(torque / 4f);
			}
		}
		if (useTorqueDamping && reusableLimbList.Count > 0)
		{
			Vector3 torqueVector = torque;
			torque = Vector3.zero;
			for (int k = 0; k < reusableLimbList.Count; k++)
			{
				torque += reusableLimbList[k].ModifyTorqueFromJointLimits(torqueVector, useFuckedUpTorqueDamping, dampX, dampY, dampZ);
			}
			torque /= (float)reusableLimbList.Count;
		}
		AddCalculatedTorque(cachedRigidbody, torque);
	}

	public void AddCalculatedTorque(Rigidbody body, Vector3 finalTorque, bool frontLeg = false, bool backleg = false)
	{
		if (Time.fixedTime <= lastTorqueCall)
		{
			Debug.LogError("Something went wrong! Something is trying to add torques after we've already applied them this fixedUpdate!");
		}
		else if (frontLeg)
		{
			torqueMap[body.GetInstanceID()] += finalTorque * GetGirthAndScaleMod(frontLeg: true);
		}
		else if (backleg)
		{
			torqueMap[body.GetInstanceID()] += finalTorque * GetGirthAndScaleMod(frontLeg: false);
		}
		else
		{
			torqueMap[body.GetInstanceID()] += finalTorque * scaleMod;
		}
	}

	private void ApplyTorques()
	{
		for (int i = 0; i < torqueKeys.Count; i++)
		{
			Vector3 vector = torqueMap[torqueKeys[i].GetInstanceID()];
			if (vector != Vector3.zero)
			{
				torqueKeys[i].AddRelativeTorque(vector * GlobalProperties.gravMod);
				torqueMap[torqueKeys[i].GetInstanceID()] = Vector3.zero;
			}
		}
		lastTorqueCall = Time.fixedTime;
	}
}
