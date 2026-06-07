using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.TerrainResources
{
	[Serializable]
	public class ResourceSetting
	{
		public TranslationTerm Name;

		public Material ForegroundMaterial;

		public Material BackgroundMaterial;

		public Texture2D Icon;

		public Color ParticleColor;

		public Dictionary<EGameModeDifficulty, float> StartingAmount;

		public bool HideInUserInterface;

		public float ConversionRate;

		public float GetStartingAmount()
		{
			EGameModeDifficulty key = ((RuntimeGlobals.GameModeSettings != null && RuntimeGlobals.GameMode != EGameMode.Creative) ? RuntimeGlobals.GameModeSettings.Difficulty : EGameModeDifficulty.None);
			if (StartingAmount != null && StartingAmount.ContainsKey(key))
			{
				return StartingAmount[key];
			}
			return 0f;
		}
	}
}
