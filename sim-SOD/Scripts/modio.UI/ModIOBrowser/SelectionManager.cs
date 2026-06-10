using System.Collections.Generic;
using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class SelectionManager : SelfInstancingMonoSingleton<SelectionManager>
	{
		private Dictionary<UiViews, List<GameObject>> selectionHistory;

		private Dictionary<UiViews, GameObject> viewConfig;

		public List<SelectionViewConfigItem> defaultViews;

		public UiViews currentView { get; private set; }

		private UiViews previousView { get; set; }

		protected override void Awake()
		{
		}

		public void Update()
		{
		}

		private List<GameObject> CurrentViewHistory()
		{
			return null;
		}

		public void SelectMostRecentStillActivatedUiItem(bool force = false)
		{
		}

		private void ForceSelectMostRecentStillActivatedUiItem()
		{
		}

		public void SetNewViewDefaultSelection(UiViews view, Selectable selectable)
		{
		}

		public void SelectPreviousView()
		{
		}

		public void SelectView(UiViews view)
		{
		}

		private List<GameObject> LazyInstantiateHistory(UiViews view)
		{
			return null;
		}

		private SelectionViewConfigItem GetViewConfigItem(UiViews view)
		{
			return null;
		}
	}
}
