using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Mods;
using ModApi.PlanetStudio;
using ModApi.Scenes;
using ModApi.State;
using UnityEngine;

namespace ModApi.Planet
{
	public class SolarSystemDataScript : MonoBehaviour, ISolarSystemData
	{
		public const int CurrentXmlVersion = 1;

		public const double DefaultMapViewScale = 1E-05;

		public const double DefaultMaxZoom = 500000000000.0;

		[SerializeField]
		private string _author;

		private List<LaunchLocation> _defaultLaunchLocations;

		[SerializeField]
		private string _description;

		private Guid _id;

		[SerializeField]
		private string _name;

		[SerializeField]
		private string _parentAncestryId;

		[SerializeField]
		private PlanetCubemapManager _planetCubemapManager;

		[SerializeField]
		private CelestialBodyScaleData _scaleDefaults;

		[SerializeField]
		private SkyboxData _skyboxData;

		private Material _skyboxMaterial;

		private List<Texture2D> _skyboxTextures;

		[SerializeField]
		private Version _version;

		[SerializeField]
		private string _versionTag;

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

		public CelestialFile File { get; private set; }

		public PlanetarySystemFileData FileData { get; private set; }

		public Color FlareColor { get; set; }

		public Guid Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public bool IsDefaultSystem => Id == Game.Instance.CelestialDatabase.DefaultPlanetarySystemV2Id;

		public double MapViewScale { get; set; }

		public double MaximumMapViewZoom { get; set; }

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

		public PlanetCubemapManager PlanetCubemapManager
		{
			get
			{
				if (_planetCubemapManager == null)
				{
					_planetCubemapManager = new GameObject("PlanetCubemapManager").AddComponent<PlanetCubemapManager>();
					_planetCubemapManager.transform.SetParent(base.transform, worldPositionStays: false);
					_planetCubemapManager.LoadSystem(this);
				}
				return _planetCubemapManager;
			}
		}

		public List<PlanetDataScript> Planets { get; set; }

		IReadOnlyList<IPlanetData> ISolarSystemData.Planets => Planets;

		public CelestialBodyScaleData Scale { get; private set; }

		public CelestialBodyScaleData ScaleDefaults => _scaleDefaults;

		public SkyboxData SkyboxData
		{
			get
			{
				return _skyboxData;
			}
			private set
			{
				_skyboxData = value;
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

		public static SolarSystemDataScript CreateFromFile(CelestialFile file, bool createTerrainData, bool applyScaleAndOverrides)
		{
			return CreateFromFile(file, new GameObject("PlanetarySystemData"), createTerrainData, applyScaleAndOverrides);
		}

		public static SolarSystemDataScript CreateFromFile(CelestialFile file, GameObject obj, bool createTerrainData, bool applyScaleAndOverrides)
		{
			PlanetarySystemFileData fileData = Game.Instance.CelestialDatabase.GetPlanetarySystem(file.Id);
			if (fileData == null)
			{
				throw new Exception($"Could not find planetary system file with id '{file.Id}'.");
			}
			XElement root = LoadXml(file).Root;
			SolarSystemDataScript script = obj.GetComponent<SolarSystemDataScript>();
			if (script == null)
			{
				script = obj.AddComponent<SolarSystemDataScript>();
			}
			else
			{
				List<GameObject> list = new List<GameObject>();
				foreach (Transform item2 in obj.transform)
				{
					list.Add(item2.gameObject);
				}
				foreach (GameObject item3 in list)
				{
					UnityEngine.Object.DestroyImmediate(item3);
				}
			}
			script.Id = file.Id;
			script.Name = (string)root.Attribute("name");
			script.Author = ((string)root.Attribute("author")) ?? "Unknown";
			script.Version = root.GetVersionAttribute("version", new Version(1, 0));
			script.VersionTag = ((string)root.Attribute("versionTag")) ?? string.Empty;
			script.ParentAncestryId = ((string)root.Attribute("parentAncestryId")) ?? string.Empty;
			script.Description = root.Element("Description")?.Value;
			Color? colorAttribute = root.GetColorAttribute("flareColor");
			script.FlareColor = colorAttribute ?? new Color(1f, 1f, 1f, 1f);
			XAttribute xAttribute = root.Attribute("maxZoomDistance");
			script.MaximumMapViewZoom = ((xAttribute != null) ? ((double)float.Parse(xAttribute.Value)) : 500000000000.0);
			XAttribute xAttribute2 = root.Attribute("mapViewScale");
			script.MapViewScale = ((xAttribute2 != null) ? ((double)float.Parse(xAttribute2.Value)) : 1E-05);
			script.File = file;
			script.FileData = fileData;
			script._scaleDefaults = CelestialBodyScaleData.CreateFromXml(root.Element("Scale")) ?? new CelestialBodyScaleData();
			script.Scale = (applyScaleAndOverrides ? script._scaleDefaults.Clone() : new CelestialBodyScaleData());
			script.SkyboxData = SkyboxData.LoadFromXml(root.Element("Skybox"));
			script.Planets = new List<PlanetDataScript>();
			var celestialBodies = (from x in root.Elements("CelestialBodies").Elements("CelestialBody")
				select new
				{
					FileId = (string)x.Attribute("id"),
					ParentFileId = (string)x.Attribute("parent"),
					File = fileData.GetCelestialBodyFile(((string)x.Attribute("id")) ?? string.Empty),
					ParentFile = fileData.GetCelestialBodyFile(((string)x.Attribute("parent")) ?? string.Empty),
					Data = new CelestialBodyPlanetarySystemDefinedData(x.Element("Data")),
					Xml = x
				}).ToList();
			for (int num = celestialBodies.Count - 1; num >= 0; num--)
			{
				var anon = celestialBodies[num];
				if (anon.File == null)
				{
					Debug.LogError("Unable to find file for celestial body with id '" + anon.FileId + "'");
					celestialBodies.RemoveAt(num);
				}
				else if (!string.IsNullOrWhiteSpace(anon.ParentFileId) && anon.ParentFile == null)
				{
					Debug.LogError("Unable to find parent file for celestial body with id '" + anon.FileId + "' and parent id '" + anon.ParentFileId + "'");
					celestialBodies.RemoveAt(num);
				}
				else
				{
					for (int num2 = num - 1; num2 >= 0; num2--)
					{
						if (celestialBodies[num2].FileId == anon.FileId)
						{
							Debug.LogError("The system contains more than one celestial body with id '" + anon.FileId + "'. Duplicates will be removed.");
							celestialBodies.RemoveAt(num);
							break;
						}
					}
				}
			}
			CreateBodiesRecursively(null);
			script._defaultLaunchLocations = new List<LaunchLocation>();
			foreach (XElement item4 in root.Elements("LaunchLocations").Elements("LaunchLocation"))
			{
				LaunchLocation item = new LaunchLocation(item4);
				script._defaultLaunchLocations.Add(item);
			}
			return script;
			void CreateBodiesRecursively(Guid? parentId)
			{
				PlanetDataScript parentCelestialBody = (parentId.HasValue ? script.Planets.Single(delegate(PlanetDataScript x)
				{
					Guid id = x.Id;
					Guid? guid = parentId;
					return id == guid;
				}) : null);
				foreach (var item5 in celestialBodies.Where(x =>
				{
					CelestialFile parentFile = x.ParentFile;
					if (parentFile == null)
					{
						return !parentId.HasValue;
					}
					Guid id = parentFile.Id;
					Guid? guid = parentId;
					return id == guid;
				}))
				{
					PlanetDataScript planetDataScript = script.CreateCelestialBody(item5.File, item5.Data, parentCelestialBody, createTerrainData, applyScaleAndOverrides);
					CreateBodiesRecursively(planetDataScript.Id);
				}
			}
		}

		public static XDocument LoadXml(CelestialFile file)
		{
			XDocument xDocument = XDocument.Load(file.Path.FullPath);
			if (xDocument.Root.Name.LocalName != "PlanetarySystem")
			{
				throw new InvalidOperationException($"An error occurred loading the XML of the planetary system for file '{file.Id}'. " + "The XML loaded successfully but it does not appear to be planetary system XML.");
			}
			int valueOrDefault = ((int?)xDocument.Root.Attribute("xmlVersion")).GetValueOrDefault();
			if (valueOrDefault < 1)
			{
				PlanetarySystemXmlVersionUpdater.Upgrade(xDocument.Root, valueOrDefault);
			}
			return xDocument;
		}

		public void ApplyCustomSkybox()
		{
			if (_skyboxData != null)
			{
				UnloadCustomSkybox();
				_skyboxTextures = new List<Texture2D>(6);
				_skyboxTextures.Add(LoadCustomSkyboxTexture(_skyboxData.XPositiveTextureId));
				_skyboxTextures.Add(LoadCustomSkyboxTexture(_skyboxData.XNegativeTextureId));
				_skyboxTextures.Add(LoadCustomSkyboxTexture(_skyboxData.YPositiveTextureId));
				_skyboxTextures.Add(LoadCustomSkyboxTexture(_skyboxData.YNegativeTextureId));
				_skyboxTextures.Add(LoadCustomSkyboxTexture(_skyboxData.ZPositiveTextureId));
				_skyboxTextures.Add(LoadCustomSkyboxTexture(_skyboxData.ZNegativeTextureId));
				_skyboxMaterial = UnityEngine.Object.Instantiate(Game.Instance.ResourceLoader.LoadMaterial("Planets/Materials/SkyboxMaterials/CustomSkyboxMaterial"));
				_skyboxMaterial.SetTexture("_LeftTex", _skyboxTextures[0]);
				_skyboxMaterial.SetTexture("_RightTex", _skyboxTextures[1]);
				_skyboxMaterial.SetTexture("_UpTex", _skyboxTextures[2]);
				_skyboxMaterial.SetTexture("_DownTex", _skyboxTextures[3]);
				_skyboxMaterial.SetTexture("_FrontTex", _skyboxTextures[4]);
				_skyboxMaterial.SetTexture("_BackTex", _skyboxTextures[5]);
				_skyboxMaterial.SetFloat("_Exposure", _skyboxData.Exposure);
				_skyboxMaterial.SetFloat("_Rotation", _skyboxData.Rotation);
				_skyboxMaterial.SetColor("_Tint", _skyboxData.Tint);
				SceneSkybox.ReplaceSkybox(_skyboxMaterial, isCustom: true);
			}
		}

		public PlanetDataScript CreateCelestialBody(CelestialFile file, CelestialBodyPlanetarySystemDefinedData planetarySystemDefinedData, PlanetDataScript parentCelestialBody, bool createTerrainData, bool applyScaleAndOverrides)
		{
			PlanetDataScript planetDataScript = PlanetDataScript.CreateFromFile(file, planetarySystemDefinedData, parentCelestialBody, this, createTerrainData, applyScaleAndOverrides);
			Planets.Add(planetDataScript);
			return planetDataScript;
		}

		public List<LaunchLocation> GetDefaultLaunchLocations()
		{
			List<LaunchLocation> list = new List<LaunchLocation>(_defaultLaunchLocations.Count);
			foreach (LaunchLocation launchLocation in _defaultLaunchLocations)
			{
				CelestialFile file;
				if (Game.InPlanetStudioScene)
				{
					file = (string.IsNullOrWhiteSpace(launchLocation.PlanetName) ? null : (from x in PlanetStudioBase.Instance.PlanetarySystemDesigner.CelestialBodyFiles
						where x.Id == launchLocation.PlanetName
						select x.File).FirstOrDefault());
				}
				else
				{
					file = (string.IsNullOrWhiteSpace(launchLocation.PlanetName) ? null : FileData.GetCelestialBodyFile(launchLocation.PlanetName));
				}
				PlanetDataScript planetDataScript = Planets.FirstOrDefault((PlanetDataScript x) => x.Id == (file?.Id ?? Guid.Empty));
				if (planetDataScript == null)
				{
					Debug.LogError("Unable to find the celestial body '" + launchLocation.PlanetName + "' associated with default launch location: " + launchLocation.GenerateXml().ToString());
					continue;
				}
				LaunchLocation launchLocation2 = new LaunchLocation(launchLocation);
				launchLocation2.PlanetName = planetDataScript.Name;
				launchLocation2.UserCreated = false;
				list.Add(launchLocation2);
			}
			return list;
		}

		public PlanetDataScript GetPlanetData(string planetName)
		{
			foreach (PlanetDataScript planet in Planets)
			{
				if (planet.Name == planetName)
				{
					return planet;
				}
			}
			return null;
		}

		IPlanetData ISolarSystemData.GetPlanetData(string planetName)
		{
			return GetPlanetData(planetName);
		}

		public RequiredModsData GetRequiredMods()
		{
			RequiredModsData requiredModsData = new RequiredModsData();
			foreach (PlanetDataScript planet in Planets)
			{
				requiredModsData.Add(planet.FileData.RequiredMods);
			}
			foreach (GameMod gameMod in Game.Instance.ModManager.GameMods)
			{
				if (gameMod.IsModRequiredForPlanetarySystem(this))
				{
					requiredModsData.Add(new RequiredModData(gameMod.ModInfo, requiresCodeExecution: true));
				}
			}
			return requiredModsData;
		}

		public XDocument Save(IReadOnlyList<CelestialFileReference> fileReferences)
		{
			CelestialDatabase db = Game.Instance.CelestialDatabase;
			var references = fileReferences.Select((CelestialFileReference x) => new
			{
				FileId = db.GetFile(x).Id,
				LocalId = x.LocalId
			});
			var source = Planets.Select((PlanetDataScript x) => new
			{
				LocalId = references.First(r => r.FileId == x.FileData.FileId).LocalId,
				ParentLocalId = references.FirstOrDefault(r =>
				{
					Guid fileId = r.FileId;
					Guid? obj = x.Parent?.FileData.FileId;
					return fileId == obj;
				})?.LocalId,
				Script = x
			});
			RequiredModsData requiredMods = GetRequiredMods();
			return new XDocument(new XElement("PlanetarySystem", new XAttribute("name", Name), new XAttribute("author", _author), new XAttribute("version", _version?.ToString() ?? "1.0"), new XAttribute("versionTag", _versionTag ?? string.Empty), new XAttribute("xmlVersion", 1), new XAttribute("flareColor", FlareColor.ToXAttributeValue()), new XAttribute("maxZoomDistance", MaximumMapViewZoom.ToString("0.###e-0")), new XAttribute("mapViewScale", MapViewScale.ToString("0.###e-0")), string.IsNullOrEmpty(_parentAncestryId) ? null : new XAttribute("parentAncestryId", _parentAncestryId), new XElement("FileReferences", fileReferences.Select((CelestialFileReference x) => x.SaveToXml("File"))), string.IsNullOrWhiteSpace(Description) ? null : new XElement("Description", Description), _scaleDefaults.GenerateXml("Scale"), SkyboxData?.GenerateXml("Skybox"), new XElement("CelestialBodies", source.Select(x => new XElement("CelestialBody", new XAttribute("id", x.LocalId), (x.ParentLocalId == null) ? null : new XAttribute("parent", x.ParentLocalId), x.Script.PlanetarySystemDefinedData?.GenerateXml("Data", x.ParentLocalId != null)))), (_defaultLaunchLocations.Count == 0) ? null : new XElement("LaunchLocations", _defaultLaunchLocations.Select((LaunchLocation x) => x.GenerateXml())), requiredMods.GenerateXml()));
		}

		public void SetLaunchLocations(List<LaunchLocation> launchLocations)
		{
			_defaultLaunchLocations.Clear();
			_defaultLaunchLocations.AddRange(launchLocations);
		}

		protected virtual void OnDestroy()
		{
			UnloadCustomSkybox();
		}

		private Texture2D LoadCustomSkyboxTexture(string id)
		{
			CelestialFile referencedFile = FileData.GetReferencedFile(id);
			if (referencedFile == null)
			{
				Debug.LogError("Unable to load custom skybox texture with id '" + id + "'. The referenced file could not be found.");
				return null;
			}
			Texture2D texture2D = referencedFile.LoadTexture(mipmaps: true, linear: false, markNonReadable: true);
			if (texture2D == null)
			{
				Debug.LogError("Unable to load custom skybox texture with id '" + id + "'. The file existed but could not be loaded as a texture.");
			}
			texture2D.name = "Custom_Skybox_" + id;
			return texture2D;
		}

		private void UnloadCustomSkybox()
		{
			if (_skyboxMaterial != null)
			{
				SceneSkybox.UnloadSkybox();
				if (_skyboxMaterial != null)
				{
					UnityEngine.Object.Destroy(_skyboxMaterial);
				}
				_skyboxMaterial = null;
			}
			if (_skyboxTextures == null)
			{
				return;
			}
			foreach (Texture2D skyboxTexture in _skyboxTextures)
			{
				if (skyboxTexture != null)
				{
					UnityEngine.Object.Destroy(skyboxTexture);
				}
			}
			_skyboxTextures.Clear();
			_skyboxTextures = null;
		}
	}
}
