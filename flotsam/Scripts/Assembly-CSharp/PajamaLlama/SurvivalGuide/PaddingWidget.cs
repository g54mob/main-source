using System;
using System.Collections.Generic;
using PajamaLlama.JSON;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.SurvivalGuide
{
	internal class PaddingWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public float Padding { get; private set; }

			public Parameters(Dictionary<string, object> parameters)
			{
				if (!JSONExtensions.TryReturnParameter<long>(parameters, "padding", out var parameter))
				{
					throw new NotImplementedException("Pading Widget must have padding.");
				}
				Padding = parameter;
			}

			public Parameters(float padding)
			{
				Padding = padding;
			}
		}

		[SerializeField]
		private LayoutElement _layoutElement;

		internal override void Initialize(BaseParameters parameters)
		{
			if (!(parameters is Parameters parameters2))
			{
				Debug.LogException(new NotImplementedException());
				return;
			}
			_layoutElement.minWidth = parameters2.Padding;
			_layoutElement.preferredWidth = parameters2.Padding;
			_layoutElement.minHeight = parameters2.Padding;
			_layoutElement.preferredHeight = parameters2.Padding;
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(parameters);
		}
	}
}
