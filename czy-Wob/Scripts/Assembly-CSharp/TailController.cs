using System.Collections.Generic;
using HighlightingSystem;
using UnityEngine;

public class TailController : MonoBehaviour
{
	public enum TailState
	{
		NEUTRAL = 0,
		WAGGING = 1,
		TUCKED = 2
	}

	public GameObject tailDrive;

	public GameObject segmentToIgnoreBack;

	public Transform scaleTransform;

	public TailState currentTailState;

	private bool tailStateOverrideActive;

	private TailState tailStateOverride;

	private float wagoutTimer;

	private float wagoutTimerMax = 1f;

	private float wagDriveHorizontalMod = 37f;

	private float wagDriveHorizontalModMin;

	private float wagDriveHorizontalModMax = 200f;

	private float wagHorizontalAngle = 45f;

	private float wagAngleTolerance = 25f;

	private float wagVertAngle = -45f;

	private TailStateStruct wagRequirements;

	private float wagDriveHorizontal = 100f;

	private float wagDriveVertical = 10000f;

	private JointDrive wagDriveX;

	private JointDrive wagDriveYZ;

	private PhysicsScene dogSpawningPhysics;

	private float dogSpawningPhysicsTimer;

	private float tuckedVertAngle = 45f;

	private TailStateStruct tuckedRequirements;

	private ConfigurableJoint baseJoint;

	private JointDrive originalDriveX;

	private JointDrive originalDriveYZ;

	private Dictionary<GameObject, float> initialSegmentPositions = new Dictionary<GameObject, float>();

	private List<GameObject> segmentKeys = new List<GameObject>();

	private float positionTolerance = 2f;

	private bool isDead;

	private DoggyBrain brainRef;

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

	private void Start()
	{
		Transform transform = FindRoot();
		brainRef = transform.GetComponent<DoggyBrain>();
		controllerRef = transform.GetComponent<LegController>();
		Collider component = controllerRef.bodyBack.GetComponent<Collider>();
		Collider[] components = segmentToIgnoreBack.GetComponents<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			Physics.IgnoreCollision(components[i], component);
		}
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			if (!(rigidbody.transform == segmentToIgnoreBack.transform) && !(rigidbody.GetComponent<Collider>() == null) && rigidbody.GetComponent<Collider>().bounds.Intersects(component.bounds))
			{
				Physics.IgnoreCollision(rigidbody.GetComponent<Collider>(), component);
			}
		}
		SetUpTailChainPositions();
		InitializeTailStates();
		baseJoint = tailDrive.GetComponent<ConfigurableJoint>();
		baseJoint.connectedBody = controllerRef.bodyBack.GetComponent<Rigidbody>();
		originalDriveX = baseJoint.angularXDrive;
		originalDriveYZ = baseJoint.angularYZDrive;
		UpdateWagDrive();
		wagVertAngle = Mathf.Max(wagVertAngle, tailDrive.GetComponent<ConfigurableJoint>().lowAngularXLimit.limit);
		wagHorizontalAngle = Mathf.Min(wagHorizontalAngle, baseJoint.angularYLimit.limit);
	}

	private void Update()
	{
		if (!isDead && brainRef.isInitialized())
		{
			if (wagDriveHorizontalMod != wagDriveHorizontal)
			{
				UpdateWagDrive();
			}
			if (!tailStateOverrideActive)
			{
				UpdateTailState();
			}
			ManualPhysicsUpdate();
		}
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

	public void ManualFixedUpdate()
	{
		if (!isDead)
		{
			AnimateTail();
		}
		CheckTailPositions();
	}

	public void OnDie(InventoryItem tailItem, float force, Vector3 dogCenter, float radius, float upwardsMod, List<GameObject> dogParts, List<GutFloraResource> additionalFlora, List<GutFloraResource> additionalFloraBoosted, GameObject deathParticles = null)
	{
		SetTailState(TailState.NEUTRAL);
		GameObject gameObject = new GameObject("Dog Tail");
		if (deathParticles != null)
		{
			Object.Instantiate(deathParticles, baseJoint.connectedBody.transform.TransformPoint(baseJoint.connectedAnchor), Quaternion.identity);
		}
		Object.Destroy(baseJoint);
		base.transform.SetParent(gameObject.transform);
		ObjectUtil.ConvertObjectToFood(gameObject, tailItem, GetComponentInChildren<SkinnedMeshRenderer>().material.color, canSaveLoad: false, null, additionalFlora, additionalFloraBoosted);
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

	public void SetTailStateOverride(TailState newState)
	{
		tailStateOverride = newState;
		tailStateOverrideActive = true;
		SetTailState(tailStateOverride);
	}

	public void ClearTailStateOverride()
	{
		tailStateOverrideActive = false;
	}

	private TailState GetTailState()
	{
		if (tailStateOverrideActive)
		{
			return tailStateOverride;
		}
		return currentTailState;
	}

	private void InitializeTailStates()
	{
		wagRequirements = default(TailStateStruct);
		wagRequirements.requireAll = true;
		wagRequirements.minAnger = DoggyBrain.minAngerForHappiness;
		wagRequirements.maxAnger = DoggyBrain.maxAngerForHappiness;
		wagRequirements.minEnergy = DoggyBrain.minEnergyForHappiness;
		wagRequirements.maxEnergy = DoggyBrain.maxEnergyForHappiness;
		wagRequirements.minHunger = DoggyBrain.minHungerForHappiness;
		wagRequirements.maxHunger = DoggyBrain.maxHungerForHappiness;
		wagRequirements.minStress = DoggyBrain.minStressForHappiness;
		wagRequirements.maxStress = DoggyBrain.maxStressForHappiness;
		wagRequirements.minBoredom = DoggyBrain.minBoredomForHappiness;
		wagRequirements.maxBoredom = DoggyBrain.maxBoredomForHappiness;
		tuckedRequirements = default(TailStateStruct);
		tuckedRequirements.requireAll = false;
		tuckedRequirements.minAnger = 0f;
		tuckedRequirements.maxAnger = 0.1f;
		tuckedRequirements.minEnergy = 0f;
		tuckedRequirements.maxEnergy = 0.1f;
		tuckedRequirements.minHunger = 0f;
		tuckedRequirements.maxHunger = 0.1f;
		tuckedRequirements.minStress = 0f;
		tuckedRequirements.maxStress = 0.1f;
		tuckedRequirements.minBoredom = 0f;
		tuckedRequirements.maxBoredom = 0.1f;
	}

	public void SetUpTailChainPositions()
	{
		segmentKeys.Clear();
		initialSegmentPositions.Clear();
		ConfigurableJoint[] componentsInChildren = segmentToIgnoreBack.transform.parent.gameObject.GetComponentsInChildren<ConfigurableJoint>();
		foreach (ConfigurableJoint obj in componentsInChildren)
		{
			GameObject gameObject = obj.gameObject;
			GameObject gameObject2 = obj.connectedBody.gameObject;
			initialSegmentPositions[gameObject] = Vector3.Distance(gameObject.transform.position, gameObject2.transform.position);
			segmentKeys.Add(gameObject);
		}
	}

	private void CheckTailPositions()
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

	private void UpdateWagDrive()
	{
		wagDriveHorizontal = wagDriveHorizontalMod;
		wagDriveX = default(JointDrive);
		wagDriveX.positionSpring = wagDriveVertical;
		wagDriveX.maximumForce = baseJoint.angularXDrive.maximumForce;
		wagDriveX.positionDamper = baseJoint.angularXDrive.positionDamper;
		wagDriveYZ = default(JointDrive);
		wagDriveYZ.positionSpring = wagDriveHorizontal;
		wagDriveYZ.maximumForce = baseJoint.angularYZDrive.maximumForce;
		wagDriveYZ.positionDamper = baseJoint.angularYZDrive.positionDamper;
		if (GetTailState() == TailState.WAGGING)
		{
			baseJoint.angularXDrive = wagDriveX;
			baseJoint.angularYZDrive = wagDriveYZ;
		}
	}

	private void UpdateTailState()
	{
		if (wagRequirements.StateValid(brainRef))
		{
			SetTailState(TailState.WAGGING);
		}
		else if (tuckedRequirements.StateValid(brainRef))
		{
			SetTailState(TailState.TUCKED);
		}
		else
		{
			SetTailState(TailState.NEUTRAL);
		}
	}

	private void SetTailState(TailState newState)
	{
		if (newState != currentTailState && !isDead)
		{
			switch (currentTailState)
			{
			case TailState.WAGGING:
				baseJoint.angularXDrive = originalDriveX;
				baseJoint.angularYZDrive = originalDriveYZ;
				baseJoint.targetRotation = Quaternion.identity;
				break;
			case TailState.TUCKED:
				baseJoint.targetRotation = Quaternion.identity;
				break;
			}
			currentTailState = newState;
			switch (newState)
			{
			case TailState.WAGGING:
				StartWag();
				break;
			case TailState.TUCKED:
				StartTuck();
				break;
			}
		}
	}

	private void AnimateTail()
	{
		switch (GetTailState())
		{
		case TailState.WAGGING:
			Wag();
			break;
		case TailState.NEUTRAL:
			Neutral();
			break;
		}
	}

	private void Neutral()
	{
		baseJoint.targetRotation = Quaternion.identity;
	}

	private void StartWag()
	{
		baseJoint.angularXDrive = wagDriveX;
		baseJoint.angularYZDrive = wagDriveYZ;
		baseJoint.targetRotation = Quaternion.Euler(wagVertAngle, wagHorizontalAngle, 0f);
		wagHorizontalAngle *= -1f;
		wagoutTimer = 0f;
	}

	private void StartTuck()
	{
		baseJoint.targetRotation = Quaternion.Euler(tuckedVertAngle, 0f, 0f);
	}

	private void Wag()
	{
		wagDriveHorizontalMod = wagRequirements.GetPercentValid(brainRef, ignoreStress: true, ignoreHunger: false, ignoreEnergy: false, ignoreAnger: false, ignoreBoredom: true) * (wagDriveHorizontalModMax - wagDriveHorizontalModMin);
		wagDriveHorizontalMod += wagDriveHorizontalModMin;
		bool flag = false;
		float positiveBoundAngle = AngleUtil.GetPositiveBoundAngle(baseJoint.transform.localRotation.eulerAngles.y);
		float positiveBoundAngle2 = AngleUtil.GetPositiveBoundAngle(wagHorizontalAngle + baseJoint.connectedBody.transform.localRotation.eulerAngles.y);
		float angleDiff = AngleUtil.GetAngleDiff(positiveBoundAngle2, positiveBoundAngle);
		if (wagHorizontalAngle > 0f && positiveBoundAngle >= positiveBoundAngle2 && angleDiff < wagAngleTolerance)
		{
			flag = true;
		}
		else if (wagHorizontalAngle < 0f && positiveBoundAngle <= positiveBoundAngle2 && angleDiff < wagAngleTolerance)
		{
			flag = true;
		}
		if (!flag && wagoutTimer > wagoutTimerMax)
		{
			flag = true;
		}
		if (flag)
		{
			baseJoint.targetRotation = Quaternion.Euler(wagVertAngle, wagHorizontalAngle, 0f);
			wagHorizontalAngle *= -1f;
			wagoutTimer = 0f;
		}
		else
		{
			wagoutTimer += Time.deltaTime;
		}
	}
}
