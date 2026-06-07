using System;
using UnityEngine.Events;

namespace SettingScripts
{
	public abstract class ChangingSetting
	{
		[NonSerialized]
		public UnityEvent OnChange = new UnityEvent();
	}
}
