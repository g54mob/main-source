using UnityEngine;

public class SpeedLines : MonoBehaviour
{
	private ParticleSystem ParticleSystem;

	private ParticleSystem.EmissionModule emission;

	private ParticleSystemRenderer ParticleRenderer;

	private ParticleSystem.MainModule ParticlesMain;

	private ParticleSystem.Particle[] particles;

	public Transform camera;

	public float minSpeed = 20f;

	public float spawnDistance = 10f;

	public float margin = 2f;

	private float spawnWidth;

	public float PositionUpdateDelay = 0.1f;

	private float PositionUpdateTimeRemaining;

	private bool isInitialized;

	private Vector3 lastpos;

	public bool UpdateAtRuntime;

	public float LinesSize = 0.02f;

	public Color LinesColor1 = new Color(1f, 1f, 1f, 0.7f);

	public Color LinesColor2 = new Color(0.7f, 0.7f, 0.7f, 0.7f);

	public int LinesCount = 500;

	public float LinesStretching = 0.035f;

	private void Start()
	{
		ParticleSystem = GetComponent<ParticleSystem>();
		ParticlesMain = ParticleSystem.main;
		emission = ParticleSystem.emission;
		ParticleRenderer = GetComponent<ParticleSystemRenderer>();
		SetParticleProperties();
		spawnWidth = spawnDistance * 2f;
		ParticleSystem.ShapeModule shape = ParticleSystem.shape;
		shape.scale = Vector3.one * spawnWidth;
		if (!camera)
		{
			camera = Camera.main.transform;
		}
	}

	private void SetParticleProperties()
	{
		ParticlesMain.startSize = LinesSize;
		ParticlesMain.startColor = new ParticleSystem.MinMaxGradient(LinesColor1, LinesColor2);
		emission.rateOverTime = LinesCount;
		ParticlesMain.maxParticles = LinesCount * 2;
		ParticleRenderer.velocityScale = LinesStretching;
	}

	private void LateUpdate()
	{
		base.transform.position = camera.position;
		if (!isInitialized)
		{
			lastpos = base.transform.position;
			isInitialized = true;
			PositionUpdateTimeRemaining = PositionUpdateDelay;
		}
		if (UpdateAtRuntime)
		{
			SetParticleProperties();
		}
		PositionUpdateTimeRemaining -= Time.deltaTime;
		if (PositionUpdateTimeRemaining <= 0f)
		{
			if ((lastpos - base.transform.position).magnitude / (PositionUpdateDelay - PositionUpdateTimeRemaining) < minSpeed)
			{
				ParticleSystem.Stop();
			}
			else
			{
				ParticleSystem.Play();
			}
			lastpos = base.transform.position;
			PositionUpdateTimeRemaining = PositionUpdateDelay;
		}
		if (particles == null || particles.Length < ParticleSystem.main.maxParticles)
		{
			particles = new ParticleSystem.Particle[ParticleSystem.main.maxParticles];
		}
		int num = ParticleSystem.GetParticles(particles);
		for (int i = 0; i < num; i++)
		{
			Vector3 position = particles[i].position;
			Vector3 vector = position - base.transform.position;
			if (Mathf.Abs(vector.x) > spawnDistance + margin)
			{
				position.x -= Mathf.Sign(vector.x) * spawnWidth;
			}
			if (Mathf.Abs(vector.y) > spawnDistance + margin)
			{
				position.y -= Mathf.Sign(vector.y) * spawnWidth;
			}
			if (Mathf.Abs(vector.z) > spawnDistance + margin)
			{
				position.z -= Mathf.Sign(vector.z) * spawnWidth;
			}
			particles[i].position = position;
		}
		ParticleSystem.SetParticles(particles, num);
	}
}
