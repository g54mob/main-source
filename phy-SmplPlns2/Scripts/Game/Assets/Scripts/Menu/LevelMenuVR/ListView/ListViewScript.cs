using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Net;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class ListViewScript : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _debugText;

		[SerializeField]
		private ListViewDetailsScript _details;

		[SerializeField]
		private TextMeshProUGUI _errorText;

		[SerializeField]
		private TextMeshProUGUI _headerText;

		[SerializeField]
		private Transform _itemParent;

		[SerializeField]
		private GameObject _itemTemplate;

		[SerializeField]
		private GameObject _loading;

		private int _loadItemsRequestId;

		[SerializeField]
		private GameObject _modsInfoSection;

		[SerializeField]
		private GameObject _navGroupTemplate;

		[SerializeField]
		private GameObject _navItemTemplate;

		[SerializeField]
		private Transform _navParent;

		[SerializeField]
		private GameObject _pageControl;

		[SerializeField]
		private GameObject _pageNextButton;

		[SerializeField]
		private TextMeshProUGUI _pageText;

		private ListViewItemScript _selectedItem;

		private List<NavigationItemScript> _selectedNavFilters = new List<NavigationItemScript>();

		private NavigationItemScript _selectedNavItem;

		public ListViewDetailsScript Details => _details;

		public List<ListViewItemScript> Items { get; private set; } = new List<ListViewItemScript>();

		public int MaxSimultaneousFilters { get; set; } = 1;

		public ListViewModel Model { get; private set; }

		public List<NavigationGroupScript> NavGroups { get; private set; } = new List<NavigationGroupScript>();

		public ListViewItemScript SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				if (value != _selectedItem)
				{
					if (_selectedItem != null)
					{
						_selectedItem.Selected = false;
					}
					_selectedItem = value;
					if (_selectedItem != null)
					{
						_selectedItem.Selected = true;
					}
					if (_selectedItem != null)
					{
						ShowDetails(_selectedItem.Model);
					}
					else
					{
						_details.Visible = false;
					}
				}
			}
		}

		public NavigationItemScript SelectedNavItem
		{
			get
			{
				return _selectedNavItem;
			}
			set
			{
				if (value != _selectedNavItem)
				{
					SelectedItem = null;
					if (_selectedNavItem != null)
					{
						_selectedNavItem.Selected = false;
					}
					_selectedNavItem = value;
					if (_selectedNavItem != null)
					{
						_selectedNavItem.Selected = true;
					}
					Model.OnSelectedNavItemChanged();
				}
			}
		}

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public event Action<ListViewScript> Closed;

		public static ListViewScript CreateListView(ListViewModel model, Transform parent)
		{
			ListViewScript component = (UnityEngine.Object.Instantiate(Resources.Load("Menu/VR/ListView")) as GameObject).GetComponent<ListViewScript>();
			component.transform.SetParent(parent, worldPositionStays: false);
			component.Initialize(model);
			return component;
		}

		public void Close()
		{
			Model.OnClosing();
			this.Closed?.Invoke(this);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public ListViewItemScript CreateItem(ItemModel model)
		{
			GameObject obj = UnityEngine.Object.Instantiate(_itemTemplate);
			obj.transform.SetParent(_itemParent, worldPositionStays: false);
			obj.SetActive(value: true);
			ListViewItemScript component = obj.GetComponent<ListViewItemScript>();
			component.Initialize(model, this);
			Items.Add(component);
			return component;
		}

		public IEnumerator CreateItemsAsync(IEnumerable<ItemModel> items, int loadItemsRequestId)
		{
			foreach (ItemModel item in items)
			{
				yield return item.LoadSpriteAsync();
				if (loadItemsRequestId != _loadItemsRequestId)
				{
					break;
				}
				CreateItem(item);
				yield return new WaitForEndOfFrame();
			}
		}

		public NavigationItemScript CreateNavFilter(NavigationGroupScript navGroup, string name, object userData = null, bool includeInFilterCount = true)
		{
			GameObject obj = UnityEngine.Object.Instantiate(_navItemTemplate);
			obj.transform.SetParent(_navParent, worldPositionStays: false);
			obj.SetActive(value: true);
			NavigationItemScript component = obj.GetComponent<NavigationItemScript>();
			component.Initialize(name, navGroup, this);
			component.IsFilter = true;
			component.IncludeInFilterCount = includeInFilterCount;
			component.UserData = userData;
			navGroup.NavigationItems.Add(component);
			return component;
		}

		public NavigationGroupScript CreateNavGroup(string name)
		{
			GameObject obj = UnityEngine.Object.Instantiate(_navGroupTemplate);
			obj.transform.SetParent(_navParent, worldPositionStays: false);
			obj.SetActive(value: true);
			NavigationGroupScript component = obj.GetComponent<NavigationGroupScript>();
			component.Initialize(name, null, this);
			NavGroups.Add(component);
			return component;
		}

		public NavigationItemScript CreateNavItem(NavigationGroupScript navGroup, string name, object userData = null)
		{
			GameObject obj = UnityEngine.Object.Instantiate(_navItemTemplate);
			obj.transform.SetParent(_navParent, worldPositionStays: false);
			obj.SetActive(value: true);
			NavigationItemScript component = obj.GetComponent<NavigationItemScript>();
			component.Initialize(name, navGroup, this);
			component.UserData = userData;
			navGroup.NavigationItems.Add(component);
			return component;
		}

		public void Initialize(ListViewModel model)
		{
			_details.Initialize(this);
			Model = model;
			Model.OnListViewInitialized(this);
		}

		public void OnDownloadModsButtonClicked()
		{
			WebUtility.OpenUrl("https://www.simpleplanes.com/Mods/SPVR", useInGameOverlayIfAvailable: false);
		}

		public void OnItemClicked(ListViewItemScript listViewItemScript)
		{
			SelectedItem = listViewItemScript;
		}

		public void OnNavItemClicked(NavigationItemScript navigationItemScript)
		{
			if (navigationItemScript.IsFilter)
			{
				SetFilterState(navigationItemScript, !navigationItemScript.IsChecked, notifyModel: true);
			}
			else
			{
				SelectedNavItem = navigationItemScript;
			}
		}

		public void OnPageButtonClicked(int direction)
		{
			Model.AdvancePage(direction);
		}

		public void OnSelectButtonClicked()
		{
			Model.OnSelectButtonClicked(SelectedItem);
		}

		public void RefreshItems()
		{
			StartCoroutine(RefreshItemsAsync());
		}

		public void SetDebugText(string text)
		{
			_debugText.gameObject.SetActive(value: true);
			_debugText.text = text;
		}

		public void SetFilterState(NavigationItemScript navigationItemScript, bool enabled, bool notifyModel)
		{
			if (navigationItemScript.IsChecked == enabled)
			{
				return;
			}
			navigationItemScript.IsChecked = enabled;
			if (navigationItemScript.IncludeInFilterCount)
			{
				if (navigationItemScript.IsChecked)
				{
					_selectedNavFilters.Add(navigationItemScript);
				}
				else
				{
					_selectedNavFilters.Remove(navigationItemScript);
				}
				while (_selectedNavFilters.Count > MaxSimultaneousFilters)
				{
					NavigationItemScript navigationItemScript2 = _selectedNavFilters[0];
					navigationItemScript2.IsChecked = false;
					_selectedNavFilters.Remove(navigationItemScript2);
				}
			}
			Model.OnFiltersChanged();
		}

		public void SetHeaderText(string text)
		{
			_headerText.text = text;
		}

		public void ShowDetails(ItemModel model)
		{
			_details.Visible = true;
			_details.ClearDetailRows();
			Model.UpdateDetailsPanel(model, _details);
		}

		public void ShowErrorMessage(string errorMessage)
		{
			if (!string.IsNullOrEmpty(errorMessage))
			{
				_errorText.gameObject.SetActive(value: true);
				_errorText.text = errorMessage;
			}
			else
			{
				_errorText.gameObject.SetActive(value: false);
				_errorText.text = string.Empty;
			}
		}

		public void ShowModsInfoSection(bool show)
		{
			_modsInfoSection.SetActive(show);
		}

		protected virtual void Awake()
		{
			_details.Visible = false;
			_pageControl.SetActive(value: false);
		}

		protected virtual void Update()
		{
			UpdateDebugText();
		}

		private IEnumerator RefreshItemsAsync()
		{
			int loadId = ++_loadItemsRequestId;
			ShowErrorMessage(null);
			_loading.SetActive(value: true);
			foreach (ListViewItemScript item in Items)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			Items.Clear();
			UpdatePagingUI();
			yield return new WaitForEndOfFrame();
			List<ItemModel> items = new List<ItemModel>();
			yield return Model.LoadItems(items);
			yield return CreateItemsAsync(items, loadId);
			UpdatePagingUI();
			_loading.SetActive(value: false);
			Model.OnItemsFinishedLoading();
		}

		private void UpdateDebugText()
		{
		}

		private void UpdatePagingUI()
		{
			_pageControl.SetActive(Model.PagingEnabled);
			_pageNextButton.SetActive(Model.PageNextEnabled);
			if (Model.PagingEnabled)
			{
				_pageText.text = $"Page {Model.Page}";
			}
		}
	}
}
