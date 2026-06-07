using System.Reflection;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Dialogs;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class TextureProperty : ConfigurableProperty
	{
		private ITexturePropertyHandler _handler;

		private TexturePickerScript _picker;

		private RawImageWidget _texturePreview;

		public ButtonWidget Button { get; private set; }

		public TextWidget Label { get; private set; }

		public TextureProperty(MemberInfo member, DesignerPropertyAttribute attribute)
			: base(member, attribute)
		{
		}

		public override void CreateUI(Widget parent)
		{
			DesignerPropertyTextureAttribute designerPropertyTextureAttribute = base.Attribute as DesignerPropertyTextureAttribute;
			base.RootWidget = CreateWidgetFromTemplate("property-texture", parent);
			base.RootWidget.name = GetDefaultLabel();
			Label = base.RootWidget.FindWidget<TextWidget>("label-text");
			Label.Text = designerPropertyTextureAttribute.Label;
			Button = base.RootWidget.FindWidget<ButtonWidget>("button");
			Button.Clicked += OnButtonClicked;
			_texturePreview = base.RootWidget.FindWidget<RawImageWidget>("texture-preview");
		}

		public override void OnPropertiesClosed()
		{
			base.OnPropertiesClosed();
			CloseTexturePicker();
		}

		public void OpenTexturePicker()
		{
			string initiallySelectedId = GetValue() as string;
			DestroyPicker();
			_picker = Game.Instance.UserInterface.CreateTexturePickerFlyout(_handler.CreateItemsForTexturePicker(this), initiallySelectedId);
			_picker.Flyout.Show(show: true);
			_picker.TextureSelected += OnTextureSelected;
			_picker.Flyout.Closed += OnTexturePickerClosed;
		}

		public override void RefreshUI()
		{
			CloseTexturePicker();
			if (base.CurrentPartModifier != null)
			{
				_handler = base.CurrentPartModifier as ITexturePropertyHandler;
				if (_handler == null)
				{
					Debug.LogError(base.CurrentPartModifier?.GetType().Name + " must implement ITexturePropertyHandler");
				}
				else
				{
					RefreshPreviewTexture();
				}
			}
		}

		public override void SetCurrentPartModifier(PartModifierData partModifier, object fieldTarget)
		{
			base.SetCurrentPartModifier(partModifier, fieldTarget);
			CloseTexturePicker();
		}

		private void CloseTexturePicker()
		{
			_picker?.Flyout.Close();
		}

		private void DestroyPicker()
		{
			if (_picker != null)
			{
				_picker.TextureSelected -= OnTextureSelected;
				_picker.Flyout.Closed -= OnTexturePickerClosed;
				_picker.Flyout.Widget.Destroy();
				_picker = null;
			}
		}

		private void OnButtonClicked(Widget widget)
		{
			OpenTexturePicker();
		}

		private void OnTexturePickerClosed(IFlyout flyout)
		{
			DestroyPicker();
		}

		private void OnTextureSelected(object sender, TexturePickerScript.TextureSelectedEventArgs e)
		{
			foreach (var symmetricModifier in GetSymmetricModifiers(includeCurrentModifier: true))
			{
				if (!(symmetricModifier.PartModifier is ITexturePropertyHandler texturePropertyHandler))
				{
					Debug.LogError(symmetricModifier.PartModifier?.GetType().Name + " must implement ITexturePropertyHandler");
				}
				else
				{
					texturePropertyHandler.OnTextureSelected(e.TextureItem);
				}
			}
			RefreshPreviewTexture();
		}

		private void RefreshPreviewTexture()
		{
			_texturePreview.Texture = _handler.GetPreviewTexture(this);
			Button.Tooltip = _texturePreview.Texture?.name;
			_texturePreview.ToggleClass("hack-refresh");
		}
	}
}
