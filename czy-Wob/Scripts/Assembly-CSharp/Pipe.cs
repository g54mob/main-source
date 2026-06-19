using System.Collections.Generic;
using ClockStone;
using UnityEngine;

[ExecuteInEditMode]
public class Pipe : MonoBehaviour
{
	public enum PipeSegmentType
	{
		None = -1,
		Left = 0,
		Right = 1,
		Up = 2,
		Down = 3,
		Forward = 4,
		Backward = 5
	}

	public GameObject basePipe;

	public GameObject longPipe;

	public GameObject pipeJoint;

	public GameObject floorPortal;

	private float effectivePipeSize = ConstructionManager.pipeSize;

	public bool editorMode = true;

	public List<PipeSegmentType> segments = new List<PipeSegmentType>();

	public List<GameObject> createdSegments = new List<GameObject>();

	public List<GameObject> createdConnectors = new List<GameObject>();

	private bool dirRight = true;

	private float scaleFactor = 1f;

	private string pipeExitSuctionSound = "pipe_exit_suction";

	private string pipeExitPulloutSound = "pipe_exit_pullout";

	private string pipeEntranceLoopSound = "pipe_entrance_loop";

	private string pipeEntranceLoopLayerSound = "pipe_entrance_loop_layer";

	private string pipeEntranceSuctionSound = "pipe_entrance_suction";

	private List<ulong> allObjectIDsInEntrance = new List<ulong>();

	private Dictionary<ulong, AudioObject> objectIDToEntranceLoopDict = new Dictionary<ulong, AudioObject>();

	private Dictionary<ulong, AudioObject> objectIDToEntranceLoopLayerDict = new Dictionary<ulong, AudioObject>();

	private List<GameObject> objectsInPipe = new List<GameObject>();

	private List<GameObject> objectsInPipeWithEntrySoundsPlayed = new List<GameObject>();

	private float pipeExitVelocityMod = 0.4f;

	private float loopFadeoutLen = 0.1f;

	private float startingLoopVolume = 1f;

	private float velocityMagnitudeMin;

	private float velocityMagnitudeMax = 20f;

	private bool endingPortalIsFloor;

	private bool startingPortalIsFloor;

	private bool endingPortalIsTopOfPen;

	private bool startingPortalIsTopOfPen = true;

	private bool firstSegmentCostCharged;

	private ObjectGrabber grabberRef;

	private void Start()
	{
		OnStart();
		grabberRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
	}

	private void Update()
	{
		OnUpdate();
	}

	public bool IsObjectBeingGrabbed(GameObject obj)
	{
		if (grabberRef == null)
		{
			return false;
		}
		return grabberRef.GetGrabbedObject() == obj;
	}

	public void SetStartingFloorInfo(bool isFloor)
	{
		startingPortalIsFloor = isFloor;
	}

	public void SetEndingFloorInfo(bool isFloor)
	{
		endingPortalIsFloor = isFloor;
	}

	public void SetStartingPenTopInfo(bool isTopOfPen)
	{
		startingPortalIsTopOfPen = isTopOfPen;
	}

	public void SetEndingPenTopInfo(bool isTopOfPen)
	{
		endingPortalIsTopOfPen = isTopOfPen;
	}

	protected virtual void OnStart()
	{
		CreatePipeSystem();
	}

	protected virtual void OnUpdate()
	{
		CheckObjectsHaveLeftPipe();
		CheckObjectsHaveLeftEntrance();
		UpdateEntranceLoopAudio();
	}

	public bool FirstSegmentedPaidFor()
	{
		return firstSegmentCostCharged;
	}

	public void SetFirstSegmentPaidFor()
	{
		if (firstSegmentCostCharged)
		{
			Debug.LogError("Already paid for the first segment.");
		}
		else
		{
			firstSegmentCostCharged = true;
		}
	}

	public void SetScaleFactor(float newScaleFactor)
	{
		scaleFactor = newScaleFactor;
		base.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
		CreatePipeSystem();
	}

	public Vector3 ReverseSegmentGravity(Vector3 originalGrav, int segmentIndex)
	{
		return originalGrav * -1f;
	}

	public Vector3 GetFirstSegmentCenter()
	{
		return GetFirstSegment().transform.position;
	}

	public Vector3 GetLastSegmentCenter()
	{
		return GetLastSegment().transform.position;
	}

	public bool DefaultDirection()
	{
		return dirRight;
	}

	public GameObject GetFirstSegment()
	{
		if (dirRight)
		{
			return createdSegments[0];
		}
		return createdSegments[createdSegments.Count - 1];
	}

	public GameObject GetLastSegment()
	{
		if (dirRight)
		{
			return createdSegments[createdSegments.Count - 1];
		}
		return createdSegments[0];
	}

	public Vector3 GetFirstSegmentEntranceCenter()
	{
		Vector3 forward = GetFirstSegment().GetComponent<PipeEntrance>().rotationObject.transform.forward;
		Vector3 vector = Vector3.one * (effectivePipeSize / 1.5f);
		return GetFirstSegmentCenter() + new Vector3(forward.x * vector.x, forward.y * vector.y, forward.z * vector.z);
	}

	public Vector3 GetLastSegmentEntranceCenter()
	{
		Vector3 forward = GetLastSegment().GetComponent<PipeEntrance>().rotationObject.transform.forward;
		Vector3 vector = Vector3.one * (effectivePipeSize / 1.5f);
		return GetLastSegmentCenter() + new Vector3(forward.x * vector.x, forward.y * vector.y, forward.z * vector.z);
	}

	public void OnObjectLeftEntranceTrigger(GameObject newObject)
	{
		GameObject gameObject = newObject.transform.root.gameObject;
		if (!objectsInPipe.Contains(gameObject) || IsObjectBeingGrabbed(gameObject))
		{
			return;
		}
		if (!objectsInPipeWithEntrySoundsPlayed.Contains(gameObject))
		{
			objectsInPipeWithEntrySoundsPlayed.Add(gameObject);
			AudioController.Play(pipeEntranceSuctionSound, newObject.GetComponent<BoundingBoxComponent>().GetBoxCenter());
		}
		ulong uID = gameObject.GetComponent<ObjectID>().GetUID();
		if (allObjectIDsInEntrance.Contains(uID))
		{
			allObjectIDsInEntrance.Remove(uID);
			if (objectIDToEntranceLoopDict.ContainsKey(uID))
			{
				objectIDToEntranceLoopDict[uID].Stop(loopFadeoutLen);
				objectIDToEntranceLoopDict.Remove(uID);
			}
			if (objectIDToEntranceLoopLayerDict.ContainsKey(uID))
			{
				objectIDToEntranceLoopLayerDict[uID].Stop(loopFadeoutLen);
				objectIDToEntranceLoopLayerDict.Remove(uID);
			}
		}
	}

	public void OnObjectInEntrance(GameObject newObjectHit, GameObject hitTrigger)
	{
		GameObject gameObject = newObjectHit.transform.root.gameObject;
		if (objectsInPipe.Contains(gameObject))
		{
			return;
		}
		objectsInPipe.Add(gameObject);
		if (gameObject.CompareTag(Tags.DOG))
		{
			gameObject.GetComponent<NodeAssociationController>().SetCurrentPipe(base.gameObject);
		}
		GameObject segmentRef = hitTrigger.GetComponent<PipeEntryExitTrigger>().segmentRef;
		if (createdSegments.Count == 1)
		{
			BasePipe component = segmentRef.GetComponent<BasePipe>();
			if (hitTrigger == component.triggerExit && dirRight)
			{
				ReverseDirection();
			}
			else if (hitTrigger == component.triggerEntry && !dirRight)
			{
				ReverseDirection();
			}
		}
		else if (segmentRef == GetLastSegment())
		{
			ReverseDirection();
		}
		ulong uID = gameObject.GetComponent<ObjectID>().GetUID();
		if (!allObjectIDsInEntrance.Contains(uID))
		{
			allObjectIDsInEntrance.Add(uID);
			AudioObject audioObject = AudioController.Play(pipeEntranceLoopSound, newObjectHit.transform);
			if (audioObject != null)
			{
				objectIDToEntranceLoopDict[uID] = audioObject;
				objectIDToEntranceLoopLayerDict[uID] = AudioController.Play(pipeEntranceLoopLayerSound, newObjectHit.transform);
				startingLoopVolume = objectIDToEntranceLoopLayerDict[uID].volume;
				objectIDToEntranceLoopLayerDict[uID].volume *= GetVelocityModifiedVolumeForObject(gameObject);
			}
			else
			{
				startingLoopVolume = 0f;
			}
		}
	}

	private float GetVelocityModifiedVolumeForObject(GameObject obj)
	{
		Rigidbody rb = ((!obj.CompareTag(Tags.DOG)) ? obj.GetComponentInChildren<Rigidbody>() : obj.GetComponent<LegController>().bodyFront.GetComponent<Rigidbody>());
		return GetVelocityModifiedVolumeForRigidbody(rb, velocityMagnitudeMin, velocityMagnitudeMax);
	}

	private float GetVelocityModifiedVolumeForRigidbody(Rigidbody rb, float minVolume = 0f, float maxVolume = 1f)
	{
		return MathUtil.GetValueOfRangePercentage(MathUtil.GetPercentageOfRange(Mathf.Clamp(rb.velocity.magnitude, velocityMagnitudeMin, velocityMagnitudeMax), velocityMagnitudeMin, velocityMagnitudeMax), minVolume, maxVolume);
	}

	private void UpdateEntranceLoopAudio()
	{
		for (int i = 0; i < objectsInPipe.Count; i++)
		{
			if (!(objectsInPipe[i] == null))
			{
				ulong uID = objectsInPipe[i].GetComponent<ObjectID>().GetUID();
				if (objectIDToEntranceLoopDict.ContainsKey(uID) && objectIDToEntranceLoopLayerDict[uID] != null)
				{
					objectIDToEntranceLoopLayerDict[uID].volume = startingLoopVolume * GetVelocityModifiedVolumeForObject(objectsInPipe[i]);
				}
			}
		}
	}

	private void ReverseDirection()
	{
		dirRight = !dirRight;
	}

	private void CheckObjectsHaveLeftEntrance()
	{
		for (int num = allObjectIDsInEntrance.Count - 1; num >= 0; num--)
		{
			GameObject objectForUID = ObjectRegistration.GetRegistrationScript().GetObjectForUID(allObjectIDsInEntrance[num]);
			if (!(objectForUID == null))
			{
				BoundingBoxComponent component = objectForUID.GetComponent<BoundingBoxComponent>();
				PipeEntrance component2 = GetFirstSegment().GetComponent<PipeEntrance>();
				Vector3 otherCenter = component2.entryTriggerCollider.transform.TransformPoint(component2.entryTriggerCollider.center);
				Vector3 extents = component2.entryTriggerCollider.bounds.extents;
				if (!component.CheckBoxIntersect(otherCenter, extents))
				{
					OnObjectLeftEntranceTrigger(objectForUID);
				}
			}
		}
	}

	private void CheckObjectsHaveLeftPipe()
	{
		for (int num = objectsInPipeWithEntrySoundsPlayed.Count - 1; num >= 0; num--)
		{
			if (objectsInPipeWithEntrySoundsPlayed[num] == null)
			{
				objectsInPipeWithEntrySoundsPlayed.RemoveAt(num);
			}
		}
		bool flag = false;
		for (int num2 = objectsInPipe.Count - 1; num2 >= 0; num2--)
		{
			bool flag2 = false;
			if (objectsInPipe[num2] == null)
			{
				flag = true;
				if (objectsInPipeWithEntrySoundsPlayed.Contains(null))
				{
					objectsInPipeWithEntrySoundsPlayed.Remove(null);
				}
				objectsInPipe.RemoveAt(num2);
			}
			else
			{
				BoundingBoxComponent component = objectsInPipe[num2].GetComponent<BoundingBoxComponent>();
				for (int i = 0; i < createdSegments.Count; i++)
				{
					if (createdSegments[i].GetComponent<BoundingBoxComponent>().CheckBoxIntersect(component))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					if (objectsInPipe[num2].CompareTag(Tags.DOG))
					{
						objectsInPipe[num2].GetComponent<NodeAssociationController>().SetCurrentPipe(null);
					}
					OnObjectRemovedFromPipe(objectsInPipe[num2]);
					if (objectsInPipeWithEntrySoundsPlayed.Contains(objectsInPipe[num2]))
					{
						objectsInPipeWithEntrySoundsPlayed.Remove(objectsInPipe[num2]);
					}
					objectsInPipe.RemoveAt(num2);
				}
			}
		}
		if (flag)
		{
			CheckForNullRefs();
		}
	}

	private void CheckForNullRefs()
	{
		for (int num = allObjectIDsInEntrance.Count - 1; num >= 0; num--)
		{
			ulong num2 = allObjectIDsInEntrance[num];
			int num3;
			if (objectsInPipe.Count != 0)
			{
				num3 = ((ObjectRegistration.GetRegistrationScript().GetObjectForUID(allObjectIDsInEntrance[num]) == null) ? 1 : 0);
				if (num3 == 0)
				{
					goto IL_005c;
				}
			}
			else
			{
				num3 = 1;
			}
			allObjectIDsInEntrance.Remove(num2);
			goto IL_005c;
			IL_005c:
			bool flag = objectIDToEntranceLoopDict.ContainsKey(num2);
			bool flag2 = objectIDToEntranceLoopLayerDict.ContainsKey(num2);
			if (num3 != 0 || (flag && objectIDToEntranceLoopDict[num2] == null) || (flag2 && objectIDToEntranceLoopLayerDict[num2] == null))
			{
				if (flag)
				{
					objectIDToEntranceLoopDict[num2].Stop(loopFadeoutLen);
					objectIDToEntranceLoopDict.Remove(num2);
				}
				if (flag2)
				{
					objectIDToEntranceLoopLayerDict[num2].Stop(loopFadeoutLen);
					objectIDToEntranceLoopLayerDict.Remove(num2);
				}
			}
		}
	}

	private void OnObjectRemovedFromPipe(GameObject obj)
	{
		ulong uID = obj.GetComponent<ObjectID>().GetUID();
		if (allObjectIDsInEntrance.Contains(uID))
		{
			allObjectIDsInEntrance.Remove(uID);
			if (objectIDToEntranceLoopDict.ContainsKey(uID))
			{
				objectIDToEntranceLoopDict[uID].Stop(loopFadeoutLen);
				objectIDToEntranceLoopDict.Remove(uID);
			}
			if (objectIDToEntranceLoopLayerDict.ContainsKey(uID))
			{
				objectIDToEntranceLoopLayerDict[uID].Stop(loopFadeoutLen);
				objectIDToEntranceLoopLayerDict.Remove(uID);
			}
		}
		Rigidbody rigidbody = null;
		Rigidbody[] componentsInChildren = obj.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody2 in componentsInChildren)
		{
			if (rigidbody == null)
			{
				rigidbody = rigidbody2;
			}
			rigidbody2.velocity *= pipeExitVelocityMod;
		}
		if (!(rigidbody != null))
		{
			return;
		}
		if (IsObjectBeingGrabbed(obj))
		{
			AudioObject audioObject = AudioController.Play(pipeExitPulloutSound, rigidbody.transform.position);
			if (audioObject != null)
			{
				audioObject.volume *= GetVelocityModifiedVolumeForRigidbody(rigidbody, 0.5f);
			}
		}
		else
		{
			AudioController.Play(pipeExitSuctionSound, rigidbody.transform.position);
		}
	}

	public void AddPipeSegment(PipeSegmentType newSegment)
	{
		segments.Add(newSegment);
		CreatePipeSystem();
	}

	public Quaternion GetCorrectRotationForFirstSegment()
	{
		return GetRotationForSegmentType(segments[0], entrance: true);
	}

	public void CreatePipeSystem()
	{
		if (segments.Count == 0)
		{
			Debug.LogError("Attempting to create a pipe system with zero segments.");
			return;
		}
		DestroyOldPipes();
		Vector3 currentPos = base.transform.position;
		bool flag = false;
		for (int i = 0; i < segments.Count; i++)
		{
			if (flag)
			{
				flag = false;
				continue;
			}
			PipeSegmentType pipeSegmentType = segments[i];
			PipeSegmentType pipeSegmentType2 = ((i != 0) ? segments[i - 1] : PipeSegmentType.None);
			PipeSegmentType dirMinus = ((i <= 1) ? PipeSegmentType.None : segments[i - 2]);
			PipeSegmentType pipeSegmentType3 = ((i + 1 >= segments.Count) ? PipeSegmentType.None : segments[i + 1]);
			GameObject gameObject = Object.Instantiate(GetPipeObjectForSegmentTypes(pipeSegmentType, pipeSegmentType2, pipeSegmentType3, i, segments.Count), base.transform.localPosition, base.transform.rotation);
			gameObject.transform.localScale *= scaleFactor;
			createdSegments.Add(gameObject);
			PipeFlyZone componentInChildren = gameObject.GetComponentInChildren<PipeFlyZone>();
			componentInChildren.SetSegmentIndex(i);
			componentInChildren.SetGravScaleFactor(Mathf.Max(1f, 1f / scaleFactor));
			bool floor = false;
			bool topOfPen = false;
			bool flag2 = false;
			if (pipeSegmentType2 == PipeSegmentType.None)
			{
				flag2 = true;
				floor = startingPortalIsFloor;
				topOfPen = startingPortalIsTopOfPen;
			}
			else if (pipeSegmentType3 == PipeSegmentType.None)
			{
				flag2 = true;
				floor = endingPortalIsFloor;
				topOfPen = endingPortalIsTopOfPen;
				componentInChildren.pipePortalExit = true;
			}
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.position = currentPos;
			if (pipeSegmentType != pipeSegmentType2 && pipeSegmentType2 != PipeSegmentType.None)
			{
				RotatePipeJoint(gameObject, pipeSegmentType2, pipeSegmentType);
			}
			else
			{
				if (flag2)
				{
					RotateEntrance(gameObject, pipeSegmentType, pipeSegmentType2);
				}
				gameObject.transform.localRotation = GetRotationForSegmentType(pipeSegmentType, flag2);
			}
			if (!flag2 && (pipeSegmentType == pipeSegmentType2 || pipeSegmentType2 == PipeSegmentType.None))
			{
				ApplyRandomRotation(gameObject, pipeSegmentType);
			}
			if (pipeSegmentType != pipeSegmentType2 && pipeSegmentType2 != PipeSegmentType.None)
			{
				componentInChildren.SetSegmentDir(pipeSegmentType);
				componentInChildren.SetPrevSegmentDir(pipeSegmentType2);
			}
			bool longSegment = false;
			if (pipeSegmentType == pipeSegmentType3 && pipeSegmentType == pipeSegmentType2 && i + 2 < segments.Count)
			{
				longSegment = true;
				flag = true;
			}
			ShowConnectors(gameObject, dirMinus, pipeSegmentType2, pipeSegmentType, pipeSegmentType3, i == segments.Count - 1, flag2, floor, topOfPen);
			OffsetCurrentPosBySegmentType(ref currentPos, pipeSegmentType, longSegment);
		}
	}

	private void ApplyRandomRotation(GameObject pipe, PipeSegmentType segmentType)
	{
		if (Random.value > 0.5f)
		{
			pipe.transform.Rotate(Vector3.up, 180f, Space.Self);
		}
		if (segmentType == PipeSegmentType.Forward || segmentType == PipeSegmentType.Backward)
		{
			pipe.transform.Rotate(Vector3.up, 90f, Space.Self);
		}
	}

	private void ShowConnectors(GameObject pipe, PipeSegmentType dirMinus2, PipeSegmentType dirMinus1, PipeSegmentType currentDir, PipeSegmentType nextDir, bool lastSegment, bool entrance, bool floor, bool topOfPen)
	{
		if (pipe == null || currentDir == PipeSegmentType.None)
		{
			return;
		}
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		if (entrance)
		{
			PipeEntrance component = pipe.GetComponent<PipeEntrance>();
			gameObject2 = (floor ? component.frontConnectorFloor : ((!topOfPen) ? component.frontConnector : component.frontConnectorTop));
			gameObject2.SetActive(value: true);
			return;
		}
		BasePipe component2 = pipe.GetComponent<BasePipe>();
		if (component2 != null)
		{
			gameObject = component2.connectorBack;
			gameObject2 = component2.connectorFront;
		}
		else
		{
			PipeJoint component3 = pipe.GetComponent<PipeJoint>();
			if (!(component3 != null))
			{
				return;
			}
			gameObject = component3.backConnector;
			gameObject2 = component3.frontConnector;
		}
		bool flag = false;
		if (dirMinus1 != PipeSegmentType.None && currentDir != PipeSegmentType.None && nextDir != PipeSegmentType.None && dirMinus1 != currentDir && currentDir == nextDir)
		{
			gameObject.SetActive(value: true);
			gameObject2.SetActive(value: true);
			return;
		}
		if (dirMinus1 != PipeSegmentType.None && currentDir != PipeSegmentType.None && dirMinus2 != PipeSegmentType.None && dirMinus1 == currentDir && dirMinus2 != dirMinus1)
		{
			flag = true;
		}
		if (lastSegment && !flag)
		{
			gameObject.SetActive(value: true);
			gameObject2.SetActive(value: true);
		}
		else
		{
			if (flag && !lastSegment)
			{
				return;
			}
			switch (currentDir)
			{
			case PipeSegmentType.Left:
				if (gameObject.transform.position.x < gameObject2.transform.position.x)
				{
					if (flag && lastSegment)
					{
						gameObject.SetActive(value: true);
					}
					else
					{
						gameObject2.SetActive(value: true);
					}
				}
				else if (flag && lastSegment)
				{
					gameObject2.SetActive(value: true);
				}
				else
				{
					gameObject.SetActive(value: true);
				}
				break;
			case PipeSegmentType.Right:
				if (gameObject.transform.position.x > gameObject2.transform.position.x)
				{
					if (flag && lastSegment)
					{
						gameObject.SetActive(value: true);
					}
					else
					{
						gameObject2.SetActive(value: true);
					}
				}
				else if (flag && lastSegment)
				{
					gameObject2.SetActive(value: true);
				}
				else
				{
					gameObject.SetActive(value: true);
				}
				break;
			case PipeSegmentType.Up:
				if (gameObject.transform.position.y > gameObject2.transform.position.y)
				{
					if (flag && lastSegment)
					{
						gameObject.SetActive(value: true);
					}
					else
					{
						gameObject2.SetActive(value: true);
					}
				}
				else if (flag && lastSegment)
				{
					gameObject2.SetActive(value: true);
				}
				else
				{
					gameObject.SetActive(value: true);
				}
				break;
			case PipeSegmentType.Down:
				if (gameObject.transform.position.y < gameObject2.transform.position.y)
				{
					if (flag && lastSegment)
					{
						gameObject.SetActive(value: true);
					}
					else
					{
						gameObject2.SetActive(value: true);
					}
				}
				else if (flag && lastSegment)
				{
					gameObject2.SetActive(value: true);
				}
				else
				{
					gameObject.SetActive(value: true);
				}
				break;
			case PipeSegmentType.Forward:
				if (gameObject.transform.position.z < gameObject2.transform.position.z)
				{
					if (flag && lastSegment)
					{
						gameObject.SetActive(value: true);
					}
					else
					{
						gameObject2.SetActive(value: true);
					}
				}
				else if (flag && lastSegment)
				{
					gameObject2.SetActive(value: true);
				}
				else
				{
					gameObject.SetActive(value: true);
				}
				break;
			case PipeSegmentType.Backward:
				if (gameObject.transform.position.z > gameObject2.transform.position.z)
				{
					if (flag && lastSegment)
					{
						gameObject.SetActive(value: true);
					}
					else
					{
						gameObject2.SetActive(value: true);
					}
				}
				else if (flag && lastSegment)
				{
					gameObject2.SetActive(value: true);
				}
				else
				{
					gameObject.SetActive(value: true);
				}
				break;
			}
		}
	}

	private void RotateEntrance(GameObject entrance, PipeSegmentType typeCurrent, PipeSegmentType typePrev)
	{
		PipeEntrance component = entrance.GetComponent<PipeEntrance>();
		if ((typeCurrent == PipeSegmentType.Left && typePrev == PipeSegmentType.None) || (typeCurrent == PipeSegmentType.Right && typePrev != PipeSegmentType.None))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(90f, 180f, 90f);
		}
		else if ((typeCurrent == PipeSegmentType.Right && typePrev == PipeSegmentType.None) || (typeCurrent == PipeSegmentType.Left && typePrev != PipeSegmentType.None))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(-90f, 0f, -90f);
		}
		else if ((typeCurrent == PipeSegmentType.Backward && typePrev == PipeSegmentType.None) || (typeCurrent == PipeSegmentType.Forward && typePrev != PipeSegmentType.None))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(90f, 180f, 0f);
		}
		else if ((typeCurrent == PipeSegmentType.Up && typePrev == PipeSegmentType.None) || (typeCurrent == PipeSegmentType.Down && typePrev != PipeSegmentType.None))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
		}
	}

	private void RotatePipeJoint(GameObject joint, PipeSegmentType prevType, PipeSegmentType newType)
	{
		PipeJoint component = joint.GetComponent<PipeJoint>();
		if ((prevType == PipeSegmentType.Left && newType == PipeSegmentType.Up) || (prevType == PipeSegmentType.Down && newType == PipeSegmentType.Right))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(-90f, -90f, 0f);
		}
		else if ((prevType == PipeSegmentType.Up && newType == PipeSegmentType.Right) || (prevType == PipeSegmentType.Left && newType == PipeSegmentType.Down))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(0f, 90f, 180f);
		}
		else if ((prevType == PipeSegmentType.Right && newType == PipeSegmentType.Down) || (prevType == PipeSegmentType.Up && newType == PipeSegmentType.Left))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(90f, -90f, 0f);
		}
		else if ((prevType == PipeSegmentType.Down && newType == PipeSegmentType.Left) || (prevType == PipeSegmentType.Right && newType == PipeSegmentType.Up))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
		}
		else if ((prevType == PipeSegmentType.Backward && newType == PipeSegmentType.Up) || (prevType == PipeSegmentType.Down && newType == PipeSegmentType.Forward))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
		}
		else if ((prevType == PipeSegmentType.Up && newType == PipeSegmentType.Forward) || (prevType == PipeSegmentType.Backward && newType == PipeSegmentType.Down))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(180f, 0f, 0f);
		}
		else if ((prevType == PipeSegmentType.Forward && newType == PipeSegmentType.Down) || (prevType == PipeSegmentType.Up && newType == PipeSegmentType.Backward))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		}
		else if ((prevType == PipeSegmentType.Forward && newType == PipeSegmentType.Right) || (prevType == PipeSegmentType.Left && newType == PipeSegmentType.Backward))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(0f, 90f, 90f);
		}
		else if ((prevType == PipeSegmentType.Left && newType == PipeSegmentType.Forward) || (prevType == PipeSegmentType.Backward && newType == PipeSegmentType.Right))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(0f, 90f, -90f);
		}
		else if ((prevType == PipeSegmentType.Backward && newType == PipeSegmentType.Left) || (prevType == PipeSegmentType.Right && newType == PipeSegmentType.Forward))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(180f, 0f, 90f);
		}
		else if ((prevType == PipeSegmentType.Forward && newType == PipeSegmentType.Left) || (prevType == PipeSegmentType.Right && newType == PipeSegmentType.Backward))
		{
			component.rotationObject.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
		}
		else if ((prevType == PipeSegmentType.Forward && newType == PipeSegmentType.Up) || (prevType == PipeSegmentType.Down && newType == PipeSegmentType.Backward))
		{
			component.rotationObject.transform.localRotation = Quaternion.identity;
		}
	}

	private GameObject GetPipeObjectForSegmentTypes(PipeSegmentType segmentType, PipeSegmentType prevType, PipeSegmentType nextType, int index, int segmentCount)
	{
		if (prevType == PipeSegmentType.None || nextType == PipeSegmentType.None)
		{
			return floorPortal;
		}
		if (nextType == segmentType && prevType == segmentType && index != 0 && index < segmentCount - 2)
		{
			return longPipe;
		}
		if (segmentType == prevType || prevType == PipeSegmentType.None)
		{
			return basePipe;
		}
		return pipeJoint;
	}

	private Quaternion GetRotationForSegmentType(PipeSegmentType segmentType, bool entrance)
	{
		if (entrance)
		{
			switch (segmentType)
			{
			case PipeSegmentType.Left:
			case PipeSegmentType.Right:
				return Quaternion.Euler(0f, 0f, 90f);
			case PipeSegmentType.Forward:
			case PipeSegmentType.Backward:
				return Quaternion.Euler(90f, 0f, 0f);
			case PipeSegmentType.Up:
			case PipeSegmentType.Down:
				return Quaternion.Euler(0f, 0f, 180f);
			}
		}
		switch (segmentType)
		{
		case PipeSegmentType.Up:
			return Quaternion.identity;
		case PipeSegmentType.Down:
			return Quaternion.Euler(0f, 0f, 180f);
		case PipeSegmentType.Left:
			return Quaternion.Euler(0f, 0f, 90f);
		case PipeSegmentType.Right:
			return Quaternion.Euler(0f, 0f, -90f);
		case PipeSegmentType.Forward:
			return Quaternion.Euler(-90f, 0f, 0f);
		case PipeSegmentType.Backward:
			return Quaternion.Euler(90f, 0f, 0f);
		default:
			Debug.LogError("Invalid PipeSegmentType");
			return Quaternion.identity;
		}
	}

	private void OffsetCurrentPosBySegmentType(ref Vector3 currentPos, PipeSegmentType segmentType, bool longSegment)
	{
		Vector3 vector = Vector3.zero;
		switch (segmentType)
		{
		case PipeSegmentType.Down:
			vector = -base.transform.up * (effectivePipeSize - 1f) * scaleFactor;
			break;
		case PipeSegmentType.Up:
			vector = base.transform.up * (effectivePipeSize - 1f) * scaleFactor;
			break;
		case PipeSegmentType.Left:
			vector = -base.transform.right * (effectivePipeSize - 1f) * scaleFactor;
			break;
		case PipeSegmentType.Right:
			vector = base.transform.right * (effectivePipeSize - 1f) * scaleFactor;
			break;
		case PipeSegmentType.Forward:
			vector = -base.transform.forward * (effectivePipeSize - 1f) * scaleFactor;
			break;
		case PipeSegmentType.Backward:
			vector = base.transform.forward * (effectivePipeSize - 1f) * scaleFactor;
			break;
		}
		currentPos += vector;
		if (longSegment)
		{
			currentPos += vector;
		}
	}

	private void DestroyOldPipes()
	{
		createdSegments.Clear();
		while (base.transform.childCount > 0)
		{
			Object.DestroyImmediate(base.transform.GetChild(0).gameObject);
		}
	}
}
