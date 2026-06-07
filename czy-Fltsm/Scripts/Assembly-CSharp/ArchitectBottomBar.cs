using PajamaLlama.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ArchitectBottomBar : Panel, ICancelable
{
	[SerializeField]
	private MoveBuildableCursorProperties _cursorProperties;

	[SerializeField]
	private RewiredComponent _applyComponent;

	[SerializeField]
	private Button _revertButton;

	[SerializeField]
	private TextMeshProUGUI _counter;

	[SerializeField]
	private GameObject[] _gameObjectsToDisable;

	[SerializeField]
	private DPad _dPad;

	[SerializeField]
	private DPadProperties _dPadProperties;

	[SerializeField]
	[FormerlySerializedAs("_applyDialogProperties")]
	private DialogProperties _applyStoredDialogProperties;

	[SerializeField]
	private DialogProperties _applyPlacingDialogProperties;

	[SerializeField]
	private DialogProperties _revertDialogProperties;

	private Community _community;

	private CursorManager _cursorManager;

	private int StoredBuildableCount
	{
		get
		{
			if (_community == null)
			{
				return 0;
			}
			return _community.ReturnStoredBuildablesCount();
		}
	}

	private void OnEnable()
	{
		_revertButton.interactable = PersistenceManager.TryTakeSnapShot();
		_community = Community.PlayerCommunity;
		_community.OnStoredBuildableAdded.AddListener(OnStoredBuildableAdded);
		_community.OnStoredBuildableRemoved.AddListener(OnStoredBuildableRemoved);
		_counter.text = StoredBuildableCount.ToString();
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		DisableGameObjects();
		if ((bool)_dPad)
		{
			_dPad.OverrideDPadProperties(_dPadProperties);
		}
		_cursorManager = GameManager.CursorManager;
		_cursorManager?.Activate(_cursorProperties);
		FlotsamInputManager.PushCancelable(this);
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		GameObject[] gameObjectsToDisable = _gameObjectsToDisable;
		for (int i = 0; i < gameObjectsToDisable.Length; i++)
		{
			gameObjectsToDisable[i].SetActive(value: true);
		}
		if ((bool)_dPad)
		{
			_dPad.RemoveOverrideDPadProperties(_dPadProperties);
		}
		_cursorManager?.Deactivate();
		FlotsamInputManager.RemoveCancelable(this);
	}

	private void OnActiveInputUpdated(GameEvent gameEvent)
	{
		FinalUpdate.RegisterOneShot(DisableGameObjects);
	}

	private void DisableGameObjects()
	{
		GameObject[] gameObjectsToDisable = _gameObjectsToDisable;
		for (int i = 0; i < gameObjectsToDisable.Length; i++)
		{
			gameObjectsToDisable[i].SetActive(value: false);
		}
	}

	private void OnStoredBuildableAdded(IPlaceable placeable, bool toggleCategory)
	{
		_counter.text = StoredBuildableCount.ToString();
	}

	private void OnStoredBuildableRemoved(IPlaceable placeable)
	{
		_counter.text = StoredBuildableCount.ToString();
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (UIManager.AllowArchitectMode)
		{
			return base.Open(id, context);
		}
		return false;
	}

	public override void Close()
	{
		base.Close();
		GameManager.UIManager.ClosePanel(PanelID.ArchitectBuildableCreation);
		GameManager.UIManager.ClosePanel(PanelID.BuildableCreation);
	}

	public void Apply()
	{
		if (!_applyComponent.IsMappedToUICancel() || (!GameManager.UIManager.IsPanelOpen(PanelID.ArchitectBuildableCreation) && !GameManager.UIManager.IsPanelOpen(PanelID.BuildableCreation)))
		{
			if (_cursorProperties.BlocksApply)
			{
				PopUpDialog.Instance.TryOpenPopUpDialog(_applyPlacingDialogProperties);
			}
			else if (_community.ReturnStoredBuildablesCount(onlyBuildings: true) <= 0)
			{
				GameManager.UIManager.ClosePanel(PanelID.ArchitectBottomBar);
				GameManager.CursorManager.Deactivate(cancelled: true);
				PersistenceManager.ClearSnapShot();
			}
			else if (PopUpDialog.Instance.TryOpenPopUpDialog(_applyStoredDialogProperties))
			{
				PopUpDialog.Instance.DialogFeedbackEvent.AddListener(OnRevertDialogFeedback);
			}
		}
	}

	public void Revert()
	{
		if (PopUpDialog.Instance.TryOpenPopUpDialog(_revertDialogProperties))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(OnRevertDialogFeedback);
		}
	}

	private void OnRevertDialogFeedback(bool revert)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(OnRevertDialogFeedback);
		if (revert)
		{
			if (PersistenceManager.SetRestoreSnapShot())
			{
				_cursorProperties.OnRevert();
				LoadingScreen.LoadScene("_02_GameWorld");
			}
			else
			{
				Debug.LogError("Unable to restore Snap Shot!");
			}
		}
	}

	public bool TryCancel()
	{
		return false;
	}
}
