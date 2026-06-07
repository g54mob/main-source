using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Wwise/AkGameObj")]
[DisallowMultipleComponent]
[ExecuteInEditMode]
[DefaultExecutionOrder(-25)]
public class AkGameObj : MonoBehaviour
{
	[SerializeField]
	private AkGameObjListenerList m_listeners;

	public bool isEnvironmentAware;

	[SerializeField]
	private bool isStaticObject;

	private Collider m_Collider;

	private AkGameObjEnvironmentData m_envData;

	private AkGameObjPositionData m_posData;

	public bool usePositionOffsetData;

	public AkGameObjPositionOffsetData m_positionOffsetData;

	[SerializeField]
	private float scalingFactor;

	private bool isRegistered;

	[HideInInspector]
	[SerializeField]
	private AkGameObjPosOffsetData m_posOffsetData;

	private const int AK_NUM_LISTENERS = 8;

	[HideInInspector]
	[SerializeField]
	private int listenerMask;

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

	public bool IsUsingDefaultListeners => false;

	public List<AkAudioListener> ListenerList => null;

	public event EventHandler PositionChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public bool GameObjIsRegistered()
	{
		return false;
	}

	internal void AddListener(AkAudioListener listener)
	{
	}

	internal void RemoveListener(AkAudioListener listener)
	{
	}

	public AKRESULT Register()
	{
		return default(AKRESULT);
	}

	private void UnregisterGameObject()
	{
	}

	public AKRESULT Unregister()
	{
		return default(AKRESULT);
	}

	private void SetPosition()
	{
	}

	private void Awake()
	{
	}

	private void RegisterGameObject()
	{
	}

	private void CheckStaticStatus()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public virtual Vector3 GetPosition()
	{
		return default(Vector3);
	}

	public virtual Vector3 GetForward()
	{
		return default(Vector3);
	}

	public virtual Vector3 GetUpward()
	{
		return default(Vector3);
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}
}
