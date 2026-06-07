using System;
using JBooth.MicroSplat;
using UnityEngine;

namespace Assets.Dev.Scripts.Performance
{
	public class PerformanceDebugResources : ScriptableObject
	{
		[Serializable]
		public struct MicroSplatMaterialData
		{
			public MicroSplatKeywords Keywords;

			public Material Material;

			public MicroSplatPropData PropData;
		}

		[Serializable]
		public struct TerrainSpnMaterialData
		{
			public MicroSplatMaterialData Default;

			public MicroSplatMaterialData Lite;
		}

		public TerrainSpnMaterialData TerrainSpn;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void LogWarningInBuild()
		{
			if (Resources.Load<PerformanceDebugResources>("PerformanceDebugResources") != null)
			{
				Debug.LogWarning("PerformanceDebugResources scriptable asset should not be removed before commits or builds.");
			}
		}
	}
}
