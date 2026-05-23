using Pathfinding.RVO;
using UnityEngine;

public class MovementFollowPath : MonoBehaviour
{
	public Transform pathParent;

	public float speed = 5f;

	private Transform[] pathPoints;

	private int currentPointIndex;

	private bool isMoving = true;

	private RVOController rvo;

	private void Start()
	{
		rvo = GetComponent<RVOController>();
		if (PerkManager.IsEquipped(PerkManager.instance.falconGodPerk))
		{
			speed *= PerkManager.instance.tauntTheFalcon_speedMultiplyer;
		}
		pathPoints = new Transform[pathParent.childCount];
		for (int i = 0; i < pathParent.childCount; i++)
		{
			pathPoints[i] = pathParent.GetChild(i);
		}
		if (pathPoints.Length != 0)
		{
			base.transform.position = pathPoints[0].position;
		}
	}

	private void Update()
	{
		if (isMoving && pathPoints.Length != 0)
		{
			MoveAlongPath();
		}
		else
		{
			rvo.velocity = Vector3.zero;
		}
	}

	private void MoveAlongPath()
	{
		if (currentPointIndex < pathPoints.Length)
		{
			Vector3 position = base.transform.position;
			Transform transform = pathPoints[currentPointIndex];
			float maxDistanceDelta = speed * Time.deltaTime;
			base.transform.position = Vector3.MoveTowards(base.transform.position, transform.position, maxDistanceDelta);
			if (Vector3.Distance(base.transform.position, transform.position) < 0.1f)
			{
				currentPointIndex++;
				if (currentPointIndex >= pathPoints.Length)
				{
					isMoving = false;
					base.transform.position = transform.position;
				}
			}
			rvo.velocity = (base.transform.position - position).normalized * speed;
		}
		else
		{
			rvo.velocity = Vector3.zero;
		}
	}
}
