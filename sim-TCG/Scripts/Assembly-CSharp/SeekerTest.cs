using Pathfinding;
using UnityEngine;

public class SeekerTest : MonoBehaviour
{
	public Transform targetPosition;

	private Seeker seeker;

	public Path path;

	public float speed = 2f;

	public float nextWaypointDistance = 3f;

	private int currentWaypoint;

	public float repathRate = 0.5f;

	private float lastRepath = float.NegativeInfinity;

	public bool reachedEndOfPath;

	public void Start()
	{
		seeker = GetComponent<Seeker>();
		seeker.StartPath(base.transform.position, targetPosition.position, OnPathComplete);
	}

	public void OnPathComplete(Path p)
	{
		Debug.Log("A path was calculated. Did it fail with an error? " + p.error);
		p.Claim(this);
		if (!p.error)
		{
			if (path != null)
			{
				path.Release(this);
			}
			path = p;
			currentWaypoint = 0;
		}
		else
		{
			p.Release(this);
		}
	}

	public void Update()
	{
		if (Time.time > lastRepath + repathRate && seeker.IsDone())
		{
			lastRepath = Time.time;
			seeker.StartPath(base.transform.position, targetPosition.position, OnPathComplete);
		}
		if (path == null)
		{
			return;
		}
		reachedEndOfPath = false;
		float num;
		while (true)
		{
			num = Vector3.Distance(base.transform.position, path.vectorPath[currentWaypoint]);
			if (!(num < nextWaypointDistance))
			{
				break;
			}
			if (currentWaypoint + 1 < path.vectorPath.Count)
			{
				currentWaypoint++;
				continue;
			}
			reachedEndOfPath = true;
			break;
		}
		float num2 = (reachedEndOfPath ? Mathf.Sqrt(num / nextWaypointDistance) : 1f);
		_ = (path.vectorPath[currentWaypoint] - base.transform.position).normalized * speed * num2;
		base.transform.position = Vector3.MoveTowards(base.transform.position, path.vectorPath[currentWaypoint], speed);
	}
}
