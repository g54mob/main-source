using System;
using System.Collections.Generic;
using PajamaLlama.JSON;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.SurvivalGuide
{
	internal class ImageWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public Sprite Sprite { get; private set; }

			public Vector2 Dimensions { get; private set; }

			public string Link { get; private set; }

			public Parameters(Dictionary<string, object> parameters)
			{
				if (!JSONExtensions.TryReturnParameter<string>(parameters, "image", out var parameter))
				{
					throw new NotImplementedException("Image Widget must have Sprite.");
				}
				Sprite = Resources.Load<Sprite>(parameter);
				if (!JSONExtensions.TryReturnParameter<long>(parameters, "width", out var parameter2) || !JSONExtensions.TryReturnParameter<long>(parameters, "height", out var parameter3))
				{
					throw new NotImplementedException("Image Widget must have valid dimensions.");
				}
				Dimensions = new Vector2(parameter2, parameter3);
				if (JSONExtensions.TryReturnParameter<string>(parameters, "link", out var parameter4))
				{
					Link = parameter4;
				}
			}

			public Parameters(Sprite sprite, Vector2 dimensions, string link = "")
			{
				Sprite = sprite;
				Dimensions = dimensions;
				Link = link;
			}
		}

		[SerializeField]
		private Image _image;

		internal override void Initialize(BaseParameters parameters)
		{
			if (!(parameters is Parameters parameters2))
			{
				Debug.LogError(new NotImplementedException());
				return;
			}
			_image.sprite = parameters2.Sprite;
			_image.rectTransform.sizeDelta = parameters2.Dimensions;
			if (!parameters2.Link.IsNullOrEmpty())
			{
				_image.gameObject.AddComponent<LinkableSurvivalGuideWidget>().Initialize(parameters2.Link, 1.1f);
			}
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(parameters);
		}
	}
}
