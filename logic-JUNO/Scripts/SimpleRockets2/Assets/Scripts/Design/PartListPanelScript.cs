using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Ui;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Levels;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Settings.Core;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class PartListPanelScript : DesignerFlyoutPanelScript
	{
		private List<(DesignerPartCategory Category, XmlElement XmlElement)> _categories;

		private PartListItemScript _hoveredPartItem;

		private XmlElement _parts;

		private XmlElement _popupElement;

		private float _popupTimer;

		private bool _refreshSubassemblyList;

		private int _selectedCategoryIndex = -1;

		private XmlElement _subassemblies;

		private XmlElement _subassemblyListItemPrefab;

		private XmlElement _templatePart;

		private XmlElement _templatePartCategory;

		private IGameStateValidator _validator;

		public IReadOnlyList<DesignerPartCategory> Categories { get; private set; }

		public DesignerPartList DesignerParts { get; private set; }

		public PartListItemScript HoveredPartItem
		{
			get
			{
				return _hoveredPartItem;
			}
			set
			{
				if (_hoveredPartItem != value)
				{
					_hoveredPartItem = value;
					_popupElement.Hide(recursiveCall: false, delegate
					{
						_popupTimer = 0.2f;
					});
				}
			}
		}

		public int SelectedCategoryIndex
		{
			get
			{
				return _selectedCategoryIndex;
			}
			set
			{
				if (_selectedCategoryIndex != value)
				{
					if (value < 0 || value >= _categories.Count)
					{
						throw new IndexOutOfRangeException();
					}
					_selectedCategoryIndex = value;
					OnPartCategoryButtonClicked(_categories[_selectedCategoryIndex].XmlElement);
				}
			}
		}

		public void AddPart(PartListItemScript partListItem, PointerEventData eventData)
		{
			Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.AddPart);
			base.DesignerUi.DesignerWidget.AddPartStart(partListItem.DesignerPart, eventData);
		}

		public void CreateSubassembly(string name, Assembly subassembly, ICraftScript craftScript)
		{
			DesignerParts.CreateSubassembly(name, subassembly, craftScript);
			_refreshSubassemblyList = true;
		}

		public void FinishedAddingPart(PointerEventData eventData)
		{
			base.DesignerUi.DesignerWidget.AddPartFinish(eventData);
		}

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			_validator = base.DesignerUi.Designer.Validator;
			DesignerParts = new DesignerPartList(Game.Instance.PartTypes);
			if (!DesignerParts.Load())
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "One or more sub-assemblies could not be loaded.";
			}
			base.Flyout.Closed += OnFlyoutClosed;
			RefreshUi();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			base.xmlLayout.GetComponent<RectMask2D>().enabled = false;
			RefreshUi();
		}

		public void MovePart(PointerEventData eventData)
		{
			base.DesignerUi.DesignerWidget.AddPartMove(eventData);
		}

		protected virtual void OnDestroy()
		{
			if (DesignerParts == null || !CurrentDevice.HasAnyFlag(DeviceFlags.LowRam))
			{
				return;
			}
			foreach (DesignerPart part in DesignerParts.Parts)
			{
				part.UnloadIcon();
			}
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
			if (_refreshSubassemblyList)
			{
				_refreshSubassemblyList = false;
				PopulateSubbassemblyList();
			}
			if (_hoveredPartItem != null && !_hoveredPartItem.DesignerPart.IsSubassembly && _popupTimer > 0f)
			{
				_popupTimer -= Time.unscaledDeltaTime;
				if (_popupTimer < 0f)
				{
					UpdateInfoPopup(_hoveredPartItem);
				}
			}
		}

		private void CreatePartListItem(DesignerPart part, XmlElement parent)
		{
			PartListItemScript partListItemScript = UiUtilities.CloneTemplate(_templatePart, parent).gameObject.AddComponent<PartListItemScript>();
			partListItemScript.PartList = this;
			partListItemScript.DesignerPart = part;
			partListItemScript.name = "PartList.Item." + part.Name;
			partListItemScript.IconSprite = part.GetIcon();
		}

		private void CreateSubassemblyListItem(DesignerPart subassembly, Transform parent)
		{
			GameObject obj = UnityEngine.Object.Instantiate(_subassemblyListItemPrefab.gameObject);
			obj.SetActive(value: true);
			obj.GetComponent<XmlElement>().GetElementByInternalId<TextMeshProUGUI>("name").text = subassembly.Name;
			obj.transform.SetParent(parent, worldPositionStays: false);
			PartListItemScript partListItemScript = obj.AddComponent<PartListItemScript>();
			partListItemScript.PartList = this;
			partListItemScript.DesignerPart = subassembly;
		}

		private void FilterSubassemblies(string searchFilter)
		{
			PartListItemScript[] componentsInChildren = _subassemblies.GetComponentsInChildren<PartListItemScript>(includeInactive: true);
			foreach (PartListItemScript partListItemScript in componentsInChildren)
			{
				if (string.IsNullOrEmpty(searchFilter) || partListItemScript.DesignerPart.Name.IndexOf(searchFilter, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					partListItemScript.gameObject.SetActive(value: true);
				}
				else
				{
					partListItemScript.gameObject.SetActive(value: false);
				}
			}
		}

		private void LoadPartListItems(string categoryId, XmlElement contentParent)
		{
			ILevel level = Game.Instance.LevelManager.CurrentLevel;
			DesignerPartCategory category = DesignerPartCategories.GetCategory(categoryId, create: false);
			IEnumerable<DesignerPart> parts = DesignerParts.Parts;
			parts = ((!(categoryId != "All")) ? (from x in parts
				where x.Category.Id != "Sub Assemblies"
				where x.ShowInDesigner
				select x) : parts.Where((DesignerPart x) => x.Category == category && x.ShowInDesigner));
			foreach (DesignerPart item in (from x in parts
				where level == null || x.PartTypes.All((PartType partType) => level.IsPartTypeAllowed(partType))
				orderby x.DisplayOrder, x.Name
				select x).ToList())
			{
				if (categoryId == "Sub Assemblies" || _validator.IsDesignerPartAvailable(item))
				{
					CreatePartListItem(item, contentParent);
				}
			}
		}

		private void OnDeleteSubassemblyClicked(XmlElement deleteButtonElement)
		{
			PartListItemScript subassemblyPart = deleteButtonElement.GetComponentInParent<PartListItemScript>();
			ModApi.Ui.MessageDialogScript dialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			dialog.MessageText = $"Please confirm that you wish to delete this subassembly:\n'{subassemblyPart.DesignerPart.Name}'";
			dialog.UseDangerButtonStyle = true;
			dialog.OkayClicked += delegate
			{
				DesignerParts.DeleteSubassembly(subassemblyPart.DesignerPart);
				UnityEngine.Object.Destroy(subassemblyPart.gameObject);
				dialog.Close();
			};
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			_popupElement.Hide();
		}

		private void OnPartCategoryButtonClicked(XmlElement xmlElement)
		{
			XmlElement[] array = base.xmlLayout.GetElementsByClass("toggle-category").ToArray();
			foreach (XmlElement xmlElement2 in array)
			{
				if (xmlElement2 != xmlElement)
				{
					xmlElement2.RemoveClass("toggle-button-toggled");
				}
			}
			xmlElement.AddClass("toggle-button-toggled");
			string attribute = xmlElement.GetAttribute("data-category-id");
			UpdatePartList(attribute);
		}

		private void PopulateSubbassemblyList()
		{
			XmlElement elementById = base.xmlLayout.GetElementById("subassemblies-content");
			foreach (Transform item in elementById.transform)
			{
				if (item.gameObject != _subassemblyListItemPrefab.gameObject)
				{
					item.gameObject.SetActive(value: false);
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			foreach (DesignerPart part in DesignerParts.Parts)
			{
				if (part.IsSubassembly)
				{
					CreateSubassemblyListItem(part, elementById.transform);
				}
			}
		}

		private void RefreshPartCategories()
		{
			XmlElement elementById = base.xmlLayout.GetElementById("part-category-panel");
			_templatePartCategory = base.xmlLayout.GetElementById("template-part-category");
			if (_templatePartCategory == null)
			{
				Debug.LogError("Unable to find the part category template UI element.");
				return;
			}
			_categories = new List<(DesignerPartCategory, XmlElement)>();
			foreach (DesignerPartCategory item in DesignerPartCategories.Categories.OrderBy((DesignerPartCategory x) => x.DisplayOrder))
			{
				if (!item.CareerModeOnly || Game.IsCareer)
				{
					XmlElement xmlElement = UiUtilities.CloneTemplate(_templatePartCategory, elementById);
					xmlElement.name = "PartList.Category." + item.Id;
					xmlElement.Tooltip = item.Tooltip;
					xmlElement.SetAttribute("name", xmlElement.name);
					xmlElement.SetAttribute("data-category-id", item.Id);
					xmlElement.childElements[0].SetAttribute("sprite", item.IconPath);
					xmlElement.childElements[0].GetComponent<Image>().sprite = item.Icon;
					_categories.Add((item, xmlElement));
				}
			}
			Categories = new List<DesignerPartCategory>(_categories.Select(((DesignerPartCategory Category, XmlElement XmlElement) x) => x.Category));
		}

		private void RefreshUi()
		{
			if (base.DesignerUi != null)
			{
				_templatePart = base.xmlLayout.GetElementById("template-part");
				_parts = base.xmlLayout.GetElementById("parts");
				_subassemblies = base.xmlLayout.GetElementById("subassemblies");
				_subassemblyListItemPrefab = base.xmlLayout.GetElementById("template-subassembly");
				PopulateSubbassemblyList();
				_popupElement = base.xmlLayout.GetElementById("info-popup");
				_popupElement.transform.SetParent(base.DesignerUi.DesignerUiController.transform);
				_popupElement.Hide();
				RefreshPartCategories();
			}
		}

		private void UpdateInfoPopup(PartListItemScript partListItem)
		{
			XmlElement element = partListItem.GetComponent<XmlElement>();
			DesignerPart designerPart = partListItem.DesignerPart;
			_popupElement.GetElementByInternalId("name").SetText(designerPart.Name);
			_popupElement.GetElementByInternalId("description").SetText(designerPart.Description);
			_popupElement.GetElementByInternalId("variable-properties").SetActive(designerPart.VariableProperties);
			if ((designerPart.Mass == 0f || designerPart.Price == 0L) && designerPart.PayloadIds.Count == 0)
			{
				_popupElement.GetElementByInternalId("mass").SetActive(!designerPart.VariableProperties);
				_popupElement.GetElementByInternalId("price").SetActive(!designerPart.VariableProperties);
			}
			else
			{
				_popupElement.GetElementByInternalId("mass").SetActive(active: true);
				_popupElement.GetElementByInternalId("mass").SetText(Units.GetMassString(designerPart.Mass));
				_popupElement.GetElementByInternalId("price").SetActive(active: true);
				_popupElement.GetElementByInternalId("price").SetText(Units.GetPriceString(designerPart.Price));
			}
			_popupElement.transform.position = element.transform.position;
			_popupElement.GetElementByInternalId("engine-details").SetActive(active: false);
			XmlLayoutTimer.DelayedCall(0.01f, delegate
			{
				_popupElement.transform.position = element.transform.position;
			}, this);
			_popupElement.Show();
		}

		private void UpdatePartList(string categoryId)
		{
			DesignerPartCategory category = DesignerPartCategories.GetCategory(categoryId, create: false);
			_selectedCategoryIndex = _categories.FindIndex(((DesignerPartCategory Category, XmlElement XmlElement) x) => x.Category == category);
			XmlElement elementById = base.xmlLayout.GetElementById("parts-content");
			GetComponentInParent<FlyoutScript>().Title = category?.DisplayName ?? categoryId;
			base.xmlLayout.GetElementById("no-category-selected").SetActive(active: false);
			foreach (Transform item in elementById.transform)
			{
				if (item.gameObject != _templatePart.gameObject)
				{
					item.gameObject.SetActive(value: false);
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			if (categoryId == "Sub Assemblies")
			{
				_parts.Hide();
				_subassemblies.Show();
			}
			else
			{
				_parts.Show();
				_subassemblies.Hide();
				LoadPartListItems(categoryId, elementById);
			}
		}
	}
}
