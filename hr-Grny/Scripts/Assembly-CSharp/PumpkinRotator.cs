using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PumpkinRotator : MonoBehaviour
{
	[SerializeField]
	private Transform playerTarget;

	[SerializeField]
	private float detectionRadius;

	[SerializeField]
	private float rotationSpeed;

	[SerializeField]
	private AudioClip detectionSound;

	[SerializeField]
	private float audioCooldown;

	private AudioSource audioSource;

	private bool isPlayerInRange;

	private float nextPlayTime;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}
}
