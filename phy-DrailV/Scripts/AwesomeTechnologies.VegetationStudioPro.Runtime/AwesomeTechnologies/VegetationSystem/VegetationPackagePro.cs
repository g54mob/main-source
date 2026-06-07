using System;
using System.Collections.Generic;
using AwesomeTechnologies.Shaders;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Vegetation.Masks;
using Unity.Collections;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class VegetationPackagePro : ScriptableObject
	{
		public string PackageName = "No name";

		[SerializeField]
		public List<VegetationItemInfoPro> VegetationInfoList = new List<VegetationItemInfoPro>();

		public List<TerrainTextureSettings> TerrainTextureSettingsList = new List<TerrainTextureSettings>();

		public List<TerrainTextureInfo> TerrainTextureList = new List<TerrainTextureInfo>();

		public List<TextureMaskGroup> TextureMaskGroupList = new List<TextureMaskGroup>();

		public int TerrainTextureCount;

		public BiomeType BiomeType;

		public int BiomeSortOrder = 1;

		public bool GenerateBiomeSplamap = true;

		public void InitPackage()
		{
		}

		public string GetVegetationItemID(string assetGuid)
		{
			for (int i = 0; i <= VegetationInfoList.Count - 1; i++)
			{
				if (VegetationInfoList[i].VegetationGuid == assetGuid)
				{
					return VegetationInfoList[i].VegetationItemID;
				}
			}
			return "";
		}

		public void ResizeTerrainTextureList(int newCount)
		{
			if (newCount <= 0)
			{
				TerrainTextureList.Clear();
				return;
			}
			while (TerrainTextureList.Count > newCount)
			{
				TerrainTextureList.RemoveAt(TerrainTextureList.Count - 1);
			}
		}

		public void RegenerateVegetationItemIDs()
		{
			for (int i = 0; i <= VegetationInfoList.Count - 1; i++)
			{
				VegetationInfoList[i].VegetationItemID = Guid.NewGuid().ToString();
			}
		}

		public void ResizeTerrainTextureSettingsList(int newCount)
		{
			if (newCount <= 0)
			{
				TerrainTextureSettingsList.Clear();
				return;
			}
			while (TerrainTextureSettingsList.Count > newCount)
			{
				TerrainTextureSettingsList.RemoveAt(TerrainTextureSettingsList.Count - 1);
			}
		}

		public void DeleteTextureMaskGroup(TextureMaskGroup textureMaskGroup)
		{
			TextureMaskGroupList.Remove(textureMaskGroup);
			for (int i = 0; i <= VegetationInfoList.Count - 1; i++)
			{
				VegetationItemInfoPro vegetationItemInfoPro = VegetationInfoList[i];
				for (int num = vegetationItemInfoPro.TextureMaskIncludeRuleList.Count - 1; num >= 0; num--)
				{
					if (vegetationItemInfoPro.TextureMaskIncludeRuleList[num].TextureMaskGroupID == textureMaskGroup.TextureMaskGroupID)
					{
						vegetationItemInfoPro.TextureMaskIncludeRuleList.RemoveAt(num);
					}
				}
				if (vegetationItemInfoPro.TextureMaskIncludeRuleList.Count == 0)
				{
					vegetationItemInfoPro.UseTextureMaskIncludeRules = false;
				}
			}
		}

		public TextureMaskGroup GetTextureMaskGroup(string textureMaskGroupID)
		{
			for (int i = 0; i <= TextureMaskGroupList.Count - 1; i++)
			{
				if (TextureMaskGroupList[i].TextureMaskGroupID == textureMaskGroupID)
				{
					return TextureMaskGroupList[i];
				}
			}
			return null;
		}

		public VegetationItemInfoPro GetVegetationInfo(string id)
		{
			for (int i = 0; i <= VegetationInfoList.Count - 1; i++)
			{
				if (VegetationInfoList[i].VegetationItemID == id)
				{
					return VegetationInfoList[i];
				}
			}
			return null;
		}

		public void PrepareNativeArrayTextureCurves()
		{
			for (int i = 0; i <= TerrainTextureSettingsList.Count - 1; i++)
			{
				if (TerrainTextureSettingsList[i].HeightCurveArray.IsCreated)
				{
					TerrainTextureSettingsList[i].HeightCurveArray.Dispose();
				}
				TerrainTextureSettingsList[i].HeightCurveArray = new NativeArray<float>(4096, Allocator.Persistent);
				if (!ValidateAnimationCurve(TerrainTextureSettingsList[i].TextureHeightCurve))
				{
					TerrainTextureSettingsList[i].TextureHeightCurve = CreateResetAnimationCurve();
				}
				TerrainTextureSettingsList[i].HeightCurveArray.CopyFrom(TerrainTextureSettingsList[i].TextureHeightCurve.GenerateCurveArray(4096));
				if (TerrainTextureSettingsList[i].SteepnessCurveArray.IsCreated)
				{
					TerrainTextureSettingsList[i].SteepnessCurveArray.Dispose();
				}
				TerrainTextureSettingsList[i].SteepnessCurveArray = new NativeArray<float>(4096, Allocator.Persistent);
				if (!ValidateAnimationCurve(TerrainTextureSettingsList[i].TextureSteepnessCurve))
				{
					TerrainTextureSettingsList[i].TextureSteepnessCurve = CreateResetAnimationCurve();
				}
				TerrainTextureSettingsList[i].SteepnessCurveArray.CopyFrom(TerrainTextureSettingsList[i].TextureSteepnessCurve.GenerateCurveArray(4096));
			}
		}

		public bool ValidateAnimationCurve(AnimationCurve curve)
		{
			if (float.IsNaN(curve.Evaluate(0.5f)))
			{
				return false;
			}
			return true;
		}

		private AnimationCurve CreateResetAnimationCurve()
		{
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve.AddKey(0f, 0.5f);
			animationCurve.AddKey(1f, 0.5f);
			return animationCurve;
		}

		public void DisposeNativeArrayTextureCurves()
		{
			for (int i = 0; i <= TerrainTextureSettingsList.Count - 1; i++)
			{
				if (TerrainTextureSettingsList[i].HeightCurveArray.IsCreated)
				{
					TerrainTextureSettingsList[i].HeightCurveArray.Dispose();
				}
				if (TerrainTextureSettingsList[i].SteepnessCurveArray.IsCreated)
				{
					TerrainTextureSettingsList[i].SteepnessCurveArray.Dispose();
				}
			}
		}

		public void LoadDefaultTextures()
		{
			if (TerrainTextureCount == 0)
			{
				return;
			}
			if (TerrainTextureList.Count == 0)
			{
				TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture1", "TerrainTextures/TerrainTexture1_n", new Vector2(15f, 15f)));
				TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture2", "TerrainTextures/TerrainTexture2_n", new Vector2(15f, 15f)));
				TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture3", "TerrainTextures/TerrainTexture3_n", new Vector2(15f, 15f)));
				TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture4", "TerrainTextures/TerrainTexture4_n", new Vector2(15f, 15f)));
			}
			if (TerrainTextureCount == 4)
			{
				return;
			}
			if (TerrainTextureList.Count == 4)
			{
				TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture5", "TerrainTextures/TerrainTexture5_n", new Vector2(15f, 15f)));
				TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture6", "TerrainTextures/TerrainTexture6_n", new Vector2(15f, 15f)));
				TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture7", "TerrainTextures/TerrainTexture7_n", new Vector2(15f, 15f)));
				TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture8", "TerrainTextures/TerrainTexture8_n", new Vector2(15f, 15f)));
			}
			if (TerrainTextureCount != 8)
			{
				if (TerrainTextureList.Count == 8)
				{
					TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture9", "TerrainTextures/TerrainTexture9_n", new Vector2(15f, 15f)));
					TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture10", "TerrainTextures/TerrainTexture10_n", new Vector2(15f, 15f)));
					TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture11", "TerrainTextures/TerrainTexture11_n", new Vector2(15f, 15f)));
					TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture12", "TerrainTextures/TerrainTexture12_n", new Vector2(15f, 15f)));
				}
				if (TerrainTextureCount != 12 && TerrainTextureList.Count == 12)
				{
					TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture13", "TerrainTextures/TerrainTexture13_n", new Vector2(15f, 15f)));
					TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture14", "TerrainTextures/TerrainTexture14_n", new Vector2(15f, 15f)));
					TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture15", "TerrainTextures/TerrainTexture15_n", new Vector2(15f, 15f)));
					TerrainTextureList.Add(LoadTexture("TerrainTextures/TerrainTexture16", "TerrainTextures/TerrainTexture16_n", new Vector2(15f, 15f)));
				}
			}
		}

		public void SetupTerrainTextureSettings()
		{
			if (TerrainTextureSettingsList == null)
			{
				TerrainTextureSettingsList = new List<TerrainTextureSettings>();
			}
			if (TerrainTextureSettingsList.Count < TerrainTextureCount)
			{
				for (int i = TerrainTextureSettingsList.Count; i <= TerrainTextureCount - 1; i++)
				{
					TerrainTextureSettings terrainTextureSettings = new TerrainTextureSettings
					{
						TextureHeightCurve = new AnimationCurve()
					};
					terrainTextureSettings.TextureHeightCurve.AddKey(0f, 1f);
					terrainTextureSettings.TextureHeightCurve.AddKey(1f, 1f);
					terrainTextureSettings.TextureSteepnessCurve = new AnimationCurve();
					terrainTextureSettings.TextureSteepnessCurve.AddKey(0f, 0.5f);
					terrainTextureSettings.TextureSteepnessCurve.AddKey(1f, 0.5f);
					terrainTextureSettings.UseNoise = false;
					terrainTextureSettings.NoiseScale = 5f;
					terrainTextureSettings.TextureWeight = 1f;
					terrainTextureSettings.Enabled = i < 4;
					terrainTextureSettings.TextureLayer = i;
					TerrainTextureSettingsList.Add(terrainTextureSettings);
				}
				VegetationPackagePro vegetationPackagePro = (VegetationPackagePro)Resources.Load("DefaultSplatmapRulesPackage", typeof(VegetationPackagePro));
				if ((bool)vegetationPackagePro && TerrainTextureSettingsList.Count > 3 && vegetationPackagePro.TerrainTextureSettingsList.Count > 3)
				{
					TerrainTextureSettingsList[0].TextureHeightCurve = new AnimationCurve(vegetationPackagePro.TerrainTextureSettingsList[0].TextureHeightCurve.keys);
					TerrainTextureSettingsList[0].TextureSteepnessCurve = new AnimationCurve(vegetationPackagePro.TerrainTextureSettingsList[0].TextureSteepnessCurve.keys);
					TerrainTextureSettingsList[1].TextureHeightCurve = new AnimationCurve(vegetationPackagePro.TerrainTextureSettingsList[1].TextureHeightCurve.keys);
					TerrainTextureSettingsList[1].TextureSteepnessCurve = new AnimationCurve(vegetationPackagePro.TerrainTextureSettingsList[1].TextureSteepnessCurve.keys);
					TerrainTextureSettingsList[2].TextureHeightCurve = new AnimationCurve(vegetationPackagePro.TerrainTextureSettingsList[2].TextureHeightCurve.keys);
					TerrainTextureSettingsList[2].TextureSteepnessCurve = new AnimationCurve(vegetationPackagePro.TerrainTextureSettingsList[2].TextureSteepnessCurve.keys);
					TerrainTextureSettingsList[3].TextureHeightCurve = new AnimationCurve(vegetationPackagePro.TerrainTextureSettingsList[3].TextureHeightCurve.keys);
					TerrainTextureSettingsList[3].TextureSteepnessCurve = new AnimationCurve(vegetationPackagePro.TerrainTextureSettingsList[3].TextureSteepnessCurve.keys);
				}
			}
		}

		private static TerrainTextureInfo LoadTexture(string textureName, string normalTextureName, Vector2 uv)
		{
			TerrainTextureInfo terrainTextureInfo = new TerrainTextureInfo
			{
				TileSize = uv,
				Offset = new Vector2(0f, 0f)
			};
			if (textureName != "")
			{
				terrainTextureInfo.Texture = Resources.Load(textureName) as Texture2D;
			}
			if (normalTextureName != "")
			{
				terrainTextureInfo.TextureNormals = Resources.Load(normalTextureName) as Texture2D;
			}
			return terrainTextureInfo;
		}

		public void RefreshVegetationItemPrefab(VegetationItemInfoPro vegetationItemInfoPro)
		{
			GameObject prefab = vegetationItemInfoPro.VegetationPrefab;
			if (vegetationItemInfoPro.PrefabType == VegetationPrefabType.Texture)
			{
				prefab = Resources.Load<GameObject>("DefaultGrassPatch");
				if (vegetationItemInfoPro.VegetationTexture != null)
				{
					vegetationItemInfoPro.Name = vegetationItemInfoPro.VegetationTexture.name;
				}
			}
			else if (vegetationItemInfoPro.VegetationPrefab != null)
			{
				vegetationItemInfoPro.Name = vegetationItemInfoPro.VegetationPrefab.name;
			}
			string shaderName = ShaderSelector.GetShaderName(prefab);
			Material[] vegetationItemMaterials = ShaderSelector.GetVegetationItemMaterials(prefab);
			IShaderController shaderControler = ShaderSelector.GetShaderControler(shaderName);
			shaderControler.CreateDefaultSettings(vegetationItemMaterials);
			vegetationItemInfoPro.BillboardRenderMode = shaderControler.Settings.BillboardRenderMode;
			vegetationItemInfoPro.ShaderName = shaderName;
			vegetationItemInfoPro.ShaderControllerSettings = shaderControler.Settings;
			if (vegetationItemInfoPro.VegetationType == VegetationType.Tree)
			{
				GenerateBillboard(vegetationItemInfoPro.VegetationItemID);
			}
			if (Application.platform == RuntimePlatform.WindowsEditor && shaderControler.Settings.SupportsInstantIndirect)
			{
				vegetationItemInfoPro.VegetationRenderMode = VegetationRenderMode.InstancedIndirect;
			}
		}

		public void AddVegetationItem(Texture2D texture, VegetationType vegetationType, bool enableRuntimeSpawn = true, string newVegetationItemID = "")
		{
			VegetationItemInfoPro vegetationItemInfoPro = new VegetationItemInfoPro
			{
				VegetationPrefab = null,
				VegetationTexture = texture,
				PrefabType = VegetationPrefabType.Texture,
				VegetationType = vegetationType
			};
			if (texture != null)
			{
				vegetationItemInfoPro.Name = texture.name;
			}
			vegetationItemInfoPro.VegetationItemID = ((newVegetationItemID == "") ? Guid.NewGuid().ToString() : newVegetationItemID);
			vegetationItemInfoPro.Init();
			vegetationItemInfoPro.EnableRuntimeSpawn = enableRuntimeSpawn;
			bool flag = UnityEngine.Random.Range(0f, 1f) > 0.5f;
			vegetationItemInfoPro.Seed = UnityEngine.Random.Range(0, 100);
			vegetationItemInfoPro.UseNoiseCutoff = false;
			vegetationItemInfoPro.NoiseDensityInverse = flag;
			vegetationItemInfoPro.NoiseCutoffInverse = flag;
			vegetationItemInfoPro.NoiseScaleInverse = flag;
			switch (vegetationType)
			{
			case VegetationType.Grass:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(0.9f, 1.3f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.FollowTerrainScale;
				break;
			case VegetationType.Plant:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(1.7f, 3f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.RotateY;
				break;
			case VegetationType.Objects:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(3.3f, 4.5f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.RotateY;
				break;
			case VegetationType.Tree:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(7f, 9f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.RotateY;
				break;
			case VegetationType.LargeObjects:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(8f, 13f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.RotateY;
				break;
			}
			GameObject prefab = Resources.Load<GameObject>("DefaultGrassPatch");
			string shaderName = ShaderSelector.GetShaderName(prefab);
			Material[] vegetationItemMaterials = ShaderSelector.GetVegetationItemMaterials(prefab);
			IShaderController shaderControler = ShaderSelector.GetShaderControler(shaderName);
			shaderControler.CreateDefaultSettings(vegetationItemMaterials);
			vegetationItemInfoPro.BillboardRenderMode = shaderControler.Settings.BillboardRenderMode;
			vegetationItemInfoPro.ShaderName = shaderName;
			vegetationItemInfoPro.ShaderControllerSettings = shaderControler.Settings;
			VegetationInfoList.Add(vegetationItemInfoPro);
			if (Application.platform == RuntimePlatform.WindowsEditor && shaderControler.Settings.SupportsInstantIndirect)
			{
				vegetationItemInfoPro.VegetationRenderMode = VegetationRenderMode.InstancedIndirect;
			}
		}

		public void AddVegetationItem(GameObject go, VegetationType vegetationType, bool enableRuntimeSpawn = true, string newVegetationItemID = "")
		{
			VegetationItemInfoPro vegetationItemInfoPro = new VegetationItemInfoPro
			{
				VegetationPrefab = go,
				PrefabType = VegetationPrefabType.Mesh,
				VegetationType = vegetationType
			};
			if (go != null)
			{
				vegetationItemInfoPro.Name = go.name;
			}
			vegetationItemInfoPro.VegetationItemID = ((newVegetationItemID == "") ? Guid.NewGuid().ToString() : newVegetationItemID);
			vegetationItemInfoPro.Init();
			vegetationItemInfoPro.EnableRuntimeSpawn = enableRuntimeSpawn;
			bool flag = UnityEngine.Random.Range(0f, 1f) > 0.5f;
			vegetationItemInfoPro.Seed = UnityEngine.Random.Range(0, 100);
			vegetationItemInfoPro.UseNoiseCutoff = false;
			vegetationItemInfoPro.NoiseDensityInverse = flag;
			vegetationItemInfoPro.NoiseCutoffInverse = flag;
			vegetationItemInfoPro.NoiseScaleInverse = flag;
			switch (vegetationType)
			{
			case VegetationType.Grass:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(0.9f, 1.3f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.FollowTerrainScale;
				break;
			case VegetationType.Plant:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(1.7f, 3f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.RotateY;
				break;
			case VegetationType.Objects:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(3.3f, 4.5f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.RotateY;
				break;
			case VegetationType.Tree:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(7f, 9f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.RotateY;
				break;
			case VegetationType.LargeObjects:
				vegetationItemInfoPro.SampleDistance = UnityEngine.Random.Range(8f, 13f);
				vegetationItemInfoPro.Rotation = VegetationRotationType.RotateY;
				break;
			}
			string shaderName = ShaderSelector.GetShaderName(go);
			Material[] vegetationItemMaterials = ShaderSelector.GetVegetationItemMaterials(go);
			IShaderController shaderControler = ShaderSelector.GetShaderControler(shaderName);
			shaderControler.CreateDefaultSettings(vegetationItemMaterials);
			vegetationItemInfoPro.BillboardRenderMode = shaderControler.Settings.BillboardRenderMode;
			vegetationItemInfoPro.ShaderName = shaderName;
			vegetationItemInfoPro.ShaderControllerSettings = shaderControler.Settings;
			VegetationInfoList.Add(vegetationItemInfoPro);
			if (vegetationType == VegetationType.Tree)
			{
				GenerateBillboard(vegetationItemInfoPro.VegetationItemID);
			}
			if (Application.platform == RuntimePlatform.WindowsEditor && shaderControler.Settings.SupportsInstantIndirect)
			{
				vegetationItemInfoPro.VegetationRenderMode = VegetationRenderMode.InstancedIndirect;
			}
		}

		public void DuplicateVegetationItem(VegetationItemInfoPro vegetationItemInfo)
		{
			VegetationItemInfoPro vegetationItemInfoPro = new VegetationItemInfoPro(vegetationItemInfo);
			vegetationItemInfoPro.Name += " Copy";
			VegetationInfoList.Add(vegetationItemInfoPro);
		}

		public void GenerateBillboard(int vegetationItemIndex)
		{
		}

		public void GenerateBillboard(string vegetationItemID)
		{
			int vegetationItemIndexFromID = GetVegetationItemIndexFromID(vegetationItemID);
			GenerateBillboard(vegetationItemIndexFromID);
		}

		public int GetVegetationItemIndexFromID(string id)
		{
			for (int i = 0; i <= VegetationInfoList.Count - 1; i++)
			{
				if (VegetationInfoList[i].VegetationItemID == id)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
