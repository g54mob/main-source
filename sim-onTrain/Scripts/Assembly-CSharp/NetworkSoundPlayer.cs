using System.Collections.Generic;
using DG.Tweening;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Audio;

public class NetworkSoundPlayer : NetworkBehaviour
{
	[Header("Ses Veritabanı")]
	[SerializeField]
	[Tooltip("Tüm oyun sesleri burada tanımlanır")]
	private List<EastupSoundData> soundDatabase = new List<EastupSoundData>();

	[Header("Environment & Game FX Sesleri")]
	[SerializeField]
	[Tooltip("Çevre ve oyun efekt sesleri")]
	private List<EastupSoundData> environmentGameFXSound = new List<EastupSoundData>();

	[Header("Ayarlar")]
	[SerializeField]
	[Tooltip("Master ses yüksekliği çarpanı")]
	[Range(0f, 1f)]
	private float masterVolume = 1f;

	[Header("Pool Settings")]
	[SerializeField]
	[Tooltip("Ses objesinin pool adı (NetworkPoolManager'da tanımlı olmalı)")]
	private string audioPoolName = "AudioObject";

	[Header("Local 2D Pool (Network'siz)")]
	[SerializeField]
	[Tooltip("2D local ses için oluşturulacak AudioSource sayısı")]
	private int local2DPoolSize = 8;

	[SerializeField]
	[Tooltip("Local 2D seslerin (loot, craft vb.) yönlendirileceği mixer grubu. Boşsa mixer bypass edilir ve ses ayarları bu sesleri etkilemez!")]
	private AudioMixerGroup local2DMixerGroup;

	private List<AudioSource> local2DPool = new List<AudioSource>();

	private Dictionary<GameAudios, EastupSoundData> soundDictionary;

	public static NetworkSoundPlayer Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		InitializeSoundDictionary();
		InitializeLocal2DPool();
	}

	private void InitializeLocal2DPool()
	{
		for (int i = 0; i < local2DPoolSize; i++)
		{
			GameObject obj = new GameObject($"Local2DAudio_{i}");
			obj.transform.SetParent(base.transform);
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.spatialBlend = 0f;
			audioSource.playOnAwake = false;
			if (local2DMixerGroup != null)
			{
				audioSource.outputAudioMixerGroup = local2DMixerGroup;
			}
			local2DPool.Add(audioSource);
		}
	}

	public void PlaySound2DLocal(GameAudios audioName)
	{
		if (soundDictionary == null || !soundDictionary.ContainsKey(audioName))
		{
			Debug.LogWarning($"Sound not found in database: {audioName}");
			return;
		}
		EastupSoundData eastupSoundData = soundDictionary[audioName];
		AudioClip audioClip = eastupSoundData.GetAudioClip();
		if (audioClip == null)
		{
			return;
		}
		AudioSource audioSource = null;
		foreach (AudioSource item in local2DPool)
		{
			if (!item.isPlaying)
			{
				audioSource = item;
				break;
			}
		}
		if (audioSource == null)
		{
			Debug.LogWarning("Local 2D audio pool is full! Consider increasing local2DPoolSize.");
			return;
		}
		audioSource.clip = audioClip;
		audioSource.volume = GetVolume(eastupSoundData);
		audioSource.pitch = GetPitch(eastupSoundData);
		audioSource.Play();
	}

	private void InitializeSoundDictionary()
	{
		soundDictionary = new Dictionary<GameAudios, EastupSoundData>();
		foreach (EastupSoundData item in soundDatabase)
		{
			if (!soundDictionary.ContainsKey(item.audioName))
			{
				soundDictionary.Add(item.audioName, item);
			}
			else
			{
				Debug.LogWarning($"Duplicate audio entry found: {item.audioName}");
			}
		}
		foreach (EastupSoundData item2 in environmentGameFXSound)
		{
			if (!soundDictionary.ContainsKey(item2.audioName))
			{
				soundDictionary.Add(item2.audioName, item2);
			}
			else
			{
				Debug.LogWarning($"Duplicate audio entry found: {item2.audioName}");
			}
		}
	}

	public void PlaySound(NetworkSoundData soundData, Vector3 position)
	{
		if (soundData.delay <= 0f)
		{
			PlaySound(soundData.audioName, position);
			return;
		}
		DOVirtual.DelayedCall(soundData.delay, delegate
		{
			PlaySound(soundData.audioName, position);
		});
	}

	public void PlaySound(GameAudios audioName, Vector3 position)
	{
		if (soundDictionary == null || !soundDictionary.ContainsKey(audioName))
		{
			Debug.LogWarning($"Sound not found in database: {audioName}");
			return;
		}
		EastupSoundData eastupSoundData = soundDictionary[audioName];
		if (eastupSoundData.isLocalOnly)
		{
			PlaySoundLocal(eastupSoundData, position);
		}
		else if (base.isServer)
		{
			RpcPlaySoundAtPosition(audioName, position);
		}
		else
		{
			CmdPlaySoundAtPosition(audioName, position);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdPlaySoundAtPosition(GameAudios audioName, Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_GameAudios(writer, audioName);
		writer.WriteVector3(position);
		SendCommandInternal("System.Void NetworkSoundPlayer::CmdPlaySoundAtPosition(GameAudios,UnityEngine.Vector3)", 1299148616, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlaySoundAtPosition(GameAudios audioName, Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_GameAudios(writer, audioName);
		writer.WriteVector3(position);
		SendRPCInternal("System.Void NetworkSoundPlayer::RpcPlaySoundAtPosition(GameAudios,UnityEngine.Vector3)", 1323521213, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void PlaySoundLocalOnly(GameAudios audioName, Vector3 position)
	{
		if (soundDictionary != null && soundDictionary.ContainsKey(audioName))
		{
			PlaySoundLocal(soundDictionary[audioName], position);
		}
	}

	private void PlaySoundLocal(EastupSoundData soundData, Vector3 position)
	{
		AudioClip audioClip = soundData.GetAudioClip();
		if (audioClip == null)
		{
			Debug.LogWarning($"AudioClip is null for {soundData.audioName}");
			return;
		}
		if (!TryGetAudioObjectFromPool(out var audioObject))
		{
			Debug.LogWarning("Audio pool is empty! Consider increasing pool size.");
			return;
		}
		audioObject.transform.position = position;
		audioObject.SetActive(value: true);
		AudioSource component = audioObject.GetComponent<AudioSource>();
		if (component == null)
		{
			Debug.LogError("AudioObject prefab doesn't have AudioSource component!");
			ReturnAudioObjectToPool(audioObject);
			return;
		}
		float volume = GetVolume(soundData);
		float pitch = GetPitch(soundData);
		component.clip = audioClip;
		component.volume = volume;
		component.pitch = pitch;
		component.spatialBlend = 1f;
		component.minDistance = soundData.minDistance;
		component.maxDistance = soundData.maxDistance;
		component.rolloffMode = AudioRolloffMode.Linear;
		component.Play();
		DOVirtual.DelayedCall(audioClip.length, delegate
		{
			ReturnAudioObjectToPool(audioObject);
		});
	}

	private bool TryGetAudioObjectFromPool(out GameObject audioObject)
	{
		audioObject = null;
		if (NetworkPoolManager.Instance == null)
		{
			Debug.LogError("NetworkPoolManager instance not found!");
			return false;
		}
		audioObject = NetworkPoolManager.Instance.GetFromLocalPool(audioPoolName);
		return audioObject != null;
	}

	private void ReturnAudioObjectToPool(GameObject audioObject)
	{
		if (audioObject != null && NetworkPoolManager.Instance != null)
		{
			NetworkPoolManager.Instance.ReturnToLocalPoolPublic(audioPoolName, audioObject);
		}
	}

	public void PlaySound2D(GameAudios audioName)
	{
		if (soundDictionary == null || !soundDictionary.ContainsKey(audioName))
		{
			Debug.LogWarning($"Sound not found in database: {audioName}");
			return;
		}
		EastupSoundData eastupSoundData = soundDictionary[audioName];
		AudioClip audioClip = eastupSoundData.GetAudioClip();
		if (audioClip == null)
		{
			Debug.LogWarning($"AudioClip is null for {audioName}");
			return;
		}
		if (!TryGetAudioObjectFromPool(out var audioObject))
		{
			Debug.LogWarning("Audio pool is empty! Consider increasing pool size.");
			return;
		}
		audioObject.transform.position = ((Camera.main != null) ? Camera.main.transform.position : Vector3.zero);
		audioObject.SetActive(value: true);
		AudioSource component = audioObject.GetComponent<AudioSource>();
		if (component == null)
		{
			Debug.LogError("AudioObject prefab doesn't have AudioSource component!");
			ReturnAudioObjectToPool(audioObject);
			return;
		}
		float volume = GetVolume(eastupSoundData);
		float pitch = GetPitch(eastupSoundData);
		component.clip = audioClip;
		component.volume = volume;
		component.pitch = pitch;
		component.spatialBlend = 0f;
		component.Play();
		DOVirtual.DelayedCall(audioClip.length, delegate
		{
			ReturnAudioObjectToPool(audioObject);
		});
	}

	private float GetVolume(EastupSoundData soundData)
	{
		return Random.Range(soundData.VolumeRange.x, soundData.VolumeRange.y) * soundData.volumeMultiplier * masterVolume;
	}

	private float GetPitch(EastupSoundData soundData)
	{
		return Random.Range(soundData.PitchRange.x, soundData.PitchRange.y);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdPlaySoundAtPosition__GameAudios__Vector3(GameAudios audioName, Vector3 position)
	{
		RpcPlaySoundAtPosition(audioName, position);
	}

	protected static void InvokeUserCode_CmdPlaySoundAtPosition__GameAudios__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlaySoundAtPosition called on client.");
		}
		else
		{
			((NetworkSoundPlayer)obj).UserCode_CmdPlaySoundAtPosition__GameAudios__Vector3(GeneratedNetworkCode._Read_GameAudios(reader), reader.ReadVector3());
		}
	}

	protected void UserCode_RpcPlaySoundAtPosition__GameAudios__Vector3(GameAudios audioName, Vector3 position)
	{
		if (soundDictionary != null && soundDictionary.ContainsKey(audioName))
		{
			EastupSoundData soundData = soundDictionary[audioName];
			PlaySoundLocal(soundData, position);
		}
	}

	protected static void InvokeUserCode_RpcPlaySoundAtPosition__GameAudios__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlaySoundAtPosition called on server.");
		}
		else
		{
			((NetworkSoundPlayer)obj).UserCode_RpcPlaySoundAtPosition__GameAudios__Vector3(GeneratedNetworkCode._Read_GameAudios(reader), reader.ReadVector3());
		}
	}

	static NetworkSoundPlayer()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSoundPlayer), "System.Void NetworkSoundPlayer::CmdPlaySoundAtPosition(GameAudios,UnityEngine.Vector3)", InvokeUserCode_CmdPlaySoundAtPosition__GameAudios__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSoundPlayer), "System.Void NetworkSoundPlayer::RpcPlaySoundAtPosition(GameAudios,UnityEngine.Vector3)", InvokeUserCode_RpcPlaySoundAtPosition__GameAudios__Vector3);
	}
}
