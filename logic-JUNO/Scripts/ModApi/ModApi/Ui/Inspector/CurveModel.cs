using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class CurveModel : ValueModel<AnimationCurve>
	{
		public string Label { get; set; }

		public CurveModel(string label, Func<AnimationCurve> valueGetter, Action<AnimationCurve> valueSetter = null)
			: base(valueGetter, valueSetter)
		{
			Label = label;
		}
	}
}
