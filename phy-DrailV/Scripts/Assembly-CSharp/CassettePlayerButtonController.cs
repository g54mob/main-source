using System;
using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

public class CassettePlayerButtonController : MonoBehaviour
{
	public GameObject play;

	public GameObject stop;

	public GameObject pause;

	public GameObject next;

	public GameObject previous;

	private ToggleSwitchBase playControl;

	private ToggleSwitchBase stopControl;

	private ToggleSwitchBase pauseControl;

	private ToggleSwitchBase nextControl;

	private ToggleSwitchBase previousControl;

	private Coroutine initCoro;

	private Dictionary<ToggleSwitchBase, Action> buttonHandlers = new Dictionary<ToggleSwitchBase, Action>();

	private HashSet<ToggleSwitchBase> ignore = new HashSet<ToggleSwitchBase>();

	public event Action PlayPressed;

	public event Action PausePressed;

	public event Action StopPressed;

	public event Action NextPressed;

	public event Action PreviousPressed;

	private void Awake()
	{
		initCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Initialize());
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isQuitting && initCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(initCoro);
		}
	}

	public bool IsPlayButtonPressed()
	{
		return false;
	}

	private IEnumerator Initialize()
	{
		yield return null;
		yield return WaitFor.EndOfFrame;
		playControl = play.GetComponent<ToggleSwitchBase>();
		playControl.Used += delegate
		{
			HandleButtonPress(playControl);
		};
		buttonHandlers[playControl] = PlayPressed_Fire;
		pauseControl = pause.GetComponent<ToggleSwitchBase>();
		pauseControl.Used += delegate
		{
			HandleButtonPress(pauseControl);
		};
		buttonHandlers[pauseControl] = PausePressed_Fire;
		stopControl = stop.GetComponent<ToggleSwitchBase>();
		stopControl.Used += delegate
		{
			HandleButtonPress(stopControl);
		};
		buttonHandlers[stopControl] = StopPressed_Fire;
		nextControl = next.GetComponent<ToggleSwitchBase>();
		nextControl.Used += delegate
		{
			HandleButtonPress(nextControl);
		};
		buttonHandlers[nextControl] = NextPressed_Fire;
		previousControl = previous.GetComponent<ToggleSwitchBase>();
		previousControl.Used += delegate
		{
			HandleButtonPress(previousControl);
		};
		buttonHandlers[previousControl] = PreviousPressed_Fire;
		initCoro = null;
	}

	private void HandleButtonPress(ToggleSwitchBase btn)
	{
		if (ignore.Contains(btn))
		{
			ignore.Remove(btn);
			return;
		}
		ignore.Add(btn);
		buttonHandlers[btn]();
	}

	private void PlayPressed_Fire()
	{
		this.PlayPressed?.Invoke();
	}

	private void StopPressed_Fire()
	{
		this.StopPressed?.Invoke();
	}

	private void NextPressed_Fire()
	{
		this.NextPressed?.Invoke();
	}

	private void PausePressed_Fire()
	{
		this.PausePressed?.Invoke();
	}

	private void PreviousPressed_Fire()
	{
		this.PreviousPressed?.Invoke();
	}

	public void ForcePressPlayExternal()
	{
		if (!(playControl == null))
		{
			playControl.Use();
		}
	}

	public void ForcePressStopExternal()
	{
		if (!(stopControl == null))
		{
			stopControl.Use();
		}
	}
}
