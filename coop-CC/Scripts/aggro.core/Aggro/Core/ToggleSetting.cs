using System;
using UnityEngine;

namespace Aggro.Core
{
	public sealed class ToggleSetting : AggroSettingBase
	{
		private bool _default;

		private Action<bool> _onSaved;

		public bool value { get; private set; }

		public ToggleSetting(bool defaultValue)
		{
			_default = defaultValue;
		}

		public ToggleSetting(bool defaultValue, Action<bool> onSaved = null, bool userEditable = true)
		{
			_default = defaultValue;
			_onSaved = onSaved;
			base.userEditable = userEditable;
		}

		public override void SetToDefault()
		{
			value = _default;
		}

		protected override void SaveToPrefs(string preferencesKey)
		{
			PlayerPrefs.SetInt(preferencesKey, value ? 1 : 0);
			if (_onSaved != null)
			{
				_onSaved(value);
			}
		}

		protected override void LoadFromPrefs(string preferencesKey)
		{
			value = PlayerPrefs.GetInt(preferencesKey, _default ? 1 : 0) > 0;
		}

		public void SetValue(bool value)
		{
			this.value = value;
		}
	}
}
