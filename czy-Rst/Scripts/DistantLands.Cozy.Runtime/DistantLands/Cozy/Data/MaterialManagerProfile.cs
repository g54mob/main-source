using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Material Manager Profile", order = 361)]
	public class MaterialManagerProfile : CozyProfile
	{
		[Serializable]
		public class ModulatedValue
		{
			public enum ModulationSource
			{
				dayPercent = 0,
				yearPercent = 1,
				precipitation = 2,
				temperature = 3,
				snowAmount = 4,
				rainAmount = 5
			}

			public enum ModulationTarget
			{
				terrainLayerColor = 0,
				terrainLayerTint = 1,
				materialColor = 2,
				materialValue = 3,
				globalColor = 4,
				globalValue = 5
			}

			[Tooltip("The source that will modulate the target.")]
			public ModulationSource modulationSource;

			[Tooltip("The target type that will be modulated.")]
			public ModulationTarget modulationTarget;

			[Tooltip("The gradient that will pass a color to the modulation target based on the modulation source.")]
			public Gradient mappedGradient;

			[Tooltip("The curve that will pass a float value to the modulation target based on the modulation source.")]
			public AnimationCurve mappedCurve;

			[Tooltip("The terrain layer that this profile impacts.")]
			public TerrainLayer targetLayer;

			[Tooltip("The material that this profile impacts.")]
			public Material targetMaterial;

			public string targetVariableName;
		}

		public Texture snowTexture;

		public float snowNoiseSize = 10f;

		public Color snowColor = Color.white;

		public float puddleScale = 2f;

		[ModulatedProperty]
		public ModulatedValue[] modulatedValues;
	}
}
