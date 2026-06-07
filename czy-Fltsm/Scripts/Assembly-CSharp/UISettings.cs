using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flotsam/Settings/UI Settings")]
public class UISettings : ScriptableObject
{
	[Serializable]
	internal struct CursorTexture
	{
		[SerializeField]
		internal CursorState State;

		[SerializeField]
		internal Texture2D Texture;
	}

	[Header("UI Scale")]
	[SerializeField]
	private Vector2 _referenceResolution = new Vector2(1920f, 1080f);

	[SerializeField]
	[Range(0f, 1f)]
	private float _matchWidthOrHeight = 0.5f;

	[SerializeField]
	private CanvasScaler.ScreenMatchMode _screenMatchMode;

	[Header("General")]
	[SerializeField]
	private float _tooltipDelay = 0.5f;

	[SerializeField]
	private LayerMask _selectionMask;

	[SerializeField]
	private AssignmentIcon _assignmentPrefab;

	[SerializeField]
	[Tooltip("Adds a \"MISSING LOCALIZATION\" text at the end of any localizedString in game that's using a fallback text")]
	private bool _showMissingLocalizationWarnings;

	[Header("Panels")]
	[SerializeField]
	private AssignmentPanelEntry _assignmentPanelEntryPrefab;

	[SerializeField]
	private MarkerOrderPanelEntry _markerOrderPanelEntryPrefab;

	[SerializeField]
	private MarkerIcon _markerIconPrefab;

	[SerializeField]
	private DietIcon _dietIconsPrefab;

	[Header("Dialog Panels")]
	[SerializeField]
	private DialogProperties _salvageWarningDialogProperties;

	[SerializeField]
	private DialogProperties _missingRequiredFieldDialogProperties;

	[SerializeField]
	private DialogProperties _saveSuccessfulDialogProperties;

	[SerializeField]
	private DialogProperties _saveFailedDialogProperties;

	[SerializeField]
	private DialogProperties _revertChangesDialogProperties;

	[SerializeField]
	private DialogProperties _externalLinkDialogProperties;

	[SerializeField]
	private DialogProperties _freeSeagullDialogProperties;

	[Space]
	[SerializeField]
	private DialogProperties _oldSeagullLandmarkProperties;

	[SerializeField]
	private DialogProperties _seagullsUpdatedProperties;

	[Space]
	[SerializeField]
	private SaveDialogProperties _overwriteSaveProperties;

	[Header("Input Panels")]
	[SerializeField]
	private DialogProperties _inputFeedback;

	[SerializeField]
	private DialogProperties _inputNameChange;

	[SerializeField]
	private DialogProperties _inputNameChangeAgent;

	[SerializeField]
	private DialogProperties _inputSaveName;

	[Header("Notifications")]
	[SerializeField]
	private NotificationProperties _drifterJoinedNotification;

	[SerializeField]
	private NotificationProperties _drifterNoFoodNotification;

	[SerializeField]
	private NotificationProperties _drifterNoWaterNotification;

	[Space]
	[SerializeField]
	private NotificationProperties _seagullJoinedNotification;

	[SerializeField]
	private NotificationProperties _seagullLeftNotification;

	[Space]
	[SerializeField]
	private NotificationProperties _researchFinishedNotification;

	[SerializeField]
	private NotificationProperties _boatAbandonedNotification;

	[SerializeField]
	private NotificationProperties _buildableFinishedNotification;

	[SerializeField]
	private NotificationProperties _salvageMarkerFinishedNotification;

	[SerializeField]
	private NotificationProperties _fishingMarkerFinishedNotification;

	[SerializeField]
	private NotificationProperties _landmarkSalvagedNotification;

	[SerializeField]
	private NotificationProperties _researchUnlockedNotification;

	[SerializeField]
	private NotificationProperties _salvageRadiusIncreasedNotification;

	[SerializeField]
	private NotificationProperties _dailyReportAvailableNotification;

	[SerializeField]
	private NotificationProperties _levelUpNotification;

	[SerializeField]
	private NotificationProperties _unlockableRecipeNotification;

	[Header("Tooltip")]
	[SerializeField]
	private GameObject _constructionTooltipSlot;

	[Header("Energy Panel")]
	[SerializeField]
	private EnergyItemProducerOverviewUI _energyItemProducerOverviewUIPrefab;

	[SerializeField]
	private EnergyManualProducerOverviewUI _energyManualProducerOverviewUIPrefab;

	[SerializeField]
	private EnergyPassiveOverviewUI _energyPassiveOverviewUIPrefab;

	[SerializeField]
	private EnergyStorageOverviewUI _energyStorageOverviewUIPrefab;

	[SerializeField]
	private ProducerOverviewUI _producerOverviewUIPrefab;

	[SerializeField]
	private ResearchStationEnergyOverviewUI _researchStationEnergyOverviewUIPrefab;

	[SerializeField]
	[HideInInspector]
	private PersistentNotificationProperties _notificationProperties;

	public float TooltipDelay => _tooltipDelay;

	public LayerMask SelectionMask => _selectionMask;

	public AssignmentIcon AssignmentPrefab => _assignmentPrefab;

	public bool ShowMissingLocalizationWarnings => _showMissingLocalizationWarnings;

	public AssignmentPanelEntry AssignmentPanelEntryPrefab => _assignmentPanelEntryPrefab;

	public MarkerOrderPanelEntry MarkerOrderPanelEntryPrefab => _markerOrderPanelEntryPrefab;

	public MarkerIcon MarkerIconPrefab => _markerIconPrefab;

	public DietIcon DietIconsPrefab => _dietIconsPrefab;

	public DialogProperties SalvageWarningDialogProperties => _salvageWarningDialogProperties;

	public DialogProperties MissingRequiredFieldDialogProperties => _missingRequiredFieldDialogProperties;

	public DialogProperties SaveSuccessfulDialogProperties => _saveSuccessfulDialogProperties;

	public DialogProperties SaveFailedDialogProperties => _saveFailedDialogProperties;

	public DialogProperties RevertChangesDialogProperties => _revertChangesDialogProperties;

	public DialogProperties ExternalLinkDialogProperties => _externalLinkDialogProperties;

	public DialogProperties FreeSeagullDialogProperties => _freeSeagullDialogProperties;

	public DialogProperties OldSeagullLandmarkProperties => _oldSeagullLandmarkProperties;

	public DialogProperties SeagullsUpdatedProperties => _seagullsUpdatedProperties;

	public SaveDialogProperties OverwriteSaveProperties => _overwriteSaveProperties;

	public DialogProperties InputFeedback => _inputFeedback;

	public DialogProperties InputNameChange => _inputNameChange;

	public DialogProperties InputNameChangeAgent => _inputNameChangeAgent;

	public DialogProperties InputSaveName => _inputSaveName;

	public NotificationProperties DrifterJoinedNotification => _drifterJoinedNotification;

	public NotificationProperties DrifterNoFoodNotification => _drifterNoFoodNotification;

	public NotificationProperties DrifterNoWaterNotification => _drifterNoWaterNotification;

	public NotificationProperties SeagullJoinedNotification => _seagullJoinedNotification;

	public NotificationProperties SeagullLeftNotification => _seagullLeftNotification;

	public NotificationProperties ResearchFinishedNotification => _researchFinishedNotification;

	public NotificationProperties BoatAbandonedNotification => _boatAbandonedNotification;

	public NotificationProperties BuildableFinishedNotification => _buildableFinishedNotification;

	public NotificationProperties SalvageMarkerFinishedNotification => _salvageMarkerFinishedNotification;

	public NotificationProperties FishingMarkerFinishedNotification => _fishingMarkerFinishedNotification;

	public NotificationProperties LandmarkSalvagedNotification => _landmarkSalvagedNotification;

	public NotificationProperties ResearchUnlockedNotification => _researchUnlockedNotification;

	public NotificationProperties SalvageRadiusIncreasedNotification => _salvageRadiusIncreasedNotification;

	public NotificationProperties DailyReportAvailableNotification => _dailyReportAvailableNotification;

	public NotificationProperties LevelUpNotification => _levelUpNotification;

	public NotificationProperties UnlockableRecipeNotification => _unlockableRecipeNotification;

	public GameObject ConstructionTooltipSlot => _constructionTooltipSlot;

	public EnergyItemProducerOverviewUI EnergyItemProducerOverviewUIPrefab => _energyItemProducerOverviewUIPrefab;

	public EnergyManualProducerOverviewUI EnergyManualProducerOverviewUIPrefab => _energyManualProducerOverviewUIPrefab;

	public EnergyPassiveOverviewUI EnergyPassiveOverviewUIPrefab => _energyPassiveOverviewUIPrefab;

	public EnergyStorageOverviewUI EnergyStorageOverviewUIPrefab => _energyStorageOverviewUIPrefab;

	public ProducerOverviewUI ProducerOverviewUIPrefab => _producerOverviewUIPrefab;

	public ResearchStationEnergyOverviewUI ResearchStationEnergyOverviewUIPrefab => _researchStationEnergyOverviewUIPrefab;

	public PersistentNotificationProperties NotificationProperties => _notificationProperties;

	public float ReturnDefaultUIScale()
	{
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		float result = 0f;
		switch (_screenMatchMode)
		{
		case CanvasScaler.ScreenMatchMode.MatchWidthOrHeight:
		{
			float a = Mathf.Log(vector.x / _referenceResolution.x, 2f);
			float b = Mathf.Log(vector.y / _referenceResolution.y, 2f);
			float p = Mathf.Lerp(a, b, _matchWidthOrHeight);
			result = Mathf.Pow(2f, p);
			break;
		}
		case CanvasScaler.ScreenMatchMode.Expand:
			result = Mathf.Min(vector.x / _referenceResolution.x, vector.y / _referenceResolution.y);
			break;
		case CanvasScaler.ScreenMatchMode.Shrink:
			result = Mathf.Max(vector.x / _referenceResolution.x, vector.y / _referenceResolution.y);
			break;
		}
		return result;
	}
}
