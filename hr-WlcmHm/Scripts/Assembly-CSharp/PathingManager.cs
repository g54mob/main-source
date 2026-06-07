using System.Collections.Generic;
using UnityEngine;

public class PathingManager : MonoBehaviour
{
	[Tooltip("How many waypoints will be walked through in the INNER circle. Outside circle is  n - 1")]
	[SerializeField]
	private int changeCirclesAfterPoints;

	[Space]
	[SerializeField]
	private List<Transform> pointsInner;

	[SerializeField]
	private List<Transform> pointsOuter;

	private int currentPoints;

	public int ChangeCirclesAfterPoints => changeCirclesAfterPoints;

	private void Start()
	{
		if (pointsInner.Count != pointsOuter.Count)
		{
			Debug.LogWarning("PointsInner.Count != pointsOuter.Count. Unexpected behaviour may occur!");
		}
		currentPoints = pointsOuter.Count;
	}

	private void Update()
	{
	}

	public Transform GetPoint(int index, bool innerCircle)
	{
		if (!innerCircle)
		{
			return pointsOuter[index % pointsOuter.Count];
		}
		return pointsInner[index % pointsInner.Count];
	}
}
