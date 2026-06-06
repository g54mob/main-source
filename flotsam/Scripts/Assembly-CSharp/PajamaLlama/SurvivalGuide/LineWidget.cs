using System;
using System.Collections.Generic;
using PajamaLlama.JSON;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class LineWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public float Height { get; private set; }

			public Parameters(Dictionary<string, object> parameters)
			{
				if (!JSONExtensions.TryReturnParameter<long>(parameters, "height", out var parameter))
				{
					throw new NotImplementedException("Line Widget must have a height.");
				}
				Height = parameter;
			}

			public Parameters(float height)
			{
				Height = height;
			}
		}

		[SerializeField]
		private RectTransform _lineTransform;

		internal override void Initialize(BaseParameters parameters)
		{
			if (parameters is Parameters parameters2)
			{
				_lineTransform.sizeDelta = new Vector2(_lineTransform.sizeDelta.x, parameters2.Height);
			}
			else
			{
				Debug.LogException(new NotImplementedException());
			}
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(parameters);
		}
	}
}
