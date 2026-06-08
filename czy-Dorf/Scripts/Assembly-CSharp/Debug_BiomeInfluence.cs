using System;
using UnityEngine;

[Serializable]
public class Debug_BiomeInfluence
{
	[SerializeField]
	private Biome biome;

	[SerializeField]
	private float influence;

	public Debug_BiomeInfluence(Biome biome, float influence)
	{
		this.biome = biome;
		this.influence = influence;
	}
}
