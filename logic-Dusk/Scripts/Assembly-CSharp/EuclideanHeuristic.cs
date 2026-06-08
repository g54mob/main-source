using UnityEngine;

public class EuclideanHeuristic : IDistanceHeuristic
{
	public float Calculate(Waypoint a, Waypoint b)
	{
		return Vector3.Distance(a.transform.position, b.transform.position);
	}
}
