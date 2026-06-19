using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReservableStable : ReservableObject
{
	public GameObject timerGUI;

	public Image timerFill;

	public float layEggsTimer = 10f;

	private float tutorialMod = 2f;

	private Coroutine currentEggsRoutine;

	private void OnDestroy()
	{
		if (currentEggsRoutine != null)
		{
			OnRoutineFinished();
		}
	}

	protected override void EnableBehavior()
	{
		base.EnableBehavior();
		timerGUI.SetActive(value: false);
	}

	protected override void MainObjectBehavior()
	{
		currentEggsRoutine = StartCoroutine(PrepareToLayEggsRoutine());
	}

	private IEnumerator PrepareToLayEggsRoutine()
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		timerGUI.SetActive(value: true);
		timerFill.fillAmount = 0f;
		float time = layEggsTimer;
		while (time >= 0f)
		{
			time = ((!inTutorialMode) ? (time - Time.deltaTime) : (time - Time.deltaTime * tutorialMod));
			yield return frameWait;
			timerFill.fillAmount = (layEggsTimer - time) / layEggsTimer;
		}
		OnRoutineFinished();
		currentEggsRoutine = null;
	}

	private void OnRoutineFinished()
	{
		if (currentEggsRoutine != null)
		{
			StopCoroutine(currentEggsRoutine);
			currentEggsRoutine = null;
		}
		currentCallback();
		currentCallback = null;
		timerGUI.SetActive(value: false);
	}

	protected override void OnRelease()
	{
		base.OnRelease();
		if (currentEggsRoutine != null)
		{
			StopCoroutine(currentEggsRoutine);
			currentEggsRoutine = null;
		}
		timerGUI.SetActive(value: false);
	}
}
