using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class FPSControllerNEW : MonoBehaviour
{
	public Joystick moveTouchPad;

	public Joystick rotateTouchPad;

	public Transform cameraPivot;

	public float forwardSpeed;

	public float backwardSpeed;

	public float sidestepSpeed;

	public float jumpSpeed;

	public float inAirMultiplier;

	public Vector2 rotationSpeed;

	public float tiltPositiveYAxis;

	public float tiltNegativeYAxis;

	public float tiltXAxisMinimum;

	private Transform thisTransform;

	private CharacterController character;

	private Vector3 cameraVelocity;

	private Vector3 velocity;

	private bool canJump;

	public GameObject rotateControll;

	public GameObject footstepScriptHolder;

	public GameObject headBobAnimHolder;

	public bool day2;

	public bool day3;

	public bool playerCrouch;

	public bool PlayerIsGrounded;

	public bool fallTimerStarted;

	public float timeInAir;

	public GameObject soundHolder;

	public GameObject FallsoundHolder;

	public GameObject granny;

	public GameObject Player;

	public GameObject checkGround;

	public int startingPitch;

	public virtual void Start()
	{
	}

	public virtual void OnEndGame()
	{
	}

	public virtual void FixedUpdate()
	{
	}
}
