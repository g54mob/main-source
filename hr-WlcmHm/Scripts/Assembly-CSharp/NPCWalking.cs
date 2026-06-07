using DG.Tweening;
using UnityEngine;

public class NPCWalking : MonoBehaviour
{
	[SerializeField]
	private Transform[] walkPoints;

	[SerializeField]
	private float lerpDuration;

	[HideInInspector]
	public bool canWalk = true;

	private Animator anim;

	private int currentPointIndex;

	private float timeElapsed;

	private Vector3 startPosition;

	private Vector3 targetPosition;

	private bool isRotating;

	public NPCBaseController AI;

	private void Start()
	{
		anim = GetComponent<Animator>();
		if (AI != null)
		{
			AI.Activity = EActivity.WALKING;
		}
		startPosition = base.transform.position;
		targetPosition = walkPoints[currentPointIndex].position;
		canWalk = true;
	}

	private void Update()
	{
		if (canWalk)
		{
			WalkToNextPoint();
		}
	}

	private void WalkToNextPoint()
	{
		if (!isRotating)
		{
			RotateTowardsDestination(walkPoints[currentPointIndex]);
			isRotating = true;
		}
		base.transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / lerpDuration);
		timeElapsed += Time.deltaTime;
		if (Vector3.Distance(base.transform.position, targetPosition) < 0.1f)
		{
			timeElapsed = 0f;
			startPosition = base.transform.position;
			currentPointIndex = (currentPointIndex + 1) % walkPoints.Length;
			targetPosition = walkPoints[currentPointIndex].position;
			if (currentPointIndex < walkPoints.Length)
			{
				isRotating = false;
			}
		}
	}

	private void RotateTowardsDestination(Transform point)
	{
		Vector3 normalized = (point.position - base.transform.position).normalized;
		normalized.y = 0f;
		Quaternion endValue = Quaternion.LookRotation(normalized);
		base.transform.DORotateQuaternion(endValue, 1f);
	}
}
