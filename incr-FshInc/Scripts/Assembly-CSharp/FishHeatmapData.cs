using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish Heatmap", menuName = "Game/Fish Heatmap")]
public class FishHeatmapData : ScriptableObject
{
	[Serializable]
	public class FishColorMapping
	{
		public Color color;

		public Fish fish;

		[Tooltip("A multiplier for the fish's base drop chance. 2 = 2x the chance.")]
		public float probabilityMultiplier = 2f;
	}

	public Texture2D heatmapTexture;

	public List<FishColorMapping> colorMappings;
}
