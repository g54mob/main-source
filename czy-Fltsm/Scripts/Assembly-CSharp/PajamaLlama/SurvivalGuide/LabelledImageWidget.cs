using System;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.JSON;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.SurvivalGuide
{
	internal class LabelledImageWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public Sprite Sprite { get; private set; }

			public Sprite BackgroundSprite { get; private set; }

			public Color BackgroundColor { get; private set; } = Color.white;

			public Vector2 Dimensions { get; private set; }

			public string Text { get; private set; }

			public string Link { get; private set; }

			public Parameters(Dictionary<string, object> parameters)
			{
				if (!JSONExtensions.TryReturnParameter<string>(parameters, "image", out var parameter))
				{
					Debug.LogException(new NotImplementedException("Labelled Image Widget must have Sprite."));
					return;
				}
				Sprite = Resources.Load<Sprite>(parameter);
				if (!JSONExtensions.TryReturnParameter<string>(parameters, "text", out var parameter2))
				{
					Debug.LogException(new NotImplementedException("Labelled Image must have valid text."));
					return;
				}
				Text = new LocalizedString(parameter2);
				if (!JSONExtensions.TryReturnParameter<long>(parameters, "width", out var parameter3) || !JSONExtensions.TryReturnParameter<long>(parameters, "height", out var parameter4))
				{
					Debug.LogException(new NotImplementedException("Labelled Image Widget must have valid dimensions."));
					return;
				}
				Dimensions = new Vector2(parameter3, parameter4);
				if (JSONExtensions.TryReturnParameter<string>(parameters, "background", out var parameter5))
				{
					BackgroundSprite = Resources.Load<Sprite>(parameter5);
				}
				if (JSONExtensions.TryReturnParameter<string>(parameters, "background-color", out var parameter6) && ColorUtility.TryParseHtmlString(parameter6, out var color))
				{
					BackgroundColor = color;
				}
				if (JSONExtensions.TryReturnParameter<string>(parameters, "link", out var parameter7))
				{
					Link = parameter7;
				}
			}

			public Parameters(string text, Sprite sprite, Vector2 dimensions, string link = "", Sprite backgroundSprite = null, Color backgroundColor = default(Color))
			{
				Text = text;
				Sprite = sprite;
				BackgroundSprite = backgroundSprite;
				BackgroundColor = ((backgroundColor != default(Color)) ? backgroundColor : Color.white);
				Dimensions = dimensions;
				Link = link;
			}
		}

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private Image _imageBackground;

		[SerializeField]
		private LayoutElement _imageLayoutElement;

		internal override void Initialize(BaseParameters parameters)
		{
			if (!(parameters is Parameters parameters2))
			{
				Debug.LogException(new NotImplementedException());
				return;
			}
			_image.sprite = parameters2.Sprite;
			_imageLayoutElement.minWidth = parameters2.Dimensions.x;
			_imageLayoutElement.minHeight = parameters2.Dimensions.y;
			_imageLayoutElement.preferredWidth = parameters2.Dimensions.x;
			_imageLayoutElement.preferredHeight = parameters2.Dimensions.y;
			_text.text = parameters2.Text;
			if (_imageBackground != null)
			{
				if (parameters2.BackgroundSprite != null)
				{
					_imageBackground.sprite = parameters2.BackgroundSprite;
					_imageBackground.color = parameters2.BackgroundColor;
					_imageBackground.enabled = true;
				}
				else
				{
					_imageBackground.enabled = false;
				}
			}
			if (!parameters2.Link.IsNullOrEmpty())
			{
				_image.gameObject.AddComponent<LinkableSurvivalGuideWidget>().Initialize(parameters2.Link, 1.1f);
				_text.gameObject.AddComponent<LinkableSurvivalGuideWidget>().Initialize(parameters2.Link, 1.05f);
			}
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(parameters);
		}
	}
}
