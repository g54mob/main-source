using System.Collections;
using Aggro.Core;
using UnityEngine;

public class ControllerNoticeUI : EntityBehaviourBase, IInputController
{
	public GameObject container;

	public GameObject clickCatch;

	private bool _continue;

	public EaseUI easeUI;

	private void Awake()
	{
		container.SetActive(value: false);
		clickCatch.SetActive(value: false);
		Object.DontDestroyOnLoad(base.gameObject);
	}

	public IEnumerator NoticeCo()
	{
		while (!AggroInputManager.enabled || FadeManager.instance.busy)
		{
			yield return null;
		}
		container.SetActive(value: true);
		clickCatch.SetActive(value: true);
		easeUI.transform.localScale = Vector3.zero;
		easeUI.EaseIn();
		AggroInputManager.PushController(this);
		_continue = false;
		while (!_continue)
		{
			yield return null;
			if (AggroInputManager.input.QuotaReport.Continue.WasPerformedThisFrame())
			{
				_continue = true;
			}
		}
		easeUI.EaseOut();
		yield return new WaitForSecondsRealtime(0.3f);
		AggroInputManager.RemoveController(this);
		container.SetActive(value: false);
		clickCatch.SetActive(value: false);
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.QuotaReport.Enable();
		AggroInputManager.EnableUIModule();
	}

	public void OnContinue()
	{
		_continue = true;
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.QuotaReport.Disable();
	}

	public void TestNotice()
	{
		ShowNotice();
	}

	public void ShowNotice()
	{
		if (!AggroInputManager.IsControllerInStack(this))
		{
			StartCoroutine(NoticeCo());
		}
	}
}
