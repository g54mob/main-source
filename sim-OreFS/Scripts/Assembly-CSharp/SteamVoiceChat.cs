using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using UnityEngine;
using UnityEngine.InputSystem;

public class SteamVoiceChat : NetworkBehaviour
{
	[Header("Voice Activation")]
	[Tooltip("Ses verisi gelmediğinde konuşma durumunu kapatmadan önce beklenecek süre (saniye)")]
	[Range(0.1f, 1f)]
	public float silenceTimeout = 0.3f;

	[Header("Audio")]
	[Range(0f, 1f)]
	public float voiceVolume = 1f;

	[Range(0f, 50f)]
	public float spatialMaxDistance = 30f;

	[Range(0f, 5f)]
	public float spatialMinDistance = 2f;

	[Header("Network")]
	[Tooltip("Max compressed voice buffer size per packet (bytes)")]
	public int maxCompressedBufferSize = 8192;

	[Header("Input")]
	[SerializeField]
	private InputActionReference pushToTalkActionReference;

	[Header("Audio Source")]
	[SerializeField]
	private AudioSource voiceAudioSource;

	[Header("World Space Voice Icon")]
	[Tooltip("Oyuncunun başı üstünde gösterilecek ses ikonu (SpriteRenderer veya GameObject)")]
	[SerializeField]
	private GameObject voiceIconObject;

	[SyncVar(hook = "OnIsSpeakingChanged")]
	private bool isSpeaking;

	private bool isLocallyMuted;

	private bool isRecording;

	private bool isSpeakingLocal;

	private float silenceTimer;

	private byte[] compressedBuffer;

	private byte[] decompressedBuffer;

	private float[] audioBuffer;

	private int writePosition;

	private int readPosition;

	private uint optimalSampleRate;

	private AudioClip voiceClip;

	private AudioSource lastActiveSource;

	private GameObject currentVehicleIcon;

	private static readonly HashSet<SteamVoiceChat> mutedPlayers;

	private InputAction pushToTalkAction;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isSpeaking;

	public bool IsSpeaking => isSpeaking;

	private VoiceActivationMode ActiveMode
	{
		get
		{
			if (!(GameManager.Instance != null))
			{
				return VoiceActivationMode.Off;
			}
			return GameManager.Instance.voiceActivationMode;
		}
	}

	public bool IsLocallyMuted => isLocallyMuted;

	public bool NetworkisSpeaking
	{
		get
		{
			return isSpeaking;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isSpeaking, 1uL, _Mirror_SyncVarHookDelegate_isSpeaking);
		}
	}

	public static event Action<SteamVoiceChat, bool> OnSpeakingStateChanged;

	public static event Action<SteamVoiceChat> OnPlayerVoiceInitialized;

	public static event Action<SteamVoiceChat> OnPlayerVoiceDestroyed;

	public override void OnStartAuthority()
	{
		base.OnStartAuthority();
		compressedBuffer = new byte[maxCompressedBufferSize];
		optimalSampleRate = SteamUser.GetVoiceOptimalSampleRate();
		if (optimalSampleRate == 0)
		{
			optimalSampleRate = 11025u;
		}
		if (pushToTalkActionReference != null)
		{
			pushToTalkAction = pushToTalkActionReference.action;
			pushToTalkAction.Enable();
		}
		if (ActiveMode == VoiceActivationMode.VoiceActivation)
		{
			SteamUser.StartVoiceRecording();
			isRecording = true;
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (optimalSampleRate == 0)
		{
			optimalSampleRate = SteamUser.GetVoiceOptimalSampleRate();
			if (optimalSampleRate == 0)
			{
				optimalSampleRate = 11025u;
			}
		}
		decompressedBuffer = new byte[optimalSampleRate * 2];
		if (voiceAudioSource != null)
		{
			voiceAudioSource.spatialBlend = 1f;
			voiceAudioSource.rolloffMode = AudioRolloffMode.Linear;
			voiceAudioSource.minDistance = spatialMinDistance;
			voiceAudioSource.maxDistance = spatialMaxDistance;
			voiceAudioSource.playOnAwake = false;
			voiceAudioSource.loop = true;
			voiceAudioSource.volume = voiceVolume;
			if (base.isLocalPlayer)
			{
				voiceAudioSource.mute = true;
			}
		}
		int num = (int)(optimalSampleRate * 5);
		audioBuffer = new float[num];
		voiceClip = AudioClip.Create("VoiceChat_" + base.netId, num, 1, (int)optimalSampleRate, stream: true, OnAudioRead, OnAudioSetPosition);
		if (voiceAudioSource != null)
		{
			voiceAudioSource.clip = voiceClip;
		}
		if (voiceIconObject != null)
		{
			voiceIconObject.SetActive(value: false);
		}
		SteamVoiceChat.OnPlayerVoiceInitialized?.Invoke(this);
	}

	private void OnDestroy()
	{
		if (isRecording)
		{
			SteamUser.StopVoiceRecording();
			isRecording = false;
		}
		if (pushToTalkAction != null)
		{
			pushToTalkAction.Disable();
		}
		mutedPlayers.Remove(this);
		SteamVoiceChat.OnPlayerVoiceDestroyed?.Invoke(this);
	}

	public void SetActivationMode(VoiceActivationMode newMode)
	{
		if (!base.isLocalPlayer || GameManager.Instance == null)
		{
			return;
		}
		if (isRecording)
		{
			SteamUser.StopVoiceRecording();
			isRecording = false;
		}
		if (isSpeakingLocal || isSpeaking)
		{
			isSpeakingLocal = false;
			CmdSetSpeaking(speaking: false);
		}
		GameManager.Instance.voiceActivationMode = newMode;
		if (newMode == VoiceActivationMode.Off)
		{
			return;
		}
		if (compressedBuffer == null)
		{
			compressedBuffer = new byte[maxCompressedBufferSize];
			optimalSampleRate = SteamUser.GetVoiceOptimalSampleRate();
			if (optimalSampleRate == 0)
			{
				optimalSampleRate = 11025u;
			}
		}
		if (newMode == VoiceActivationMode.VoiceActivation)
		{
			SteamUser.StartVoiceRecording();
			isRecording = true;
		}
	}

	public void SetVehicleVoice(AudioSource vehicleSource, GameObject vehicleIcon)
	{
		if (lastActiveSource != null && lastActiveSource.isPlaying)
		{
			lastActiveSource.Stop();
		}
		if (vehicleSource != null)
		{
			vehicleSource.clip = voiceClip;
			vehicleSource.spatialBlend = 1f;
			vehicleSource.rolloffMode = AudioRolloffMode.Linear;
			vehicleSource.minDistance = spatialMinDistance;
			vehicleSource.maxDistance = spatialMaxDistance;
			vehicleSource.volume = voiceVolume;
			vehicleSource.loop = true;
			vehicleSource.playOnAwake = false;
			if (base.isLocalPlayer)
			{
				vehicleSource.mute = true;
			}
		}
		lastActiveSource = vehicleSource;
		if (voiceIconObject != null)
		{
			voiceIconObject.SetActive(value: false);
		}
		currentVehicleIcon = vehicleIcon;
		if (vehicleIcon != null)
		{
			vehicleIcon.SetActive(isSpeaking);
		}
	}

	public void ClearVehicleVoice()
	{
		if (lastActiveSource != null && lastActiveSource != voiceAudioSource && lastActiveSource.isPlaying)
		{
			lastActiveSource.Stop();
		}
		if (voiceAudioSource != null)
		{
			voiceAudioSource.clip = voiceClip;
		}
		lastActiveSource = null;
		if (currentVehicleIcon != null)
		{
			currentVehicleIcon.SetActive(value: false);
		}
		currentVehicleIcon = null;
		if (voiceIconObject != null)
		{
			voiceIconObject.SetActive(isSpeaking);
		}
	}

	private void Update()
	{
		if (!base.isLocalPlayer || !base.isOwned)
		{
			return;
		}
		if (ActiveMode == VoiceActivationMode.Off)
		{
			if (isRecording)
			{
				SteamUser.StopVoiceRecording();
				isRecording = false;
				if (isSpeakingLocal)
				{
					isSpeakingLocal = false;
					CmdSetSpeaking(speaking: false);
				}
			}
		}
		else if (ActiveMode == VoiceActivationMode.PushToTalk)
		{
			UpdatePushToTalk();
		}
		else
		{
			UpdateVoiceActivation();
		}
	}

	private void UpdatePushToTalk()
	{
		if (pushToTalkAction == null)
		{
			return;
		}
		if (pushToTalkAction.IsPressed())
		{
			if (!isRecording)
			{
				SteamUser.StartVoiceRecording();
				isRecording = true;
				CmdSetSpeaking(speaking: true);
			}
			PollAndSendVoice();
		}
		else if (isRecording)
		{
			SteamUser.StopVoiceRecording();
			isRecording = false;
			CmdSetSpeaking(speaking: false);
		}
	}

	private void UpdateVoiceActivation()
	{
		if (!isRecording)
		{
			SteamUser.StartVoiceRecording();
			isRecording = true;
		}
		if (PollAndSendVoice())
		{
			silenceTimer = 0f;
			if (!isSpeakingLocal)
			{
				isSpeakingLocal = true;
				CmdSetSpeaking(speaking: true);
			}
		}
		else if (isSpeakingLocal)
		{
			silenceTimer += Time.deltaTime;
			if (silenceTimer >= silenceTimeout)
			{
				isSpeakingLocal = false;
				CmdSetSpeaking(speaking: false);
			}
		}
	}

	private bool PollAndSendVoice()
	{
		if (compressedBuffer == null)
		{
			return false;
		}
		if (SteamUser.GetVoice(bWantCompressed: true, compressedBuffer, (uint)compressedBuffer.Length, out var nBytesWritten) == EVoiceResult.k_EVoiceResultOK && nBytesWritten != 0)
		{
			byte[] array = new byte[nBytesWritten];
			Buffer.BlockCopy(compressedBuffer, 0, array, 0, (int)nBytesWritten);
			CmdSendVoiceData(array);
			return true;
		}
		return false;
	}

	[Command]
	private void CmdSetSpeaking(bool speaking)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetSpeaking__Boolean(speaking);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(speaking);
		SendCommandInternal("System.Void SteamVoiceChat::CmdSetSpeaking(System.Boolean)", -2085609376, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdSendVoiceData(byte[] compressedVoice)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSendVoiceData__Byte_005B_005D(compressedVoice);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBytesAndSize(compressedVoice);
		SendCommandInternal("System.Void SteamVoiceChat::CmdSendVoiceData(System.Byte[])", -78636978, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcReceiveVoiceData(byte[] compressedVoice)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBytesAndSize(compressedVoice);
		SendRPCInternal("System.Void SteamVoiceChat::RpcReceiveVoiceData(System.Byte[])", -1922919496, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnAudioRead(float[] data)
	{
		for (int i = 0; i < data.Length; i++)
		{
			if (readPosition != writePosition)
			{
				data[i] = audioBuffer[readPosition];
				readPosition = (readPosition + 1) % audioBuffer.Length;
			}
			else
			{
				data[i] = 0f;
			}
		}
	}

	private void OnAudioSetPosition(int newPosition)
	{
	}

	private void OnIsSpeakingChanged(bool oldValue, bool newValue)
	{
		if (currentVehicleIcon != null)
		{
			currentVehicleIcon.SetActive(newValue);
			if (voiceIconObject != null)
			{
				voiceIconObject.SetActive(value: false);
			}
		}
		else if (voiceIconObject != null)
		{
			voiceIconObject.SetActive(newValue);
		}
		SteamVoiceChat.OnSpeakingStateChanged?.Invoke(this, newValue);
	}

	public void SetLocalMute(bool muted)
	{
		isLocallyMuted = muted;
		if (muted)
		{
			mutedPlayers.Add(this);
			if (voiceAudioSource != null)
			{
				voiceAudioSource.mute = true;
			}
		}
		else
		{
			mutedPlayers.Remove(this);
			if (voiceAudioSource != null && !base.isLocalPlayer)
			{
				voiceAudioSource.mute = false;
			}
		}
	}

	public void SetVolume(float volume)
	{
		if (voiceAudioSource != null)
		{
			voiceAudioSource.volume = Mathf.Clamp01(volume);
		}
	}

	public SteamVoiceChat()
	{
		_Mirror_SyncVarHookDelegate_isSpeaking = OnIsSpeakingChanged;
	}

	static SteamVoiceChat()
	{
		mutedPlayers = new HashSet<SteamVoiceChat>();
		RemoteProcedureCalls.RegisterCommand(typeof(SteamVoiceChat), "System.Void SteamVoiceChat::CmdSetSpeaking(System.Boolean)", InvokeUserCode_CmdSetSpeaking__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(SteamVoiceChat), "System.Void SteamVoiceChat::CmdSendVoiceData(System.Byte[])", InvokeUserCode_CmdSendVoiceData__Byte_005B_005D, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(SteamVoiceChat), "System.Void SteamVoiceChat::RpcReceiveVoiceData(System.Byte[])", InvokeUserCode_RpcReceiveVoiceData__Byte_005B_005D);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetSpeaking__Boolean(bool speaking)
	{
		NetworkisSpeaking = speaking;
	}

	protected static void InvokeUserCode_CmdSetSpeaking__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetSpeaking called on client.");
		}
		else
		{
			((SteamVoiceChat)obj).UserCode_CmdSetSpeaking__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdSendVoiceData__Byte_005B_005D(byte[] compressedVoice)
	{
		RpcReceiveVoiceData(compressedVoice);
	}

	protected static void InvokeUserCode_CmdSendVoiceData__Byte_005B_005D(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSendVoiceData called on client.");
		}
		else
		{
			((SteamVoiceChat)obj).UserCode_CmdSendVoiceData__Byte_005B_005D(reader.ReadBytesAndSize());
		}
	}

	protected void UserCode_RpcReceiveVoiceData__Byte_005B_005D(byte[] compressedVoice)
	{
		if (base.isLocalPlayer || isLocallyMuted || mutedPlayers.Contains(this))
		{
			return;
		}
		AudioSource audioSource = ((lastActiveSource != null) ? lastActiveSource : voiceAudioSource);
		if (!(audioSource == null) && decompressedBuffer != null && SteamUser.DecompressVoice(compressedVoice, (uint)compressedVoice.Length, decompressedBuffer, (uint)decompressedBuffer.Length, out var nBytesWritten, optimalSampleRate) == EVoiceResult.k_EVoiceResultOK && nBytesWritten != 0)
		{
			int num = (int)(nBytesWritten / 2);
			for (int i = 0; i < num; i++)
			{
				short num2 = BitConverter.ToInt16(decompressedBuffer, i * 2);
				audioBuffer[writePosition] = (float)num2 / 32768f;
				writePosition = (writePosition + 1) % audioBuffer.Length;
			}
			if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
	}

	protected static void InvokeUserCode_RpcReceiveVoiceData__Byte_005B_005D(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcReceiveVoiceData called on server.");
		}
		else
		{
			((SteamVoiceChat)obj).UserCode_RpcReceiveVoiceData__Byte_005B_005D(reader.ReadBytesAndSize());
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isSpeaking);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isSpeaking);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isSpeaking, _Mirror_SyncVarHookDelegate_isSpeaking, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isSpeaking, _Mirror_SyncVarHookDelegate_isSpeaking, reader.ReadBool());
		}
	}
}
