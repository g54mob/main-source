using System.Collections;
using System.Collections.Generic;
using ClockStone;
using UnityEngine;

public class LevitateBehavior : MonoBehaviour
{
	public delegate void LevitateFinishedCallback();

	private LevitateFinishedCallback currentCallback;

	private float levitationTimeLow = 5f;

	private float leviationTimeHigh = 20f;

	private float levitationGravMod = 0.05f;

	private float levitationGravModLow = 0.05f;

	private float levitationGravModHigh = 0.25f;

	private bool isLevitating;

	private Coroutine levitationRoutine;

	private GameObject levitationTarget;

	private List<Gravboost> levitationBoosters = new List<Gravboost>();

	private string levitateLoop = "dog_ghost_levitate_loop";

	private float levitateFadeOutTime = 0.5f;

	private AudioObject currentLevitationLoop;

	private LegController legRef;

	private FaceController faceRef;

	private GameObject levitationLine;

	private GameObject highlightedSelf;

	private GameObject highlightedTarget;

	private GhostManager ghostRef;

	private ObjectGrabber grabberRef;

	private ConstructionManager constructionRef;

	private void Awake()
	{
		legRef = GetComponent<LegController>();
		faceRef = GetComponent<FaceController>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		ghostRef = registrationScript.GetGlobalComponent<GhostManager>(GlobalObject.GHOST_MANAGER);
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
	}

	public bool IsLevitating()
	{
		return isLevitating;
	}

	public void RequestLevitate(GameObject target, LevitateFinishedCallback callback = null)
	{
		if (isLevitating || levitationRoutine != null)
		{
			Debug.LogError("Attempting to levitate but we're already doing so.");
			return;
		}
		isLevitating = true;
		currentCallback = callback;
		highlightedSelf = base.gameObject;
		grabberRef.HighlightObjectForLevitation(base.gameObject);
		levitationGravMod = Random.Range(levitationGravModLow, levitationGravModHigh);
		currentLevitationLoop = AudioController.Play(levitateLoop, legRef.bodyFront.transform);
		bool self = false;
		levitationTarget = target;
		if (target == null)
		{
			self = true;
			levitationTarget = base.gameObject;
		}
		else
		{
			levitationLine = Object.Instantiate(ghostRef.levitationLinePrefab);
			levitationTarget = levitationTarget.transform.root.gameObject;
			highlightedTarget = levitationTarget;
			grabberRef.HighlightObjectForLevitation(levitationTarget);
			if (levitationTarget.CompareTag(Tags.DOG))
			{
				LegController component = levitationTarget.GetComponent<LegController>();
				faceRef.FocusOnTarget(component.bodyFront.transform);
				levitationLine.GetComponent<LevitationParabola>().SetTransforms(GetComponent<LegController>().bodyFront.transform, component.bodyFront.transform);
			}
			else
			{
				Transform transform = levitationTarget.GetComponentInChildren<Rigidbody>().transform;
				faceRef.FocusOnTarget(transform);
				levitationLine.GetComponent<LevitationParabola>().SetTransforms(GetComponent<LegController>().bodyFront.transform, transform);
			}
		}
		if (!levitationTarget.CompareTag(Tags.DOG))
		{
			levitationBoosters.AddRange(levitationTarget.GetComponentsInChildren<Gravboost>());
		}
		levitationRoutine = StartCoroutine(LevitationRoutine(self));
	}

	public void RequestStopLevitating()
	{
		if (isLevitating)
		{
			FinishLevitate();
		}
	}

	private IEnumerator LevitationRoutine(bool self)
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		GetComponent<BoundingBoxComponent>();
		BoundingBoxComponent bbc = levitationTarget.GetComponent<BoundingBoxComponent>();
		isLevitating = true;
		if (levitationTarget.CompareTag(Tags.DOG))
		{
			levitationTarget.GetComponent<BodyBuck>().LockBucks();
			if (!self)
			{
				levitationTarget.GetComponent<DogAI>().OnLevitatedByDog(base.gameObject);
			}
		}
		float timer = 0f;
		for (float levitationTime = Random.Range(levitationTimeLow, leviationTimeHigh); timer < levitationTime; timer += Time.deltaTime)
		{
			if (!(levitationTarget != null))
			{
				break;
			}
			if (!(bbc != null))
			{
				break;
			}
			Vector3 boxCenter = bbc.GetBoxCenter();
			float num = 0f;
			ulong? roomUID = bbc.GetRoomUID();
			if (roomUID.HasValue)
			{
				ulong? uIDForDenObjectIsInsideOf = DenInteriorManager.GetUIDForDenObjectIsInsideOf(base.gameObject);
				num = ((!uIDForDenObjectIsInsideOf.HasValue) ? constructionRef.GetObjectForUID(roomUID.Value).GetComponent<RoomBase>().GetRoomCenter()
					.y : DenInteriorManager.GetInteriorForDenID(uIDForDenObjectIsInsideOf.Value).GetComponent<BoundingBoxComponent>().GetBoxCenter()
					.y);
			}
			if (boxCenter.y < num)
			{
				if (levitationTarget.CompareTag(Tags.DOG))
				{
					levitationTarget.GetComponent<GravboostDog>().SetCustomMultiplier(0f - levitationGravMod);
				}
				else
				{
					for (int i = 0; i < levitationBoosters.Count; i++)
					{
						levitationBoosters[i].SetCustomMultiplier(0f - levitationGravMod);
					}
				}
			}
			else if (boxCenter.y > num)
			{
				if (levitationTarget.CompareTag(Tags.DOG))
				{
					levitationTarget.GetComponent<GravboostDog>().SetCustomMultiplier(levitationGravMod);
				}
				else
				{
					for (int j = 0; j < levitationBoosters.Count; j++)
					{
						levitationBoosters[j].SetCustomMultiplier(levitationGravMod);
					}
				}
			}
			yield return frameWait;
		}
		currentCallback?.Invoke();
		currentCallback = null;
		levitationRoutine = null;
	}

	private void FinishLevitate()
	{
		isLevitating = false;
		if (currentLevitationLoop != null)
		{
			currentLevitationLoop.Stop(levitateFadeOutTime);
			currentLevitationLoop = null;
		}
		if (levitationTarget != null)
		{
			if (levitationTarget.CompareTag(Tags.DOG))
			{
				levitationTarget.GetComponent<BodyBuck>().UnlockBucks();
				levitationTarget.GetComponent<GravboostDog>().ClearCustomMultiplier();
			}
			else
			{
				for (int i = 0; i < levitationBoosters.Count; i++)
				{
					levitationBoosters[i].ClearCustomMultiplier();
				}
			}
		}
		if (highlightedSelf != null)
		{
			grabberRef.ClearLevitationObject(highlightedSelf);
			highlightedSelf = null;
		}
		if (highlightedTarget != null)
		{
			grabberRef.ClearLevitationObject(highlightedTarget);
			highlightedTarget = null;
		}
		if (levitationLine != null)
		{
			Object.Destroy(levitationLine);
			levitationLine = null;
		}
		levitationTarget = null;
		levitationBoosters.Clear();
		if (levitationRoutine != null)
		{
			StopCoroutine(levitationRoutine);
			levitationRoutine = null;
		}
	}
}
