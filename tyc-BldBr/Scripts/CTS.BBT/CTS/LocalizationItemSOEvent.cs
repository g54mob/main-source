using System;
using CTS.Core;

namespace CTS
{
	public class LocalizationItemSOEvent : MonoSingleton<LocalizationItemSOEvent>
	{
		public static event Action InitProcessEnded;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public static void Go()
		{
			LocalizationItemSOEvent.InitProcessEnded?.Invoke();
		}
	}
}
