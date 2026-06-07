using UnityEngine;
using Zenject;

namespace VampireSurvivors
{
	public class OnlineErrorManager : MonoBehaviour
	{
		private static OnlineErrorManager Instance;

		[Inject]
		private SignalBus _signalBus;

		private LobbiesManager _lobbiesManager;

		public static string OnlineErrorPopupID;

		[Inject]
		private void Construct(LobbiesManager lobbiesManager)
		{
		}

		private void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public static void CloseErrorPopupIfExists()
		{
		}

		public static void ShowError(OnlineErrorType type, string msg)
		{
		}

		public static string TypeToString(OnlineErrorType type)
		{
			return null;
		}
	}
}
