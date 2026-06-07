using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Wwise/AkAudioListener")]
[RequireComponent(typeof(AkGameObj))]
[DisallowMultipleComponent]
[DefaultExecutionOrder(-50)]
public class AkAudioListener : MonoBehaviour
{
	public class BaseListenerList
	{
		private readonly List<ulong> listenerIdList;

		private readonly List<AkAudioListener> listenerList;

		public List<AkAudioListener> ListenerList => null;

		public virtual bool Add(AkAudioListener listener)
		{
			return false;
		}

		public virtual bool Remove(AkAudioListener listener)
		{
			return false;
		}

		public ulong[] GetListenerIds()
		{
			return null;
		}
	}

	public class DefaultListenerList : BaseListenerList
	{
		public override bool Add(AkAudioListener listener)
		{
			return false;
		}

		public override bool Remove(AkAudioListener listener)
		{
			return false;
		}
	}

	private static readonly DefaultListenerList defaultListeners;

	private ulong akGameObjectID;

	private List<AkGameObj> EmittersToStartListeningTo;

	private List<AkGameObj> EmittersToStopListeningTo;

	public bool isDefaultListener;

	[SerializeField]
	public bool bOverrideScalingFactor;

	[SerializeField]
	private float scalingFactor;

	[SerializeField]
	public int listenerId;

	public float ScalingFactor
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static DefaultListenerList DefaultListeners => null;

	public void StartListeningToEmitter(AkGameObj emitter)
	{
	}

	public void StopListeningToEmitter(AkGameObj emitter)
	{
	}

	public void SetIsDefaultListener(bool isDefault)
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public ulong GetAkGameObjectID()
	{
		return 0uL;
	}

	public void Migrate14()
	{
	}
}
