using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class TownWeightTiersWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public Parameters(Dictionary<string, object> parameters)
			{
			}
		}

		[SerializeField]
		private Engine _engine;

		[SerializeField]
		private TextMeshProUGUI _text;

		internal override void Initialize(BaseParameters parameters)
		{
			string text = "";
			int num = _engine.WeightTiers.Length;
			for (int i = 0; i < num; i++)
			{
				WeightTier weightTier = _engine.WeightTiers[i];
				text = ((i != num - 1) ? string.Concat(text, "\t- ", weightTier.Name, "\n") : (text + "\t- " + weightTier.Name));
			}
			_text.text = text;
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(parameters);
		}
	}
}
