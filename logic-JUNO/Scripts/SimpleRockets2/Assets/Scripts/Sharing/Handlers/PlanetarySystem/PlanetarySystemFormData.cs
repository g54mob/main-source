using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Ui.Sharing.Upload;
using ModApi.Planet;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Sharing.Handlers.PlanetarySystem
{
	public class PlanetarySystemFormData : UploadContentFormData
	{
		public string CreateResourceFileXml { get; private set; }

		public string DetailsXml { get; private set; }

		public string ResourceFileName { get; }

		public string ResourceFilePath { get; private set; }

		public PlanetarySystemFormData(UploadContentModel model, string parentAncestryId, SolarSystemDataScript planetarySystem, Dictionary<string, Guid> celestialBodyIds, CreateResourceFileModel resourceFileModel, string resourceFilePath, string resourceFileName)
			: base(model, planetarySystem.ParentAncestryId, parentAncestryId, planetarySystem.FileData.RequiredMods)
		{
			ResourceFilePath = resourceFilePath;
			ResourceFileName = resourceFileName;
			CreateResourceFileXml = resourceFileModel.GenerateXml();
			List<PlanetDataScript> list = new List<PlanetDataScript>();
			Stack<PlanetDataScript> stack = new Stack<PlanetDataScript>();
			stack.Push(planetarySystem.Planets.First((PlanetDataScript x) => x.Parent == null));
			while (stack.Count > 0)
			{
				PlanetDataScript body = stack.Pop();
				list.Add(body);
				foreach (PlanetDataScript item in from x in planetarySystem.Planets
					where x.Parent == body
					orderby x.OrbitData?.SemiMajorAxis ?? 0.0 descending
					select x)
				{
					stack.Push(item);
				}
			}
			PlanetarySystemDetailsModel planetarySystemDetailsModel = new PlanetarySystemDetailsModel();
			foreach (PlanetDataScript item2 in list)
			{
				PlanetDataScript parent = item2.Parent;
				Orbit orbit = ((parent == null) ? null : new Orbit(item2.OrbitData, parent.Mass));
				PlanetAtmosphereData atmosphereData = item2.AtmosphereData;
				planetarySystemDetailsModel.PlanetarySystemVersion = planetarySystem.Version;
				planetarySystemDetailsModel.PlanetarySystemVersionTag = planetarySystem.VersionTag;
				planetarySystemDetailsModel.OrbitingBodies.Add(new PlanetarySystemDetailsModel.OrbitingBody
				{
					AngularVelocity = item2.AngularVelocity,
					AtmosphereHeight = atmosphereData.Height,
					EscapeVelocity = item2.EscapeVelocity,
					HasRings = (item2.RingsData?.HasRings ?? false),
					HasWater = item2.HasWater,
					Mass = item2.Mass,
					Name = item2.Name,
					Orbit = ((orbit == null) ? null : new PlanetarySystemDetailsModel.OrbitingBody.OrbitDetailsModel
					{
						ApoapsisDistance = orbit.ApoapsisDistance,
						Eccentricity = orbit.Eccentricity,
						Inclination = orbit.Inclination,
						PeriapsisAngle = orbit.PeriapsisAngle,
						PeriapsisDistance = orbit.PeriapsisDistance,
						Period = orbit.Period,
						PrimaryMass = orbit.PrimaryMass,
						Prograde = orbit.IsPrograde,
						RightAscensionOfAscendingNode = orbit.RightAscensionOfAscendingNode,
						SemiMajorAxis = orbit.SemiMajorAxis,
						TrueAnomaly = orbit.TrueAnomaly
					}),
					ParentName = item2.Parent?.Name,
					Radius = item2.Radius,
					ResourceHash = celestialBodyIds[item2.Name].ToString(),
					SeaLevel = item2.SeaLevel,
					SurfaceGravity = item2.SurfaceGravity
				});
			}
			DetailsXml = planetarySystemDetailsModel.GenerateXml();
		}

		public override void UpdateFormData(WWWForm form)
		{
			base.UpdateFormData(form);
			form.AddField("CreateResourceFileXml", CreateResourceFileXml);
			form.AddField("DetailsXml", DetailsXml);
			byte[] contents = File.ReadAllBytes(ResourceFilePath);
			form.AddBinaryData("resourceFile", contents, ResourceFileName, "text/xml");
		}
	}
}
