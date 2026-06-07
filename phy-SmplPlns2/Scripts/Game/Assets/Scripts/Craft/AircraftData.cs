using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Craft.Exceptions;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tutorials;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class AircraftData
	{
		public const int CurrentXmlVersion = 23;

		public CraftAerodynamicsModelType AerodynamicsModelType { get; set; }

		public Assembly Assembly { get; set; }

		public Vector3 BoundsMinimum { get; set; }

		public Vector3 BoundsOffset { get; set; }

		public CraftDrag CraftDrag { get; private set; }

		public ThemeData CurrentTheme { get; set; }

		public ThemeData CustomTheme { get; set; }

		public int? DamageLimit { get; set; }

		public bool DiffuseInertiaTensors { get; set; }

		public string Instructions { get; set; }

		public bool LegacyJointIdentification { get; set; }

		public CraftLoadContext LoadContext { get; }

		public float MirrorPlaneOffset { get; set; }

		public string Name { get; set; }

		public Vector3 PaintOrigin { get; set; }

		public Vector3 Size { get; set; }

		public List<string> Tags { get; }

		public IReadOnlyList<TutorialInfo> Tutorials { get; }

		public string Url { get; set; }

		public bool UseOldDragCalculation { get; set; }

		public List<VariableSetter> VariableSetters { get; private set; }

		public int XmlVersion { get; set; }

		public static event EventHandler<AircraftGeneratedEventArgs> AircraftGenerated;

		public AircraftData(XElement aircraftElement, CraftLoadContext loadContext)
		{
			if (aircraftElement == null)
			{
				throw new ArgumentNullException("aircraftElement", "Attempting to instantiate an aircraft with a null XElement");
			}
			XmlVersion = aircraftElement.GetIntAttribute("xmlVersion", 1);
			if (XmlVersion > 23)
			{
				throw new XmlVersionException();
			}
			if (XmlVersion == 7)
			{
				JWingData.UpgradeControlSurfaces(aircraftElement);
			}
			XElement xElement = aircraftElement.Element("Variables");
			if (XmlVersion <= 7)
			{
				VariableSetter.UpgradeLegacyFlapsSetters(aircraftElement, xElement);
			}
			LoadContext = loadContext;
			Name = aircraftElement.Attribute("name").Value;
			Tags = aircraftElement.GetStringListAttribute("tags");
			AerodynamicsModelType = aircraftElement.GetEnumAttribute("aerodynamicsModel", (XmlVersion >= 20) ? CraftAerodynamicsModelType.StandardV1 : CraftAerodynamicsModelType.Legacy);
			PaintOrigin = aircraftElement.GetVector3Attribute("paintOrigin", new Vector3(0f, 2.5f, 0f));
			MirrorPlaneOffset = aircraftElement.GetFloatAttribute("mirrorPlaneOffset");
			Size = aircraftElement.GetVector3Attribute("size", Vector3.zero);
			BoundsOffset = aircraftElement.GetVector3Attribute("boundsOffset", Vector3.zero);
			BoundsMinimum = aircraftElement.GetVector3Attribute("boundsMin", Vector3.zero);
			Url = aircraftElement.GetStringAttribute("url", string.Empty);
			UseOldDragCalculation = aircraftElement.GetBoolAttribute("useOldDragCalculation");
			DiffuseInertiaTensors = aircraftElement.GetBoolAttribute("diffuseInertiaTensors", defaultValue: true);
			DamageLimit = (int?)aircraftElement.Attribute("damageLimit");
			Instructions = (string)aircraftElement.Element("Instructions");
			Tutorials = (from x in aircraftElement.Elements("Tutorials").Elements("Tutorial")
				select new TutorialInfo((string)x.Attribute("name"), x)).ToList();
			CraftDrag = new CraftDrag(aircraftElement.Element("CraftDrag"));
			LegacyJointIdentification = aircraftElement.GetBoolAttribute("legacyJointIdentification", defaultValue: true);
			XElement assemblyElement = aircraftElement.Element("Assembly");
			Assembly = new Assembly(assemblyElement, XmlVersion, loadContext);
			if (aircraftElement.Attribute("boundsOffset") == null)
			{
				PartData partData = Assembly.Parts.Where((PartData x) => x.GetModifier<CockpitData>()?.PrimaryCockpit ?? false).FirstOrDefault();
				if (partData != null)
				{
					BoundsOffset = partData.Position - (BoundsMinimum + Size / 2f);
				}
			}
			XElement xElement2 = aircraftElement.Element("Theme");
			if (xElement2 != null)
			{
				CustomTheme = new ThemeData(xElement2, XmlVersion);
			}
			else
			{
				CustomTheme = Game.Instance.AircraftThemes.GetTheme("Custom");
			}
			string value = aircraftElement.Attribute("theme").Value;
			if (value == "Custom")
			{
				CurrentTheme = CustomTheme;
				int[] partMaterialReassignments = CurrentTheme.PartMaterialReassignments;
				if (partMaterialReassignments != null && partMaterialReassignments.Length != 0)
				{
					foreach (PartData part in Assembly.Parts)
					{
						List<int> materialIds = part.MaterialIds;
						for (int num = 0; num < materialIds.Count; num++)
						{
							int num2 = materialIds[num];
							if (num2 >= 0)
							{
								materialIds[num] = ((num2 < partMaterialReassignments.Length) ? partMaterialReassignments[num2] : 0);
							}
						}
					}
				}
			}
			else
			{
				CurrentTheme = Game.Instance.AircraftThemes.GetTheme(value);
			}
			VariableSetters = new List<VariableSetter>();
			if (xElement != null)
			{
				foreach (XElement item in xElement.Elements("Setter"))
				{
					VariableSetter variableSetter = VariableSetter.LoadFromXml(item);
					if (variableSetter != null)
					{
						VariableSetters.Add(variableSetter);
					}
				}
			}
			SetPrimaryCockpitIfNonExist();
		}

		public static GameObject GenerateGameObject(AircraftData aircraft, PartData.PartCreationInfo partCreationInfo, ushort teamId)
		{
			GameObject gameObject = new GameObject("Aircraft");
			AircraftScript aircraftScript = gameObject.AddComponent<AircraftScript>();
			aircraftScript.Initialize(aircraft, teamId);
			aircraftScript.Aircraft.Assembly.CreateGameObjects(aircraftScript, partCreationInfo, aircraftScript.Children);
			aircraftScript.RebuildAircraftStructure();
			AircraftData.AircraftGenerated?.Invoke(null, new AircraftGeneratedEventArgs(aircraftScript));
			return gameObject;
		}

		public static GameObject GenerateGameObjectMultipleFrames(AircraftData aircraft, PartData.PartCreationInfo partCreationInfo, ushort teamId, Action onDone)
		{
			GameObject gameObject = new GameObject("Aircraft");
			AircraftScript aircraftScript = gameObject.AddComponent<AircraftScript>();
			aircraftScript.Initialize(aircraft, teamId);
			aircraftScript.Aircraft.Assembly.CreateGameObjectsMultipleFrames(aircraftScript, partCreationInfo, aircraftScript.Children, delegate(bool success, string message, Exception exception)
			{
				if (exception != null)
				{
					Debug.LogException(exception);
				}
				if (!success)
				{
					Debug.LogError("An error occurred trying to load the craft over multiple frames. " + (message ?? string.Empty));
				}
				aircraftScript.RebuildAircraftStructure();
				AircraftData.AircraftGenerated?.Invoke(null, new AircraftGeneratedEventArgs(aircraftScript));
				onDone?.Invoke();
			});
			return gameObject;
		}

		public XElement GenerateXml(bool createRigidBodyGroups, bool serializeStats = false)
		{
			int num = 23;
			XElement xElement = new XElement("Specifications");
			AircraftScript aircraftScript = Assembly?.Parts[0]?.PartScript?.Aircraft;
			if (serializeStats && aircraftScript != null)
			{
				AircraftScript.AircraftStats[] array = (AircraftScript.AircraftStats[])Enum.GetValues(typeof(AircraftScript.AircraftStats));
				for (int i = 0; i < array.Length; i++)
				{
					AircraftScript.AircraftStats statsToGet = array[i];
					xElement.Add(new XAttribute(statsToGet.ToString(), aircraftScript.GetStats(statsToGet)));
				}
			}
			XElement xElement2 = new XElement("Variables");
			if (VariableSetters != null)
			{
				foreach (VariableSetter variableSetter in VariableSetters)
				{
					xElement2.Add(variableSetter.SaveToXml());
				}
			}
			XElement xElement3 = new XElement("Aircraft", new XAttribute("name", Name), new XAttribute("tags", string.Join(",", Tags)), new XAttribute("url", Url), new XAttribute("theme", CurrentTheme.Name), (AerodynamicsModelType == CraftAerodynamicsModelType.StandardV1) ? null : new XAttribute("aerodynamicsModel", AerodynamicsModelType), new XAttribute("paintOrigin", PaintOrigin.ToXAttributeValue()), (MirrorPlaneOffset == 0f) ? null : new XAttribute("mirrorPlaneOffset", MirrorPlaneOffset), new XAttribute("size", Size.ToXAttributeValue()), new XAttribute("boundsOffset", BoundsOffset.ToXAttributeValue()), new XAttribute("boundsMin", BoundsMinimum.ToXAttributeValue()), new XAttribute("xmlVersion", num), new XAttribute("legacyJointIdentification", LegacyJointIdentification), new XAttribute("clientVersion", Game.Version.ToString()), xElement, xElement2, Assembly.GenerateXml(createRigidBodyGroups), CustomTheme.GenerateXml());
			XElement xElement4 = new XElement("CraftDrag");
			CraftDrag.WriteToXml(xElement4);
			xElement3.Add(xElement4);
			if (UseOldDragCalculation)
			{
				xElement3.Add(new XAttribute("useOldDragCalculation", true));
			}
			if (!DiffuseInertiaTensors)
			{
				xElement3.Add(new XAttribute("diffuseInertiaTensors", DiffuseInertiaTensors));
			}
			if (!string.IsNullOrWhiteSpace(Instructions))
			{
				xElement3.Add(new XElement("Instructions", Instructions));
			}
			if (Tutorials.Count > 0)
			{
				xElement3.Add(new XElement("Tutorials", Tutorials.Select((TutorialInfo x) => new XElement("Tutorial", new XAttribute("name", x.Name), x.Xml))));
			}
			return xElement3;
		}

		private void SetPrimaryCockpitIfNonExist()
		{
			CockpitData cockpitData = null;
			CockpitData cockpitData2 = null;
			foreach (PartData part in Assembly.Parts)
			{
				CockpitData modifier = part.GetModifier<CockpitData>();
				if (modifier != null)
				{
					if (cockpitData == null)
					{
						cockpitData = modifier;
					}
					if (modifier.PrimaryCockpit)
					{
						cockpitData2 = modifier;
						break;
					}
				}
			}
			if (cockpitData2 == null && cockpitData != null)
			{
				cockpitData.PrimaryCockpit = true;
			}
		}
	}
}
