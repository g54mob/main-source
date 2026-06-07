using Assets.Scripts.Craft;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.Paint
{
	public class ColorButtonScript : WidgetScript
	{
		private PaintPanelScript _paintPanelScript;

		private bool _selected;

		private TexturePreviewScript _texturePreview;

		public int MaterialId { get; set; }

		public PartMaterial PartMaterial { get; private set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				if (value)
				{
					base.Widget.AddClass("color-button-selected");
				}
				else
				{
					base.Widget.RemoveClass("color-button-selected");
				}
			}
		}

		public void InitializeMaterial(PartMaterial partMaterial, PaintPanelScript paintPanelScript)
		{
			PartMaterial = partMaterial;
			_paintPanelScript = paintPanelScript;
			_texturePreview = base.gameObject.AddComponent<TexturePreviewScript>();
			_texturePreview.InitializeMaterial(partMaterial);
		}

		public void UpdateMaterial()
		{
			_texturePreview.InitializeMaterial(PartMaterial);
			_texturePreview.UpdateMaterial();
		}

		private void OnClicked(Widget widget)
		{
			_paintPanelScript.ColorButtonClicked(this);
		}
	}
}
