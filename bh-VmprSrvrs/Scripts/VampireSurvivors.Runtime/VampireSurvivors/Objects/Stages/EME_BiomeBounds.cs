using System;
using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Objects.Stages
{
	public class EME_BiomeBounds : MonoBehaviour
	{
		[Serializable]
		public struct EmeraldsBiomeBounds
		{
			public Color BoundsColor;

			public float UpperLimit;

			public float LowerLimit;
		}

		[SerializeField]
		private List<EmeraldsBiomeBounds> _biomeBoundsList;

		[SerializeField]
		private float _invertedBoundsYOffset;

		private bool IsStageInverted => false;

		public EmeraldsBiomeBounds GetBoundsForBiome(BackgroundEmerald.EmeraldsBiomes biome)
		{
			return default(EmeraldsBiomeBounds);
		}

		public float GetBiomeCentreY(BackgroundEmerald.EmeraldsBiomes biome)
		{
			return 0f;
		}

		public bool TryGetBiomePositionIsInside(Vector2 position, out BackgroundEmerald.EmeraldsBiomes biome)
		{
			biome = default(BackgroundEmerald.EmeraldsBiomes);
			return false;
		}
	}
}
