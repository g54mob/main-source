using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Ui.Sharing.Upload;
using ModApi.Planet;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Sharing.Handlers.CelestialBody
{
	public class CelestialBodyFormData : UploadContentFormData
	{
		public IReadOnlyList<BinaryDataUploadContent> AdditionalBinaryData { get; private set; }

		public string CreateResourceFileXml { get; private set; }

		public string DetailsXml { get; private set; }

		public string ResourceFileName { get; }

		public string ResourceFilePath { get; private set; }

		public CelestialBodyFormData(UploadContentModel model, string parentAncestryId, PlanetDataScript celestialBody, List<BinaryDataUploadContent> additionalBinaryData, CreateResourceFileModel resourceFileModel, string resourceFilePath, string resourceFileName)
			: base(model, celestialBody.ParentAncestryId, parentAncestryId, celestialBody.FileData.RequiredMods)
		{
			ResourceFilePath = resourceFilePath;
			ResourceFileName = resourceFileName;
			CreateResourceFileXml = resourceFileModel.GenerateXml();
			AdditionalBinaryData = additionalBinaryData;
			PlanetAtmosphereData atmosphereData = celestialBody.AtmosphereData;
			CelestialBodyDetailsModel celestialBodyDetailsModel = new CelestialBodyDetailsModel
			{
				CelestialBodyVersion = celestialBody.Version,
				CelestialBodyVersionTag = celestialBody.VersionTag,
				AngularVelocity = celestialBody.AngularVelocity,
				Atmosphere = new CelestialBodyDetailsModel.AtmosphereDetailsModel
				{
					CrushAltitude = atmosphereData.CrushAltitude,
					Description = atmosphereData.Description,
					HasPhysicsAtmosphere = atmosphereData.HasPhysicsAtmosphere,
					Height = atmosphereData.Height,
					MeanGamma = atmosphereData.MeanGamma,
					MeanMassPerMolecule = atmosphereData.MeanMassPerMolecule,
					MeanSurfaceTemperature = atmosphereData.MeanSurfaceTemperature,
					MeanSurfaceTemperatureDay = atmosphereData.MeanSurfaceTemperatureDay,
					MeanSurfaceTemperatureNight = atmosphereData.MeanSurfaceTemperatureNight,
					ScaleHeight = atmosphereData.ScaleHeight,
					SurfaceAirDensity = atmosphereData.SurfaceAirDensity
				},
				EscapeVelocity = celestialBody.EscapeVelocity,
				HasRings = (celestialBody.RingsData?.HasRings ?? false),
				HasTerrainPhysics = celestialBody.HasTerrainPhysics,
				HasWater = celestialBody.HasWater,
				Mass = celestialBody.Mass,
				Radius = celestialBody.Radius,
				SeaLevel = celestialBody.SeaLevel,
				SurfaceGravity = celestialBody.SurfaceGravity
			};
			DetailsXml = celestialBodyDetailsModel.GenerateXml();
		}

		public override void UpdateFormData(WWWForm form)
		{
			base.UpdateFormData(form);
			form.AddField("CreateResourceFileXml", CreateResourceFileXml);
			form.AddField("DetailsXml", DetailsXml);
			byte[] contents = File.ReadAllBytes(ResourceFilePath);
			form.AddBinaryData("resourceFile", contents, ResourceFileName, "text/xml");
			foreach (BinaryDataUploadContent additionalBinaryDatum in AdditionalBinaryData)
			{
				form.AddBinaryData(additionalBinaryDatum.FieldName, additionalBinaryDatum.Data, additionalBinaryDatum.FileName, additionalBinaryDatum.MimeType);
			}
		}
	}
}
