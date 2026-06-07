using System;
using System.Collections.Generic;
using PajamaLlama.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : Panel
{
	public readonly struct TutorialIDContext : IPanelContext
	{
		public PanelID PanelID => PanelID.TutorialPanel;

		public TutorialID TutorialID { get; }

		public TutorialIDContext(TutorialID tutorialID)
		{
			TutorialID = tutorialID;
		}
	}

	[Serializable]
	public class TutorialTab
	{
		[SerializeField]
		private TutorialID _id;

		[SerializeField]
		private Toggle _toggle;

		public TutorialID ID => _id;

		public Toggle Toggle => _toggle;

		public bool IsActiveSelf
		{
			get
			{
				if ((bool)_toggle)
				{
					return _toggle.gameObject.activeSelf;
				}
				return false;
			}
		}

		public bool IsOn
		{
			get
			{
				if ((bool)_toggle && _toggle.isActiveAndEnabled)
				{
					return _toggle.isOn;
				}
				return false;
			}
			set
			{
				if ((bool)_toggle && _toggle.isActiveAndEnabled)
				{
					_toggle.isOn = value;
				}
			}
		}
	}

	[SerializeField]
	private SelectableGroup _tabs;

	[SerializeField]
	private List<TutorialTab> _tutorialTabs;

	[SerializeField]
	private TextMeshProUGUI _pageLabel;

	[SerializeField]
	private Button _pageButtonPrevious;

	[SerializeField]
	private Button _pageButtonNext;

	[SerializeField]
	private NotificationProperties _notificationProperties;

	private Tutorial[] _tutorials;

	private Tutorial _activeTutorial;

	private void OnEnable()
	{
		if (!_tutorials.IsNullOrEmpty() && !(_activeTutorial != null))
		{
			FinalUpdate.RegisterOneShot(SetFirstTutorialActive);
		}
	}

	private void OnDisable()
	{
		_tabs.DeselectSelected();
	}

	private void OnDestroy()
	{
		foreach (TutorialTab tutorialTab in _tutorialTabs)
		{
			tutorialTab.Toggle.onValueChanged.RemoveListener(OnTabValueChanged);
		}
		GameEventDispatcher.RemoveListener(GameEventType.TutorialPanelPopup, OnTutorialEvent);
		GameEventDispatcher.RemoveListener(GameEventType.TutorialNotification, OnTutorialNotificationEvent);
	}

	public override void Initialize()
	{
		_tutorials = GetComponentsInChildren<Tutorial>(includeInactive: true);
		Tutorial[] tutorials = _tutorials;
		for (int i = 0; i < tutorials.Length; i++)
		{
			tutorials[i].Initialize();
		}
		_pageButtonPrevious.onClick.AddListener(OnPreviousTutorialPage);
		_pageButtonNext.onClick.AddListener(OnNextTutorialPage);
		GameEventDispatcher.AddListener(GameEventType.TutorialPanelPopup, OnTutorialEvent);
		GameEventDispatcher.AddListener(GameEventType.TutorialNotification, OnTutorialNotificationEvent);
		foreach (TutorialTab tutorialTab in _tutorialTabs)
		{
			if (tutorialTab.IsActiveSelf)
			{
				tutorialTab.Toggle.onValueChanged.AddListener(OnTabValueChanged);
			}
		}
		base.gameObject.SetActive(value: false);
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (base.Open(id, context))
		{
			TutorialID tutorialID = TutorialID.None;
			tutorialID = ((!(context is TutorialObjectOfInterest tutorialObjectOfInterest)) ? ((!(context is TutorialIDContext tutorialIDContext)) ? TutorialIDProvider.TutorialID : tutorialIDContext.TutorialID) : tutorialObjectOfInterest.TutorialID);
			if (tutorialID != TutorialID.None)
			{
				ToggleTab(tutorialID);
			}
			return true;
		}
		return false;
	}

	private void ToggleTab(TutorialID id)
	{
		foreach (TutorialTab tutorialTab in _tutorialTabs)
		{
			if (tutorialTab.ID == id)
			{
				if (!_tabs.TrySelect(tutorialTab.Toggle))
				{
					tutorialTab.IsOn = true;
					OnTabValueChanged(value: true);
				}
				break;
			}
		}
	}

	private void SetFirstTutorialActive()
	{
		OnTabValueChanged(value: true);
		if (!(_activeTutorial == null))
		{
			return;
		}
		foreach (TutorialTab tutorialTab in _tutorialTabs)
		{
			tutorialTab.IsOn = true;
			if (tutorialTab.IsOn)
			{
				break;
			}
		}
	}

	private void OnTutorialEvent(GameEvent gameEvent)
	{
		if (gameEvent is TutorialEvent tutorialEvent)
		{
			GameManager.UIManager.DisplayPanel(ID, new TutorialIDContext(tutorialEvent.Id));
		}
	}

	private void OnTutorialNotificationEvent(GameEvent gameEvent)
	{
		if (gameEvent is TutorialEvent tutorialEvent)
		{
			GameManager.UIManager.NotificationHandler.AddNotification(_notificationProperties, new TutorialObjectOfInterest(tutorialEvent.Id));
		}
	}

	private void OnTabValueChanged(bool value)
	{
		if (!value)
		{
			return;
		}
		foreach (TutorialTab tutorialTab in _tutorialTabs)
		{
			if (tutorialTab.IsOn)
			{
				ActivateTutorial(tutorialTab.ID);
				break;
			}
		}
	}

	private void ActivateTutorial(TutorialID id)
	{
		if (_activeTutorial != null)
		{
			if (_activeTutorial.ID == id)
			{
				return;
			}
			_activeTutorial.gameObject.SetActive(value: false);
		}
		if (TryGetTutorial(id, out var tutorial))
		{
			_activeTutorial = tutorial;
			_activeTutorial.gameObject.SetActive(value: true);
			OnTutorialPageUpdated();
		}
	}

	private void OnPreviousTutorialPage()
	{
		if ((bool)_activeTutorial && _activeTutorial.PreviousPage())
		{
			OnTutorialPageUpdated();
		}
	}

	private void OnNextTutorialPage()
	{
		if ((bool)_activeTutorial && _activeTutorial.NextPage())
		{
			OnTutorialPageUpdated();
		}
	}

	private void OnTutorialPageUpdated()
	{
		if (((bool)_activeTutorial && _activeTutorial.HasPreviousPage()) || _activeTutorial.HasNextPage())
		{
			_pageButtonPrevious.gameObject.SetActive(value: true);
			_pageButtonPrevious.interactable = _activeTutorial.HasPreviousPage();
			_pageButtonNext.gameObject.SetActive(value: true);
			_pageButtonNext.interactable = _activeTutorial.HasNextPage();
			_pageLabel.gameObject.SetActive(value: true);
			_pageLabel.text = (_activeTutorial ? _activeTutorial.GetPageString() : "0/0");
		}
		else
		{
			_pageButtonPrevious.gameObject.SetActive(value: false);
			_pageButtonNext.gameObject.SetActive(value: false);
			_pageLabel.gameObject.SetActive(value: false);
		}
	}

	public bool TryGetTutorial(TutorialID id, out Tutorial tutorial)
	{
		for (int i = 0; i < _tutorials.Length; i++)
		{
			tutorial = _tutorials[i];
			if (tutorial.ID == id)
			{
				return true;
			}
		}
		tutorial = null;
		return false;
	}
}
