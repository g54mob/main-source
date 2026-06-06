using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using I2.Loc;
using PajamaLlama.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace PajamaLlama.SurvivalGuide
{
	public class SurvivalGuide : Panel, ISelectableGroupFirstSelectedProvider, ILocalizationGenderProvider, ILocalizationParamsManager
	{
		[SerializeField]
		[Tooltip("The inputs for which the page indices should be selected when the panel is opened.")]
		private InputFlags _selectableInputs = InputFlags.Joystick;

		[SerializeField]
		private Transform _pagesParent;

		[SerializeField]
		private GameObject _backgroundPatterns;

		[SerializeField]
		private Transform _indexParent;

		[SerializeField]
		private Button _previousButton;

		[SerializeField]
		private Accordion _indexAccordion;

		[Space]
		[SerializeField]
		private ScrollRect _indexScrollRect;

		[SerializeField]
		private ScrollRect _pageScrollRect;

		[Space]
		[SerializeField]
		private GameObject _titleGameObject;

		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private Image _titleImage;

		private SurvivalGuideProperties _properties;

		private Page _selectedPage;

		private List<CategoryPage> _survivalGuide;

		private Dictionary<string, Page> _pages;

		private Stack<Page> _selectionStack;

		private List<CategoryPageIndex> _index;

		private Accordion.Transition _accordionAnimation;

		private static HashSet<string> _pageIds = new HashSet<string>();

		Agent.EGender ILocalizationGenderProvider.LocalizationGender => Agent.EGender.Male;

		private void OnEnable()
		{
			LocalizationManager.ParamManagers.Add(this);
			_indexScrollRect.normalizedPosition = new Vector2(0f, 1f);
			_pageScrollRect.normalizedPosition = new Vector2(0f, 1f);
			if (TryGetSelectedPageIndexSelectable(out var category, out var _))
			{
				FinalUpdate.RegisterOneShot(category.ToggleOn);
			}
			if (_backgroundPatterns != null)
			{
				_backgroundPatterns.SetActive(value: true);
			}
		}

		private void OnDisable()
		{
			if (_backgroundPatterns != null)
			{
				_backgroundPatterns.SetActive(value: false);
			}
			LocalizationManager.ParamManagers.Remove(this);
		}

		private void OnDestroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.OpenSurvivalGuidePage, OnPageOpenEvent);
		}

		public void Initialize(SurvivalGuideProperties properties)
		{
			LocalizationManager.ParamManagers.Add(this);
			_titleGameObject.SetActive(value: false);
			ClearPageIds();
			_properties = properties;
			_survivalGuide = properties.CreateSurvivalGuide();
			_index = GenerateIndex(_survivalGuide, _indexParent);
			_pages = new Dictionary<string, Page>();
			_selectionStack = new Stack<Page>();
			_previousButton.interactable = false;
			_accordionAnimation = _indexAccordion.transition;
			GameEventDispatcher.AddListener(GameEventType.OpenSurvivalGuidePage, OnPageOpenEvent);
			LocalizationManager.ParamManagers.Remove(this);
		}

		private List<CategoryPageIndex> GenerateIndex(List<CategoryPage> survivalGuide, Transform parent)
		{
			List<CategoryPageIndex> list = new List<CategoryPageIndex>();
			foreach (CategoryPage item in survivalGuide)
			{
				CategoryPageIndex categoryPageIndex = UnityEngine.Object.Instantiate(_properties.CategoryIndexPrefab, parent);
				list.Add(categoryPageIndex);
				categoryPageIndex.Initialize(item);
			}
			return list;
		}

		private void OnPageOpenEvent(GameEvent gameEvent)
		{
			if (gameEvent is StringEvent stringEvent)
			{
				Select(stringEvent.Data);
			}
			if (gameEvent is PageEvent pageEvent)
			{
				Select(pageEvent.Page.ID);
			}
			if (!base.gameObject.activeInHierarchy)
			{
				GameManager.UIManager.DisplayPanel(PanelID.SurvivalGuide);
			}
		}

		private void Select(string pageID, bool addToStack = true)
		{
			if (!TryGetPage(out var page, pageID))
			{
				Debug.LogException(new Exception("There is no page with that ID " + pageID + " present."));
				return;
			}
			if (_selectedPage != null)
			{
				_selectedPage.SetActive(active: false);
				if (addToStack)
				{
					_selectionStack.Push(_selectedPage);
				}
			}
			base.gameObject.SetActive(value: true);
			_selectedPage = page;
			_selectedPage.SetActive(active: true);
			_titleGameObject.SetActive(value: true);
			_titleText.text = page.Name;
			_titleImage.gameObject.SetActive(page.Icon != null);
			_titleImage.sprite = page.Icon;
			_previousButton.interactable = _selectionStack.Count > 0;
			new StringEvent(GameEventType.SurvivalGuidePageOpened, _selectedPage.ID).Dispatch();
		}

		public void PreviousPage()
		{
			if (_selectionStack.TryPop(out var result))
			{
				Select(result.ID, addToStack: false);
			}
		}

		public void StopSearching(string text)
		{
			if (text.Length <= 0)
			{
				StopSearching();
			}
		}

		private void StopSearching()
		{
			foreach (CategoryPageIndex item in _index)
			{
				item.gameObject.SetActive(value: true);
				foreach (PageIndex subPageIndex in item.SubPageIndices)
				{
					subPageIndex.gameObject.SetActive(value: true);
				}
				item.Accordion.UpdateGroup();
				item.Accordion.isOn = false;
			}
			_indexAccordion.transition = _accordionAnimation;
		}

		public void Search(string text)
		{
			if (text.Length <= 0)
			{
				StopSearching(text);
				return;
			}
			_indexAccordion.transition = Accordion.Transition.Instant;
			foreach (CategoryPageIndex item in _index)
			{
				int num = 0;
				foreach (PageIndex subPageIndex in item.SubPageIndices)
				{
					bool flag = Regex.IsMatch(subPageIndex.Page.Name, text, RegexOptions.IgnoreCase);
					if (flag)
					{
						num++;
					}
					subPageIndex.gameObject.SetActive(flag);
				}
				if (item.Accordion.group != null)
				{
					item.Accordion.group = null;
				}
				bool flag2 = num > 0;
				item.gameObject.SetActive(flag2);
				item.Accordion.isOn = flag2;
				item.Accordion.OnValueChanged(flag2);
			}
		}

		private bool TryGetPage(out Page page, string pageId)
		{
			if (_pages.TryGetValue(pageId, out page))
			{
				return true;
			}
			if (TryGetPageAndParent(out page, out var parent, pageId))
			{
				page.GenerateWidgets(UnityEngine.Object.Instantiate(_properties.PageParentPrefab, parent));
				_pages.Add(pageId, page);
				return true;
			}
			page = null;
			return false;
		}

		private bool TryGetPageAndParent(out Page page, out Transform parent, string pageId)
		{
			foreach (CategoryPage item in _survivalGuide)
			{
				if (item.TryGetPage<Page>(out page, pageId))
				{
					parent = item.GetTransform(_pagesParent);
					return true;
				}
			}
			page = null;
			parent = null;
			return false;
		}

		internal static string GetUniquePageId(string pageId, string pageName)
		{
			int num = 0;
			string text = pageId;
			while (!_pageIds.Add(text))
			{
				Debug.LogErrorFormat("ID '{0}' for page '{1}' is already in use for another page!", text, pageName);
				text = $"{pageId}_{++num}";
			}
			return text;
		}

		internal static void ClearPageIds()
		{
			_pageIds.Clear();
		}

		public bool TryGetFirstSelected(out Selectable selectable)
		{
			if (TryGetSelectedPageIndexSelectable(out var _, out selectable))
			{
				return FlotsamInputManager.HasActiveInput(_selectableInputs);
			}
			selectable = null;
			return false;
		}

		private bool TryGetSelectedPageIndexSelectable(out CategoryPageIndex category, out Selectable selectable)
		{
			if (_selectedPage != null)
			{
				int count = _index.Count;
				while (0 < count--)
				{
					category = _index[count];
					if (category.TryGetPageIndexSelectable(out selectable, _selectedPage))
					{
						return true;
					}
				}
			}
			category = null;
			selectable = null;
			return false;
		}
	}
}
