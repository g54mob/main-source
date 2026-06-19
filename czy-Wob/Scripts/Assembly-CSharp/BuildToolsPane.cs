using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildToolsPane : PaneBase
{
	public CoreButtonUnityGUI newRoomButton;

	public Image newRoomButtonSprite;

	public TextMeshProUGUI remainingRoomsText;

	public Image remainingRoomsHolderSprite;

	public Color roomButtonActiveColor = Color.white;

	public Color roomButtonInactiveColor = new Color(0f, 0f, 0f, 0.5f);

	public Color moreRoomsRemainingColor;

	public Color noRoomsRemainingColor;

	public GameObject roomHighlightGraphic;

	public GameObject pipeHighlightGraphic;

	public GameObject moveHighlightGraphic;

	public GameObject destroyHighlightGraphic;

	private float slideInTime = 0.1f;

	private float slideOutTime = 0.1f;

	private Vector3 slideVector = new Vector3(2f, 0f, 0f);

	private ConstructionManager.SubMode currentModeHighlight;

	private DogHome homeRef;

	private ConstructionManager constructionRef;

	protected override void LoadBehavior()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		homeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		CancelCurrentEase();
		if (inchwormRef != null)
		{
			currentEase = inchwormRef.RequestEase(base.gameObject, slideVector, slideInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnLoadComplete);
		}
		UpdateRoomButton();
		HighlightToolForSubMode(ConstructionManager.SubMode.STANDARD);
	}

	protected override void UnloadBehavior()
	{
		CancelCurrentEase();
		currentEase = inchwormRef.RequestEase(base.gameObject, -slideVector, slideOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnUnloadComplete);
	}

	public void OnDestroyButtonClicked()
	{
		constructionRef.OnDestroyButtonClicked();
	}

	public void OnMoveButtonClicked()
	{
		constructionRef.OnMoveButtonClicked();
	}

	public void OnNewPipeButtonClicked()
	{
		constructionRef.OnNewPipeButtonClicked();
	}

	public void OnNewRoomButtonClicked(BuildableObject penType)
	{
		constructionRef.BuildSpecificRoom(penType);
	}

	public void HighlightToolForSubMode(ConstructionManager.SubMode mode)
	{
		switch (currentModeHighlight)
		{
		case ConstructionManager.SubMode.NEW_ROOM_SELECTION:
			roomHighlightGraphic.SetActive(value: false);
			break;
		case ConstructionManager.SubMode.NEW_ROOM_BUILDING:
			roomHighlightGraphic.SetActive(value: false);
			break;
		case ConstructionManager.SubMode.NEW_PIPE:
			pipeHighlightGraphic.SetActive(value: false);
			break;
		case ConstructionManager.SubMode.STANDARD:
			moveHighlightGraphic.SetActive(value: false);
			break;
		case ConstructionManager.SubMode.DESTROY:
			destroyHighlightGraphic.SetActive(value: false);
			break;
		}
		switch (mode)
		{
		case ConstructionManager.SubMode.NEW_ROOM_SELECTION:
			roomHighlightGraphic.SetActive(value: true);
			break;
		case ConstructionManager.SubMode.NEW_ROOM_BUILDING:
			roomHighlightGraphic.SetActive(value: true);
			break;
		case ConstructionManager.SubMode.NEW_PIPE:
			pipeHighlightGraphic.SetActive(value: true);
			break;
		case ConstructionManager.SubMode.STANDARD:
			moveHighlightGraphic.SetActive(value: true);
			break;
		case ConstructionManager.SubMode.DESTROY:
			destroyHighlightGraphic.SetActive(value: true);
			break;
		}
		currentModeHighlight = mode;
	}

	public bool CanPlaceMoreRooms()
	{
		int numberOfAllowedPens = homeRef.GetNumberOfAllowedPens();
		if (constructionRef.GetNumberOfCreatedRooms() >= numberOfAllowedPens)
		{
			return false;
		}
		return true;
	}

	public void UpdateRoomButton()
	{
		if (!(homeRef == null))
		{
			int numberOfAllowedPens = homeRef.GetNumberOfAllowedPens();
			int numberOfCreatedRooms = constructionRef.GetNumberOfCreatedRooms();
			int num = numberOfAllowedPens - numberOfCreatedRooms;
			if (numberOfCreatedRooms > numberOfAllowedPens)
			{
				num = 0;
				Debug.LogError("Somehow have more rooms than is allowed!");
			}
			remainingRoomsText.text = num.ToString();
			if (num <= 0)
			{
				newRoomButton.enabled = false;
				newRoomButton.useGlobalGUIActiveStatus = false;
				newRoomButtonSprite.color = roomButtonInactiveColor;
				remainingRoomsHolderSprite.color = noRoomsRemainingColor;
			}
			else
			{
				newRoomButton.enabled = true;
				newRoomButton.useGlobalGUIActiveStatus = true;
				newRoomButtonSprite.color = roomButtonActiveColor;
				remainingRoomsHolderSprite.color = moreRoomsRemainingColor;
			}
		}
	}
}
