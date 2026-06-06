using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecorationPanel : Panel
{
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
	private BuildDecorationPanel _buildPanel;

	[SerializeField]
	private PanelTabContainer _tabs;

	[SerializeField]
	private Button _salvageButton;

	[SerializeField]
	private GameObject _salvageButtonIcon;

	[SerializeField]
	private GameObject _salvageButtonCancelIcon;

	[SerializeField]
	private Tooltip _salvageTooltip;

	[SerializeField]
	private GameObject _tutorialButton;

	private readonly List<IDecorationPanelElement> _elements = new List<IDecorationPanelElement>();

	public Decoration Decoration { get; private set; }

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.DecorationBuilt, OnDecorationUpdated);
		GameEventDispatcher.AddListener(GameEventType.DecorationRemoved, OnDecorationUpdated);
		GameEventDispatcher.AddListener(GameEventType.DecorationSelected, OnDecorationUpdated);
	}

	private void OnDisable()
	{
		Close();
		GameEventDispatcher.RemoveListener(GameEventType.DecorationBuilt, OnDecorationUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.DecorationRemoved, OnDecorationUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.DecorationSelected, OnDecorationUpdated);
	}

	public override void Initialize()
	{
		IDecorationPanelElement[] componentsInChildren = GetComponentsInChildren<IDecorationPanelElement>(includeInactive: true);
		foreach (IDecorationPanelElement decorationPanelElement in componentsInChildren)
		{
			if (decorationPanelElement.Id != DecorationPanelElementId.None)
			{
				_elements.Add(decorationPanelElement);
			}
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (context is Decoration decoration && base.Open(id, context))
		{
			Initialize(decoration);
			return true;
		}
		return false;
	}

	public override void Close()
	{
		foreach (IDecorationPanelElement element in _elements)
		{
			element.Deactivate();
		}
		if (Decoration != null)
		{
			Decoration decoration = Decoration;
			decoration.OnSalvageDone = (Action<Decoration>)Delegate.Remove(decoration.OnSalvageDone, new Action<Decoration>(Close));
			ConstructibleStatus statusHolder = Decoration.StatusHolder;
			statusHolder.OnMalfunctionsUpdated = (Action)Delegate.Remove(statusHolder.OnMalfunctionsUpdated, new Action(RefreshElements));
			Selector.Deselect(Decoration.GetComponentsInChildren<SelectionLink>());
		}
		Decoration = null;
		base.Close();
	}

	private void Close(Decoration decoration)
	{
		if (decoration == Decoration)
		{
			Close();
		}
	}

	public void Initialize(Decoration decoration)
	{
		if (!(Decoration == decoration))
		{
			if (Decoration != null)
			{
				ConstructibleStatus statusHolder = Decoration.StatusHolder;
				statusHolder.OnMalfunctionsUpdated = (Action)Delegate.Remove(statusHolder.OnMalfunctionsUpdated, new Action(RefreshElements));
			}
			Decoration = decoration;
			_name.text = Decoration.Name;
			string text = Decoration.Name + "\n" + Decoration.GetDescription();
			_descriptionTooltip.LocalizedText = text;
			_iconTooltip.LocalizedText = text;
			_icon.sprite = Decoration.Properties.GetIcon();
			_headerImage.overrideSprite = Decoration.Properties.HeaderSprite;
			if (_tutorialButton != null)
			{
				_tutorialButton.SetActive(Decoration.Properties.TutorialPageID != TutorialID.None);
			}
			RefreshElements();
		}
	}

	private void RefreshElements()
	{
		BuildPhase buildPhase = Decoration.ConstructionHandler.BuildPhase;
		bool num = buildPhase == BuildPhase.Deconstructing || buildPhase == BuildPhase.HaulFrom;
		Decoration decoration = Decoration;
		decoration.OnSalvageDone = (Action<Decoration>)Delegate.Remove(decoration.OnSalvageDone, new Action<Decoration>(Close));
		if (num)
		{
			Decoration decoration2 = Decoration;
			decoration2.OnSalvageDone = (Action<Decoration>)Delegate.Combine(decoration2.OnSalvageDone, new Action<Decoration>(Close));
		}
		ConstructibleStatus statusHolder = Decoration.StatusHolder;
		statusHolder.OnMalfunctionsUpdated = (Action)Delegate.Remove(statusHolder.OnMalfunctionsUpdated, new Action(RefreshElements));
		ConstructibleStatus statusHolder2 = Decoration.StatusHolder;
		statusHolder2.OnMalfunctionsUpdated = (Action)Delegate.Combine(statusHolder2.OnMalfunctionsUpdated, new Action(RefreshElements));
		_salvageButton.interactable = Decoration.ConstructionHandler.CanBeDeconstructed(out var error);
		_salvageTooltip.LocalizedText = error;
		buildPhase = Decoration.ConstructionHandler.BuildPhase;
		bool flag = buildPhase == BuildPhase.Deconstructing || buildPhase == BuildPhase.HaulFrom || buildPhase == BuildPhase.SalvageShutdown || Decoration.ConstructionHandler.CancelConstructionAfterHaul;
		_salvageButtonIcon.SetActive(!flag);
		_salvageButtonCancelIcon.SetActive(flag);
		buildPhase = Decoration.ConstructionHandler.BuildPhase;
		bool flag2 = buildPhase == BuildPhase.Finished || buildPhase == BuildPhase.SalvageShutdown;
		foreach (IDecorationPanelElement element in _elements)
		{
			if (ShouldShowElement(Decoration.Properties, element, flag2))
			{
				element.Activate(Decoration);
			}
			else
			{
				element.Deactivate();
			}
		}
		if (flag2)
		{
			_buildPanel.Deactivate();
		}
		else
		{
			_buildPanel.Initialize(Decoration, Decoration.Properties.RequiredResources);
		}
		_tabs.Initialize();
	}

	public void OnClickSalvageButton()
	{
		BuildPhase buildPhase = Decoration.ConstructionHandler.BuildPhase;
		if (buildPhase == BuildPhase.Deconstructing || buildPhase == BuildPhase.SalvageShutdown || Decoration.ConstructionHandler.CancelConstructionAfterHaul)
		{
			Decoration.Parent.CancelDecorationRemoval(Decoration);
			Decoration decoration = Decoration;
			decoration.OnSalvageDone = (Action<Decoration>)Delegate.Remove(decoration.OnSalvageDone, new Action<Decoration>(Close));
			RefreshElements();
		}
		else
		{
			Decoration.Parent.RemoveDecoration(Decoration);
			if (Decoration.Properties.ShouldDeconstructInstantly)
			{
				Close();
			}
			else
			{
				RefreshElements();
			}
		}
	}

	public void OpenSurvivalGuidePage()
	{
		new StringEvent(GameEventType.OpenSurvivalGuidePage, Decoration.Properties.SurvivalGuideIdentifier).Dispatch();
	}

	public void OpenTutorialPage()
	{
		TutorialEvent.Dispatch(GameEventType.TutorialPanelPopup, Decoration.Properties.TutorialPageID);
	}

	public void PopUpNameChange()
	{
		if (PopUpDialog.Instance.TryPopUpInput(GameManager.Settings.UISettings.InputNameChange))
		{
			PopUpDialog.Instance.InputEvent += SetDecorationName;
		}
	}

	private void SetDecorationName(string newName, bool dialogFeedback)
	{
		PopUpDialog.Instance.InputEvent -= SetDecorationName;
		if (dialogFeedback)
		{
			Decoration.Name = newName;
			_name.text = Decoration.Name;
		}
	}

	private void OnDecorationUpdated(GameEvent gameEvent)
	{
		if (gameEvent is DecorationEvent decorationEvent && decorationEvent.Deco == Decoration)
		{
			Initialize(Decoration);
		}
	}

	private bool ShouldShowElement(DecorationProperties properties, IDecorationPanelElement element, bool canShowPanels)
	{
		if (element == null)
		{
			return false;
		}
		if ((properties.UIElements & element.Id) != DecorationPanelElementId.None)
		{
			return true;
		}
		return element.Id switch
		{
			DecorationPanelElementId.Malfunction => properties.ShowMalfunctionElements, 
			DecorationPanelElementId.EnergyGridLink => properties.ShowEnergyGridLinkElements && canShowPanels, 
			DecorationPanelElementId.EnergyStorage => properties.ShowEnergyStorageElements && canShowPanels, 
			DecorationPanelElementId.EnergyGridInformation => properties.ShowEnergyGridEfficiency && canShowPanels, 
			_ => false, 
		};
	}
}
