using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game
{
	public class Boot
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitOnLoad()
		{
		}

		private static void LocalizationSettingsOnSelectedLocaleChanged(Locale locale)
		{
		}

		private static void Handler(AsyncOperationHandle handle, Exception e)
		{
		}
	}
}
