using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class ApplicationManager : Singleton<ApplicationManager>
	{
		public const int EXECUTION_ORDER_DEFAULT = 0;

		public const int EXECUTION_ORDER_DEFAULT_LATER = 1;

		public const int EXECUTION_ORDER_DEFAULT_EARLIER = -1;

		public const int EXECUTION_ORDER_FIRST = -50;

		public const int EXECUTION_ORDER_FIRST_LATER = -49;

		public const int EXECUTION_ORDER_FIRST_EARLIER = -51;

		public const int EXECUTION_ORDER_LAST = 50;

		public const int EXECUTION_ORDER_LAST_LATER = 51;

		public const int EXECUTION_ORDER_LAST_EARLIER = 49;

		public static bool IsExiting { get; private set; }

		public static event Action EventExit;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void OnSubsystemsInit()
		{
			IsExiting = false;
			Singleton<ApplicationManager>.Instance.WakeUp();
		}

		private void OnApplicationQuit()
		{
			IsExiting = true;
			ApplicationManager.EventExit?.Invoke();
		}
	}
}
