using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Tools;

public static class TimerHelper
{
	public static Timer RegisterSecs(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0, bool isOnlineTimer = false, bool canPause = true)
	{
		bool useRealTime2 = default(bool);
		MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
		int repeat2 = default(int);
		TimerType type = default(TimerType);
		IntPtr intPtr = default(IntPtr);
		bool canPause2 = default(bool);
		return Timers.Register(duration, onComplete, onUpdate, isLooped, useRealTime2, autoDestroyOwner2, repeat2, type, (byte)(nint)intPtr != 0, canPause2);
	}

	public static Timer RegisterMillis(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0, bool isOnlineTimer = false)
	{
		float duration2 = duration * 0.001f;
		bool useRealTime2 = default(bool);
		MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
		int repeat2 = default(int);
		TimerType type = default(TimerType);
		bool isOnlineTimer2 = default(bool);
		bool canPause = default(bool);
		return Timers.Register(duration2, onComplete, onUpdate, isLooped, useRealTime2, autoDestroyOwner2, repeat2, type, isOnlineTimer2, canPause);
	}

	public static Timer RegisterSecsUI(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0)
	{
		bool isLooped2 = default(bool);
		bool usesRealTime = default(bool);
		MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
		int repeat2 = default(int);
		bool canPause = default(bool);
		Timer result = new Timer(duration, onComplete, onUpdate, isLooped2, usesRealTime, autoDestroyOwner2, repeat2, isLooped, canPause);
		TimerManagerUI managerUI = Timers._managerUI;
		if ((object)Timers._managerUI != null && ((TimerManager)managerUI)._timersToAdd != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
			return result;
		}
		return (Timer)(object)new NullReferenceException();
	}

	public static Timer RegisterMillisUI(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0)
	{
		float duration2 = duration * 0.001f;
		bool isLooped2 = default(bool);
		bool usesRealTime = default(bool);
		MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
		int repeat2 = default(int);
		bool canPause = default(bool);
		Timer result = new Timer(duration2, onComplete, onUpdate, isLooped2, usesRealTime, autoDestroyOwner2, repeat2, isLooped, canPause);
		TimerManagerUI managerUI = Timers._managerUI;
		if ((object)Timers._managerUI != null && ((TimerManager)managerUI)._timersToAdd != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
			return result;
		}
		return (Timer)(object)new NullReferenceException();
	}

	public static Timer RegisterSecsAutomation(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0)
	{
		bool isLooped2 = default(bool);
		bool usesRealTime = default(bool);
		MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
		int repeat2 = default(int);
		bool canPause = default(bool);
		Timer result = new Timer(duration, onComplete, onUpdate, isLooped2, usesRealTime, autoDestroyOwner2, repeat2, isLooped, canPause);
		TimerManagerAutomation managerAutomation = Timers._managerAutomation;
		if ((object)Timers._managerAutomation != null && ((TimerManager)managerAutomation)._timersToAdd != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
			return result;
		}
		return (Timer)(object)new NullReferenceException();
	}

	public static Timer RegisterMillisAutomation(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0)
	{
		float duration2 = duration * 0.001f;
		bool isLooped2 = default(bool);
		bool usesRealTime = default(bool);
		MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
		int repeat2 = default(int);
		bool canPause = default(bool);
		Timer result = new Timer(duration2, onComplete, onUpdate, isLooped2, usesRealTime, autoDestroyOwner2, repeat2, isLooped, canPause);
		TimerManagerAutomation managerAutomation = Timers._managerAutomation;
		if ((object)Timers._managerAutomation != null && ((TimerManager)managerAutomation)._timersToAdd != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
			return result;
		}
		return (Timer)(object)new NullReferenceException();
	}
}
