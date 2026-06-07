using System.Threading;
using UnityEngine;

namespace DebugSystem
{
	public class MainThreadFreezeProbe : MonoBehaviour
	{
		[Tooltip("Freezes longer than this many milliseconds produce a log entry.")]
		[SerializeField]
		private int freezeThresholdMs;

		[Tooltip("How often the background thread samples (ms). Lower = more precise but more log noise.")]
		[SerializeField]
		private int sampleIntervalMs;

		private static MainThreadFreezeProbe s_instance;

		private CancellationTokenSource _cts;

		private long _lastMainThreadTickUtcMs;

		public static void Install()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void AutoInstall()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void StartBackgroundWatcher()
		{
		}
	}
}
