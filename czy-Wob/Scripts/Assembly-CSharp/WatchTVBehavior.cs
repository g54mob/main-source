using System.Collections;
using UnityEngine;

public class WatchTVBehavior : MonoBehaviour
{
	public delegate void WatchFinishedCallback();

	private InteractableTV currentTV;

	private float watchTimeMin = 15f;

	private float TVNotVisibleTimeBeforeInterruption = 1f;

	private float sitChanceDefault = 0.25f;

	private float sitChanceLayabout = 0.75f;

	private float sleepChanceLayabout = 0.25f;

	private bool sitRequested;

	private Coroutine currentWatchRoutine;

	private FaceController faceRef;

	private void Start()
	{
		faceRef = GetComponent<FaceController>();
	}

	public void RequestWatch(InteractableTV newTV, WatchFinishedCallback callback = null)
	{
		if (newTV == null)
		{
			callback?.Invoke();
			Debug.LogError("Attempting to watch TV but we're already doing so.");
		}
		else if (currentWatchRoutine != null)
		{
			callback?.Invoke();
			Debug.LogError("Attempting to watch TV but we're already doing so.");
		}
		else
		{
			currentTV = newTV;
			currentWatchRoutine = StartCoroutine(WatchRoutine(callback));
		}
	}

	public void RequestStop()
	{
		if (currentWatchRoutine != null)
		{
			StopCoroutine(currentWatchRoutine);
			currentWatchRoutine = null;
		}
		OnFinish();
	}

	private void OnFinish()
	{
		currentTV = null;
		GetComponent<FaceController>().StopFocus();
		if (sitRequested)
		{
			GetComponent<SitBehavior>().RequestStandUp();
		}
	}

	private IEnumerator WatchRoutine(WatchFinishedCallback callback)
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		SitBehavior component = GetComponent<SitBehavior>();
		DoggyBrain brainRef = GetComponent<DoggyBrain>();
		EnergyPersonalityType energyType = brainRef.GetPersonality().GetEnergyPersonality();
		float num = sitChanceDefault;
		if (energyType == EnergyPersonalityType.LAYABOUT)
		{
			num = sitChanceLayabout;
		}
		sitRequested = Random.value <= num;
		if (sitRequested)
		{
			component.RequestSit();
		}
		faceRef.FocusOnTarget(currentTV.GetFocusTransform());
		float timeWatched = 0f;
		float TVNotVisibleTime = 0f;
		while (timeWatched < watchTimeMin || brainRef.IsBored())
		{
			yield return frameWait;
			timeWatched += Time.deltaTime;
			if (currentTV == null || !currentTV.IsCurrentlyOn())
			{
				GetComponent<DogAI>().ForceInterruptBehavior();
				GetComponent<DogParticleController>().RequestSurpriseParticlesStart();
				yield break;
			}
			if (!CanSeeTV())
			{
				TVNotVisibleTime += Time.deltaTime;
				if (TVNotVisibleTime > TVNotVisibleTimeBeforeInterruption)
				{
					GetComponent<DogAI>().ForceInterruptBehavior();
					yield break;
				}
			}
			else
			{
				TVNotVisibleTime = 0f;
			}
		}
		OnFinish();
		currentWatchRoutine = null;
		callback?.Invoke();
		if (energyType == EnergyPersonalityType.LAYABOUT && (brainRef.IsTired() || Random.value <= sleepChanceLayabout))
		{
			TransitionToSleep();
		}
	}

	private bool CanSeeTV()
	{
		return faceRef.CanSeeFocusObject();
	}

	private void TransitionToSleep()
	{
		DogAI component = GetComponent<DogAI>();
		DistractionSleepImmediately newDistraction = new DistractionSleepImmediately(component, 1f);
		component.TryAddNewDistraction(newDistraction, useTimeSinceLastDistraction: false);
	}
}
