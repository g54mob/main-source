using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;
using UnityEngine;

namespace Assets.Scripts.Craft.Fuel
{
	public class CraftFuelSources : ICraftFuelSources, IDisposable
	{
		private List<CrossFeedScript> _crossFeeds = new List<CrossFeedScript>();

		private List<Tuple<IFuelSource, IFuelSource>> _equalizeCrossFeeds;

		private Dictionary<FuelType, double> _frameFuelLog;

		private List<CraftFuelSource> _fuelSources = new List<CraftFuelSource>();

		private IFuelTransferManager _fuelTransferManager;

		public IReadOnlyList<IFuelSource> FuelSources => _fuelSources;

		public event FuelDelegate FuelUsed;

		public CraftFuelSources(IFuelTransferManager fuelTransferManager)
		{
			_fuelTransferManager = fuelTransferManager;
		}

		public void AbsorbFuelSources(CraftFuelSources craftFuelSources)
		{
			int num = 0;
			foreach (CraftFuelSource fuelSource in _fuelSources)
			{
				num = Mathf.Max(fuelSource.Id, num);
			}
			num++;
			foreach (CraftFuelSource fuelSource2 in craftFuelSources._fuelSources)
			{
				fuelSource2.FuelTransferMode = FuelTransferMode.None;
				_fuelSources.Add(fuelSource2);
				fuelSource2.FuelTransferManager = _fuelTransferManager;
				fuelSource2.Id = num++;
			}
		}

		public void CreateFuelSourceForConnectedParts(IEnumerable<PartData> parts, bool removeDisconnectedCrossFeeds, List<CraftFuelSource> fuelSources)
		{
			List<FuelTankData> list = new List<FuelTankData>();
			Dictionary<int, FuelTankScript> dictionary = new Dictionary<int, FuelTankScript>();
			foreach (PartData part in parts)
			{
				part.GetModifiers(list);
				if (!removeDisconnectedCrossFeeds)
				{
					CrossFeedData modifier = part.GetModifier<CrossFeedData>();
					if (modifier != null && modifier.Mode != CrossFeedData.CrossFeedMode.Disabled)
					{
						_crossFeeds.Add(modifier.Script);
					}
				}
			}
			foreach (FuelTankData item in list)
			{
				CraftFuelSource craftFuelSource = null;
				if (item != null && !item.Script.PartScript.Disconnected)
				{
					if (item.FuelType == FuelType.Battery)
					{
						craftFuelSource = item.Part.PartScript.CommandPod?.BatteryFuelSource as CraftFuelSource;
					}
					else if (item.FuelType == FuelType.Monopropellant)
					{
						craftFuelSource = item.Part.PartScript.CommandPod?.MonoFuelSource as CraftFuelSource;
					}
					else if (item.FuelType == FuelType.Jet)
					{
						craftFuelSource = item.Part.PartScript.CommandPod?.JetFuelSource as CraftFuelSource;
					}
				}
				if (craftFuelSource != null)
				{
					craftFuelSource?.AddFuelTank(item.Script);
				}
				else
				{
					dictionary[item.Part.Id] = item.Script;
				}
			}
			int[] array = dictionary.Keys.ToArray();
			foreach (int key in array)
			{
				FuelTankScript fuelTankScript = dictionary[key];
				if (fuelTankScript != null)
				{
					FuelTankScript fuelTankScript2 = fuelTankScript;
					CraftFuelSource craftFuelSource2 = CreateFuelSource(fuelTankScript2.Data.FuelType);
					FindConnectedTanks(fuelTankScript2.PartScript.Data, fuelTankScript2, craftFuelSource2, dictionary);
					fuelSources?.Add(craftFuelSource2);
				}
			}
			SetupCrossFeeds(removeDisconnectedCrossFeeds);
		}

		public void Dispose()
		{
			this.FuelUsed = null;
		}

		public void Rebuild(ICraftScript craftScript)
		{
			_fuelSources.Clear();
			_crossFeeds.Clear();
			CraftFuelSource batteryFuelSource = CreateFuelSource(FuelType.Battery);
			foreach (ICommandPod commandPod in craftScript.CommandPods)
			{
				CommandPodScript obj = commandPod as CommandPodScript;
				obj.BatteryFuelSource = batteryFuelSource;
				obj.JetFuelSource = CreateFuelSource(FuelType.Jet, reverseSubPriority: true);
				obj.MonoFuelSource = CreateFuelSource(FuelType.Monopropellant, reverseSubPriority: true);
			}
			IReadOnlyList<PartData> parts = craftScript.Data.Assembly.Parts;
			CreateFuelSourceForConnectedParts(parts, removeDisconnectedCrossFeeds: false, null);
		}

		public void Update(float deltaTime)
		{
			foreach (CraftFuelSource fuelSource in _fuelSources)
			{
				fuelSource.UpdateCrossFeeds(deltaTime);
			}
			if (_equalizeCrossFeeds != null)
			{
				foreach (Tuple<IFuelSource, IFuelSource> equalizeCrossFeed in _equalizeCrossFeeds)
				{
					EqualizeFuelSources(equalizeCrossFeed.Item1, equalizeCrossFeed.Item2, deltaTime);
				}
			}
			ClearFuelLog();
			List<CraftFuelSource> list = null;
			foreach (CraftFuelSource fuelSource2 in _fuelSources)
			{
				double fuelDelta = fuelSource2.UpdateFuel();
				LogFuelUsed(fuelSource2.FuelType, fuelDelta);
				if (fuelSource2.IsDead)
				{
					if (list == null)
					{
						list = new List<CraftFuelSource>();
					}
					list.Add(fuelSource2);
				}
			}
			if (list != null)
			{
				foreach (CraftFuelSource item in list)
				{
					_fuelSources.Remove(item);
				}
			}
			RaiseFuelUsedEvents();
		}

		private static void FindConnectedTanks(PartData part, FuelTankScript fuelTankScript, CraftFuelSource fuelSource, Dictionary<int, FuelTankScript> lookup)
		{
			if (fuelTankScript != null)
			{
				fuelSource.AddFuelTank(fuelTankScript);
			}
			lookup[part.Id] = null;
			foreach (PartConnection partConnection in part.PartConnections)
			{
				PartData otherPart = partConnection.GetOtherPart(part);
				FuelTankScript value = null;
				if (lookup.TryGetValue(otherPart.Id, out value))
				{
					if (value != null && value.Data.FuelType == fuelSource.FuelType && EngineUtilities.ConnectedWithFuelLine(partConnection, part, otherPart))
					{
						FindConnectedTanks(otherPart, value, fuelSource, lookup);
					}
				}
				else if (otherPart.Config.FuelLineOverride)
				{
					FindConnectedTanks(otherPart, null, fuelSource, lookup);
				}
			}
		}

		private void ClearFuelLog()
		{
			if (_frameFuelLog != null)
			{
				_frameFuelLog.Clear();
			}
		}

		private CraftFuelSource CreateFuelSource(FuelType fuelType, bool reverseSubPriority = false)
		{
			CraftFuelSource craftFuelSource = new CraftFuelSource(_fuelTransferManager, _fuelSources.Count, fuelType);
			craftFuelSource.ReverseSubPriority = reverseSubPriority;
			_fuelSources.Add(craftFuelSource);
			return craftFuelSource;
		}

		private void EqualizeFuelSources(IFuelSource sourceA, IFuelSource sourceB, float deltaTime)
		{
			double totalFuel = sourceA.TotalFuel;
			double totalFuel2 = sourceB.TotalFuel;
			double totalCapacity = sourceA.TotalCapacity;
			double totalCapacity2 = sourceB.TotalCapacity;
			double num = totalCapacity + totalCapacity2;
			if (num > 0.0)
			{
				double num2 = (totalFuel + totalFuel2) / num * totalCapacity - totalFuel;
				num2 *= 0.5;
				float num3 = sourceA.FuelType.FuelTransferRate * deltaTime;
				num2 = Mathd.Clamp(num2, 0f - num3, num3);
				if (num2 > 0.0)
				{
					sourceA.AddFuel(sourceB.RemoveFuel(num2));
				}
				else if (num2 < 0.0)
				{
					num2 = 0.0 - num2;
					sourceB.AddFuel(sourceA.RemoveFuel(num2));
				}
			}
		}

		private void LogFuelUsed(FuelType fuelType, double fuelDelta)
		{
			if (this.FuelUsed != null)
			{
				if (_frameFuelLog == null)
				{
					_frameFuelLog = new Dictionary<FuelType, double>();
				}
				double value = 0.0;
				_frameFuelLog.TryGetValue(fuelType, out value);
				_frameFuelLog[fuelType] = value + fuelDelta;
			}
		}

		private void RaiseFuelUsedEvents()
		{
			if (this.FuelUsed == null || _frameFuelLog == null)
			{
				return;
			}
			foreach (KeyValuePair<FuelType, double> item in _frameFuelLog)
			{
				double num = 0.0 - item.Value;
				if (num > 9.999999747378752E-05)
				{
					this.FuelUsed(num, item.Key);
				}
			}
		}

		private void SetupCrossFeeds(bool removeDisconnectedCrossFeeds)
		{
			if (removeDisconnectedCrossFeeds)
			{
				foreach (CraftFuelSource fuelSource in _fuelSources)
				{
					fuelSource.ClearCrossFeeds();
				}
				CrossFeedScript[] array = _crossFeeds.ToArray();
				_equalizeCrossFeeds?.Clear();
				CrossFeedScript[] array2 = array;
				foreach (CrossFeedScript crossFeedScript in array2)
				{
					if (crossFeedScript.PartScript.Disconnected)
					{
						_crossFeeds.Remove(crossFeedScript);
					}
				}
			}
			foreach (CrossFeedScript crossFeed in _crossFeeds)
			{
				FuelTankScript source = null;
				FuelTankScript target = null;
				if (!crossFeed.GetFuelTanks(out source, out target))
				{
					continue;
				}
				if (crossFeed.Data.Mode == CrossFeedData.CrossFeedMode.Equalize)
				{
					if (_equalizeCrossFeeds == null)
					{
						_equalizeCrossFeeds = new List<Tuple<IFuelSource, IFuelSource>>();
					}
					_equalizeCrossFeeds.Add(new Tuple<IFuelSource, IFuelSource>(source.CraftFuelSource, target.CraftFuelSource));
				}
				else
				{
					target.CraftFuelSource.AddCrossFeedPullSource(source.CraftFuelSource);
				}
			}
		}
	}
}
