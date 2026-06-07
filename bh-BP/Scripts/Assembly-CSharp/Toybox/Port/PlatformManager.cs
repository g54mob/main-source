using UnityEngine;

namespace Toybox.Port
{
	public class PlatformManager : MonoBehaviour
	{
		private IPlatformManager _platformManager;

		private bool _isInitialized;

		public static PlatformManager Instance { get; private set; }

		public bool IsConstrained => false;

		public bool IsInitialized => false;

		public IPlatformManager PlatformInterface => null;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RunTimeInitialization()
		{
		}

		private void Awake()
		{
		}

		private void Init()
		{
		}

		private void Update()
		{
		}
	}
}
