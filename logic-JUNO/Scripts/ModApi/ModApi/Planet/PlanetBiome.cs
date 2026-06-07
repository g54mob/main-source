using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Planet.Modifiers;
using ModApi.Planet.Modifiers.VertexData.Biomes;
using UnityEngine;

namespace ModApi.Planet
{
	public class PlanetBiome : MonoBehaviour
	{
		private bool _initialized;

		[SerializeField]
		private string _name;

		private Transform _planetModifiersRoot;

		[SerializeField]
		private PlanetWaterConfig _waterConfig;

		public List<PlanetModifier> Modifiers { get; private set; }

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public PlanetTerrainDataScript TerrainData { get; private set; }

		public PlanetWaterConfig WaterConfig => _waterConfig;

		public static PlanetBiome CreateDefaultBiome(GameObject biomeObject)
		{
			PlanetBiome planetBiome = biomeObject.AddComponent<PlanetBiome>();
			planetBiome._name = "Default Biome";
			return planetBiome;
		}

		public static PlanetBiome CreateFromXml(XElement xml, PlanetTerrainDataScript terrainData)
		{
			string text = (string)xml.Attribute("name");
			GameObject gameObject = Utilities.GetOrCreateObjectInHierarchy(terrainData.transform, "Biomes/" + text);
			if ((bool)gameObject.GetComponent<PlanetBiome>())
			{
				GameObject obj = new GameObject(gameObject.name);
				obj.transform.SetParent(gameObject.transform.parent, worldPositionStays: false);
				gameObject = obj;
			}
			PlanetBiome planetBiome = gameObject.AddComponent<PlanetBiome>();
			planetBiome._name = text;
			planetBiome.TerrainData = terrainData;
			Transform transform = gameObject.transform;
			Utilities.GetOrCreateObjectInHierarchy(transform, VertexDataPlanetModifierPassType.Height.ToString());
			Utilities.GetOrCreateObjectInHierarchy(transform, VertexDataPlanetModifierPassType.HeightFinal.ToString());
			Utilities.GetOrCreateObjectInHierarchy(transform, VertexDataPlanetModifierPassType.Final.ToString());
			Utilities.GetOrCreateObjectInHierarchy(transform, VertexDataPlanetModifierPassType.Water.ToString());
			planetBiome._planetModifiersRoot = transform;
			planetBiome._waterConfig = PlanetWaterConfig.CreateFromXml(xml.Element("WaterConfig") ?? new XElement("WaterConfig"), terrainData.WaterConfigDefault);
			foreach (XElement item in xml.Elements("Modifiers").Elements("Modifier"))
			{
				PlanetModifier.CreateFromXml(item, transform, terrainData, planetBiome);
			}
			planetBiome.Initialize();
			return planetBiome;
		}

		public void AddModifierFromXml(XElement modifierXml, int? modifierIndex = null)
		{
			PlanetModifier planetModifier = PlanetModifier.CreateFromXml(modifierXml, _planetModifiersRoot, TerrainData, this);
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
				PlanetModifier planetModifier = PlanetModifier.CreateFromXml(item, _planetModifiersRoot, TerrainData, this);
				if (num.HasValue)
				{
					planetModifier.transform.SetSiblingIndex(num.Value);
					num = num.Value + 1;
				}
			}
			RefreshModifiersList();
		}

		public List<SubBiomeData> GetSubBiomes()
		{
			List<SubBiomeData> list = new List<SubBiomeData>();
			foreach (PlanetModifier modifier in Modifiers)
			{
				if (modifier is ISubBiomePlanetModifier subBiomePlanetModifier)
				{
					subBiomePlanetModifier.GetSubBiomes(list);
				}
			}
			return list;
		}

		public void Initialize()
		{
			if (!_initialized)
			{
				_initialized = true;
				RefreshModifiersList();
			}
		}

		public void RefreshModifiersList()
		{
			Modifiers = new List<PlanetModifier>();
			GetModifiers(Modifiers, new List<PlanetModifier>(), base.transform);
		}

		public virtual void SaveXml(XElement xml)
		{
			RefreshModifiersList();
			xml.SetAttributeValue("name", _name);
			xml.Add(_waterConfig.SaveXml(new XElement("WaterConfig"), isPlanetDefaultConfig: false));
			XElement xElement = new XElement("Modifiers");
			foreach (PlanetModifier modifier in Modifiers)
			{
				XElement xElement2 = new XElement("Modifier");
				modifier.SaveXml(xElement2);
				xElement.Add(xElement2);
			}
			xml.Add(xElement);
		}

		private void GetModifiers(List<PlanetModifier> modifierList, List<PlanetModifier> tempList, Transform obj)
		{
			PlanetBiome component = obj.GetComponent<PlanetBiome>();
			if (component != null && component != this)
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

		private void OnValidate()
		{
			_waterConfig?.OnValidate();
		}
	}
}
