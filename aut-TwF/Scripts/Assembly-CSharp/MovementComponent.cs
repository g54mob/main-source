using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour
{
	public delegate void OnMoveToPosition(Vector3 position);

	private static int DEFAULT_AGENT_PRIORITY = 50;

	[SerializeField]
	private float speed = 5f;

	[SerializeField]
	private float rotationSpeed = 640f;

	private int movementEnabled;

	protected CharacterController characterController;

	protected NavMeshAgent navMeshAgent;

	private Coroutine lookAtCoroutine;

	public virtual float Speed
	{
		get
		{
			return speed;
		}
		set
		{
			speed = value;
			if ((bool)NavMeshAgent)
			{
				NavMeshAgent.speed = speed;
			}
		}
	}

	public float RotationSpeed
	{
		get
		{
			return rotationSpeed;
		}
		set
		{
			rotationSpeed = value;
			if ((bool)NavMeshAgent)
			{
				NavMeshAgent.angularSpeed = rotationSpeed;
			}
		}
	}

	public virtual bool MovementEnabled
	{
		get
		{
			return movementEnabled == 0;
		}
		set
		{
			if (value)
			{
				movementEnabled = Mathf.Max(0, movementEnabled - 1);
			}
			else
			{
				movementEnabled++;
			}
			if (!MovementEnabled)
			{
				StopMovement();
			}
		}
	}

	public NavMeshAgent NavMeshAgent => navMeshAgent;

	public event OnMoveToPosition onMoveToPosition;

	protected virtual void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		characterController = GetComponent<CharacterController>();
		if ((bool)NavMeshAgent)
		{
			NavMeshAgent.speed = speed;
			NavMeshAgent.angularSpeed = RotationSpeed;
			if ((bool)characterController)
			{
				NavMeshAgent.height = characterController.height;
			}
		}
	}

	protected virtual void Start()
	{
	}

	public virtual void MoveToPosition(Vector3 position, bool synchronous = false)
	{
		if (!MovementEnabled)
		{
			return;
		}
		if ((bool)NavMeshAgent)
		{
			NavMeshAgent.stoppingDistance = 0f;
			if (synchronous)
			{
				NavMeshPath path = new NavMeshPath();
				NavMeshAgent.CalculatePath(position, path);
				NavMeshAgent.SetPath(path);
				this.onMoveToPosition?.Invoke(NavMeshAgent.pathEndPosition);
			}
			else
			{
				navMeshAgent.SetDestination(position);
				this.onMoveToPosition?.Invoke(position);
			}
		}
		else
		{
			Move(position - base.transform.position, Time.deltaTime);
		}
	}

	public virtual void MoveToGameObject(GameObject gameObject)
	{
		if (!MovementEnabled)
		{
			return;
		}
		if ((bool)NavMeshAgent)
		{
			if ((bool)gameObject.GetComponent<CharacterController>())
			{
				NavMeshAgent.stoppingDistance = gameObject.GetComponent<CharacterController>().radius + NavMeshAgent.radius + 1f;
			}
			NavMeshAgent.SetDestination(gameObject.transform.position);
		}
		else
		{
			Move(gameObject.transform.position - base.transform.position, Time.deltaTime);
		}
	}

	public virtual void Move(Vector3 direction, float tickTime, bool normalizeDirection = true)
	{
		if (MovementEnabled)
		{
			if (normalizeDirection)
			{
				direction.Normalize();
			}
			if ((bool)characterController)
			{
				MoveWithCharacterController(direction);
			}
			else
			{
				MoveWithTransform(direction);
			}
			if (direction != Vector3.zero)
			{
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.LookRotation(direction), RotationSpeed * Time.unscaledDeltaTime);
			}
		}
	}

	public virtual void StopMovement()
	{
		if ((bool)NavMeshAgent && NavMeshAgent.isActiveAndEnabled)
		{
			NavMeshAgent.ResetPath();
		}
		if ((bool)characterController)
		{
			Move(Vector3.zero, Time.deltaTime);
		}
	}

	public virtual void SetAgentPriority(int priority)
	{
		if ((bool)NavMeshAgent)
		{
			NavMeshAgent.avoidancePriority = priority;
		}
	}

	public void ResetAgentPriority()
	{
		if ((bool)NavMeshAgent)
		{
			NavMeshAgent.avoidancePriority = DEFAULT_AGENT_PRIORITY;
		}
	}

	public virtual bool IsMoving()
	{
		bool flag = false;
		if ((bool)NavMeshAgent)
		{
			flag = NavMeshAgent.velocity.sqrMagnitude > 0.001f;
		}
		if (!flag && (bool)characterController)
		{
			flag = characterController.velocity.sqrMagnitude > 0.001f;
		}
		return flag;
	}

	public virtual Vector3 GetVelocity()
	{
		Vector3 vector = Vector3.zero;
		if ((bool)NavMeshAgent)
		{
			vector = NavMeshAgent.velocity;
		}
		if (vector == Vector3.zero && (bool)characterController)
		{
			return characterController.velocity;
		}
		return vector;
	}

	public void LookAt(GameObject target)
	{
		Vector3 dir = target.transform.position - base.transform.position;
		LookAt(dir);
	}

	public void LookAt(Vector3 dir)
	{
		dir.y = 0f;
		this.StartCoroutineCheckingVar(LookAtCoroutine(dir.normalized), ref lookAtCoroutine);
	}

	private IEnumerator LookAtCoroutine(Vector3 dir)
	{
		while (!IsMoving() && Vector3.Angle(base.transform.forward, dir) > 0.5f)
		{
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
			yield return null;
		}
		lookAtCoroutine = null;
	}

	private void MoveWithCharacterController(Vector3 direction)
	{
		if (MovementEnabled)
		{
			characterController.SimpleMove(direction * speed);
		}
	}

	private void MoveWithTransform(Vector3 direction)
	{
		if (MovementEnabled)
		{
			base.transform.position = base.transform.position + direction * speed * Time.unscaledDeltaTime;
		}
	}
}
