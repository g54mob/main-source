using System;
using CTS.Core;
using CTS.ScriptableSettings;
using UnityEngine;

namespace CTS
{
	public class AgentNeedVisualsDisplay : CTSSingleton<AgentNeedVisualsDisplay>
	{
		[SerializeField]
		private SettingObject<bool> _showFun;

		[SerializeField]
		private SettingObject<bool> _showHunger;

		[SerializeField]
		private SettingObject<bool> _showToilet;

		public bool ShowFun => _showFun.GetValue();

		public bool ShowHunger => _showHunger.GetValue();

		public bool ShowToilet => _showToilet.GetValue();

		public static event Action DisplayChanged;

		protected override void SingletonAwake()
		{
			_showFun.ValueChanged += OnSettingChanged;
			_showHunger.ValueChanged += OnSettingChanged;
			_showToilet.ValueChanged += OnSettingChanged;
		}

		protected override void OnSingletonDestroy()
		{
			_showFun.ValueChanged -= OnSettingChanged;
			_showHunger.ValueChanged -= OnSettingChanged;
			_showToilet.ValueChanged -= OnSettingChanged;
		}

		private void OnSettingChanged(bool value)
		{
			AgentNeedVisualsDisplay.DisplayChanged?.Invoke();
		}
	}
}
