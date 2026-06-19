using System.Collections.Generic;
using UnityEngine;

public class Segment
{
	public Inchworm.EaseType easeType;

	public GameObject easeObj;

	public List<GameObject> batchEaseObjs;

	public List<GameObject> originalEaseObjs;

	public List<Transform> originalParents;

	public bool isEasing;

	public Vector3 currentEaseStart;

	public Vector3 currentEaseEnd;

	public float startDelay;

	public float currentEaseTime;

	public float currentEaseDuration;

	public Inchworm.EaseCallback easeCallback;

	public Inchworm.GetEaseValue getEaseValue;

	public Inchworm.EasePriority priority;

	public bool useLocalPosition;
}
