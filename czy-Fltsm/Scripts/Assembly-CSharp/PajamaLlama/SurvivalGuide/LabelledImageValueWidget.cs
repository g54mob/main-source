using System;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.JSON;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.SurvivalGuide
{
	internal class LabelledImageValueWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public Sprite Sprite { get; private set; }

			public Sprite BackgroundSprite { get; private set; }

			public Color BackgroundColor { get; private set; } = Color.white;

			public float Height { get; private set; }

			public string Label { get; private set; }

			public string Value { get; private set; }

			public string Link { get; private set; }

			public Parameters(Dictionary<string, object> parameters)
			{
				if (!JSONExtensions.TryReturnParameter<string>(parameters, "image", out var parameter))
				{
					Debug.LogException(new NotImplementedException("LabelledImageValueWidget must have Sprite."));
					return;
				}
				Sprite = Resources.Load<Sprite>(parameter);
				if (!JSONExtensions.TryReturnParameter<string>(parameters, "label", out var parameter2))
				{
					Debug.LogException(new NotImplementedException("LabelledImageValueWidget must have valid label."));
					return;
				}
				Label = new LocalizedString(parameter2);
				if (!JSONExtensions.TryReturnParameter<string>(parameters, "value", out var parameter3))
				{
					Debug.LogException(new NotImplementedException("LabelledImageValueWidget must have valid value."));
					return;
				}
				Value = parameter3;
				if (!JSONExtensions.TryReturnParameter<long>(parameters, "height", out var parameter4))
				{
					Debug.LogException(new NotImplementedException("LabelledImageValueWidget must have valid height."));
					return;
				}
				Height = parameter4;
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

			public Parameters(string label, string value, Sprite sprite, float height, string link = "", Sprite backgroundSprite = null, Color backgroundColor = default(Color))
			{
				Label = label;
				Value = value;
				Sprite = sprite;
				BackgroundSprite = backgroundSprite;
				BackgroundColor = ((backgroundColor != default(Color)) ? backgroundColor : Color.white);
				Height = height;
				Link = link;
			}
		}

		[SerializeField]
		private Image _image;

		[SerializeField]
		private Image _imageBackground;

		[SerializeField]
		private TextMeshProUGUI _label;

		[SerializeField]
		private TextMeshProUGUI _value;

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
			_imageLayoutElement.minWidth = parameters2.Height;
			_imageLayoutElement.minHeight = parameters2.Height;
			_imageLayoutElement.preferredWidth = parameters2.Height;
			_imageLayoutElement.preferredHeight = parameters2.Height;
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
			if (base.transform is RectTransform rectTransform)
			{
				rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, parameters2.Height);
			}
			_label.text = parameters2.Label;
			_value.text = parameters2.Value;
			if (!parameters2.Link.IsNullOrEmpty())
			{
				_image.gameObject.AddComponent<LinkableSurvivalGuideWidget>().Initialize(parameters2.Link, 1.1f);
				_label.gameObject.AddComponent<LinkableSurvivalGuideWidget>().Initialize(parameters2.Link, 1.05f);
				_value.gameObject.AddComponent<LinkableSurvivalGuideWidget>().Initialize(parameters2.Link, 1.05f);
			}
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(parameters);
		}
	}
}
