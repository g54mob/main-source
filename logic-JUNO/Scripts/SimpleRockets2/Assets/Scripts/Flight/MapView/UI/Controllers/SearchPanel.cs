using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Packages.SocialPlatforms;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Flight.MapView;
using ModApi.Ioc;
using ModApi.Scenes.Events;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.UI.Controllers
{
	public class SearchPanel : IMapViewSearchPanel
	{
		private class SearchItem
		{
			private bool _selected;

			public bool AllowRename { get; set; }

			public Button Button { get; set; }

			public XmlElement Element { get; set; }

			public MapItem MapItem { get; set; }

			public XmlElement NameElement { get; set; }

			public bool Selected
			{
				get
				{
					return _selected;
				}
				set
				{
					if (_selected != value)
					{
						_selected = value;
						if (value)
						{
							Element.AddClass("selected");
						}
						else
						{
							Element.RemoveClass("selected");
						}
					}
				}
			}

			public ICameraFocusable Target { get; set; }

			public void SetNameText(string name)
			{
				NameElement.SetText(name);
			}
		}

		private ICurrentCameraTarget _cameraTarget;

		private XmlElement _contentRoot;

		private IItemRegistry _itemRegistry;

		private List<SearchItem> _items = new List<SearchItem>();

		private XmlElement _itemTemplate;

		private MapViewUiController _mapViewUi;

		private XmlElement _panelElement;

		private bool _rebuildRequired = true;

		private TMP_InputField _searchInput;

		private SearchItem _selectedItem;

		private bool _visible;

		private SearchItem SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				if (_selectedItem != value)
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
				}
			}
		}

		public SearchPanel(IIocContainer ioc, IMapViewContext mapViewContext, MapViewUiController mapViewUi, XmlElement panelElement)
		{
			ioc.Register((IMapViewSearchPanel)this, (IContext)mapViewContext);
			_mapViewUi = mapViewUi;
			_panelElement = panelElement;
			_itemTemplate = panelElement.GetElementByInternalId("search-item-template");
			_contentRoot = panelElement.GetElementByInternalId("search-content");
			_searchInput = panelElement.GetElementByInternalId<TMP_InputField>("search-input");
			_searchInput.onValueChanged.AddListener(delegate
			{
				FilterSearchItems();
			});
			GameObject parentWithName = Utilities.GetParentWithName(_contentRoot.gameObject, "Viewport");
			if (parentWithName != null)
			{
				Image component = parentWithName.GetComponent<Image>();
				if (component != null)
				{
					component.raycastTarget = false;
				}
			}
			_cameraTarget = ioc.Resolve<ICurrentCameraTarget>(mapViewContext);
			_cameraTarget.TargetChanged += OnSelectTarget;
			_itemRegistry = ioc.Resolve<IItemRegistry>(mapViewContext);
			_itemRegistry.MapItemAdded += delegate
			{
				OnMapItemsChanged();
			};
			_itemRegistry.MapItemRemoved += delegate
			{
				OnMapItemsChanged();
			};
			Game.Instance.SceneManager.SceneTransitionStarted += OnSceneTransitionStarted;
		}

		public void OnDestroy()
		{
			_visible = false;
		}

		public void OnMapItemsChanged()
		{
			if (_visible)
			{
				RebuildSearchItems();
			}
			else
			{
				_rebuildRequired = true;
			}
		}

		public void OnSearchButtonClicked(XmlElement button)
		{
			if (button.HasClass("selected"))
			{
				button.RemoveClass("selected");
			}
			else
			{
				button.AddClass("selected");
			}
			_visible = button.HasClass("selected");
			_panelElement.SetActive(_visible);
			if (_visible)
			{
				if (_rebuildRequired)
				{
					RebuildSearchItems();
				}
				if (!Device.IsMobileBuild && !SocialExt.IsSteamDeckOrBigPicture)
				{
					_searchInput.Select();
				}
			}
		}

		void IMapViewSearchPanel.RefreshSearchItemList()
		{
			RebuildSearchItems();
			_mapViewUi.MapViewInspector.Refresh();
		}

		private void AddElement(string name, MapItem mapItem, bool allowRename)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_itemTemplate, _contentRoot);
			SearchItem item = new SearchItem
			{
				Button = xmlElement.GetComponent<Button>(),
				MapItem = mapItem,
				Element = xmlElement,
				NameElement = xmlElement.GetElementByInternalId("name"),
				Target = (mapItem as ICameraFocusable),
				AllowRename = allowRename
			};
			item.SetNameText(name);
			_items.Add(item);
			item.Button.onClick.AddListener(delegate
			{
				OnItemClicked(item);
			});
			if (allowRename)
			{
				XmlElement elementByInternalId = xmlElement.GetElementByInternalId("rename-button");
				elementByInternalId.AddOnClickEvent(delegate
				{
					OnRenameItemClicked(item);
				});
				elementByInternalId.SetActive(active: true);
			}
		}

		private void FilterSearchItems()
		{
			string text = _searchInput.text;
			foreach (SearchItem item in _items)
			{
				if (item.MapItem.OrbitInfo.OrbitNode.Name.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					item.Button.gameObject.SetActive(value: true);
				}
				else
				{
					item.Button.gameObject.SetActive(value: false);
				}
			}
		}

		private void OnItemClicked(SearchItem item)
		{
			ICameraFocusable cameraFocus = item.MapItem as ICameraFocusable;
			_mapViewUi.MapView.SetCameraFocus(cameraFocus, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
		}

		private void OnRenameItemClicked(SearchItem item)
		{
			if (item.AllowRename)
			{
				CraftNode node = item.MapItem?.OrbitInfo?.OrbitNode as CraftNode;
				ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
				inputDialogScript.InputText = node.Name;
				inputDialogScript.MessageText = "Rename Craft";
				inputDialogScript.InputPlaceholderText = "Craft Name";
				inputDialogScript.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
				{
					d.Close();
					RenameNode(node, item, d.InputText);
				};
			}
			else
			{
				Debug.LogFormat("Cannot rename this item");
			}
		}

		private void OnSceneTransitionStarted(object sender, SceneTransitionEventArgs e)
		{
			Game.Instance.SceneManager.SceneTransitionStarted -= OnSceneTransitionStarted;
			_visible = false;
		}

		private void OnSelectTarget(ICameraFocusable target)
		{
			SearchItem selectedItem = _items.Where((SearchItem x) => x.Target == target).FirstOrDefault();
			SelectedItem = selectedItem;
		}

		private void RebuildSearchItems()
		{
			_rebuildRequired = false;
			SelectedItem = null;
			foreach (SearchItem item in _items)
			{
				item.Button.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(item.Button.gameObject);
			}
			_items.Clear();
			foreach (MapItem item2 in _itemRegistry.Items.OrderBy((MapItem x) => x.OrbitInfo.OrbitNode.Name))
			{
				if (item2 is ITargetableItem)
				{
					bool flag = true;
					bool allowRename = false;
					if (item2.OrbitInfo.OrbitNode is CraftNode craftNode)
					{
						flag = craftNode.HasCommandPod;
						allowRename = true;
					}
					if (flag)
					{
						AddElement(item2.OrbitInfo.OrbitNode.Name, item2, allowRename);
					}
				}
			}
			FilterSearchItems();
			OnSelectTarget(_cameraTarget.Target);
		}

		private void RenameNode(CraftNode node, SearchItem item, string inputText)
		{
			node.Name = inputText;
			item.SetNameText(inputText);
			_mapViewUi.MapViewInspector.Refresh();
		}
	}
}
