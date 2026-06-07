using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Packages.SocialPlatforms;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class ListViewScript : MonoBehaviour
	{
		public enum ListViewDisplayType
		{
			ObjectPreview = 0,
			LargeDialog = 1,
			SmallDialog = 2
		}

		public enum PrimaryButtonStyleType
		{
			Primary = 0,
			Danger = 1,
			Warning = 2,
			Success = 3
		}

		public enum SpriteLoadLocation
		{
			Resources = 0,
			File = 1
		}

		private static Dictionary<string, bool> _filterStates = new Dictionary<string, bool>();

		private GameObject _addButton;

		private bool _canDelete = true;

		private float _clickTime;

		private bool _closed;

		private XmlElement _contextMenu;

		private XmlElement _contextMenuItemTemplate;

		private XmlElement _contextMenuSeparatorTemplate;

		private XmlElement _contextMenuToggle;

		private string _currentSearchFilter;

		private GameObject _deleteButton;

		private TextMeshProUGUI _detailsTitleText;

		private IDialog _dialog;

		private List<ListViewFilter> _filters;

		private XmlElement _footer;

		private XmlElement _itemsParent;

		private ListViewDetailsScript _listViewDetails;

		private TextMeshProUGUI _loadingText;

		private XmlElement _noSelectionMessage;

		private string _notificationId;

		private XmlElement _notificationPanel;

		private XmlElement _panel;

		private XmlLayoutButtonComponent _primaryButton;

		private XmlElement _primaryButtonElement;

		private PrimaryButtonStyleType _primaryButtonStyle;

		private TextMeshProUGUI _primaryButtonText;

		private TMP_InputField _searchInput;

		private ListViewItemScript _selectedItem;

		private Dictionary<string, Sprite> _spriteCache = new Dictionary<string, Sprite>();

		private TextMeshProUGUI _titleText;

		private bool _useGrid;

		private XmlLayout _xmlLayout;

		public bool AllowCameraZoom => false;

		public bool CanDelete
		{
			get
			{
				return _canDelete;
			}
			set
			{
				_canDelete = value;
				_deleteButton.SetActive(_canDelete);
			}
		}

		public bool ContextMenuVisible
		{
			get
			{
				return _contextMenu.Visible;
			}
			set
			{
				if (_contextMenu.Visible != value)
				{
					if (value)
					{
						_contextMenu.Show();
					}
					else
					{
						_contextMenu.Hide();
					}
				}
			}
		}

		public string DetailsTitleText
		{
			get
			{
				return _detailsTitleText?.text ?? string.Empty;
			}
			set
			{
				if (_detailsTitleText != null)
				{
					_detailsTitleText.text = value;
				}
			}
		}

		public ListViewDisplayType DisplayType { get; set; }

		public IReadOnlyList<ListViewFilter> Filters => _filters;

		public bool FooterEnabled { get; set; } = true;

		public ListViewDetailsScript ListViewDetails => _listViewDetails;

		public string NoSelectionMessageText
		{
			get
			{
				return _noSelectionMessage.GetAttribute("text", string.Empty);
			}
			set
			{
				_noSelectionMessage.SetAndApplyAttribute("text", value);
			}
		}

		public IListViewObjectViewer ObjectViewer { get; private set; }

		public bool PrimaryButtonEnabled
		{
			get
			{
				return _primaryButton.interactable;
			}
			set
			{
				_primaryButton.interactable = value;
			}
		}

		public PrimaryButtonStyleType PrimaryButtonStyle
		{
			get
			{
				return _primaryButtonStyle;
			}
			set
			{
				if (_primaryButtonStyle != value)
				{
					string styleClassName = GetStyleClassName(_primaryButtonStyle);
					_primaryButtonElement.RemoveClass(styleClassName);
					_primaryButtonStyle = value;
					string styleClassName2 = GetStyleClassName(_primaryButtonStyle);
					_primaryButtonElement.AddClass(styleClassName2);
				}
			}
		}

		public string PrimaryButtonText
		{
			get
			{
				return _primaryButtonText.text;
			}
			set
			{
				_primaryButtonText.text = value;
			}
		}

		public ListViewItemScript SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				if (!(_selectedItem != value))
				{
					return;
				}
				if (_selectedItem != null)
				{
					_selectedItem.Selected = false;
				}
				_selectedItem = value;
				if (_selectedItem != null)
				{
					_selectedItem.Selected = true;
					if (FooterEnabled)
					{
						_footer.Show();
					}
					_noSelectionMessage.SetActive(active: false);
					UpdateSelectedItem(value);
					return;
				}
				if (FooterEnabled)
				{
					_footer.Hide();
				}
				ObjectViewer?.PreviewObject(null);
				_listViewDetails.Visible = false;
				_noSelectionMessage.SetActive(active: true);
				DetailsTitleText = string.Empty;
				ViewModel.OnSelectedItemChanged(null);
			}
		}

		public bool ShowAddButton
		{
			get
			{
				return _addButton.activeSelf;
			}
			set
			{
				_addButton.SetActive(value);
			}
		}

		public string Title
		{
			get
			{
				return _titleText.text;
			}
			set
			{
				_titleText.text = value;
			}
		}

		public bool TranslucentBackground { get; set; } = true;

		public ListViewModel ViewModel { get; private set; }

		public XmlLayout XmlLayout => _xmlLayout;

		public event EventHandler Closed;

		public ListViewScript()
		{
			_filters = new List<ListViewFilter>();
			_currentSearchFilter = string.Empty;
		}

		public void Close()
		{
			if (!_closed)
			{
				_closed = true;
				ViewModel.OnClosed();
				this.Closed?.Invoke(this, new EventArgs());
			}
		}

		public void CloseNotification()
		{
			if (_notificationPanel != null)
			{
				_notificationPanel.Hide();
				if (!string.IsNullOrWhiteSpace(_notificationId))
				{
					Game.Instance.Settings.AddNotification(_notificationId);
					_notificationId = null;
				}
			}
		}

		public ContextMenuItemScript CreateContextMenuItem(string text, Action<ContextMenuItemScript> clickHandler = null, string tooltip = null, bool closeWhenClicked = true)
		{
			_contextMenuToggle.Show();
			XmlLayout.GetElementById("details-title-text")?.AddClass("avoid-context-menu");
			XmlElement xmlElement = UiUtilities.CloneTemplate(_contextMenuItemTemplate, _contextMenu);
			ContextMenuItemScript contextMenuItemScript = xmlElement.gameObject.AddComponent<ContextMenuItemScript>();
			contextMenuItemScript.Initialize(xmlElement);
			contextMenuItemScript.Text = text;
			contextMenuItemScript.Tooltip = tooltip;
			contextMenuItemScript.ClickHandler = clickHandler;
			contextMenuItemScript.CloseContextMenuWhenClicked = closeWhenClicked;
			return contextMenuItemScript;
		}

		public XmlElement CreateContextMenuSeparator()
		{
			return UiUtilities.CloneTemplate(_contextMenuSeparatorTemplate, _contextMenu);
		}

		public ContextMenuItemScript CreateFilter(bool defaultState, string text, string tooltip, ListViewFilterType type, bool invertEnabledLogic, params string[] keywords)
		{
			ListViewFilter filter = new ListViewFilter(text, tooltip, type, invertEnabledLogic, keywords);
			filter.Enabled = GetFilterState(text, defaultState);
			ContextMenuItemScript contextMenuItemScript = CreateContextMenuItem(text, delegate(ContextMenuItemScript x)
			{
				OnFilterClicked(x, filter);
			}, tooltip, closeWhenClicked: false);
			contextMenuItemScript.Selected = filter.Enabled;
			_filters.Add(filter);
			return contextMenuItemScript;
		}

		public ListViewItemScript CreateItem(string name, string subtitle, object itemModel, string sprite = null, SpriteLoadLocation? spriteLocation = SpriteLoadLocation.Resources, string itemTemplateOverride = null)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(GetItemTemplate(sprite != null, itemTemplateOverride), _itemsParent);
			ListViewItemScript listViewItemScript = xmlElement.gameObject.AddComponent<ListViewItemScript>();
			listViewItemScript.gameObject.name = Title + "." + name;
			listViewItemScript.Initialize(xmlElement);
			listViewItemScript.Title = name;
			listViewItemScript.Subtitle = subtitle;
			listViewItemScript.ItemModel = itemModel;
			if (sprite != null)
			{
				if (spriteLocation == SpriteLoadLocation.File)
				{
					listViewItemScript.Sprite = LoadSpriteFromFile(sprite);
				}
				else
				{
					listViewItemScript.SpriteResourcePath = string.Format(sprite);
				}
			}
			ViewModel.Items.Add(listViewItemScript);
			return listViewItemScript;
		}

		public void DeleteItem(ListViewItemScript item)
		{
			item.XmlElement.parentElement.RemoveChildElement(item.XmlElement);
			item.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(item.gameObject);
		}

		public void DisablePrimaryButtonSound()
		{
			_primaryButtonElement.RemoveClass("audio-btn-big");
		}

		public virtual void Initialize(XmlLayout xmlLayout, XmlLayoutController xmlController, ListViewModel viewModel, IListViewObjectViewer objectViewer, IDialog dialog, bool useGrid = false)
		{
			_dialog = dialog;
			_useGrid = useGrid;
			xmlController.EventTarget = this;
			InitializeLayout(xmlLayout);
			ViewModel = viewModel;
			ObjectViewer = objectViewer;
			ObjectViewer?.PreviewObject(null);
			ViewModel.OnListViewInitialized(this);
			UpdateLayout();
		}

		public Sprite LoadSpriteFromFile(string path)
		{
			if (!_spriteCache.ContainsKey(path))
			{
				Texture2D texture2D = Utilities.LoadTextureFromFile(path);
				if (texture2D != null)
				{
					texture2D.wrapMode = TextureWrapMode.Clamp;
					_spriteCache[path] = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0f, 0f), 100f, 0u, SpriteMeshType.FullRect);
				}
				else
				{
					_spriteCache[path] = null;
					Debug.LogError("Could not load texture from " + path);
				}
			}
			return _spriteCache[path];
		}

		public void OnAddButtonClicked()
		{
			ViewModel.OnAddButtonClicked(SelectedItem);
		}

		public void OnContextMenuButtonClicked()
		{
			_contextMenu.ToggleVisibility();
		}

		public void OnDeleteButtonClicked()
		{
			if (SelectedItem != null)
			{
				ViewModel.OnDeleteButtonClicked(SelectedItem);
			}
		}

		public void OnPrimaryButtonClicked()
		{
			if (SelectedItem != null)
			{
				ViewModel.OnPrimaryButtonClicked(SelectedItem);
			}
		}

		public void ReloadItems()
		{
			foreach (ListViewItemScript item in ViewModel.Items)
			{
				if (item != null)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			ViewModel.Items.Clear();
			StartCoroutine(LoadItems());
		}

		public bool ShowNotification(string id, string text)
		{
			if (!Game.Instance.Settings.SeenNotifications.Contains(id) && _notificationPanel != null)
			{
				_notificationId = id;
				_notificationPanel.Show();
				_notificationPanel.GetElementByInternalId<TextMeshProUGUI>("notification-text").text = text;
				return true;
			}
			return false;
		}

		protected virtual void Start()
		{
			_listViewDetails.Visible = false;
			_searchInput.text = string.Empty;
			if (!Device.IsMobileBuild && !SocialExt.IsSteamDeckOrBigPicture)
			{
				_searchInput.Select();
			}
			_panel.Show(recursiveCall: false, delegate
			{
				StartCoroutine(LoadItems());
			});
		}

		protected virtual void Update()
		{
			if (_dialog == null || Game.Instance.UserInterface.ActiveDialog == _dialog)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
				{
					OnCloseButtonClicked();
				}
				if (UnityEngine.Input.GetKeyDown(KeyCode.Return))
				{
					OnPrimaryButtonClicked();
				}
				if (UnityEngine.Input.GetKeyDown(KeyCode.F) && UnityEngine.Input.GetKey(KeyCode.LeftControl))
				{
					_searchInput.Select();
				}
				if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
				{
					AdvanceSelection(1);
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
				{
					AdvanceSelection(-1);
				}
			}
		}

		private void AdvanceSelection(int direction)
		{
			List<ListViewItemScript> list = ViewModel.Items.Where((ListViewItemScript x) => x.Visible).ToList();
			int index = Mathf.Clamp(list.IndexOf(SelectedItem) + direction, 0, list.Count - 1);
			SelectedItem = list.ElementAt(index);
		}

		private string GetFilterKeyName(string filterName)
		{
			return "ListView." + Title + "." + filterName;
		}

		private bool GetFilterState(string filterName, bool defaultValue)
		{
			string filterKeyName = GetFilterKeyName(filterName);
			return Game.Instance.Settings.UserPrefs.GetBool(filterKeyName, defaultValue);
		}

		private XmlElement GetItemTemplate(bool sprite, string itemTemplateOverride)
		{
			string id = "list-item-template";
			if (itemTemplateOverride != null)
			{
				id = itemTemplateOverride;
			}
			else if (_useGrid)
			{
				id = "grid-list-icon-item-template";
			}
			else if (sprite)
			{
				id = "list-icon-item-template";
			}
			return _xmlLayout.GetElementById(id);
		}

		private string GetStyleClassName(PrimaryButtonStyleType primaryButtonStyle)
		{
			return primaryButtonStyle switch
			{
				PrimaryButtonStyleType.Primary => "btn-primary", 
				PrimaryButtonStyleType.Danger => "btn-danger", 
				PrimaryButtonStyleType.Warning => "btn-warning", 
				PrimaryButtonStyleType.Success => "btn-success", 
				_ => string.Empty, 
			};
		}

		private void InitializeLayout(XmlLayout xmlLayout)
		{
			_xmlLayout = xmlLayout;
			_panel = xmlLayout.GetElementById("panel");
			_deleteButton = xmlLayout.GetElementById("delete-button").gameObject;
			_addButton = xmlLayout.GetElementById("add-button").gameObject;
			ShowAddButton = false;
			_footer = xmlLayout.GetElementById("footer");
			if (_useGrid)
			{
				_itemsParent = xmlLayout.GetElementById("grid-items-parent");
				UnityEngine.Object.Destroy(xmlLayout.GetElementById("items-parent")?.gameObject);
			}
			else
			{
				_itemsParent = xmlLayout.GetElementById("items-parent");
				UnityEngine.Object.Destroy(xmlLayout.GetElementById("grid-items-parent")?.gameObject);
			}
			_itemsParent.SetActive(active: true);
			_loadingText = xmlLayout.GetElementById<TextMeshProUGUI>("loading-text");
			_primaryButtonElement = xmlLayout.GetElementById("primary-button");
			_primaryButtonText = xmlLayout.GetElementById<TextMeshProUGUI>("primary-button-text");
			_searchInput = xmlLayout.GetElementById<TMP_InputField>("search-input");
			_titleText = xmlLayout.GetElementById<TextMeshProUGUI>("title-text");
			_noSelectionMessage = xmlLayout.GetElementById("no-selection-message");
			_contextMenu = xmlLayout.GetElementById("item-context-menu");
			_contextMenuItemTemplate = xmlLayout.GetElementById("context-menu-item-template");
			_contextMenuSeparatorTemplate = xmlLayout.GetElementById("context-menu-separator-template");
			_contextMenuToggle = xmlLayout.GetElementById("context-menu-toggle");
			_primaryButton = _primaryButtonText.transform.parent.GetComponent<XmlLayoutButtonComponent>();
			XmlElement elementById = xmlLayout.GetElementById("details");
			_listViewDetails = elementById.gameObject.AddComponent<ListViewDetailsScript>();
			_listViewDetails.Initialize(elementById, this);
			_detailsTitleText = xmlLayout.GetElementById<TextMeshProUGUI>("details-title-text");
			_notificationPanel = xmlLayout.GetElementById("notification-panel");
			_panel.SetAttribute("active", "false");
		}

		private IEnumerator LoadItems()
		{
			_loadingText.text = "LOADING";
			_loadingText.gameObject.SetActive(value: true);
			yield return new WaitForEndOfFrame();
			yield return ViewModel.LoadItems();
			SimpleContentSizeFitter sizeFitter = _itemsParent.GetComponentInParent<SimpleContentSizeFitter>();
			sizeFitter.enabled = false;
			yield return new WaitForEndOfFrame();
			sizeFitter.enabled = true;
			sizeFitter.MatchChildDimensions();
			_loadingText.gameObject.SetActive(value: false);
			ViewModel.OnFiltersChanged(_currentSearchFilter, Filters);
			ViewModel.OnItemsLoaded();
			if (ViewModel.Items.Count == 0)
			{
				_loadingText.text = ViewModel.NoItemsFoundMessage;
				_loadingText.gameObject.SetActive(value: true);
			}
		}

		private void OnCloseButtonClicked()
		{
			ViewModel.OnCanceled();
			Close();
		}

		private void OnContextMenuItemClicked(XmlElement element)
		{
			ContextMenuItemScript component = element.GetComponent<ContextMenuItemScript>();
			component.ClickHandler?.Invoke(component);
			if (component.CloseContextMenuWhenClicked)
			{
				ContextMenuVisible = false;
			}
		}

		private void OnFilterClicked(ContextMenuItemScript contextMenuItem, ListViewFilter filter)
		{
			filter.Enabled = !filter.Enabled;
			contextMenuItem.Selected = filter.Enabled;
			SetFilterState(filter.Text, filter.Enabled);
			ViewModel.OnFiltersChanged(_currentSearchFilter, Filters);
		}

		private void OnListItemClicked(XmlElement element)
		{
			ListViewItemScript listViewItemScript = null;
			if (element != null)
			{
				listViewItemScript = element.GetComponent<ListViewItemScript>();
			}
			if (SelectedItem != listViewItemScript)
			{
				SelectedItem = listViewItemScript;
				if (SelectedItem != null)
				{
					_clickTime = Time.time;
				}
			}
			else if (SelectedItem != null)
			{
				if (Time.time - _clickTime < 0.5f && ViewModel.DoubleClickIsPrimaryClick)
				{
					OnPrimaryButtonClicked();
				}
				else
				{
					_clickTime = Time.time;
				}
			}
		}

		private void OnSearchChanged(string text)
		{
			if (text == null)
			{
				text = string.Empty;
			}
			_currentSearchFilter = text.ToLower();
			ViewModel.OnFiltersChanged(_currentSearchFilter, Filters);
		}

		private void SetFilterState(string filterName, bool state)
		{
			string filterKeyName = GetFilterKeyName(filterName);
			Game.Instance.Settings.UserPrefs.SetBool(filterKeyName, state);
		}

		private void UpdateLayout()
		{
			XmlLayout component = GetComponent<XmlLayout>();
			XmlElement elementById = component.GetElementById("preview-drag-handler");
			XmlElement elementById2 = component.GetElementById("background");
			if (DisplayType == ListViewDisplayType.ObjectPreview)
			{
				elementById.gameObject.AddComponent<PreviewDragHandler>().Initialize(elementById, this);
				elementById2.AddClass("transparent-background");
				return;
			}
			_panel.AddClass("no-preview");
			if (DisplayType == ListViewDisplayType.SmallDialog)
			{
				_panel.AddClass("small");
			}
			elementById.SetActive(active: false);
			if (!TranslucentBackground)
			{
				elementById2.AddClass("opaque-background");
			}
		}

		private void UpdateSelectedItem(ListViewItemScript item)
		{
			DetailsTitleText = item?.Title ?? string.Empty;
			ViewModel.OnSelectedItemChanging(item, delegate
			{
				ViewModel.UpdateDetails(item, delegate
				{
					_listViewDetails.Visible = true;
					TryUpdatePreview(delegate
					{
						ViewModel.OnSelectedItemChanged(item);
					});
				});
			});
			void TryUpdatePreview(Action completeCallback)
			{
				try
				{
					ViewModel.UpdatePreview(item, ObjectViewer, completeCallback);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					ObjectViewer?.PreviewObject(null);
					ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
					messageDialogScript.MessageText = $"Failed to load item preview.";
					messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
					{
						d.Close();
						completeCallback?.Invoke();
					};
				}
			}
		}
	}
}
