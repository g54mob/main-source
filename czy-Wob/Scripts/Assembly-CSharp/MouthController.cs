using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
	public delegate void GrabSuccessCallback();

	public InventoryItem babyToothRef;

	private float babyToothDropChance = 0.05f;

	private List<ConfigurableJoint> mouthJoints = new List<ConfigurableJoint>();

	private GameObject heldObject;

	private List<Collider> heldColliders = new List<Collider>();

	private int activeMouthIndex;

	private string toothCrackSFX = "dog_tooth_lost";

	private string grabObjectSound = "dog_object_grab";

	private string dropObjectSound = "dog_object_drop";

	private float chompTimer = -1f;

	private float chompTimerMax = 0.5f;

	private float holdTimer = -1f;

	private float biteHoldTimer = 0.05f;

	private float breakForce = 2500f;

	private float breakTorque = 500f;

	private bool isDead;

	private float breakValuesTimer;

	private float breakValuesTimerMax = 0.25f;

	private bool holdFromBite;

	private Vector3 defaultRotation;

	private bool shuttingDown;

	private DogAI aiRef;

	private DogState stateRef;

	private DoggyBrain brainRef;

	private PenFocus penFocusRef;

	private DogNoises dogNoisesRef;

	private ObjectGrabber grabberRef;

	private FaceController faceControllerRef;

	private DogParticleController particleRef;

	private DogHome homeRef;

	private void Awake()
	{
		aiRef = GetComponent<DogAI>();
		stateRef = GetComponent<DogState>();
		brainRef = GetComponent<DoggyBrain>();
		dogNoisesRef = GetComponent<DogNoises>();
		particleRef = GetComponent<DogParticleController>();
		faceControllerRef = GetComponent<FaceController>();
		defaultRotation = faceControllerRef.GetDogHeadForIndex(0).mouthJointRef.transform.localRotation.eulerAngles;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		homeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME, nullAllowed: true);
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER, nullAllowed: true);
	}

	private void OnApplicationQuit()
	{
		shuttingDown = true;
	}

	private void OnDestroy()
	{
		DropObject();
	}

	private void Update()
	{
		if (chompTimer > 0f)
		{
			chompTimer -= Time.deltaTime;
		}
		if (holdTimer > 0f)
		{
			holdTimer -= Time.deltaTime;
			if (holdTimer <= 0f)
			{
				DropObject();
			}
		}
		if (breakValuesTimer > 0f)
		{
			breakValuesTimer -= Time.deltaTime;
			if (breakValuesTimer <= 0f)
			{
				AssignBreakValues();
			}
		}
		mouthJoints.RemoveAll((ConfigurableJoint joint) => joint == null);
		if (mouthJoints.Count == 0 && heldObject != null)
		{
			RestoreCollision();
			DropObject();
			heldObject = null;
		}
		if (mouthJoints.Count > 0 && mouthJoints[0].connectedBody == null)
		{
			DropObject();
		}
	}

	public bool CanChomp()
	{
		if (isDead)
		{
			return false;
		}
		if (heldObject != null)
		{
			return false;
		}
		if (chompTimer > 0f)
		{
			return false;
		}
		return true;
	}

	private void OnDrawGizmos()
	{
		for (int i = 0; i < mouthJoints.Count; i++)
		{
			if (!(mouthJoints[i] == null))
			{
				Gizmos.DrawSphere(mouthJoints[i].transform.TransformPoint(mouthJoints[i].anchor), 0.05f);
			}
		}
	}

	private void DropBabyTooth()
	{
		float num = Random.Range(0.75f, 1f);
		Vector3 value = new Vector3(num, num, num);
		Vector3 position = faceControllerRef.GetDogHeadForIndex(activeMouthIndex).mouthTransform.position;
		homeRef.TrySpawnItem(babyToothRef, position, null, moveToGoodLocation: false, value);
		AudioController.Play(toothCrackSFX, position);
	}

	public void TryTeething()
	{
		DogAge currentDogAge = brainRef.GetCurrentDogAge();
		if ((currentDogAge == DogAge.CHILD || currentDogAge == DogAge.TEEN) && faceControllerRef.GetMouthIndex() != 1 && homeRef != null && Random.value <= babyToothDropChance)
		{
			DropBabyTooth();
		}
	}

	public void GrabObject(GameObject newObject, bool hold = true, GrabSuccessCallback callback = null)
	{
		if (heldObject == newObject)
		{
			callback?.Invoke();
			return;
		}
		if (heldObject != null)
		{
			DropObject();
		}
		if (!CanChomp() || newObject == null)
		{
			if (callback != null)
			{
				aiRef.ForceInterruptBehavior();
			}
			return;
		}
		int num = Random.Range(0, faceControllerRef.GetNumberOfDogHeads());
		DogAI.TransformAndPos bestTransformAndPosForTarget = aiRef.GetBestTransformAndPosForTarget(newObject.transform.root.gameObject, topLevel: true, num);
		if (bestTransformAndPosForTarget.transform == null && num != 0)
		{
			num = 0;
			bestTransformAndPosForTarget = aiRef.GetBestTransformAndPosForTarget(newObject.transform.root.gameObject, topLevel: true, num);
		}
		if (bestTransformAndPosForTarget.transform == null)
		{
			if (callback != null)
			{
				aiRef.ForceInterruptBehavior();
			}
			return;
		}
		heldObject = newObject;
		ObjectConnectionsManager.OnObjectGrabbedByDog(base.gameObject, newObject.transform.root.gameObject);
		if (heldColliders.Count > 0)
		{
			RestoreCollision();
		}
		if (bestTransformAndPosForTarget.transform.GetComponent<Collider>() != null)
		{
			heldColliders.Add(bestTransformAndPosForTarget.transform.GetComponent<Collider>());
		}
		heldColliders.AddRange(bestTransformAndPosForTarget.transform.GetComponentsInChildren<Collider>());
		CreateMouthJoints(num);
		RaycastHit faceHitInfoForGauranteedObject = stateRef.GetFaceHitInfoForGauranteedObject(newObject, bestTransformAndPosForTarget.closestPosition, num);
		Vector3 normal = faceHitInfoForGauranteedObject.normal;
		Vector3 point = faceHitInfoForGauranteedObject.point;
		if (faceHitInfoForGauranteedObject.transform == null)
		{
			DropObject();
			if (callback != null)
			{
				aiRef.ForceInterruptBehavior();
			}
			return;
		}
		activeMouthIndex = num;
		DogHead dogHeadForIndex = faceControllerRef.GetDogHeadForIndex(activeMouthIndex);
		TryTeething();
		float y = 0f - Quaternion.LookRotation(normal).eulerAngles.x - defaultRotation.y;
		Quaternion localRotation = Quaternion.Euler(defaultRotation.x, y, defaultRotation.z);
		dogHeadForIndex.mouthJointRef.transform.localRotation = localRotation;
		dogHeadForIndex.mouthJointRef.transform.position = point;
		dogHeadForIndex.mouthJointRef.transform.position += dogHeadForIndex.mouthJointRef.position - dogHeadForIndex.mouthTransform.position;
		dogHeadForIndex.mouthJointRef.transform.position += normal * 0.1f;
		Rigidbody rigidbody = bestTransformAndPosForTarget.transform.GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = bestTransformAndPosForTarget.transform.root.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = bestTransformAndPosForTarget.transform.root.GetComponentInChildren<Rigidbody>();
			}
		}
		for (int i = 0; i < mouthJoints.Count; i++)
		{
			mouthJoints[i].connectedBody = rigidbody;
		}
		int numberOfDogHeads = faceControllerRef.GetNumberOfDogHeads();
		for (int j = 0; j < heldColliders.Count; j++)
		{
			for (int k = 0; k < numberOfDogHeads; k++)
			{
				if (faceControllerRef.OldHead())
				{
					Physics.IgnoreCollision(faceControllerRef.GetDogHeadForIndex(k).faceObject.GetComponent<Collider>(), heldColliders[j]);
					continue;
				}
				Physics.IgnoreCollision(faceControllerRef.GetDogHeadForIndex(k).snoutBone.GetComponent<Collider>(), heldColliders[j]);
				Physics.IgnoreCollision(faceControllerRef.GetDogHeadForIndex(k).snoutBone.GetComponent<ConfigurableJoint>().connectedBody.GetComponent<Collider>(), heldColliders[j]);
			}
		}
		chompTimer = chompTimerMax;
		if (newObject.transform.root.gameObject.CompareTag(Tags.DOG))
		{
			if (newObject.transform.root.GetComponent<FaceController>() != null && !newObject.transform.root.GetComponent<DoggyBrain>().IsSleeping())
			{
				newObject.transform.root.GetComponent<FaceController>().RequestFace(Face.SURPRISED, 1f);
			}
			if (newObject.transform.root != base.gameObject && !hold)
			{
				newObject.transform.root.GetComponent<DogAI>().OnBittenByDog(base.gameObject);
			}
		}
		if (!hold)
		{
			holdTimer = biteHoldTimer;
			dogNoisesRef.RequestBite();
			particleRef.RequestBiteParticlesStart(activeMouthIndex);
			base.gameObject.GetComponent<DogAI>().GetCurrentBehavior().AwardBehaviorDefinedLoot();
		}
		else if (grabberRef != null && grabberRef.GetGrabbedObject() == newObject.transform.root.gameObject)
		{
			grabberRef.DropObject();
		}
		holdFromBite = !hold;
		InteractableBase component = newObject.transform.root.GetComponent<InteractableBase>();
		if (hold && component != null)
		{
			component.OnObjectGrabbedByDog(base.gameObject);
		}
		callback?.Invoke();
		penFocusRef.OnObjectGrabbed(base.gameObject, heldObject);
		AudioController.Play(grabObjectSound, dogHeadForIndex.mouthTransform.position);
	}

	private void CreateMouthJoints(int chosenHeadIndex)
	{
		DogHead dogHeadForIndex = faceControllerRef.GetDogHeadForIndex(chosenHeadIndex);
		Vector3 anchor = dogHeadForIndex.mouthJointBody.transform.InverseTransformPoint(dogHeadForIndex.mouthTransform.position);
		ConfigurableJoint configurableJoint = dogHeadForIndex.mouthJointBody.gameObject.AddComponent<ConfigurableJoint>();
		configurableJoint.anchor = anchor;
		configurableJoint.xMotion = ConfigurableJointMotion.Locked;
		configurableJoint.yMotion = ConfigurableJointMotion.Locked;
		configurableJoint.zMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Limited;
		SoftJointLimitSpring softJointLimitSpring = new SoftJointLimitSpring
		{
			spring = 0f,
			damper = 1f
		};
		configurableJoint.angularXLimitSpring = softJointLimitSpring;
		configurableJoint.angularYZLimitSpring = softJointLimitSpring;
		SoftJointLimit lowAngularXLimit = default(SoftJointLimit);
		SoftJointLimit highAngularXLimit = default(SoftJointLimit);
		SoftJointLimit softJointLimit = default(SoftJointLimit);
		float num = 2f;
		lowAngularXLimit.limit = 0f - num;
		highAngularXLimit.limit = num;
		softJointLimit.limit = num;
		configurableJoint.lowAngularXLimit = lowAngularXLimit;
		configurableJoint.highAngularXLimit = highAngularXLimit;
		configurableJoint.angularYLimit = softJointLimit;
		configurableJoint.angularZLimit = softJointLimit;
		configurableJoint.enablePreprocessing = false;
		configurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
		configurableJoint.projectionAngle = 1f;
		configurableJoint.projectionDistance = 0.1f;
		configurableJoint.breakTorque = 100000f;
		configurableJoint.breakForce = 100000f;
		mouthJoints.Add(configurableJoint);
		breakValuesTimer = breakValuesTimerMax;
	}

	private void AssignBreakValues()
	{
		for (int i = 0; i < mouthJoints.Count; i++)
		{
			if (faceControllerRef.OldHead())
			{
				mouthJoints[i].breakTorque = breakTorque * 2f;
				mouthJoints[i].breakForce = breakForce * 2f;
			}
			else
			{
				mouthJoints[i].breakTorque = breakTorque;
				mouthJoints[i].breakForce = breakForce;
			}
		}
		breakValuesTimer = 0f;
	}

	public int GetActiveMouthIndex()
	{
		return activeMouthIndex;
	}

	public void DropObject()
	{
		int i = activeMouthIndex;
		activeMouthIndex = 0;
		InteractableBase interactableBase = null;
		if (heldObject != null)
		{
			interactableBase = heldObject.transform.root.GetComponent<InteractableBase>();
			if (interactableBase != null)
			{
				interactableBase.OnObjectDroppedByDog(base.gameObject);
			}
			ObjectConnectionsManager.OnObjectDroppedByDog(base.gameObject, heldObject.transform.root.gameObject);
		}
		breakValuesTimer = 0f;
		if (mouthJoints.Count == 0)
		{
			heldObject = null;
			return;
		}
		DogHead dogHeadForIndex = faceControllerRef.GetDogHeadForIndex(i);
		RestoreCollision();
		if (heldObject != null && !shuttingDown)
		{
			AudioController.Play(dropObjectSound, dogHeadForIndex.mouthTransform.position);
		}
		heldObject = null;
		for (int j = 0; j < mouthJoints.Count; j++)
		{
			if (mouthJoints[j] != null)
			{
				mouthJoints[j].connectedBody = null;
				Object.Destroy(mouthJoints[j]);
			}
		}
		mouthJoints.Clear();
		if (holdFromBite && interactableBase != null)
		{
			interactableBase.OnObjectBittenByDog(dogHeadForIndex.mouthJointRef.transform.rotation.eulerAngles, base.gameObject);
		}
		if (penFocusRef != null)
		{
			penFocusRef.OnObjectDropped(base.gameObject);
		}
	}

	private void RestoreCollision()
	{
		if (heldColliders.Count == 0)
		{
			return;
		}
		int numberOfDogHeads = faceControllerRef.GetNumberOfDogHeads();
		for (int i = 0; i < heldColliders.Count; i++)
		{
			if (heldColliders[i] == null)
			{
				continue;
			}
			for (int j = 0; j < numberOfDogHeads; j++)
			{
				if (faceControllerRef.OldHead())
				{
					Physics.IgnoreCollision(faceControllerRef.GetDogHeadForIndex(j).faceObject.GetComponent<Collider>(), heldColliders[i], ignore: false);
					continue;
				}
				Physics.IgnoreCollision(faceControllerRef.GetDogHeadForIndex(j).snoutBone.GetComponent<Collider>(), heldColliders[i], ignore: false);
				Physics.IgnoreCollision(faceControllerRef.GetDogHeadForIndex(j).snoutBone.GetComponent<ConfigurableJoint>().connectedBody.GetComponent<Collider>(), heldColliders[i], ignore: false);
			}
		}
		heldColliders.Clear();
	}

	public bool IsCarryingObject()
	{
		return heldObject != null;
	}

	public GameObject GetCarriedObject()
	{
		return heldObject;
	}

	public float GetCarriedWeight()
	{
		if (heldObject == null || mouthJoints.Count == 0)
		{
			return 0f;
		}
		return mouthJoints[0].connectedBody.mass;
	}

	public void OnDie()
	{
		DropObject();
		isDead = true;
	}
}
