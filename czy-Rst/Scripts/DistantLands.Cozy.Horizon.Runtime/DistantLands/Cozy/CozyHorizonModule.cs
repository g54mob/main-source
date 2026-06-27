using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyHorizonModule : CozyModule
	{
		private Transform layerParent;

		[CozySearchable(new string[] { })]
		public bool hideInHierarchy;

		[SerializeField]
		private MeshRenderer layerPrefab;

		[SerializeField]
		private Shader cubemapShader;

		[SerializeField]
		private Shader ribbonShader;

		[SerializeField]
		private Shader spriteShader;

		[SerializeField]
		private Shader textureSheetShader;

		private int beforeClouds;

		private int afterClouds;

		[Range(0f, 2f)]
		public float fogMultiplier = 1f;

		[Range(-1f, 1f)]
		public float heightOffset;

		[Range(0f, 360f)]
		public float rotation;

		[CozySearchable(new string[] { "horizon", "skybox", "layers" })]
		public CozyHorizonProfile horizonProfile;

		public override void InitializeModule()
		{
			base.InitializeModule();
			UpdateSkyLayers();
		}

		private void LateUpdate()
		{
			layerParent.position = base.weatherSphere.transform.position;
			layerParent.localScale = base.weatherSphere.transform.GetChild(0).localScale;
		}

		public override void CozyUpdateLoop()
		{
			if ((CozyWeather.FreezeUpdateInEditMode && !Application.isPlaying) || this == null)
			{
				return;
			}
			if (layerParent == null)
			{
				UpdateSkyLayers();
			}
			if ((layerParent.hideFlags == (HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild) && hideInHierarchy) || (layerParent.hideFlags == (HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild) && !hideInHierarchy))
			{
				UpdateSkyLayers();
			}
			if ((bool)horizonProfile)
			{
				if (horizonProfile.layers.Count != layerParent.childCount)
				{
					UpdateSkyLayers();
				}
			}
			else
			{
				UpdateSkyLayers();
			}
		}

		public void UpdateSkyLayers()
		{
			DestroyLayers();
			if (!this)
			{
				return;
			}
			layerParent = new GameObject("Horizon Layers").transform;
			layerParent.position = base.weatherSphere.transform.position;
			if (hideInHierarchy)
			{
				layerParent.gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
			}
			else
			{
				layerParent.gameObject.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
			}
			beforeClouds = 0;
			afterClouds = 0;
			if (horizonProfile != null)
			{
				for (int num = horizonProfile.layers.Count - 1; num >= 0; num--)
				{
					InitializeLayer(horizonProfile.layers[num]);
				}
			}
		}

		public void InitializeLayer(CozyHorizonProfile.HorizonLayerReference layer)
		{
			if (layerParent == null)
			{
				UpdateSkyLayers();
				return;
			}
			MeshRenderer meshRenderer = Object.Instantiate(layerPrefab, layerParent);
			meshRenderer.gameObject.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
			if ((bool)layer.texture)
			{
				meshRenderer.name = layer.texture.name;
			}
			Material material = null;
			switch (layer.layerType)
			{
			case CozyHorizonProfile.LayerType.Cubemap:
				material = new Material(cubemapShader);
				break;
			case CozyHorizonProfile.LayerType.Ribbon:
				material = new Material(ribbonShader);
				material.SetFloat("_Position", layer.placementHeight + heightOffset);
				material.SetFloat("_Height", layer.verticalScale);
				material.SetFloat("_Angle", (layer.angle / 360f + rotation / 360f) % 1f);
				material.SetFloat("_Tiling", layer.tiling);
				break;
			case CozyHorizonProfile.LayerType.TextureSheet:
				material = new Material(textureSheetShader);
				material.SetVector("_Rotation", new Vector4(layer.pitch, layer.yaw + rotation / 360f, layer.roll, 0f));
				material.SetFloat("_Size", layer.size);
				material.SetFloat("_Columns", layer.columns);
				material.SetFloat("_Rows", layer.rows);
				material.SetFloat("_Framerate", layer.framerate);
				break;
			default:
				material = new Material(spriteShader);
				material.SetVector("_Rotation", new Vector4(layer.pitch, layer.yaw + rotation / 360f, layer.roll, 0f));
				material.SetFloat("_Size", layer.size);
				break;
			}
			int num = 0;
			material.hideFlags = HideFlags.DontSave;
			material.SetColor("_Color", layer.color);
			material.SetTexture("_Texture", layer.texture);
			material.SetFloat("_FogLightAmount", layer.fogLightAmount);
			material.SetFloat("_FogAmount", layer.fogAmount * fogMultiplier);
			if (layer.placementLocation == CozyHorizonProfile.PlacementLocation.behindClouds)
			{
				beforeClouds++;
				num = 2901 + layer.renderPriorityOffset;
			}
			else
			{
				afterClouds++;
				num = 2950 + layer.renderPriorityOffset;
			}
			material.renderQueue = num;
			meshRenderer.material = material;
		}

		public void DestroyLayers()
		{
			if ((bool)layerParent)
			{
				MeshRenderer[] componentsInChildren = layerParent.GetComponentsInChildren<MeshRenderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Object.DestroyImmediate(componentsInChildren[i].sharedMaterial);
				}
				Object.DestroyImmediate(layerParent.gameObject);
			}
		}

		public override void DeinitializeModule()
		{
			DestroyLayers();
		}
	}
}
