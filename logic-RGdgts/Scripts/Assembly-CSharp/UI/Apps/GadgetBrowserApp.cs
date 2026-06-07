using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI.Common;
using UI.Elements;
using UI.ListContainer;
using UI.SmallCanvas;
using UnityEngine;
using UnityEngine.Localization.Tables;

namespace UI.Apps
{
	public class GadgetBrowserApp : MultiToolApp
	{
		[Serializable]
		public struct TabButton
		{
			public GBTabs tab;

			public UIButton button;
		}

		[SerializeField]
		private UIButton devTagGadgets;

		public List<TabButton> tabButtons;

		private Dictionary<GBTabs, UIButton> tabsButtonsDict;

		private GBTabs currentVisibleGadgetsTab;

		[SerializeField]
		protected UIButton nextPageButton;

		[SerializeField]
		protected UIButton previousPageButton;

		[SerializeField]
		protected TextMeshProUGUI currentPageText;

		protected int totalGadgetPages;

		protected int currentPage;

		protected int lastSelectedPage;

		private int steamElementsPerPage;

		protected ElementListContainer gadgetListContainer;

		protected SerializedGadgetMetaData currentActiveGadget;

		private int lastSteamCallbackRequested;

		[SerializeField]
		private UIInputField searchBar;

		[SerializeField]
		private UIButton increaseSearchValueButton;

		[SerializeField]
		private UIButton decreaseSearchValueButton;

		[SerializeField]
		private UIButton tagButton;

		[SerializeField]
		private UIText orderLabel;

		private string searchString;

		private List<string> searchTags;

		private Dictionary<GadgetTags, TableEntryReference> tagButtonDict;

		private WorkshopController.Sorting[] localSortingMethods;

		private WorkshopController.Sorting[] workshopSortingMethods;

		private Dictionary<WorkshopController.Sorting, TableEntryReference> sortingDictionary;

		protected WorkshopController.Sorting currentSortingMethod;

		[SerializeField]
		private GameObject NoPersonalGadgetsBox;

		[SerializeField]
		private UIButton learnButton;

		[SerializeField]
		private GameObject NoSubscribedGadgetsBox;

		[SerializeField]
		private GameObject NoLauncherGadgetsBox;

		[SerializeField]
		private GameObject FutureShowcaseGadgetsBox;

		[SerializeField]
		private GameObject NoSteamConnectionBox;

		protected List<SerializedGadgetMetaData> metadataToDispose;

		protected bool isStarting;

		protected Coroutine waitToCloseProjectorCo;

		protected Coroutine workshopOfflineMessageCo;

		public GadgetBrowserSmallPanel gadgetDataSmallPanelPrefab;

		private GadgetBrowserSmallPanel gadgetDataSmallPanel;

		public override void Init()
		{
		}

		private void InitTabButtons()
		{
		}

		private void InitTagsDictionary()
		{
		}

		public override void AppStart()
		{
		}

		private void OnAppStart()
		{
		}

		public override void AppStop()
		{
		}

		private void ChooseGadgetShowingMode(GBTabs tab, bool resetSort = false)
		{
		}

		protected List<ElementColoredButtonParameters> ReturnSubscribedGadgetParameters(Action<List<ButtonsParametersAndPrefabIndex>> onReceived, uint page, List<string> tags = null, bool reset = false)
		{
			return null;
		}

		protected List<ElementColoredButtonParameters> ReturnDevsGadgetParameters(Action<List<ButtonsParametersAndPrefabIndex>> onReceived, uint page, List<string> tags = null)
		{
			return null;
		}

		protected List<ElementColoredButtonParameters> ReturnWorkshopGadgetParameters(Action<List<ButtonsParametersAndPrefabIndex>> onReceived, uint page, List<string> tags = null, bool reset = false)
		{
			return null;
		}

		private void UpdateMetadataWorshopState(SerializedGadgetMetaData metadata)
		{
		}

		private void OnReturnDevsParameters(bool success, WorkshopController.WorkshopQueryResult result, Action<List<ButtonsParametersAndPrefabIndex>> onReceived, uint page)
		{
		}

		private void OnReturnRemoteParameters(bool success, WorkshopController.WorkshopQueryResult result, Action<List<ButtonsParametersAndPrefabIndex>> onReceived, int page)
		{
		}

		private void OnReturnGadgetSteamErrors(bool success)
		{
		}

		private void OnRemoteGadgetParametersReceived(List<ButtonsParametersAndPrefabIndex> results, GBTabs requestedTab)
		{
		}

		protected List<ButtonsParametersAndPrefabIndex> ReturnLocalGadgetParameters()
		{
			return null;
		}

		protected List<ButtonsParametersAndPrefabIndex> ReturnLauncherParameters()
		{
			return null;
		}

		private void OnReturnPrintedGadgetParameters(List<ButtonsParametersAndPrefabIndex> results, int page)
		{
		}

		private void ReorderPrintedGadgets(List<ButtonsParametersAndPrefabIndex> gadgetP)
		{
		}

		protected void ResetGadgets(bool onlyDevs = false, bool reset = false)
		{
		}

		protected void SelectGadget(SerializedGadgetMetaData gadgetMetadata)
		{
		}

		protected void OnElementSelected(int gadgetIndex)
		{
		}

		protected void OnElementDoubleClicked(int gadgetIndex)
		{
		}

		protected void OnGadgetButtonEnter(int gadgetIndex)
		{
		}

		protected void OnGadgetButtonExit(int gadgetIndex)
		{
		}

		protected IEnumerator WaitToCloseProjectorCO()
		{
			return null;
		}

		protected IEnumerator WorkshopOfflineMessageCO()
		{
			return null;
		}

		private void StopCoroutines()
		{
		}

		protected void DisposeMetadatas()
		{
		}

		protected void GoToNextPage()
		{
		}

		protected void GoToPreviousPage()
		{
		}

		private void HidePagesNumbers()
		{
		}

		protected void SetPagesNumbers(int page, int totalResults)
		{
		}

		protected void SetPageButtons()
		{
		}

		public override void OnMultitoolClose()
		{
		}

		private string GetDictIdFromMetadata(SerializedGadgetMetaData metadata)
		{
			return null;
		}

		private ElementColoredButtonParameters ParametersFromGadget(SerializedGadgetMetaData gadget)
		{
			return null;
		}

		public override bool NeedGadget()
		{
			return false;
		}

		private void ManageSearchButtonsColor(WorkshopController.Sorting[] searchValues)
		{
		}

		private void ResetTabButtonsToIcon()
		{
		}

		private void SelectTab(GBTabs selectedTab, bool loadGadgets = true)
		{
		}

		private void ChangeSortingMethod(WorkshopController.Sorting? newSortingMethod = null)
		{
		}

		private WorkshopController.Sorting[] SelectSortingMethod()
		{
			return null;
		}

		private string SetSortingLabel(WorkshopController.Sorting sorting)
		{
			return null;
		}

		private void OnIncreaseSortingMethod()
		{
		}

		private void OnDecreaseSortingMethod()
		{
		}

		public void SearchValueChangeCheck()
		{
		}

		private void OpenTagModal()
		{
		}

		private void AddSelectedTags(List<UIToggle> toggles)
		{
		}

		private string FromStringToTag(string tagString)
		{
			return null;
		}

		private bool CheckName(SerializedGadgetMetaData metadata)
		{
			return false;
		}

		private bool CheckTags(SerializedGadgetMetaData metadata)
		{
			return false;
		}

		private void CleanMessageBoxes()
		{
		}

		private void CleanErrorMessage()
		{
		}

		private void CleanSearchBar()
		{
		}
	}
}
