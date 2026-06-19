using System;
using System.Collections.Generic;
using System.Diagnostics;
using Aggro.Core;
using Aggro.Core.Networking;
using Dissonance;
using Dissonance.Integrations.FMOD_Playback;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceManager : AggroManagerBase<VoiceManager>
{
	private enum VoipSetting
	{
		Active = 0,
		PushToTalk = 1,
		Disabled = 2
	}

	private struct Player
	{
		public VoicePlayerState voice;

		public FMODVoicePlayback playback;

		public float uiVolume;

		public int index;

		public float radioTimer;

		public bool wasSpeaking;

		public bool mutedByPlatform;

		public bool TryGetEntity(out Entity entity)
		{
			if (voice.Tracker is MonoBehaviour comp)
			{
				return comp.TryGetEntity(out entity);
			}
			entity = Entity.invalid;
			return false;
		}
	}

	[Serializable]
	public class VoicePlayer
	{
		public string busId;

		public EventReference ghostRef;

		public EventReference anvilRef;

		public EventReference batteryRef;

		public EventReference radioRef;

		[NonSerialized]
		public GUID busGuid;

		[NonSerialized]
		public FMOD.Studio.EventInstance ghostInstance;

		[NonSerialized]
		public FMOD.Studio.EventInstance anvilInstance;

		[NonSerialized]
		public FMOD.Studio.EventInstance batteryInstance;

		[NonSerialized]
		public FMOD.Studio.EventInstance radioInstance;

		[NonSerialized]
		public PARAMETER_ID radioParameter;
	}

	public DissonanceComms comms;

	public VoiceBroadcastTrigger broadcast;

	[Range(0f, 1f)]
	public float startingVolume = 0.7f;

	[Min(0f)]
	public float maxDistance = 50f;

	[Range(0f, 1f)]
	public float minDistanceVolume = 0.5f;

	public VoicePlayer[] voicePlayers;

	public float radioDistance = 10f;

	private readonly bool _isRestrictedByPlatform = Aggro.Core.Platform.PlayerMutedByPlatform();

	private List<Player> _players = new List<Player>();

	private List<int> _indices = new List<int>();

	private uint _inputSettingVersion;

	private VoicePlayerState _localPlayerVoicePlayerState;

	private uint _pttVersion;

	private uint _pttInputVersion;

	private VECTOR[] _customRollOff;

	private static readonly int SETTING_AUDIO_INPUT = AggroSettings.IdToHash("audio-input");

	private static readonly int VOIP_SETTING_ID = AggroSettings.IdToHash("audio-voip");

	public float radioAmplitudeThreshold = 0.05f;

	public float radioCooldown = 1f;

	public EventReference radioInSfx;

	public EventReference radioOutSfx;

	public bool isMuted => broadcast.IsMuted;

	public bool isVoiceCommsRestricted => _isRestrictedByPlatform;

	protected override void OnEntityCreated()
	{
		if (AggroNetworkManager.isSinglePlayer || _isRestrictedByPlatform)
		{
			base.enabled = false;
			broadcast.Mode = CommActivationMode.None;
			if (_isRestrictedByPlatform)
			{
				comms.IsDeafened = true;
			}
			return;
		}
		for (int i = 0; i < voicePlayers.Length; i++)
		{
			VoicePlayer voicePlayer = voicePlayers[i];
			voicePlayer.ghostInstance = RuntimeManager.CreateInstance(voicePlayer.ghostRef);
			voicePlayer.anvilInstance = RuntimeManager.CreateInstance(voicePlayer.anvilRef);
			voicePlayer.batteryInstance = RuntimeManager.CreateInstance(voicePlayer.batteryRef);
			voicePlayer.radioInstance = RuntimeManager.CreateInstance(voicePlayer.radioRef);
			CheckResult("getParameterDescriptionByName", RuntimeManager.StudioSystem.getParameterDescriptionByName($"CrOut-VOIP{i + 1}", out var parameter));
			voicePlayer.radioParameter = parameter.id;
			if (RuntimeManager.GetBus(voicePlayer.busId).getID(out voicePlayer.busGuid) != RESULT.OK)
			{
				UnityEngine.Debug.LogWarning("Was unable to get bus path! (" + voicePlayer.busId + ")");
			}
			_indices.Add(i);
		}
		comms.OnPlayerJoinedSession += OnPlayerJoinedSession;
		comms.OnPlayerLeftSession += OnPlayerLeftSession;
		foreach (VoicePlayerState player in comms.Players)
		{
			AddPlayer(player);
		}
		DropdownSetting setting = AggroSettings.GetSetting<DropdownSetting>(VOIP_SETTING_ID);
		_pttVersion = setting.saveVersion;
		SetVoiceSetting((VoipSetting)setting.index);
		SceneManager.MoveGameObjectToScene(FMODChannelGroupLocks.Instance.gameObject, SceneManager.GetSceneByName("scene-game"));
	}

	protected override void OnEntityDestroyed()
	{
		if (!AggroNetworkManager.isSinglePlayer)
		{
			comms.OnPlayerJoinedSession -= OnPlayerJoinedSession;
			comms.OnPlayerLeftSession -= OnPlayerLeftSession;
			for (int i = 0; i < voicePlayers.Length; i++)
			{
				VoicePlayer obj = voicePlayers[i];
				obj.ghostInstance.release();
				obj.anvilInstance.release();
				obj.batteryInstance.release();
			}
		}
	}

	private void OnPlayerJoinedSession(VoicePlayerState player)
	{
		AddPlayer(player);
	}

	private void OnPlayerLeftSession(VoicePlayerState player)
	{
		RemovePlayer(player);
	}

	public VoicePlayerState GetLocalPlayerVoicePlayerState()
	{
		return _localPlayerVoicePlayerState;
	}

	public VoicePlayerState GetVoicePlayerStateFromEntity(Entity entityToCheck)
	{
		foreach (Player player in _players)
		{
			if (player.TryGetEntity(out var entity) && entity == entityToCheck)
			{
				return player.voice;
			}
		}
		return null;
	}

	private void AddPlayer(VoicePlayerState voice)
	{
		if (voice.IsLocalPlayer)
		{
			_localPlayerVoicePlayerState = voice;
			return;
		}
		Player item = default(Player);
		item.voice = voice;
		item.playback = (FMODVoicePlayback)voice.Playback;
		item.index = _indices[0];
		item.uiVolume = startingVolume;
		item.voice.Volume = startingVolume;
		item.playback.OutputBusID = voicePlayers[item.index].busGuid.ToString();
		item.mutedByPlatform = false;
		if (_isRestrictedByPlatform)
		{
			item.voice.IsLocallyMuted = true;
			item.mutedByPlatform = true;
		}
		if (_customRollOff == null)
		{
			VECTOR vECTOR = new VECTOR
			{
				x = 0f,
				y = 1f
			};
			VECTOR vECTOR2 = new VECTOR
			{
				x = maxDistance,
				y = minDistanceVolume
			};
			VECTOR vECTOR3 = new VECTOR
			{
				x = item.playback.MaxDistance,
				y = minDistanceVolume
			};
			_customRollOff = new VECTOR[3] { vECTOR, vECTOR2, vECTOR3 };
		}
		item.playback.SetCustomRollOff(_customRollOff);
		List<NetworkPlayerManager.PlayerStats> list = new List<NetworkPlayerManager.PlayerStats>();
		NetworkAggroManagerBase<NetworkPlayerManager>.instance.PopulatePlayerStats(list);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].voiceName == item.voice.Name && (MutedByPlatform(list[i].platformId) || MutedByPlatform(list[i].playFabId)))
			{
				item.voice.IsLocallyMuted = true;
				item.mutedByPlatform = true;
			}
		}
		_players.Add(item);
		_indices.RemoveAtSwapBack(0);
	}

	public bool MutedByPlatform(ulong platformId)
	{
		return Aggro.Core.Platform.PlayerMutedByPlatform(platformId);
	}

	public bool MutedByPlatform(string playFabId)
	{
		return Aggro.Core.Platform.PlayerMutedByPlatform(playFabId);
	}

	private void RemovePlayer(VoicePlayerState voice)
	{
		if (voice.IsLocalPlayer)
		{
			return;
		}
		for (int i = 0; i < _players.Count; i++)
		{
			Player player = _players[i];
			if (player.voice.Name == voice.Name)
			{
				_indices.Add(player.index);
				_players.RemoveAt(i);
				break;
			}
		}
	}

	protected override void OnUpdatePresentation()
	{
		FMODAudioInputSetting setting = AggroSettings.GetSetting<FMODAudioInputSetting>(SETTING_AUDIO_INPUT);
		if (_inputSettingVersion != setting.saveVersion)
		{
			_inputSettingVersion = setting.saveVersion;
			if (setting.TryGetRecordDriverInfo(out var driverName, out var _))
			{
				comms.MicrophoneName = driverName;
			}
		}
		DropdownSetting setting2 = AggroSettings.GetSetting<DropdownSetting>(VOIP_SETTING_ID);
		if (setting2.saveVersion != _pttVersion)
		{
			_pttVersion = setting2.saveVersion;
			SetVoiceSetting((VoipSetting)setting2.index);
		}
		if (setting2.index == 1)
		{
			bool flag = AggroInputManager.input.Always.PTT.IsPressed();
			if (flag == broadcast.IsMuted)
			{
				broadcast.IsMuted = !flag;
			}
		}
		if (_isRestrictedByPlatform)
		{
			broadcast.IsMuted = true;
			comms.IsDeafened = true;
			comms.IsMuted = true;
			return;
		}
		if (GameUtil.isLobby || !NetworkAggroManagerBase<ShiftManager>.ManagerExists() || NetworkAggroManagerBase<ShiftManager>.instance.isTransitioning)
		{
			for (int i = 0; i < _players.Count; i++)
			{
				Player player = _players[i];
				VoicePlayer voicePlayer = voicePlayers[player.index];
				RuntimeManager.StudioSystem.setParameterByID(voicePlayer.radioParameter, 0f);
				StopEvent("Radio Stop", voicePlayer.radioInstance);
				StopEvent("Anvil Stop", voicePlayer.anvilInstance);
				StopEvent("Battery Stop", voicePlayer.batteryInstance);
				StopEvent("Ghost Stop", voicePlayer.ghostInstance);
				player.playback.DisablePositionalAudio = true;
			}
			return;
		}
		for (int j = 0; j < _players.Count; j++)
		{
			Player value = _players[j];
			VoicePlayer voicePlayer2 = voicePlayers[value.index];
			value.playback.DisablePositionalAudio = false;
			if (!value.TryGetEntity(out var entity) || !entity.TryGetObject<PlayerEffects>(out var obj))
			{
				continue;
			}
			if (GameUtil.TryGetLocalPlayer(out var player2))
			{
				float num = Vector3.Distance(player2.transform.position, entity.transform.position);
				if (num > radioDistance)
				{
					StartEvent("radioInstance", voicePlayer2.radioInstance);
				}
				else
				{
					StopEvent("radioInstance", voicePlayer2.radioInstance);
				}
				value.radioTimer += Time.deltaTime;
				bool flag2 = value.voice.Amplitude > radioAmplitudeThreshold;
				if (num > radioDistance && flag2 && !value.wasSpeaking && value.radioTimer > radioCooldown)
				{
					value.radioTimer = 0f;
					AudioManager.PlaySfx(radioInSfx);
				}
				if (num > radioDistance && !flag2 && value.wasSpeaking && value.radioTimer > radioCooldown)
				{
					value.radioTimer = 0f;
					AudioManager.PlaySfx(radioOutSfx);
				}
				value.wasSpeaking = flag2;
				_players[j] = value;
			}
			PlayerCensor playerCensor = entity.GetObject<PlayerCensor>();
			RuntimeManager.StudioSystem.setParameterByID(voicePlayer2.radioParameter, playerCensor.bleeping ? 1f : 0f);
			value.voice.Volume = (playerCensor.bleeping ? 0f : value.uiVolume);
			if (obj.syncInvisible)
			{
				StartEvent("GhostInstance Start", voicePlayer2.ghostInstance);
			}
			else
			{
				StopEvent("GhostInstance Stop", voicePlayer2.ghostInstance);
			}
			PlayerEffectContext playerEffectContext = PlayerEffectContext.Battery | PlayerEffectContext.Anvil;
			if ((obj.context & playerEffectContext) != PlayerEffectContext.None && (obj.context & playerEffectContext) != playerEffectContext)
			{
				if ((obj.context & PlayerEffectContext.Anvil) != PlayerEffectContext.None)
				{
					StartEvent("Anvil Start", voicePlayer2.anvilInstance);
					StopEvent("Battery Stop", voicePlayer2.batteryInstance);
				}
				else
				{
					StartEvent("Battery Start", voicePlayer2.batteryInstance);
					StopEvent("Anvil Stop", voicePlayer2.anvilInstance);
				}
			}
			else
			{
				StopEvent("Anvil Stop", voicePlayer2.anvilInstance);
				StopEvent("Battery Stop", voicePlayer2.batteryInstance);
			}
		}
	}

	private void StartEvent(string label, FMOD.Studio.EventInstance sfx)
	{
		if (CheckResult(label, sfx.getPlaybackState(out var state)) && state != PLAYBACK_STATE.PLAYING && state != PLAYBACK_STATE.STARTING)
		{
			CheckResult(label, sfx.start());
		}
	}

	private void StopEvent(string label, FMOD.Studio.EventInstance sfx)
	{
		if (CheckResult(label, sfx.getPlaybackState(out var state)) && state != PLAYBACK_STATE.STOPPED && state != PLAYBACK_STATE.STOPPING)
		{
			CheckResult(label, sfx.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT));
		}
	}

	private static bool CheckResult(string label, RESULT result)
	{
		if (result != RESULT.OK)
		{
			UnityEngine.Debug.LogWarning($"{label} has invalid result! ({result})");
			return false;
		}
		return true;
	}

	public bool HasPlayer(string playerName)
	{
		return GetPlayerIndex(playerName) >= 0;
	}

	public bool IsMuted(string playerName)
	{
		return _players[GetPlayerIndex(playerName)].voice.IsLocallyMuted;
	}

	public void ToggleMute(string playerName)
	{
		Player player = _players[GetPlayerIndex(playerName)];
		player.voice.IsLocallyMuted = !player.voice.IsLocallyMuted;
	}

	public float GetVolume(string playerName)
	{
		return _players[GetPlayerIndex(playerName)].uiVolume;
	}

	public void SetVolume(string playerName, float volume)
	{
		Player value = _players[GetPlayerIndex(playerName)];
		value.uiVolume = volume;
		_players[GetPlayerIndex(playerName)] = value;
	}

	private void SetVoiceSetting(VoipSetting setting)
	{
		switch (setting)
		{
		case VoipSetting.Active:
			broadcast.Mode = CommActivationMode.VoiceActivation;
			broadcast.IsMuted = false;
			break;
		case VoipSetting.PushToTalk:
			broadcast.Mode = CommActivationMode.Open;
			broadcast.IsMuted = true;
			break;
		case VoipSetting.Disabled:
			broadcast.Mode = CommActivationMode.None;
			broadcast.IsMuted = true;
			break;
		default:
			throw new InvalidEnumException();
		}
	}

	private int GetPlayerIndex(string playerName)
	{
		for (int i = 0; i < _players.Count; i++)
		{
			if (_players[i].voice.Name == playerName)
			{
				return i;
			}
		}
		return -1;
	}

	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	private void VerifyPlayerExists(string playerName)
	{
		if (GetPlayerIndex(playerName) < 0)
		{
			throw new InvalidOperationException("[VOICE] Player does not exist!");
		}
	}
}
