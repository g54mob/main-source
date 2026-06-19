using System;
using UnityEngine;

namespace Aggro.Core
{
	public sealed class DropdownSetting : AggroSettingBase
	{
		private int _defaultIndex;

		private Action<int> _onSaved;

		public string[] options { get; private set; }

		public int index { get; private set; }

		public DropdownSetting(int defaultIndex, string[] options)
			: this(defaultIndex, options, null)
		{
		}

		public DropdownSetting(int defaultIndex, string[] options, Action<int> onSaved)
		{
			_defaultIndex = defaultIndex;
			this.options = new string[options.Length];
			Array.Copy(options, this.options, options.Length);
			_onSaved = onSaved;
		}

		public override void SetToDefault()
		{
			index = _defaultIndex;
		}

		public void SetIndex(int index)
		{
			this.index = index;
		}

		protected override void SaveToPrefs(string preferencesKey)
		{
			PlayerPrefs.SetInt(preferencesKey, index);
			if (_onSaved != null)
			{
				_onSaved(index);
			}
		}

		protected override void LoadFromPrefs(string preferencesKey)
		{
			index = PlayerPrefs.GetInt(preferencesKey, _defaultIndex);
		}
	}
}
