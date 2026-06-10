using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using NaughtyAttributes;
using UnityEngine;

public class TelephoneController : MonoBehaviour
{
	public enum CallState
	{
		dialing = 0,
		denied = 1,
		ringing = 2,
		started = 3,
		ended = 4
	}

	public enum CallType
	{
		dds = 0,
		audioEvent = 1,
		player = 2,
		fakeOutbound = 3
	}

	[Serializable]
	public class CallSource
	{
		public CallType callType;

		public string dds;

		public string audio;

		public string dialog;

		public int job;

		public InteractionController.ConversationType convoType;

		[NonSerialized]
		public AudioEvent audioEvent;

		[NonSerialized]
		public DialogPreset dialogGreeting;

		public CallSource(CallType newType, string newDDS)
		{
		}

		public CallSource(CallType newType, AudioEvent newAudioEvent)
		{
		}

		public CallSource(CallType newType, DialogPreset newGreeting, InteractionController.ConversationType newConvoType = InteractionController.ConversationType.normal)
		{
		}

		public CallSource(CallType newType, DialogPreset newGreeting, SideJob newJob, InteractionController.ConversationType newConvoType = InteractionController.ConversationType.normal)
		{
		}
	}

	[Serializable]
	public class PhoneCall
	{
		public int from;

		public int to;

		public float time;

		public int caller;

		public int receiver;

		public int intendedReceiver;

		public CallSource source;

		public CallState previousSate;

		public CallState state;

		public float ringTime;

		public bool specRecevier;

		public float dialingTimer;

		public float ringDelay;

		[NonSerialized]
		public Telephone fromNS;

		[NonSerialized]
		public Telephone toNS;

		[NonSerialized]
		public Human callerNS;

		[NonSerialized]
		public Human recevierNS;

		[NonSerialized]
		public Human intendedReceiverNS;

		[NonSerialized]
		public AudioController.LoopingSoundInfo lineRingingLoop;

		[NonSerialized]
		public AudioController.LoopingSoundInfo lineActiveLoopCaller;

		[NonSerialized]
		public AudioController.LoopingSoundInfo lineActiveLoopReceiver;

		[NonSerialized]
		public EventInstance callAudioInstance;

		[NonSerialized]
		public EventInstance connecting;

		[NonSerialized]
		public EventInstance hangUpCaller;

		[NonSerialized]
		public EventInstance hangUpReciever;

		public PhoneCall(Telephone newFrom, Telephone newTo, float newTime, Human newCaller, Human newIntendedReceiver, CallSource newCallSource, float newMaxRingTime = 0.1f, bool newSpecificRecevier = false)
		{
		}

		public void SetCallState(CallState newState)
		{
		}

		public void EndCall()
		{
		}

		public void SetupNonSerializedData()
		{
		}
	}

	public delegate void PlayerCall();

	[Header("Telecoms")]
	public List<PhoneCall> activeCalls;

	private float gameTimeLastLoop;

	public Dictionary<Interactable, EventInstance> engagedEvents;

	public Dictionary<int, CallSource> fakeTelephoneDictionary;

	[Header("Debug")]
	public int debugNumber;

	private static TelephoneController _instance;

	public static TelephoneController Instance => null;

	public event PlayerCall OnPlayerCall
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

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public PhoneCall CreateNewCall(int from, int to, Human caller, Human intendedReceiver, CallSource callSource, float maxRingTime = 0.1f, bool specificRecevier = false)
	{
		return null;
	}

	public PhoneCall CreateNewCall(Telephone from, Telephone to, Human caller, Human intendedReceiver, CallSource callSource, float maxRingTime = 0.1f, bool specificRecevier = false)
	{
		return null;
	}

	public void OnPlayerCalls()
	{
	}

	public void AddFakeNumber(int number, CallSource source)
	{
	}

	public void RemoveFakeNumber(int number)
	{
	}

	public void AddActiveCall(PhoneCall newCall)
	{
	}

	public void RemoveActiveCall(PhoneCall newCall)
	{
	}

	private void Update()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void FindTelephoneByNumber()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void FindTelephonesAtPlayerLocation()
	{
	}
}
