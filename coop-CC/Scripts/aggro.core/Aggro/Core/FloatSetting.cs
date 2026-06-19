using System;
using FMODUnity;
using Unity.Mathematics;
using UnityEngine;

namespace Aggro.Core
{
	public sealed class FloatSetting : AggroSettingBase
	{
		public enum Style
		{
			Number = 0,
			Percentage = 1,
			NoInputField = 2,
			Integer = 3
		}

		private float _default;

		private Action<float> _onSaved;

		public Style style { get; private set; }

		public float min { get; private set; }

		public float max { get; private set; }

		public float value { get; private set; }

		public EventReference changeSfx { get; private set; }

		public EventReference zeroSfx { get; private set; }

		public FloatSetting(Style style, float min, float max, float defaultValue, EventReference changeSfx = default(EventReference), EventReference zeroSfx = default(EventReference))
		{
			this.style = style;
			this.min = min;
			this.max = max;
			_default = defaultValue;
			this.changeSfx = changeSfx;
			this.zeroSfx = zeroSfx;
		}

		public FloatSetting(Style style, float min, float max, float defaultValue, Action<float> onSaved, EventReference changeSfx = default(EventReference), EventReference zeroSfx = default(EventReference), bool userEditable = true)
		{
			this.style = style;
			this.min = min;
			this.max = max;
			_default = defaultValue;
			_onSaved = onSaved;
			this.changeSfx = changeSfx;
			this.zeroSfx = zeroSfx;
			base.userEditable = userEditable;
		}

		public override void SetToDefault()
		{
			value = _default;
		}

		protected override void SaveToPrefs(string preferencesKey)
		{
			PlayerPrefs.SetFloat(preferencesKey, value);
			if (_onSaved != null)
			{
				_onSaved(value);
			}
		}

		protected override void LoadFromPrefs(string preferencesKey)
		{
			value = PlayerPrefs.GetFloat(preferencesKey, _default);
		}

		public void SetValue(float value)
		{
			this.value = math.clamp(value, min, max);
		}
	}
}
