using System.Collections;
using System.Collections.Generic;
using HighlightingSystem;
using UnityEngine;

public class WingController : MonoBehaviour
{
	public enum WingState
	{
		TUCKED = 0,
		EXTENDED = 1,
		FLAP = 2,
		FLUTTER = 3,
		INTIMIDATE = 4,
		LOCKED = 5
	}

	public ConfigurableJoint jointDrive;

	public GameObject segmentToIgnoreBack;

	public Transform scaleTransform;

	public WingState currentWingState;

	public Vector3 tuckAdjust = Vector3.zero;

	private TailStateStruct flutterRequirements;

	private bool isLeftWing = true;

	private float totalWingCount = 1f;

	private Vector3 tuckedRotLeft = new Vector3(329.2f, 37.4f, 258.2f);

	private Vector3 tuckedRotRight = new Vector3(30.8f, 322.6f, 258.2f);

	private Quaternion flapDownRotLeft = new Quaternion(-0.16f, -0.45f, -0.2f, 0.641f);

	private Quaternion flapDownRotRight = new Quaternion(0.16f, 0.45f, -0.2f, 0.641f);

	private float flapDrag = 25f;

	private float flapForce = 1250f;

	private float flutterMultiplier = 0.35f;

	private Rigidbody bodyFrontRB;

	private PhysicsScene dogSpawningPhysics;

	private float dogSpawningPhysicsTimer;

	private Dictionary<GameObject, float> initialSegmentPositions = new Dictionary<GameObject, float>();

	private List<GameObject> segmentKeys = new List<GameObject>();

	private float positionTolerance = 2f;

	private bool isDead;

	private float wingIndexTimeExtension = 0.05f;

	private float tuckTime = 0.5f;

	private float currentTuckTime;

	private Quaternion tuckStartRot;

	private float extendTime = 0.15f;

	private float currentExtendTime;

	private Quaternion extendStartRot;

	private bool downCycle;

	private float flapDownTime = 0.25f;

	private bool _flyForwardConstant;

	private bool _flyForwardPeriodic;

	private bool currentlyFlyingForward;

	private float periodicForwardTimeCurrent;

	private float periodicForwardTimeMax = 0.25f;

	private float periodicForwardTimeMin = 0.1f;

	private bool turnLeft;

	private bool turnRight;

	private float randomForwardChance = 0.15f;

	private float periodicForwardChance = 0.35f;

	private Coroutine currentFlapRoutine;

	private FlyBehavior flyRef;

	private DoggyBrain brainRef;

	private MouthController mouthRef;

	private LegController controllerRef;

	private Transform FindRoot()
	{
		Transform parent = base.transform;
		while (!parent.CompareTag("dog"))
		{
			parent = parent.parent;
		}
		return parent;
	}

	private void Awake()
	{
		InitializeWingStates();
	}

	private void InitializeWingStates()
	{
		flutterRequirements = default(TailStateStruct);
		flutterRequirements.requireAll = true;
		flutterRequirements.minAnger = DoggyBrain.minAngerForBigHappiness;
		flutterRequirements.maxAnger = DoggyBrain.maxAngerForHappiness;
		flutterRequirements.minEnergy = DoggyBrain.minEnergyForBigHappiness;
		flutterRequirements.maxEnergy = DoggyBrain.maxEnergyForHappiness;
		flutterRequirements.minHunger = DoggyBrain.minHungerForBigHappiness;
		flutterRequirements.maxHunger = DoggyBrain.maxHungerForHappiness;
		flutterRequirements.minStress = DoggyBrain.minStressForBigHappiness;
		flutterRequirements.maxStress = DoggyBrain.maxStressForHappiness;
		flutterRequirements.minBoredom = DoggyBrain.minBoredomForBigHappiness;
		flutterRequirements.maxBoredom = DoggyBrain.maxBoredomForHappiness;
	}

	private void Start()
	{
		Transform transform = FindRoot();
		brainRef = transform.GetComponent<DoggyBrain>();
		mouthRef = transform.GetComponent<MouthController>();
		controllerRef = transform.GetComponent<LegController>();
		bodyFrontRB = controllerRef.bodyFront.GetComponent<Rigidbody>();
		Collider component = controllerRef.bodyBack.GetComponent<Collider>();
		Collider component2 = controllerRef.bodyFront.GetComponent<Collider>();
		Physics.IgnoreCollision(segmentToIgnoreBack.GetComponent<Collider>(), component);
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Physics.IgnoreCollision(collider, component);
			Physics.IgnoreCollision(collider, component2);
		}
		SetUpWingChainPositions();
		jointDrive.connectedBody = controllerRef.bodyFront.GetComponent<Rigidbody>();
		SetWingState(WingState.TUCKED, force: true);
	}

	private void Update()
	{
		if (isDead || !brainRef.isInitialized() || currentWingState == WingState.LOCKED)
		{
			return;
		}
		if (currentWingState != WingState.FLAP)
		{
			if (brainRef.IsSleeping())
			{
				SetWingState(WingState.TUCKED);
			}
			else if (brainRef.IsAngry())
			{
				SetWingState(WingState.INTIMIDATE);
			}
			else if (brainRef.IsStressed())
			{
				SetWingState(WingState.TUCKED);
			}
			else if (flutterRequirements.StateValid(brainRef))
			{
				SetWingState(WingState.FLUTTER);
			}
			else
			{
				SetWingState(WingState.TUCKED);
			}
		}
		ManualPhysicsUpdate();
	}

	private void FixedUpdate()
	{
		ManualFixedUpdate();
	}

	private void ManualPhysicsUpdate()
	{
		if (!brainRef.GetIsDisplayDog())
		{
			return;
		}
		_ = dogSpawningPhysics;
		dogSpawningPhysicsTimer += Time.unscaledDeltaTime;
		_ = dogSpawningPhysics;
		if (dogSpawningPhysics.IsValid())
		{
			while (dogSpawningPhysicsTimer >= Time.fixedDeltaTime)
			{
				ManualFixedUpdate();
				dogSpawningPhysicsTimer -= Time.fixedDeltaTime;
			}
		}
	}

	private void ManualFixedUpdate()
	{
		if (!isDead && currentWingState != WingState.LOCKED)
		{
			AnimateWing();
		}
		CheckWingPositions();
	}

	public void SetFlyRef(FlyBehavior newRef)
	{
		flyRef = newRef;
	}

	public void SetIsLeftWing(bool val)
	{
		isLeftWing = val;
	}

	public void SetTotalWingCount(float val, float index)
	{
		totalWingCount = val;
		tuckTime += index * wingIndexTimeExtension;
		extendTime += index * wingIndexTimeExtension;
		flapDownTime += index * wingIndexTimeExtension;
	}

	public void OnDie(InventoryItem wingItem, float force, Vector3 dogCenter, float radius, float upwardsMod, List<GameObject> dogParts, List<GutFloraResource> additionalFlora, List<GutFloraResource> additionalFloraBoosted, GameObject deathParticles = null)
	{
		SetWingState(WingState.LOCKED, force: true);
		GameObject gameObject = new GameObject("Dog Wing");
		if (deathParticles != null)
		{
			Object.Instantiate(deathParticles, jointDrive.connectedBody.transform.TransformPoint(jointDrive.connectedAnchor), Quaternion.identity);
		}
		segmentKeys.Remove(jointDrive.gameObject);
		initialSegmentPositions.Remove(jointDrive.gameObject);
		Object.Destroy(jointDrive);
		base.transform.SetParent(gameObject.transform);
		ObjectUtil.ConvertObjectToFood(gameObject, wingItem, GetComponentInChildren<SkinnedMeshRenderer>().material.color, canSaveLoad: false, null, additionalFlora, additionalFloraBoosted);
		dogParts.Add(gameObject);
		Rigidbody[] componentsInChildren = gameObject.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj in componentsInChildren)
		{
			obj.mass *= 10f;
			obj.AddExplosionForce(force, dogCenter, radius, upwardsMod);
		}
		Highlighter[] componentsInChildren2 = gameObject.GetComponentsInChildren<Highlighter>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			componentsInChildren2[i].ConstantOffImmediate();
		}
		isDead = true;
	}

	private WingState GetWingState()
	{
		return currentWingState;
	}

	public void SetUpWingChainPositions()
	{
		segmentKeys.Clear();
		initialSegmentPositions.Clear();
		ConfigurableJoint[] componentsInChildren = jointDrive.gameObject.GetComponentsInChildren<ConfigurableJoint>();
		foreach (ConfigurableJoint obj in componentsInChildren)
		{
			GameObject gameObject = obj.gameObject;
			GameObject gameObject2 = obj.connectedBody.gameObject;
			initialSegmentPositions[gameObject] = Vector3.Distance(gameObject.transform.position, gameObject2.transform.position);
			segmentKeys.Add(gameObject);
		}
	}

	private void CheckWingPositions()
	{
		for (int i = 0; i < segmentKeys.Count; i++)
		{
			GameObject gameObject = segmentKeys[i].GetComponent<Joint>().connectedBody.gameObject;
			if (Vector3.Distance(gameObject.transform.position, segmentKeys[i].transform.position) > initialSegmentPositions[segmentKeys[i]] + positionTolerance)
			{
				segmentKeys[i].transform.position = gameObject.transform.position;
			}
		}
	}

	public void SetWingState(WingState newState, bool force = false, bool flyForwardConstant = false, bool flyForwardPeriodic = false, bool right = false, bool left = false)
	{
		currentlyFlyingForward = false;
		turnLeft = left;
		turnRight = right;
		_flyForwardConstant = flyForwardConstant;
		_flyForwardPeriodic = flyForwardPeriodic;
		periodicForwardTimeCurrent = 0f;
		if (force || (newState != currentWingState && !isDead))
		{
			bodyFrontRB.angularDrag = 0f;
			if (currentFlapRoutine != null)
			{
				StopCoroutine(currentFlapRoutine);
				currentFlapRoutine = null;
			}
			currentWingState = newState;
			switch (newState)
			{
			case WingState.TUCKED:
				StartTuck();
				break;
			case WingState.EXTENDED:
				StartExtend();
				break;
			case WingState.INTIMIDATE:
				StartIntimidate();
				break;
			case WingState.FLAP:
				StartFlap();
				break;
			case WingState.FLUTTER:
				StartFlutter();
				break;
			case WingState.LOCKED:
				StartLock();
				break;
			}
		}
	}

	private void StartLock()
	{
		currentTuckTime = tuckTime - 0.01f;
		AnimateTuck();
	}

	private void StartTuck()
	{
		currentTuckTime = 0f;
		tuckStartRot = jointDrive.targetRotation;
	}

	private void StartExtend()
	{
		currentExtendTime = 0f;
		extendStartRot = jointDrive.targetRotation;
	}

	private void StartIntimidate()
	{
		currentExtendTime = 0f;
		extendStartRot = Quaternion.Euler(tuckedRotLeft + tuckAdjust);
		if (!isLeftWing)
		{
			extendStartRot = Quaternion.Euler(tuckedRotRight - tuckAdjust);
		}
	}

	private void StartFlap()
	{
		if (currentFlapRoutine != null)
		{
			StopCoroutine(currentFlapRoutine);
		}
		currentFlapRoutine = StartCoroutine(FlapRoutine());
	}

	private void StartFlutter()
	{
		if (currentFlapRoutine != null)
		{
			StopCoroutine(currentFlapRoutine);
		}
		currentFlapRoutine = StartCoroutine(FlapRoutine(flutter: true));
	}

	private void AnimateWing()
	{
		switch (currentWingState)
		{
		case WingState.TUCKED:
			AnimateTuck();
			break;
		case WingState.EXTENDED:
			AnimateExtend();
			break;
		case WingState.INTIMIDATE:
			AnimateIntimidate();
			break;
		case WingState.FLAP:
		case WingState.FLUTTER:
			break;
		}
	}

	private void AnimateTuck()
	{
		if (!(currentTuckTime >= tuckTime))
		{
			currentTuckTime += Time.fixedDeltaTime;
			if (currentTuckTime > tuckTime)
			{
				currentTuckTime = tuckTime;
			}
			Quaternion b = Quaternion.Euler(tuckedRotLeft + tuckAdjust);
			if (!isLeftWing)
			{
				b = Quaternion.Euler(tuckedRotRight - tuckAdjust);
			}
			jointDrive.targetRotation = Quaternion.Slerp(tuckStartRot, b, Inchworm.GetSinusoidalValue(currentTuckTime / tuckTime, 0f, -1f, 1f));
		}
	}

	private void AnimateExtend()
	{
		if (!(currentExtendTime >= extendTime))
		{
			currentExtendTime += Time.fixedDeltaTime;
			if (currentExtendTime > extendTime)
			{
				currentExtendTime = extendTime;
			}
			Quaternion identity = Quaternion.identity;
			jointDrive.targetRotation = Quaternion.Slerp(extendStartRot, identity, Inchworm.GetSinusoidalValue(currentExtendTime / extendTime, 0f, -1f, 1f));
		}
	}

	private void AnimateIntimidate()
	{
		if (currentExtendTime >= extendTime)
		{
			currentExtendTime = extendTime - 0.15f;
		}
		currentExtendTime += Time.fixedDeltaTime;
		float num = Mathf.Clamp(currentExtendTime, 0f, extendTime);
		Quaternion identity = Quaternion.identity;
		jointDrive.targetRotation = Quaternion.Slerp(extendStartRot, identity, Inchworm.GetSinusoidalValue(num / extendTime, 0f, -1f, 1f));
	}

	private IEnumerator FlapRoutine(bool flutter = false)
	{
		downCycle = false;
		bodyFrontRB.angularDrag = flapDrag;
		WaitForFixedUpdate fixedWait = new WaitForFixedUpdate();
		WaitForSecondsRealtime fakeFixedWait = new WaitForSecondsRealtime(Time.fixedDeltaTime);
		StartExtend();
		float currentTimer;
		for (currentTimer = 0f; currentTimer < extendTime; currentTimer += Time.fixedDeltaTime)
		{
			AnimateExtend();
			if (brainRef.GetIsDisplayDog())
			{
				yield return fakeFixedWait;
			}
			else
			{
				yield return fixedWait;
			}
		}
		if (brainRef.GetIsDisplayDog())
		{
			yield return new WaitForSecondsRealtime(0.15f);
		}
		else
		{
			yield return new WaitForSeconds(0.15f);
		}
		downCycle = true;
		currentTimer = 0f;
		Quaternion flapStartRot = jointDrive.targetRotation;
		while (true)
		{
			if (downCycle && currentTimer >= flapDownTime)
			{
				downCycle = false;
				currentTimer = 0f;
				flyRef.GenerateNextFlapUpTime(flutter);
				flapStartRot = jointDrive.targetRotation;
			}
			else if (!downCycle && currentTimer >= flyRef.GetFlapUpTime() + flyRef.GetFlapWaitTime())
			{
				downCycle = true;
				currentTimer = 0f;
				flapStartRot = jointDrive.targetRotation;
			}
			currentTimer += Time.fixedDeltaTime;
			if (downCycle)
			{
				AnimateFlapDown(currentTimer, flapStartRot, flutter);
			}
			else
			{
				AnimateFlapUp(currentTimer, flapStartRot);
			}
			if (brainRef.GetIsDisplayDog())
			{
				yield return fakeFixedWait;
			}
			else
			{
				yield return fixedWait;
			}
		}
	}

	private void AnimateFlapDown(float timer, Quaternion flapStartRot, bool flutter = false)
	{
		if (timer >= flapDownTime)
		{
			timer = flapDownTime;
		}
		Quaternion b = flapDownRotLeft;
		if (!isLeftWing)
		{
			b = flapDownRotRight;
		}
		jointDrive.targetRotation = Quaternion.Slerp(flapStartRot, b, Inchworm.GetSinusoidalValue(timer / flapDownTime, 0f, -1f, 1f));
		if (!(timer <= flapDownTime - flapDownTime / 6f))
		{
			return;
		}
		float num = flapForce;
		if (flutter)
		{
			num *= flutterMultiplier;
		}
		float carriedWeight = mouthRef.GetCarriedWeight();
		float num2 = 1f / totalWingCount;
		Vector3 up = Vector3.up;
		if (_flyForwardPeriodic && periodicForwardTimeCurrent <= 0f)
		{
			currentlyFlyingForward = Random.value < periodicForwardChance;
			periodicForwardTimeCurrent = Random.Range(periodicForwardTimeMin, periodicForwardTimeMax);
		}
		if (turnRight || turnLeft)
		{
			float num3 = 1f;
			if (turnRight)
			{
				num3 = -1f;
			}
			bodyFrontRB.AddRelativeTorque(num * controllerRef.GetWeightPercentage(carriedWeight) * num2 * bodyFrontRB.transform.forward * num3);
		}
		if ((_flyForwardConstant || currentlyFlyingForward) && Random.value < randomForwardChance)
		{
			up -= bodyFrontRB.transform.right;
		}
		bodyFrontRB.AddForceAtPosition(num * controllerRef.GetWeightPercentage(carriedWeight) * num2 * up, jointDrive.transform.position);
	}

	private void AnimateFlapUp(float timer, Quaternion flapStartRot)
	{
		float num = flyRef.GetFlapUpTime() + flyRef.GetFlapWaitTime();
		if (timer > num)
		{
			timer = num;
		}
		if (timer < flyRef.GetFlapWaitTime())
		{
			currentTuckTime = tuckTime - 0.01f;
			AnimateTuck();
		}
		else
		{
			Quaternion identity = Quaternion.identity;
			jointDrive.targetRotation = Quaternion.Slerp(flapStartRot, identity, Inchworm.GetSinusoidalValue(timer / num, 0f, -1f, 1f));
		}
	}
}
