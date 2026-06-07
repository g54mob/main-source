using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.State.Validation;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Exceptions;
using ModApi.Planet;
using ModApi.Scenes.Parameters;
using ModApi.Scripts.State.Validation;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.State
{
	public class GameState : IGameState
	{
		public const int CurrentXmlVersion = 6;

		public const string LaunchLocationsFileName = "LaunchLocations.xml";

		public const string UserSettingsFileName = "UserSettings.xml";

		private string _rootPath;

		public long AvailableFunds => Career?.Money ?? 0;

		public CareerState Career { get; }

		ICareerState IGameState.Career => Career;

		public string CompanyName { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public CrewManager Crew { get; private set; }

		public string EditorCraftId { get; }

		public string Id { get; }

		public bool IsDefault => Id == "__default__";

		public DateTime LastModifiedDateTime { get; set; }

		public List<LaunchLocation> LaunchLocations { get; private set; }

		public string LaunchLocationsPath
		{
			get
			{
				if (Type == GameStateType.Level)
				{
					string text = _rootPath + "/LaunchLocations.xml";
					if (File.Exists(text))
					{
						return text;
					}
				}
				return _rootPath + "/../LaunchLocations.xml";
			}
		}

		public bool MenuTutorialComplete { get; set; }

		public GameStateMode Mode { get; set; }

		public bool NotSupported { get; }

		public string Parent { get; set; }

		public FlightSceneLoadParameters PreflightLoadParameters { get; set; }

		public string RootPath => _rootPath;

		public string SelectedCraftDesignId { get; set; }

		public int? SelectedCraftNodeId { get; set; }

		public LaunchLocation SelectedLaunchLocation { get; set; }

		public GameStateType Type { get; set; }

		public GameStateUserSettings UserSettings { get; }

		public IGameStateValidator Validator { get; private set; }

		public GameState(string id, string rootPath, string careerModePath = "Default")
		{
			_rootPath = rootPath;
			Id = id;
			FileInfo fileInfo = new FileInfo(rootPath + "/GameState.xml");
			XElement xElement = XDocument.Load(fileInfo.FullName).Element("GameState");
			UserSettings = new GameStateUserSettings(_rootPath + "/../UserSettings.xml");
			int intAttribute = Utilities.GetIntAttribute(xElement, "xmlVersion", 1);
			if (intAttribute > 6)
			{
				throw new XmlVersionException();
			}
			if (intAttribute < 6)
			{
				GameStateXmlVersionUpdater.Upgrade(this, xElement, intAttribute);
			}
			CompanyName = xElement.GetStringAttribute("companyName", string.Empty);
			Mode = xElement.GetEnumAttribute("mode", GameStateMode.Sandbox);
			Type = xElement.GetEnumAttribute("type", GameStateType.Default);
			LastModifiedDateTime = xElement.GetDateTimeAttribute("lastModifiedTime", fileInfo.LastWriteTime);
			CreatedDateTime = xElement.GetDateTimeAttribute("createdTime", fileInfo.CreationTime);
			Parent = xElement.GetStringAttribute("parent");
			Crew = new CrewManager(xElement.Element("CrewMembers"), this);
			MenuTutorialComplete = xElement.GetBoolAttribute("menuTutorialComplete");
			NotSupported = xElement.GetBoolAttribute("notSupported");
			LaunchLocations = new List<LaunchLocation>();
			if (File.Exists(LaunchLocationsPath))
			{
				foreach (XElement item in XDocument.Load(LaunchLocationsPath).Element("LaunchLocations").Elements())
				{
					LaunchLocation launchLocation = new LaunchLocation(item);
					if (item.GetBoolAttribute("selected"))
					{
						SelectedLaunchLocation = launchLocation;
					}
					LaunchLocations.Add(launchLocation);
				}
				if (SelectedLaunchLocation == null)
				{
					SelectedLaunchLocation = LaunchLocations.FirstOrDefault();
				}
			}
			EditorCraftId = xElement.GetStringAttribute("editorCraftId");
			if (string.IsNullOrEmpty(EditorCraftId))
			{
				string text = null;
				if (Type == GameStateType.Level)
				{
					text = "__new__";
					EditorCraftId = "__editor_level__";
				}
				else
				{
					text = ((EditorCraftId == null) ? "__editor__" : ((Mode == GameStateMode.Career) ? "__new_career__" : "__new__"));
					EditorCraftId = (Guid.TryParse(id, out var _) ? ("__editor_" + id + "__") : $"__editor_{Guid.NewGuid()}__");
				}
				try
				{
					FileInfo craftFile = Game.Instance.CraftDesigns.GetCraftFile(text);
					FileInfo craftFile2 = Game.Instance.CraftDesigns.GetCraftFile(EditorCraftId);
					if (craftFile.Exists && !craftFile2.Exists)
					{
						craftFile.CopyTo(craftFile2.FullName);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			SelectedCraftDesignId = xElement.GetStringAttribute("selectedCraftDesign", EditorCraftId);
			if (Mode == GameStateMode.Career)
			{
				XElement xElement2 = xElement.Element("Career");
				string path = xElement2?.GetStringAttribute("path") ?? careerModePath;
				Career = new CareerState(path, xElement2, this);
				if (string.IsNullOrWhiteSpace(Career.Path))
				{
					throw new Exception("Could not load gamestate '" + CompanyName + "' (id '" + Id + "') because it does not specify a valid path for its career folder.");
				}
				Validator = new CareerValidator(Career);
			}
			else
			{
				Validator = new SandboxValidator();
			}
			PreflightLoadParameters = FlightSceneLoadParameters.RestorePreflightData(xElement.Element("PreflightLoadParameters"), this);
		}

		public double GetCurrentTime()
		{
			return LoadFlightStateData().Time;
		}

		public string GetTagActive()
		{
			return Type switch
			{
				GameStateType.Default => "Active", 
				GameStateType.Level => "Level.Active", 
				GameStateType.PlanetStudio => "PlanetStudio.Active", 
				GameStateType.Simulation => "Simulation.Active", 
				_ => throw new NotSupportedException($"GameStateType '{Type}' not supported by this method."), 
			};
		}

		public string GetTagPreFlight()
		{
			return Type switch
			{
				GameStateType.Default => "PreFlight", 
				GameStateType.Level => "Level.PreFlight", 
				GameStateType.PlanetStudio => "PlanetStudio.PreFlight", 
				GameStateType.Simulation => "Simulation.PreFlight", 
				_ => throw new NotSupportedException($"GameStateType '{Type}' not supported by this method."), 
			};
		}

		public string GetTagQuicksave()
		{
			return Type switch
			{
				GameStateType.Default => "QuickSave", 
				GameStateType.Level => null, 
				GameStateType.PlanetStudio => "PlanetStudio.QuickSave", 
				GameStateType.Simulation => "Simulation.QuickSave", 
				_ => throw new NotSupportedException($"GameStateType '{Type}' not supported by this method."), 
			};
		}

		public void InitializeDefaultSandboxLaunchLocations(SolarSystemDataScript planetarySystem)
		{
			if (Mode != GameStateMode.Sandbox)
			{
				return;
			}
			int count = LaunchLocations.Count;
			LaunchLocations = planetarySystem.GetDefaultLaunchLocations().Concat(LaunchLocations.Where((LaunchLocation x) => x.UserCreated)).ToList();
			if (SelectedLaunchLocation != null && !SelectedLaunchLocation.UserCreated)
			{
				SelectedLaunchLocation = LaunchLocations.FirstOrDefault((LaunchLocation x) => !x.UserCreated && x.Name == SelectedLaunchLocation.Name);
			}
			if (SelectedLaunchLocation == null)
			{
				SelectedLaunchLocation = LaunchLocations.Where((LaunchLocation x) => !string.IsNullOrWhiteSpace(x.PlanetName)).FirstOrDefault();
			}
			if (count != LaunchLocations.Count)
			{
				SaveLaunchLocations();
			}
		}

		public FlightState LoadFlightState()
		{
			return new FlightState(LoadFlightStateData());
		}

		public FlightStateData LoadFlightStateData()
		{
			return new FlightStateData(Utilities.CombinePaths(_rootPath, "FlightState.xml"));
		}

		public void Save()
		{
			XElement xElement = new XElement("GameState");
			xElement.SetAttributeValue("xmlVersion", 6);
			xElement.SetAttributeValue("companyName", CompanyName);
			xElement.SetAttributeValue("mode", Mode);
			xElement.SetAttributeValue("type", Type);
			xElement.SetAttributeValue("parent", Parent);
			xElement.SetAttributeValue("lastModifiedTime", DateTime.Now);
			xElement.SetAttributeValue("createdTime", CreatedDateTime);
			xElement.SetAttributeValue("menuTutorialComplete", MenuTutorialComplete);
			xElement.SetAttributeValue("editorCraftId", EditorCraftId);
			if (NotSupported)
			{
				xElement.SetAttributeValue("notSupported", NotSupported);
			}
			if (SelectedCraftDesignId != EditorCraftId)
			{
				xElement.SetAttributeValue("selectedCraftDesign", SelectedCraftDesignId);
			}
			if (PreflightLoadParameters != null)
			{
				xElement.Add(PreflightLoadParameters.SavePreflightData("PreflightLoadParameters"));
			}
			if (Mode == GameStateMode.Career)
			{
				xElement.Add(Career.GenerateXml());
			}
			xElement.Add(Crew.GenerateXml());
			new XDocument(xElement).Save(_rootPath + "/GameState.xml");
		}

		public void SaveLaunchLocations()
		{
			XElement xElement = new XElement("LaunchLocations");
			List<LaunchLocation> list = LaunchLocations.Where((LaunchLocation x) => !x.UserCreated).ToList();
			list.AddRange(from x in LaunchLocations
				where x.UserCreated
				orderby x.Name
				select x);
			foreach (LaunchLocation item in list)
			{
				XElement xElement2 = item.GenerateXml();
				if (item == SelectedLaunchLocation)
				{
					xElement2.SetAttributeValue("selected", true);
				}
				xElement.Add(xElement2);
			}
			XDocument xDocument = new XDocument();
			xDocument.Add(xElement);
			xDocument.Save(LaunchLocationsPath);
		}
	}
}
