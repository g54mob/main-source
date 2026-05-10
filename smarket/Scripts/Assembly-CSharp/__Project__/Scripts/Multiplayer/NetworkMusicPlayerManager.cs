using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkMusicPlayerManager : NoktaSingletonPunCallbacks<NetworkMusicPlayerManager>
	{
		private void Start()
		{
		}

		private void OnSyncRequest(string invokerUserID)
		{
		}

		[PunRPC]
		public void SyncMusic_RPC(int index, float volume, float playbackTime, bool trackPlay)
		{
		}

		public void PlayAudio_Broadcast()
		{
		}

		[PunRPC]
		public void PlayAudio_RPC()
		{
		}

		public void SkipMusicForward_Broadcast()
		{
		}

		[PunRPC]
		public void SkipMusicForward_RPC()
		{
		}

		public void SkipMusicBackward_Broadcast()
		{
		}

		[PunRPC]
		public void SkipMusicBackward_RPC()
		{
		}

		public void MusicTime_Broadcast(float time)
		{
		}

		[PunRPC]
		public void MusicTime_RPC(float time)
		{
		}

		public void VolumeChange_Broadcast(float volume)
		{
		}

		[PunRPC]
		public void VolumeChange_RPC(float volume)
		{
		}

		public void PauseAudio_Broadcast()
		{
		}

		[PunRPC]
		public void PauseAudio_RPC()
		{
		}

		public void StopAudio_Broadcast()
		{
		}

		[PunRPC]
		public void StopAudio_RPC()
		{
		}
	}
}
