using CTS.Core;
using UnityEngine;

namespace CTS.ScriptableSettings
{
	public abstract class DLCSetting<T> : PlayerPrefSetting<T>
	{
		[SerializeField]
		private T _valueWhenNoDLC;

		[SerializeField]
		private StringKey _dlc;

		public override T GetValue()
		{
			if (!CTSSingleton<GamePlatform>.InstanceExists())
			{
				return _valueWhenNoDLC;
			}
			if (!CTSSingleton<GamePlatform>.Instance.Library.IsDLCInstalled(_dlc))
			{
				return _valueWhenNoDLC;
			}
			return base.GetValue();
		}
	}
}
