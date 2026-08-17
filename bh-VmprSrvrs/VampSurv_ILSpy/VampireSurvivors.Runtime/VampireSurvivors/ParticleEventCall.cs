using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivors;

public class ParticleEventCall : MonoBehaviour
{
	public float EventTriggerTime = 5f;

	public UnityEvent onEventTriggered;

	private bool CallEventsOnParticleSystemStopped;

	public UnityEvent OnParticleSystemStoppedEvent;

	private ParticleSystem _particleSystem;

	private bool _eventCalled;

	private void Start()
	{
		//IL_017b: Expected O, but got I
		//IL_027b: Expected O, but got I
		//IL_01c0: Expected O, but got I4
		//IL_01cf: Expected O, but got I4
		//IL_0204: Expected O, but got I
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		ParticleSystem component = GetComponent<ParticleSystem>();
		_particleSystem = component;
		ParticleSystem particleSystem = _particleSystem;
		if ((object)_particleSystem == null || ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0)
		{
			Debug.LogError("ParticleEventCall script requires a ParticleSystem component on the same GameObject.");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v475 @ rax_v19 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v514 @ rax_v22 (should have been resolved before IL gen)");
			ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
			object obj3 = 0;
			nint num = 0;
			object obj4 = 0;
			while ((nint)obj4 < componentsInChildren.Length)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj5 == null)
					{
						MissingMethodException ex3 = new MissingMethodException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v719 @ rax_v30 (should have been resolved before IL gen)");
				obj3++;
				num = 3;
				obj4 = obj3;
			}
		}
		_eventCalled = false;
	}

	private void Update()
	{
		ParticleSystem particleSystem = _particleSystem;
		if ((object)_particleSystem == null || ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0 || !_particleSystem.isPlaying || _eventCalled)
		{
			return;
		}
		float time = _particleSystem.time;
		if (!(time < EventTriggerTime) && !_eventCalled)
		{
			if (onEventTriggered != null)
			{
				onEventTriggered.Invoke();
			}
			_eventCalled = true;
		}
	}

	private void CallEvents()
	{
		if (onEventTriggered != null)
		{
			onEventTriggered.Invoke();
		}
		_eventCalled = true;
	}

	public void RestartEventTimer()
	{
		_eventCalled = false;
	}

	private void OnParticleSystemStopped()
	{
		if (CallEventsOnParticleSystemStopped && onEventTriggered != null)
		{
			onEventTriggered.Invoke();
		}
		_eventCalled = false;
		if (OnParticleSystemStoppedEvent != null)
		{
			OnParticleSystemStoppedEvent.Invoke();
		}
	}

	private void PlayFX()
	{
		_particleSystem.Play(withChildren: true);
	}

	private void StopFX()
	{
		_particleSystem.Stop();
	}

	public ParticleEventCall()
	{
		UnityEvent unityEvent = (UnityEvent)new UnityEventBase();
		unityEvent.m_InvokeArray = null;
		((UnityEventBase)unityEvent)._002Ector();
		OnParticleSystemStoppedEvent = unityEvent;
	}
}
