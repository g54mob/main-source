using System.Collections.Generic;
using ModApi.Common;
using ModApi.Ui.Inspector;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Inspector
{
	public class ElementBuilder
	{
		private XmlElement _panelContainer;

		private Dictionary<string, XmlElement> _templates = new Dictionary<string, XmlElement>();

		public ElementBuilder(XmlLayoutController controller)
		{
			_panelContainer = controller.xmlLayout.GetElementById("panel-container");
			foreach (XmlElement item in controller.xmlLayout.GetElementsByClass("inspector-template"))
			{
				_templates[item.id] = item;
			}
		}

		public int BuildGroup(GroupModel group, XmlElement parent, List<ItemElement> elements, int index = -1)
		{
			if (!string.IsNullOrEmpty(group.Name))
			{
				HeaderModel headerModel = new HeaderModel(group.Name);
				headerModel.OnMoveItem = group.OnMoveItem;
				headerModel.OnDeleteItem = group.OnDeleteItem;
				group.Header = headerModel;
				CreateElement(headerModel, group, parent, elements, index);
				if (index > -1)
				{
					index++;
				}
			}
			foreach (ItemModel item in group.Items)
			{
				if (item is GroupModel)
				{
					GroupModel groupModel = item as GroupModel;
					index = BuildGroup(groupModel, parent, elements, index);
					continue;
				}
				CreateElement(item, group, parent, elements, index);
				if (index > -1)
				{
					index++;
				}
			}
			group.UpdateChildVisbility();
			return index;
		}

		public IInspectorPanel CreatePanel(BuildInspectorPanelRequest request)
		{
			XmlElement xmlElement = CloneTemplate("template-panel", _panelContainer);
			InspectorPanelScript inspectorPanelScript = xmlElement.gameObject.AddComponent<InspectorPanelScript>();
			inspectorPanelScript.Initialize(request.Model, request.CreationInfo, this, xmlElement);
			return inspectorPanelScript;
		}

		private XmlElement CloneTemplate(string templateId, XmlElement parent)
		{
			return UiUtilities.CloneTemplate(_templates[templateId], parent);
		}

		private ItemElement CreateElement(ItemModel item, GroupModel group, XmlElement parent, List<ItemElement> elements, int index, bool includeInHeightCalculation = true)
		{
			ItemElement itemElement = null;
			if (item is TextModel)
			{
				itemElement = new TextElement(CloneTemplate("template-text-element", parent), item as TextModel, group);
			}
			else if (item is TextButtonModel)
			{
				itemElement = new TextButtonElement(CloneTemplate("template-text-button-element", parent), item as TextButtonModel, group);
			}
			else if (item is IconButtonModel)
			{
				itemElement = new IconButtonElement(CloneTemplate("template-icon-button-element", parent), item as IconButtonModel, group);
			}
			else if (item is LabelButtonModel)
			{
				itemElement = new LabelButtonElement(CloneTemplate("template-label-button-element", parent), item as LabelButtonModel, group);
			}
			else if (item is ToggleModel)
			{
				itemElement = new ToggleElement(CloneTemplate("template-toggle-element", parent), item as ToggleModel, group);
			}
			else if (item is DropdownModel)
			{
				itemElement = new DropdownElement(CloneTemplate("template-dropdown-element", parent), item as DropdownModel, group);
			}
			else if (item is HeaderModel)
			{
				itemElement = new HeaderElement(CloneTemplate("template-header-element", parent), item as HeaderModel, group);
			}
			else if (item is SliderModel)
			{
				XmlElement xmlElement = CloneTemplate("template-slider-element", parent);
				SliderModel sliderModel = item as SliderModel;
				itemElement = new SliderElement(xmlElement, sliderModel, group, sliderModel.MinValue, sliderModel.MaxValue, sliderModel.WholeNumbers);
			}
			else if (item is SpinnerModel)
			{
				itemElement = new SpinnerElement(CloneTemplate("template-spinner-element", parent), item as SpinnerModel, group);
			}
			else if (item is ProgressBarModel)
			{
				itemElement = new ProgressBarElement(CloneTemplate("template-progress-bar-element", parent), item as ProgressBarModel, group);
			}
			else if (item is IconButtonRowModel)
			{
				IconButtonRowModel iconButtonRowModel = item as IconButtonRowModel;
				IconButtonRowElement iconButtonRowElement = new IconButtonRowElement(CloneTemplate(string.IsNullOrEmpty(iconButtonRowModel.Label) ? "template-icon-button-row" : "template-icon-button-row-with-label", parent), iconButtonRowModel, group);
				foreach (IconButtonModel button in iconButtonRowModel.Buttons)
				{
					CreateElement(button, group, iconButtonRowElement.Container, elements, -1, includeInHeightCalculation: false);
				}
				itemElement = iconButtonRowElement;
			}
			else if (item is LogModel)
			{
				itemElement = new LogElement(CloneTemplate("template-log-element", parent), item as LogModel, group);
			}
			else if (item is TextInputModel)
			{
				itemElement = new TextInputElement(CloneTemplate("template-text-input", parent), item as TextInputModel, group);
			}
			else if (item is NumericInputModel)
			{
				itemElement = new NumericInputElement(CloneTemplate("template-numeric-input", parent), item as NumericInputModel, group);
			}
			else if (item is FloatInputModel)
			{
				itemElement = new FloatInputElement(CloneTemplate("template-numeric-input", parent), item as FloatInputModel, group);
			}
			else if (item is Vector3InputModel)
			{
				itemElement = new VectorInputElement<Vector3>(CloneTemplate("template-vector-input", parent), item as Vector3InputModel, group);
			}
			else if (item is Vector3dInputModel)
			{
				itemElement = new VectorInputElement<Vector3d>(CloneTemplate("template-vector-input", parent), item as Vector3dInputModel, group);
			}
			else if (item is Vector2InputModel)
			{
				itemElement = new VectorInputElement<Vector2>(CloneTemplate("template-vector2-input", parent), item as Vector2InputModel, group);
			}
			else if (item is Vector2dInputModel)
			{
				itemElement = new VectorInputElement<Vector2d>(CloneTemplate("template-vector2-input", parent), item as Vector2dInputModel, group);
			}
			else if (item is Vector2IntInputModel)
			{
				itemElement = new VectorInputElement<Vector2i>(CloneTemplate("template-vector2-input", parent), item as Vector2IntInputModel, group);
			}
			else if (item is MinMaxValueInputModel)
			{
				itemElement = new VectorInputElement<MinMaxValue>(CloneTemplate("template-vector2-input", parent), item as MinMaxValueInputModel, group);
			}
			else if (item is ColorModel)
			{
				itemElement = new ColorElement(CloneTemplate("template-color", parent), item as ColorModel, group);
			}
			else if (item is CurveModel)
			{
				itemElement = new CurveElement(CloneTemplate("template-curve", parent), item as CurveModel, group);
			}
			else if (item is TextureModel)
			{
				itemElement = new TextureElement(CloneTemplate("template-texture", parent), item as TextureModel, group);
			}
			else if (item is LabelModel)
			{
				itemElement = new LabelElement(CloneTemplate("template-label-element", parent), item as LabelModel, group);
			}
			else if (item is SpacerModel)
			{
				itemElement = new SpacerElement(CloneTemplate("template-spacer-element", parent), item as SpacerModel, group);
			}
			else if (item is TableRowModel)
			{
				XmlElement xmlElement2 = CloneTemplate("template-table-row", parent);
				TableRowModel tableRowModel = item as TableRowModel;
				TableRowElement tableRowElement = new TableRowElement(xmlElement2, tableRowModel, group);
				List<ItemElement> list = new List<ItemElement>();
				foreach (ItemModel item2 in tableRowModel.Items)
				{
					CreateElement(item2, group, tableRowElement.Container, list, -1, includeInHeightCalculation: false);
				}
				tableRowElement.XmlElement.AddClass("table-row");
				elements.AddRange(list);
				itemElement = tableRowElement;
			}
			else if (item is GradientModel)
			{
				itemElement = new GradientElement(CloneTemplate("template-gradient", parent), item as GradientModel, group);
			}
			else if (item is DeltaVAdjustorModel)
			{
				itemElement = new DeltaVAdjustorElement(CloneTemplate("template-deltav-adjustor", parent), item as DeltaVAdjustorModel, group);
			}
			if (itemElement == null)
			{
				Debug.LogError("Could not find template for item model: " + item.GetType().ToString());
			}
			if (includeInHeightCalculation)
			{
				itemElement.Height = itemElement.XmlElement.GetAttribute("preferredHeight", "0").ToInt();
			}
			item.NotifyElementCreated(itemElement);
			elements.Add(itemElement);
			if (index > -1)
			{
				itemElement.GameObject.transform.SetSiblingIndex(index);
			}
			return itemElement;
		}
	}
}
