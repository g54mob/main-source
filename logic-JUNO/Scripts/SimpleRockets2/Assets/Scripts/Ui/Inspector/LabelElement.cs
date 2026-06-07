using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;

namespace Assets.Scripts.Ui.Inspector
{
	public class LabelElement : ItemElement
	{
		private ElementAlignment _alignment;

		private TextMeshProUGUI _labelText;

		private LabelModel _model;

		public TextMeshProUGUI LabelText => _labelText;

		public LabelElement(XmlElement xmlElement, LabelModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			_labelText.text = model.Label;
			_alignment = ElementAlignment.Left;
		}

		public static TextAlignmentOptions TextAlignmentToTextMeshProAlignment(ElementAlignment alignment)
		{
			return alignment switch
			{
				ElementAlignment.Left => TextAlignmentOptions.Left, 
				ElementAlignment.Center => TextAlignmentOptions.Center, 
				ElementAlignment.Right => TextAlignmentOptions.Right, 
				ElementAlignment.TopLeft => TextAlignmentOptions.TopLeft, 
				ElementAlignment.TopCenter => TextAlignmentOptions.Top, 
				ElementAlignment.TopRight => TextAlignmentOptions.TopRight, 
				ElementAlignment.BottomLeft => TextAlignmentOptions.BottomLeft, 
				ElementAlignment.BottomCenter => TextAlignmentOptions.Bottom, 
				ElementAlignment.BottomRight => TextAlignmentOptions.BottomRight, 
				_ => TextAlignmentOptions.Left, 
			};
		}

		public static ElementAlignment TextAlignmentToTextMeshProAlignment(TextAlignmentOptions alignment)
		{
			return alignment switch
			{
				TextAlignmentOptions.Left => ElementAlignment.Left, 
				TextAlignmentOptions.Center => ElementAlignment.Center, 
				TextAlignmentOptions.Right => ElementAlignment.Right, 
				TextAlignmentOptions.TopLeft => ElementAlignment.TopLeft, 
				TextAlignmentOptions.Top => ElementAlignment.TopCenter, 
				TextAlignmentOptions.TopRight => ElementAlignment.TopRight, 
				TextAlignmentOptions.BottomLeft => ElementAlignment.BottomLeft, 
				TextAlignmentOptions.Bottom => ElementAlignment.BottomCenter, 
				TextAlignmentOptions.BottomRight => ElementAlignment.BottomRight, 
				_ => ElementAlignment.Left, 
			};
		}

		public override void Update()
		{
			base.Update();
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
			if (_alignment != _model.Alignment)
			{
				_alignment = _model.Alignment;
				_labelText.alignment = TextAlignmentToTextMeshProAlignment(_alignment);
			}
		}
	}
}
