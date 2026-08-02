using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	public static class GPUIBillboardUtility
	{
		public static GPUIBillboard GenerateBillboardData(GameObject prefabObject)
		{
			return GenerateBillboardData(prefabObject, 2048, 8, 0.5f, 0.5f);
		}

		public static GPUIBillboard GenerateBillboardData(GameObject prefabObject, int atlasResolution, int frameCount, float brightness, float cutoffOverride, float normalStrength = 1f)
		{
			Bounds bounds = prefabObject.GetBounds(isVertexBased: true);
			Vector2 quadSize = new Vector2(Vector2.Distance(Vector2.zero, new Vector2(bounds.size.x, bounds.size.z)), bounds.size.y);
			float yPivotOffset = 0f - bounds.min.y;
			GPUIBillboard gPUIBillboard = ScriptableObject.CreateInstance<GPUIBillboard>();
			gPUIBillboard.name = prefabObject.name + "_Billboard";
			gPUIBillboard.prefabObject = prefabObject;
			gPUIBillboard.atlasResolution = (GPUIBillboard.GPUIBillboardResolution)atlasResolution;
			gPUIBillboard.frameCount = frameCount;
			gPUIBillboard.brightness = brightness;
			gPUIBillboard.cutoffOverride = cutoffOverride;
			gPUIBillboard.normalStrength = normalStrength;
			gPUIBillboard.quadSize = quadSize;
			gPUIBillboard.yPivotOffset = yPivotOffset;
			gPUIBillboard.billboardShaderType = GPUIBillboard.GPUIBillboardShaderType.Default;
			if (GPUIRuntimeSettings.Instance.IsBuiltInRP)
			{
				gPUIBillboard.billboardShaderType = DetermineBillboardShaderType(prefabObject);
			}
			return gPUIBillboard;
		}

		private static GPUIBillboard.GPUIBillboardShaderType DetermineBillboardShaderType(GameObject prefabObject)
		{
			MeshRenderer[] componentsInChildren = prefabObject.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material[] sharedMaterials = componentsInChildren[i].sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (!(material == null) && !(material.shader == null))
					{
						if (material.shader.name.Contains("Tree Creator"))
						{
							return GPUIBillboard.GPUIBillboardShaderType.TreeCreator;
						}
						if (material.shader.name.Contains("SpeedTree"))
						{
							return GPUIBillboard.GPUIBillboardShaderType.SpeedTree;
						}
						if (material.shader.name.Contains("Tree Soft Occlusion"))
						{
							return GPUIBillboard.GPUIBillboardShaderType.SoftOcclusion;
						}
					}
				}
			}
			return GPUIBillboard.GPUIBillboardShaderType.Default;
		}

		public static bool GenerateBillboard(GPUIBillboard billboard, bool saveAsAsset = false)
		{
			if (billboard.prefabObject == null)
			{
				Debug.LogError("Can no generate billboard. Prefab is null!");
				return false;
			}
			GameObject gameObject = null;
			GameObject gameObject2 = null;
			int globalTextureMipmapLimit = QualitySettings.globalTextureMipmapLimit;
			QualitySettings.globalTextureMipmapLimit = 0;
			RenderPipelineAsset defaultRenderPipeline = GraphicsSettings.defaultRenderPipeline;
			RenderPipelineAsset renderPipeline = QualitySettings.renderPipeline;
			try
			{
				Bounds bounds = billboard.prefabObject.GetBounds(isVertexBased: true);
				int num = (int)billboard.atlasResolution / billboard.frameCount;
				billboard.albedoAtlasRT = new RenderTexture((int)billboard.atlasResolution, num, 32, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default)
				{
					enableRandomWrite = true,
					wrapMode = TextureWrapMode.Repeat,
					name = billboard.prefabObject.name + "_Albedo"
				};
				billboard.albedoAtlasRT.Create();
				billboard.normalAtlasRT = new RenderTexture((int)billboard.atlasResolution, num, 32, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default)
				{
					enableRandomWrite = true,
					wrapMode = TextureWrapMode.Repeat,
					name = billboard.prefabObject.name + "_Normal"
				};
				billboard.albedoAtlasRT.Create();
				gameObject = UnityEngine.Object.Instantiate(billboard.prefabObject, Vector3.zero, Quaternion.identity);
				gameObject.transform.localScale = Vector3.one;
				gameObject.hideFlags = HideFlags.DontSave;
				int num2 = 31;
				MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
				if (componentsInChildren == null || componentsInChildren.Length == 0)
				{
					Debug.LogError("Cannot create GPU Instancer billboard for " + billboard.prefabObject.name + " : no mesh renderers found in prefab!");
					UnityEngine.Object.DestroyImmediate(gameObject);
					return false;
				}
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.layer = num2;
					for (int j = 0; j < componentsInChildren[i].sharedMaterials.Length; j++)
					{
						Material material = componentsInChildren[i].sharedMaterials[j];
						if (material != null)
						{
							if (material.HasProperty("_MainTexture"))
							{
								material.SetTexture("_MainTex", material.GetTexture("_MainTexture"));
							}
							if (material.HasProperty("_BaseMap"))
							{
								material.SetTexture("_MainTex", material.GetTexture("_BaseMap"));
							}
							if (material.HasProperty("_BaseColor"))
							{
								material.SetColor("_Color", material.GetColor("_BaseColor"));
							}
						}
					}
				}
				Shader shader = GPUIUtility.FindShader("Hidden/GPUInstancerPro/Billboard/AlbedoBake");
				Shader shader2 = GPUIUtility.FindShader("Hidden/GPUInstancerPro/Billboard/NormalBake");
				Shader.SetGlobalFloat("_GPUIBillboardBrightness", billboard.brightness);
				Shader.SetGlobalFloat("_GPUIBillboardCutoffOverride", billboard.cutoffOverride);
				float num3 = Mathf.Max(billboard.quadSize.x, billboard.quadSize.y);
				gameObject2 = new GameObject("GPUI_BillboardCameraPivot");
				Camera camera = new GameObject().AddComponent<Camera>();
				camera.transform.SetParent(gameObject2.transform);
				camera.gameObject.hideFlags = HideFlags.DontSave;
				camera.cullingMask = 1 << num2;
				camera.clearFlags = CameraClearFlags.Color;
				camera.backgroundColor = Color.clear;
				camera.orthographic = true;
				camera.nearClipPlane = 0f;
				camera.farClipPlane = num3;
				camera.orthographicSize = num3 * 0.5f;
				camera.allowMSAA = false;
				camera.enabled = false;
				camera.renderingPath = RenderingPath.Forward;
				camera.transform.localPosition = new Vector3(0f, bounds.center.y, (0f - num3) / 2f);
				int frameCount = billboard.frameCount;
				float num4 = 360f / (float)frameCount;
				GraphicsSettings.defaultRenderPipeline = null;
				QualitySettings.renderPipeline = null;
				RenderTexture temporary = RenderTexture.GetTemporary(num, num, 32, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				temporary.enableRandomWrite = true;
				temporary.Create();
				camera.targetTexture = temporary;
				for (int k = 0; k < frameCount; k++)
				{
					gameObject2.transform.rotation = Quaternion.AngleAxis(num4 * (float)k, Vector3.up);
					camera.RenderWithShader(shader, string.Empty);
					GPUITextureUtility.CopyTextureWithComputeShader(temporary, billboard.albedoAtlasRT, k * num);
					camera.RenderWithShader(shader2, string.Empty);
					GPUITextureUtility.CopyTextureWithComputeShader(temporary, billboard.normalAtlasRT, k * num);
				}
				DilateBillboardTexture(billboard.albedoAtlasRT, frameCount, isNormal: false);
				DilateBillboardTexture(billboard.normalAtlasRT, frameCount, isNormal: true);
			}
			catch (Exception exception)
			{
				GraphicsSettings.defaultRenderPipeline = defaultRenderPipeline;
				QualitySettings.renderPipeline = renderPipeline;
				Debug.LogError("Error on billboard generation for: " + billboard.prefabObject);
				QualitySettings.globalTextureMipmapLimit = globalTextureMipmapLimit;
				if ((bool)gameObject)
				{
					UnityEngine.Object.DestroyImmediate(gameObject);
				}
				if ((bool)gameObject2)
				{
					UnityEngine.Object.DestroyImmediate(gameObject2);
				}
				if ((bool)billboard.albedoAtlasRT)
				{
					UnityEngine.Object.DestroyImmediate(billboard.albedoAtlasRT);
				}
				if ((bool)billboard.normalAtlasRT)
				{
					UnityEngine.Object.DestroyImmediate(billboard.normalAtlasRT);
				}
				Debug.LogException(exception);
			}
			GraphicsSettings.defaultRenderPipeline = defaultRenderPipeline;
			QualitySettings.renderPipeline = renderPipeline;
			QualitySettings.globalTextureMipmapLimit = globalTextureMipmapLimit;
			UnityEngine.Object.DestroyImmediate(gameObject);
			UnityEngine.Object.DestroyImmediate(gameObject2);
			return true;
		}

		public static GPUIBillboard FindBillboardAsset(GameObject prefabObject)
		{
			if (GPUIRuntimeSettings.Instance.billboardAssets != null)
			{
				foreach (GPUIBillboard billboardAsset in GPUIRuntimeSettings.Instance.billboardAssets)
				{
					if (billboardAsset != null && billboardAsset.prefabObject == prefabObject)
					{
						return billboardAsset;
					}
				}
			}
			return null;
		}

		public static void DilateBillboardTexture(RenderTexture billboardTexture, int frameCount, bool isNormal)
		{
			RenderTexture renderTexture = new RenderTexture(billboardTexture.width, billboardTexture.height, billboardTexture.depth, billboardTexture.format, RenderTextureReadWrite.Linear)
			{
				enableRandomWrite = true,
				wrapMode = billboardTexture.wrapMode,
				name = billboardTexture.name
			};
			renderTexture.Create();
			ComputeShader cS_Billboard = GPUIConstants.CS_Billboard;
			cS_Billboard.SetTexture(0, "result", renderTexture);
			cS_Billboard.SetTexture(0, "billboardSource", billboardTexture);
			cS_Billboard.SetInts("billboardSize", billboardTexture.width, billboardTexture.height);
			cS_Billboard.SetInt("frameCount", frameCount);
			cS_Billboard.SetBool("isNormal", isNormal);
			cS_Billboard.Dispatch(0, Mathf.CeilToInt((float)billboardTexture.width / (GPUIConstants.CS_THREAD_COUNT_2D * (float)frameCount)), Mathf.CeilToInt((float)billboardTexture.height / GPUIConstants.CS_THREAD_COUNT_2D), frameCount);
			GPUITextureUtility.CopyTextureWithComputeShader(renderTexture, billboardTexture, 0);
			renderTexture.DestroyRenderTexture();
		}

		public static Material CreateBillboardMaterial(Texture albedo, Texture normal, float cutOff, int frameCount, float normalStrength, GPUIBillboard.GPUIBillboardShaderType shaderType)
		{
			Material material = new Material(GetBillboardShader(shaderType));
			material.SetTexture("_AlbedoAtlas", albedo);
			material.SetTexture("_NormalAtlas", normal);
			material.SetFloat("_CutOff_GPUI", cutOff);
			material.SetInt("_FrameCount_GPUI", frameCount);
			material.SetFloat("_NormalStrength_GPUI", normalStrength);
			if (QualitySettings.billboardsFaceCameraPosition)
			{
				material.EnableKeyword("BILLBOARD_FACE_CAMERA_POS");
			}
			else
			{
				material.DisableKeyword("BILLBOARD_FACE_CAMERA_POS");
			}
			return material;
		}

		public static Material CreateBillboardMaterial(GPUIBillboard billboard)
		{
			Material material = ((!(billboard.albedoAtlasRT != null) || !(billboard.normalAtlasRT != null)) ? CreateBillboardMaterial(billboard.albedoAtlasTexture, billboard.normalAtlasTexture, billboard.cutoffOverride, billboard.frameCount, billboard.normalStrength, billboard.billboardShaderType) : CreateBillboardMaterial(billboard.albedoAtlasRT, billboard.normalAtlasRT, billboard.cutoffOverride, billboard.frameCount, billboard.normalStrength, billboard.billboardShaderType));
			if (billboard.billboardShaderType == GPUIBillboard.GPUIBillboardShaderType.SpeedTree)
			{
				Renderer componentInChildren = billboard.prefabObject.GetComponentInChildren<MeshRenderer>();
				if (componentInChildren != null)
				{
					if (componentInChildren.sharedMaterial.IsKeywordEnabled("EFFECT_HUE_VARIATION"))
					{
						material.EnableKeyword("SPDTREE_HUE_VARIATION");
						material.SetFloat("_UseSPDHueVariation", 1f);
						if (componentInChildren.sharedMaterial.HasProperty("_HueVariation"))
						{
							material.SetVector("_SPDHueVariation", componentInChildren.sharedMaterial.GetVector("_HueVariation"));
						}
						if (componentInChildren.sharedMaterial.HasProperty("_HueVariationColor"))
						{
							material.SetVector("_SPDHueVariation", componentInChildren.sharedMaterial.GetVector("_HueVariationColor"));
						}
					}
					else
					{
						material.DisableKeyword("SPDTREE_HUE_VARIATION");
					}
				}
			}
			return material;
		}

		public static Mesh GenerateQuadMesh(GPUIBillboard billboard)
		{
			Rect value = new Rect(0f, 0f, 1f, 1f);
			if (billboard.quadSize.x < billboard.quadSize.y)
			{
				value.width = billboard.quadSize.x / billboard.quadSize.y;
				value.x = (1f - value.width) / 2f;
			}
			else if (billboard.quadSize.x > billboard.quadSize.y)
			{
				value.height = billboard.quadSize.y / billboard.quadSize.x;
				value.y = (1f - value.height) / 2f;
			}
			return GPUIUtility.GenerateQuadMesh(billboard.quadSize.x, billboard.quadSize.y, value, centerPivotAtBottom: true, 0f, billboard.yPivotOffset);
		}

		public static Mesh GenerateQuadMesh(GPUIBillboard billboard, Rect uvRect)
		{
			return GPUIUtility.GenerateQuadMesh(billboard.quadSize.x, billboard.quadSize.y, uvRect, centerPivotAtBottom: true, 0f, billboard.yPivotOffset);
		}

		public static Shader GetBillboardShader(GPUIBillboard.GPUIBillboardShaderType shaderType)
		{
			return GPUIRuntimeSettings.Instance.RenderPipeline switch
			{
				GPUIRenderPipeline.URP => GPUIUtility.FindShader("GPUInstancerPro/Billboard/BillboardURP_GPUIPro"), 
				GPUIRenderPipeline.HDRP => GPUIUtility.FindShader("GPUInstancerPro/Billboard/BillboardHDRP_GPUIPro"), 
				_ => shaderType switch
				{
					GPUIBillboard.GPUIBillboardShaderType.SpeedTree => GPUIUtility.FindShader("GPUInstancerPro/Billboard/2DRendererSpeedTree"), 
					GPUIBillboard.GPUIBillboardShaderType.TreeCreator => GPUIUtility.FindShader("GPUInstancerPro/Billboard/2DRendererTreeCreator"), 
					GPUIBillboard.GPUIBillboardShaderType.SoftOcclusion => GPUIUtility.FindShader("GPUInstancerPro/Billboard/2DRendererSoftOcclusion"), 
					_ => GPUIUtility.FindShader("GPUInstancerPro/Billboard/BillboardBuiltin_GPUIPro"), 
				}, 
			};
		}
	}
}
