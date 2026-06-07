using System;
using System.Collections.Generic;
using AwesomeTechnologies.Shaders;
using AwesomeTechnologies.Utility;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace AwesomeTechnologies.VegetationSystem
{
	public class VegetationItemModelInfo
	{
		public GameObject VegetationModel;

		public Mesh VegetationMeshLod0;

		public Mesh VegetationMeshLod1;

		public Mesh VegetationMeshLod2;

		public Mesh VegetationMeshLod3;

		public float LOD1Distance;

		public float LOD2Distance;

		public float LOD3Distance;

		public int LODCount;

		public bool LODFadePercentage;

		public bool LODFadeCrossfade;

		public int DistanceBand;

		public Material[] VegetationMaterialsLOD0;

		public Material[] VegetationMaterialsLOD1;

		public Material[] VegetationMaterialsLOD2;

		public Material[] VegetationMaterialsLOD3;

		public MeshRenderer VegetationRendererLOD0;

		public MeshRenderer VegetationRendererLOD1;

		public MeshRenderer VegetationRendererLOD2;

		public MeshRenderer VegetationRendererLOD3;

		public MaterialPropertyBlock VegetationMaterialPropertyBlockLOD0;

		public MaterialPropertyBlock VegetationMaterialPropertyBlockLOD1;

		public MaterialPropertyBlock VegetationMaterialPropertyBlockLOD2;

		public MaterialPropertyBlock VegetationMaterialPropertyBlockLOD3;

		public MaterialPropertyBlock VegetationMaterialPropertyBlockShadowsLOD0;

		public MaterialPropertyBlock VegetationMaterialPropertyBlockShadowsLOD1;

		public MaterialPropertyBlock VegetationMaterialPropertyBlockShadowsLOD2;

		public MaterialPropertyBlock VegetationMaterialPropertyBlockShadowsLOD3;

		public VegetationItemInfoPro VegetationItemInfo;

		public EnvironmentSettings EnvironmentSettings;

		public VegetationRenderSettings VegetationRenderSettings;

		public VegetationSettings VegetationSettings;

		public float BoundingSphereRadius;

		public GameObject SelectedVegetationModelLOD0;

		public GameObject SelectedVegetationModelLOD1;

		public GameObject SelectedVegetationModelLOD2;

		public GameObject SelectedVegetationModelLOD3;

		public Material BillboardMaterial;

		public List<MeshRenderer> WindSamplerMeshRendererList = new List<MeshRenderer>();

		public readonly List<CameraComputeBuffers> CameraComputeBufferList = new List<CameraComputeBuffers>();

		public readonly List<MaterialPropertyBlock> CameraBillboardMaterialPropertyBlockList = new List<MaterialPropertyBlock>();

		public NativeArray<float> HeightRuleCurveArray;

		public NativeArray<float> SteepnessRuleCurveArray;

		private float _maxVegetationSize;

		[NonSerialized]
		public IShaderController ShaderControler;

		public bool BillboardLODFadeCrossfade;

		public VegetationItemModelInfo(VegetationItemInfoPro vegetationItemInfo, EnvironmentSettings environmentSettings, List<GameObject> windSamplerList, int cameraCount, VegetationRenderSettings vegetationRenderSettings, VegetationSettings vegetationSettings)
		{
			EnvironmentSettings = environmentSettings;
			VegetationRenderSettings = vegetationRenderSettings;
			VegetationItemInfo = vegetationItemInfo;
			VegetationModel = vegetationItemInfo.VegetationPrefab;
			VegetationSettings = vegetationSettings;
			if (vegetationItemInfo.PrefabType == VegetationPrefabType.Texture)
			{
				VegetationModel = Resources.Load<GameObject>("DefaultGrassPatch");
			}
			if (VegetationModel == null)
			{
				VegetationModel = Resources.Load("MissingVegetationItemCube") as GameObject;
				Debug.LogError("The vegetation prefab of item: " + vegetationItemInfo.Name + " is missing. Please replace or delete VegetationItem.");
			}
			DistanceBand = vegetationItemInfo.GetDistanceBand();
			SelectedVegetationModelLOD0 = MeshUtils.SelectMeshObject(VegetationModel, LODLevel.LOD0);
			SelectedVegetationModelLOD1 = MeshUtils.SelectMeshObject(VegetationModel, LODLevel.LOD1);
			SelectedVegetationModelLOD2 = MeshUtils.SelectMeshObject(VegetationModel, LODLevel.LOD2);
			SelectedVegetationModelLOD3 = MeshUtils.SelectMeshObject(VegetationModel, LODLevel.LOD3);
			ShaderControler = ShaderSelector.GetShaderControler(vegetationItemInfo.ShaderName);
			if (ShaderControler != null)
			{
				ShaderControler.Settings = vegetationItemInfo.ShaderControllerSettings;
			}
			LODCount = MeshUtils.GetLODCount(VegetationModel, ShaderControler);
			CreateCameraWindSamplerItems(windSamplerList);
			if (ShaderControler != null)
			{
				LODFadePercentage = ShaderControler.Settings.LODFadePercentage;
				LODFadeCrossfade = ShaderControler.Settings.LODFadeCrossfade;
			}
			VegetationMeshLod0 = GetVegetationMesh(VegetationModel, LODLevel.LOD0);
			VegetationMeshLod1 = GetVegetationMesh(VegetationModel, LODLevel.LOD1);
			VegetationMeshLod2 = GetVegetationMesh(VegetationModel, LODLevel.LOD2);
			VegetationMeshLod3 = GetVegetationMesh(VegetationModel, LODLevel.LOD3);
			VegetationRendererLOD0 = SelectedVegetationModelLOD0.GetComponentInChildren<MeshRenderer>();
			VegetationMaterialsLOD0 = CreateMaterials(VegetationRendererLOD0.sharedMaterials, 0);
			VegetationRendererLOD1 = SelectedVegetationModelLOD1.GetComponentInChildren<MeshRenderer>();
			VegetationMaterialsLOD1 = CreateMaterials(VegetationRendererLOD1.sharedMaterials, 1);
			VegetationRendererLOD2 = SelectedVegetationModelLOD2.GetComponentInChildren<MeshRenderer>();
			VegetationMaterialsLOD2 = CreateMaterials(VegetationRendererLOD2.sharedMaterials, 2);
			VegetationRendererLOD3 = SelectedVegetationModelLOD3.GetComponentInChildren<MeshRenderer>();
			VegetationMaterialsLOD3 = CreateMaterials(VegetationRendererLOD3.sharedMaterials, 3);
			if (vegetationItemInfo.PrefabType == VegetationPrefabType.Texture)
			{
				Shader shader = Shader.Find("AwesomeTechnologies/Release/Grass/Grass");
				MaterialUtility.ChangeShader(VegetationMaterialsLOD0, shader);
				MaterialUtility.ChangeShader(VegetationMaterialsLOD1, shader);
				MaterialUtility.ChangeShader(VegetationMaterialsLOD2, shader);
				MaterialUtility.ChangeShader(VegetationMaterialsLOD3, shader);
				SetGrassTexture(VegetationMaterialsLOD0, vegetationItemInfo.VegetationTexture);
				SetGrassTexture(VegetationMaterialsLOD1, vegetationItemInfo.VegetationTexture);
				SetGrassTexture(VegetationMaterialsLOD2, vegetationItemInfo.VegetationTexture);
				SetGrassTexture(VegetationMaterialsLOD3, vegetationItemInfo.VegetationTexture);
			}
			VegetationMaterialPropertyBlockLOD0 = new MaterialPropertyBlock();
			VegetationRendererLOD0.GetPropertyBlock(VegetationMaterialPropertyBlockLOD0);
			if (VegetationMaterialPropertyBlockLOD0 == null)
			{
				VegetationMaterialPropertyBlockLOD0 = new MaterialPropertyBlock();
			}
			VegetationMaterialPropertyBlockLOD1 = new MaterialPropertyBlock();
			VegetationRendererLOD1.GetPropertyBlock(VegetationMaterialPropertyBlockLOD1);
			if (VegetationMaterialPropertyBlockLOD1 == null)
			{
				VegetationMaterialPropertyBlockLOD1 = new MaterialPropertyBlock();
			}
			VegetationMaterialPropertyBlockLOD2 = new MaterialPropertyBlock();
			VegetationRendererLOD2.GetPropertyBlock(VegetationMaterialPropertyBlockLOD2);
			if (VegetationMaterialPropertyBlockLOD2 == null)
			{
				VegetationMaterialPropertyBlockLOD2 = new MaterialPropertyBlock();
			}
			VegetationMaterialPropertyBlockLOD3 = new MaterialPropertyBlock();
			VegetationRendererLOD3.GetPropertyBlock(VegetationMaterialPropertyBlockLOD3);
			if (VegetationMaterialPropertyBlockLOD3 == null)
			{
				VegetationMaterialPropertyBlockLOD3 = new MaterialPropertyBlock();
			}
			VegetationMaterialPropertyBlockShadowsLOD0 = new MaterialPropertyBlock();
			VegetationRendererLOD0.GetPropertyBlock(VegetationMaterialPropertyBlockShadowsLOD0);
			if (VegetationMaterialPropertyBlockShadowsLOD0 == null)
			{
				VegetationMaterialPropertyBlockShadowsLOD0 = new MaterialPropertyBlock();
			}
			VegetationMaterialPropertyBlockShadowsLOD1 = new MaterialPropertyBlock();
			VegetationRendererLOD1.GetPropertyBlock(VegetationMaterialPropertyBlockShadowsLOD1);
			if (VegetationMaterialPropertyBlockShadowsLOD1 == null)
			{
				VegetationMaterialPropertyBlockShadowsLOD1 = new MaterialPropertyBlock();
			}
			VegetationMaterialPropertyBlockShadowsLOD2 = new MaterialPropertyBlock();
			VegetationRendererLOD2.GetPropertyBlock(VegetationMaterialPropertyBlockShadowsLOD2);
			if (VegetationMaterialPropertyBlockShadowsLOD2 == null)
			{
				VegetationMaterialPropertyBlockShadowsLOD2 = new MaterialPropertyBlock();
			}
			VegetationMaterialPropertyBlockShadowsLOD3 = new MaterialPropertyBlock();
			VegetationRendererLOD3.GetPropertyBlock(VegetationMaterialPropertyBlockShadowsLOD3);
			if (VegetationMaterialPropertyBlockShadowsLOD3 == null)
			{
				VegetationMaterialPropertyBlockShadowsLOD3 = new MaterialPropertyBlock();
			}
			LOD1Distance = GetLODDistance(VegetationModel, 0);
			LOD2Distance = GetLODDistance(VegetationModel, 1);
			LOD3Distance = GetLODDistance(VegetationModel, 2);
			vegetationItemInfo.Bounds = MeshUtils.CalculateBoundsInstantiate(VegetationModel);
			float num = Mathf.Max(vegetationItemInfo.ScaleMultiplier.x, vegetationItemInfo.ScaleMultiplier.y, vegetationItemInfo.ScaleMultiplier.z);
			BoundingSphereRadius = vegetationItemInfo.Bounds.extents.magnitude * VegetationItemInfo.MaxScale * VegetationItemInfo.YScale * num + 5f;
			CreateCameraBuffers(cameraCount);
			HeightRuleCurveArray = new NativeArray<float>(4096, Allocator.Persistent);
			UpdateHeightRuleCurve();
			SteepnessRuleCurveArray = new NativeArray<float>(4096, Allocator.Persistent);
			UpdateSteepnessRuleCurve();
			if (vegetationItemInfo.VegetationType == VegetationType.Tree)
			{
				CreateBillboardMaterial();
			}
		}

		public void CreateCameraWindSamplerItems(List<GameObject> windSamplerList)
		{
			if (ShaderControler != null && ShaderControler.Settings.SampleWind)
			{
				for (int i = 0; i <= windSamplerList.Count - 1; i++)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(SelectedVegetationModelLOD0);
					gameObject.hideFlags = HideFlags.HideAndDontSave;
					gameObject.name = "VegetationSystemRenderer";
					gameObject.transform.SetParent(windSamplerList[i].transform);
					gameObject.transform.localPosition = new Vector3(0f, 0f, 3f);
					gameObject.transform.localRotation = Quaternion.identity;
					CleanVegetationObject(gameObject);
					MeshRenderer componentInChildren = gameObject.GetComponentInChildren<MeshRenderer>();
					WindSamplerMeshRendererList.Add(componentInChildren);
				}
			}
		}

		public void CreateCameraBuffers(int cameraCount)
		{
			DisposeCameraBuffers();
			CameraBillboardMaterialPropertyBlockList.Clear();
			for (int i = 0; i <= cameraCount - 1; i++)
			{
				CameraComputeBuffers item = new CameraComputeBuffers(VegetationMeshLod0, VegetationMeshLod1, VegetationMeshLod2, VegetationMeshLod3);
				CameraComputeBufferList.Add(item);
				CameraBillboardMaterialPropertyBlockList.Add(new MaterialPropertyBlock());
			}
		}

		private void SetGrassTexture(Material[] materials, Texture2D texture)
		{
			for (int i = 0; i <= materials.Length - 1; i++)
			{
				materials[i].SetTexture("_MainTex", texture);
			}
		}

		private void UpdateBillboardMaterial()
		{
			if ((bool)BillboardMaterial)
			{
				BillboardMaterial.SetFloat("_Cutoff", VegetationItemInfo.BillboardCutoff);
				if (ShaderControler != null)
				{
					BillboardLODFadeCrossfade = ShaderControler.Settings.LODFadeCrossfade;
				}
				if (ShaderControler != null && ShaderControler.Settings.DynamicHUE)
				{
					Color colorPropertyValue = ShaderControler.Settings.GetColorPropertyValue("FoliageHue");
					BillboardMaterial.SetColor("_HueVariation", colorPropertyValue);
					BillboardMaterial.SetInt("_UseSpeedTreeHueVariation", 1);
				}
				else
				{
					BillboardMaterial.SetColor("_HueVariation", new Color(1f, 0.5f, 0f, 0.09765625f));
					BillboardMaterial.SetInt("_UseSpeedTreeHueVariation", 0);
				}
				BillboardMaterial.EnableKeyword("LOD_FADE_CROSSFADE");
				BillboardMaterial.SetColor("_Color", VegetationItemInfo.BillboardTintColor);
				BillboardMaterial.SetFloat("_Brightness", VegetationItemInfo.BillboardBrightness);
				BillboardMaterial.SetFloat("_SnowAmount", Mathf.Clamp01(EnvironmentSettings.SnowAmount));
				BillboardMaterial.SetColor("_SnowColor", EnvironmentSettings.BillboardSnowColor);
				BillboardMaterial.SetFloat("_SnowBlendFactor", EnvironmentSettings.SnowBlendFactor);
				BillboardMaterial.SetFloat("_SnowBrightness", EnvironmentSettings.SnowBrightness);
				BillboardMaterial.SetFloat("_BillboardWindSpeed", VegetationItemInfo.BillboardWindSpeed);
				BillboardMaterial.SetFloat("_Smoothness", VegetationItemInfo.BillboardSmoothness);
				BillboardMaterial.SetFloat("_NormalStrength", VegetationItemInfo.BillboardNormalStrength);
				BillboardMaterial.SetFloat("_ShadowOffset", VegetationItemInfo.BillboardShadowOffset);
				float num = Mathf.Max(VegetationItemInfo.Bounds.extents.x, VegetationItemInfo.Bounds.extents.y, VegetationItemInfo.Bounds.extents.z);
				BillboardMaterial.SetFloat("_DepthBoundsSize", num * 2f);
				BillboardMaterial.SetFloat("_FadeDistance", VegetationItemInfo.BillboardFadeDistance);
				if (VegetationItemInfo.UseBillboardFade)
				{
					BillboardMaterial.SetInt("_UseFade", 1);
				}
				else
				{
					BillboardMaterial.SetInt("_UseFade", 0);
				}
				if (VegetationItemInfo.BillboardRenderMode == BillboardRenderMode.Standard)
				{
					BillboardMaterial.SetFloat("_Metallic", VegetationItemInfo.BillboardMetallic);
				}
				else
				{
					BillboardMaterial.SetFloat("_Specular", VegetationItemInfo.BillboardSpecular);
				}
				BillboardMaterial.SetFloat("_Occlusion", VegetationItemInfo.BillboardOcclusion);
				if (VegetationRenderSettings.ShowLODDebug)
				{
					BillboardMaterial.SetColor("_LODDebugColor", GetLODColor(4));
				}
				else
				{
					BillboardMaterial.SetColor("_LODDebugColor", Color.white);
				}
			}
		}

		private void CreateBillboardMaterial()
		{
			if (VegetationItemInfo.BillboardRenderMode == BillboardRenderMode.Standard)
			{
				BillboardMaterial = new Material(Shader.Find("AwesomeTechnologies/Release/Billboards/BillboardsMetallic"))
				{
					enableInstancing = true,
					hideFlags = HideFlags.DontSave
				};
			}
			else
			{
				BillboardMaterial = new Material(Shader.Find("AwesomeTechnologies/Release/Billboards/BetterShaders_GroupBillboards"))
				{
					enableInstancing = true,
					hideFlags = HideFlags.DontSave
				};
			}
			BillboardMaterial.SetTexture("_MainTex", VegetationItemInfo.BillboardTexture);
			BillboardMaterial.SetTexture("_Bump", VegetationItemInfo.BillboardNormalTexture);
			BillboardMaterial.SetInt("_InRow", BillboardAtlasRenderer.GetBillboardQualityColumnCount(VegetationItemInfo.BillboardQuality));
			BillboardMaterial.SetInt("_InCol", BillboardAtlasRenderer.GetBillboardQualityRowCount(VegetationItemInfo.BillboardQuality));
			BillboardMaterial.SetInt("_CullDistance", 340);
			BillboardMaterial.SetInt("_FarCullDistance", 5000);
			if (ShaderControler != null && ShaderControler.Settings.DynamicHUE)
			{
				BillboardMaterial.SetInt("_UseSpeedTreeHueVariation", 1);
			}
			else
			{
				BillboardMaterial.SetInt("_UseSpeedTreeHueVariation", 0);
			}
			if (ShaderControler != null)
			{
				if (ShaderControler.Settings.BillboardSnow)
				{
					BillboardMaterial.EnableKeyword("USE_SNOW");
				}
				else
				{
					BillboardMaterial.DisableKeyword("USE_SNOW");
				}
				if (ShaderControler.Settings.BillboardHDWind)
				{
					BillboardMaterial.EnableKeyword("USE_HDWIND");
				}
				else
				{
					BillboardMaterial.DisableKeyword("USE_HDWIND");
				}
			}
			if (VegetationItemInfo.OverrideShaderController)
			{
				if (VegetationItemInfo.UseBillboardSnow)
				{
					BillboardMaterial.EnableKeyword("USE_SNOW");
				}
				else
				{
					BillboardMaterial.DisableKeyword("USE_SNOW");
				}
			}
			if (VegetationItemInfo.OverrideShaderController)
			{
				if (VegetationItemInfo.UseBillboardWind)
				{
					BillboardMaterial.EnableKeyword("USE_HDWIND");
				}
				else
				{
					BillboardMaterial.DisableKeyword("USE_HDWIND");
				}
			}
			UpdateBillboardMaterial();
		}

		private void DisposeCameraBuffers()
		{
			for (int i = 0; i <= CameraComputeBufferList.Count - 1; i++)
			{
				CameraComputeBufferList[i].DestroyComputeBuffers();
			}
			CameraComputeBufferList.Clear();
		}

		public void Dispose()
		{
			DestroyMaterials(VegetationMaterialsLOD0);
			DestroyMaterials(VegetationMaterialsLOD1);
			DestroyMaterials(VegetationMaterialsLOD2);
			DestroyMaterials(VegetationMaterialsLOD3);
			DisposeCameraBuffers();
			if (HeightRuleCurveArray.IsCreated)
			{
				HeightRuleCurveArray.Dispose();
			}
			if (SteepnessRuleCurveArray.IsCreated)
			{
				SteepnessRuleCurveArray.Dispose();
			}
		}

		public void UpdateHeightRuleCurve()
		{
			float[] array = VegetationItemInfo.HeightRuleCurve.GenerateCurveArray(4096);
			HeightRuleCurveArray.CopyFrom(array);
		}

		public void UpdateSteepnessRuleCurve()
		{
			float[] array = VegetationItemInfo.SteepnessRuleCurve.GenerateCurveArray(4096);
			SteepnessRuleCurveArray.CopyFrom(array);
		}

		private static void DestroyMaterials(Material[] materials)
		{
			for (int i = 0; i <= materials.Length - 1; i++)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(materials[i]);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(materials[i]);
				}
			}
		}

		private static Mesh GetVegetationMesh(GameObject rootVegetationModel, LODLevel lodLevel)
		{
			MeshFilter componentInChildren = MeshUtils.SelectMeshObject(rootVegetationModel, lodLevel).GetComponentInChildren<MeshFilter>();
			if ((bool)componentInChildren.sharedMesh)
			{
				return componentInChildren.sharedMesh;
			}
			return new Mesh();
		}

		private static float GetLODDistance(GameObject rootVegetationModel, int lodIndex)
		{
			LODGroup componentInChildren = rootVegetationModel.GetComponentInChildren<LODGroup>();
			if ((bool)componentInChildren)
			{
				LOD[] lODs = componentInChildren.GetLODs();
				if (lodIndex >= 0 && lodIndex < lODs.Length)
				{
					return componentInChildren.size / lODs[lodIndex].screenRelativeTransitionHeight;
				}
			}
			return -1f;
		}

		private Material[] CreateMaterials(Material[] sharedMaterials, int lodIndex)
		{
			Material[] array = new Material[sharedMaterials.Length];
			for (int i = 0; i <= sharedMaterials.Length - 1; i++)
			{
				if ((bool)sharedMaterials[i])
				{
					array[i] = new Material(sharedMaterials[i]);
					if (array[i].shader.name == "Hidden/Nature/Tree Creator Leaves Optimized")
					{
						array[i].shader = Shader.Find("Nature/Tree Creator Leaves");
					}
				}
				else
				{
					array[i] = new Material(Shader.Find("Standard"))
					{
						enableInstancing = true
					};
				}
				RefreshMaterial(array[i], lodIndex);
			}
			return array;
		}

		private void RefreshMaterial(Material material, int lodIndex)
		{
			if (material.HasProperty("_CullFarEnd"))
			{
				float value = VegetationItemInfo.RenderDistanceFactor * VegetationSettings.PlantDistance;
				material.SetFloat("_CullFarEnd", value);
			}
			material.enableInstancing = true;
			if (VegetationItemInfo.VegetationRenderMode == VegetationRenderMode.Normal)
			{
				material.DisableKeyword("LOD_FADE_CROSSFADE");
				material.DisableKeyword("LOD_FADE_PERCENTAGE");
			}
			if (VegetationItemInfo.EnableCrossFade)
			{
				material.EnableKeyword("LOD_FADE_CROSSFADE");
			}
			else
			{
				material.DisableKeyword("LOD_FADE_CROSSFADE");
			}
			if (material.HasProperty("_LODDebugColor"))
			{
				if (VegetationRenderSettings.ShowLODDebug)
				{
					material.SetColor("_LODDebugColor", GetLODColor(lodIndex));
				}
				else
				{
					material.SetColor("_LODDebugColor", Color.white);
				}
			}
			ShaderControler?.UpdateMaterial(material, EnvironmentSettings);
		}

		private Color GetLODColor(int lodIndex)
		{
			switch (lodIndex)
			{
			case 0:
				return Color.green;
			case 1:
				return Color.red;
			case 2:
				return Color.blue;
			case 3:
				return Color.cyan;
			case 4:
				return Color.yellow;
			default:
				return Color.white;
			}
		}

		public void RefreshMaterials()
		{
			for (int i = 0; i <= VegetationMaterialsLOD0.Length - 1; i++)
			{
				RefreshMaterial(VegetationMaterialsLOD0[i], 0);
			}
			for (int j = 0; j <= VegetationMaterialsLOD1.Length - 1; j++)
			{
				RefreshMaterial(VegetationMaterialsLOD1[j], 1);
			}
			for (int k = 0; k <= VegetationMaterialsLOD2.Length - 1; k++)
			{
				RefreshMaterial(VegetationMaterialsLOD2[k], 2);
			}
			for (int l = 0; l <= VegetationMaterialsLOD3.Length - 1; l++)
			{
				RefreshMaterial(VegetationMaterialsLOD3[l], 3);
			}
			UpdateBillboardMaterial();
		}

		public Mesh GetLODMesh(int lodIndex)
		{
			switch (lodIndex)
			{
			case 0:
				return VegetationMeshLod0;
			case 1:
				return VegetationMeshLod1;
			case 2:
				return VegetationMeshLod2;
			case 3:
				return VegetationMeshLod3;
			default:
				return null;
			}
		}

		public Material[] GetLODMaterials(int lodIndex)
		{
			switch (lodIndex)
			{
			case 0:
				return VegetationMaterialsLOD0;
			case 1:
				return VegetationMaterialsLOD1;
			case 2:
				return VegetationMaterialsLOD2;
			case 3:
				return VegetationMaterialsLOD3;
			default:
				return null;
			}
		}

		public MaterialPropertyBlock GetLODMaterialPropertyBlock(int lodIndex)
		{
			switch (lodIndex)
			{
			case 0:
				return VegetationMaterialPropertyBlockLOD0;
			case 1:
				return VegetationMaterialPropertyBlockLOD1;
			case 2:
				return VegetationMaterialPropertyBlockLOD2;
			case 3:
				return VegetationMaterialPropertyBlockLOD3;
			default:
				return null;
			}
		}

		public ComputeBuffer GetLODVisibleBuffer(int lodIndex, int cameraIndex, bool shadows)
		{
			if (shadows)
			{
				switch (lodIndex)
				{
				case 0:
					return CameraComputeBufferList[cameraIndex].ShadowBufferLOD0;
				case 1:
					return CameraComputeBufferList[cameraIndex].ShadowBufferLOD1;
				case 2:
					return CameraComputeBufferList[cameraIndex].ShadowBufferLOD2;
				case 3:
					return CameraComputeBufferList[cameraIndex].ShadowBufferLOD3;
				default:
					return null;
				}
			}
			switch (lodIndex)
			{
			case 0:
				return CameraComputeBufferList[cameraIndex].VisibleBufferLOD0;
			case 1:
				return CameraComputeBufferList[cameraIndex].VisibleBufferLOD1;
			case 2:
				return CameraComputeBufferList[cameraIndex].VisibleBufferLOD2;
			case 3:
				return CameraComputeBufferList[cameraIndex].VisibleBufferLOD3;
			default:
				return null;
			}
		}

		public List<ComputeBuffer> GetLODArgsBufferList(int lodIndex, int cameraIndex, bool shadows)
		{
			if (shadows)
			{
				switch (lodIndex)
				{
				case 0:
					return CameraComputeBufferList[cameraIndex].ShadowArgsBufferMergedLOD0List;
				case 1:
					return CameraComputeBufferList[cameraIndex].ShadowArgsBufferMergedLOD1List;
				case 2:
					return CameraComputeBufferList[cameraIndex].ShadowArgsBufferMergedLOD2List;
				case 3:
					return CameraComputeBufferList[cameraIndex].ShadowArgsBufferMergedLOD3List;
				default:
					return null;
				}
			}
			switch (lodIndex)
			{
			case 0:
				return CameraComputeBufferList[cameraIndex].ArgsBufferMergedLOD0List;
			case 1:
				return CameraComputeBufferList[cameraIndex].ArgsBufferMergedLOD1List;
			case 2:
				return CameraComputeBufferList[cameraIndex].ArgsBufferMergedLOD2List;
			case 3:
				return CameraComputeBufferList[cameraIndex].ArgsBufferMergedLOD3List;
			default:
				return null;
			}
		}

		private void CleanVegetationObject(GameObject go)
		{
			Mesh sharedMesh = new Mesh
			{
				bounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(2f, 2f, 2f))
			};
			MeshFilter[] componentsInChildren = go.GetComponentsInChildren<MeshFilter>();
			for (int i = 0; i <= componentsInChildren.Length - 1; i++)
			{
				componentsInChildren[i].sharedMesh = sharedMesh;
			}
			Rigidbody[] componentsInChildren2 = go.GetComponentsInChildren<Rigidbody>();
			for (int j = 0; j <= componentsInChildren2.Length - 1; j++)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(componentsInChildren2[j]);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(componentsInChildren2[j]);
				}
			}
			Collider[] componentsInChildren3 = go.GetComponentsInChildren<Collider>();
			for (int k = 0; k <= componentsInChildren3.Length - 1; k++)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(componentsInChildren3[k]);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(componentsInChildren3[k]);
				}
			}
			BillboardRenderer[] componentsInChildren4 = go.GetComponentsInChildren<BillboardRenderer>();
			for (int l = 0; l <= componentsInChildren4.Length - 1; l++)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(componentsInChildren4[l]);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(componentsInChildren4[l]);
				}
			}
			NavMeshObstacle[] componentsInChildren5 = go.GetComponentsInChildren<NavMeshObstacle>();
			for (int m = 0; m <= componentsInChildren5.Length - 1; m++)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(componentsInChildren5[m]);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(componentsInChildren5[m]);
				}
			}
			Transform[] componentsInChildren6 = go.GetComponentsInChildren<Transform>();
			for (int n = 0; n <= componentsInChildren6.Length - 1; n++)
			{
				if (componentsInChildren6[n].name.Contains("Billboard"))
				{
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(componentsInChildren6[n].gameObject);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(componentsInChildren6[n].gameObject);
					}
				}
			}
			componentsInChildren6 = go.GetComponentsInChildren<Transform>();
			for (int num = 0; num <= componentsInChildren6.Length - 1; num++)
			{
				if (componentsInChildren6[num].name.Contains("CollisionObject"))
				{
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(componentsInChildren6[num].gameObject);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(componentsInChildren6[num].gameObject);
					}
				}
			}
			LODGroup[] componentsInChildren7 = go.GetComponentsInChildren<LODGroup>();
			for (int num2 = 0; num2 <= componentsInChildren7.Length - 1; num2++)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(componentsInChildren7[num2]);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(componentsInChildren7[num2]);
				}
			}
			MeshRenderer[] componentsInChildren8 = go.GetComponentsInChildren<MeshRenderer>();
			for (int num3 = 0; num3 <= componentsInChildren8.Length - 1; num3++)
			{
				componentsInChildren8[num3].shadowCastingMode = ShadowCastingMode.Off;
				componentsInChildren8[num3].receiveShadows = false;
				componentsInChildren8[num3].lightProbeUsage = LightProbeUsage.Off;
				if (componentsInChildren8[num3].sharedMaterials.Length > 1)
				{
					Material[] sharedMaterials = new Material[1] { Resources.Load("WindSampler", typeof(Material)) as Material };
					componentsInChildren8[num3].sharedMaterials = sharedMaterials;
				}
			}
		}
	}
}
