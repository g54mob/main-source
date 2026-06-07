using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace StylizedGrass
{
	[AddComponentMenu("Stylized Grass/Colormap Renderer")]
	[HelpURL("http://staggart.xyz/unity/stylized-grass-shader/sgs-docs/?section=blending-with-terrain-colors")]
	[ExecuteInEditMode]
	public class GrassColorMapRenderer : MonoBehaviour
	{
		[Serializable]
		public class LayerScaleSettings
		{
			public int layerID;

			[Range(0f, 1f)]
			public float strength;
		}

		public static GrassColorMapRenderer Instance;

		public UniversalRendererData renderData;

		public GrassColorMap colorMap;

		[Tooltip("These objects can be Unity Terrains or custom Mesh Terrains. Their size can be used to automatically fit the render area")]
		public List<GameObject> terrainObjects;

		public int resIdx;

		public int resolution;

		[Tooltip("Objects set to this layer will be included in the render")]
		public LayerMask renderLayer;

		[Tooltip("Render objects on specific layers into the color map. When disabled, the terrain(s) are temporarily moved up 1000 units")]
		public bool useLayers;

		[Tooltip("Enable this option if you're using a custom terrain shader which greatly alters the terrain color (eg. global noise).\n\nWhen disabled, the terrains are temporarily rendered using an Unlit shader (based on the default Unity terrain shader)\n\nThis only applies to Unity terrain, not meshes")]
		public bool thirdPartyShader;

		public Camera renderCam;

		[NonSerialized]
		public bool showBounds;

		public List<LayerScaleSettings> layerScaleSettings;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public void AssignActiveTerrains()
		{
		}

		public void AssignVegetationStudioMeshTerrains()
		{
		}

		public void AssignChildMeshes()
		{
		}

		public void AssignColorMap()
		{
		}
	}
}
