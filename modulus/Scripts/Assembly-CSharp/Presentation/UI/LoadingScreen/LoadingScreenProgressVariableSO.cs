using Data.Variables;
using UnityEngine;

namespace Presentation.UI.LoadingScreen
{
	[CreateAssetMenu(fileName = "LoadingScreenProgressVariableSO", menuName = "Variables/LoadingScreenProgressVariable")]
	public class LoadingScreenProgressVariableSO : VariableSO<LoadingScreenProgressVariableSO.Values>
	{
		public struct Values
		{
			public bool Hide;

			public float Progress01;

			public Values(bool hide, float currProgress01)
			{
				Hide = hide;
				Progress01 = currProgress01;
			}
		}

		public void SetValue(LoadingProgressEnum percent)
		{
			Values value = Value;
			value.Progress01 = (float)percent * 0.01f;
			SetValue(value);
		}

		public void SetValueLerp(LoadingProgressEnum fromPercent, LoadingProgressEnum toPercent, float lerp01)
		{
			Values value = Value;
			value.Progress01 = Mathf.Lerp((float)fromPercent, (float)toPercent, lerp01) * 0.01f;
			SetValue(value);
		}

		public void SetHiddenAndReset(bool hide)
		{
			Values value = new Values
			{
				Hide = hide
			};
			SetValue(value);
		}
	}
}
