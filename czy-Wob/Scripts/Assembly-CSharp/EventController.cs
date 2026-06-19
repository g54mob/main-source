using UnityEngine;

public class EventController : MonoBehaviour
{
	public GameObject dogSpawnParticles;

	public SaveableDogGene givenEntireDogDogGene;

	public TextAsset givenEntireDogEventConvo;

	public SaveableDogProfile givenEntireDogDogProfile;

	private bool hasShownWarning;

	private float internalEventTimer;

	private float eventTriggerMin = 5f;

	private float eventTriggerMax = 10f;

	private float eventTriggerNext;

	private InGameEvent currentlyActiveEvent;

	private SceneManagerBase sceneRef;

	private void Start()
	{
		sceneRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
	}

	private void Update()
	{
		TickTimer();
		UpdateCurrentEvent();
	}

	public bool HasShownWarning()
	{
		return hasShownWarning;
	}

	public void SetHasShownWarning()
	{
		hasShownWarning = true;
	}

	public void RunEvent(GameEvent newEvent)
	{
		InGameEvent inGameEvent = null;
		if (newEvent == GameEvent.TOO_MANY_EGGS)
		{
			inGameEvent = new TooManyEggsEvent();
		}
		else
		{
			Debug.LogError("No implementation for event: " + newEvent);
		}
		if (inGameEvent != null)
		{
			inGameEvent.RunEvent(this);
			currentlyActiveEvent = inGameEvent;
		}
	}

	private void TickTimer()
	{
		if (!TutorialController.IsTutorialActive() && sceneRef.GetGameMode() == GameMode.HOME)
		{
			if (eventTriggerNext <= 0f)
			{
				ResetEventTrigger();
			}
			internalEventTimer += Time.deltaTime;
			if (internalEventTimer >= eventTriggerNext * 60f)
			{
				TriggerRandomEvent();
			}
		}
	}

	private void UpdateCurrentEvent()
	{
		if (currentlyActiveEvent != null)
		{
			currentlyActiveEvent.Update();
		}
	}

	private void TriggerRandomEvent()
	{
		ResetEventTrigger();
	}

	private void ResetEventTrigger()
	{
		internalEventTimer = 0f;
		eventTriggerNext = Random.Range(eventTriggerMin, eventTriggerMax);
	}
}
