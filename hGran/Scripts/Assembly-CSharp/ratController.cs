using UnityEngine;
using UnityEngine.AI;

public class ratController : MonoBehaviour
{
	public float wanderRadius;

	public float wanderTimer;

	public float waitingTimer;

	public Animator ratAnim;

	private Transform target;

	private NavMeshAgent agent;

	public float timer;

	public float Waittimer;

	public bool wait;

	public float distanceWaypoint;

	public bool ratS;

	public bool ratR;

	public AudioClip ratNoise;

	public BoxCollider boxCol;

	public virtual void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public virtual void ratStopped()
	{
	}

	public virtual void ratRunning()
	{
	}

	public virtual void getShoot()
	{
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
	{
		return default(Vector3);
	}
}
