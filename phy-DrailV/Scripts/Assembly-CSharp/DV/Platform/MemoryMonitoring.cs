using Cysharp.Threading.Tasks;
using DV.Platform.Windows;
using UnityEngine;

namespace DV.Platform
{
	public class MemoryMonitoring : MonoBehaviour
	{
		public delegate void LowMemoryDelegate(long amountKiloBytesFree);

		public static LowMemoryDelegate LowMemoryThresholdReached;

		public int lowMemoryWarningThresholdMB = 1500;

		public float thresholdReductionMultiplier = 0.9f;

		public int delayBetweenChecksSeconds = 2;

		private long currentThresholdKB;

		private long lastTotalAvailKB;

		private bool continueChecking = true;

		private void Awake()
		{
			currentThresholdKB = lowMemoryWarningThresholdMB * 1024;
			(long freeKB, long totalKB) freeAndTotalMemoryKB = MemoryMonitoring_Native.GetFreeAndTotalMemoryKB();
			var (freeKB, _) = freeAndTotalMemoryKB;
			LogMemoryAmount(freeKB, lastTotalAvailKB = freeAndTotalMemoryKB.totalKB);
			CheckMemory().Forget();
		}

		private void OnDestroy()
		{
			continueChecking = false;
		}

		private async UniTaskVoid CheckMemory()
		{
			await UniTask.SwitchToThreadPool();
			while (continueChecking)
			{
				await UniTask.WaitForSeconds(delayBetweenChecksSeconds, ignoreTimeScale: true);
				var (freeKB, num) = MemoryMonitoring_Native.GetFreeAndTotalMemoryKB();
				if (freeKB == -1 || num == -1)
				{
					Debug.LogWarning("[MemoryMonitoring] couldn't check memory, disabling further checks");
					await UniTask.SwitchToMainThread();
					Object.Destroy(this);
					break;
				}
				if (num > lastTotalAvailKB)
				{
					Debug.Log(string.Format("[{0}] OS increased system memory from {1:N0} KB to {2:N0} KB", "MemoryMonitoring", lastTotalAvailKB, num));
				}
				lastTotalAvailKB = num;
				if (freeKB < currentThresholdKB)
				{
					currentThresholdKB = (long)((float)freeKB * thresholdReductionMultiplier);
					LogMemoryAmount(freeKB, num);
					await UniTask.SwitchToMainThread();
					LowMemoryThresholdReached?.Invoke(freeKB);
					await UniTask.SwitchToThreadPool();
				}
			}
		}

		private static void LogMemoryAmount(long freeKB, long totalKB)
		{
			Debug.Log(string.Format("[{0}] free: {1:N0} KB, total: {2:N0} KB", "MemoryMonitoring", freeKB, totalKB));
		}
	}
}
