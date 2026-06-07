using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ME_PerPlatformSettings : MonoBehaviour
{
	public bool DisableOnMobiles;

	public GameObject[] Particles;

	[Range(0.1f, 1f)]
	public float ParticleBudgetForMobiles = 1f;

	private bool isMobile;

	private bool defaultOpaueColorUsing;

	private bool defaultDepthUsing;

	private void Awake()
	{
		isMobile = IsMobilePlatform();
		if (!isMobile)
		{
			return;
		}
		if (DisableOnMobiles)
		{
			GameObject[] particles = Particles;
			for (int i = 0; i < particles.Length; i++)
			{
				particles[i].SetActive(value: false);
			}
		}
		else if (ParticleBudgetForMobiles < 0.99f)
		{
			ChangeParticlesBudget(ParticleBudgetForMobiles);
		}
	}

	private void OnEnable()
	{
		Camera main = Camera.main;
		if (!(main == null))
		{
			UniversalAdditionalCameraData component = main.GetComponent<UniversalAdditionalCameraData>();
			if (component != null)
			{
				defaultOpaueColorUsing = component.requiresColorTexture;
				defaultDepthUsing = component.requiresDepthTexture;
				component.requiresColorTexture = true;
				component.requiresDepthTexture = true;
			}
		}
	}

	private void OnDisable()
	{
		Camera main = Camera.main;
		if (!(main == null))
		{
			UniversalAdditionalCameraData component = main.GetComponent<UniversalAdditionalCameraData>();
			if (component != null)
			{
				component.requiresColorTexture = defaultOpaueColorUsing;
				component.requiresDepthTexture = defaultDepthUsing;
			}
		}
	}

	private bool IsMobilePlatform()
	{
		bool result = false;
		if (Application.isMobilePlatform)
		{
			result = true;
		}
		return result;
	}

	private void ChangeParticlesBudget(float particlesMul)
	{
		GameObject[] particles = Particles;
		for (int i = 0; i < particles.Length; i++)
		{
			ParticleSystem component = particles[i].GetComponent<ParticleSystem>();
			ParticleSystem.MainModule main = component.main;
			main.maxParticles = Mathf.Max(1, (int)((float)main.maxParticles * particlesMul));
			ParticleSystem.EmissionModule emission = component.emission;
			if (!emission.enabled)
			{
				break;
			}
			ParticleSystem.MinMaxCurve rateOverTime = emission.rateOverTime;
			if (rateOverTime.constantMin > 1f)
			{
				rateOverTime.constantMin *= particlesMul;
			}
			if (rateOverTime.constantMax > 1f)
			{
				rateOverTime.constantMax *= particlesMul;
			}
			emission.rateOverTime = rateOverTime;
			ParticleSystem.MinMaxCurve rateOverDistance = emission.rateOverDistance;
			if (rateOverDistance.constantMin > 1f)
			{
				if (rateOverDistance.constantMin > 1f)
				{
					rateOverDistance.constantMin *= particlesMul;
				}
				if (rateOverDistance.constantMax > 1f)
				{
					rateOverDistance.constantMax *= particlesMul;
				}
				emission.rateOverDistance = rateOverDistance;
			}
			ParticleSystem.Burst[] array = new ParticleSystem.Burst[emission.burstCount];
			emission.GetBursts(array);
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j].minCount > 1)
				{
					array[j].minCount = (short)((float)array[j].minCount * particlesMul);
				}
				if (array[j].maxCount > 1)
				{
					array[j].maxCount = (short)((float)array[j].maxCount * particlesMul);
				}
			}
			emission.SetBursts(array);
		}
	}
}
