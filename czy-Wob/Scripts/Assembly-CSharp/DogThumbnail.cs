using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DogThumbnail : MonoBehaviour
{
	public Image selector;

	public Image thumbnailBox;

	public GameObject enterCocoonButton;

	public Image dogThumbnailRenderer;

	public GameObject hungerIcon;

	public GameObject energyIcon;

	public GameObject stressIcon;

	public GameObject angerIcon;

	public GameObject boredomIcon;

	private GameObject currentIcon;

	private ThumbnailSet thumbSet;

	private float lastClickTime = -100f;

	private float doubleClickWindow = 0.3f;

	private bool isSelected;

	private ulong associatedDogID;

	private DoggyBrain associatedBrain;

	private FaceController associatedFace;

	private Face lastFace;

	private Sprite currentDisplayFace;

	private Coroutine currentDelayedActivationRoutine;

	private PenFocus focusRef;

	private DogRegistration dogRegRef;

	private DogThumbnailController controllerRef;

	private void Awake()
	{
		focusRef = Camera.main.GetComponent<PenFocus>();
		selector.enabled = false;
	}

	public void SetDog(DogRegistration regRef, ulong dogID, DogThumbnailController newControllerRef)
	{
		associatedDogID = dogID;
		controllerRef = newControllerRef;
		angerIcon.SetActive(value: false);
		hungerIcon.SetActive(value: false);
		energyIcon.SetActive(value: false);
		stressIcon.SetActive(value: false);
		boredomIcon.SetActive(value: false);
		dogRegRef = regRef;
		SetDogRefs();
		thumbSet = dogRegRef.GrabExistingThumbnailSetForDogID(dogID, controllerRef);
		enterCocoonButton.SetActive(value: false);
		if (regRef.GetSaveableDogFromID(dogID).inCocoon)
		{
			currentDisplayFace = newControllerRef.cocoonPortraitSpriteLowRes;
			dogThumbnailRenderer.sprite = newControllerRef.cocoonPortraitSpriteLowRes;
		}
		else
		{
			currentDisplayFace = thumbSet.defaultThumb;
			dogThumbnailRenderer.sprite = thumbSet.defaultThumb;
		}
	}

	public void Refresh()
	{
		SetDog(dogRegRef, associatedDogID, controllerRef);
	}

	private void SetDogRefs()
	{
		if (!dogRegRef.GetSaveableDogFromID(associatedDogID).inCocoon)
		{
			GameObject dogFromID = dogRegRef.GetDogFromID(associatedDogID);
			if (dogFromID == null)
			{
				Debug.LogError("No dog found for dogID: " + associatedDogID + " inside of SetDog()");
				return;
			}
			associatedBrain = dogFromID.GetComponent<DoggyBrain>();
			associatedFace = dogFromID.GetComponent<FaceController>();
		}
	}

	private void Update()
	{
		UpdateNeedIcons();
		UpdateEmotionDisplay();
	}

	public ulong GetAssociatedDogID()
	{
		return associatedDogID;
	}

	public void SetSelected(bool selectedVal)
	{
		isSelected = selectedVal;
		selector.enabled = isSelected;
	}

	public void SetCocoonableState(bool newState)
	{
		if (newState)
		{
			enterCocoonButton.SetActive(value: true);
		}
		else
		{
			enterCocoonButton.SetActive(value: false);
		}
	}

	private void UpdateNeedIcons()
	{
		if (associatedBrain == null)
		{
			SetDogRefs();
		}
		if (associatedBrain == null || !associatedBrain.isInitialized())
		{
			return;
		}
		GameObject gameObject = null;
		switch (associatedBrain.GetCurrentNeed(closeToFailure: true))
		{
		case Need.Hunger:
			gameObject = hungerIcon;
			break;
		case Need.Energy:
			gameObject = energyIcon;
			break;
		case Need.Anger:
			gameObject = angerIcon;
			break;
		case Need.Stress:
			gameObject = stressIcon;
			break;
		case Need.Boredom:
			gameObject = boredomIcon;
			break;
		}
		if (currentIcon != gameObject)
		{
			if (currentIcon != null)
			{
				currentIcon.SetActive(value: false);
			}
			currentIcon = gameObject;
			if (currentIcon != null)
			{
				currentIcon.SetActive(value: true);
			}
		}
	}

	private void UpdateEmotionDisplay()
	{
		if (!(associatedFace == null))
		{
			Face currentFace = associatedFace.GetCurrentFace();
			if (currentFace != lastFace)
			{
				lastFace = currentFace;
				currentDisplayFace = thumbSet.defaultThumb;
			}
		}
	}

	public ThumbnailSet GetThumbnailSet()
	{
		return thumbSet;
	}

	public Sprite GetCurrentDisplayFace()
	{
		return currentDisplayFace;
	}

	public Sprite GetDefaultDisplayFace()
	{
		return thumbSet.defaultThumb;
	}

	public void OnMutateButtonClicked()
	{
		if (currentDelayedActivationRoutine == null)
		{
			currentDelayedActivationRoutine = StartCoroutine(DelayedCocoonButtonPress());
		}
	}

	public IEnumerator DelayedCocoonButtonPress()
	{
		yield return new WaitForEndOfFrame();
		if (associatedBrain.GetComponent<CocoonController>().EnterCocoon())
		{
			enterCocoonButton.SetActive(value: false);
		}
		currentDelayedActivationRoutine = null;
	}

	public void ThumbnailClicked()
	{
		controllerRef.OnDogSelected(associatedDogID);
		float time = Time.time;
		if (time - lastClickTime <= doubleClickWindow)
		{
			lastClickTime = -100f;
			controllerRef.FocusOnSelectedDog();
		}
		else if (!focusRef.FollowCamActive())
		{
			bool inCocoon = dogRegRef.GetSaveableDogFromID(associatedDogID).inCocoon;
			GameObject gameObject = dogRegRef.GetDogFromID(associatedDogID);
			if (inCocoon)
			{
				gameObject = controllerRef.GetCocoonForDogID(associatedDogID);
			}
			DogDenController component = gameObject.GetComponent<DogDenController>();
			if (component != null && component.IsInDen())
			{
				focusRef.FocusOnDen(component.GetCurrentlyOccupiedDenObject());
			}
			else
			{
				ulong? roomUID = gameObject.GetComponent<BoundingBoxComponent>().GetRoomUID();
				if (roomUID.HasValue)
				{
					focusRef.SetLastFocusedRoom(roomUID.Value, refocusAllowed: false);
				}
			}
		}
		lastClickTime = time;
	}
}
