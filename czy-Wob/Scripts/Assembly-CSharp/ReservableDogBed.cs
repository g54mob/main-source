using UnityEngine;
using UnityEngine.UI;

public class ReservableDogBed : ReservableObject
{
	public Image timerFill;

	public GameObject timerGUI;

	private float timerDelta;

	private bool behaviorRunning;

	private DoggyBrain currentBrain;

	private void OnDestroy()
	{
		OnSleepFinished();
	}

	protected override void UpdateBehavior()
	{
		base.UpdateBehavior();
		if (behaviorRunning)
		{
			UpdateTimer();
		}
	}

	protected override void EnableBehavior()
	{
		base.EnableBehavior();
		timerGUI.SetActive(value: false);
	}

	private void UpdateTimer()
	{
		timerFill.fillAmount = (currentBrain.GetCurrentEnergy() - (1f - timerDelta)) / timerDelta;
		if (timerFill.fillAmount >= 1f)
		{
			OnSleepFinished();
		}
	}

	protected override void MainObjectBehavior()
	{
		timerGUI.SetActive(value: true);
		timerFill.fillAmount = 0f;
		behaviorRunning = true;
		currentBrain = dogRegRef.GetDogFromID(currentUser.Value).GetComponent<DoggyBrain>();
		timerDelta = 1f - currentBrain.GetCurrentEnergy();
		UpdateTimer();
	}

	private void OnSleepFinished()
	{
		currentBrain = null;
		behaviorRunning = false;
		if (currentCallback != null)
		{
			currentCallback();
			currentCallback = null;
		}
		timerGUI.SetActive(value: false);
	}

	protected override void OnRelease()
	{
		base.OnRelease();
		currentBrain = null;
		behaviorRunning = false;
		timerGUI.SetActive(value: false);
	}
}
