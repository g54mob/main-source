using UnityEngine;

public class RewiredDrifterOverview : RewiredComponent, IUIFlagsProvider
{
	[Header("Rewired Drifter Overview")]
	[SerializeField]
	private DrifterOverview _drifterOverview;

	[SerializeField]
	private RewiredComponent _upAction;

	[SerializeField]
	private RewiredComponent _downAction;

	[SerializeField]
	private GameObject _spacer;

	[SerializeField]
	private PanelContainerFlags _uiFlags;

	public PanelContainerFlags Flags => _uiFlags;

	public bool BlockCancel => false;

	protected override void Awake()
	{
		base.Awake();
		GameEventDispatcher.AddListener(GameEventType.UIFlagsUpdated, UpdateEndabled);
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, UpdateEndabled);
		UpdateEndabled();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		base.ActionImage.gameObject.SetActive(base.Interactable);
		_spacer.SetActive(base.Interactable);
		if (base.Interactable)
		{
			_drifterOverview.HideOverview();
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		OnButtonUp();
		_spacer.SetActive(value: false);
		if (!HasInteractableInput())
		{
			_drifterOverview.ShowOverview();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.UIFlagsUpdated, UpdateEndabled);
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, UpdateEndabled);
	}

	protected override void OnButtonDown()
	{
		if (!UIManager.HasFlagsSet(PanelContainerFlags.BlockDrifterOverview))
		{
			base.ActionImage.gameObject.SetActive(value: false);
			_spacer.SetActive(value: false);
			_upAction.gameObject.SetActive(value: true);
			_downAction.gameObject.SetActive(value: true);
			_drifterOverview.ShowOverview();
			UIManager.AddFlagsProvider(this);
		}
	}

	protected override void OnButtonUp()
	{
		_upAction.gameObject.SetActive(value: false);
		_downAction.gameObject.SetActive(value: false);
		_drifterOverview.HideOverview();
		base.ActionImage.gameObject.SetActive(base.Interactable);
		_spacer.SetActive(base.Interactable);
		UIManager.RemoveFlagsProvider(this);
	}

	private void UpdateEndabled(GameEvent gameEvent = null)
	{
		base.enabled = HasInteractableInput() && !UIManager.HasFlagsSet(PanelContainerFlags.BlockDrifterOverview);
	}
}
