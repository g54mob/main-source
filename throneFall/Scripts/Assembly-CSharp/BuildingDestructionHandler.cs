using UnityEngine;

public class BuildingDestructionHandler : MonoBehaviour
{
	public bool shakeCamera;

	public MeshRenderer mainMesh;

	public ParticleSystem debrisParticles;

	public ParticleSystem smokeParticles;

	public AudioSource destructionSource;

	public float destructionPitchRange = 0.2f;

	private ParticleSystem.ShapeModule debrisShape;

	private ParticleSystem.ShapeModule smokeShape;

	private float debrisPlaytime = 5f;

	private float debrisClock;

	private void Awake()
	{
		debrisShape = debrisParticles.shape;
		smokeShape = smokeParticles.shape;
	}

	private void OnEnable()
	{
		if (shakeCamera && (bool)CameraController.instance)
		{
			CameraController.instance.ShakePunch();
		}
		debrisParticles.transform.position = mainMesh.transform.position;
		debrisParticles.transform.rotation = mainMesh.transform.rotation;
		smokeParticles.transform.position = mainMesh.transform.position;
		smokeParticles.transform.rotation = mainMesh.transform.rotation;
		debrisShape.scale = mainMesh.localBounds.size;
		debrisShape.position = mainMesh.localBounds.center;
		smokeShape.scale = mainMesh.localBounds.size;
		smokeShape.position = mainMesh.localBounds.center;
		debrisClock = 0f;
		debrisParticles.Play();
		destructionSource.pitch = Random.Range(1f - destructionPitchRange, 1f + destructionPitchRange);
		destructionSource.Play();
	}

	private void Update()
	{
		if (debrisParticles.isPlaying)
		{
			debrisClock += Time.deltaTime;
			if (debrisClock >= debrisPlaytime)
			{
				debrisParticles.Pause();
			}
		}
	}
}
