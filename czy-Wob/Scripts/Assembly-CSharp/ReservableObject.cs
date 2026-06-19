using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReservableObject : MonoBehaviour
{
	public delegate void ReserveBehaviorFinishedCallback();

	public ReservableObjectType objectType;

	public Transform targetPoint;

	public float behaviorScoreMultiplier = 1f;

	public UnityEvent onReserveEvents;

	public UnityEvent onConfirmEvents;

	public UnityEvent onReleaseEvents;

	public GameObject tutorialArrow;

	protected bool inTutorialMode;

	private BoundingBoxComponent triggerBBC;

	private Transform temporaryTargetTransform;

	protected ReserveBehaviorFinishedCallback currentCallback;

	protected ulong UID;

	protected ulong? currentUser;

	protected List<ulong?> currentReservations = new List<ulong?>();

	protected DogRegistration dogRegRef;

	private void Awake()
	{
		if (tutorialArrow != null)
		{
			tutorialArrow.SetActive(value: false);
		}
	}

	public void SetUID(ulong newUID)
	{
		UID = newUID;
	}

	public ulong GetUID()
	{
		return UID;
	}

	private void Update()
	{
		UpdateBehavior();
	}

	public void SetTutorialArrowState(bool val)
	{
		tutorialArrow.SetActive(val);
	}

	public void SetTutorialMode(bool val)
	{
		inTutorialMode = val;
	}

	protected virtual void UpdateBehavior()
	{
		AlignTargetTransform();
		CheckUserBoundingBox();
	}

	private void OnEnable()
	{
		EnableBehavior();
	}

	protected virtual void EnableBehavior()
	{
		temporaryTargetTransform = new GameObject().transform;
		AlignTargetTransform();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		registrationScript.RegisterReservableObject(this);
	}

	private void OnDisable()
	{
		DisableBehavior();
	}

	protected virtual void DisableBehavior()
	{
		if (temporaryTargetTransform != null)
		{
			Object.Destroy(temporaryTargetTransform.gameObject);
			temporaryTargetTransform = null;
		}
		ObjectRegistration.GetRegistrationScript().UnregisterReservableObject(this);
	}

	public void SetTriggerBBC(BoundingBoxComponent newBBC)
	{
		triggerBBC = newBBC;
	}

	private void AlignTargetTransform()
	{
		if (!(temporaryTargetTransform == null))
		{
			temporaryTargetTransform.position = targetPoint.position;
		}
	}

	public Transform GetTargetTransform()
	{
		return temporaryTargetTransform;
	}

	public int GetNumberOfReservations()
	{
		return currentReservations.Count;
	}

	public bool CanReserveObject(ulong dogID)
	{
		if (currentUser == dogID || !currentUser.HasValue)
		{
			return true;
		}
		return false;
	}

	public void UseObject(ulong dogID)
	{
		if (currentUser.HasValue)
		{
			dogRegRef.GetDogFromID(dogID).GetComponent<DogAI>().ForceInterruptBehavior();
			Debug.LogError(dogID + " attempting to use an object that's already in use by " + currentUser + "!");
			return;
		}
		if (currentReservations.Contains(dogID))
		{
			RemoveReservation(dogID);
		}
		currentUser = dogID;
		for (int num = currentReservations.Count - 1; num >= 0; num--)
		{
			dogRegRef.GetDogFromID(currentReservations[num].Value).GetComponent<DogAI>().ForceInterruptBehavior();
		}
	}

	public void ReserveObject(ulong dogID)
	{
		if (!CanReserveObject(dogID))
		{
			Debug.LogError("Attempting to reserve an object that cannot be reserved at this moment: " + dogID);
			return;
		}
		if (currentReservations.Contains(dogID))
		{
			Debug.LogError("Attempting to double-reserve an object: " + dogID);
			return;
		}
		currentReservations.Add(dogID);
		OnReserve();
	}

	public void RemoveReservation(ulong dogID)
	{
		if (currentReservations.Contains(dogID))
		{
			currentReservations.Remove(dogID);
		}
	}

	public virtual void OnConfirm(ulong dogID, ReserveBehaviorFinishedCallback callbackRef)
	{
		onConfirmEvents.Invoke();
		currentCallback = callbackRef;
		UseObject(dogID);
		MainObjectBehavior();
	}

	public void ReleaseObject(ulong dogID)
	{
		if (currentUser.HasValue)
		{
			if (currentUser != dogID)
			{
				Debug.LogError("Attempting to release an object that's currently being used by another dog: " + dogID + " (releaser) " + currentUser + " (current user)");
			}
			else
			{
				currentUser = null;
				OnRelease();
			}
		}
	}

	public bool IsDogUsingObject(ulong dogID)
	{
		return dogID == currentUser;
	}

	public virtual void OnTriggerStayReported(GameObject rootObj)
	{
		if (!currentUser.HasValue && rootObj.CompareTag(Tags.DOG))
		{
			ReservableObject targetReservableObject = rootObj.GetComponent<DogAI>().GetTargetReservableObject();
			if (!(targetReservableObject == null) && targetReservableObject.objectType == objectType && BoundingBoxTriggerCheck(rootObj, triggerBBC, requireContainment: true))
			{
				rootObj.GetComponent<WalkController>().ReportReservationObject(this);
			}
		}
	}

	public virtual void CheckUserBoundingBox()
	{
		if (currentUser.HasValue)
		{
			GameObject dogFromID = dogRegRef.GetDogFromID(currentUser.Value);
			if (!BoundingBoxTriggerCheck(dogFromID, triggerBBC, requireContainment: false))
			{
				dogFromID.GetComponent<DogAI>().ForceInterruptBehavior();
			}
		}
	}

	private bool BoundingBoxTriggerCheck(GameObject dog, BoundingBoxComponent bbc, bool requireContainment)
	{
		BoundingBoxComponent component = dog.GetComponent<BoundingBoxComponent>();
		if (requireContainment)
		{
			return component.CheckBoxContained(bbc);
		}
		return bbc.CheckBoxIntersect(component);
	}

	protected virtual void OnReserve()
	{
		onReserveEvents.Invoke();
	}

	protected virtual void OnRelease()
	{
		onReleaseEvents.Invoke();
	}

	public float GetBehaviorScoreMultiplier(DogBehaviorReserveEnum behaviorEnum)
	{
		return behaviorScoreMultiplier;
	}

	protected virtual void MainObjectBehavior()
	{
		currentCallback();
		currentCallback = null;
	}
}
