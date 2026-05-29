using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class PlayerRelativeControl : MonoBehaviour
{
	public Joystick moveJoystick;

	public Joystick rotateJoystick;

	public Transform cameraPivot;

	public float forwardSpeed;

	public float backwardSpeed;

	public float sidestepSpeed;

	public float jumpSpeed;

	public float inAirMultiplier;

	public Vector2 rotationSpeed;

	private Transform thisTransform;

	private CharacterController character;

	private AnimationController animationController;

	private Vector3 cameraVelocity;

	private Vector3 velocity;

	public virtual void Start()
	{
	}

	public virtual void OnEndGame()
	{
	}

	public virtual void Update()
	{
	}
}
