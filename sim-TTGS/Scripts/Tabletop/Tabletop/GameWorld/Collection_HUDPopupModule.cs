using System;
using System.Collections.Generic;
using System.Linq;
using Simulator;
using Simulator.GameWorld;
using Simulator.Preview3D;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class Collection_HUDPopupModule : TabletopHUDPopupModule, IUIShouldersInputReceiver
	{
		[SerializeField]
		private RectTransform m_pageContainer;

		[SerializeField]
		private NavBox m_pageContainerNavBox;

		[SerializeField]
		private RectTransform m_filtersContainer;

		[SerializeField]
		private Graphic[] m_graphicsToHide;

		[Header("Screens")]
		[SerializeField]
		private GameObject m_catalogScreen;

		[SerializeField]
		private RectTransform m_catalogScreenFooter;

		[SerializeField]
		private UI_CollectionSquadEditionScreen m_squadEditionScreen;

		[SerializeField]
		private UI_CollectionSquadSelectionScreen m_squadSelectionScreen;

		[Header("Popups")]
		[SerializeField]
		private UI_CollectionStatisticsPopup m_statisticsPopup;

		[SerializeField]
		private UI_CollectionMiniaturePopup m_miniaturePopup;

		[SerializeField]
		private UI_MiniatureAssemblePopup m_assemblePopup;

		[SerializeField]
		private UI_MiniaturePaintingPopup m_paintingPopup;

		[SerializeField]
		private NavButton m_prevMiniaturePopupArrow;

		[SerializeField]
		private NavButton m_nextMiniaturePopupArrow;

		[Header("Catalog")]
		[Header("Sort")]
		[SerializeField]
		private TabletopDropdown m_sortDropdown;

		[Header("Search")]
		[SerializeField]
		private UI_SearchBar m_searchBar;

		[Header("Filters")]
		[SerializeField]
		private UI_CollectionFilterDropdown m_filterDropdown;

		[Header("Statistics")]
		[SerializeField]
		private Button m_statisticsButton;

		[Header("Pages")]
		[SerializeField]
		private NavButton m_firstPageButton;

		[SerializeField]
		private NavButton m_prevPageButton;

		[SerializeField]
		private NavButton m_nextPageButton;

		[SerializeField]
		private NavButton m_lastPageButton;

		[Space(10f)]
		[SerializeField]
		private TextMeshProUGUI m_pageNumberText;

		[SerializeField]
		private ObjectActivator m_pageActivator;

		[Header("Prefabs")]
		[SerializeField]
		private UI_CollectionPage m_pagePrefab;

		private UI_CollectionPopup m_currentUICollectionPopup;

		private Vector2Int m_layout;

		private Vector2 m_pageSizeReference;

		private float m_pageGridHorSpace;

		private List<UI_CollectionPage> m_pages = new List<UI_CollectionPage>();

		private int m_currentPageIndex;

		private int m_currentPageCount;

		private List<ECollectionSortType> m_baseSortOrder;

		private ECollectionSortType m_primarySortType;

		private string m_searchString;

		public override ETabletopHUDPopupModuleType ActualType => ETabletopHUDPopupModuleType.COLLECTION;

		public int CurrentPageIndex
		{
			get
			{
				return m_currentPageIndex;
			}
			set
			{
				m_currentPageIndex = value;
				UpdatePageIndexText();
			}
		}

		public int CurrentPageCount
		{
			get
			{
				return m_currentPageCount;
			}
			set
			{
				m_currentPageCount = value;
				UpdatePageIndexText();
				UpdatePageButtonsAvailability();
			}
		}

		public static event Action Closed;

		protected override void OnEnable()
		{
			base.OnEnable();
			InitSortDropdown();
			m_filterDropdown.Init();
			Collection.CollectedNewPieces += OnCollectedNewPieces;
			Collection.StartAssembleMiniature += OnStartAssembleMiniature;
			Collection.CompleteAssembleMiniature += OnCompleteAssembleMiniature;
			Collection.PaintedMiniature += OnPaintedMiniature;
			UI_CollectionMiniatureButton.Clicked += OnMiniatureButtonClicked;
			m_squadSelectionScreen.EditSquad += OnStartEditingSquad;
			m_squadSelectionScreen.Closed += OnCloseButtonClicked;
			m_squadEditionScreen.Closed += OnSquadEditionClosed;
			m_statisticsPopup.Activated += OnActivatePopup;
			m_miniaturePopup.Activated += OnActivatePopup;
			m_assemblePopup.Activated += OnActivatePopup;
			m_paintingPopup.Activated += OnActivatePopup;
			m_sortDropdown.onValueChanged.AddListener(OnSortTypeChanged);
			m_searchBar.AnyChange += OnSearchValueChanged;
			m_searchBar.Validate += OnValidateSearch;
			m_filterDropdown.AnyChange += OnAnyFilterChanged;
			if ((bool)m_statisticsButton)
			{
				m_statisticsButton.onClick.AddListener(OnButton_Statistics);
			}
			m_firstPageButton.Button.onClick.AddListener(OnButton_FirstPage);
			m_prevPageButton.Button.onClick.AddListener(OnButton_PreviousPage);
			m_nextPageButton.Button.onClick.AddListener(OnButton_NextPage);
			m_lastPageButton.Button.onClick.AddListener(OnButton_LastPage);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Collection.CollectedNewPieces -= OnCollectedNewPieces;
			Collection.StartAssembleMiniature -= OnStartAssembleMiniature;
			Collection.CompleteAssembleMiniature -= OnCompleteAssembleMiniature;
			Collection.PaintedMiniature -= OnPaintedMiniature;
			UI_CollectionMiniatureButton.Clicked -= OnMiniatureButtonClicked;
			m_squadSelectionScreen.EditSquad -= OnStartEditingSquad;
			m_squadSelectionScreen.Closed -= OnCloseButtonClicked;
			m_squadEditionScreen.Closed -= OnSquadEditionClosed;
			m_statisticsPopup.Activated -= OnActivatePopup;
			m_miniaturePopup.Activated -= OnActivatePopup;
			m_assemblePopup.Activated -= OnActivatePopup;
			m_paintingPopup.Activated -= OnActivatePopup;
			m_sortDropdown.onValueChanged.RemoveListener(OnSortTypeChanged);
			m_searchBar.AnyChange -= OnSearchValueChanged;
			m_searchBar.Validate -= OnValidateSearch;
			m_filterDropdown.AnyChange -= OnAnyFilterChanged;
			if ((bool)m_statisticsButton)
			{
				m_statisticsButton.onClick.RemoveListener(OnButton_Statistics);
			}
			m_firstPageButton.Button.onClick.RemoveListener(OnButton_FirstPage);
			m_prevPageButton.Button.onClick.RemoveListener(OnButton_PreviousPage);
			m_nextPageButton.Button.onClick.RemoveListener(OnButton_NextPage);
			m_lastPageButton.Button.onClick.RemoveListener(OnButton_LastPage);
		}

		private void OpenCatalogScreen(bool squadEdition)
		{
			m_catalogScreen.SetActive(value: true);
			((IActivable)m_squadSelectionScreen).SetActive(false);
			m_squadEditionScreen.SetActive(squadEdition);
		}

		private void OpenSquadSelectionScreen()
		{
			ToggleBackgroundGraphics(value: false);
			m_catalogScreen.SetActive(value: false);
			m_squadEditionScreen.SetActive(active: false);
			((IActivable)m_squadSelectionScreen).SetActive(true);
		}

		private void OpenSquadEditionScreen()
		{
			ToggleBackgroundGraphics(value: false);
			OpenCatalogScreen(squadEdition: true);
			m_layout = CollectionSettings.SmallLayout;
			m_pageSizeReference = CollectionSettings.SmallPageContainerSize;
			m_pageGridHorSpace = CollectionSettings.SmallPageContainerGridHorSpace;
			m_pageContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, CollectionSettings.SmallPageContainerSize.y);
			m_pageContainer.anchoredPosition = new Vector2(0f, CollectionSettings.SmallPageContainerY);
			m_filtersContainer.anchoredPosition = new Vector2(0f, CollectionSettings.SmallFiltersContainerY);
			m_catalogScreenFooter.anchoredPosition = new Vector2(0f, CollectionSettings.SmallFooterContainerY);
			if (TryGetCloseNavButton(out var closeNavButton))
			{
				closeNavButton.gameObject.SetActive(value: false);
			}
		}

		private void InitSortDropdown()
		{
			m_baseSortOrder = CollectionSettings.GetBaseSortOrder();
			m_primarySortType = m_baseSortOrder[0];
			m_sortDropdown.ClearOptions();
			List<string> list = new List<string>();
			foreach (ECollectionSortType item in m_baseSortOrder)
			{
				list.Add(CollectionSettings.GetSortTypeTerm(item));
			}
			m_sortDropdown.AddOptions(list);
		}

		private List<CollectionElement> SortAndFilterContent(HashSet<CollectionElement> list)
		{
			if (!list.IsValid())
			{
				return new List<CollectionElement>();
			}
			List<CollectionElement> list2 = new List<CollectionElement>();
			foreach (CollectionElement item in list)
			{
				if (item.data != null && PassCollectionFilters(item) && PassSearchFilter(item))
				{
					list2.Add(item);
				}
			}
			list2.Sort(SortMethod);
			return list2;
		}

		private bool PassSearchFilter(CollectionElement element)
		{
			if (!string.IsNullOrWhiteSpace(m_searchString))
			{
				if (!element.discovered)
				{
					return false;
				}
				return element.data.GetLocalizedName().Contains(m_searchString, StringComparison.InvariantCulture);
			}
			return true;
		}

		private bool PassCollectionFilters(CollectionElement element)
		{
			foreach (ECollectionFilterType value in Enum.GetValues(typeof(ECollectionFilterType)))
			{
				if (m_filterDropdown.IsFilterActive((int)value))
				{
					continue;
				}
				switch (value)
				{
				case ECollectionFilterType.INCOMPLETE:
					if (element.discovered && element.present && element.totalAssembled < 1)
					{
						return false;
					}
					break;
				case ECollectionFilterType.UNPAINTED:
					if (element.discovered && element.present && element.painted < 1)
					{
						return false;
					}
					break;
				case ECollectionFilterType.PAINTED:
					if (element.discovered && element.present && element.painted > 0)
					{
						return false;
					}
					break;
				case ECollectionFilterType.MISSING:
					if (element.discovered && !element.present)
					{
						return false;
					}
					break;
				case ECollectionFilterType.UNDISCOVERED:
					if (!element.discovered)
					{
						return false;
					}
					break;
				}
			}
			return true;
		}

		private int SortMethod(CollectionElement e1, CollectionElement e2)
		{
			int sortResult = GetSortResult(m_primarySortType, e1, e2);
			if (sortResult != 0)
			{
				return sortResult;
			}
			sortResult = -e1.discovered.CompareTo(e2.discovered);
			if (sortResult != 0)
			{
				return sortResult;
			}
			sortResult = -e1.present.CompareTo(e2.present);
			if (sortResult != 0)
			{
				return sortResult;
			}
			foreach (ECollectionSortType item in m_baseSortOrder)
			{
				if (item != m_primarySortType)
				{
					sortResult = GetSortResult(item, e1, e2);
					if (sortResult != 0)
					{
						return sortResult;
					}
				}
			}
			return 0;
		}

		private int GetSortResult(ECollectionSortType type, CollectionElement e1, CollectionElement e2)
		{
			switch (type)
			{
			case ECollectionSortType.LICENSE:
				return e1.data.License.CompareTo(e2.data.License);
			case ECollectionSortType.ARMY:
				return e1.data.Army.CompareTo(e2.data.Army);
			case ECollectionSortType.NAME:
				if (e1.discovered != e2.discovered)
				{
					return -e1.discovered.CompareTo(e2.discovered);
				}
				return e1.data.GetLocalizedName().CompareTo(e2.data.GetLocalizedName());
			case ECollectionSortType.RARITY:
				return -e1.data.Rarity.CompareTo(e2.data.Rarity);
			case ECollectionSortType.PRICE:
				return -e1.data.MarketPrice.CompareTo(e2.data.MarketPrice);
			case ECollectionSortType.COMPLETION:
				if (Collection.Mode == ECollectionMode.BROWSE)
				{
					int num = -e1.piecesCount.CompareTo(e2.piecesCount);
					if (num != 0)
					{
						return num;
					}
				}
				return -e1.totalAssembled.CompareTo(e2.totalAssembled);
			default:
				throw new NotImplementedException();
			}
		}

		private UI_CollectionPage GetPage(int pageIndex)
		{
			while (pageIndex >= m_pages.Count)
			{
				CreateNewPage();
			}
			return m_pages[pageIndex];
		}

		private void ActivatePage(int pageIndex)
		{
			if (m_pages.IsIndexValid(pageIndex))
			{
				m_pageActivator.Activate(m_pages[pageIndex]);
				if (m_pages[pageIndex].GetMiniaturesCount() <= 0)
				{
					SelectCloseButton();
				}
				CurrentPageIndex = pageIndex;
				if (Collection.Mode == ECollectionMode.SQUAD_EDITION)
				{
					m_squadEditionScreen.RefreshMiniatureImages();
				}
				m_pageContainerNavBox.SetCurrentElement(GetCurrentPage());
			}
			UpdatePageButtonsAvailability();
		}

		private void SelectCloseButton()
		{
			if (TryGetCloseNavButton(out var closeNavButton))
			{
				EventSystem.current.SetSelectedGameObject(closeNavButton.gameObject);
			}
		}

		private void CreateNewPage()
		{
			UI_CollectionPage component = UnityEngine.Object.Instantiate(m_pagePrefab, m_pageContainer).GetComponent<UI_CollectionPage>();
			m_pageContainerNavBox.AddChild(component);
			m_pageContainerNavBox.SetupChildren();
			m_pageContainerNavBox.SelectFirstChild();
			m_pages.Add(component);
		}

		private void RefreshLayout()
		{
			switch (Collection.Mode)
			{
			case ECollectionMode.BROWSE:
			case ECollectionMode.PAINTING:
			case ECollectionMode.SELLING:
				OpenCatalogScreen(squadEdition: false);
				m_layout = CollectionSettings.DefaultLayout;
				m_pageSizeReference = CollectionSettings.DefaultPageContainerSize;
				m_pageGridHorSpace = CollectionSettings.DefaultPageContainerGridHorSpace;
				m_pageContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, CollectionSettings.DefaultPageContainerSize.y);
				m_pageContainer.anchoredPosition = new Vector2(0f, CollectionSettings.DefaultPageContainerY);
				m_filtersContainer.anchoredPosition = new Vector2(0f, CollectionSettings.DefaultFiltersContainerY);
				m_catalogScreenFooter.anchoredPosition = new Vector2(0f, CollectionSettings.DefaultFooterContainerY);
				ToggleBackgroundGraphics(value: true);
				break;
			case ECollectionMode.SQUAD_EDITION:
				OpenSquadEditionScreen();
				break;
			case ECollectionMode.SQUAD_SELECTION:
				OpenSquadSelectionScreen();
				break;
			case (ECollectionMode)4:
			case (ECollectionMode)5:
				break;
			}
		}

		private HashSet<CollectionElement> GetValidCollectionElements()
		{
			return Collection.Mode switch
			{
				ECollectionMode.BROWSE => Collection.GetAllCollectionElements().ToHashSet(), 
				ECollectionMode.PAINTING => Collection.GetPaintableCollectionElements().ToHashSet(), 
				ECollectionMode.SELLING => Collection.GetSellableCollectionElements().ToHashSet(), 
				ECollectionMode.SQUAD_EDITION => Collection.GetPaintedCollectionElements().ToHashSet(), 
				_ => null, 
			};
		}

		private void RefreshContent()
		{
			RefreshLayout();
			if (m_catalogScreen.activeSelf)
			{
				RefreshPages();
				if (m_pages.Count > 0 && m_pages[CurrentPageIndex].GetMiniaturesCount() > 0)
				{
					base.NavBox.SelectFirstChild();
				}
				else
				{
					m_squadEditionScreen.SelectCloseButton();
				}
			}
		}

		private void RefreshPages()
		{
			List<CollectionElement> list = new List<CollectionElement>();
			int num = m_layout.x * m_layout.y;
			int currentPageIndex = CurrentPageIndex;
			int num2 = 0;
			foreach (CollectionElement item in SortAndFilterContent(GetValidCollectionElements()))
			{
				list.Add(item);
				if (list.Count == num)
				{
					GetPage(num2).SetContent(list, m_layout, m_pageSizeReference, m_pageGridHorSpace);
					num2++;
					list.Clear();
				}
			}
			GetPage(num2).SetContent(list, m_layout, m_pageSizeReference, m_pageGridHorSpace);
			if (list.Count > 0)
			{
				num2++;
			}
			CurrentPageCount = num2;
			ActivatePage((currentPageIndex < CurrentPageCount) ? currentPageIndex : 0);
		}

		private void UpdatePageIndexText()
		{
			int num = ((CurrentPageCount == 0) ? 1 : CurrentPageCount);
			m_pageNumberText.text = $" {CurrentPageIndex + 1} / {num}";
		}

		private void UpdatePageButtonsAvailability()
		{
			if (CurrentPageIndex == 0)
			{
				m_firstPageButton.SetInteractable(value: false);
				m_prevPageButton.SetInteractable(value: false);
				m_nextPageButton.SetInteractable(CurrentPageCount > 1);
				m_lastPageButton.SetInteractable(CurrentPageCount > 1);
			}
			else if (CurrentPageIndex >= CurrentPageCount - 1)
			{
				m_firstPageButton.SetInteractable(value: true);
				m_prevPageButton.SetInteractable(value: true);
				m_nextPageButton.SetInteractable(value: false);
				m_lastPageButton.SetInteractable(value: false);
			}
			else
			{
				m_firstPageButton.SetInteractable(value: true);
				m_prevPageButton.SetInteractable(value: true);
				m_nextPageButton.SetInteractable(value: true);
				m_lastPageButton.SetInteractable(value: true);
			}
		}

		private void CloseFilters()
		{
			m_filterDropdown.Close();
		}

		private void OnCollectedNewPieces()
		{
		}

		private void OnStartAssembleMiniature(int uid, bool newMiniature)
		{
			TabletopWorld.TabletopHUDPopup.CloseModule();
		}

		private void OnCompleteAssembleMiniature(int uid)
		{
			Collection.Open(ECollectionMode.BROWSE, delegate
			{
				m_miniaturePopup.Open(uid);
			});
		}

		private void OnPaintedMiniature(int uid, int c)
		{
			if (base.IsActive)
			{
				RefreshContent();
			}
		}

		private void OnSortTypeChanged(int value)
		{
			m_primarySortType = CollectionSettings.GetSortTypeByIndex(value);
			CloseFilters();
			RefreshContent();
		}

		protected virtual void OnSearchValueChanged(string content)
		{
			m_searchString = content;
			CloseFilters();
			RefreshContent();
		}

		protected virtual void OnValidateSearch()
		{
			CloseFilters();
			RefreshContent();
		}

		private void OnAnyFilterChanged()
		{
			RefreshContent();
		}

		private void OnButton_Statistics()
		{
			m_statisticsPopup.SetActive(active: true);
			CloseFilters();
		}

		private void OnButton_FirstPage()
		{
			CloseFilters();
			ActivatePage(0);
		}

		private void OnButton_PreviousPage()
		{
			CloseFilters();
			ActivatePage(CurrentPageIndex - 1);
		}

		private void OnButton_NextPage()
		{
			CloseFilters();
			ActivatePage(CurrentPageIndex + 1);
		}

		private void OnButton_LastPage()
		{
			CloseFilters();
			ActivatePage(CurrentPageCount - 1);
		}

		private void OnMiniatureButtonClicked(int miniatureUID)
		{
			CloseFilters();
			switch (Collection.Mode)
			{
			case ECollectionMode.BROWSE:
			case ECollectionMode.PAINTING:
				m_miniaturePopup.Open(miniatureUID);
				break;
			case ECollectionMode.SELLING:
				StallInteractable.CurrentlyInteracted.OnMiniatureButtonClicked(miniatureUID);
				break;
			case ECollectionMode.SQUAD_EDITION:
				m_squadEditionScreen.TryAddMiniatureToSquad(miniatureUID);
				break;
			}
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			RefreshContent();
			IUIShouldersInputReceiver.SetCurrent(this);
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			Preview3DManager.Instance.DisableCamera();
			if (m_currentUICollectionPopup != null)
			{
				m_currentUICollectionPopup.SetActive(active: false);
			}
			Collection_HUDPopupModule.Closed?.Invoke();
			IUIShouldersInputReceiver.SetCurrent(null);
		}

		private void OnActivatePopup(UI_CollectionPopup uiCollectionPopup, bool active)
		{
			m_currentUICollectionPopup = (active ? uiCollectionPopup : null);
			ShowCloseButton(!active);
			if (!active && TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				if (GetCurrentPage().GetMiniaturesCount() > 0)
				{
					m_pageContainerNavBox.ResumeSelection();
				}
				else
				{
					SelectCloseButton();
				}
			}
			if (m_currentUICollectionPopup is UI_CollectionMiniaturePopup)
			{
				RegisterMinuaturePopupCallbacks(active);
			}
		}

		protected override void OnCloseButtonClicked()
		{
			if (m_currentUICollectionPopup != null)
			{
				if (m_currentUICollectionPopup.CanBeClosed())
				{
					m_currentUICollectionPopup.SetActive(active: false);
					ShowCloseButton(show: true);
				}
			}
			else if (m_squadEditionScreen.IsActive)
			{
				OnSquadEditionClosed();
			}
			else
			{
				base.OnCloseButtonClicked();
			}
		}

		public override bool OverrideCancel()
		{
			if (m_currentUICollectionPopup != null || m_squadEditionScreen.IsActive)
			{
				return true;
			}
			return false;
		}

		public override void Cancel()
		{
			base.Cancel();
			OnCloseButtonClicked();
		}

		private void OnStartEditingSquad(int index)
		{
			UI_CollectionSquadEditionScreen.CurrentlyEditedSlot = index;
			Collection.SetMode(ECollectionMode.SQUAD_EDITION);
			RefreshContent();
		}

		private void OnSquadEditionClosed()
		{
			Collection.SetMode(ECollectionMode.SQUAD_SELECTION);
			RefreshContent();
		}

		public void OnUIInput_GamepadShoulders(float value)
		{
			if (m_currentUICollectionPopup != null)
			{
				if (m_currentUICollectionPopup is UI_CollectionMiniaturePopup)
				{
					OnButton_ChangeMiniature(value);
				}
				return;
			}
			if (value > 0f && m_nextPageButton.IsInteractable())
			{
				OnButton_NextPage();
			}
			else if (value < 0f && m_prevPageButton.IsInteractable())
			{
				OnButton_PreviousPage();
			}
			m_pages[CurrentPageIndex].SelectFirstChild();
		}

		private void RegisterMinuaturePopupCallbacks(bool active)
		{
			if (active)
			{
				m_nextMiniaturePopupArrow.Button.onClick.AddListener(OnButton_NextMiniature);
				m_prevMiniaturePopupArrow.Button.onClick.AddListener(OnButton_PrevMiniature);
			}
			else
			{
				m_nextMiniaturePopupArrow.Button.onClick.RemoveListener(OnButton_NextMiniature);
				m_prevMiniaturePopupArrow.Button.onClick.RemoveListener(OnButton_PrevMiniature);
			}
		}

		private void OnButton_NextMiniature()
		{
			OnButton_ChangeMiniature(1f);
		}

		private void OnButton_PrevMiniature()
		{
			OnButton_ChangeMiniature(-1f);
		}

		private void OnButton_ChangeMiniature(float value)
		{
			UI_CollectionPage currentPage = GetCurrentPage();
			if ((value > 0f && currentPage.GetNextSelectedMiniature(out var button)) || (value < 0f && currentPage.GetPreviousSelectedMiniature(out button)))
			{
				m_miniaturePopup.Open(button.Data.UID);
				currentPage.CurrentSelectedButton = button;
				return;
			}
			if (value > 0f && m_nextPageButton.IsInteractable())
			{
				OnButton_NextPage();
			}
			else if (value < 0f && m_prevPageButton.IsInteractable())
			{
				OnButton_PreviousPage();
			}
			currentPage = GetCurrentPage();
			UI_CollectionMiniatureButton currentSelectedButton = currentPage.CurrentSelectedButton;
			if (currentSelectedButton != null)
			{
				m_miniaturePopup.Open(currentSelectedButton.Data.UID);
			}
		}

		private UI_CollectionPage GetCurrentPage()
		{
			return m_pages[m_currentPageIndex];
		}

		private void ToggleBackgroundGraphics(bool value)
		{
			Graphic[] graphicsToHide = m_graphicsToHide;
			for (int i = 0; i < graphicsToHide.Length; i++)
			{
				graphicsToHide[i].enabled = value;
			}
		}
	}
}
