using System;
using UnityEngine;

[Serializable]
public class tapcontrol : MonoBehaviour
{
	public GameObject cameraObject;

	public Transform cameraPivot;

	public float speed;

	public float jumpSpeed;

	public float inAirMultiplier;

	public float minimumDistanceToMove;

	public float minimumTimeUntilMove;

	public bool zoomEnabled;

	public float zoomEpsilon;

	public float zoomRate;

	public bool rotateEnabled;

	public float rotateEpsilon;

	private ZoomCamera zoomCamera;

	private Camera cam;

	private Transform thisTransform;

	private CharacterController character;

	private AnimationController animationController;

	private Vector3 targetLocation;

	private bool moving;

	private float rotationTarget;

	private float rotationVelocity;

	private Vector3 velocity;

	private ControlState state;

	private int[] fingerDown;

	private Vector2[] fingerDownPosition;

	private int[] fingerDownFrame;

	private float firstTouchTime;

	public virtual void Start()
	{
	}

	public virtual void OnEndGame()
	{
	}

	public virtual void FaceMovementDirection()
	{
	}

	public virtual void CameraControl(Touch touch0, Touch touch1)
	{
	}

	public virtual void CharacterControl()
	{
	}

	public virtual void ResetControlState()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void LateUpdate()
	{
	}
}
