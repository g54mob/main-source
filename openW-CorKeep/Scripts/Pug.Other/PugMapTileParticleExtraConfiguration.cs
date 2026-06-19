using System;
using System.Collections.Generic;
using UnityEngine;

public class PugMapTileParticleExtraConfiguration : MonoBehaviour
{
	[Serializable]
	public struct ParticleBurst
	{
		public Vector2 minMaxEmitCount;

		public int targetTileCount;
	}

	public List<ParticleBurst> burstsPerTileCount;

	private void OnValidate()
	{
		ParticleSystem component = GetComponent<ParticleSystem>();
		if (!(component == null) && component.emission.burstCount != burstsPerTileCount.Count)
		{
			Debug.LogError($"Particle System has {component.emission.burstCount} bursts, " + $"but PugMapTileParticleExtraConfiguration has {burstsPerTileCount.Count} bursts configured. Please ensure they match.", base.gameObject);
		}
	}
}
