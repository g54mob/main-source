using System;
using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("Wwise/AkEvent")]
[ExecuteInEditMode]
[RequireComponent(typeof(AkGameObj))]
public class AkEvent : AkDragDropTriggerHandler
{
	[Serializable]
	public class CallbackData
	{
		public CallbackFlags Flags;

		public string FunctionName;

		public GameObject GameObject;

		public void CallFunction(AkEventCallbackMsg eventCallbackMsg)
		{
		}
	}

	public AkActionOnEventType actionOnEventType;

	public AkCurveInterpolation curveInterpolation;

	public bool enableActionOnEvent;

	public Event data;

	private GameObject otherGameObject;

	public bool useCallbacks;

	public bool stopSoundOnDestroy;

	public List<CallbackData> Callbacks;

	public GameObject soundEmitterObject;

	public float transitionDuration;

	private AkEventCallbackMsg EventCallbackMsg;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("eventID")]
	private int eventIdInternal;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("valueGuid")]
	private byte[] valueGuidInternal;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("m_callbackData")]
	private AkEventCallbackData m_callbackDataInternal;

	protected override BaseType WwiseType => null;

	public uint playingId => 0u;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.2 and will be removed in a future release.")]
	public int eventID => 0;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public byte[] valueGuid => null;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public AkEventCallbackData m_callbackData => null;

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void Callback(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
	{
	}

	public override void HandleEvent(GameObject in_gameObject)
	{
	}

	protected new void OnDestroy()
	{
	}

	public void Stop(int _transitionDuration)
	{
	}

	public void Stop(int _transitionDuration, AkCurveInterpolation _curveInterpolation)
	{
	}
}
