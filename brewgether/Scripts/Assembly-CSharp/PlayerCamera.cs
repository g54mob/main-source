using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public float Distance;

	public float Height;

	public GameObject PlayerTarget;

	private PlayerInputController input;

	private Transform target;

	private PlayerMachine machine;

	private float yRotation;

	private SuperCharacterController controller;

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}
}
