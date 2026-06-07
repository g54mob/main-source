using System;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[Serializable]
	public class Options
	{
		[Serializable]
		public class Settings
		{
			public enum TerrainSearchMethod
			{
				Hierarchy = 0,
				AllInScene = 1
			}

			[Tooltip("When working with multiple scenes, it can be useful to have MicroVerse find all terrains in all scenes instead of only working with the ones below it in the hierarchy")]
			public TerrainSearchMethod terrainSearchMethod;

			[Tooltip("Some terrain shaders need the terrain layers to stay in sync between terrains - this can increase the number of splat maps needed by increasing the texture count when some textures are only used on some terrains")]
			public bool keepLayersInSync;

			[Tooltip("Unity's API for updating terrains is really slow, MicroVerse tries to sneak these in on things like mouse up events. This will control how many terrains it attempts to sync back on such events.")]
			public int maxHeightSaveBackPerFrame = 1;

			[Tooltip("Unity terrain rendering is really slow, so when working with a large number of terrains, MicroVerse can automatically cull them at a certain distance to improve performance")]
			public bool useSceneCulling;

			[Range(100f, 10000f)]
			public float sceneTerrainCullingDistance = 2500f;

			[Range(100f, 10000f)]
			public float sceneVegetationCullingDistance = 1500f;

			[Range(100f, 24000f)]
			public float sceneCameraCullingDistance = 12000f;
		}

		[Serializable]
		public class Colors
		{
			public bool drawStampPreviews = true;

			public Color heightStampColor = Color.gray;

			public Color textureStampColor = Color.clear;

			public Color treeStampColor = Color.green;

			public Color detailStampColor = Color.yellow;

			public Color occluderStampColor = Color.magenta;

			public Color copyStampColor = Color.cyan;

			public Color pasteStampColor = Color.cyan * 0.8f;

			public Color maskStampColor = Color.red;

			public Color objectStampColor = Color.blue;

			public Color ambientAreaColor = new Color(0f, 0f, 1f, 0.5f);

			public Color noisePreviewColor = new Color(1f, 0f, 0f, 0.8f);

			public Color filterPreviewColor = new Color(0f, 0f, 1f, 0.8f);
		}

		public Settings settings = new Settings();

		public Colors colors = new Colors();
	}
}
