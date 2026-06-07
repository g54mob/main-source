using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.State;
using ModApi;
using ModApi.Common.Extensions;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Sharing.Handlers.Sandbox
{
	public class SandboxFormData
	{
		public enum PictureFormatType
		{
			PNG = 0,
			JPG = 1
		}

		public static string PictureExtension => PictureFormat switch
		{
			PictureFormatType.JPG => "jpg", 
			PictureFormatType.PNG => "png", 
			_ => throw new InvalidOperationException(string.Format("Unsupported picture format:", PictureFormat)), 
		};

		public static string PictureExtensionMimeType => PictureFormat switch
		{
			PictureFormatType.JPG => "image/jpeg", 
			PictureFormatType.PNG => "image/png", 
			_ => throw new InvalidOperationException(string.Format("Unsupported picture format:", PictureFormat)), 
		};

		public static PictureFormatType PictureFormat { get; } = PictureFormatType.JPG;

		public string AncestryId { get; private set; }

		public string Description { get; private set; }

		public bool IsPublic { get; private set; }

		public string ParentAncestryId { get; private set; }

		public Guid PlanetarySystemId { get; private set; }

		public int PlanetCount { get; private set; }

		public XElement RequiredMods { get; private set; }

		public SandboxDetailsModel SandboxDetails { get; private set; }

		public string SandboxName { get; private set; }

		public IEnumerable<byte[]> Screenshots { get; private set; }

		public bool ValidPhotoChecksums { get; private set; }

		public byte[] ZipBytes { get; private set; }

		private SandboxFormData()
		{
		}

		public static SandboxFormData CreateFromCurrentSandbox(string name, string description, bool isPublic, bool validPhotoChecksums, IEnumerable<Texture2D> screenshots)
		{
			string id = Game.Instance.GameState.Id;
			string gameStateTag = "Active";
			string newAncestryId = Guid.NewGuid().ToString();
			string ancestryId = SandboxUpload.GetAncestryId(id, gameStateTag);
			return Create(name, description, isPublic, validPhotoChecksums, screenshots, newAncestryId, ancestryId);
		}

		public static SandboxFormData CreateFromCurrentSandbox(string name, string description, bool isPublic, bool validPhotoChecksums, IEnumerable<Texture2D> screenshots, string newAncestryId, string parentAncestryId)
		{
			return Create(name, description, isPublic, validPhotoChecksums, screenshots, newAncestryId, parentAncestryId);
		}

		public static SandboxFormData LoadFromXml(XDocument sandboxDocument)
		{
			XElement root = sandboxDocument.Root;
			SandboxFormData sandboxFormData = new SandboxFormData();
			sandboxFormData.AncestryId = root.Attribute("ancestryId").Value;
			sandboxFormData.ParentAncestryId = root.Attribute("parentAncestryId").Value;
			sandboxFormData.SandboxName = root.Attribute("SandboxName").Value;
			sandboxFormData.Description = root.Attribute("Description").Value;
			sandboxFormData.IsPublic = bool.Parse(root.Attribute("isPublic").Value);
			sandboxFormData.ValidPhotoChecksums = bool.Parse(root.Attribute("ValidPhotoChecksums").Value);
			if (root.Element("RequiredMods").HasElements)
			{
				sandboxFormData.RequiredMods = root.Element("RequiredMods");
			}
			XElement xElement = root.Element("ZipBytes");
			sandboxFormData.ZipBytes = Convert.FromBase64String(xElement.Value);
			List<byte[]> list = new List<byte[]>();
			string value = root.Attribute("ScreenshotsFolder").Value;
			if (Directory.Exists(value))
			{
				FileInfo[] files = new DirectoryInfo(value).GetFiles($"*.{PictureExtension}");
				foreach (FileInfo fileInfo in files)
				{
					list.Add(File.ReadAllBytes(fileInfo.FullName));
				}
			}
			sandboxFormData.Screenshots = list;
			return sandboxFormData;
		}

		public XElement SaveXml(string folder, string fileName)
		{
			XElement xElement = new XElement("Sandbox", new XAttribute("ancestryId", AncestryId), new XAttribute("parentAncestryId", ParentAncestryId), new XAttribute("SandboxName", SandboxName), new XAttribute("Description", Description), new XAttribute("isPublic", IsPublic), new XAttribute("ValidPhotoChecksums", ValidPhotoChecksums), new XAttribute("ScreenshotsFolder", folder), RequiredMods);
			XElement xElement2 = new XElement("ZipBytes");
			xElement.Add(xElement2);
			xElement2.Value = Convert.ToBase64String(ZipBytes);
			SaveScreenshots(folder);
			xElement.Save(Utilities.CombinePaths(folder, fileName));
			return xElement;
		}

		private static SandboxFormData Create(string name, string description, bool isPublic, bool validPhotoChecksums, IEnumerable<Texture2D> screenshots, string newAncestryId, string parentAncestryId)
		{
			SandboxFormData sandboxFormData = new SandboxFormData();
			GameStateManager gameStateManager = Game.Instance.GameStateManager;
			GameState gameState = Game.Instance.GameState;
			string id = gameState.Id;
			FlightState flightState = null;
			if (Game.InFlightScene)
			{
				flightState = ((FlightSceneScript)Game.Instance.FlightScene).FlightState;
				flightState.Save(overridePreventSave: true);
			}
			else
			{
				flightState = gameState.LoadFlightState();
			}
			Guid hashBasedFileId = flightState.PlanetarySystem.GetHashBasedFileId();
			using (ZipHelper zipHelper = new ZipHelper())
			{
				FileInfo[] files = new DirectoryInfo(gameStateManager.GetGameStateTagPath(id, gameState.GetTagActive())).GetFiles("*.xml");
				foreach (FileInfo fileInfo in files)
				{
					if (fileInfo.Name.Equals("FlightState.xml", StringComparison.OrdinalIgnoreCase))
					{
						XDocument xml = XDocument.Load(fileInfo.FullName);
						FlightStateData.ChangePlanetarySystemReference(xml, hashBasedFileId);
						zipHelper.AddFileBytes(xml.SaveAsBytes(), fileInfo.Name);
					}
					else
					{
						zipHelper.AddXmlFile(fileInfo.Name, File.ReadAllText(fileInfo.FullName));
					}
				}
				zipHelper.AddXmlFile("LaunchLocations.xml", File.ReadAllText(gameState.LaunchLocationsPath));
				zipHelper.AddTextFile("Name.txt", name);
				sandboxFormData.ZipBytes = zipHelper.GetBytes();
			}
			if (flightState.FlightStateRequiredMods.Mods.Count > 0)
			{
				sandboxFormData.RequiredMods = flightState.FlightStateRequiredMods.GenerateXml();
			}
			sandboxFormData.SandboxName = name;
			sandboxFormData.Description = description;
			sandboxFormData.IsPublic = isPublic;
			sandboxFormData.ValidPhotoChecksums = validPhotoChecksums;
			sandboxFormData.AncestryId = newAncestryId;
			sandboxFormData.ParentAncestryId = parentAncestryId;
			sandboxFormData.PlanetarySystemId = hashBasedFileId;
			sandboxFormData.SandboxDetails = new SandboxDetailsModel();
			sandboxFormData.SandboxDetails.Time = (long)flightState.Time;
			sandboxFormData.SandboxDetails.SolarSystemName = flightState.SolarSystemData.Name;
			sandboxFormData.SandboxDetails.PlanetCount = flightState.SolarSystemData.Planets.Count;
			foreach (CraftNode craftNode in flightState.CraftNodes)
			{
				SandboxDetailsModel.ActiveCraftDetailsModel item = new SandboxDetailsModel.ActiveCraftDetailsModel
				{
					Name = craftNode.Name,
					Altitude = (long)(craftNode.Position.magnitude - craftNode.Parent.PlanetData.Radius),
					Velocity = (long)craftNode.Velocity.magnitude,
					Grounded = craftNode.InContactWithPlanet,
					Planet = craftNode.Parent.PlanetData.Name,
					CraftMass = (int)(craftNode.CraftMass * 100f),
					CraftPartCount = craftNode.CraftPartCount
				};
				sandboxFormData.SandboxDetails.Crafts.Add(item);
			}
			List<byte[]> list = new List<byte[]>();
			foreach (Texture2D screenshot in screenshots)
			{
				switch (PictureFormat)
				{
				case PictureFormatType.JPG:
					list.Add(screenshot.EncodeToJPG());
					break;
				case PictureFormatType.PNG:
					list.Add(screenshot.EncodeToPNG());
					break;
				}
			}
			sandboxFormData.Screenshots = list;
			if (!Game.InFlightScene)
			{
				flightState.Destroy();
			}
			return sandboxFormData;
		}

		private void SaveScreenshots(string folder)
		{
			int num = 0;
			foreach (byte[] screenshot in Screenshots)
			{
				File.WriteAllBytes(Utilities.CombinePaths(folder, $"UserView_{num++}.{PictureExtension}"), screenshot);
			}
		}
	}
}
