using UnityEngine;

public class TextWrapper
{
	public class WidthProvider : TextWrap.IWidthProvider
	{
		public TextGenerator generator;

		private TextGenerationSettings settings_;

		public TextGenerationSettings settings
		{
			set
			{
				settings_.fontSize = value.fontSize;
				settings_.resizeTextMinSize = value.resizeTextMinSize;
				settings_.resizeTextMaxSize = value.resizeTextMaxSize;
				settings_.textAnchor = value.textAnchor;
				settings_.alignByGeometry = value.alignByGeometry;
				settings_.scaleFactor = value.scaleFactor;
				settings_.color = value.color;
				settings_.font = value.font;
				settings_.pivot = value.pivot;
				settings_.richText = value.richText;
				settings_.lineSpacing = value.lineSpacing;
				settings_.fontStyle = value.fontStyle;
				settings_.resizeTextForBestFit = value.resizeTextForBestFit;
				settings_.updateBounds = value.updateBounds;
				settings_.generateOutOfBounds = true;
				settings_.horizontalOverflow = HorizontalWrapMode.Overflow;
				settings_.verticalOverflow = VerticalWrapMode.Overflow;
			}
		}

		public WidthProvider()
		{
			settings_ = default(TextGenerationSettings);
			settings_.generationExtents = new Vector2(100000f, 100000f);
		}

		public float GetWidth(string text)
		{
			return generator.GetPreferredWidth(text, settings_);
		}
	}

	private WidthProvider widthProvider = new WidthProvider();

	public string Wrap(string str, TextGenerator generator, TextGenerationSettings settings, bool rtl)
	{
		widthProvider.generator = generator;
		widthProvider.settings = settings;
		return TextWrap.Wrap(str, settings.generationExtents.x, widthProvider, rtl);
	}
}
