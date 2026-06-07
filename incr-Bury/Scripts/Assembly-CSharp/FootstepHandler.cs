using UnityEngine;

public class FootstepHandler : MonoBehaviour
{
	[Header("References")]
	public Transform playerTransform;

	private PlayerMovement playerMovement;

	[Header("Settings")]
	public float stepDistance = 2f;

	public AudioSource audioSource;

	public float minVelocity = 0.1f;

	[SerializeField]
	private float sfxVolumeModifier;

	private Vector3 lastStepPos;

	private PlayerMovement.AirState _prevAirState;

	private float prevFrameVeloMag;

	private void Awake()
	{
		playerMovement = GetComponent<PlayerMovement>();
	}

	private void Start()
	{
		lastStepPos = playerTransform.position;
	}

	private void Update()
	{
		Vector3 vector = new Vector3(playerTransform.position.x - lastStepPos.x, 0f, playerTransform.position.z - lastStepPos.z);
		if ((vector.magnitude > minVelocity * Time.deltaTime || prevFrameVeloMag < 0.5f) && Vector3.Distance(playerTransform.position, lastStepPos) >= stepDistance && playerMovement.airState == PlayerMovement.AirState.Grounded)
		{
			PlayFootstep();
			lastStepPos = playerTransform.position;
		}
		if (_prevAirState == PlayerMovement.AirState.Airborne && playerMovement.airState == PlayerMovement.AirState.Grounded)
		{
			PlayFootstep();
		}
		_prevAirState = playerMovement.airState;
		prevFrameVeloMag = vector.magnitude;
	}

	private void PlayFootstep()
	{
		audioSource.pitch = Random.Range(0.95f, 1.05f);
		if (GameManager.Singleton.playHardSurfaceFootsteps)
		{
			int index = Random.Range(0, AudioManager.Singleton.sfx_Footsteps_HardSurface.Count);
			audioSource.PlayOneShot(AudioManager.Singleton.sfx_Footsteps_HardSurface[index], AudioManager.Singleton.sfxVolume * sfxVolumeModifier);
		}
		else
		{
			int index2 = Random.Range(0, AudioManager.Singleton.sfx_Footsteps.Count);
			audioSource.PlayOneShot(AudioManager.Singleton.sfx_Footsteps[index2], AudioManager.Singleton.sfxVolume * sfxVolumeModifier);
		}
	}
}
