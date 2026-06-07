using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.Craft.Propulsion
{
	public class RocketEngineType
	{
		public string AudioId { get; }

		public float BaseMass { get; }

		public float BasePrice { get; private set; }

		public float BaseScale { get; }

		public float ChamberPressure { get; }

		public float Efficiency { get; }

		public float WattsPerMassFlow { get; }

		public string GimbalId { get; }

		public float GimbalRange { get; }

		public float GimbalSpeed { get; }

		public string Id { get; }

		public int Ignitions { get; }

		public bool IsAbstractType { get; private set; }

		public float MassScale { get; }

		public float MinThrottle { get; }

		public ILoadedMod Mod { get; }

		public string Name { get; }

		public float NozzleRadiusScale { get; }

		public string PrefabId { get; private set; }

		public float PriceScale { get; }

		public float Radius { get; }

		public string SubPrefabId { get; private set; }

		public List<string> SubTextureStyleIds { get; } = new List<string>();

		public List<RocketEngineType> SubTypes { get; } = new List<RocketEngineType>();

		public List<FuelType> SupportedFuels { get; } = new List<FuelType>();

		public List<FuelGrain> FuelGrains { get; } = new List<FuelGrain>();

		public List<RocketNozzleType> SupportedNozzles { get; } = new List<RocketNozzleType>();

		public bool SupportsDeactivation { get; }

		public List<string> TextureStyleIds { get; } = new List<string>();

		public float ThrottleResponse { get; private set; }

		public RocketEngineType(XElement xml, PropulsionData propulsionData, RocketEngineType parent, ILoadedMod mod = null)
		{
			Id = xml.Attribute("id").Value;
			Name = xml.Attribute("name").Value;
			ChamberPressure = xml.GetFloatAttribute("chamberPressure") * 1000000f;
			PrefabId = xml.GetStringAttribute("prefabId", parent?.PrefabId);
			SubPrefabId = xml.GetStringAttribute("subPrefabId", parent?.SubPrefabId);
			AudioId = xml.GetStringAttribute("audio", parent?.AudioId ?? "Medium");
			GimbalId = xml.GetStringAttribute("gimbalId", parent?.GimbalId ?? "Normal");
			GimbalRange = xml.GetFloatAttribute("gimbalRange", parent?.GimbalRange ?? 5f);
			GimbalSpeed = xml.GetFloatAttribute("gimbalSpeed", parent?.GimbalSpeed ?? 2.5f);
			BaseScale = xml.GetFloatAttribute("baseScale", parent?.BaseScale ?? 0.4f);
			BaseMass = xml.GetFloatAttribute("baseMass", parent?.BaseMass ?? 0f);
			MassScale = xml.GetFloatAttribute("massScale", parent?.MassScale ?? 5f);
			BasePrice = xml.GetFloatAttribute("basePrice", parent?.BasePrice ?? 1f);
			PriceScale = xml.GetFloatAttribute("priceScale", parent?.PriceScale ?? 1f);
			NozzleRadiusScale = xml.GetFloatAttribute("nozzleRadiusScale", parent?.NozzleRadiusScale ?? 1f);
			ThrottleResponse = xml.GetFloatAttribute("throttleResponse", parent?.ThrottleResponse ?? 10f);
			MinThrottle = xml.GetFloatAttribute("minThrottle", parent?.MinThrottle ?? 0f);
			SupportsDeactivation = xml.GetBoolAttribute("supportsDeactivation", parent?.SupportsDeactivation ?? true);
			Ignitions = xml.GetIntAttribute("ignitions", parent?.Ignitions ?? 0);
			Efficiency = xml.GetFloatAttribute("efficiency", parent?.Efficiency ?? 1f);
			Radius = xml.GetFloatAttribute("radius", parent?.Radius ?? 1f);
			WattsPerMassFlow = xml.GetFloatAttribute("wattsPerMassFlow");
			List<string> textureStyleIds = TextureStyleIds;
			IEnumerable<string> collection;
			if (parent != null)
			{
				IEnumerable<string> textureStyleIds2 = parent.TextureStyleIds;
				collection = textureStyleIds2;
			}
			else
			{
				IEnumerable<string> textureStyleIds2 = (((string)xml.Attribute("textureStyleIds")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				collection = textureStyleIds2;
			}
			textureStyleIds.AddRange(collection);
			List<string> subTextureStyleIds = SubTextureStyleIds;
			IEnumerable<string> collection2;
			if (parent != null)
			{
				IEnumerable<string> textureStyleIds2 = parent.SubTextureStyleIds;
				collection2 = textureStyleIds2;
			}
			else
			{
				IEnumerable<string> textureStyleIds2 = (((string)xml.Attribute("subTextureStyleIds")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				collection2 = textureStyleIds2;
			}
			subTextureStyleIds.AddRange(collection2);
			string stringAttribute = xml.GetStringAttribute("nozzles");
			if (stringAttribute != null)
			{
				string[] array = stringAttribute.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string supportedNozzleId in array)
				{
					RocketNozzleType rocketNozzleType = propulsionData.RocketNozzles.Where((RocketNozzleType x) => x.Id == supportedNozzleId).FirstOrDefault();
					if (rocketNozzleType != null)
					{
						SupportedNozzles.Add(rocketNozzleType);
						continue;
					}
					Debug.LogErrorFormat("Nozzle with ID {0} could not be found in {1}'s list of supported nozzles.", supportedNozzleId, Id);
				}
			}
			else
			{
				foreach (RocketNozzleType rocketNozzle in propulsionData.RocketNozzles)
				{
					SupportedNozzles.Add(rocketNozzle);
				}
			}
			string stringAttribute2 = xml.GetStringAttribute("fuels");
			if (stringAttribute2 != null)
			{
				string[] array = stringAttribute2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string text in array)
				{
					try
					{
						FuelType fuelType = propulsionData.GetFuelType(text);
						SupportedFuels.Add(fuelType);
					}
					catch (Exception)
					{
						Debug.LogErrorFormat("Fuel with ID {0} could not be found in {1}'s list of supported fuels.", text, Id);
					}
				}
			}
			else if (parent != null)
			{
				foreach (FuelType supportedFuel in parent.SupportedFuels)
				{
					SupportedFuels.Add(supportedFuel);
				}
			}
			string stringAttribute3 = xml.GetStringAttribute("supportedGrains");
			if (stringAttribute3 != null)
			{
				string[] array = stringAttribute3.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string supportedGrainsId in array)
				{
					FuelGrain fuelGrain = propulsionData.FuelGrains.Where((FuelGrain x) => x.Id == supportedGrainsId).FirstOrDefault();
					if (fuelGrain != null)
					{
						FuelGrains.Add(fuelGrain);
						continue;
					}
					Debug.LogErrorFormat("Fuel Grain with ID {0} could not be found in {1}'s list of supported fuel grains.", supportedGrainsId, Id);
				}
			}
			else if (parent != null)
			{
				foreach (FuelGrain fuelGrain2 in parent.FuelGrains)
				{
					FuelGrains.Add(fuelGrain2);
				}
			}
			foreach (XElement item2 in xml.Elements("SubType"))
			{
				RocketEngineType item = new RocketEngineType(item2, propulsionData, this, mod);
				SubTypes.Add(item);
			}
			IsAbstractType = SubTypes.Count > 0;
			if (!IsAbstractType && SupportedFuels.Count == 0)
			{
				Debug.LogErrorFormat("Engine {0} has no supported fuels", Id);
			}
			Mod = mod;
		}
	}
}
