using UnityEngine;

public class RandomFollowStateAuthoring : MonoBehaviour
{
	public ObjectID objectToFollow;

	public float minDistanceFromObjectToFollow = 0.5f;

	public float maxDistanceFromObjectToFollow = 2f;

	public float maxWalkDuration = 3f;

	public float minIdleDuration = 0.5f;

	public float maxIdleDuration = 1f;
}
