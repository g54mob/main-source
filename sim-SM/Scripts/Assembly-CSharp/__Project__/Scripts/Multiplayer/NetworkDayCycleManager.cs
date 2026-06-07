using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkDayCycleManager : NoktaSingletonPunCallbacks<NetworkDayCycleManager>
	{
		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnSyncRequest(string invokerUserID)
		{
		}

		private void RequestCurrentDayData_Broadcast(bool dayCycling)
		{
		}

		[PunRPC]
		public void SyncCurrentDay_RPC(bool aM, float dayDurationInGameTimeInSeconds, float dayDurationInReelTimeInSeconds, float gameTimeScale, float currentTimeInFloat, int currentTimeInSeconds, int currentTimeInMinutes, int currentTimeInHours, float dayPercentage, int currentDay, float currentTime, bool dayCycling)
		{
		}

		public void RequestSyncTime_Broadcast()
		{
		}

		[PunRPC]
		public void RequestSyncTime_RPC(int hour, int minute, int second)
		{
		}

		public void StartNextDay_Broadcast()
		{
		}

		[PunRPC]
		public void StartNextDay_RPC()
		{
		}

		public void FinishTheDay_Broadcast()
		{
		}

		[PunRPC]
		public void FinishTheDay_RPC()
		{
		}
	}
}
