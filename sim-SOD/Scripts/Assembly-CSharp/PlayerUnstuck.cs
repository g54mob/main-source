using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerUnstuck : MonoBehaviour
{
	public bool isAutomatic;

	[Range(0f, 10f)]
	public float secondsUntilUnstuck;

	[Range(0f, 200f)]
	public float maxTeleportDistance;

	[Range(0f, 100f)]
	public float ColliderSizePercent;

	private float currentAttemptedSecondsOfMovement;

	public LayerMask layerMask;

	private FirstPersonController firstPersonController;

	private CharacterController characterController;

	private Vector3 previousPosition;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void UnstuckTeleportPlayer()
	{
	}
}
