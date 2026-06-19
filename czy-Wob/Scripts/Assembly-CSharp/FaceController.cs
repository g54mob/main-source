using System.Collections;
using System.Collections.Generic;
using HighlightingSystem;
using I2.Loc;
using UnityEngine;

public class FaceController : MonoBehaviour
{
	public Transform debugTestTarget;

	public List<FaceSet> allFaceSets = new List<FaceSet>();

	public List<Material> allMouths = new List<Material>();

	public List<LocalizedString> mouthNames = new List<LocalizedString>();

	public Material openMouthMat;

	public DogHead oldDogHead;

	public DogHead mainDogHead;

	public int oldDogHeadFaceSetIndex;

	private List<DogHead> allDogHeads = new List<DogHead>();

	private bool useOldHead;

	private Dictionary<GameObject, float> initialSegmentPositions = new Dictionary<GameObject, float>();

	private List<GameObject> segmentKeys = new List<GameObject>();

	private float positionTolerance = 2f;

	private Face currentFace;

	private FaceSet currentFaceSet;

	private float expressionTimer = -1f;

	private FaceSet currentFaceSetUnused;

	private int currentMouthIndex;

	private int currentFaceSetIndex;

	private Transform bodyFront;

	private Coroutine currentEmoteRoutine;

	private float fov = 110f;

	private float focusAngleChangeMax = 4f;

	private float overrideAngleChangeMax = -1f;

	private Transform currentFocusTarget;

	private bool neckTension = true;

	private JointDrive defaultXDrive;

	private JointDrive defaultYZDrive;

	private JointDrive tensionMaxJointDrive;

	private JointDrive tensionGoneJointDrive;

	private bool emoteAILock;

	private bool ambientFocus;

	private bool ambientFocusAllowed = true;

	private float ambientFocusChance = 0.5f;

	private float currentAmbientFocusTimer;

	private float maxAmbientFocusDistance = 10f;

	private float ambientFocusCheckTimerMin = 5f;

	private float ambientFocusCheckTimerMax = 20f;

	private Face currentDefaultFace;

	private Quaternion targetFaceRot = Quaternion.identity;

	private bool overrideFaceRot;

	private Quaternion targetFaceRotOverride = Quaternion.identity;

	private bool debugNoUpdates;

	private LegController legControllerRef;

	private DogRegistration dogRegRef;

	private MasterDogGene masterDogGeneRef;

	private void Awake()
	{
		tensionGoneJointDrive = default(JointDrive);
		tensionGoneJointDrive.maximumForce = 1f;
		tensionGoneJointDrive.positionSpring = 100f;
		tensionMaxJointDrive = default(JointDrive);
		tensionMaxJointDrive.positionDamper = 0f;
		tensionMaxJointDrive.maximumForce = 1000000f;
		tensionMaxJointDrive.positionSpring = 1000000f;
		AddDogHead(mainDogHead);
		legControllerRef = GetComponent<LegController>();
		if (legControllerRef != null)
		{
			bodyFront = GetComponent<LegController>().bodyFront.transform;
		}
		masterDogGeneRef = GetComponent<MasterDogGene>();
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void Update()
	{
		if (!(legControllerRef == null))
		{
			UpdateFocus();
			CheckAmbientFocus();
			UpdateExpressionTimer();
			UpdateHeadTargetRotations();
		}
	}

	private void FixedUpdate()
	{
		CheckFacePositions();
	}

	private void OnDestroy()
	{
		StopFocus();
	}

	public void SetOverrideFaceRot(Vector3 newRot)
	{
		SetOverrideFaceRot(Quaternion.Euler(newRot));
	}

	public void SetOverrideFaceRot(Quaternion newRot)
	{
		overrideFaceRot = true;
		targetFaceRotOverride = newRot;
	}

	public void ClearOverrideFaceRot()
	{
		overrideFaceRot = false;
		targetFaceRotOverride = Quaternion.identity;
	}

	public void SetAmbientFocusAllowed(bool val)
	{
		ambientFocusAllowed = val;
	}

	public void RemoveNeckTension()
	{
		if (!useOldHead && neckTension && allDogHeads.Count != 0)
		{
			neckTension = false;
			defaultXDrive = allDogHeads[0].emoteJoint.angularXDrive;
			defaultYZDrive = allDogHeads[0].emoteJoint.angularYZDrive;
			for (int i = 0; i < allDogHeads.Count; i++)
			{
				allDogHeads[i].emoteJoint.angularXDrive = tensionGoneJointDrive;
				allDogHeads[i].emoteJoint.angularYZDrive = tensionGoneJointDrive;
			}
		}
	}

	public void MaximizeNeckTension()
	{
		if (!useOldHead && neckTension && allDogHeads.Count != 0)
		{
			overrideAngleChangeMax = 90f;
			neckTension = false;
			defaultXDrive = allDogHeads[0].emoteJoint.angularXDrive;
			defaultYZDrive = allDogHeads[0].emoteJoint.angularYZDrive;
			for (int i = 0; i < allDogHeads.Count; i++)
			{
				allDogHeads[i].emoteJoint.angularXDrive = tensionMaxJointDrive;
				allDogHeads[i].emoteJoint.angularYZDrive = tensionMaxJointDrive;
			}
		}
	}

	public void RestoreNeckTension()
	{
		if (!useOldHead && !neckTension && allDogHeads.Count != 0)
		{
			neckTension = true;
			overrideAngleChangeMax = -1f;
			for (int i = 0; i < allDogHeads.Count; i++)
			{
				allDogHeads[i].emoteJoint.angularXDrive = defaultXDrive;
				allDogHeads[i].emoteJoint.angularYZDrive = defaultYZDrive;
			}
		}
	}

	public List<GameObject> GetAllSnouts()
	{
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < allDogHeads.Count; i++)
		{
			list.Add(allDogHeads[i].snoutBone);
		}
		return list;
	}

	public List<DogHead> GetAllDogHeads()
	{
		return allDogHeads;
	}

	public int GetNumberOfDogHeads()
	{
		return allDogHeads.Count;
	}

	public DogHead GetDogHeadForIndex(int i)
	{
		if (i < 0 || i >= allDogHeads.Count)
		{
			Debug.LogError("No dog head found for index: " + i + " on dog: " + base.gameObject);
			return null;
		}
		return allDogHeads[i];
	}

	public void AddDogHead(DogHead head)
	{
		allDogHeads.Add(head);
		UpdateHeadCollision(head);
		head.emoteJoint = head.armatureStart.GetComponent<ConfigurableJoint>();
	}

	public bool OldHead()
	{
		return useOldHead;
	}

	public void SetUseOldHead()
	{
		useOldHead = true;
		currentFaceSetIndex = oldDogHeadFaceSetIndex;
		UpdateFaceSet(allFaceSets[currentFaceSetIndex], currentFaceSetIndex);
		legControllerRef.mouth = oldDogHead.mouthTransform.gameObject;
		GetComponent<DogState>().UpdateMouth();
		allDogHeads.Clear();
		segmentKeys.Clear();
		initialSegmentPositions.Clear();
		allDogHeads.Add(oldDogHead);
	}

	public Face GetCurrentFace()
	{
		return currentFace;
	}

	public void UpdateFaceSetByIndex(int index)
	{
		UpdateFaceSet(allFaceSets[index], index);
	}

	public void UpdateFaceSet(FaceSet newFaceSet, int index)
	{
		currentFaceSet = newFaceSet;
		RequestFace(Face.DEFAULT);
		currentFaceSetIndex = index;
	}

	public void UpdateMouthByIndex(int index)
	{
		UpdateMouth(allMouths[index], index);
	}

	public void UpdateMouth(Material newMouth, int index)
	{
		SetMouthMaterial(newMouth);
		currentMouthIndex = index;
	}

	public void SetMouthOpen(bool val)
	{
		if (val)
		{
			SetMouthMaterial(openMouthMat);
		}
		else
		{
			UpdateMouthByIndex(currentMouthIndex);
		}
	}

	public void AssignEyes()
	{
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.EYELIDS);
		bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.OBLONG_EYES);
		bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.SMALL_PUPILS);
		bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MULTI_PUPILS);
		bool domRecPropertyStatus5 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.GEOMETRIC_EYES);
		bool domRecPropertyStatus6 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.DECORATIVE_EYES);
		bool domRecPropertyStatus7 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.LASHES_EYES);
		bool domRecPropertyStatus8 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.LONG_EYES);
		bool domRecPropertyStatus9 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_PUPIL_EYES);
		bool domRecPropertyStatus10 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.HORIZONTAL_EYES);
		bool domRecPropertyStatus11 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.SPIRAL_EYES);
		bool domRecPropertyStatus12 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.TRIANGLE_EYES);
		int index = 0;
		if (domRecPropertyStatus2 && domRecPropertyStatus4)
		{
			index = 6;
		}
		else if (domRecPropertyStatus3 && domRecPropertyStatus4)
		{
			index = 4;
		}
		else if (domRecPropertyStatus5 && domRecPropertyStatus11)
		{
			index = 5;
		}
		else if (domRecPropertyStatus10 && domRecPropertyStatus8)
		{
			index = 10;
		}
		else if (domRecPropertyStatus10 && domRecPropertyStatus2)
		{
			index = 9;
		}
		else if (domRecPropertyStatus9 && domRecPropertyStatus4)
		{
			index = 15;
		}
		else if (domRecPropertyStatus)
		{
			index = 1;
		}
		else if (domRecPropertyStatus2)
		{
			index = 2;
		}
		else if (domRecPropertyStatus3)
		{
			index = 3;
		}
		else if (domRecPropertyStatus12)
		{
			index = 14;
		}
		else if (domRecPropertyStatus5)
		{
			index = 12;
		}
		else if (domRecPropertyStatus7)
		{
			index = 8;
		}
		else if (domRecPropertyStatus11)
		{
			index = 11;
		}
		else if (domRecPropertyStatus9)
		{
			index = 13;
		}
		else if (domRecPropertyStatus6)
		{
			index = 7;
		}
		if (useOldHead)
		{
			currentFaceSetUnused = allFaceSets[index];
		}
		else
		{
			UpdateFaceSetByIndex(index);
		}
	}

	public LocalizedString GetCurrentFaceSetName()
	{
		if (useOldHead)
		{
			return currentFaceSetUnused.localizedName;
		}
		return currentFaceSet.localizedName;
	}

	public LocalizedString GetCurrentMouthName()
	{
		return mouthNames[currentMouthIndex];
	}

	public void AssignMouth()
	{
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.TEETH);
		bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.V_MOUTH);
		bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MOUTH_SMILE);
		bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MOUTH_FROWN);
		bool domRecPropertyStatus5 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MOUTH_CHEEKS);
		bool domRecPropertyStatus6 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MOUTH_CUTOFF);
		bool domRecPropertyStatus7 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MOUTH_WIGGLE);
		bool domRecPropertyStatus8 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.OPEN_MOUTH);
		bool domRecPropertyStatus9 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MOUTH_POINTED);
		bool domRecPropertyStatus10 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MOUTH_NEUTRAL);
		bool domRecPropertyStatus11 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MOUTH_MISSING_TEETH);
		int index = 1;
		if (domRecPropertyStatus && domRecPropertyStatus10)
		{
			index = 0;
		}
		else if (domRecPropertyStatus2 && domRecPropertyStatus8)
		{
			index = 3;
		}
		else if (domRecPropertyStatus && domRecPropertyStatus9)
		{
			index = 6;
		}
		else if (domRecPropertyStatus && domRecPropertyStatus6)
		{
			index = 7;
		}
		else if (domRecPropertyStatus && domRecPropertyStatus7)
		{
			index = 13;
		}
		else if (domRecPropertyStatus && domRecPropertyStatus4)
		{
			index = 4;
		}
		else if (domRecPropertyStatus && domRecPropertyStatus3)
		{
			index = 10;
		}
		else if (domRecPropertyStatus11 && domRecPropertyStatus9)
		{
			index = 11;
		}
		else if (domRecPropertyStatus11)
		{
			index = 8;
		}
		else if (domRecPropertyStatus10 && !domRecPropertyStatus8)
		{
			index = 12;
		}
		else if (domRecPropertyStatus5)
		{
			index = 5;
		}
		else if (domRecPropertyStatus2)
		{
			index = 2;
		}
		else if (domRecPropertyStatus4)
		{
			index = 9;
		}
		UpdateMouthByIndex(index);
	}

	public int GetFaceSetIndex()
	{
		return currentFaceSetIndex;
	}

	public int GetMouthIndex()
	{
		return currentMouthIndex;
	}

	public bool AILocked()
	{
		return emoteAILock;
	}

	public void OnDie(InventoryItem headItem, float force, Vector3 dogCenter, float radius, float upwardsMod, List<GameObject> dogParts, List<GutFloraResource> additionalFlora, List<GutFloraResource> additionalFloraBoosted, GameObject deathParticles = null)
	{
		StopFocus();
		RequestFace(Face.DEAD);
		for (int i = 0; i < allDogHeads.Count; i++)
		{
			GameObject gameObject = new GameObject("Dog Head");
			Joint joint = (useOldHead ? allDogHeads[i].armatureStart.GetComponent<ConfigurableJoint>() : allDogHeads[i].armatureStart.GetComponent<ConfigurableJoint>().connectedBody.GetComponent<ConfigurableJoint>());
			if (deathParticles != null)
			{
				Object.Instantiate(deathParticles, joint.connectedBody.transform.TransformPoint(joint.connectedAnchor), Quaternion.identity);
			}
			Object.Destroy(joint);
			allDogHeads[i].headHolder.transform.SetParent(gameObject.transform);
			Color associatedColor = (useOldHead ? allDogHeads[i].faceObject.GetComponent<MeshRenderer>().material.color : allDogHeads[i].faceObject.GetComponent<SkinnedMeshRenderer>().material.color);
			ObjectUtil.ConvertObjectToFood(gameObject, headItem, associatedColor, canSaveLoad: false, null, additionalFlora, additionalFloraBoosted);
			dogParts.Add(gameObject);
			Rigidbody[] componentsInChildren = gameObject.GetComponentsInChildren<Rigidbody>();
			foreach (Rigidbody obj in componentsInChildren)
			{
				obj.mass *= 10f;
				obj.AddExplosionForce(force, dogCenter, radius, upwardsMod);
			}
			Highlighter[] componentsInChildren2 = gameObject.GetComponentsInChildren<Highlighter>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].ConstantOffImmediate();
			}
		}
		Object.Destroy(this);
	}

	public void DebugReplaceTexture(Material newMat)
	{
		debugNoUpdates = true;
		for (int i = 0; i < allDogHeads.Count; i++)
		{
			Renderer[] componentsInChildren = allDogHeads[i].faceObject.GetComponentsInChildren<Renderer>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].material = newMat;
			}
			allDogHeads[i].faceObject.GetComponent<Renderer>().material = newMat;
		}
	}

	public void FocusOnTarget(Transform target)
	{
		InteractableBase component = target.root.GetComponent<InteractableBase>();
		if (component != null)
		{
			target = component.GetFocusTransform();
		}
		bool flag = false;
		if (currentFocusTarget != target)
		{
			if (currentFocusTarget == null || target == null)
			{
				flag = true;
			}
			else if (currentFocusTarget.transform.root != target.transform.root)
			{
				flag = true;
			}
		}
		if (flag)
		{
			StopFocus();
		}
		currentFocusTarget = target;
		if (!(component == null) && flag)
		{
			component.AddFocusingDog(dogRegRef.GetIDFromDog(base.gameObject));
		}
	}

	public void StopFocus()
	{
		if (currentFocusTarget != null)
		{
			InteractableBase component = currentFocusTarget.transform.root.GetComponent<InteractableBase>();
			if (component != null)
			{
				component.RemoveFocusingDog(dogRegRef.GetIDFromDog(base.gameObject));
			}
		}
		currentFocusTarget = null;
		targetFaceRot = Quaternion.identity;
	}

	private void CheckAmbientFocus()
	{
		if (!ambientFocusAllowed)
		{
			if (ambientFocus)
			{
				StopFocus();
			}
		}
		else
		{
			if (currentFocusTarget != null && !ambientFocus)
			{
				return;
			}
			currentAmbientFocusTimer -= Time.deltaTime;
			if (currentAmbientFocusTimer > 0f)
			{
				return;
			}
			ambientFocus = false;
			currentAmbientFocusTimer = Random.Range(ambientFocusCheckTimerMin, ambientFocusCheckTimerMax);
			if (Random.value > ambientFocusChance)
			{
				return;
			}
			List<GameObject> objects = ObjectRegistration.GetRegistrationScript().GetAllObjectsForTag(TagsEnum.ALL);
			ListUtil.ShuffleList(ref objects);
			for (int i = 0; i < objects.Count; i++)
			{
				if (objects[i] == base.gameObject || objects[i] == null)
				{
					continue;
				}
				BoundingBoxComponent component = objects[i].GetComponent<BoundingBoxComponent>();
				if (component == null)
				{
					continue;
				}
				Vector3 boxCenter = component.GetBoxCenter();
				if (!(Vector3.Distance(bodyFront.transform.position, boxCenter) > maxAmbientFocusDistance))
				{
					Transform transform = objects[i].transform;
					Rigidbody componentInChildren = objects[i].GetComponentInChildren<Rigidbody>();
					if (componentInChildren != null)
					{
						transform = componentInChildren.transform;
					}
					if (!IsFacingAngleOutsideFOV(GetFacingAngleForTarget(transform)))
					{
						ambientFocus = true;
						FocusOnTarget(transform);
						break;
					}
				}
			}
		}
	}

	private void UpdateHeadTargetRotations()
	{
		for (int i = 0; i < allDogHeads.Count; i++)
		{
			UpdateHeadTargetRotation(allDogHeads[i]);
		}
	}

	private void UpdateHeadTargetRotation(DogHead head)
	{
		if (useOldHead)
		{
			return;
		}
		Quaternion quaternion = targetFaceRot;
		if (overrideFaceRot)
		{
			quaternion = targetFaceRotOverride;
		}
		if (!(head.emoteJoint.targetRotation == quaternion))
		{
			float num = focusAngleChangeMax;
			if (overrideAngleChangeMax >= 0f)
			{
				num = overrideAngleChangeMax;
			}
			float num2 = Quaternion.Angle(head.emoteJoint.targetRotation, quaternion);
			float t = Mathf.Min(1f, num / num2) * 50f * Time.deltaTime;
			Quaternion targetRotation = Quaternion.Lerp(head.emoteJoint.targetRotation, quaternion, t);
			head.emoteJoint.targetRotation = targetRotation;
		}
	}

	public Vector3 GetFacingAngleForTarget(Transform targetTransform)
	{
		if (targetTransform.gameObject == bodyFront.transform)
		{
			return Vector3.zero;
		}
		Quaternion quaternion = Quaternion.LookRotation(targetTransform.position - bodyFront.transform.position, bodyFront.transform.right);
		Vector3 eulerAngles = (Quaternion.Inverse(bodyFront.transform.rotation) * quaternion).eulerAngles;
		eulerAngles.y -= 270f;
		eulerAngles.y = 0f - eulerAngles.y;
		if (eulerAngles.x > 180f)
		{
			eulerAngles.x -= 360f;
		}
		if (eulerAngles.y > 180f)
		{
			eulerAngles.y -= 360f;
		}
		return eulerAngles;
	}

	public GameObject GetCurrentFocusTarget()
	{
		if (currentFocusTarget == null)
		{
			return null;
		}
		return currentFocusTarget.transform.root.gameObject;
	}

	public bool CanSeeFocusObject()
	{
		if (currentFocusTarget == null)
		{
			return false;
		}
		Vector3 facingAngleForTarget = GetFacingAngleForTarget(currentFocusTarget);
		return !IsFacingAngleOutsideFOV(facingAngleForTarget);
	}

	private void UpdateFocus()
	{
		if (debugTestTarget != null)
		{
			currentFocusTarget = debugTestTarget;
		}
		if (!(currentFocusTarget == null))
		{
			Vector3 facingAngleForTarget = GetFacingAngleForTarget(currentFocusTarget);
			if (IsFacingAngleOutsideFOV(facingAngleForTarget))
			{
				facingAngleForTarget.x = 0f;
				facingAngleForTarget.y = 0f;
			}
			targetFaceRot = Quaternion.Euler(0f, facingAngleForTarget.x, facingAngleForTarget.y);
		}
	}

	private bool IsFacingAngleOutsideFOV(Vector3 angle)
	{
		if (angle.x > fov || angle.x < 0f - fov || angle.y > fov || angle.y < 0f - fov)
		{
			return true;
		}
		return false;
	}

	public void CancelEmote()
	{
		if (currentEmoteRoutine != null)
		{
			StopCoroutine(currentEmoteRoutine);
			currentEmoteRoutine = null;
		}
	}

	public void RequestEmote(HeadEmote emoteType, float timer = -1f)
	{
		if (currentEmoteRoutine == null && base.gameObject.activeSelf)
		{
			switch (emoteType)
			{
			case HeadEmote.DEFAULT:
				SetEmoteDefault();
				break;
			case HeadEmote.CONFUSED:
				SetEmoteConfused();
				break;
			case HeadEmote.SKEPTICAL:
				SetEmoteSkeptical();
				break;
			case HeadEmote.PETTED:
				SetEmotePetted();
				break;
			case HeadEmote.PETTED_END:
				SetEmotePettedEnd();
				break;
			case HeadEmote.HOWL:
				SetEmoteHowl(timer);
				break;
			}
		}
	}

	private void SetEmoteDefault()
	{
		targetFaceRot = Quaternion.identity;
	}

	private void SetEmoteConfused()
	{
		currentEmoteRoutine = StartCoroutine(ConfusedEmote());
	}

	private IEnumerator ConfusedEmote()
	{
		float angle1Time = Random.Range(0.4f, 0.1f);
		float angle1HoldTime = Random.Range(1f, 0.75f);
		float angle2Time = Random.Range(0.6f, 0.3f);
		float angle2HoldTime = Random.Range(1.5f, 1f);
		float returnTime = Random.Range(0.4f, 0.3f);
		float num = Random.Range(30, 40);
		float x = ((Random.value > 0.5f) ? num : (0f - num));
		float z = ((x > 0f) ? 10 : (-10));
		float timer = 0f;
		while (timer <= angle1Time)
		{
			timer += Time.deltaTime;
			float quadraticInValue = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), 0f, 0f - x, angle1Time);
			float quadraticInValue2 = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), 0f, 0f - z, angle1Time);
			if (!useOldHead)
			{
				for (int i = 0; i < allDogHeads.Count; i++)
				{
					Vector3 eulerAngles = allDogHeads[i].emoteJoint.targetRotation.eulerAngles;
					targetFaceRot = Quaternion.Euler(quadraticInValue, eulerAngles.y, quadraticInValue2);
					allDogHeads[i].emoteJoint.targetRotation = Quaternion.Euler(quadraticInValue, eulerAngles.y, quadraticInValue2);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		while (timer <= angle1HoldTime)
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		while (timer <= angle2Time)
		{
			timer += Time.deltaTime;
			float quadraticInValue = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), x, x * 2f, angle2Time);
			float quadraticInValue2 = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), z, z * 2f, angle2Time);
			if (!useOldHead)
			{
				for (int j = 0; j < allDogHeads.Count; j++)
				{
					Vector3 eulerAngles = allDogHeads[j].emoteJoint.targetRotation.eulerAngles;
					targetFaceRot = Quaternion.Euler(quadraticInValue, eulerAngles.y, quadraticInValue2);
					allDogHeads[j].emoteJoint.targetRotation = Quaternion.Euler(quadraticInValue, eulerAngles.y, quadraticInValue2);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		while (timer <= angle2HoldTime)
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		while (timer <= returnTime)
		{
			timer += Time.deltaTime;
			float quadraticInValue = Inchworm.GetQuadraticOutValue(Mathf.Min(timer, 1f), 0f - x, 0f - x, returnTime);
			float quadraticInValue2 = Inchworm.GetQuadraticOutValue(Mathf.Min(timer, 1f), 0f - z, 0f - z, returnTime);
			if (!useOldHead)
			{
				for (int k = 0; k < allDogHeads.Count; k++)
				{
					Vector3 eulerAngles = allDogHeads[k].emoteJoint.targetRotation.eulerAngles;
					targetFaceRot = Quaternion.Euler(quadraticInValue, eulerAngles.y, quadraticInValue2);
					allDogHeads[k].emoteJoint.targetRotation = Quaternion.Euler(quadraticInValue, eulerAngles.y, quadraticInValue2);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		currentEmoteRoutine = null;
	}

	private void SetEmoteHowl(float howlTime)
	{
		currentEmoteRoutine = StartCoroutine(HowlEmote(howlTime));
	}

	private IEnumerator HowlEmote(float howlTime)
	{
		float angle1Time = Random.Range(0.5f, 1f);
		float returnTime = Random.Range(0.4f, 0.5f);
		float y = -45f;
		float timer = 0f;
		while (timer <= angle1Time)
		{
			timer += Time.deltaTime;
			float quadraticInValue = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), 0f, 0f - y, angle1Time);
			if (!useOldHead)
			{
				for (int i = 0; i < allDogHeads.Count; i++)
				{
					Vector3 eulerAngles = allDogHeads[i].emoteJoint.targetRotation.eulerAngles;
					targetFaceRot = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
					allDogHeads[i].emoteJoint.targetRotation = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		while (timer <= howlTime)
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		while (timer <= returnTime)
		{
			timer += Time.deltaTime;
			float quadraticInValue = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), y, y, returnTime);
			if (!useOldHead)
			{
				for (int j = 0; j < allDogHeads.Count; j++)
				{
					Vector3 eulerAngles = allDogHeads[j].emoteJoint.targetRotation.eulerAngles;
					targetFaceRot = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
					allDogHeads[j].emoteJoint.targetRotation = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		currentEmoteRoutine = null;
	}

	private void SetEmoteSkeptical()
	{
		currentEmoteRoutine = StartCoroutine(SkepticalEmote());
	}

	private IEnumerator SkepticalEmote()
	{
		float angle1Time = Random.Range(0f, 0.2f);
		float angle1HoldTime = 1f;
		float returnTime = Random.Range(0.4f, 0.5f);
		float y = -45f;
		float timer = 0f;
		while (timer <= angle1Time)
		{
			timer += Time.deltaTime;
			float quadraticInValue = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), 0f, 0f - y, angle1Time);
			if (!useOldHead)
			{
				for (int i = 0; i < allDogHeads.Count; i++)
				{
					Vector3 eulerAngles = allDogHeads[i].emoteJoint.targetRotation.eulerAngles;
					targetFaceRot = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
					allDogHeads[i].emoteJoint.targetRotation = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		while (timer <= angle1HoldTime)
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		timer = 0f;
		while (timer <= returnTime)
		{
			timer += Time.deltaTime;
			float quadraticInValue = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), y, y, returnTime);
			if (!useOldHead)
			{
				for (int j = 0; j < allDogHeads.Count; j++)
				{
					Vector3 eulerAngles = allDogHeads[j].emoteJoint.targetRotation.eulerAngles;
					targetFaceRot = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
					allDogHeads[j].emoteJoint.targetRotation = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		currentEmoteRoutine = null;
	}

	public void SetEmotePetted()
	{
		currentEmoteRoutine = StartCoroutine(PettedEmote());
	}

	public void SetEmotePettedEnd()
	{
		currentEmoteRoutine = StartCoroutine(PettedEmoteEnd());
	}

	private IEnumerator PettedEmote()
	{
		float angle1Time = Random.Range(0.5f, 0.6f);
		float y = -45f;
		float timer = 0f;
		while (timer <= angle1Time)
		{
			timer += Time.deltaTime;
			float quadraticInValue = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), 0f, 0f - y, angle1Time);
			if (!useOldHead)
			{
				for (int i = 0; i < allDogHeads.Count; i++)
				{
					Vector3 eulerAngles = allDogHeads[i].emoteJoint.targetRotation.eulerAngles;
					targetFaceRot = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
					allDogHeads[i].emoteJoint.targetRotation = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		currentEmoteRoutine = null;
	}

	private IEnumerator PettedEmoteEnd()
	{
		List<float> startYValues = new List<float>();
		if (!useOldHead)
		{
			for (int i = 0; i < allDogHeads.Count; i++)
			{
				float num = allDogHeads[i].emoteJoint.targetRotation.eulerAngles.y;
				if (num > 180f)
				{
					num -= 360f;
				}
				startYValues.Add(num);
			}
		}
		float timer = 0f;
		float returnTime = Random.Range(0.5f, 0.75f);
		while (timer <= returnTime)
		{
			timer += Time.deltaTime;
			if (!useOldHead)
			{
				for (int j = 0; j < allDogHeads.Count; j++)
				{
					float quadraticInValue = Inchworm.GetQuadraticInValue(Mathf.Min(timer, 1f), startYValues[j], startYValues[j], returnTime);
					Vector3 eulerAngles = allDogHeads[j].emoteJoint.targetRotation.eulerAngles;
					targetFaceRot = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
					allDogHeads[j].emoteJoint.targetRotation = Quaternion.Euler(eulerAngles.x, quadraticInValue, eulerAngles.z);
				}
			}
			yield return new WaitForEndOfFrame();
		}
		currentEmoteRoutine = null;
	}

	public void RequestFace(Face faceType, float faceTimer = -1f, bool suppressEmote = false, bool lockAI = false)
	{
		emoteAILock = lockAI;
		expressionTimer = faceTimer;
		if (faceType == Face.DEFAULT && currentDefaultFace != Face.DEFAULT)
		{
			faceType = currentDefaultFace;
		}
		if (faceType == currentFace && currentFace != Face.DEFAULT)
		{
			return;
		}
		currentFace = faceType;
		switch (faceType)
		{
		case Face.DEFAULT:
			SetFaceMaterial(currentFaceSet.defaultFace);
			break;
		case Face.SLEEP:
			SetFaceMaterial(currentFaceSet.sleepFace);
			break;
		case Face.DEAD:
			SetFaceMaterial(currentFaceSet.deadFace);
			break;
		case Face.SURPRISED:
			if (!suppressEmote)
			{
				RequestEmote(HeadEmote.SKEPTICAL);
			}
			SetFaceMaterial(currentFaceSet.surprisedFace);
			break;
		case Face.ANGRY:
			SetFaceMaterial(currentFaceSet.angryFace);
			break;
		case Face.WINCE:
			SetFaceMaterial(currentFaceSet.surprisedFace);
			break;
		}
	}

	public void SetDefaultFace(Face newDefaultFace)
	{
		currentDefaultFace = newDefaultFace;
		if (expressionTimer <= 0f)
		{
			RequestFace(Face.DEFAULT);
		}
	}

	private void SetFaceMaterial(Material material)
	{
		if (debugNoUpdates)
		{
			return;
		}
		if (useOldHead)
		{
			Material[] materials = allDogHeads[0].faceObject.GetComponent<Renderer>().materials;
			allDogHeads[0].faceObject.GetComponent<Renderer>().materials = new Material[2]
			{
				materials[0],
				material
			};
			return;
		}
		for (int i = 0; i < allDogHeads.Count; i++)
		{
			Material[] materials2 = allDogHeads[i].faceObject.GetComponent<Renderer>().materials;
			allDogHeads[i].faceObject.GetComponent<Renderer>().materials = new Material[3]
			{
				materials2[0],
				material,
				materials2[2]
			};
		}
	}

	private void SetMouthMaterial(Material material)
	{
		for (int i = 0; i < allDogHeads.Count; i++)
		{
			Material[] materials = allDogHeads[i].faceObject.GetComponent<Renderer>().materials;
			allDogHeads[i].faceObject.GetComponent<Renderer>().materials = new Material[3]
			{
				materials[0],
				materials[1],
				material
			};
		}
	}

	private void UpdateExpressionTimer()
	{
		if (expressionTimer <= 0f)
		{
			emoteAILock = false;
			return;
		}
		expressionTimer -= Time.deltaTime;
		if (expressionTimer <= 0f)
		{
			emoteAILock = false;
			RequestFace(Face.DEFAULT);
		}
	}

	public void UpdateHeadCollisions()
	{
		for (int i = 0; i < allDogHeads.Count; i++)
		{
			UpdateHeadCollision(allDogHeads[i]);
		}
	}

	private void UpdateHeadCollision(DogHead head)
	{
		if (useOldHead || head.armatureStart == null)
		{
			return;
		}
		List<Collider> list = new List<Collider>();
		list.AddRange(head.armatureStart.transform.parent.GetComponentsInChildren<Collider>());
		DogLooks component = GetComponent<DogLooks>();
		Collider[] componentsInChildren;
		for (int i = 0; i < list.Count; i++)
		{
			list[i].gameObject.layer = LayerMask.NameToLayer("Head");
			for (int j = i + 1; j < list.Count; j++)
			{
				Physics.IgnoreCollision(list[i], list[j]);
			}
			componentsInChildren = head.earsHolder.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				Physics.IgnoreCollision(list[i], collider);
			}
		}
		List<Collider> list2 = new List<Collider>();
		for (int l = 0; l < allDogHeads.Count; l++)
		{
			if (allDogHeads[l] == head)
			{
				continue;
			}
			list2.Clear();
			list2.Add(allDogHeads[l].armatureStart.GetComponent<Collider>());
			list2.AddRange(allDogHeads[l].armatureStart.GetComponentsInChildren<Collider>());
			for (int m = 0; m < list2.Count; m++)
			{
				for (int n = 0; n < list.Count; n++)
				{
					Physics.IgnoreCollision(list[n], list2[m]);
				}
			}
		}
		Physics.IgnoreCollision(component.bodyFront.GetComponent<Collider>(), head.armatureStart.GetComponent<Collider>());
		componentsInChildren = head.earsHolder.GetComponentsInChildren<Collider>();
		foreach (Collider collider2 in componentsInChildren)
		{
			Physics.IgnoreCollision(component.bodyFront.GetComponent<Collider>(), collider2);
			Physics.IgnoreCollision(component.bodyBack.GetComponent<Collider>(), collider2);
		}
		SetUpFaceChainPositions();
	}

	public void SetUpFaceChainPositions()
	{
		segmentKeys.Clear();
		initialSegmentPositions.Clear();
		for (int i = 0; i < allDogHeads.Count; i++)
		{
			ConfigurableJoint[] componentsInChildren = allDogHeads[i].armatureStart.transform.parent.GetComponentsInChildren<ConfigurableJoint>();
			foreach (ConfigurableJoint obj in componentsInChildren)
			{
				GameObject gameObject = obj.gameObject;
				GameObject gameObject2 = obj.connectedBody.gameObject;
				initialSegmentPositions[gameObject] = Vector3.Distance(gameObject.transform.position, gameObject2.transform.position);
				segmentKeys.Add(gameObject);
			}
		}
	}

	private void CheckFacePositions()
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
}
