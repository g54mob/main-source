using System;
using System.Collections.Generic;
using System.Linq;
using ModIO.Util;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class SelectionManager : SelfInstancingMonoSingleton<SelectionManager>
	{
		private Dictionary<UiViews, List<GameObject>> selectionHistory = new Dictionary<UiViews, List<GameObject>>();

		private Dictionary<UiViews, GameObject> viewConfig;

		public List<SelectionViewConfigItem> defaultViews = new List<SelectionViewConfigItem>();

		public UiViews currentView { get; private set; } = UiViews.Browse;

		private UiViews previousView { get; set; }

		protected override void Awake()
		{
			base.Awake();
			base.gameObject.SetActive(value: false);
			if (defaultViews.Any((SelectionViewConfigItem x) => x.viewType == UiViews.Nothing))
			{
				string message = $"Unable to set up a default view with the UiViews type {UiViews.Nothing}.";
				Debug.LogError(message);
				throw new UnityException(message);
			}
			viewConfig = defaultViews.ToDictionary((SelectionViewConfigItem x) => x.viewType, (SelectionViewConfigItem x) => x.defaultSelectedObject);
		}

		public void Update()
		{
			if (!MonoSingleton<Browser>.Instance.BrowserCanvas.activeSelf || currentView == UiViews.Nothing)
			{
				return;
			}
			if (EventSystem.current.currentSelectedGameObject != null)
			{
				if (CurrentViewHistory().LastOrDefault() != EventSystem.current.currentSelectedGameObject)
				{
					CurrentViewHistory().Add(EventSystem.current.currentSelectedGameObject);
				}
			}
			else
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SelectGameObject(CurrentViewHistory().Last());
			}
		}

		private List<GameObject> CurrentViewHistory()
		{
			if (selectionHistory[currentView] == null)
			{
				return LazyInstantiateHistory(currentView);
			}
			return selectionHistory[currentView];
		}

		public void SelectMostRecentStillActivatedUiItem(bool force = false)
		{
			if (EventSystem.current.currentSelectedGameObject == null || force)
			{
				GameObject gameObject = CurrentViewHistory().LastOrDefault((GameObject x) => x.activeSelf);
				gameObject = ((gameObject == null) ? viewConfig[currentView] : gameObject);
				CurrentViewHistory().Clear();
				CurrentViewHistory().Add(gameObject);
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SelectGameObject(gameObject);
			}
		}

		private void ForceSelectMostRecentStillActivatedUiItem()
		{
			SelectMostRecentStillActivatedUiItem(force: true);
		}

		public void SetNewViewDefaultSelection(UiViews view, Selectable selectable)
		{
			GetViewConfigItem(view).defaultSelectedObject = selectable.gameObject;
			viewConfig[view] = selectable.gameObject;
			LazyInstantiateHistory(view);
			selectionHistory[view].Clear();
		}

		public void SelectPreviousView()
		{
			SelectView(previousView);
		}

		public void SelectView(UiViews view)
		{
			if (view == UiViews.Nothing)
			{
				throw new UnityException($"No views with the type '{UiViews.Nothing}' allowed.");
			}
			if (!defaultViews.Any((SelectionViewConfigItem x) => x.viewType == view))
			{
				throw new UnityException($"There is no configuration for the view {view}.");
			}
			SelectionViewConfigItem viewConfigItem = GetViewConfigItem(view);
			previousView = currentView;
			currentView = viewConfigItem.viewType;
			LazyInstantiateHistory(currentView);
			if (view != UiViews.Browse || CurrentViewHistory().Count() == 0)
			{
				GameObject gameObject = viewConfig[currentView];
				SelfInstancingMonoSingleton<InputNavigation>.Instance.SelectGameObject(gameObject);
				CurrentViewHistory().Clear();
				CurrentViewHistory().Add(gameObject);
			}
			else
			{
				ForceSelectMostRecentStillActivatedUiItem();
			}
		}

		private List<GameObject> LazyInstantiateHistory(UiViews view)
		{
			if (!selectionHistory.ContainsKey(view))
			{
				List<GameObject> list = new List<GameObject>();
				selectionHistory.Add(view, list);
				return list;
			}
			return selectionHistory[view];
		}

		private SelectionViewConfigItem GetViewConfigItem(UiViews view)
		{
			return defaultViews.FirstOrDefault((SelectionViewConfigItem x) => x.viewType == view) ?? throw new NotImplementedException($"The configuration for the view '{view}' does not exist.");
		}
	}
}
