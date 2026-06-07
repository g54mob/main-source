using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Flight.Sim;
using ModApi.Mods;
using ModApi.Planet.Modifiers;
using ModApi.State;
using UnityEngine;

namespace ModApi.Planet
{
	public class PlanetDataScript : MonoBehaviour, IPlanetData
	{
		public const int CurrentXmlVersion = 2;

		public const float DefaultWaveAmplitude = 0.5f;

		[SerializeField]
		private double _angularVelocity;

		[SerializeField]
		private PlanetAtmosphereData _atmosphereData;

		[SerializeField]
		private string _author;

		private List<LaunchLocation> _defaultLaunchLocations;

		[Multiline]
		[SerializeField]
		private string _description;

		[SerializeField]
		private bool _hasTerrainPhysics;

		[SerializeField]
		private bool _hasWater;

		private double? _impactRadius;

		private double? _impactRadiusSquared;

		[SerializeField]
		private double _legacyQuadSphereActivationDistance;

		[SerializeField]
		private double _legacyQuadSphereTransitionDistance;

		private double _mass;

		private double? _maxEstimatedTerrainElevation;

		[SerializeField]
		private List<string> _modKeywords;

		[SerializeField]
		private string _musicIntensityExpression;

		[SerializeField]
		private string[] _musicKeywords;

		[SerializeField]
		private string _name;

		[SerializeField]
		private string _parentAncestryId;

		[SerializeField]
		private CelestialBodyPlanetarySystemDefinedData _planetarySystemDefinedData;

		private PlanetCubemapManager _planetCubemapManager;

		[SerializeField]
		private double _radius;

		[SerializeField]
		private double _radiusScaledSpaceHeightAdjustment;

		[SerializeField]
		private PlanetRingsData _ringsData;

		[SerializeField]
		private CelestialBodyScaleData _scaleDefaults;

		[SerializeField]
		private float _seaLevel;

		[SerializeField]
		private bool _skyboxFadeDuringDaytime;

		[SerializeField]
		private PlanetShaderData _skyShaderData;

		[SerializeField]
		private bool _skyShaderEnabled;

		[SerializeField]
		private List<StructureNodeData> _structureNodes = new List<StructureNodeData>();

		[SerializeField]
		private double _surfaceGravity;

		[SerializeField]
		private bool _syncPropertiesFromTerrain;

		private XElement _terrainDataXml;

		[SerializeField]
		private PlanetShaderData _terrainShaderData;

		[SerializeField]
		private bool _uniformHeight;

		[SerializeField]
		private Version _version;

		[SerializeField]
		private string _versionTag;

		public double AngularVelocity
		{
			get
			{
				return PlanetarySystemDefinedData.AngularVelocity ?? _angularVelocity;
			}
			set
			{
				_angularVelocity = value;
			}
		}

		public PlanetAtmosphereData AtmosphereData
		{
			get
			{
				return _atmosphereData;
			}
			set
			{
				_atmosphereData = value;
			}
		}

		IPlanetAtmosphereData IPlanetData.AtmosphereData => _atmosphereData;

		public string Author
		{
			get
			{
				return _author;
			}
			set
			{
				_author = value;
			}
		}

		public List<LaunchLocation> DefaultLaunchLocations => _defaultLaunchLocations;

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		public float EquirectangularMapBrightness { get; set; } = 1f;

		public float EquirectangularMapLight { get; set; } = 0.5f;

		public double EscapeVelocity { get; private set; }

		public CelestialFile File { get; private set; }

		public CelestialBodyFileData FileData { get; private set; }

		public CelestialDatabaseGeneratedData GeneratedData { get; private set; }

		public bool HasTerrainPhysics
		{
			get
			{
				return _hasTerrainPhysics;
			}
			set
			{
				_hasTerrainPhysics = value;
			}
		}

		public bool HasWater
		{
			get
			{
				return _hasWater;
			}
			set
			{
				_hasWater = value;
			}
		}

		public Guid Id { get; private set; }

		public double ImpactRadius
		{
			get
			{
				if (!_impactRadius.HasValue)
				{
					try
					{
						PlanetCubemapData cubemapData = PlanetCubemapUtility.GetCubemapData(this, create: false);
						double value = Radius + (double)(cubemapData?.MinHeight ?? 0f) - 20.0;
						_impactRadius = value;
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						_impactRadius = Radius;
					}
				}
				return _impactRadius.Value;
			}
		}

		public double ImpactRadiusSquared
		{
			get
			{
				if (!_impactRadiusSquared.HasValue)
				{
					_impactRadiusSquared = ImpactRadius * ImpactRadius;
				}
				return _impactRadiusSquared.Value;
			}
		}

		public double Mass
		{
			get
			{
				return _mass;
			}
			set
			{
				_mass = value;
				EscapeVelocity = CalculateEscapeVelocity(_mass, _radius);
			}
		}

		public double MaxEstimatedTerrainElevation
		{
			get
			{
				if (!_maxEstimatedTerrainElevation.HasValue)
				{
					try
					{
						double value = (double)(PlanetCubemapUtility.GetCubemapData(this, create: false)?.MaxHeight ?? 0f) + 1000.0;
						_maxEstimatedTerrainElevation = value;
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						_maxEstimatedTerrainElevation = 0.0;
					}
				}
				return _maxEstimatedTerrainElevation.Value;
			}
		}

		public List<string> ModKeywords => _modKeywords;

		public string MusicIntensityExpression => _musicIntensityExpression;

		public string[] MusicKeywords => _musicKeywords;

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

		public OrbitData OrbitData { get; set; }

		public PlanetDataScript Parent { get; private set; }

		IPlanetData IPlanetData.Parent => Parent;

		public string ParentAncestryId
		{
			get
			{
				return _parentAncestryId;
			}
			set
			{
				_parentAncestryId = value;
			}
		}

		public CelestialBodyPlanetarySystemDefinedData PlanetarySystemDefinedData
		{
			get
			{
				return _planetarySystemDefinedData;
			}
			private set
			{
				_planetarySystemDefinedData = value;
			}
		}

		public double QuadSphereActivationDistance
		{
			get
			{
				if (_legacyQuadSphereActivationDistance == 0.0)
				{
					if (TerrainData == null)
					{
						Debug.LogError("An error occurred trying to get the 'QuadSphereActivationDistance' for planet '" + Name + "' because the TerrainData is null");
						return 0.0;
					}
					return TerrainData.QualitySettings.Current.QuadSphereActivationDistance;
				}
				return _legacyQuadSphereActivationDistance;
			}
		}

		public double QuadSphereTransitionDistance
		{
			get
			{
				if (_legacyQuadSphereTransitionDistance == 0.0)
				{
					if (TerrainData == null)
					{
						Debug.LogError("An error occurred trying to get the 'QuadSphereTransitionDistance' for planet '" + Name + "' because the TerrainData is null");
						return 0.0;
					}
					return TerrainData.QualitySettings.Current.QuadSphereTransitionDistance;
				}
				return _legacyQuadSphereTransitionDistance;
			}
		}

		public double Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
				RadiusSquared = _radius * _radius;
				RadiusScaledSpace = (_radius + _radiusScaledSpaceHeightAdjustment) * 0.0001;
				EscapeVelocity = CalculateEscapeVelocity(_mass, _radius);
				_impactRadiusSquared = null;
			}
		}

		public double RadiusScaledSpace { get; private set; }

		public double RadiusSquared { get; private set; }

		IPlanetRingsData IPlanetData.RingsData => _ringsData;

		public PlanetRingsData RingsData
		{
			get
			{
				return _ringsData;
			}
			set
			{
				_ringsData = value;
			}
		}

		public CelestialBodyScaleData Scale { get; private set; }

		public CelestialBodyScaleData ScaleDefaults => _scaleDefaults;

		public float SeaLevel
		{
			get
			{
				return _seaLevel;
			}
			set
			{
				_seaLevel = value;
			}
		}

		public bool SkyboxFadeDuringDaytime
		{
			get
			{
				return _skyboxFadeDuringDaytime;
			}
			set
			{
				_skyboxFadeDuringDaytime = value;
			}
		}

		public PlanetShaderData SkyShaderData => _skyShaderData;

		public bool SkyShaderEnabled
		{
			get
			{
				return _skyShaderEnabled;
			}
			set
			{
				_skyShaderEnabled = value;
			}
		}

		public ISolarSystemData SolarSystemData { get; private set; }

		public double? SphereOfInfluence { get; private set; }

		public List<StructureNodeData> StructureNodes => _structureNodes;

		public double SurfaceGravity
		{
			get
			{
				return _surfaceGravity;
			}
			set
			{
				_surfaceGravity = value;
			}
		}

		public bool SyncPropertiesFromTerrain => _syncPropertiesFromTerrain;

		public PlanetTerrainDataScript TerrainData { get; private set; }

		IPlanetTerrainData IPlanetData.TerrainData => TerrainData;

		public PlanetShaderData TerrainShaderData => _terrainShaderData;

		public bool UniformHeight
		{
			get
			{
				return _uniformHeight;
			}
			set
			{
				_uniformHeight = value;
			}
		}

		public Version Version
		{
			get
			{
				return _version;
			}
			set
			{
				_version = value;
			}
		}

		public string VersionTag
		{
			get
			{
				return _versionTag;
			}
			set
			{
				_versionTag = value;
			}
		}

		private PlanetDataScript()
		{
		}

		public static PlanetDataScript CreateFromFile(CelestialFile file, CelestialBodyPlanetarySystemDefinedData planetarySystemDefinedData, PlanetDataScript parentCelestialBody, SolarSystemDataScript planetarySystem, bool createTerrainData, bool applyScaleAndOverrides)
		{
			XDocument xDocument = XDocument.Load(file.Path.FullPath);
			if (xDocument.Root.Name.LocalName != "CelestialBody")
			{
				throw new InvalidOperationException($"An error occurred loading the XML of the celestial body for file '{file.Id}'. " + "The XML loaded successfully but it does not appear to be celestial body XML.");
			}
			return CreateFromXml(xDocument.Root, file, planetarySystemDefinedData, parentCelestialBody, planetarySystem, createTerrainData, applyScaleAndOverrides);
		}

		public static PlanetDataScript CreateFromXml(XElement xml, CelestialFile file, CelestialBodyPlanetarySystemDefinedData planetarySystemDefinedData, PlanetDataScript parentCelestialBody, SolarSystemDataScript planetarySystem, bool createTerrainData, bool applyScaleAndOverrides)
		{
			CelestialBodyFileData fileData = CelestialBodyFileData.LoadFromXml(xml, file.Id);
			int valueOrDefault = ((int?)xml.Attribute("xmlVersion")).GetValueOrDefault();
			if (valueOrDefault < 2)
			{
				CelestialBodyXmlVersionUpdater.Upgrade(xml, valueOrDefault);
			}
			string text = null;
			string text2 = null;
			if (planetarySystemDefinedData != null)
			{
				text = planetarySystemDefinedData.OverrideName;
				text2 = planetarySystemDefinedData.OverrideDescription;
			}
			string text3 = text ?? ((string)xml.Attribute("name"));
			PlanetDataScript planetDataScript = new GameObject(text3).AddComponent<PlanetDataScript>();
			planetDataScript.Id = file.Id;
			planetDataScript.Name = text3;
			planetDataScript.SolarSystemData = planetarySystem;
			planetDataScript.Parent = parentCelestialBody;
			planetDataScript.PlanetarySystemDefinedData = planetarySystemDefinedData ?? new CelestialBodyPlanetarySystemDefinedData();
			planetDataScript._scaleDefaults = CelestialBodyScaleData.CreateFromXml(xml.Element("Scale")) ?? new CelestialBodyScaleData();
			if (applyScaleAndOverrides)
			{
				planetDataScript.Scale = planetDataScript.ScaleDefaults.Clone();
				if (planetarySystemDefinedData?.Scale != null)
				{
					planetDataScript.Scale *= planetarySystemDefinedData.Scale;
				}
				if (planetarySystem != null)
				{
					planetDataScript.Scale *= planetarySystem.Scale;
				}
			}
			else
			{
				planetDataScript.Scale = new CelestialBodyScaleData();
			}
			Transform parent = ((planetDataScript.Parent != null) ? planetDataScript.Parent.transform : ((planetarySystem == null) ? null : planetarySystem.transform));
			planetDataScript.transform.SetParent(parent, worldPositionStays: false);
			planetDataScript.Author = ((string)xml.Attribute("author")) ?? "Unknown";
			planetDataScript.Version = xml.GetVersionAttribute("version", new Version(1, 0));
			planetDataScript.VersionTag = ((string)xml.Attribute("versionTag")) ?? string.Empty;
			planetDataScript.ParentAncestryId = ((string)xml.Attribute("parentAncestryId")) ?? string.Empty;
			planetDataScript.SeaLevel = Utilities.GetFloatAttribute(xml, "seaLevel", 0f);
			planetDataScript.HasTerrainPhysics = Utilities.GetBoolAttribute(xml, "hasTerrainPhysics", defaultValue: true);
			planetDataScript.HasWater = Utilities.GetBoolAttribute(xml, "hasWater", defaultValue: false);
			planetDataScript._radiusScaledSpaceHeightAdjustment = ((double?)xml.Attribute("radiusScaledSpaceHeightAdjustment")).GetValueOrDefault() * (double)planetDataScript.Scale.PlanetScale;
			planetDataScript.Radius = (double)xml.Attribute("radius") * (double)planetDataScript.Scale.PlanetScale;
			planetDataScript._surfaceGravity = (double)xml.Attribute("surfaceGravity") * (double)planetDataScript.Scale.GravityScale;
			planetDataScript._angularVelocity = (double)xml.Attribute("angularVelocity") * (double)planetDataScript.Scale.AngularVelocityScale;
			planetDataScript._uniformHeight = (bool)xml.Attribute("uniformHeight");
			planetDataScript._description = text2 ?? ((string)xml.Element("Description"));
			planetDataScript._modKeywords = new List<string>(((string)xml.Element("ModKeywords"))?.Split(',', StringSplitOptions.RemoveEmptyEntries) ?? new string[0]);
			planetDataScript._musicIntensityExpression = ((string)xml.Element("MusicIntensity")) ?? string.Empty;
			planetDataScript._musicKeywords = ((string)xml.Element("MusicKeywords"))?.Split(',') ?? new string[0];
			planetDataScript._atmosphereData = PlanetAtmosphereData.CreateFromXml(xml.Element("Atmosphere"), planetDataScript);
			planetDataScript._ringsData = PlanetRingsData.CreateFromXml(xml.Element("Rings"), planetDataScript);
			planetDataScript._skyboxFadeDuringDaytime = Utilities.GetBoolAttribute(xml, "skyboxFadeDuringDaytime", defaultValue: true);
			planetDataScript._skyShaderEnabled = Utilities.GetBoolAttribute(xml, "skyShaderEnabled", defaultValue: true);
			planetDataScript._legacyQuadSphereActivationDistance = ((double?)xml.Attribute("legacyQuadSphereActivationDistance")) ?? ((double?)xml.Attribute("quadSphereActivationDistance")).GetValueOrDefault();
			planetDataScript._legacyQuadSphereTransitionDistance = ((double?)xml.Attribute("legacyQuadSphereTransitionDistance")) ?? ((double?)xml.Attribute("quadSphereTransitionDistance")).GetValueOrDefault();
			planetDataScript.EquirectangularMapBrightness = xml.GetFloatAttribute("equirectMapBrightness", 1f);
			planetDataScript.EquirectangularMapLight = xml.GetFloatAttribute("equirectMapLight", 0.5f);
			planetDataScript.CalculateMass();
			planetDataScript.EscapeVelocity = CalculateEscapeVelocity(planetDataScript._mass, planetDataScript._radius);
			planetDataScript.SphereOfInfluence = planetarySystemDefinedData?.SphereOfInfluence;
			if (planetarySystemDefinedData?.Orbit != null)
			{
				planetDataScript.OrbitData = planetarySystemDefinedData.Orbit;
				planetDataScript.OrbitData.SemiMajorAxis *= planetDataScript.Scale.OrbitScale;
			}
			else if (parentCelestialBody != null)
			{
				throw new Exception("Celestial body '" + planetDataScript.Name + "' does not have orbit data but it has a parent celestial body.");
			}
			planetDataScript._terrainDataXml = xml.Element("Terrain");
			planetDataScript.Initialize();
			planetDataScript.File = file;
			planetDataScript.FileData = fileData;
			planetDataScript.GeneratedData = Game.Instance.CelestialDatabase.GetGeneratedData(file.Id);
			if (createTerrainData)
			{
				planetDataScript.LoadTerrainData();
			}
			planetDataScript._name = planetDataScript.Name;
			XElement xElement = xml.Element("TerrainShaderData");
			if (xElement != null)
			{
				planetDataScript._terrainShaderData = PlanetShaderData.CreateFromXml(xElement.Element("PlanetShaderData"));
			}
			else
			{
				planetDataScript._terrainShaderData = new PlanetShaderData();
				planetDataScript._terrainShaderData.SetDefaults(PlanetShaderData.Type.Surface);
			}
			xElement = xml.Element("SkyShaderData");
			if (xElement != null)
			{
				planetDataScript._skyShaderData = PlanetShaderData.CreateFromXml(xElement.Element("PlanetShaderData"));
			}
			else
			{
				planetDataScript._skyShaderData = new PlanetShaderData();
				planetDataScript._skyShaderData.SetDefaults(PlanetShaderData.Type.Sky);
			}
			foreach (XElement item3 in xml.Elements("StructureNodes").Elements("StructureNode"))
			{
				StructureNodeData item = new StructureNodeData(item3);
				planetDataScript._structureNodes.Add(item);
			}
			planetDataScript._defaultLaunchLocations = new List<LaunchLocation>();
			foreach (XElement item4 in xml.Elements("LaunchLocations").Elements("LaunchLocation"))
			{
				LaunchLocation item2 = new LaunchLocation(item4);
				planetDataScript._defaultLaunchLocations.Add(item2);
			}
			return planetDataScript;
		}

		public void CalculateMass()
		{
			_mass = _surfaceGravity * _radius * _radius / 6.67384E-11;
		}

		public RequiredMods GetRequiredMods()
		{
			IModManager modManager = Game.Instance.ModManager;
			if (modManager.LoadedMods.Count == 0)
			{
				return new RequiredMods();
			}
			if (TerrainData == null)
			{
				throw new InvalidOperationException("Terrain data must be loaded to get the required mods.");
			}
			RequiredMods requiredMods = new RequiredMods();
			foreach (PlanetModifier modifier in TerrainData.Modifiers)
			{
				modifier.GetModRequirements(requiredMods.Add);
			}
			foreach (PlanetBiome biome in TerrainData.Biomes)
			{
				foreach (PlanetModifier modifier2 in biome.Modifiers)
				{
					modifier2.GetModRequirements(requiredMods.Add);
				}
			}
			foreach (GameMod gameMod in modManager.GameMods)
			{
				if (gameMod.IsModRequiredForCelestialBody(this))
				{
					requiredMods.Add(gameMod.ModInfo, requiresCodeExecution: true);
				}
			}
			return requiredMods;
		}

		public double GetWaveTime(double gameTime)
		{
			if (TerrainData == null)
			{
				return 0.0;
			}
			PlanetWaterConfig waterConfigDefault = TerrainData.WaterConfigDefault;
			if (waterConfigDefault.WaveSpeed != 0f)
			{
				double num = (double)waterConfigDefault.WaveLength / (double)waterConfigDefault.WaveSpeed;
				double num2 = (double)(int)(gameTime / num) * num;
				return gameTime - num2;
			}
			return gameTime;
		}

		public PlanetTerrainDataScript LoadTerrainData()
		{
			if (_terrainDataXml != null && TerrainData == null)
			{
				TerrainData = PlanetTerrainDataScript.CreateFromXml(_terrainDataXml, this);
			}
			return TerrainData;
		}

		IPlanetTerrainData IPlanetData.LoadTerrainData()
		{
			return LoadTerrainData();
		}

		public PlanetCubemapsRequest RequestCubemaps(string requestName, int size, Action<PlanetCubemapsRequest> onCubemapsUpdated)
		{
			if (_planetCubemapManager == null)
			{
				_planetCubemapManager = SolarSystemData?.PlanetCubemapManager;
				if (_planetCubemapManager == null)
				{
					_planetCubemapManager = new GameObject("PlanetCubemapManager").AddComponent<PlanetCubemapManager>();
					_planetCubemapManager.transform.SetParent(base.transform, worldPositionStays: false);
					_planetCubemapManager.LoadPlanet(this);
				}
			}
			return _planetCubemapManager.RequestCubemaps(requestName, this, size, onCubemapsUpdated);
		}

		public XDocument Save(IReadOnlyList<CelestialFileReference> supportFileReferences)
		{
			base.transform.parent.GetComponentInParent<PlanetDataScript>();
			XElement root = new XDocument(new XElement("CelestialBody")).Root;
			root.SetAttributeValue("name", _name);
			root.SetAttributeValue("author", _author);
			root.SetAttributeValue("version", _version?.ToString() ?? "1.0");
			root.SetAttributeValue("versionTag", _versionTag ?? string.Empty);
			root.SetAttributeValue("xmlVersion", 2);
			root.SetAttributeValue("seaLevel", _seaLevel);
			root.SetAttributeValue("hasTerrainPhysics", _hasTerrainPhysics);
			root.SetAttributeValue("hasWater", _hasWater);
			root.SetAttributeValue("radius", _radius);
			root.SetAttributeValue("surfaceGravity", _surfaceGravity);
			root.SetAttributeValue("angularVelocity", _angularVelocity);
			root.SetAttributeValue("uniformHeight", _uniformHeight);
			root.SetAttributeValue("radiusScaledSpaceHeightAdjustment", _radiusScaledSpaceHeightAdjustment);
			root.SetAttributeValue("skyboxFadeDuringDaytime", _skyboxFadeDuringDaytime);
			root.SetAttributeValue("skyShaderEnabled", _skyShaderEnabled);
			root.Add(new XElement("FileReferences", supportFileReferences.Select((CelestialFileReference x) => x.SaveToXml("File"))));
			root.Add(new XElement("Description", _description));
			root.Add(new XElement("ModKeywords", string.Join(",", _modKeywords)));
			root.Add(new XElement("MusicIntensity", _musicIntensityExpression));
			root.Add(new XElement("MusicKeywords", string.Join(",", _musicKeywords)));
			root.Add(_scaleDefaults.GenerateXml("Scale"));
			root.Add(_atmosphereData.SaveXml(new XElement("Atmosphere")));
			root.Add(_ringsData.SaveXml(new XElement("Rings")));
			root.SetAttributeValue("equirectMapBrightness", EquirectangularMapBrightness);
			root.SetAttributeValue("equirectMapLight", EquirectangularMapLight);
			if (_legacyQuadSphereActivationDistance != 0.0)
			{
				root.SetAttributeValue("legacyQuadSphereActivationDistance", _legacyQuadSphereActivationDistance);
			}
			if (_legacyQuadSphereTransitionDistance != 0.0)
			{
				root.SetAttributeValue("legacyQuadSphereTransitionDistance", _legacyQuadSphereTransitionDistance);
			}
			if (!string.IsNullOrEmpty(_parentAncestryId))
			{
				root.SetAttributeValue("parentAncestryId", _parentAncestryId);
			}
			TerrainData = GetComponentInChildren<PlanetTerrainDataScript>(includeInactive: false);
			if (TerrainData != null)
			{
				root.Add(TerrainData.Save(new XElement("Terrain")));
			}
			else if (_terrainDataXml != null)
			{
				root.Add(_terrainDataXml);
			}
			else
			{
				Debug.LogErrorFormat("Planet '{0}' has no terrain data associated with it.", _name);
			}
			XElement content = _terrainShaderData.SaveXml();
			root.Add(new XElement("TerrainShaderData", content));
			content = _skyShaderData.SaveXml();
			root.Add(new XElement("SkyShaderData", content));
			if (_structureNodes.Count > 0)
			{
				XElement xElement = new XElement("StructureNodes");
				root.Add(xElement);
				foreach (StructureNodeData structureNode in _structureNodes)
				{
					xElement.Add(structureNode.GenerateXml("StructureNode"));
				}
			}
			if (_defaultLaunchLocations.Count > 0)
			{
				root.Add(new XElement("LaunchLocations", _defaultLaunchLocations.Select((LaunchLocation x) => x.GenerateXml(savePlanetName: false))));
			}
			RequiredModsData requiredModsData = new RequiredModsData(GetRequiredMods());
			root.Add(requiredModsData.GenerateXml());
			return root.Document;
		}

		public void UnloadTerrainData()
		{
			if (TerrainData != null)
			{
				UnityEngine.Object.Destroy(TerrainData.gameObject);
				TerrainData = null;
			}
		}

		private static double CalculateEscapeVelocity(double mass, double radius)
		{
			return Mathd.Sqrt(1.334768E-10 * mass / radius);
		}

		private void Initialize()
		{
		}
	}
}
