using UnityEngine;

namespace Alekrus.UnivarsalPlatform
{
	public class MainProvider
	{
		protected static ProviderCreateMainEventHandler _customHandler;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnSubsystemRegistration()
		{
			_customHandler = null;
		}

		public static void SetCreateEventHandler(ProviderCreateMainEventHandler parCreateEventHandler)
		{
			_customHandler = parCreateEventHandler;
		}

		public static IMain Create()
		{
			return _customHandler?.Invoke();
		}
	}
}
