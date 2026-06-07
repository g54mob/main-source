using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Mods;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Planet.Modifiers.VertexData;
using UnityEngine;

namespace ModApi.Planet.Modifiers
{
	public abstract class PlanetModifier : MonoBehaviour
	{
		private static readonly char[] _stringSplitComma = new char[1] { ',' };

		private static Dictionary<Type, ILoadedMod> _planetModifierModMap = new Dictionary<Type, ILoadedMod>();

		private static Dictionary<string, Type> _planetModifierTypes = new Dictionary<string, Type>();

		private static List<Assembly> _registeredAssemblies = new List<Assembly>();

		private static Dictionary<Type, string> _typeIDLookup = new Dictionary<Type, string>();

		[SerializeField]
		private string[] _disabledWithSymbols;

		[SerializeField]
		private string[] _enabledWithSymbols;

		[SerializeField]
		private string _name;

		private string _typeId;

		public PlanetBiome Biome { get; protected set; }

		public string Container { get; set; }

		public IReadOnlyList<string> DisabledWithSymbols => _disabledWithSymbols;

		public IReadOnlyList<string> EnabledWithSymbols => _enabledWithSymbols;

		public ILoadedMod Mod
		{
			get
			{
				_planetModifierModMap.TryGetValue(GetType(), out var value);
				return value;
			}
		}

		public PlanetModifierType ModifierType { get; private set; }

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

		public virtual bool SupportsRandomization => false;

		public string TypeId
		{
			get
			{
				if (string.IsNullOrEmpty(_typeId))
				{
					_typeId = GetTypeId();
				}
				return _typeId;
			}
		}

		public bool VisibleInBasicViewMode { get; set; }

		protected float PlanetScale => TerrainData.PlanetData.Scale.PlanetScale;

		protected PlanetTerrainDataScript TerrainData { get; private set; }

		protected PlanetModifier(PlanetModifierType modifierType)
		{
			ModifierType = modifierType;
			_enabledWithSymbols = new string[0];
			_disabledWithSymbols = new string[0];
		}

		public static PlanetModifier CreateFromXml(XElement xml, Transform root, PlanetTerrainDataScript terrainData, PlanetBiome biome)
		{
			PlanetModifier planetModifier = null;
			GameObject gameObject = new GameObject((string)xml.Attribute("name"));
			string text = (string)xml.Attribute("type");
			if (!_planetModifierTypes.TryGetValue(text, out var value))
			{
				Debug.LogError("Unable to find planet modifier type '" + text + "'");
				return null;
			}
			try
			{
				planetModifier = (PlanetModifier)gameObject.AddComponent(value);
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("Unable to create planet modifier of type '{0}'.{1}{2}", value.AssemblyQualifiedName, Environment.NewLine, ex);
				return null;
			}
			planetModifier.Biome = biome;
			planetModifier.TerrainData = terrainData;
			planetModifier.RestoreXml(xml);
			if (!(bool)xml.Attribute("enabled"))
			{
				gameObject.SetActive(value: false);
			}
			string hierarchy = string.Empty;
			VertexDataPlanetModifier vertexDataPlanetModifier = planetModifier as VertexDataPlanetModifier;
			if (vertexDataPlanetModifier != null)
			{
				hierarchy = vertexDataPlanetModifier.Pass.ToString();
				string text2 = ((string)xml.Attribute("hierarchy")) ?? null;
				if (text2 != null && biome == null)
				{
					string text3 = text2.Replace("PlanetModifiers", string.Empty);
					planetModifier.Container = text3.Replace(gameObject.name, string.Empty).Trim(new char[1] { '/' });
				}
			}
			GameObject orCreateObjectInHierarchy = Utilities.GetOrCreateObjectInHierarchy(root, hierarchy);
			gameObject.transform.SetParent(orCreateObjectInHierarchy.transform, worldPositionStays: false);
			return planetModifier;
		}

		public static IEnumerable<Type> GetPlanetModifierTypes()
		{
			return _planetModifierTypes.Values;
		}

		public static string GetTypeId(Type type)
		{
			if (_typeIDLookup.TryGetValue(type, out var value))
			{
				return value;
			}
			object[] customAttributes = type.GetCustomAttributes(typeof(PlanetModifierTypeIdAttribute), inherit: false);
			if (customAttributes.Length != 0)
			{
				object[] array = customAttributes;
				for (int i = 0; i < array.Length; i++)
				{
					value = ((PlanetModifierTypeIdAttribute)array[i]).Id;
				}
			}
			else
			{
				value = GetDefaultTypeId(type);
			}
			_typeIDLookup.Add(type, value);
			return value;
		}

		public static void Register(Assembly assembly, ILoadedMod mod)
		{
			if (_registeredAssemblies.Contains(assembly))
			{
				return;
			}
			_registeredAssemblies.Add(assembly);
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (!typeof(PlanetModifier).IsAssignableFrom(type) || type.IsAbstract)
				{
					continue;
				}
				object[] customAttributes = type.GetCustomAttributes(typeof(PlanetModifierTypeIdAttribute), inherit: false);
				if (customAttributes.Length != 0)
				{
					object[] array = customAttributes;
					for (int j = 0; j < array.Length; j++)
					{
						string id = ((PlanetModifierTypeIdAttribute)array[j]).Id;
						if (_planetModifierTypes.ContainsKey(id))
						{
							Debug.Log("Overriding planet modifier with id '" + id + "'. " + $"Original type: {_planetModifierTypes[id].FullName}, New type: {type}");
						}
						_planetModifierTypes[id] = type;
						_planetModifierModMap[type] = mod;
					}
				}
				else
				{
					string defaultTypeId = GetDefaultTypeId(type);
					if (_planetModifierTypes.ContainsKey(defaultTypeId))
					{
						Debug.Log("Overriding planet modifier with id '" + defaultTypeId + "'. " + $"Original type: {_planetModifierTypes[defaultTypeId].FullName}, New type: {type}");
					}
					_planetModifierTypes[defaultTypeId] = type;
					_planetModifierModMap[type] = mod;
				}
			}
		}

		public virtual void GetModRequirements(AddModRequirementDelegate addModRequirement)
		{
			if (Mod != null)
			{
				addModRequirement(Mod.ModInfo, requiresCodeExecution: true);
			}
		}

		public virtual QuadMeshDataFlags GetRequiredTerrainMeshData()
		{
			return QuadMeshDataFlags.None;
		}

		public virtual QuadMeshDataFlags GetRequiredWaterMeshData()
		{
			return QuadMeshDataFlags.None;
		}

		public virtual List<string> GetSupportFileReferences()
		{
			List<string> list = new List<string>();
			GetSupportFileReferences(this, list);
			if (this is IBrushCubemapModifier { MapId: var mapId } && !string.IsNullOrWhiteSpace(mapId))
			{
				list.Add(mapId);
			}
			return list;
		}

		public void Initialize(PlanetTerrainDataScript terrainData)
		{
			TerrainData = terrainData;
			Initialize(terrainData.PlanetData);
		}

		public virtual void Initialize(IPlanetData planetData)
		{
		}

		public virtual void OnCreatedInPlanetStudio(VertexDataPlanetModifier parentModifier)
		{
		}

		public virtual void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			TerrainData = terrainData;
		}

		public virtual bool Randomize(RandomizeContext context)
		{
			return false;
		}

		public virtual void SaveXml(XElement xml)
		{
			if (string.IsNullOrEmpty(_name))
			{
				_name = base.gameObject.name;
			}
			xml.SetAttributeValue("type", TypeId);
			xml.SetAttributeValue("enabled", base.isActiveAndEnabled);
			xml.SetAttributeValue("name", _name);
			xml.SetAttributeValue("container", Container);
			if (VisibleInBasicViewMode)
			{
				xml.SetAttributeValue("basicView", VisibleInBasicViewMode);
			}
			if (_enabledWithSymbols.Length != 0)
			{
				xml.SetAttributeValue("enabledWithSymbols", string.Join(",", _enabledWithSymbols));
			}
			if (_disabledWithSymbols.Length != 0)
			{
				xml.SetAttributeValue("disabledWithSymbols", string.Join(",", _disabledWithSymbols));
			}
		}

		protected static void GetSupportFileReferences(object obj, List<string> references)
		{
			if (obj == null)
			{
				return;
			}
			Type type = obj.GetType();
			if (!type.IsClass && !type.IsInterface)
			{
				return;
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.GetCustomAttribute<NonSerializedAttribute>() != null || (fieldInfo.IsPrivate && fieldInfo.GetCustomAttribute<SerializeField>() == null))
				{
					continue;
				}
				if (fieldInfo.GetCustomAttribute<SupportFileReferenceAttribute>() != null)
				{
					if (fieldInfo.FieldType == typeof(string))
					{
						string text = (string)fieldInfo.GetValue(obj);
						if (!string.IsNullOrWhiteSpace(text))
						{
							references.Add(text);
						}
					}
					else
					{
						if (!fieldInfo.FieldType.IsArray || !(fieldInfo.FieldType.GetElementType() == typeof(string)))
						{
							continue;
						}
						Array array = (Array)fieldInfo.GetValue(obj);
						if (array == null)
						{
							continue;
						}
						foreach (string item in array)
						{
							if (!string.IsNullOrWhiteSpace(item))
							{
								references.Add(item);
							}
						}
					}
				}
				else if (fieldInfo.FieldType.IsArray)
				{
					Type elementType = fieldInfo.FieldType.GetElementType();
					if (!elementType.IsClass && !elementType.IsInterface)
					{
						continue;
					}
					Array array2 = (Array)fieldInfo.GetValue(obj);
					if (array2 == null)
					{
						continue;
					}
					foreach (object item2 in array2)
					{
						if (item2 != null)
						{
							GetSupportFileReferences(item2, references);
						}
					}
				}
				else
				{
					if (!fieldInfo.FieldType.IsClass)
					{
						continue;
					}
					object value = fieldInfo.GetValue(obj);
					if (value == null)
					{
						continue;
					}
					if (value is IEnumerable enumerable)
					{
						foreach (object item3 in enumerable)
						{
							if (item3 != null)
							{
								GetSupportFileReferences(value, references);
							}
						}
					}
					else
					{
						GetSupportFileReferences(value, references);
					}
				}
			}
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void RestoreXml(XElement xml)
		{
			_name = (string)xml.Attribute("name");
			Container = (string)xml.Attribute("container");
			bool? flag = (bool?)xml.Attribute("basicView");
			if (flag.HasValue)
			{
				VisibleInBasicViewMode = flag.Value;
			}
			_enabledWithSymbols = (from x in (((string)xml.Attribute("enabledWithSymbols")) ?? string.Empty).Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries)
				select x.Trim()).ToArray();
			_disabledWithSymbols = (from x in (((string)xml.Attribute("disabledWithSymbols")) ?? string.Empty).Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries)
				select x.Trim()).ToArray();
		}

		private static string GetDefaultTypeId(Type type)
		{
			Type typeFromHandle = typeof(PlanetModifier);
			bool num = type.Assembly == typeFromHandle.Assembly;
			string text = type.FullName;
			if (num && text.StartsWith(typeFromHandle.Namespace, StringComparison.Ordinal))
			{
				text = text.Substring(typeFromHandle.Namespace.Length + 1);
			}
			return text;
		}

		private string GetTypeId()
		{
			return GetTypeId(GetType());
		}
	}
}
