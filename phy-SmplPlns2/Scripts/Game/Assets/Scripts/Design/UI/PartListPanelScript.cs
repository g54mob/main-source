using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Levels;
using Assets.Scripts.Mods;
using Assets.Scripts.UI;
using Jundroo.Common.Pool;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design.UI
{
	public class PartListPanelScript : DesignerPanelScript
	{
		private class Category
		{
			public string Icon { get; set; }

			public LoadedMod Mod { get; set; }

			public string Name { get; set; }

			public List<DesignerPart> Parts { get; private set; }

			public Category(string name, string icon)
			{
				Name = name;
				Icon = icon;
				Parts = new List<DesignerPart>();
			}
		}

		private class PartButton
		{
			public string PartName { get; private set; }

			public string PartNameLowerCase { get; private set; }

			public Widget Widget { get; private set; }

			public PartButton(string partName, Widget widget)
			{
				PartName = partName;
				PartNameLowerCase = partName.ToLower();
				Widget = widget;
			}
		}

		private static Dictionary<string, bool> _collapsedStates = new Dictionary<string, bool>();

		private List<PartButton> _buttons;

		private List<Category> _categories;

		private List<HeaderScript> _headers = new List<HeaderScript>();

		private Widget _itemsParent;

		private LevelInfo _levelInfo;

		private DesignerPartList _partList;

		private bool _refreshAfterSubassemblyAdded;

		private InputWidget _searchFilter;

		private PartButtonScript _selectedPartButton;

		private bool _showingPartList;

		public DesignerPartList PartList => _partList;

		public void AddPart(PartButtonScript partButtonScript, PointerEventData eventData)
		{
			base.DesignerUI.ScreenInput.AddPartStart(partButtonScript.Part, eventData);
		}

		public void CategorySelected(string categoryName)
		{
			base.Flyout.Title = categoryName;
			Category category = GetCategory(categoryName);
			BuildPartList(category.Parts, categoryName);
		}

		public void CreateSubassembly(string name, Assembly assembly)
		{
			_partList.CreateSubassembly(name, assembly);
			_refreshAfterSubassemblyAdded = true;
		}

		public void DeleteSubassembly(DesignerPart subassemblyPart)
		{
			_partList.DeleteSubassembly(subassemblyPart);
			RefreshPartList("Sub Assemblies");
		}

		public void FinishedAddingPart(PointerEventData eventData)
		{
			base.DesignerUI.ScreenInput.AddPartFinish(eventData);
		}

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			_itemsParent = base.Widget.FindWidget("list-item-parent");
			_searchFilter = base.Widget.FindWidget<InputWidget>("search-input");
			_searchFilter.Input.onValueChanged.AddListener(delegate(string s)
			{
				SearchFilterChanged(s);
			});
			base.Flyout.HeaderClicked += OnFlyoutHeaderClicked;
			_levelInfo = Game.Instance.CurrentLevel;
			_partList = base.Designer.PartList;
			_partList.SubassemblyCreated += delegate
			{
				_refreshAfterSubassemblyAdded = true;
			};
		}

		public void MovePart(PointerEventData eventData)
		{
			base.DesignerUI.ScreenInput.AddPartMove(eventData);
		}

		public void RefreshPartList(string reselectCategory)
		{
			foreach (Category category in _categories)
			{
				category.Parts.Clear();
			}
			foreach (DesignerPart part in _partList.Parts)
			{
				GetCategory(part.Category).Parts.Add(part);
			}
			if (string.IsNullOrEmpty(reselectCategory))
			{
				BuildCategories();
			}
			else
			{
				CategorySelected(reselectCategory);
			}
		}

		public void SelectPartButton(PartButtonScript partButton)
		{
			if (_selectedPartButton != partButton)
			{
				if (_selectedPartButton != null)
				{
					_selectedPartButton.Selected = false;
				}
				_selectedPartButton = partButton;
				if (_selectedPartButton != null)
				{
					_selectedPartButton.Selected = true;
				}
			}
		}

		protected virtual void Start()
		{
			_buttons = new List<PartButton>();
			_categories = new List<Category>
			{
				new Category("Structure", "GroupIconStructure"),
				new Category("Wings", "GroupIconWing"),
				new Category("Aircraft Propulsion", "GroupIconPropulsion"),
				new Category("Engines", "GroupIconEngine"),
				new Category("Wheels", "GroupIconWheel"),
				new Category("Weapons", "GroupIconWeapon"),
				new Category("Interiors", "GroupIconCockpitInterior"),
				new Category("Gizmos", "GroupIconGizmos"),
				new Category("Sub Assemblies", "GroupIconSubAssembly")
			};
			foreach (PartCategoryInfo categoryInfo in _partList.Categories)
			{
				Category category = _categories.FirstOrDefault((Category x) => x.Name == categoryInfo.Name);
				if (category == null)
				{
					category = new Category(categoryInfo.Name, "GroupIconDrill");
					_categories.Add(category);
				}
				if (categoryInfo.Mod != null && !string.IsNullOrEmpty(categoryInfo.IconPath))
				{
					category.Mod = categoryInfo.Mod;
					category.Icon = categoryInfo.IconPath;
				}
			}
			RefreshPartList(null);
		}

		protected virtual void Update()
		{
			if (_refreshAfterSubassemblyAdded)
			{
				_refreshAfterSubassemblyAdded = false;
				RefreshPartList("Sub Assemblies");
			}
		}

		private PartButton AddPartButton(string name, string icon, DesignerPart part, Category category)
		{
			PartButton result = null;
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate("part-button", _itemsParent);
			if (widget != null)
			{
				Texture2D texture = null;
				if (part != null)
				{
					widget.Tooltip = part.Name + "\n" + part.Description;
					texture = ((part != null && part.Mod != null) ? part.Mod.ResourceLoader.LoadAsset<Texture2D>(icon) : Resources.Load<Texture2D>("Craft/Parts/Textures/Icons/" + icon));
				}
				else if (category != null)
				{
					texture = ((category != null && category.Mod != null) ? category.Mod.ResourceLoader.LoadAsset<Texture2D>(icon) : Resources.Load<Texture2D>("UI/Sprites/Design/Parts/" + icon));
				}
				widget.GetComponentInChildren<PartButtonScript>().Initialize(this, name, part, category?.Name, texture);
				result = new PartButton(name, widget);
			}
			return result;
		}

		private void BuildCategories()
		{
			ClearList();
			_searchFilter.Parent.Visible = false;
			foreach (Category category in _categories)
			{
				if (!_levelInfo.RestrictedCategories.Contains(category.Name))
				{
					_buttons.Add(AddPartButton(category.Name, category.Icon, null, category));
				}
			}
			_showingPartList = false;
		}

		private void BuildPartList(List<DesignerPart> parts, string category)
		{
			ClearList();
			_searchFilter.Parent.Visible = category == "Sub Assemblies";
			_searchFilter.Text = string.Empty;
			string text = string.Empty;
			HashSet<string> value;
			using (CollectionPool<HashSet<string>, string>.Get(out value))
			{
				foreach (DesignerPart part in parts)
				{
					if (!string.IsNullOrWhiteSpace(part.Header))
					{
						text = part.Header;
						if (value.Add(text))
						{
							CreateHeaderElement(text);
						}
					}
					else
					{
						part.Header = text;
					}
					if (!_levelInfo.RestrictedDesignerParts.Contains(part.Name))
					{
						_buttons.Add(AddPartButton(part.Name, part.Icon, part, null));
					}
				}
				_showingPartList = true;
			}
		}

		private void ClearList()
		{
			SelectPartButton(null);
			foreach (PartButton button in _buttons)
			{
				button.Widget.Destroy();
			}
			foreach (HeaderScript header in _headers)
			{
				header.CollapsedStateChanged -= OnHeaderCollapsedStateChanged;
				header.Widget.Destroy();
			}
			_buttons.Clear();
			_headers.Clear();
		}

		private void CreateHeaderElement(string headerText)
		{
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate("control-header", base.Widget);
			HeaderScript componentInChildren = widget.GetComponentInChildren<HeaderScript>();
			componentInChildren.name = "PartHeader-" + headerText;
			_headers.Add(componentInChildren);
			componentInChildren.LabelText = headerText;
			if (_collapsedStates.ContainsKey(headerText))
			{
				componentInChildren.StartCollapsed = _collapsedStates[headerText];
			}
			componentInChildren.CollapsedStateChanged += OnHeaderCollapsedStateChanged;
			widget.FindWidgetsByClass("control-header-contents").FirstOrDefault()?.Show();
		}

		private Category GetCategory(string name)
		{
			foreach (Category category2 in _categories)
			{
				if (category2.Name.ToLower() == name.ToLower())
				{
					return category2;
				}
			}
			Category category = new Category(name, "PartIconBlock1x1");
			_categories.Add(category);
			return category;
		}

		private void OnFlyoutHeaderClicked(IFlyout flyout)
		{
			if (_showingPartList)
			{
				base.Flyout.Title = "Parts";
				BuildCategories();
			}
			else
			{
				flyout.Close();
			}
		}

		private void OnHeaderCollapsedStateChanged(object sender, HeaderScript.CollapsedStateChangedEventArgs e)
		{
			_collapsedStates[e.Header.LabelText] = e.IsCollapsed;
		}

		private void SearchFilterChanged(string searchFilter)
		{
			searchFilter = searchFilter.Trim().ToLower();
			foreach (PartButton button in _buttons)
			{
				button.Widget.Visible = string.IsNullOrEmpty(searchFilter) || button.PartNameLowerCase.Contains(searchFilter);
			}
		}
	}
}
