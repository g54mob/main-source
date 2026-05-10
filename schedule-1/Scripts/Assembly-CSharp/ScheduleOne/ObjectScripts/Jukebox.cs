using System;
using EasyButtons;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.EntityFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.ObjectScripts
{
	public class Jukebox : GridItem
	{
		[Serializable]
		public class Track
		{
			public string TrackName;

			public AudioClip Clip;

			public string ArtistName;
		}

		[Serializable]
		public class JukeboxState
		{
			public int CurrentVolume;

			public bool IsPlaying;

			public float CurrentTrackTime;

			public int[] TrackOrder;

			public int CurrentTrackOrderIndex;

			public bool Shuffle;

			public ERepeatMode RepeatMode;

			public bool Sync;
		}

		public enum ERepeatMode
		{
			None = 0,
			RepeatQueue = 1,
			RepeatTrack = 2
		}

		public const float MUSIC_FADE_MULTIPLIER = 0.4f;

		public const int TRACK_COUNT = 27;

		private JukeboxState _jukeboxState;

		[Header("References")]
		public Track[] TrackList;

		public GameObject[] VolumeIndicatorBars;

		public AudioSourceController AudioSourceController;

		public Action onStateChanged;

		private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EJukeboxAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EJukeboxAssembly_002DCSharp_002Edll_Excuted;

		public int CurrentVolume => 0;

		public float NormalizedVolume => 0f;

		public bool IsPlaying => false;

		public float CurrentTrackTime => 0f;

		private int[] TrackOrder => null;

		public int CurrentTrackOrderIndex => 0;

		public bool Shuffle => false;

		public ERepeatMode RepeatMode => default(ERepeatMode);

		public bool Sync => false;

		public Track currentTrack => null;

		private AudioClip currentClip => null;

		public override void Awake()
		{
		}

		private void FixedUpdate()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public void ChangeVolume(int change)
		{
		}

		public void SetVolume(int volume, bool replicate)
		{
		}

		private void ApplyVolume()
		{
		}

		[Button]
		public void TogglePlay()
		{
		}

		[Button]
		public void Back()
		{
		}

		[Button]
		public void Next()
		{
		}

		private int GetPreviousTrackOrderIndex()
		{
			return 0;
		}

		private int GetNextTrackOrderIndex()
		{
			return 0;
		}

		[Button]
		public void ToggleShuffle()
		{
		}

		[Button]
		public void ToggleRepeatMode()
		{
		}

		[Button]
		public void ToggleSync()
		{
		}

		public void PlayTrack(int trackID)
		{
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		public void SendJukeboxState(JukeboxState state, bool setTrackTime, bool setSync)
		{
		}

		[TargetRpc]
		[ObserversRpc(RunLocally = true)]
		public void SetJukeboxState(NetworkConnection conn, JukeboxState state, bool setTrackTime, bool setSync)
		{
		}

		public void SetJukeboxState(JukeboxState state, bool setTrackTime)
		{
		}

		private Track GetTrack(int orderIndex)
		{
			return null;
		}

		private bool ValidateQueue(int[] queue)
		{
			return false;
		}

		private void ReplicateStateToOtherClients(bool setTrackTime)
		{
		}

		private void ReplicateStateToOtherJukeboxes(bool setTrackTime)
		{
		}

		public override BuildableItemData GetBaseData()
		{
			return null;
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Server_SendJukeboxState_1728100027(JukeboxState state, bool setTrackTime, bool setSync)
		{
		}

		public void RpcLogic___SendJukeboxState_1728100027(JukeboxState state, bool setTrackTime, bool setSync)
		{
		}

		private void RpcReader___Server_SendJukeboxState_1728100027(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Observers_SetJukeboxState_2499833112(NetworkConnection conn, JukeboxState state, bool setTrackTime, bool setSync)
		{
		}

		public void RpcLogic___SetJukeboxState_2499833112(NetworkConnection conn, JukeboxState state, bool setTrackTime, bool setSync)
		{
		}

		private void RpcReader___Observers_SetJukeboxState_2499833112(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_SetJukeboxState_2499833112(NetworkConnection conn, JukeboxState state, bool setTrackTime, bool setSync)
		{
		}

		private void RpcReader___Target_SetJukeboxState_2499833112(PooledReader PooledReader0, Channel channel)
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EObjectScripts_002EJukebox_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
