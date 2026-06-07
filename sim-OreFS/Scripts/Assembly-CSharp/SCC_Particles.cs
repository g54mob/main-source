using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Particles")]
public class SCC_Particles : MonoBehaviour
{
	private SCC_InputProcessor inputProcessor;

	private SCC_Network net;

	private SCC_Wheel[] wheels;

	public ParticleSystem[] exhaustParticles;

	private ParticleSystem.EmissionModule[] exhaustEmissions;

	public ParticleSystem wheelParticlePrefab;

	private List<ParticleSystem> createdParticles = new List<ParticleSystem>();

	private ParticleSystem.EmissionModule[] wheelEmissions;

	public float slip = 0.25f;

	public SCC_InputProcessor InputProcessor
	{
		get
		{
			if (inputProcessor == null)
			{
				inputProcessor = GetComponent<SCC_InputProcessor>();
			}
			return inputProcessor;
		}
	}

	private SCC_Network Net
	{
		get
		{
			if (net == null)
			{
				net = GetComponent<SCC_Network>();
			}
			return net;
		}
	}

	private void Awake()
	{
		wheels = GetComponentsInChildren<SCC_Wheel>();
		if ((bool)wheelParticlePrefab)
		{
			for (int i = 0; i < wheels.Length; i++)
			{
				ParticleSystem particleSystem = Object.Instantiate(wheelParticlePrefab, wheels[i].transform.position, wheels[i].transform.rotation, wheels[i].transform);
				createdParticles.Add(particleSystem.GetComponent<ParticleSystem>());
			}
			wheelEmissions = new ParticleSystem.EmissionModule[createdParticles.Count];
			for (int j = 0; j < createdParticles.Count; j++)
			{
				wheelEmissions[j] = createdParticles[j].emission;
			}
		}
		if (exhaustParticles != null && exhaustParticles.Length >= 1)
		{
			exhaustEmissions = new ParticleSystem.EmissionModule[exhaustParticles.Length];
			for (int k = 0; k < exhaustParticles.Length; k++)
			{
				exhaustEmissions[k] = exhaustParticles[k].emission;
			}
		}
	}

	private void Update()
	{
		WheelParticles();
		ExhaustParticles();
	}

	private void WheelParticles()
	{
		if (!wheelParticlePrefab || createdParticles.Count < 1)
		{
			return;
		}
		for (int i = 0; i < wheels.Length; i++)
		{
			wheels[i].WheelCollider.GetGroundHit(out var hit);
			if (Mathf.Abs(hit.sidewaysSlip) >= slip || Mathf.Abs(hit.forwardSlip) >= slip)
			{
				wheelEmissions[i].enabled = true;
			}
			else
			{
				wheelEmissions[i].enabled = false;
			}
		}
	}

	private void ExhaustParticles()
	{
		if (exhaustParticles == null || exhaustParticles.Length < 1)
		{
			return;
		}
		float value;
		if (Net != null && !Net.isOwned)
		{
			value = Net.syncThrottleInput;
		}
		else
		{
			if (InputProcessor == null)
			{
				return;
			}
			value = InputProcessor.inputs.throttleInput;
		}
		for (int i = 0; i < exhaustEmissions.Length; i++)
		{
			exhaustEmissions[i].rate = Mathf.Lerp(1f, 20f, Mathf.Clamp01(value));
		}
	}
}
