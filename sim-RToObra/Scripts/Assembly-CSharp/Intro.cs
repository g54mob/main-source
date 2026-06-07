using System;
using UnityEngine;

public class Intro : MonoBehaviour
{
	private enum State
	{
		Notice = 0,
		Black = 1,
		Dispatch = 2,
		Dialog = 3
	}

	public Dialog dialog;

	public GameObject canvasGo;

	public GameObject noticeGo;

	public GameObject dispatchGo;

	public AudioClip audioClipM;

	public AudioClip audioClipF;

	private Stater<State> stater;

	private static bool playerFemale = DateTime.Now.Second % 2 < 1;

	private void Start()
	{
		playerFemale = !playerFemale;
		SaveData.it.general.playerFemale = playerFemale;
		stater = new Stater<State>("Intro");
		stater.AddState(State.Notice).AddFunc(StaterFunc.ENTER(delegate
		{
			SetPage(noticeGo);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (stater.stateTime > 30f || CheckButton(1f))
			{
				stater.Go(State.Black);
			}
		}));
		stater.AddState(State.Black).AddFunc(StaterFunc.ENTER(delegate
		{
			SetPage(null);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (stater.stateTime > 2f || CheckButton(0.01f))
			{
				stater.Go(State.Dispatch);
			}
		}));
		stater.AddState(State.Dispatch).AddFunc(StaterFunc.ENTER(delegate
		{
			SetPage(dispatchGo);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (stater.stateTime > 30f || CheckButton(1f))
			{
				stater.Go(State.Dialog);
			}
		}));
		stater.AddState(State.Dialog).AddFunc(StaterFunc.ENTER(delegate
		{
			SetPage(null);
			dialog.Play("intro", new Dialog.Extra((!SaveData.it.general.playerFemale) ? audioClipM : audioClipF));
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!dialog.isPlaying)
			{
				Game.LoadStartingShip();
			}
		}));
		stater.Go(State.Notice);
		LocalizedUi.ApplyLocalization(canvasGo);
	}

	private bool CheckButton(float fromStateTime)
	{
		return stater.stateTime > fromStateTime && RInput.GetButtonDown(17);
	}

	private void Update()
	{
		stater.Step(Clock.active.deltaTime);
		if (DebugMenu.WantSkip())
		{
			if (dialog.isPlaying)
			{
				dialog.Stop();
			}
			Game.LoadStartingShip();
		}
	}

	private void SetPage(GameObject go)
	{
		canvasGo.gameObject.SetActive(go != null);
		noticeGo.gameObject.SetActive(go == noticeGo);
		dispatchGo.gameObject.SetActive(go == dispatchGo);
	}
}
