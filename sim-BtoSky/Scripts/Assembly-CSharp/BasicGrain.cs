using UnityEngine;

public class BasicGrain : MonoBehaviour
{
	public MeshRenderer casingRenderer;

	public SkinnedMeshRenderer propellantRenderer;

	public GameObject stick;

	public ParticleSystem ps;

	public AnimationCurve powerCurve;

	public float mass;

	public float thrustPow;

	public float launchDuration;

	public int stickIndex;

	public int propellantIndex;

	public int tubeIndex;

	public float multiplier;

	public MotorIngredientItem fuel;

	public MotorIngredientItem oxidizer;

	[SerializeField]
	private Material[] castingTubeMats;

	[SerializeField]
	private ParticleSystem[] pss;

	[SerializeField]
	private GameObject[] sticks;

	[SerializeField]
	private SkinnedMeshRenderer[] propellants;

	public Color liquidColor;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public Material ProMat()
	{
		return propellantRenderer.material;
	}

	public void CastingTubeSelected(int index)
	{
		if (casingRenderer != null)
		{
			tubeIndex = index;
			casingRenderer.material = castingTubeMats[index];
			switch (index)
			{
			case 0:
				mass = 0.2f;
				multiplier = 0.9f;
				break;
			case 1:
				mass = 0.25f;
				multiplier = 0.95f;
				break;
			case 2:
				mass = 0.3f;
				multiplier = 1f;
				break;
			default:
				mass = 0.35f;
				multiplier = 1.05f;
				break;
			}
		}
	}

	public void FuelSelected(MotorIngredientItem item)
	{
		fuel = item;
		if (propellantRenderer != null)
		{
			SkinnedMeshRenderer[] array = propellants;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].material = item.propellentMat;
			}
			liquidColor = item.colr;
		}
	}

	public void OxidizerSelected(MotorIngredientItem item)
	{
		oxidizer = item;
	}

	public void GrainGeometrySelected(int index)
	{
		propellantIndex = index;
		stickIndex = index;
		stick = sticks[index];
		propellantRenderer.gameObject.SetActive(value: false);
		propellantRenderer = propellants[index];
		propellantRenderer.gameObject.SetActive(value: true);
	}
}
