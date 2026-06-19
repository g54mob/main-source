using System.Collections.Generic;
using UnityEngine;

public class HowlBehavior : MonoBehaviour
{
	public delegate void HowlFinishedCallback();

	private HowlFinishedCallback currentCallback;

	private List<GameObject> nearbyDogs = new List<GameObject>();

	private float wakeupChance = 0.01f;

	private float behaviorTimer;

	private bool isHowling;

	private DogNoises dogNoisesRef;

	private FaceController faceRef;

	private MouthController mouthControllerRef;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		dogNoisesRef = GetComponent<DogNoises>();
		faceRef = GetComponent<FaceController>();
		mouthControllerRef = GetComponent<MouthController>();
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void Update()
	{
		if (isHowling)
		{
			CheckDogInterruption();
			CheckHowlFinished();
		}
	}

	private void CheckDogInterruption()
	{
		for (int i = 0; i < nearbyDogs.Count; i++)
		{
			if (Random.value <= wakeupChance && !(nearbyDogs[i] == null))
			{
				DogBehaviorBase currentBehavior = nearbyDogs[i].GetComponent<DogAI>().GetCurrentBehavior();
				if (currentBehavior != null)
				{
					currentBehavior.HandleLoudNoise(base.gameObject);
				}
			}
		}
	}

	public void RequestHowl(HowlFinishedCallback callback = null)
	{
		if (isHowling)
		{
			Debug.LogError("Attempting to howl but we're already howling.");
			return;
		}
		currentCallback = callback;
		StartHowling();
	}

	public void RequestStop()
	{
		if (isHowling)
		{
			StopHowling();
		}
	}

	private void StartHowling()
	{
		isHowling = true;
		mouthControllerRef.DropObject();
		dogRegRef.GetNearbyDogList(base.gameObject, ref nearbyDogs);
		dogNoisesRef.RequestHowl();
		behaviorTimer = dogNoisesRef.GetHowlTimer();
		faceRef.RequestEmote(HeadEmote.HOWL, behaviorTimer);
	}

	private void StopHowling()
	{
		isHowling = false;
		nearbyDogs.Clear();
	}

	private void CheckHowlFinished()
	{
		if (currentCallback != null)
		{
			behaviorTimer -= Time.deltaTime;
			if (!dogNoisesRef.IsVocalizationPlaying(dogNoisesRef.GetHowlID()) && behaviorTimer <= 0f)
			{
				currentCallback?.Invoke();
			}
		}
	}
}
