using System;
using UnityEngine.Events;

namespace SettingScripts
{
	public abstract class ChangingValueSetting<T> : ChangingSetting
	{
		[NonSerialized]
		public UnityEvent<T, T> OnValueChangeWithPrecedent = new UnityEvent<T, T>();

		[NonSerialized]
		public UnityEvent<T> OnValueChange = new UnityEvent<T>();
	}
}
