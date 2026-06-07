using System;
using UnityEngine;

public class SunMoonGuyHandler : MonoBehaviour
{
	[Header("Mouths")]
	[SerializeField]
	private GameObject mouth_Sun_Smile;

	[SerializeField]
	private GameObject mouth_Sun_Flat;

	[SerializeField]
	private GameObject mouth_Moon_Smile;

	[SerializeField]
	private GameObject mouth_Moon_Flat;

	[Header("Eye Handlers")]
	[SerializeField]
	private EyesHandler eyeHandler_Sun;

	[SerializeField]
	private EyesHandler eyeHandler_Moon;

	[Header("Misc.")]
	[SerializeField]
	private GameObject sunShines;

	[SerializeField]
	private GameObject[] sunShines_ClockHands;

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Combine(singleton.OnNightTime_Action, new Action(OnNightTimeSwitch));
		eyeHandler_Sun.ChangeEyeState(EyesHandler.EyeState.Open);
		eyeHandler_Moon.ChangeEyeState(EyesHandler.EyeState.Closed);
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(OnNightTimeSwitch));
	}

	private void Update()
	{
		_ = (bool)GameManager.Singleton;
	}

	private void FixedUpdate()
	{
		HandleSunShinesClockHands();
	}

	private void OnNightTimeSwitch()
	{
		sunShines.SetActive(value: false);
		mouth_Sun_Flat.SetActive(value: true);
		mouth_Sun_Smile.SetActive(value: false);
		mouth_Moon_Flat.SetActive(value: false);
		mouth_Moon_Smile.SetActive(value: true);
		eyeHandler_Sun.ChangeEyeState(EyesHandler.EyeState.Closed);
		eyeHandler_Moon.ChangeEyeState(EyesHandler.EyeState.Open);
	}

	private void HandleSunShinesClockHands()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			int num = Mathf.CeilToInt(GameManager.Singleton.roundTimer_Curr / PlayerStats.Singleton.roundTimerLength * (float)sunShines_ClockHands.Length);
			for (int i = 0; i < sunShines_ClockHands.Length; i++)
			{
				sunShines_ClockHands[i].SetActive(i < num);
			}
		}
	}
}
