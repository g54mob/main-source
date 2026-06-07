using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using GUPS.EasyPerformanceMonitor.Provider;
using UnityEngine;
using UnityEngine.UI;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public class NormalizedTextRenderer : ATextRenderer<PerformanceData>
	{
		[SerializeField]
		private string pattern = "0.0#";

		private string renderPattern = "{0:0.0}{1}";

		private float[] meanValues;

		[SerializeField]
		private List<Text> uiMeanTexts = new List<Text>();

		[SerializeField]
		private List<Text> uiPercentTexts = new List<Text>();

		public string Pattern => pattern;

		protected override void Awake()
		{
			base.Awake();
			meanValues = new float[base.Provider.Count];
			RefreshRenderPattern();
		}

		public override void OnNext(PerformanceData _Next)
		{
			PerformanceData performanceData = _Next;
			IPerformanceProvider performanceProvider = (IPerformanceProvider)_Next.Sender;
			int num = base.Provider.IndexOf(performanceProvider);
			if (num >= 0)
			{
				meanValues[num] = ScaleValue(performanceData.MeanValue, performanceProvider, out var _Suffix);
				if (uiMeanTexts.Count > num && uiMeanTexts[num] != null)
				{
					uiMeanTexts[num].text = string.Format(renderPattern, meanValues[num], _Suffix);
				}
				float num2 = 0f;
				for (int i = 0; i < meanValues.Length; i++)
				{
					num2 += meanValues[i];
				}
				float num3 = meanValues[num] / num2;
				if (uiPercentTexts.Count > num && uiPercentTexts[num] != null)
				{
					uiPercentTexts[num].text = $"{num3 * 100f:0.0}%";
				}
			}
		}

		private float ScaleValue(float _Value, IPerformanceProvider _Provider, out string _Suffix)
		{
			if (base.Scale && _Provider.IsScaleAble)
			{
				int i;
				for (i = 0; i < _Provider.ScaleSuffixes.Length - 1 && _Value > Mathf.Pow(_Provider.ScaleFactor, i + 1); i++)
				{
				}
				_Suffix = _Provider.ScaleSuffixes[i];
				return _Value / Mathf.Pow(_Provider.ScaleFactor, i);
			}
			_Suffix = _Provider.Unit;
			return _Value;
		}

		public override void RefreshText()
		{
			base.RefreshText();
			RefreshRenderPattern();
		}

		private void RefreshRenderPattern()
		{
			renderPattern = Pattern;
			string text = "(\\d\\.\\d+)|\\d+";
			Match match = Regex.Match(renderPattern, text);
			if (match.Success)
			{
				renderPattern = renderPattern.Replace(match.Value, "{0:" + match.Value + "}");
			}
			renderPattern = renderPattern.Replace("#", "{1}");
		}
	}
}
