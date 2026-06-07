using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using LibNoise;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap
{
	public class GalaxyMapGenerator
	{
		public int StepCount;

		private float _diameter;

		private readonly GalaxyMapManager _manager;

		private bool _hasPreset;

		public List<GalaxyMapSector> Sectors;

		private List<GalaxyMapSector> _lastSectors;

		public LocationData StartLocation;

		public LocationData EndLocation;

		private System.Random _randomGenerator;

		private const int MinGalaxySize = 4;

		private const int MaxGalaxySize = 7;

		private const int GalaxyScale = 150;

		private const float MinDistance = 50f;

		private const float MaxNeighborDistance = 350f;

		private const float MaxNoiseDisplacement = 20f;

		private LibNoise.Perlin _perlin;

		public GalaxyMapGenerator(int seed)
		{
			_randomGenerator = new System.Random(seed);
			_manager = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance;
		}

		public IEnumerator GenerateMap(int currentLevel)
		{
			Sectors = new List<GalaxyMapSector>();
			_lastSectors = new List<GalaxyMapSector>();
			_perlin = new LibNoise.Perlin();
			_perlin.Seed = _randomGenerator.Next();
			_hasPreset = _manager.GalaxyProgression.Count > currentLevel && RuntimeGlobals.GameMode == EGameMode.Campaign;
			if (_hasPreset)
			{
				StepCount = _randomGenerator.Next(_manager.GalaxyProgression[currentLevel].MinSteps, _manager.GalaxyProgression[currentLevel].MaxSteps + 1);
			}
			else
			{
				StepCount = _randomGenerator.Next(4, 7);
			}
			_diameter = StepCount * 150;
			int num = (_randomGenerator.Next(0, 140) - 70 + 180) % 360;
			Vector3 startPos = new Vector3(Mathf.Cos((float)num * ((float)System.Math.PI / 180f)) * (_diameter / 2f), Mathf.Sin((float)num * ((float)System.Math.PI / 180f)) * (_diameter / 2f), 0f);
			Vector3 endPos = GetDerivativePosition(num, 180, 5, 25);
			UniqueLocationSector endSector = new UniqueLocationSector
			{
				Revealed = true
			};
			endSector.Init(_randomGenerator, endPos);
			endSector.Step = StepCount;
			Sectors.Add(endSector);
			if (RuntimeGlobals.GameMode == EGameMode.Campaign && currentLevel == _manager.GalaxyProgression.Count - 1)
			{
				PlanetLocationData planetLocationData = (PlanetLocationData)_manager.CampaignEndLocation.CreateLocation(_randomGenerator, endSector, EMissionDifficulty.Hard, EMissionComplexity.High);
				planetLocationData.IsEndPlanet = true;
				endSector.SetLocation(planetLocationData, 16);
			}
			else
			{
				WormHoleLocationData wormHoleLocationData = (WormHoleLocationData)_manager.WormHoleExitLocation.CreateLocation(_randomGenerator, endSector, EMissionDifficulty.None, EMissionComplexity.High);
				wormHoleLocationData.SetGalaxyLevel(currentLevel + 1);
				endSector.SetLocation(wormHoleLocationData, 16);
			}
			EndLocation = endSector.Location;
			if (currentLevel > 1)
			{
				UniqueLocationSector uniqueLocationSector = new UniqueLocationSector();
				uniqueLocationSector.Init(_randomGenerator, startPos);
				uniqueLocationSector.SetExplored(true);
				uniqueLocationSector.Step = 0;
				Sectors.Add(uniqueLocationSector);
				_lastSectors.Add(uniqueLocationSector);
				WormHoleLocationData wormHoleLocationData2 = (WormHoleLocationData)_manager.WormHoleEntranceLocation.CreateLocation(_randomGenerator, uniqueLocationSector, EMissionDifficulty.None, EMissionComplexity.High);
				wormHoleLocationData2.SetGalaxyLevel(currentLevel - 1);
				uniqueLocationSector.SetLocation(wormHoleLocationData2, 16);
				StartLocation = uniqueLocationSector.Location;
				StartLocation.Visitable = false;
			}
			else
			{
				SolarSystem newSolarSystem = GetNewSolarSystem(currentLevel, 0);
				if (currentLevel == 1 && RuntimeGlobals.GameMode == EGameMode.Campaign)
				{
					SolarSystemSetting startSystem = _manager.StartSystem;
					if (startSystem != null && startSystem.IsCompatibleWithGameMode())
					{
						newSolarSystem.SetPreset(_manager.StartSystem);
					}
				}
				newSolarSystem.Init(_randomGenerator, startPos);
				newSolarSystem.SetExplored(true);
				newSolarSystem.Step = 0;
				Sectors.Add(newSolarSystem);
				_lastSectors.Add(newSolarSystem);
				StartLocation = newSolarSystem.Locations.FirstOrDefault();
			}
			Vector3 generalDirection = endPos - startPos;
			for (int i = 1; i < StepCount; i++)
			{
				Vector2 vector = (Vector2)startPos + (Vector2)generalDirection / (float)StepCount * i;
				Vector2 topPoint = vector + RotateVector(generalDirection, -90f);
				Vector2 bottomPoint = vector + RotateVector(generalDirection, 90f);
				Plane stepPlane = new Plane(startPos - endPos, vector);
				List<GalaxyMapSector> list = _lastSectors.ToList();
				_lastSectors.Clear();
				bool first = true;
				foreach (GalaxyMapSector lastSector in list)
				{
					int neighboursToAdd = ((currentLevel == 0) ? 1 : ((!lastSector.IsDeadEnd) ? 2 : 0));
					float angleOffset = ((currentLevel == 0) ? 12f : ((i == 1) ? 45f : ((float)_randomGenerator.Next(24, 42))));
					int rndMultiplier = ((((currentLevel == 0) ? (i - 1) : _randomGenerator.Next(0, 2)) == 0) ? 1 : (-1));
					for (int j = 0; j < neighboursToAdd; j++)
					{
						SolarSystem solarSystem;
						SolarSystem newSolarSystem2 = GetNewSolarSystem(currentLevel, i, (first && (solarSystem = lastSector as SolarSystem) != null) ? solarSystem : null);
						first = false;
						int num2 = ((j % 2 == 0) ? 1 : (-1));
						num2 *= rndMultiplier;
						angleOffset += newSolarSystem2.Radius / 3.6f;
						Vector3 normalized = (endPos - (Vector3)lastSector.Position).normalized;
						Vector2 vector2 = RotateVector(normalized, angleOffset * (float)num2);
						vector2.Normalize();
						Ray ray = new Ray(lastSector.Position, vector2);
						float enter;
						if (!stepPlane.Raycast(ray, out enter) || enter > 350f)
						{
							continue;
						}
						Vector3 point = ray.GetPoint(enter);
						point = GetPerlinPosition(point, RotateVector((bottomPoint - topPoint).normalized, 90 * rndMultiplier));
						newSolarSystem2.Init(_randomGenerator, point);
						if (GetOverlap(newSolarSystem2, lastSector) == null)
						{
							if (i == 1)
							{
								newSolarSystem2.Revealed = true;
							}
							Sectors.Add(newSolarSystem2);
							_lastSectors.Add(newSolarSystem2);
						}
						yield return true;
					}
				}
			}
			foreach (GalaxyMapSector lastSector2 in _lastSectors)
			{
				endSector.AddNeighbour(lastSector2);
				lastSector2.AddNeighbour(endSector);
			}
			_lastSectors.Clear();
			int k;
			for (k = 0; k < ((StepCount > 2) ? (StepCount - 1) : StepCount); k++)
			{
				List<GalaxyMapSector> list2 = Sectors.Where((GalaxyMapSector s) => s.Step == k).ToList();
				List<GalaxyMapSector> list3 = Sectors.Where((GalaxyMapSector s) => s.Step == k + 1).ToList();
				if (k == 0)
				{
					foreach (GalaxyMapSector item in list2)
					{
						foreach (GalaxyMapSector item2 in list3)
						{
							item2.AddNeighbour(item);
							item.AddNeighbour(item2);
						}
					}
					continue;
				}
				GalaxyMapSector galaxyMapSector = list2.RandomItem(_randomGenerator);
				float num3 = float.MaxValue;
				GalaxyMapSector galaxyMapSector2 = null;
				foreach (GalaxyMapSector item3 in list2)
				{
					if (item3 != galaxyMapSector && (item3.Position - galaxyMapSector.Position).magnitude < num3)
					{
						num3 = (item3.Position - galaxyMapSector.Position).magnitude;
						galaxyMapSector2 = item3;
					}
				}
				if (galaxyMapSector2 != null)
				{
					galaxyMapSector2.AddNeighbour(galaxyMapSector);
					galaxyMapSector.AddNeighbour(galaxyMapSector2);
				}
				foreach (GalaxyMapSector item4 in list2)
				{
					int num4 = ((currentLevel != 0) ? _randomGenerator.Next(1, 3) : 0);
					if (list3.Count < num4)
					{
						num4 = list3.Count;
					}
					Dictionary<GalaxyMapSector, float> dictionary = new Dictionary<GalaxyMapSector, float>();
					foreach (GalaxyMapSector item5 in list3)
					{
						dictionary.Add(item5, (item5.Position - item4.Position).magnitude);
					}
					for (int num5 = 0; num5 < num4; num5++)
					{
						KeyValuePair<GalaxyMapSector, float> keyValuePair = dictionary.OrderBy((KeyValuePair<GalaxyMapSector, float> kvp) => kvp.Value).First();
						if (keyValuePair.Value < 350f)
						{
							keyValuePair.Key.AddNeighbour(item4);
							item4.AddNeighbour(keyValuePair.Key);
						}
						dictionary.Remove(keyValuePair.Key);
					}
				}
				foreach (GalaxyMapSector item6 in list3)
				{
					SolarSystem solarSystem2;
					if (k == StepCount - 2 && item6.GetNeighbours().Count < 2)
					{
						float num6 = float.MaxValue;
						GalaxyMapSector galaxyMapSector3 = null;
						foreach (GalaxyMapSector item7 in list2)
						{
							if ((item7.Position - item6.Position).magnitude < num6)
							{
								num6 = (item7.Position - item6.Position).magnitude;
								galaxyMapSector3 = item7;
							}
						}
						if (galaxyMapSector3 != null)
						{
							galaxyMapSector3.AddNeighbour(item6);
							item6.AddNeighbour(galaxyMapSector3);
						}
					}
					else if ((from s in item6.GetNeighbours()
						where s.Step == k
						select s).ToList().Count < 1 && (solarSystem2 = item6 as SolarSystem) != null)
					{
						solarSystem2.SetPreset(_manager.GetRandomSpecialSystem(_randomGenerator, solarSystem2.MapComplexity));
						solarSystem2.Init(_randomGenerator, item6.Position);
					}
				}
			}
			if (currentLevel > 0 && (RuntimeGlobals.GameModeSettings.HasShops || RuntimeGlobals.GameModeSettings.HasGarages || RuntimeGlobals.GameModeSettings.HasWeaponCasino))
			{
				List<LocationData> list4 = new List<LocationData>();
				List<GalaxyMapSector> source = Sectors.Where((GalaxyMapSector s) => s is SolarSystem).ToList();
				if (currentLevel > 1)
				{
					List<GalaxyMapSector> list5 = source.Where((GalaxyMapSector s) => s.Step == 1).ToList();
					list5.Shuffle(_randomGenerator);
					int i2;
					for (i2 = 0; i2 < list5.Count; i2++)
					{
						SolarSystem solarSystem3;
						if ((solarSystem3 = list5[i2] as SolarSystem) == null)
						{
							continue;
						}
						LocationSetting shopSetting = (from l in _manager.GetShopLocations()
							where (i2 % 2 != 0) ? (l is GarageLocationSetting) : (l is ShopLocationSetting)
							select l).ToList().RandomItem(_randomGenerator);
						if (!(shopSetting == null) && !solarSystem3.Locations.Any((LocationData l) => l.GetType() == shopSetting.GetType()))
						{
							LocationData locationData = solarSystem3.AddLocation(shopSetting, _randomGenerator);
							if (GetOverlap(solarSystem3) != null)
							{
								solarSystem3.RemoveLocation(locationData);
							}
							else
							{
								list4.Add(locationData);
							}
						}
					}
				}
				int num7 = Mathf.CeilToInt(0.5f + (float)StepCount / 2f);
				List<GalaxyMapSector> list6 = source.Where((GalaxyMapSector s) => (currentLevel <= 1) ? (s.Step > 0) : (s.Step > 1)).ToList();
				foreach (GalaxyMapSector item8 in list6)
				{
					SolarSystem solarSystem4;
					if ((solarSystem4 = item8 as SolarSystem) == null)
					{
						continue;
					}
					foreach (LocationData location in solarSystem4.Locations)
					{
						if (location.IsShopLocation)
						{
							list4.Add(location);
						}
					}
				}
				if (list4.Count < num7)
				{
					for (int num8 = list4.Count; num8 < num7; num8++)
					{
						list6.Shuffle(_randomGenerator);
						int count = list6.Count;
						for (int num9 = 0; num9 < count; num9++)
						{
							SolarSystem solarSystem5;
							if ((solarSystem5 = list6.RandomItemProbability((GalaxyMapSector o) => Mathf.Sqrt(o.Step), _randomGenerator.Next()) as SolarSystem) == null)
							{
								continue;
							}
							List<LocationSetting> shopLocations = _manager.GetShopLocations(currentLevel);
							Dictionary<LocationSetting, float> dict = new Dictionary<LocationSetting, float>();
							if (RuntimeGlobals.GameModeSettings.HasShops)
							{
								AddShop<ShopLocationSetting, ShopLocationData>(shopLocations, list4, dict, num7);
							}
							if (RuntimeGlobals.GameModeSettings.HasGarages)
							{
								AddShop<GarageLocationSetting, GarageLocationData>(shopLocations, list4, dict, num7);
							}
							if (RuntimeGlobals.GameModeSettings.HasWeaponCasino && currentLevel > 1)
							{
								AddShop<ScrapyardLocationSetting, ScrapyardLocationData>(shopLocations, list4, dict, num7);
							}
							LocationSetting shopSetting2 = shopLocations.RandomItemProbability((LocationSetting l) => dict[l], _randomGenerator);
							if (shopSetting2 != null && !solarSystem5.Locations.Any((LocationData l) => l.GetType() == shopSetting2.GetType()))
							{
								LocationData locationData2 = solarSystem5.AddLocation(shopSetting2, _randomGenerator);
								if (IsShopAllowed(solarSystem5, locationData2))
								{
									list4.Add(locationData2);
									break;
								}
								solarSystem5.RemoveLocation(locationData2);
							}
						}
					}
				}
			}
			if (currentLevel > 0 && StepCount > 2)
			{
				int num10 = Mathf.FloorToInt((float)StepCount / 2f);
				int num11 = 1;
				bool flag = _randomGenerator.Next(0, 2) == 0;
				int i3;
				for (i3 = 1; i3 < StepCount; i3++)
				{
					bool num12 = _randomGenerator.Next(0, StepCount - num11) < num10;
					num11++;
					if (!num12)
					{
						continue;
					}
					num10--;
					List<GalaxyMapSector> list7 = Sectors.Where((GalaxyMapSector s) => s.Step == i3).ToList();
					Vector2 vector3 = (Vector2)startPos + (Vector2)generalDirection / (float)StepCount * i3;
					Vector2 vector4 = vector3 + RotateVector(generalDirection, -90f);
					Dictionary<GalaxyMapSector, float> dictionary2 = new Dictionary<GalaxyMapSector, float>();
					foreach (GalaxyMapSector item9 in list7)
					{
						dictionary2.Add(item9, (item9.Position - vector4).magnitude);
					}
					int num13 = _randomGenerator.Next(0, 10);
					int num14 = ((num13 != 0) ? 1 : 2);
					bool flag2 = ((num13 < 2) ? (!flag) : flag);
					for (int num15 = 0; num15 < num14; num15++)
					{
						GalaxyMapSector galaxyMapSector4 = (flag2 ? dictionary2.OrderBy((KeyValuePair<GalaxyMapSector, float> kvp) => kvp.Value).First().Key : dictionary2.OrderBy((KeyValuePair<GalaxyMapSector, float> kvp) => kvp.Value).Last().Key);
						SolarSystem newSolarSystem3 = GetNewSolarSystem(currentLevel, i3);
						newSolarSystem3.SetPreset(_manager.GetRandomSpecialSystem(_randomGenerator, newSolarSystem3.MapComplexity));
						newSolarSystem3.IsDeadEnd = true;
						Vector2 vector5 = galaxyMapSector4.Position + RotateVector((vector4 - vector3).normalized, 15 * (flag2 ? 1 : (-1))) * (flag2 ? 1 : (-1)) * ((galaxyMapSector4.Radius + newSolarSystem3.Radius + 50f) * 1.8f);
						vector5 = GetPerlinPosition(vector5, RotateVector((vector4 - vector3).normalized, 90 * (flag2 ? 1 : (-1))));
						newSolarSystem3.Init(_randomGenerator, vector5);
						Sectors.Add(newSolarSystem3);
						newSolarSystem3.AddNeighbour(galaxyMapSector4);
						galaxyMapSector4.AddNeighbour(newSolarSystem3);
						flag2 = !flag2;
					}
					flag = flag2;
				}
			}
			if (currentLevel > 1 && StartLocation != null)
			{
				StartLocation.Sector.ExploreNeighbours();
			}
			yield return true;
		}

		private void AddShop<T, D>(List<LocationSetting> allShops, List<LocationData> currentShops, Dictionary<LocationSetting, float> shopDict, int targetShops) where T : LocationSetting where D : LocationData
		{
			LocationSetting key = allShops.First((LocationSetting l) => l is T);
			float value = (float)targetShops / 1.8f - (float)currentShops.Count((LocationData s) => s is D);
			shopDict.Add(key, value);
		}

		private SolarSystem GetNewSolarSystem(int currentLevel, int step, SolarSystem previous = null)
		{
			SolarSystem solarSystem = new SolarSystem
			{
				Step = step
			};
			if (_hasPreset && _manager.GalaxyProgression[currentLevel].Stages != null && _manager.GalaxyProgression[currentLevel].Stages.Count > 0)
			{
				List<GalaxyMapManager.ProgressionStage> stages = _manager.GalaxyProgression[currentLevel].Stages;
				int index = Mathf.FloorToInt((float)step * (float)stages.Count / (float)StepCount);
				EMissionComplexity missionComplexity = stages[index].MissionComplexity;
				solarSystem.MissionComplexity = missionComplexity;
				EGalaxyComplexity galaxyComplexity = stages[index].GalaxyComplexity;
				solarSystem.MapComplexity = galaxyComplexity;
				if (!stages[index].AllowAllSystems && stages[index].AllowedSystems.Count > 0)
				{
					SolarSystemSetting solarSystemSetting = stages[index].AllowedSystems.RandomItem(_randomGenerator);
					if (solarSystemSetting != null && solarSystemSetting.IsCompatibleWithGameMode())
					{
						solarSystem.SetPreset(solarSystemSetting);
					}
				}
				if (!stages[index].AllowAllClimateZones && stages[index].AllowedClimateZones.Count > 0)
				{
					solarSystem.SetAllowedClimateZones(_manager.GalaxyProgression[currentLevel].Stages[index].AllowedClimateZones);
				}
				if (previous != null)
				{
					solarSystem.AddForbiddenClimateZone(previous.ClimateZoneType);
				}
				foreach (GalaxyMapSector item in Sectors.Where((GalaxyMapSector s) => s.Step == step))
				{
					SolarSystem solarSystem2;
					if ((solarSystem2 = item as SolarSystem) != null)
					{
						solarSystem.AddForbiddenClimateZone(solarSystem2.ClimateZoneType);
					}
				}
			}
			else if (RuntimeGlobals.GameMode == EGameMode.Creative && currentLevel <= 2)
			{
				int num = ((currentLevel == 1) ? 1 : 3);
				num = (int)(solarSystem.MissionComplexity = (EMissionComplexity)(num + Mathf.RoundToInt((float)step / (float)StepCount)));
				solarSystem.MapComplexity = (EGalaxyComplexity)num;
			}
			else
			{
				solarSystem.MissionComplexity = EnumHelper.GetRandomEnumValue<EMissionComplexity>(new System.Random(), 1);
				solarSystem.MapComplexity = EnumHelper.GetRandomEnumValue<EGalaxyComplexity>(new System.Random(), 1);
			}
			return solarSystem;
		}

		private Vector2 RotateVector(Vector2 vector, float angle)
		{
			float f = angle * ((float)System.Math.PI / 180f);
			float x = vector.x * Mathf.Cos(f) - vector.y * Mathf.Sin(f);
			float y = vector.x * Mathf.Sin(f) + vector.y * Mathf.Cos(f);
			return new Vector2(x, y);
		}

		private Vector3 GetPerlinPosition(Vector3 start, Vector3 displacementVector)
		{
			return start + displacementVector * (float)_perlin.GetValue(start.x, start.y, 1.0) * 20f;
		}

		private Vector3 GetDerivativePosition(int startAngle, int offset, int minDeviation, int maxDeviation)
		{
			int num = startAngle + offset;
			num = ((_randomGenerator.Next(0, 2) != 0) ? (num - _randomGenerator.Next(minDeviation, maxDeviation)) : (num + _randomGenerator.Next(minDeviation, maxDeviation)));
			num = Mathf.RoundToInt(Mathf.Repeat(num, 360f));
			return new Vector3(Mathf.Cos((float)num * ((float)System.Math.PI / 180f)) * (_diameter / 2f), Mathf.Sin((float)num * ((float)System.Math.PI / 180f)) * (_diameter / 2f), 0f);
		}

		private bool IsShopAllowed(GalaxyMapSector toCheck, LocationData shopData)
		{
			if (GetOverlap(toCheck) != null)
			{
				return false;
			}
			SolarSystem solarSystem;
			if ((shopData is GarageLocationData || shopData is ScrapyardLocationData) && (solarSystem = toCheck as SolarSystem) != null)
			{
				if (shopData is GarageLocationData && solarSystem.Locations.Count((LocationData l) => l is GarageLocationData) > 1)
				{
					return false;
				}
				if (shopData is ScrapyardLocationData && solarSystem.Locations.Count((LocationData l) => l is ScrapyardLocationData) > 1)
				{
					return false;
				}
			}
			return true;
		}

		private GalaxyMapSector GetOverlap(GalaxyMapSector toAdd, GalaxyMapSector last = null)
		{
			GalaxyMapSector result = null;
			foreach (GalaxyMapSector sector in Sectors)
			{
				if ((sector.Position - toAdd.Position).magnitude < toAdd.Radius + sector.Radius + 50f && sector != toAdd && sector != last)
				{
					result = sector;
					break;
				}
			}
			return result;
		}
	}
}
