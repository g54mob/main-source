using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Exceptions;
using UnityEngine;

namespace ModApi.Craft.Propulsion
{
	public class PropulsionData
	{
		private List<FuelType> _fuels;

		private List<RocketEngineType> _rocketEngines;

		private List<RocketNozzleType> _rocketNozzles;

		private List<FuelGrain> _fuelGrains;

		public IReadOnlyList<FuelType> Fuels => _fuels;

		public IReadOnlyList<RocketEngineType> RocketEngines => _rocketEngines;

		public IReadOnlyList<RocketNozzleType> RocketNozzles => _rocketNozzles;

		public IReadOnlyList<FuelGrain> FuelGrains => _fuelGrains;

		public PropulsionData(string xml)
		{
			_fuels = new List<FuelType>();
			_rocketEngines = new List<RocketEngineType>();
			_rocketNozzles = new List<RocketNozzleType>();
			_fuelGrains = new List<FuelGrain>();
			LoadXml(xml);
		}

		public FuelType GetFuelType(string fuelTypeId)
		{
			FuelType fuelType = _fuels.FirstOrDefault((FuelType x) => x.Id == fuelTypeId);
			if (fuelType == null)
			{
				Debug.LogErrorFormat("Could not find fuel with type ID: {0}", fuelTypeId);
			}
			return fuelType;
		}

		public void LoadXml(string xml, ILoadedMod mod = null)
		{
			XDocument xDocument = XDocument.Parse(xml);
			try
			{
				XElement xElement = xDocument.Element("Propulsion");
				foreach (XElement item in xElement.Element("Fuels").Elements("Fuel"))
				{
					FuelType fuel = new FuelType(item, mod);
					int num = _fuels.FindIndex((FuelType x) => x.Id == fuel.Id);
					if (num < 0)
					{
						_fuels.Add(fuel);
						continue;
					}
					_fuels[num] = fuel;
					Debug.Log("Mod '" + (mod?.ModInfo.Name ?? "Unknown") + "' is overriding fuel type '" + fuel.Id + "'");
				}
				FuelType.Initialize(_fuels);
				foreach (XElement item2 in xElement.Element("RocketNozzles").Elements("RocketNozzle"))
				{
					RocketNozzleType rocketNozzle = new RocketNozzleType(item2, mod);
					int num2 = _rocketNozzles.FindIndex((RocketNozzleType x) => x.Id == rocketNozzle.Id);
					if (num2 < 0)
					{
						_rocketNozzles.Add(rocketNozzle);
						continue;
					}
					_rocketNozzles[num2] = rocketNozzle;
					Debug.Log("Mod '" + (mod?.ModInfo.Name ?? "Unknown") + "' is overriding rocket nozzle type '" + rocketNozzle.Id + "'");
				}
				foreach (XElement item3 in xElement.Element("Grains").Elements("FuelGrain"))
				{
					FuelGrain fuelGrain = new FuelGrain(item3, mod);
					int num3 = _fuelGrains.FindIndex((FuelGrain x) => x.Id == fuelGrain.Id);
					if (num3 < 0)
					{
						_fuelGrains.Add(fuelGrain);
						continue;
					}
					_fuelGrains[num3] = fuelGrain;
					Debug.Log("Mod '" + (mod?.ModInfo.Name ?? "Unknown") + "' is overriding rocket nozzle type '" + fuelGrain.Id + "'");
				}
				foreach (XElement item4 in xElement.Element("RocketEngines").Elements("RocketEngine"))
				{
					RocketEngineType rocketEngine = new RocketEngineType(item4, this, null, mod);
					int num4 = _rocketEngines.FindIndex((RocketEngineType x) => x.Id == rocketEngine.Id);
					if (num4 < 0)
					{
						_rocketEngines.Add(rocketEngine);
						continue;
					}
					RocketEngineType rocketEngineType = _rocketEngines[num4];
					if (rocketEngine.SubTypes.Count > 0)
					{
						foreach (RocketEngineType subType in rocketEngine.SubTypes)
						{
							int num5 = rocketEngineType.SubTypes.FindIndex((RocketEngineType x) => x.Id == subType.Id);
							if (num5 < 0)
							{
								rocketEngineType.SubTypes.Add(subType);
								continue;
							}
							rocketEngineType.SubTypes[num5] = subType;
							Debug.Log("Mod '" + (mod?.ModInfo.Name ?? "Unknown") + "' is overriding rocket engine sub type '" + subType.Id + "'");
						}
					}
					else
					{
						if (rocketEngineType.SubTypes.Count > 0)
						{
							rocketEngine.SubTypes.AddRange(rocketEngineType.SubTypes);
						}
						_rocketEngines[num4] = rocketEngine;
						Debug.Log("Mod '" + (mod?.ModInfo.Name ?? "Unknown") + "' is overriding rocket engine type '" + rocketEngine.Id + "'");
					}
				}
			}
			catch (Exception inner)
			{
				throw new GameException("Failed to parse propulsion data XML.", inner);
			}
		}
	}
}
