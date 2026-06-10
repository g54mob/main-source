using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Manager;
using NSMedieval.Tools.Debug;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class DeveloperToolsView : MonoSingleton<DeveloperToolsView>, IObserver, IPauseGame
	{
		[SerializeField]
		private GameObject mainContainer;

		[SerializeField]
		private SoundButton buttonClose;

		[SerializeField]
		private SoundButton buttonBack;

		[SerializeField]
		private List<SoundButtonToggle> tabToggles;

		[SerializeField]
		private List<DeveloperView> developerViews;

		private bool devToolsActive;

		private bool tabsSet;

		private readonly List<DeveloperToolsCategory> categories = new DeveloperToolsCategories().Categories;

		private readonly Dictionary<SoundButtonToggle, DeveloperView> panels = new Dictionary<SoundButtonToggle, DeveloperView>();

		public bool RefreshPanel { get; set; }

		public event Action CloseDevToolsPanelEvent;

		public void CloseDevToolsPanel()
		{
			this.CloseDevToolsPanelEvent?.Invoke();
		}

		public void Open()
		{
			MonoSingleton<BugReporterManager>.Instance.IsDevConsoleOpened = true;
			SetTabs();
			MonoSingleton<GameplayPauseManager>.Instance.Register(this);
			MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(Close, base.gameObject);
			devToolsActive = true;
			SetActive();
		}

		public void SetBackButton(Action callback)
		{
			if (callback == null)
			{
				buttonBack.gameObject.SetActive(value: false);
				return;
			}
			buttonBack.gameObject.SetActive(value: true);
			buttonBack.onClick.RemoveAllListeners();
			buttonBack.onClick.AddListener(delegate
			{
				callback();
			});
		}

		private void Close()
		{
			MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
			MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(Close, base.gameObject);
			devToolsActive = false;
			SetActive();
		}

		private void Start()
		{
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			CloseDevToolsPanelEvent += Close;
			buttonClose.onClick.AddListener(Close);
			SetBackButton(null);
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
			this.CloseDevToolsPanelEvent = null;
			base.OnDestroy();
		}

		private void SetTabs()
		{
			if (tabsSet)
			{
				return;
			}
			tabsSet = true;
			for (int i = 0; i < tabToggles.Count; i++)
			{
				int num = i;
				SoundButtonToggle tabToggle = tabToggles[num];
				DeveloperView developerView = developerViews[num];
				developerView.SetupPanel((DeveloperPanelCategory)num);
				panels.Add(tabToggle, developerView);
				tabToggle.SetLabels(categories[num].Name);
				tabToggle.IsOn(num == 0);
				tabToggle.Button.onClick.AddListener(delegate
				{
					TogglePanel(tabToggle);
				});
			}
			TogglePanel(tabToggles[0]);
			SetActive();
		}

		private void TogglePanel(SoundButtonToggle panelToEnable)
		{
			foreach (KeyValuePair<SoundButtonToggle, DeveloperView> panel in panels)
			{
				bool flag = panel.Key == panelToEnable;
				panel.Key.Button.interactable = !flag;
				panel.Key.IsOn(flag);
				panel.Value.SetActive(flag);
			}
		}

		private void OnTick(float obj)
		{
		}

		private void SetActive()
		{
		}

		private IEnumerator WaitForClose()
		{
			MonoSingleton<BugReporterManager>.Instance.IsDevConsoleOpened = true;
			yield return new WaitForEndOfFrame();
			MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked = devToolsActive;
		}
	}
}
