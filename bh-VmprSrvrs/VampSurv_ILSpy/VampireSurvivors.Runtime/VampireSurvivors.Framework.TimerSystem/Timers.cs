using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.TimerSystem;

public class Timers
{
	protected static TimerManagerGame _managerGame;

	protected static TimerManagerUI _managerUI;

	protected static TimerManagerAutomation _managerAutomation;

	public static Timer Register(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0, TimerType type = TimerType.GAME, bool isOnlineTimer = false, bool canPause = true)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		bool isLooped2 = default(bool);
		bool usesRealTime = default(bool);
		MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
		int repeat2 = default(int);
		Timer timer = new Timer(duration, onComplete, onUpdate, isLooped2, usesRealTime, autoDestroyOwner2, repeat2, isLooped, canPause);
		object obj = default(object);
		bool flag = obj == null;
		TimerManagerAutomation timerManagerAutomation;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 != 1)
				{
					goto IL_00d7;
				}
				timerManagerAutomation = _managerAutomation;
			}
			else
			{
				timerManagerAutomation = (TimerManagerAutomation)(object)_managerUI;
			}
		}
		else
		{
			if (PauseSystem._paused)
			{
				if (timer == null)
				{
					goto IL_00dc;
				}
				timer.Pause();
			}
			if ((object)_managerGame == null)
			{
				goto IL_00dc;
			}
			((GameMonoBehaviour)_managerGame).HandlePauseResume();
			timerManagerAutomation = (TimerManagerAutomation)(object)_managerGame;
		}
		if ((object)timerManagerAutomation != null && ((TimerManager)timerManagerAutomation)._timersToAdd != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
			goto IL_00d7;
		}
		goto IL_00dc;
		IL_00dc:
		return (Timer)(object)new NullReferenceException();
		IL_00d7:
		return timer;
	}

	public static void InitManagers()
	{
		TimerManagerGame managerGame = _managerGame;
		if ((object)_managerGame == null || ((UnityEngine.Object)managerGame).m_CachedPtr == (IntPtr)0)
		{
			TimerManagerGame timerManagerGame = UnityEngine.Object.FindObjectOfType<TimerManagerGame>();
			if ((object)timerManagerGame != null && ((UnityEngine.Object)timerManagerGame).m_CachedPtr != (IntPtr)0)
			{
				_managerGame = timerManagerGame;
			}
			else
			{
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, (string)null);
				((UnityEngine.Object)gameObject).SetName("TimerManagerGame");
				TimerManagerGame managerGame2 = gameObject.AddComponent<TimerManagerGame>();
				_managerGame = managerGame2;
			}
		}
		TimerManagerUI managerUI = _managerUI;
		if ((object)_managerUI == null || ((UnityEngine.Object)managerUI).m_CachedPtr == (IntPtr)0)
		{
			TimerManagerUI timerManagerUI = UnityEngine.Object.FindObjectOfType<TimerManagerUI>();
			if ((object)timerManagerUI != null && ((UnityEngine.Object)timerManagerUI).m_CachedPtr != (IntPtr)0)
			{
				_managerUI = timerManagerUI;
			}
			else
			{
				GameObject gameObject2 = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject2, (string)null);
				((UnityEngine.Object)gameObject2).SetName("TimerManagerUI");
				TimerManagerUI managerUI2 = gameObject2.AddComponent<TimerManagerUI>();
				_managerUI = managerUI2;
			}
		}
		TimerManagerAutomation managerAutomation = _managerAutomation;
		if ((object)_managerAutomation == null || ((UnityEngine.Object)managerAutomation).m_CachedPtr == (IntPtr)0)
		{
			TimerManagerAutomation timerManagerAutomation = UnityEngine.Object.FindObjectOfType<TimerManagerAutomation>();
			if ((object)timerManagerAutomation != null && ((UnityEngine.Object)timerManagerAutomation).m_CachedPtr != (IntPtr)0)
			{
				_managerAutomation = timerManagerAutomation;
				return;
			}
			GameObject gameObject3 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject3, (string)null);
			((UnityEngine.Object)gameObject3).SetName("TimerManagerAutomation");
			TimerManagerAutomation managerAutomation2 = gameObject3.AddComponent<TimerManagerAutomation>();
			_managerAutomation = managerAutomation2;
		}
	}

	public static void Cancel(Timer timer)
	{
		timer?.Cancel();
	}

	public static void Pause(Timer timer)
	{
		timer?.Pause();
	}

	public static void Resume(Timer timer)
	{
		timer?.Resume();
	}

	public static void CancelAllRegisteredTimers()
	{
		TimerManagerGame managerGame = _managerGame;
		if ((object)_managerGame != null && ((UnityEngine.Object)managerGame).m_CachedPtr != (IntPtr)0)
		{
			_managerGame.CancelAllTimers();
		}
		TimerManagerUI managerUI = _managerUI;
		if ((object)_managerUI != null && ((UnityEngine.Object)managerUI).m_CachedPtr != (IntPtr)0)
		{
			_managerUI.CancelAllTimers();
		}
	}

	public static void PauseAllRegisteredTimers()
	{
		TimerManagerGame managerGame = _managerGame;
		if ((object)_managerGame != null && ((UnityEngine.Object)managerGame).m_CachedPtr != (IntPtr)0)
		{
			_managerGame.PauseAllTimers();
		}
		TimerManagerUI managerUI = _managerUI;
		if ((object)_managerUI != null && ((UnityEngine.Object)managerUI).m_CachedPtr != (IntPtr)0)
		{
			_managerUI.PauseAllTimers();
		}
	}

	public static void ResumeAllRegisteredTimers()
	{
		TimerManagerGame managerGame = _managerGame;
		if ((object)_managerGame != null && ((UnityEngine.Object)managerGame).m_CachedPtr != (IntPtr)0)
		{
			_managerGame.ResumeAllTimers();
		}
		TimerManagerUI managerUI = _managerUI;
		if ((object)_managerUI != null && ((UnityEngine.Object)managerUI).m_CachedPtr != (IntPtr)0)
		{
			_managerUI.ResumeAllTimers();
		}
	}
}
