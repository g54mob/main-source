using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone
{
	public class NimbatusTerrainClimateZone : SerializedMonoBehaviour
	{
		[ReadOnly]
		public string UniqueId;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public EClimateZoneType ZoneType;

		public bool IsUsedForRandomPlanets;

		[OdinSerialize]
		[ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 1)]
		[TitleGroup("Layers", null, TitleAlignments.Left, true, true, false, 0)]
		protected List<NimbatusClimateZoneLayer> ForegroundLayers = new List<NimbatusClimateZoneLayer>();

		[OdinSerialize]
		[ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 1)]
		[TitleGroup("Layers", null, TitleAlignments.Left, true, true, false, 0)]
		protected List<NimbatusClimateZoneLayer> BackgroundLayers = new List<NimbatusClimateZoneLayer>();

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public Gradient SkyGradient;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public Texture2D PreviewImage;

		[HideInInspector]
		public Color SelectedStarmapColor;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public Sprite StarmapSprite;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public string AmbientTheme;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public string ActionTheme;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public string AmbientSoundloop;

		[TitleGroup("Background Objects", null, TitleAlignments.Left, true, true, false, 0)]
		public List<WorldTerrainObject> BackgroundObjects;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public NimbatusTerrainSettingProvider TerrainSetting;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public List<ESpawnRegion> UnlockedSpawnRegions = new List<ESpawnRegion> { ESpawnRegion.All };

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public List<ESpawnSectorType> UnlockedSpawnSectors = new List<ESpawnSectorType> { ESpawnSectorType.All };

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public List<NimbatusPlanetTheme> AlwaysActiveThemes;

		[HideInInspector]
		public NimbatusTerrainSetting SelectedSettings;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public bool IsUsed;

		[TitleGroup("Settings", null, TitleAlignments.Left, true, true, false, 0)]
		public List<Texture2D> Textures;

		[NonSerialized]
		[HideInInspector]
		internal List<Color[]> TexturePixels;

		[TitleGroup("Preview", null, TitleAlignments.Left, true, true, false, 0)]
		public int EditorSeed;

		[TitleGroup("Preview", null, TitleAlignments.Left, true, true, false, 0)]
		public bool CustomBackground;

		[ShowIf("CustomBackground", true)]
		[TitleGroup("Preview", null, TitleAlignments.Left, true, true, false, 0)]
		public Color BackgroundColor;

		[TitleGroup("Preview", null, TitleAlignments.Left, true, true, false, 0)]
		[InlineEditor(InlineEditorModes.LargePreview, InlineEditorObjectFieldModes.Boxed)]
		public Texture2D EditorPreviewTexture;

		[ContextMenu("Generate Unique ID")]
		public void GenerateNewUniqueId()
		{
			UniqueId = Guid.NewGuid().ToString();
		}

		[TitleGroup("Preview", null, TitleAlignments.Left, true, true, false, 0)]
		[Button]
		public void GenerateImageNormal()
		{
			GenerateImage(EditorSeed);
		}

		[TitleGroup("Preview", null, TitleAlignments.Left, true, true, false, 0)]
		[Button]
		public void GenerateImageRandom()
		{
			EditorSeed = UnityEngine.Random.Range(0, 10000);
			GenerateImage(EditorSeed);
		}

		public void InitLayers(System.Random rnd, bool editor = false)
		{
			VariableSet variables = new VariableSet();
			foreach (NimbatusClimateZoneLayer foregroundLayer in ForegroundLayers)
			{
				if (editor)
				{
					foregroundLayer.Init(this, rnd, ref variables);
					continue;
				}
				ResourceSetting resourceSetting = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(foregroundLayer.TerrainMaterial);
				Material material;
				if (foregroundLayer.HasCustomMaterial)
				{
					material = foregroundLayer.CustomMaterial;
				}
				else if (resourceSetting != null)
				{
					material = resourceSetting.ForegroundMaterial;
				}
				else
				{
					material = UnityEngine.Object.Instantiate(foregroundLayer.IsEmissive ? SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.EmissiveMaterial : SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.DiffuseMaterial);
					material.color = foregroundLayer.Color;
					if (foregroundLayer.IsEmissive)
					{
						material.SetFloat("_Glow", foregroundLayer.Glow);
					}
				}
				foregroundLayer.Material = material;
				foregroundLayer.Init(this, rnd, ref variables);
			}
			foreach (NimbatusClimateZoneLayer backgroundLayer in BackgroundLayers)
			{
				if (editor)
				{
					backgroundLayer.Init(this, rnd, ref variables);
					continue;
				}
				ResourceSetting resourceSetting2 = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(backgroundLayer.TerrainMaterial);
				Material material2;
				if (backgroundLayer.HasCustomMaterial)
				{
					material2 = backgroundLayer.CustomMaterial;
				}
				else if (resourceSetting2 != null)
				{
					material2 = resourceSetting2.BackgroundMaterial;
				}
				else
				{
					material2 = UnityEngine.Object.Instantiate(backgroundLayer.IsEmissive ? SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.EmissiveMaterial : SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.DiffuseMaterial);
					material2.color = backgroundLayer.Color;
					if (backgroundLayer.IsEmissive)
					{
						material2.SetFloat("_Glow", backgroundLayer.Glow);
					}
				}
				backgroundLayer.Material = material2;
				backgroundLayer.Init(this, rnd, ref variables);
			}
		}

		public void SetSettings(NimbatusTerrainSetting setting)
		{
			SelectedSettings = setting;
		}

		public NimbatusClimateZoneLayer GetLayer(ushort materialIndex, bool isBackGround)
		{
			if (isBackGround)
			{
				return BackgroundLayers[materialIndex];
			}
			return ForegroundLayers[materialIndex];
		}

		public NimbatusTerrainData GenerateData(Vector2 worldPosition, bool isBackgroundTerrain)
		{
			float num = 0f;
			float previousLayer = 1f;
			ushort materialType = 0;
			List<NimbatusClimateZoneLayer> list = (isBackgroundTerrain ? BackgroundLayers : ForegroundLayers);
			for (ushort num2 = 0; num2 < list.Count; num2++)
			{
				float num3 = Mathf.Clamp(list[num2].GetData(worldPosition, previousLayer), -1f, 1f);
				if (num3 >= 0.5f)
				{
					materialType = num2;
				}
				previousLayer = num3;
				num = Mathf.Max(num, num3);
			}
			return new NimbatusTerrainData
			{
				MaterialType = materialType,
				Volume = num
			};
		}

		public void GenerateImage(int seed)
		{
			FillPixels();
			SelectedSettings = TerrainSetting.GenerateSettings(new System.Random(seed));
			InitLayers(new System.Random(seed), true);
			Texture2D texture2D = new Texture2D(1100, 1100);
			texture2D.Resize(1100, 1100);
			for (int i = 0; i < 1100; i++)
			{
				for (int j = 0; j < 1100; j++)
				{
					Vector2 worldPosition = new Vector2(i - 540, j - 540);
					NimbatusTerrainData nimbatusTerrainData = GenerateData(worldPosition, false);
					NimbatusTerrainData nimbatusTerrainData2 = GenerateData(worldPosition, true);
					if (nimbatusTerrainData.Volume >= 0.5f)
					{
						texture2D.SetPixel(i, j, GetLayer(nimbatusTerrainData.MaterialType, false).Color);
						continue;
					}
					if (nimbatusTerrainData2.Volume >= 0.5f)
					{
						texture2D.SetPixel(i, j, GetLayer(nimbatusTerrainData2.MaterialType, true).Color);
						continue;
					}
					if (CustomBackground)
					{
						texture2D.SetPixel(i, j, BackgroundColor);
						continue;
					}
					float magnitude = new Vector2((float)SelectedSettings.PlanetSize * 1.5f, (float)SelectedSettings.PlanetSize * 1.5f).magnitude;
					Color color = SkyGradient.Evaluate(1f / magnitude * worldPosition.magnitude);
					texture2D.SetPixel(i, j, color * 1.5f);
				}
			}
			texture2D.Apply();
			EditorPreviewTexture = texture2D;
		}

		public void FillPixels()
		{
			TexturePixels = new List<Color[]>();
			foreach (Texture2D texture in Textures)
			{
				Color[] pixels = texture.GetPixels();
				TexturePixels.Add(pixels);
			}
		}
	}
}
