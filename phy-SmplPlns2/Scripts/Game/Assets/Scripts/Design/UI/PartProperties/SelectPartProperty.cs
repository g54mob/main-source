using System.Reflection;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class SelectPartProperty : ConfigurableProperty
	{
		private TextWidget _label;

		public ButtonWidget Button { get; private set; }

		public TextWidget ButtonLabel { get; private set; }

		public DesignerPropertyPartIdAttribute SelectPartAttribute => (DesignerPropertyPartIdAttribute)base.Attribute;

		public SelectPartProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			base.RootWidget = CreateWidgetFromTemplate("control-spinner-button", parent);
			Button = base.RootWidget.FindWidget<ButtonWidget>("next-button");
			ButtonLabel = base.RootWidget.FindWidget<TextWidget>("value-text");
			_label = base.RootWidget.FindWidget<TextWidget>("label-text");
			_label.name = GetDefaultLabel();
			_label.SetStyle("text", GetDefaultLabel());
			Button.Clicked += OnButtonClicked;
			Button.PointerEnter += OnButtonPointerEnter;
			Button.PointerExit += OnButtonPointerExit;
		}

		public override void RefreshUI()
		{
			base.RefreshUI();
			UpdateButtonLabel();
		}

		private int GetSelectedPartId()
		{
			object value = GetValue();
			if (value != null)
			{
				return (int)value;
			}
			return 0;
		}

		private void OnButtonClicked(Widget widget)
		{
			ISelectPartPropertyModifier modifier = base.CurrentPartModifier as ISelectPartPropertyModifier;
			if (widget.PointerEventData.pointerId == -2)
			{
				OnChoosePartToolClosed(modifier, null);
				return;
			}
			if (SelectPartAttribute.StartMessage != null)
			{
				Designer.Instance.ShowMessage(SelectPartAttribute.StartMessage);
			}
			Designer.Instance.Tools.SelectChoosePartTool((PartData x) => (SelectPartAttribute.RequiredPartTypeId != null) ? (x.PartType.PartTypeId == SelectPartAttribute.RequiredPartTypeId) : (modifier?.OnPartSelectionToolFilterPart(base.Member.Name, x) ?? true), SelectPartAttribute.MustBeConnected, GetSelectedPartId(), SelectPartAttribute.NoOptionsMessage, delegate(PartData p)
			{
				OnChoosePartToolClosed(modifier, p);
			});
		}

		private void OnButtonPointerEnter(Widget widget)
		{
			PartData partById = Designer.Instance.Aircraft.GetPartById(GetSelectedPartId());
			Designer.Instance.HighlightedPart = partById?.PartScript;
		}

		private void OnButtonPointerExit(Widget widget)
		{
			Designer.Instance.HighlightedPart = null;
		}

		private void OnChoosePartToolClosed(ISelectPartPropertyModifier modifier, PartData part)
		{
			SetValue(part?.Id ?? 0, convertType: true);
			modifier?.OnPartSelectionToolClosed(base.Member.Name, part);
			UpdateButtonLabel();
			RaiseValueCommitted();
		}

		private void UpdateButtonLabel()
		{
			PartData partById = Designer.Instance.Aircraft.GetPartById(GetSelectedPartId());
			if (partById != null)
			{
				ButtonLabel.Text = $"{partById.PartType.Name} ({partById.Id})";
			}
			else
			{
				ButtonLabel.Text = "None";
			}
		}
	}
}
