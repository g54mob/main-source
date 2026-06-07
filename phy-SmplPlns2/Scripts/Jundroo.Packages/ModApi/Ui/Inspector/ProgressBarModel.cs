using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class ProgressBarModel : ItemModel
	{
		private Func<string> _labelGetter;

		private float _value;

		private Func<float> _valueGetter;

		public string Label { get; set; }

		public float Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = Mathf.Clamp01(value);
			}
		}

		public ProgressBarModel(string label, Func<float> valueGetter = null)
		{
			_valueGetter = valueGetter;
			Label = label;
		}

		public ProgressBarModel(Func<string> labelGetter, Func<float> valueGetter = null)
		{
			_labelGetter = labelGetter;
			_valueGetter = valueGetter;
			Label = _labelGetter();
		}

		public override void Update()
		{
			base.Update();
			if (_valueGetter != null)
			{
				Value = _valueGetter();
			}
			if (_labelGetter != null)
			{
				Label = _labelGetter();
			}
		}
	}
}
