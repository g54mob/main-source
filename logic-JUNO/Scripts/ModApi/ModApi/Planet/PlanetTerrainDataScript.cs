using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Planet.Events;
using ModApi.Planet.Modifiers;
using ModApi.Planet.Modifiers.Material;
using UnityEngine;

namespace ModApi.Planet
{
	public class PlanetTerrainDataScript : MonoBehaviour, IPlanetTerrainData
	{
		private static readonly char[] _stringSplitComma = new char[1] { ',' };

		private static bool _upgradingLegacyWater;

		private ReadOnlyCollection<PlanetBiome> _biomesReadOnly;

		private List<string> _conditionalSymbols = new List<string>();

		[SerializeField]
		private string _mapSetPath;

		private ReadOnlyCollection<PlanetModifier> _modifiersReadOnly;

		private Transform _planetModifiersRoot;

		[SerializeField]
		private PlanetTerrainQualitySettings _qualitySettings;

		[SerializeField]
		private PlanetModifier[] _randomizationIgnoreList;

		[SerializeField]
		private PlanetModifierRandomizationFlags _randomizationOptions = PlanetModifierRandomizationFlags.All;

		[SerializeField]
		[Range(0f, 16f)]
		private int _uvSizeExponent = 8;

		[SerializeField]
		private PlanetWaterConfig _waterConfigDefault;

		public List<PlanetBiome> Biomes { get; private set; }

		ReadOnlyCollection<PlanetBiome> IPlanetTerrainData.Biomes => _biomesReadOnly;

		public IReadOnlyList<string> ConditionalSymbols => _conditionalSymbols;

		public Transform HeightFinalPass { get; private set; }

		public bool Initialized { get; private set; }

		public PlanetMapSet MapSet { get; set; }

		public List<PlanetModifier> Modifiers { get; private set; }

		ReadOnlyCollection<PlanetModifier> IPlanetTerrainData.Modifiers => _modifiersReadOnly;

		public IPlanetData PlanetData { get; private set; }

		public IPlanetTerrainQuality Quality => _qualitySettings.Current;

		public PlanetTerrainQualitySettings QualitySettings
		{
			get
			{
				return _qualitySettings;
			}
			set
			{
				_qualitySettings = value;
			}
		}

		public int UVSizeExponent
		{
			get
			{
				return _uvSizeExponent;
			}
			set
			{
				_uvSizeExponent = value;
			}
		}

		public PlanetWaterConfig WaterConfigDefault => _waterConfigDefault;

		internal ReadOnlyCollection<PlanetModifier> RandomizationIgnoreList => new ReadOnlyCollection<PlanetModifier>((_randomizationIgnoreList ?? new PlanetModifier[0]).ToList());

		internal PlanetModifierRandomizationFlags RandomizationOptions => _randomizationOptions;

		private string MapSetPath
		{
			get
			{
				return _mapSetPath;
			}
			set
			{
				_mapSetPath = value;
			}
		}

		public static event EventHandler<PlanetTerrainDataEventArgs> TerrainDataInitialized;

		public static event EventHandler<PlanetTerrainDataEventArgs> TerrainDataInitializing;

		public static PlanetTerrainDataScript CreateFromXml(XElement xml, PlanetDataScript planet)
		{
			GameObject gameObject = new GameObject("TerrainData");
			if (planet != null)
			{
				gameObject.transform.SetParent(planet.transform, worldPositionStays: false);
			}
			PlanetTerrainDataScript planetTerrainDataScript = gameObject.AddComponent<PlanetTerrainDataScript>();
			planetTerrainDataScript.PlanetData = planet;
			planetTerrainDataScript._uvSizeExponent = ((int?)xml.Attribute("uvSizeExponent")) ?? 8;
			planetTerrainDataScript._conditionalSymbols = (from x in (((string)xml.Attribute("conditionalSymbols")) ?? string.Empty).Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries)
				select x.Trim()).ToList();
			int maxSubdivisionAdjustment = (int)System.Math.Log(planetTerrainDataScript.PlanetData.Scale.PlanetScale, 2.0);
			planetTerrainDataScript._qualitySettings = PlanetTerrainQualitySettings.CreateFromXml(xml.Element("QualitySettings"), maxSubdivisionAdjustment);
			XElement xElement = xml.Element("WaterConfigDefault");
			planetTerrainDataScript._waterConfigDefault = PlanetWaterConfig.CreateFromXml(xElement ?? new XElement("WaterConfigDefault"), null);
			int num = 0;
			foreach (XElement item in xml.Elements("Biomes").Elements("Biome"))
			{
				PlanetBiome.CreateFromXml(item, planetTerrainDataScript);
				num++;
			}
			if (num == 0)
			{
				Transform transform = new GameObject("Biomes").transform;
				transform.SetParent(gameObject.transform);
				GameObject obj = new GameObject("Biome");
				obj.transform.SetParent(transform);
				PlanetBiome planetBiome = PlanetBiome.CreateDefaultBiome(obj);
				obj.name = planetBiome.Name;
			}
			planetTerrainDataScript.RefreshBiomeList();
			Transform transform2 = Utilities.GetOrCreateObjectInHierarchy(gameObject.transform, "PlanetModifiers").transform;
			Utilities.GetOrCreateObjectInHierarchy(transform2, VertexDataPlanetModifierPassType.Biome.ToString());
			Utilities.GetOrCreateObjectInHierarchy(transform2, VertexDataPlanetModifierPassType.Height.ToString());
			planetTerrainDataScript.HeightFinalPass = Utilities.GetOrCreateObjectInHierarchy(transform2, VertexDataPlanetModifierPassType.HeightFinal.ToString()).transform;
			Utilities.GetOrCreateObjectInHierarchy(transform2, VertexDataPlanetModifierPassType.Final.ToString());
			Utilities.GetOrCreateObjectInHierarchy(transform2, VertexDataPlanetModifierPassType.Water.ToString());
			planetTerrainDataScript._planetModifiersRoot = transform2;
			foreach (XElement item2 in xml.Elements("Modifiers").Elements("Modifier"))
			{
				PlanetModifier.CreateFromXml(item2, transform2, planetTerrainDataScript, null);
			}
			planetTerrainDataScript.RefreshModifiersList();
			if (!_upgradingLegacyWater && xElement == null && xml.Attribute("waterGradient") != null)
			{
				UpgradeLegacyWater(xml, planet, planetTerrainDataScript);
			}
			return planetTerrainDataScript;
		}

		public void AddModifierFromXml(XElement modifierXml, int? modifierIndex = null)
		{
			PlanetModifier planetModifier = PlanetModifier.CreateFromXml(modifierXml, _planetModifiersRoot, this, null);
			int? modifierSiblingIndex = GetModifierSiblingIndex(modifierIndex);
			if (modifierSiblingIndex.HasValue)
			{
				planetModifier.transform.SetSiblingIndex(modifierSiblingIndex.Value);
			}
			RefreshModifiersList();
		}

		public void AddModifiersFromXml(IEnumerable<XElement> modifiersXml, int? modifierIndex = null)
		{
			int? num = GetModifierSiblingIndex(modifierIndex);
			foreach (XElement item in modifiersXml)
			{
				PlanetModifier planetModifier = PlanetModifier.CreateFromXml(item, _planetModifiersRoot, this, null);
				if (num.HasValue)
				{
					planetModifier.transform.SetSiblingIndex(num.Value);
					num = num.Value + 1;
				}
			}
			RefreshModifiersList();
		}

		public WaterMaterialModifier CreateWaterMaterialModifier()
		{
			WaterMaterialModifier waterMaterialModifier = new GameObject("WaterMaterialModifier").AddComponent<WaterMaterialModifier>();
			waterMaterialModifier.transform.SetParent(base.transform, worldPositionStays: false);
			Modifiers.Add(waterMaterialModifier);
			return waterMaterialModifier;
		}

		public List<T> GetModifiers<T>() where T : PlanetModifier
		{
			List<T> list = new List<T>();
			foreach (PlanetModifier modifier in Modifiers)
			{
				T val = modifier as T;
				if (val != null)
				{
					list.Add(val);
				}
			}
			return list;
		}

		public WaterMaterialModifier GetWaterMaterialModifier()
		{
			return Modifiers.Where((PlanetModifier x) => x.ModifierType == PlanetModifierType.WaterMaterial && x.gameObject.activeInHierarchy).FirstOrDefault() as WaterMaterialModifier;
		}

		public void Initialize()
		{
			if (!Initialized)
			{
				if (PlanetData == null)
				{
					PlanetData = GetComponentInParent<PlanetDataScript>();
				}
				_qualitySettings.UpdateCurrentQualitySettings(Game.Instance.QualitySettings);
				PlanetTerrainDataScript.TerrainDataInitializing?.Invoke(this, new PlanetTerrainDataEventArgs(this));
				InitializeBiomes();
				InitializeModifiers();
				PlanetTerrainDataScript.TerrainDataInitialized?.Invoke(this, new PlanetTerrainDataEventArgs(this));
				Initialized = true;
			}
		}

		public XElement Save(XElement xml)
		{
			RefreshModifiersList();
			RefreshBiomeList();
			GetComponentInParent<PlanetDataScript>();
			if (!string.IsNullOrEmpty(_mapSetPath))
			{
				xml.SetAttributeValue("mapSetPath", _mapSetPath);
			}
			xml.SetAttributeValue("uvSizeExponent", _uvSizeExponent);
			if ((_conditionalSymbols?.Count ?? 0) > 0)
			{
				xml.SetAttributeValue("conditionalSymbols", string.Join(",", _conditionalSymbols));
			}
			xml.Add(_qualitySettings.SaveXml(new XElement("QualitySettings")));
			xml.Add(_waterConfigDefault.SaveXml(new XElement("WaterConfigDefault"), isPlanetDefaultConfig: true));
			XElement xElement = new XElement("Modifiers");
			foreach (PlanetModifier modifier in Modifiers)
			{
				XElement xElement2 = new XElement("Modifier");
				modifier.SaveXml(xElement2);
				xElement.Add(xElement2);
			}
			XElement xElement3 = new XElement("Biomes");
			foreach (PlanetBiome biome in Biomes)
			{
				XElement xElement4 = new XElement("Biome");
				biome.SaveXml(xElement4);
				xElement3.Add(xElement4);
			}
			xml.Add(xElement, xElement3);
			return xml;
		}

		private static void UpgradeLegacyWater(XElement xml, PlanetDataScript planet, PlanetTerrainDataScript originalTerrainData)
		{
			_upgradingLegacyWater = true;
			PlanetTerrainDataScript planetTerrainDataScript = null;
			TerrainGenerator terrainGenerator = null;
			try
			{
				planetTerrainDataScript = CreateFromXml(new XElement(xml), planet);
				planetTerrainDataScript.Initialize();
				terrainGenerator = new TerrainGenerator(planetTerrainDataScript);
				float legacyHeightMin = terrainGenerator.LegacyHeightMin;
				Gradient gradientAttribute = Utilities.GetGradientAttribute(xml, "waterGradient", includeAlphaKeys: true);
				float colorGradientMaxDepth = planet.SeaLevel - legacyHeightMin;
				XElement xElement = (from x in xml.Element("Modifiers").Elements("Modifier")
					where (string)x.Attribute("type") == "Material.WaterMaterialModifier"
					select x).FirstOrDefault();
				float specularity = ((float?)xElement?.Elements("TilingConfig").Elements("TileLevel").FirstOrDefault()?.Attribute("specularity")) ?? 0.95f;
				float transparencyDepth = ((float?)xElement?.Attribute("transparencyDepth")) ?? 140f;
				int transparencyStrength = Mathf.RoundToInt((((float?)xElement?.Attribute("transparencyStrength")) ?? 0.129f) * 100f);
				int foamStrength = Mathf.RoundToInt((((float?)xElement?.Attribute("foamStrength")) ?? 0.53f) * 100f);
				float foamDepth = ((float?)xElement?.Attribute("foamDepth")) ?? 0.35f;
				Color foamColor = xElement?.GetColorAttribute("foamColor") ?? Color.white;
				originalTerrainData.WaterConfigDefault.ApplyLegacyWaterSettings(gradientAttribute, colorGradientMaxDepth, specularity, transparencyDepth, transparencyStrength, foamStrength, foamDepth, foamColor);
				foreach (PlanetBiome biome in originalTerrainData.Biomes)
				{
					biome.WaterConfig.ApplyLegacyWaterSettings(gradientAttribute, colorGradientMaxDepth, specularity, transparencyDepth, transparencyStrength, foamStrength, foamDepth, foamColor);
				}
				xml.Element("QualitySettings").AddAfterSelf(originalTerrainData.WaterConfigDefault.SaveXml(new XElement("WaterConfigDefault"), isPlanetDefaultConfig: true));
			}
			finally
			{
				_upgradingLegacyWater = false;
				terrainGenerator?.Dispose();
				if (planetTerrainDataScript != null)
				{
					UnityEngine.Object.Destroy(planetTerrainDataScript.gameObject);
				}
			}
			Debug.Log(planet.Name + ": Legacy water upgraded.");
		}

		private void GetModifiers(List<PlanetModifier> modifierList, List<PlanetModifier> tempList, Transform obj)
		{
			if (obj.GetComponent<PlanetBiome>() != null)
			{
				return;
			}
			obj.GetComponents(tempList);
			modifierList.AddRange(tempList);
			foreach (Transform item in obj)
			{
				GetModifiers(modifierList, tempList, item);
			}
		}

		private int? GetModifierSiblingIndex(int? modifierIndex)
		{
			if (modifierIndex.HasValue && modifierIndex < Modifiers.Count)
			{
				return Modifiers[modifierIndex.Value].transform.GetSiblingIndex();
			}
			return null;
		}

		private void InitializeBiomes()
		{
			foreach (PlanetBiome biome in Biomes)
			{
				biome.Initialize();
			}
		}

		private void InitializeModifiers()
		{
			List<PlanetModifier> list = new List<PlanetModifier>(0);
			foreach (PlanetModifier modifier in Modifiers)
			{
				try
				{
					modifier.Initialize(PlanetData);
				}
				catch (Exception exception)
				{
					list.Add(modifier);
					Debug.LogException(exception);
					Debug.LogError("An error occurred initializing planet modifier '" + modifier.Name + "'. The modifier will be disabled to prevent further errors.");
				}
			}
			if (list.Count > 0)
			{
				list.ForEach(delegate(PlanetModifier x)
				{
					Modifiers.Remove(x);
				});
				_modifiersReadOnly = Modifiers.AsReadOnly();
			}
			foreach (PlanetBiome biome in Biomes)
			{
				list.Clear();
				foreach (PlanetModifier modifier2 in biome.Modifiers)
				{
					try
					{
						modifier2.Initialize(PlanetData);
					}
					catch (Exception exception2)
					{
						list.Add(modifier2);
						Debug.LogException(exception2);
						Debug.LogError("An error occurred initializing planet biome modifier '" + modifier2.Name + "'. The modifier will be disabled to prevent further errors.");
					}
				}
				if (list.Count > 0)
				{
					list.ForEach(delegate(PlanetModifier x)
					{
						biome.Modifiers.Remove(x);
					});
					list.Clear();
				}
			}
		}

		private void OnValidate()
		{
			_waterConfigDefault?.OnValidate();
		}

		private void RefreshBiomeList()
		{
			Biomes = new List<PlanetBiome>();
			GetComponentsInChildren(includeInactive: true, Biomes);
			_biomesReadOnly = Biomes.AsReadOnly();
		}

		private void RefreshModifiersList()
		{
			Modifiers = new List<PlanetModifier>();
			GetModifiers(Modifiers, new List<PlanetModifier>(), base.transform);
			_modifiersReadOnly = Modifiers.AsReadOnly();
		}
	}
}
