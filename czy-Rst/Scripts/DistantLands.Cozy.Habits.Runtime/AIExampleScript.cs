using DistantLands.Cozy.Data;
using UnityEngine;
using UnityEngine.AI;

public class AIExampleScript : MonoBehaviour
{
	public Transform homeTarget;

	public Transform workTarget;

	public bool isWorking = true;

	public CozyHabitProfile workHabit;

	public float wanderDistance = 5f;

	public float waitTime = 2f;

	private NavMeshAgent agent;

	private Vector3 targetPosition;

	private bool isMoving;

	public float waitTimer;

	private void OnEnable()
	{
		workHabit.onStart += StartWorking;
		workHabit.onEnd += GoHome;
	}

	private void OnDisable()
	{
		workHabit.onStart -= StartWorking;
		workHabit.onEnd -= GoHome;
	}

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		targetPosition = GetRandomPosition();
	}

	private void Update()
	{
		if (isWorking)
		{
			if (isMoving)
			{
				if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
				{
					isMoving = false;
					waitTimer = waitTime;
				}
				return;
			}
			waitTimer -= Time.deltaTime;
			if (waitTimer <= 0f)
			{
				targetPosition = GetRandomPosition();
				MoveToTargetPosition();
			}
		}
		else
		{
			agent.SetDestination(homeTarget.position);
		}
	}

	private void MoveToTargetPosition()
	{
		agent.SetDestination(targetPosition);
		isMoving = true;
	}

	private Vector3 GetRandomPosition()
	{
		Vector2 normalized = Random.insideUnitCircle.normalized;
		if (NavMesh.SamplePosition(workTarget.position + new Vector3(normalized.x, 0f, normalized.y) * wanderDistance, out var hit, wanderDistance, -1))
		{
			return hit.position;
		}
		return workTarget.position;
	}

	public void StartWorking()
	{
		isWorking = true;
	}

	public void GoHome()
	{
		isWorking = false;
	}
}
