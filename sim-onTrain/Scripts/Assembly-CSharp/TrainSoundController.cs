using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class TrainSoundController : NetworkBehaviour
{
	private enum TrainSoundState
	{
		Off = 0,
		Idle = 1,
		SlowMoving = 2,
		FastMoving = 3
	}

	[Header("References")]
	[SerializeField]
	private TrainController trainController;

	[Header("Audio Clips")]
	[SerializeField]
	private AudioClip idleLoopClip;

	[SerializeField]
	private AudioClip slowLoopClip;

	[SerializeField]
	private AudioClip normalLoopClip;

	[SerializeField]
	private AudioClip steamReleaseClip;

	[SerializeField]
	private AudioClip brakeClip;

	[SerializeField]
	private AudioClip whistleClip;

	[SerializeField]
	private AudioClip fireLoopClip;

	[Header("Audio Sources")]
	[SerializeField]
	private AudioSource engineLoopSource;

	[SerializeField]
	private AudioSource oneShotSource;

	[SerializeField]
	private AudioSource brakeSource;

	[SerializeField]
	private AudioSource fireLoopSource;

	[Header("Settings")]
	[SerializeField]
	private float slowSpeedThreshold = 0.3f;

	[SerializeField]
	private float minPitch = 0.8f;

	[SerializeField]
	private float maxPitch = 1.2f;

	[SerializeField]
	private float crossfadeDuration = 0.5f;

	[Tooltip("Hız 0.3 altına düşünce fade out süresi")]
	[SerializeField]
	private float brakeFadeDuration = 1f;

	[Header("Volume Settings")]
	[SerializeField]
	private float idleVolume = 0.5f;

	[SerializeField]
	private float movingVolume = 0.7f;

	[SerializeField]
	private float brakeVolume = 0.8f;

	[SerializeField]
	private float whistleVolume = 1f;

	[SerializeField]
	private float releaseVolume = 0.6f;

	[SerializeField]
	private float fireVolume = 0.5f;

	private TrainSoundState currentState;

	private bool hasPlayedRelease;

	private bool wasEngineRunning;

	private float targetVolume;

	private bool isBrakeSoundPlaying;

	private float brakeStartSpeed;

	private void Start()
	{
		if (trainController == null)
		{
			trainController = GetComponentInParent<TrainController>();
		}
		SetupAudioSources();
	}

	private void SetupAudioSources()
	{
		if (engineLoopSource == null)
		{
			GameObject gameObject = new GameObject("EngineLoopSource");
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.localPosition = Vector3.zero;
			engineLoopSource = gameObject.AddComponent<AudioSource>();
			engineLoopSource.loop = true;
			engineLoopSource.playOnAwake = false;
			engineLoopSource.spatialBlend = 1f;
			engineLoopSource.minDistance = 5f;
			engineLoopSource.maxDistance = 50f;
		}
		if (oneShotSource == null)
		{
			GameObject gameObject2 = new GameObject("OneShotSource");
			gameObject2.transform.SetParent(base.transform);
			gameObject2.transform.localPosition = Vector3.zero;
			oneShotSource = gameObject2.AddComponent<AudioSource>();
			oneShotSource.loop = false;
			oneShotSource.playOnAwake = false;
			oneShotSource.spatialBlend = 1f;
			oneShotSource.minDistance = 5f;
			oneShotSource.maxDistance = 100f;
		}
		if (brakeSource == null)
		{
			GameObject gameObject3 = new GameObject("BrakeSource");
			gameObject3.transform.SetParent(base.transform);
			gameObject3.transform.localPosition = Vector3.zero;
			brakeSource = gameObject3.AddComponent<AudioSource>();
			brakeSource.loop = false;
			brakeSource.playOnAwake = false;
			brakeSource.spatialBlend = 1f;
			brakeSource.minDistance = 5f;
			brakeSource.maxDistance = 100f;
		}
		if (fireLoopSource == null)
		{
			GameObject gameObject4 = new GameObject("FireLoopSource");
			gameObject4.transform.SetParent(base.transform);
			gameObject4.transform.localPosition = Vector3.zero;
			fireLoopSource = gameObject4.AddComponent<AudioSource>();
			fireLoopSource.loop = true;
			fireLoopSource.playOnAwake = false;
			fireLoopSource.spatialBlend = 1f;
			fireLoopSource.minDistance = 3f;
			fireLoopSource.maxDistance = 30f;
		}
	}

	private void Update()
	{
		if (!(trainController == null))
		{
			UpdateSoundState();
			UpdateEnginePitch();
			UpdateBrakeSound();
		}
	}

	private void UpdateBrakeSound()
	{
		if (isBrakeSoundPlaying && !(brakeSource == null))
		{
			float currentSpeed = trainController.GetCurrentSpeed();
			if (currentSpeed < 0.05f)
			{
				StopBrakeSound();
			}
			else if (brakeStartSpeed > 0.1f)
			{
				float num = Mathf.Clamp01(currentSpeed / brakeStartSpeed);
				float target = brakeVolume * num;
				brakeSource.volume = Mathf.MoveTowards(brakeSource.volume, target, Time.deltaTime * 2f);
			}
		}
	}

	private void StopBrakeSound()
	{
		if (brakeSource != null)
		{
			brakeSource.Stop();
			brakeSource.loop = false;
		}
		isBrakeSoundPlaying = false;
		brakeStartSpeed = 0f;
	}

	public void RequestWhistle()
	{
		if (base.isServer)
		{
			RpcPlayWhistle();
		}
		else
		{
			CmdPlayWhistle();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdPlayWhistle()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TrainSoundController::CmdPlayWhistle()", -1821993300, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayWhistle()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TrainSoundController::RpcPlayWhistle()", -156824607, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void RequestBrake()
	{
		if (base.isServer)
		{
			RpcPlayBrake();
		}
		else
		{
			CmdPlayBrake();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdPlayBrake()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TrainSoundController::CmdPlayBrake()", -497157499, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayBrake()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TrainSoundController::RpcPlayBrake()", -499894022, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayRelease()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TrainSoundController::RpcPlayRelease()", 1601413974, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void UpdateSoundState()
	{
		bool flag = trainController.IsEngineRunning();
		float gasValue = trainController.GetGasValue();
		float currentSpeed = trainController.GetCurrentSpeed();
		float maxSpeed = trainController.maxSpeed;
		float num = ((maxSpeed > 0f) ? (currentSpeed / maxSpeed) : 0f);
		if (base.isServer && flag && gasValue >= 0.1f && !wasEngineRunning && !hasPlayedRelease)
		{
			RpcPlayRelease();
			hasPlayedRelease = true;
		}
		if (!flag && wasEngineRunning)
		{
			hasPlayedRelease = false;
		}
		UpdateFireSound(flag && gasValue >= 0.1f);
		wasEngineRunning = flag && gasValue >= 0.1f;
		TrainSoundState trainSoundState = TrainSoundState.Off;
		if (flag && gasValue >= 0.1f)
		{
			trainSoundState = ((currentSpeed < 0.1f) ? TrainSoundState.Idle : ((!(num < slowSpeedThreshold)) ? TrainSoundState.FastMoving : TrainSoundState.SlowMoving));
		}
		if (trainSoundState != currentState)
		{
			TransitionToState(trainSoundState);
			currentState = trainSoundState;
		}
		if (engineLoopSource != null && engineLoopSource.isPlaying)
		{
			engineLoopSource.volume = Mathf.MoveTowards(engineLoopSource.volume, targetVolume, Time.deltaTime / crossfadeDuration);
		}
	}

	private void TransitionToState(TrainSoundState newState)
	{
		AudioClip audioClip = null;
		float num = 0f;
		switch (newState)
		{
		case TrainSoundState.Off:
			if (engineLoopSource != null && engineLoopSource.isPlaying)
			{
				engineLoopSource.Stop();
			}
			return;
		case TrainSoundState.Idle:
			audioClip = idleLoopClip;
			num = idleVolume;
			break;
		case TrainSoundState.SlowMoving:
			audioClip = slowLoopClip;
			num = movingVolume;
			break;
		case TrainSoundState.FastMoving:
			audioClip = normalLoopClip;
			num = movingVolume;
			break;
		}
		targetVolume = num;
		if (engineLoopSource != null && audioClip != null && engineLoopSource.clip != audioClip)
		{
			engineLoopSource.clip = audioClip;
			engineLoopSource.volume = 0f;
			engineLoopSource.Play();
		}
	}

	private void UpdateEnginePitch()
	{
		if (!(engineLoopSource == null) && engineLoopSource.isPlaying && !(trainController == null))
		{
			float currentSpeed = trainController.GetCurrentSpeed();
			float maxSpeed = trainController.maxSpeed;
			float t = ((maxSpeed > 0f) ? Mathf.Clamp01(currentSpeed / maxSpeed) : 0f);
			float target = Mathf.Lerp(minPitch, maxPitch, t);
			engineLoopSource.pitch = Mathf.MoveTowards(engineLoopSource.pitch, target, Time.deltaTime * 2f);
		}
	}

	private void PlayWhistleLocal()
	{
		if (oneShotSource != null && whistleClip != null)
		{
			oneShotSource.PlayOneShot(whistleClip, whistleVolume);
		}
	}

	private void PlayBrakeLocal()
	{
		if (!(brakeSource == null) && !(brakeClip == null) && !(trainController == null))
		{
			StopBrakeSound();
			brakeStartSpeed = trainController.GetCurrentSpeed();
			brakeSource.clip = brakeClip;
			brakeSource.volume = brakeVolume;
			brakeSource.loop = true;
			brakeSource.Play();
			isBrakeSoundPlaying = true;
		}
	}

	private void PlayReleaseLocal()
	{
		if (oneShotSource != null && steamReleaseClip != null)
		{
			oneShotSource.PlayOneShot(steamReleaseClip, releaseVolume);
		}
	}

	private void UpdateFireSound(bool shouldPlay)
	{
		if (!(fireLoopSource == null) && !(fireLoopClip == null))
		{
			if (shouldPlay && !fireLoopSource.isPlaying)
			{
				fireLoopSource.clip = fireLoopClip;
				fireLoopSource.volume = fireVolume;
				fireLoopSource.Play();
			}
			else if (!shouldPlay && fireLoopSource.isPlaying)
			{
				fireLoopSource.Stop();
			}
		}
	}

	public void OnBrakeActivated()
	{
		RequestBrake();
	}

	public void OnTrainStopped()
	{
		hasPlayedRelease = false;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdPlayWhistle()
	{
		RpcPlayWhistle();
	}

	protected static void InvokeUserCode_CmdPlayWhistle(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayWhistle called on client.");
		}
		else
		{
			((TrainSoundController)obj).UserCode_CmdPlayWhistle();
		}
	}

	protected void UserCode_RpcPlayWhistle()
	{
		PlayWhistleLocal();
	}

	protected static void InvokeUserCode_RpcPlayWhistle(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayWhistle called on server.");
		}
		else
		{
			((TrainSoundController)obj).UserCode_RpcPlayWhistle();
		}
	}

	protected void UserCode_CmdPlayBrake()
	{
		RpcPlayBrake();
	}

	protected static void InvokeUserCode_CmdPlayBrake(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayBrake called on client.");
		}
		else
		{
			((TrainSoundController)obj).UserCode_CmdPlayBrake();
		}
	}

	protected void UserCode_RpcPlayBrake()
	{
		PlayBrakeLocal();
	}

	protected static void InvokeUserCode_RpcPlayBrake(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayBrake called on server.");
		}
		else
		{
			((TrainSoundController)obj).UserCode_RpcPlayBrake();
		}
	}

	protected void UserCode_RpcPlayRelease()
	{
		PlayReleaseLocal();
	}

	protected static void InvokeUserCode_RpcPlayRelease(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayRelease called on server.");
		}
		else
		{
			((TrainSoundController)obj).UserCode_RpcPlayRelease();
		}
	}

	static TrainSoundController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TrainSoundController), "System.Void TrainSoundController::CmdPlayWhistle()", InvokeUserCode_CmdPlayWhistle, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainSoundController), "System.Void TrainSoundController::CmdPlayBrake()", InvokeUserCode_CmdPlayBrake, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainSoundController), "System.Void TrainSoundController::RpcPlayWhistle()", InvokeUserCode_RpcPlayWhistle);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainSoundController), "System.Void TrainSoundController::RpcPlayBrake()", InvokeUserCode_RpcPlayBrake);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainSoundController), "System.Void TrainSoundController::RpcPlayRelease()", InvokeUserCode_RpcPlayRelease);
	}
}
