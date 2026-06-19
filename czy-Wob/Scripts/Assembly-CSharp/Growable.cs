using System;
using System.Collections.Generic;
using UnityEngine;

public class Growable : MonoBehaviour
{
	public Transform scaleObject;

	public List<GrowStage> growStages = new List<GrowStage>();

	private int growStageCount;

	public float lowScaleMult = 0.75f;

	public float highScaleMult = 1f;

	private float finalScale = 1f;

	private int currentGrowStage;

	private float currentGrowTimer;

	private GrowStage cachedGrowStage;

	private bool canStillSpread = true;

	private bool currentStageCanSpread = true;

	private bool currentStageCanKeepGrowing = true;

	private int currentSpreadAttempts;

	private float currentSpreadTimer;

	private bool isSquished;

	private bool squishReported;

	private float timeToSquish;

	private float timeToUnsquish = 1f;

	private float timeSquished;

	private float timeWithoutSquish;

	private Vector3 squishScale = new Vector3(1f, 0.25f, 1f);

	private Segment currentEase;

	private bool isBouncingForGrowth;

	private bool isBouncingForSquish;

	private BoundingBoxComponent bbcRef;

	private float debugTimeMultiplier = 1f;

	private Inchworm inchworm;

	private DogHome dogHomeRef;

	private ConstructionManager constructionRef;

	private void Awake()
	{
		growStageCount = growStages.Count;
		cachedGrowStage = growStages[currentGrowStage];
		for (int i = 0; i < growStageCount; i++)
		{
			growStages[i].CacheSpreaderCount();
		}
		finalScale = UnityEngine.Random.Range(lowScaleMult, highScaleMult);
		scaleObject.localScale = new Vector3(finalScale, finalScale, finalScale);
		ResetSpreadTimer();
		DeactivateAllGrowStages();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		inchworm = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		dogHomeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		scaleObject.transform.localRotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
		ActivateGrowStage(currentGrowStage);
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.S) && !CheatEngine.cheatRef.publicBuild)
		{
			debugTimeMultiplier = 500f;
		}
		else
		{
			debugTimeMultiplier = 1f;
		}
		CheckSpread();
		TickGrowStage();
		CheckSquish();
	}

	private void LateUpdate()
	{
		squishReported = false;
	}

	private void OnDestroy()
	{
		if (currentEase != null)
		{
			inchworm.CancelEase(ref currentEase, restoreParents: false);
			currentEase = null;
		}
	}

	public void Save(SaveablePlacedObject saveableObject)
	{
		saveableObject.floatList.Add(finalScale);
		saveableObject.floatList.Add(currentGrowTimer);
		saveableObject.floatList.Add(currentSpreadTimer);
		saveableObject.intList.Add(currentGrowStage);
		saveableObject.intList.Add(currentSpreadAttempts);
	}

	public void Load(SaveablePlacedObject saveableObject)
	{
		DeactivateAllGrowStages();
		finalScale = saveableObject.floatList[0];
		scaleObject.localScale = new Vector3(finalScale, finalScale, finalScale);
		ActivateGrowStage(saveableObject.intList[0]);
		currentGrowTimer = saveableObject.floatList[1];
		currentSpreadTimer = saveableObject.floatList[2];
		currentSpreadAttempts = saveableObject.intList[1];
		if (currentSpreadAttempts >= cachedGrowStage.maxSpreadAttempts)
		{
			canStillSpread = false;
		}
	}

	public void CopyGrowable(Growable growableRef)
	{
		SaveablePlacedObject saveableObject = new SaveablePlacedObject();
		growableRef.Save(saveableObject);
		Load(saveableObject);
	}

	private void DeactivateAllGrowStages()
	{
		for (int i = 0; i < growStageCount; i++)
		{
			DeactivateGrowStage(i);
		}
	}

	private void TickGrowStage()
	{
		if (!currentStageCanKeepGrowing || !constructionRef.IsInStandardMode())
		{
			return;
		}
		if (currentGrowTimer > 0f)
		{
			currentGrowTimer -= Time.deltaTime * debugTimeMultiplier;
			if (currentGrowTimer < 0f)
			{
				currentGrowTimer = 0f;
			}
		}
		if (currentGrowTimer <= 0f)
		{
			DeactivateGrowStage(currentGrowStage);
			if (cachedGrowStage.cycleBack)
			{
				ActivateGrowStage(currentGrowStage - cachedGrowStage.cycleBackCounter);
				return;
			}
			int num = UnityEngine.Random.Range(cachedGrowStage.stageIncrementLow, cachedGrowStage.stageIncrementHigh + 1);
			ActivateGrowStage(currentGrowStage + num);
		}
	}

	private void DeactivateGrowStage(int stageIndex)
	{
		growStages[stageIndex].objectRef.SetActive(value: false);
		if (growStages[stageIndex].triggerRef != null)
		{
			growStages[stageIndex].triggerRef.SetActive(value: false);
		}
	}

	private void ActivateGrowStage(int stageIndex)
	{
		currentGrowStage = stageIndex;
		cachedGrowStage = growStages[currentGrowStage];
		currentStageCanSpread = cachedGrowStage.spreaderCount != 0;
		if (cachedGrowStage.isFinalStage || (currentGrowStage >= growStageCount - 1 && !cachedGrowStage.cycleBack))
		{
			currentStageCanKeepGrowing = false;
		}
		else
		{
			currentStageCanKeepGrowing = true;
		}
		cachedGrowStage.objectRef.SetActive(value: true);
		if (cachedGrowStage.triggerRef != null)
		{
			cachedGrowStage.triggerRef.SetActive(value: true);
		}
		currentGrowTimer = cachedGrowStage.minutesInStage * 60f;
		float num = cachedGrowStage.percentageGrowJiggle * currentGrowTimer;
		currentGrowTimer = UnityEngine.Random.Range(currentGrowTimer - num, currentGrowTimer + num);
		isSquished = false;
		squishReported = false;
		RequestBounceInPlace();
	}

	private void CheckSpread()
	{
		if (canStillSpread && currentStageCanSpread)
		{
			currentSpreadTimer -= Time.deltaTime * debugTimeMultiplier;
			if (!(currentSpreadTimer > 0f))
			{
				ResetSpreadTimer();
				TrySpread();
			}
		}
	}

	private void ResetSpreadTimer()
	{
		currentSpreadTimer = UnityEngine.Random.Range(cachedGrowStage.spreadTimerLow, cachedGrowStage.spreadTimerHigh);
	}

	private void TrySpread()
	{
		currentSpreadAttempts++;
		if (currentSpreadAttempts >= cachedGrowStage.maxSpreadAttempts)
		{
			canStillSpread = false;
		}
		if (UnityEngine.Random.value > cachedGrowStage.spreadChance)
		{
			return;
		}
		if (bbcRef == null)
		{
			bbcRef = GetComponent<BoundingBoxComponent>();
		}
		Vector3 boxCenter = bbcRef.GetBoxCenter();
		ulong? roomUID = bbcRef.GetRoomUID();
		if (!roomUID.HasValue)
		{
			return;
		}
		RoomBase roomForUID = dogHomeRef.GetRoomForUID(roomUID.Value);
		RoomCustomizationObject randomElement = ListUtil.GetRandomElement(cachedGrowStage.spreaderObjects);
		bool flag = false;
		Vector2Int gridCell = Vector2Int.zero;
		int num = 4;
		for (int i = 0; i < num; i++)
		{
			float f = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
			float num2 = UnityEngine.Random.Range(cachedGrowStage.spreadDistanceLow, cachedGrowStage.spreadDistanceHigh);
			Vector2Int gridSquareForPositionAndRoom = ObjectPlacementManager.GetGridSquareForPositionAndRoom(boxCenter + new Vector3(Mathf.Cos(f), 0f, Mathf.Sin(f)) * num2, roomForUID, forPlants: true);
			if (ObjectPlacementManager.CanPlacePlant(roomForUID, randomElement, gridSquareForPositionAndRoom))
			{
				flag = true;
				gridCell = gridSquareForPositionAndRoom;
				break;
			}
		}
		if (flag)
		{
			ObjectPlacementManager.PlacePlant(roomForUID, randomElement, gridCell);
		}
	}

	public void ReportSquish()
	{
		squishReported = true;
	}

	private void CheckSquish()
	{
		if (currentEase != null)
		{
			timeWithoutSquish = 0f;
			return;
		}
		if (!squishReported)
		{
			timeSquished = 0f;
			if (isSquished)
			{
				timeWithoutSquish += Time.deltaTime;
				if (timeWithoutSquish > timeToUnsquish)
				{
					ResetSquish();
				}
			}
			return;
		}
		timeWithoutSquish = 0f;
		if (!isSquished)
		{
			timeSquished += Time.deltaTime;
			if (timeSquished > timeToSquish)
			{
				EngageSquish();
			}
		}
	}

	private void EngageSquish()
	{
		if (!isBouncingForSquish && !isBouncingForGrowth && !isSquished)
		{
			isSquished = true;
			scaleObject.transform.localScale = squishScale;
			RequestBounceScaleDown();
		}
	}

	private void ResetSquish()
	{
		if (currentEase == null && isSquished)
		{
			isSquished = false;
			RequestBounceScaleUp();
		}
	}

	private void RequestBounceInPlace()
	{
		if (!(inchworm == null))
		{
			if (currentEase != null)
			{
				inchworm.CancelAndFinishEase(ref currentEase);
				BounceFinishedCallback();
			}
			isBouncingForGrowth = true;
			scaleObject.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			Vector3 targetScale = new Vector3(finalScale, finalScale, finalScale);
			currentEase = inchworm.RequestEaseToScale(scaleObject.gameObject, targetScale, 0.5f, Inchworm.EaseStyle.ElasticOut, BounceFinishedCallback);
		}
	}

	private void RequestBounceScaleUp()
	{
		if (currentEase != null)
		{
			inchworm.CancelAndFinishEase(ref currentEase);
			BounceFinishedCallback();
		}
		scaleObject.localScale = squishScale;
		currentEase = inchworm.RequestEaseToScale(scaleObject.gameObject, Vector3.one, 0.5f, Inchworm.EaseStyle.ElasticOut, BounceFinishedCallback);
	}

	private void RequestBounceScaleDown()
	{
		if (currentEase != null)
		{
			inchworm.CancelAndFinishEase(ref currentEase);
			BounceFinishedCallback();
		}
		isBouncingForSquish = true;
		scaleObject.transform.localScale = Vector3.one;
		currentEase = inchworm.RequestEaseToScale(scaleObject.gameObject, squishScale, 0.1f, Inchworm.EaseStyle.Sin, BounceFinishedCallback);
	}

	private void BounceFinishedCallback()
	{
		currentEase = null;
		isBouncingForGrowth = false;
		isBouncingForSquish = false;
	}
}
