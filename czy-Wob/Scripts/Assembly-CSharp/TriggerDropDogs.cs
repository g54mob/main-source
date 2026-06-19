using System.Collections.Generic;
using UnityEngine;

public class TriggerDropDogs : TriggerBase
{
	private enum StatePos
	{
		waiting = 0,
		openDoors = 1,
		lowerPipe = 2,
		dropDogs = 3,
		raisePipe = 4,
		afterDrop = 5,
		finished = 6
	}

	public string pipeName;

	public string landingZoneName;

	public string doorLeftName = "DoorLeft";

	public string doorRightName = "DoorRight";

	public string dogRegistrationName = "DogRegistration";

	public float doorOpenDist = 20f;

	public float doorOpenTime = 1f;

	public int numDogs = 10;

	public float timeBetweenDogs = 0.25f;

	public Vector3 dogSpawnPos;

	public float pipeYStart = 40f;

	public float pipeYEnd = 25f;

	public float pipeDownDuration = 2f;

	public float pipeUpDuration = 1f;

	private StatePos currentState;

	private int currentDogNum;

	private float currentWaitTime;

	private GameObject dogRef;

	private GameObject pipeRef;

	private GameObject doorLeftRef;

	private GameObject doorRightRef;

	private GameObject landingZoneRef;

	private Inchworm inchworm;

	private void Awake()
	{
		pipeRef = GameObject.Find(pipeName);
		doorLeftRef = GameObject.Find(doorLeftName);
		doorRightRef = GameObject.Find(doorRightName);
		landingZoneRef = GameObject.Find(landingZoneName);
		inchworm = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		dogRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).globalDogprefab;
	}

	private void Update()
	{
		switch (currentState)
		{
		case StatePos.dropDogs:
			DropDogs();
			break;
		case StatePos.afterDrop:
			CheckEnd();
			break;
		}
	}

	public override void ProcessTrigger(TriggerCallback callback)
	{
		base.ProcessTrigger(callback);
		OpenDoors();
	}

	private void OpenDoors()
	{
		List<GameObject> list = new List<GameObject>();
		list.Add(doorLeftRef);
		inchworm.RequestEase(list, new Vector3(doorLeftRef.transform.position.x - doorOpenDist, 0f, 0f), doorOpenTime, adjustStartingPos: false, Inchworm.EaseStyle.Sin, Inchworm.EaseType.Position, DoorsOpenCallback);
		List<GameObject> list2 = new List<GameObject>();
		list2.Add(doorRightRef);
		inchworm.RequestEase(list2, new Vector3(doorRightRef.transform.position.x + doorOpenDist, 0f, 0f), doorOpenTime, adjustStartingPos: false, Inchworm.EaseStyle.Sin);
	}

	private void DoorsOpenCallback()
	{
		currentState = StatePos.lowerPipe;
		LowerPipe();
	}

	private void LowerPipe()
	{
		List<GameObject> list = new List<GameObject>();
		list.Add(pipeRef);
		inchworm.RequestEase(list, new Vector3(0f, pipeYEnd - pipeRef.transform.position.y, 0f), pipeDownDuration, adjustStartingPos: false, Inchworm.EaseStyle.Sin, Inchworm.EaseType.Position, PipeLoweredCallback);
	}

	private void PipeLoweredCallback()
	{
		currentState = StatePos.dropDogs;
	}

	private void RaisePipe()
	{
		List<GameObject> list = new List<GameObject>();
		list.Add(pipeRef);
		inchworm.RequestEase(list, new Vector3(0f, pipeYStart - pipeRef.transform.position.y, 0f), pipeUpDuration, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticIn, Inchworm.EaseType.Position, PipeRaisedCallback);
	}

	private void PipeRaisedCallback()
	{
		currentState = StatePos.afterDrop;
	}

	private void DropDogs()
	{
		currentWaitTime += Time.deltaTime;
		if (currentWaitTime >= timeBetweenDogs)
		{
			SpawnNextDog();
		}
	}

	private void SpawnNextDog()
	{
		currentDogNum++;
		currentWaitTime = 0f;
		Object.Instantiate(dogRef, dogSpawnPos, Random.rotation);
		if (currentDogNum >= numDogs)
		{
			RaisePipe();
			currentState = StatePos.raisePipe;
		}
	}

	private void CheckEnd()
	{
		if (landingZoneRef.GetComponent<PipeLandingZone>().dogCount >= numDogs)
		{
			landingZoneRef.GetComponent<PipeLandingZone>().ClearDogs();
			currentState = StatePos.finished;
			FinishTrigger();
		}
	}
}
