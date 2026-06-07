using DV.CabControls;
using DV.Hazmat;
using DV.Interaction;
using DV.Simulation.Cars;
using UnityEngine;

public class Fire : MonoBehaviour, IIgnitable, IInteractionPointProvider
{
	public const int FIRE_ON = 1;

	public GameObject fireObj;

	public GameObject sparksObj;

	public GameObject helperTriggerVR;

	[SerializeField]
	private SphereCollider ignitionCollider;

	public Renderer[] emissiveRenderersAffectedByFire;

	public Light fireLight;

	public float minFireIntensity;

	public float maxFireIntensity = 1f;

	public Light fillLight;

	public float fillLightMultiplier = 0.5f;

	public Light bounceLight;

	public float bounceLightMultiplier = 0.25f;

	public AnimationCurve fireboxDoorCurve = AnimationCurve.Linear(0f, 0.05f, 1f, 1f);

	private FireboxSimController fireboxController;

	private Color fireboxCoalEmissionColor = Color.white;

	private static readonly int EmissionColorId = Shader.PropertyToID("_EmissionColor");

	private ParticleSystem fireParticleSystem;

	private ParticleSystem sparksParticleSystem;

	private const float START_3DSIZE_X_MIN = 0.8f;

	private const float START_3DSIZE_X_MAX = 1f;

	private const float START_3DSIZE_Y_MIN = 1.3f;

	private const float START_3DSIZE_Y_MAX = 2f;

	private const float START_3DSIZE_Z_MIN = 0.8f;

	private const float START_3DSIZE_Z_MAX = 1f;

	private const float EMISSION_RATE_MIN = 1f;

	private const float EMISSION_RATE_MAX = 3f;

	private const float SHAPE_POSITION_Z_MIN = -0.4f;

	private const float SHAPE_POSITION_Z_MAX = 0f;

	private const float EMISSION_LIMIT = 2f;

	private const float MAX_TILE_IGNITION_HEIGHT = 10f;

	private const float IGNITION_STRENGTH = 10f;

	private Igniter igniter;

	public bool Ignited
	{
		get
		{
			if (!igniter)
			{
				return false;
			}
			return igniter.enabled;
		}
	}

	public bool IgnitionAllowed
	{
		get
		{
			if (!Ignited && (bool)fireboxController && fireboxController.FireboxDoorOpening > 0f && fireboxController.FireboxContents > 0f)
			{
				return !LevelInfo.IsUnderWater(base.transform.position);
			}
			return false;
		}
	}

	public SphereCollider OverlapInteractionCollider => ignitionCollider;

	public Transform InteractionPoint
	{
		get
		{
			if (!(ignitionCollider != null))
			{
				return null;
			}
			return ignitionCollider.transform;
		}
	}

	private void Start()
	{
		SimController simController = TrainCar.Resolve(base.gameObject).SimController;
		fireboxController = simController.firebox;
		fireParticleSystem = fireObj.GetComponent<ParticleSystem>();
		fireParticleSystem.Stop();
		sparksParticleSystem = sparksObj.GetComponent<ParticleSystem>();
		sparksParticleSystem.Stop();
		igniter = ignitionCollider.gameObject.AddComponent<Igniter>();
		igniter.objectsRadius = ignitionCollider.radius;
		igniter.enabled = false;
		igniter.terrainClearance = 10f;
		igniter.ignitionStrength = 10f;
		igniter.SetIgnoredIgnitable(this);
		if (!VRManager.IsVREnabled())
		{
			helperTriggerVR.SetActive(value: false);
		}
	}

	private void Update()
	{
		bool isFireOn = fireboxController.IsFireOn;
		if (Ignited != isFireOn)
		{
			if (isFireOn)
			{
				Ignite(1f);
			}
			else
			{
				Extinguish();
			}
		}
		if (isFireOn)
		{
			float combustionRateNormalized = fireboxController.CombustionRateNormalized;
			ParticleSystem.MainModule main = fireParticleSystem.main;
			main.startSizeX = Mathf.Lerp(0.8f, 1f, combustionRateNormalized);
			main.startSizeY = Mathf.Lerp(1.3f, 2f, combustionRateNormalized);
			main.startSizeZ = Mathf.Lerp(0.8f, 1f, combustionRateNormalized);
			ParticleSystem.EmissionModule emission = fireParticleSystem.emission;
			emission.rateOverTime = Mathf.Lerp(1f, 3f, combustionRateNormalized);
			ParticleSystem.ShapeModule shape = fireParticleSystem.shape;
			float x = shape.position.x;
			float y = shape.position.y;
			float z = Mathf.Lerp(-0.4f, 0f, combustionRateNormalized);
			shape.position = new Vector3(x, y, z);
		}
		SetFireIntensity(fireboxController.CombustionRateNormalized);
	}

	private void Extinguish()
	{
		if (Ignited)
		{
			fireParticleSystem.Stop();
			sparksParticleSystem.Stop();
			igniter.enabled = false;
		}
	}

	private void SetFireIntensity(float percent)
	{
		Color value = fireboxCoalEmissionColor * percent * 2f;
		Renderer[] array = emissiveRenderersAffectedByFire;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].material.SetColor(EmissionColorId, value);
		}
		float num = fireboxDoorCurve.Evaluate(fireboxController.FireboxDoorOpening);
		if (fireLight != null)
		{
			if (fireLight.enabled != fireboxController.IsFireOn)
			{
				fireLight.enabled = fireboxController.IsFireOn;
			}
			if (fireLight.enabled)
			{
				fireLight.intensity = Mathf.Lerp(minFireIntensity, maxFireIntensity, percent) * ((fireLight.shadows != LightShadows.None) ? 1f : num);
			}
		}
		if (fillLight != null)
		{
			if (fillLight.enabled != fireboxController.IsFireOn)
			{
				fillLight.enabled = fireboxController.IsFireOn;
			}
			if (fillLight.enabled)
			{
				fillLight.intensity = Mathf.Lerp(minFireIntensity, maxFireIntensity, percent) * fillLightMultiplier;
			}
		}
		if (bounceLight != null)
		{
			if (bounceLight.enabled != fireboxController.IsFireOn)
			{
				bounceLight.enabled = fireboxController.IsFireOn;
			}
			if (bounceLight.enabled)
			{
				bounceLight.intensity = Mathf.Lerp(minFireIntensity, maxFireIntensity, percent) * num * bounceLightMultiplier;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Coal component = other.gameObject.GetComponent<Coal>();
		if (component != null && !component.GetComponent<ItemBase>().IsGrabbed())
		{
			fireboxController.TransferCoal(1f);
			DV_GameObjectDestructionHandler.RemoveGameObject(component.gameObject);
		}
	}

	public bool Ignite(float ignitionStrength)
	{
		if (Ignited)
		{
			return false;
		}
		fireParticleSystem.Play();
		sparksParticleSystem.Play();
		igniter.enabled = true;
		fireboxController.Ignite();
		return true;
	}

	public Transform GetTransform()
	{
		return base.transform;
	}
}
