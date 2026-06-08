using System;
using UnityEngine;

public class AsciiParticleEmitter : MonoBehaviour
{
	public enum LayerType
	{
		Gameplay = 0,
		UI = 1
	}

	public enum ParticleSelectionType
	{
		RandomPrefab = 0,
		Sequential = 1,
		SequentialPerEmission = 2
	}

	public LayerType layerType;

	public int minParticles = 1;

	public int maxParticles = 1;

	public ParticleSelectionType particleSelection;

	public AsciiParticle[] particlePrefabs;

	private int sequentialPrefabIndex;

	public AsciiParticleLayer particleLayer { get; set; }

	public event Action<AsciiParticle[]> OnParticlesEmitted;

	public virtual void InitParticle(AsciiParticle particle)
	{
		Transform transform = base.transform;
		Vector3 position = transform.position;
		position.x += UnityEngine.Random.Range(0f, transform.localScale.x);
		position.y += UnityEngine.Random.Range(0f, transform.localScale.y);
		particle.transform.position = position;
	}

	public virtual AsciiParticle MakeParticle()
	{
		if (particlePrefabs.Length == 0)
		{
			return null;
		}
		AsciiParticle asciiParticle = null;
		if (particleSelection == ParticleSelectionType.RandomPrefab)
		{
			int num = UnityEngine.Random.Range(0, particlePrefabs.Length);
			asciiParticle = particlePrefabs[num];
		}
		else if (particleSelection == ParticleSelectionType.Sequential)
		{
			asciiParticle = particlePrefabs[sequentialPrefabIndex];
			sequentialPrefabIndex = (sequentialPrefabIndex + 1) % particlePrefabs.Length;
		}
		else
		{
			asciiParticle = particlePrefabs[sequentialPrefabIndex];
		}
		if (asciiParticle == null)
		{
			return null;
		}
		AsciiParticle asciiParticle2 = AsciiParticle.InstantiateFromPrefab(asciiParticle);
		InitParticle(asciiParticle2);
		return asciiParticle2;
	}

	public virtual void Emit()
	{
		if (particlePrefabs.Length == 0)
		{
			Utils.LogError("Cannot emit from emitter " + this?.ToString() + " because the Particle Prefab array is empty.", base.gameObject);
			return;
		}
		if (particleLayer == null)
		{
			Utils.LogError("Cannot emit from emitter " + this?.ToString() + " because the Particle Layer is missing.", base.gameObject);
			return;
		}
		int num = UnityEngine.Random.Range(minParticles, maxParticles + 1);
		AsciiParticle[] array = new AsciiParticle[num];
		for (int i = 0; i < num; i++)
		{
			AsciiParticle asciiParticle = MakeParticle();
			if ((bool)asciiParticle)
			{
				array[i] = asciiParticle;
				particleLayer.AddParticle(asciiParticle);
			}
		}
		if (this.OnParticlesEmitted != null)
		{
			this.OnParticlesEmitted(array);
		}
		if (particleSelection == ParticleSelectionType.SequentialPerEmission)
		{
			sequentialPrefabIndex = (sequentialPrefabIndex + 1) % particlePrefabs.Length;
		}
	}

	public virtual void MoveTo(Vector3 pos)
	{
		base.transform.position = pos;
	}

	protected virtual void Start()
	{
		FindParticleLayer();
	}

	public void FindParticleLayer()
	{
		if (!(particleLayer == null))
		{
			return;
		}
		if (GameStates.Singleton != null)
		{
			if (layerType == LayerType.Gameplay)
			{
				particleLayer = GameStates.Singleton.gameParticleLayer;
			}
			else
			{
				particleLayer = GameStates.Singleton.uiParticleLayer;
			}
		}
		else
		{
			particleLayer = UnityEngine.Object.FindObjectOfType<AsciiParticleLayer>();
		}
	}
}
