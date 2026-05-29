using UnityEngine;

public class CameraFollowExample : MonoBehaviour
{
	public CNAbstractController RotateJoystick;

	public float PitchSpeed;

	public float YawSpeed;

	public Transform player;

	public Transform playerHead;

	public float Pitch;

	public float yaw;

	public float rotationx;

	private Transform _transformCache;

	public Transform _parentTransformCache;

	private Vector3 clampedRotation;

	public bool touching;

	public bool test;

	public GameObject playerActive;

	public GameObject senseHolder;

	private saveSensitivityData SensData;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
