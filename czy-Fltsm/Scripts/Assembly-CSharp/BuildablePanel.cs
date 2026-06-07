using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildablePanel : Panel
{
	[Header("General")]
	[SerializeField]
	private TextMeshProUGUI _name;

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private Image _headerImage;

	[SerializeField]
	private Tooltip _iconTooltip;

	[SerializeField]
	private Tooltip _descriptionTooltip;

	[SerializeField]
	private PanelTabContainer _tabs;

	[Header("Activation")]
	[SerializeField]
	private List<GameObject> _activationObjects = new List<GameObject>();

	[SerializeField]
	private UIInteractableToggle _activationToggle;

	[Tooltip("Parent for the salvage and health objects.")]
	[SerializeField]
	private GameObject _salvageHealthRepairParent;

	[Header("Health")]
	[SerializeField]
	private List<GameObject> _healthObjects = new List<GameObject>();

	[SerializeField]
	private Slider _healthSlider;

	[SerializeField]
	private TextMeshProUGUI _healthText;

	[SerializeField]
	private LocalizedString _healthLocalizedText = "";

	[Header("Salvage")]
	[SerializeField]
	private List<GameObject> _salvagingObjects = new List<GameObject>();

	[SerializeField]
	private Button _salvageButton;

	[SerializeField]
	private Image _salvageButtonIcon;

	[SerializeField]
	private Image _salvageButtonCancelIcon;

	[SerializeField]
	private Tooltip _salvageTooltip;

	[Header("Building")]
	[SerializeField]
	private BuildPanel _buildPanel;

	[Header("Upgrade")]
	[SerializeField]
	private Button _upgradeButton;

	[SerializeField]
	private GameObject _upgradeRequiresResearchIndicator;

	[SerializeField]
	private LocalizedString _upgradeLocalizedText = null;

	[SerializeField]
	private LocalizedString _upgradeCancelLocalizedText = null;

	[SerializeField]
	private TextMeshProUGUI _upgradeText;

	[Header("Tutorial")]
	[SerializeField]
	private GameObject _tutorialButton;

	private bool _active;

	private BuildPhase _buildPhase;

	private readonly List<IBuildablePanelElement> _elements = new List<IBuildablePanelElement>();

	public Buildable Buildable { get; private set; }

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, OnBuildableUpdated);
		GameEventDispatcher.AddListener(GameEventType.BuildableSalvaged, OnBuildableUpdated);
		GameEventDispatcher.AddListener(GameEventType.BuildableUpgraded, OnBuildableUpdated);
		GameEventDispatcher.AddListener(GameEventType.DecorationSelected, OnBuildableUpdated);
	}

	private void Update()
	{
		if (_active)
		{
			UpdatePanel();
		}
	}

	private void LateUpdate()
	{
		if (_active && (bool)Buildable)
		{
			Initialize(Buildable, _buildPhase != Buildable.BuildPhase);
		}
	}

	private void OnDisable()
	{
		Close();
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, OnBuildableUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableSalvaged, OnBuildableUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableUpgraded, OnBuildableUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.DecorationSelected, OnBuildableUpdated);
	}

	private void OnDestroy()
	{
		_activationToggle.ToggleUpdatedEvent -= SwitchActivation;
	}

	public override void Initialize()
	{
		_activationToggle.ToggleUpdatedEvent += SwitchActivation;
		IBuildablePanelElement[] componentsInChildren = GetComponentsInChildren<IBuildablePanelElement>(includeInactive: true);
		foreach (IBuildablePanelElement buildablePanelElement in componentsInChildren)
		{
			if (buildablePanelElement.Id != BuildablePanelElementId.None)
			{
				_elements.Add(buildablePanelElement);
			}
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (context is Buildable buildable && base.Open(id, context))
		{
			Initialize(buildable);
			return true;
		}
		return false;
	}

	public override void Close()
	{
		if (!_active)
		{
			return;
		}
		_active = false;
		foreach (IBuildablePanelElement element in _elements)
		{
			element.Deactivate();
		}
		if ((bool)Buildable)
		{
			Selector.Deselect(Buildable.GetComponentsInChildren<SelectionLink>());
		}
		HideUpgradeTooltip();
		Buildable = null;
		base.Close();
	}

	public void Initialize(Buildable buildable, bool refresh = false)
	{
		if (_active && !refresh && Buildable == buildable)
		{
			return;
		}
		_active = true;
		_buildPhase = buildable.BuildPhase;
		if (Buildable != buildable)
		{
			Buildable = buildable;
			string text = Buildable.Properties.Name + "\n" + Buildable.ReturnDescription();
			_descriptionTooltip.LocalizedText = text;
			_iconTooltip.LocalizedText = text;
			_icon.sprite = Buildable.Properties.IconSprite;
			_headerImage.overrideSprite = Buildable.Properties.HeaderSprite;
			if (buildable.Properties.Upgrade != null)
			{
				UpdateUpgradeButton();
				_upgradeButton.gameObject.SetActive(value: true);
			}
			else
			{
				_upgradeButton.gameObject.SetActive(value: false);
			}
			if (_tutorialButton != null)
			{
				_tutorialButton.SetActive(buildable.Properties.TutorialPageID != TutorialID.None);
			}
		}
		BuildPhase buildPhase = Buildable.BuildPhase;
		bool finished = buildPhase == BuildPhase.Finished || buildPhase == BuildPhase.SalvageShutdown;
		foreach (IBuildablePanelElement element in _elements)
		{
			if (!element.Activate(buildable, finished))
			{
				element.Deactivate();
			}
		}
		ShowConstructionItems(buildable);
		_salvageHealthRepairParent.SetActive(Buildable.Properties.ShowDurabilityElements || Buildable.Properties.ShowActivationElement);
		ActivateElements(_activationObjects, Buildable.Properties.ShowActivationElement);
		ActivateElements(_salvagingObjects, Buildable.Properties.ShowDurabilityElements);
		ActivateElements(_healthObjects, Buildable.Properties.ShowDurabilityElements);
		_tabs.Initialize();
		UpdatePanel();
	}

	public void UpdatePanel()
	{
		_name.text = Buildable.Name;
		if (Buildable.Properties.ShowActivationElement)
		{
			if (Buildable.BuildPhase == BuildPhase.Finished)
			{
				_activationToggle.gameObject.SetActive(value: true);
				if (_activationToggle.isActiveAndEnabled && Buildable.IsActive != _activationToggle.IsOn)
				{
					_activationToggle.Toggle(Buildable.IsActive);
				}
			}
			else
			{
				_activationToggle.gameObject.SetActive(value: false);
			}
		}
		if (Buildable.Properties.ShowDurabilityElements)
		{
			UpdateUpgradeButton();
			if (Buildable.TryReturnBuildableExtendable<WalkwayPonton>(out var _))
			{
				_salvageButton.gameObject.SetActive(value: false);
			}
			else
			{
				_salvageButton.interactable = Buildable.CanBeDeconstructed(out var error);
				_salvageTooltip.LocalizedText = error;
				BuildPhase buildPhase = Buildable.BuildPhase;
				bool flag = buildPhase == BuildPhase.Deconstructing || buildPhase == BuildPhase.HaulFrom || buildPhase == BuildPhase.SalvageShutdown || Buildable.CancelConstructionAfterHaul;
				_salvageButtonIcon.gameObject.SetActive(!flag);
				_salvageButtonCancelIcon.gameObject.SetActive(flag);
			}
			_healthText.text = _healthLocalizedText;
			_healthSlider.value = Buildable.Health;
		}
	}

	private void OnBuildableUpdated(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent && buildableEvent.Buildable == Buildable)
		{
			Initialize(Buildable, refresh: true);
		}
	}

	private void ActivateElements(List<GameObject> objects, bool state)
	{
		for (int i = 0; i < objects.Count; i++)
		{
			objects[i].SetActive(state);
		}
	}

	private void ShowConstructionItems(Buildable buildable)
	{
		switch (buildable.BuildPhase)
		{
		case BuildPhase.Build:
		case BuildPhase.Deconstructing:
		case BuildPhase.HaulTo:
		case BuildPhase.HaulFrom:
			_buildPanel.Initialize(Buildable, buildable.Properties.RequiredResources);
			break;
		case BuildPhase.UpgradeHaulTo:
		case BuildPhase.UpgradeHaulFrom:
			_buildPanel.Initialize(Buildable, buildable.Properties.UpgradeResources);
			break;
		default:
			_buildPanel.Deactivate();
			break;
		}
	}

	public void PopUpNameChange()
	{
		if (Buildable.Community.IsPlayerCommunity() && PopUpDialog.Instance.TryPopUpInput(GameManager.Settings.UISettings.InputNameChange))
		{
			PopUpDialog.Instance.InputEvent += SetBuildableName;
		}
	}

	private void SetBuildableName(string newName, bool dialogFeedback)
	{
		PopUpDialog.Instance.InputEvent -= SetBuildableName;
		if (dialogFeedback)
		{
			Buildable.Name = newName;
			_name.text = Buildable.Name;
		}
	}

	private void UpdateUpgradeButton()
	{
		if (!(Buildable == null) && Buildable.Properties.Upgrade != null)
		{
			bool flag = Buildable.CanUpgrade() || Buildable.BuildPhase == BuildPhase.UpgradeShutdown || Buildable.BuildPhase == BuildPhase.UpgradeHaulTo;
			_upgradeButton.interactable = flag;
			_upgradeText.text = ((Buildable.CanUpgrade() || !flag) ? _upgradeLocalizedText : _upgradeCancelLocalizedText);
			bool flag2 = !Buildable.Properties.Upgrade.IsUnlocked();
			if (_upgradeRequiresResearchIndicator.activeSelf != flag2)
			{
				_upgradeRequiresResearchIndicator.SetActive(flag2);
			}
		}
	}

	public void OpenSurvivalGuidePage()
	{
		new StringEvent(GameEventType.OpenSurvivalGuidePage, Buildable.Properties.SurvivalGuideIdentifier).Dispatch();
	}

	public void OpenTutorialPage()
	{
		TutorialEvent.Dispatch(GameEventType.TutorialPanelPopup, Buildable.Properties.TutorialPageID);
	}

	public void SwitchActivation()
	{
		if (Buildable.IsActive)
		{
			Buildable.Deactivate();
		}
		else
		{
			Buildable.Activate();
		}
		UpdatePanel();
	}

	public void OnClickSalvageButton()
	{
		BuildPhase buildPhase = Buildable.BuildPhase;
		if (buildPhase == BuildPhase.Deconstructing || buildPhase == BuildPhase.SalvageShutdown || Buildable.CancelConstructionAfterHaul)
		{
			Buildable.CancelDeconstruction();
		}
		else
		{
			Buildable.Salvage();
		}
		if (Buildable != null)
		{
			UpdatePanel();
		}
	}

	public void OnClickUpgradeButton()
	{
		BuildPhase buildPhase = Buildable.BuildPhase;
		if (buildPhase == BuildPhase.UpgradeShutdown || buildPhase == BuildPhase.UpgradeHaulTo)
		{
			Buildable.CancelUpgrade();
		}
		else
		{
			Buildable.Upgrade();
		}
		UpdateUpgradeButton();
	}

	public void ShowUpgradeTooltip()
	{
		if ((bool)_upgradeButton)
		{
			Buildable.Properties.ShowUpgradeTooltip(_upgradeButton.gameObject);
		}
	}

	public void HideUpgradeTooltip()
	{
		Buildable.Properties.HideTooltip();
	}
}
