using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
	private const float SMOOTH_TIME = 0.3f;

	public bool LockX;

	public float offSetX;

	public float offsetY;

	public bool LockY;

	public bool LockZ;

	public bool useSmoothing;

	public Transform target;

	public GameObject hudElements;

	private Transform thisTransform;

	private Vector3 velocity;

	private bool hudActive;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}
}
