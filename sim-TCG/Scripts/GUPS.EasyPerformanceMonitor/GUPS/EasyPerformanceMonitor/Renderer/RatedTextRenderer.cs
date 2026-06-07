using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using GUPS.EasyPerformanceMonitor.Provider;
using UnityEngine;
using UnityEngine.UI;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public class RatedTextRenderer : ATextRenderer<PerformanceData>
	{
		[SerializeField]
		private string pattern = "0.0#";

		private string renderPattern = "{0:0.0}{1}";

		private float[] minValues;

		private float[] maxValues;

		private float[] meanValues;

		[SerializeField]
		private List<Text> uiMinTexts = new List<Text>();

		[SerializeField]
		private List<Text> uiMaxTexts = new List<Text>();

		[SerializeField]
		private List<Text> uiMeanTexts = new List<Text>();

		public string Pattern => pattern;

		protected override void Awake()
		{
			base.Awake();
			minValues = new float[base.Provider.Count];
			maxValues = new float[base.Provider.Count];
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
				minValues[num] = ScaleValue(performanceData.MinValue, performanceProvider, out var _Suffix);
				maxValues[num] = ScaleValue(performanceData.MaxValue, performanceProvider, out var _Suffix2);
				meanValues[num] = ScaleValue(performanceData.MeanValue, performanceProvider, out var _Suffix3);
				if (uiMinTexts.Count > num && uiMinTexts[num] != null)
				{
					uiMinTexts[num].text = string.Format(renderPattern, minValues[num], _Suffix);
				}
				if (uiMaxTexts.Count > num && uiMaxTexts[num] != null)
				{
					uiMaxTexts[num].text = string.Format(renderPattern, maxValues[num], _Suffix2);
				}
				if (uiMeanTexts.Count > num && uiMeanTexts[num] != null)
				{
					uiMeanTexts[num].text = string.Format(renderPattern, meanValues[num], _Suffix3);
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
