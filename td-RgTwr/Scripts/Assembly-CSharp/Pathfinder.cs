using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	public float distanceFromEnd = 2.1474836E+09f;

	public bool atEnd;

	public float speed = 1f;

	public Waypoint currentWaypoint;

	public bool takesSplitPaths;

	[SerializeField]
	private Enemy enemyScript;

	private void Awake()
	{
		if (Random.Range(1f, 100f) <= 50f)
		{
			takesSplitPaths = true;
		}
	}

	private void Start()
	{
		if (enemyScript == null)
		{
			enemyScript = GetComponent<Enemy>();
		}
	}

	private void FixedUpdate()
	{
		CheckWaypointDistance();
		Move();
	}

	private void Move()
	{
		Vector3 vector = currentWaypoint.transform.position - base.transform.position;
		vector.Normalize();
		base.transform.Translate(vector * speed * Time.fixedDeltaTime);
		distanceFromEnd -= speed * Time.fixedDeltaTime;
	}

	private void CheckWaypointDistance()
	{
		if (Vector3.SqrMagnitude(currentWaypoint.transform.position - base.transform.position) < 4f * speed * speed * Time.fixedDeltaTime * Time.fixedDeltaTime && !GetNewWaypoint())
		{
			atEnd = true;
			enemyScript.AtEnd();
		}
	}

	public Vector3 GetFuturePosition(float distance)
	{
		Vector3 position = base.transform.position;
		Waypoint nextWaypoint = currentWaypoint;
		float num = distance;
		int num2 = 0;
		while (num > 0f)
		{
			if (Vector3.SqrMagnitude(nextWaypoint.transform.position - position) >= num * num)
			{
				return position + (nextWaypoint.transform.position - position).normalized * num;
			}
			if (nextWaypoint.GetNextWaypoint(takesSplitPaths) == nextWaypoint)
			{
				return nextWaypoint.transform.position;
			}
			num -= Vector3.Magnitude(nextWaypoint.transform.position - position);
			position = nextWaypoint.transform.position;
			nextWaypoint = nextWaypoint.GetNextWaypoint(takesSplitPaths);
			num2++;
			if (num2 > 100)
			{
				Debug.LogError("GetFuturePosition looping too much");
				break;
			}
		}
		Debug.LogError("GetFuturePosition broken");
		return Vector3.zero;
	}

	public void Teleport(float distance)
	{
		Vector3 position = base.transform.position;
		Waypoint nextWaypoint = currentWaypoint;
		float num = distance;
		int num2 = 0;
		while (num > 0f)
		{
			if (Vector3.SqrMagnitude(nextWaypoint.transform.position - position) >= num * num)
			{
				base.transform.position = position + (nextWaypoint.transform.position - position).normalized * num;
				currentWaypoint = nextWaypoint;
				distanceFromEnd = currentWaypoint.distanceFromEnd + Vector3.Magnitude(base.transform.position - currentWaypoint.transform.position);
				return;
			}
			if (nextWaypoint.GetNextWaypoint(takesSplitPaths) == nextWaypoint)
			{
				base.transform.position = nextWaypoint.transform.position;
				currentWaypoint = nextWaypoint;
				distanceFromEnd = currentWaypoint.distanceFromEnd;
				return;
			}
			num -= Vector3.Magnitude(nextWaypoint.transform.position - position);
			position = nextWaypoint.transform.position;
			nextWaypoint = nextWaypoint.GetNextWaypoint(takesSplitPaths);
			num2++;
			if (num2 > 100)
			{
				Debug.LogError("Teleport looping too much");
				break;
			}
		}
		Debug.LogError("Teleport broken");
	}

	private bool GetNewWaypoint()
	{
		if (currentWaypoint.GetNextWaypoint(takesSplitPaths) == currentWaypoint)
		{
			return false;
		}
		distanceFromEnd = currentWaypoint.distanceFromEnd;
		currentWaypoint = currentWaypoint.GetNextWaypoint(takesSplitPaths);
		if (distanceFromEnd <= 24f)
		{
			enemyScript.CheckBattleCries(BattleCry.BattleCryTrigger.NearEnd);
		}
		return true;
	}
}
