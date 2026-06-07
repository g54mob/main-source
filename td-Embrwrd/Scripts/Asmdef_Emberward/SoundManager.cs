using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
	[CompilerGenerated]
	private sealed class _003CCR_MuteMusicForSeconds_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SoundManager _003C_003E4__this;

		public float time;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_MuteMusicForSeconds_003Ed__45(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_StartPlaySoundDelayed_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delayTime;

		public GameObject playObj;

		public SoundPlayer soundData;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_StartPlaySoundDelayed_003Ed__39(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CStart_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CStart_003Ed__23(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("目前已載入的聲音設定檔")]
	public List<SoundAssetData> list_SoundAssetData;

	[Header("遊戲執行中產生的播放物件")]
	public List<SoundPlayer> list_SoundPlayers;

	[SerializeField]
	private AudioMixerGroup audioMixer_Master;

	[SerializeField]
	private AudioMixerGroup audioMixer_Sound;

	[SerializeField]
	private AudioMixerGroup audioMixer_Music;

	[SerializeField]
	private bool isMuteInBackground;

	private Dictionary<int, SoundEntry> audioDic;

	private List<SoundCooldown> list_SoundCoolDown;

	private float volumeMultiplier_Sound;

	private float volumeMultiplier_Music;

	private float volumeMultiplier_Vocal;

	private int soundIndex;

	private Coroutine coroutine_MuteBGM;

	private bool isInitialized;

	private bool isFocused;

	private bool isPaused;

	public bool IsMute { get; private set; }

	public SoundPlayer currentBGMData { get; private set; }

	private bool DoMuteInBackground => false;

	protected override void Awake()
	{
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__23))]
	private IEnumerator Start()
	{
		return null;
	}

	private void Initialize()
	{
	}

	private void LoadSoundAssetData(SoundAssetData assetData)
	{
	}

	private void UnloadSoundAssetData(SoundAssetData assetData)
	{
	}

	private void Update()
	{
	}

	private void setMuteAll(bool isMute)
	{
	}

	private void setMute(SoundAssetData.SOUND_TYPE soundType, bool isMute)
	{
	}

	private void UpdateVolumeSetting()
	{
	}

	private SoundPlayer GetAvaliableSoundObj()
	{
		return null;
	}

	private void IncreaseSoundIndex()
	{
	}

	private int playSound_RandomPitch(string assetKeyName, string sndName, float minPitch = -1f, float maxPitch = -1f, float cooldown = -1f, float delay = -1f)
	{
		return 0;
	}

	private int playSound(string assetKeyName, string sndName, float pitch = -1f, float cooldown = -1f, float delay = -1f)
	{
		return 0;
	}

	private bool CheckCoolDown(string sndName)
	{
		return false;
	}

	private void RegisterCoolDown(string sndName, float coolDownTime)
	{
	}

	private void UnregisterCoolDown(string sndName)
	{
	}

	private int PlaySoundFinal(string fullName, float pitch, float cooldown, float delay)
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CCR_StartPlaySoundDelayed_003Ed__39))]
	private IEnumerator CR_StartPlaySoundDelayed(float delayTime, GameObject playObj, SoundPlayer soundData)
	{
		return null;
	}

	private void stopSound(string sndName)
	{
	}

	private void stopSound(int sndIndex)
	{
	}

	private int playMusic(string assetkeyName, string sndName, bool doFadeIn = false, float fadeTime = 0f, float fastForward = 0f, float pitch = 1f)
	{
		return 0;
	}

	private void stopMusic(float fadeoutTime = 0f)
	{
	}

	private void muteMusicForSeconds(float time)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_MuteMusicForSeconds_003Ed__45))]
	private IEnumerator CR_MuteMusicForSeconds(float time)
	{
		return null;
	}

	private bool isCurrentBGMName(string name)
	{
		return false;
	}

	public float GetCurrentBGMTime()
	{
		return 0f;
	}

	public void SetCurrentBGMPitch(float pitch)
	{
	}

	private void setMasterVolume(float soundLevel)
	{
	}

	private void modifySoundLevel(SoundAssetData.SOUND_TYPE soundType, float soundLevel)
	{
	}

	private float GetVolumeMultiplierByType(SoundAssetData.SOUND_TYPE type)
	{
		return 0f;
	}

	private string CombineKeyAndClipName(string keyName, string clipName)
	{
		return null;
	}

	private float LinearToDecibel(float linear)
	{
		return 0f;
	}

	private float DecibelToLinear(float dB)
	{
		return 0f;
	}

	private void registerSoundAssetData(List<SoundAssetData> list_Data)
	{
	}

	private void unregisterSoundAssetData(List<SoundAssetData> list_Data)
	{
	}

	public static void SetMuteAll(bool isMute)
	{
	}

	public static void SetMute(SoundAssetData.SOUND_TYPE soundType, bool isMute)
	{
	}

	public static int PlaySound_RandomPitch(string assetKeyName, string sndName, float minPitch = -1f, float maxPitch = -1f, float cooldown = -1f, float delay = -1f)
	{
		return 0;
	}

	public static int PlaySound(string assetKeyName, string sndName, float pitch = -1f, float cooldown = -1f, float delay = -1f)
	{
		return 0;
	}

	public static void StopSound(string sndName)
	{
	}

	public static void StopSound(int sndIndex)
	{
	}

	public static int PlayMusic(string assetkeyName, string sndName, bool doFadeIn = false, float fadeTime = 0f, float fastForward = 0f, float pitch = 1f)
	{
		return 0;
	}

	public static void StopMusic(float fadeoutTime = 0f)
	{
	}

	public static void MuteMusicForSeconds(float time)
	{
	}

	public static bool IsCurrentBGMName(string name)
	{
		return false;
	}

	public static void SetMasterVolume(float soundLevel)
	{
	}

	public static void SetVolume(SoundAssetData.SOUND_TYPE soundType, float soundLevel)
	{
	}

	public static float GetVolume(SoundAssetData.SOUND_TYPE soundType)
	{
		return 0f;
	}

	public SoundPlayer GetSoundPlayerByIndex(int sndIndex)
	{
		return null;
	}

	public void ToggleSoundMuteByIndex(int sndIndex, bool isMute)
	{
	}

	public static void RegisterSoundAssetData(List<SoundAssetData> list_Data)
	{
	}

	public static void UnregisterSoundAssetData(List<SoundAssetData> list_Data)
	{
	}

	public static void SetIsMuteInBackground(bool isOn)
	{
	}

	private void ApplyBackgroundMute()
	{
	}

	private void OnApplicationFocus(bool focusStatus)
	{
	}

	private void OnApplicationPause(bool pauseStatus)
	{
	}
}
