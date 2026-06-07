using System.Collections.Generic;
using System.Linq;
using Factory;
using Factory.Pools;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class ActiveChallengesModel : IModel, IReusable, IDeserializedHandler
	{
		public const int GracePeriodInSeconds = 3600;

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ActiveChallengesModel");

		[Dependency]
		private ChallengeSystem _challengeSystem;

		[Dependency]
		private City _city;

		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private GameBehaviourModel _behaviour;

		public readonly List<ChallengeData> challenges = new List<ChallengeData>();

		public MapChallenge.ChallengeType challengeType;

		public int cityChallengeIndex = -1;

		public int timeEnd;

		public int timeStart;

		public ulong initialSeed;

		public bool HasChallenges => challenges.Count > 0;

		public bool HasEndTime => timeEnd != 0;

		public int SecondsLeft => timeEnd - _challengeSystem.CurrentTimestamp;

		public bool IsActive
		{
			get
			{
				if (HasStarted())
				{
					return SecondsLeft > 0;
				}
				return false;
			}
		}

		public int TimeEndWithGracePeriod => timeEnd + 3600;

		public bool IsActiveWithGracePeriod
		{
			get
			{
				if (HasStarted())
				{
					return SecondsLeftWithGracePeriod > 0;
				}
				return false;
			}
		}

		public int SecondsLeftWithGracePeriod => TimeEndWithGracePeriod - _challengeSystem.CurrentTimestamp;

		public bool IsCityChallenge
		{
			get
			{
				if (HasChallenges)
				{
					return cityChallengeIndex != -1;
				}
				return false;
			}
		}

		private bool HasStarted()
		{
			return _challengeSystem.CurrentTimestamp - timeStart > 0;
		}

		public bool HasModifierOfType(ChallengeModifierType type)
		{
			ChallengeModifier firstModifierFound;
			return TryGetModifierOfType(type, out firstModifierFound);
		}

		public bool TryGetModifierOfType(ChallengeModifierType type, out ChallengeModifier firstModifierFound)
		{
			foreach (ChallengeData challenge in challenges)
			{
				if (challenge == null)
				{
					continue;
				}
				foreach (ChallengeModifier modifier in challenge.modifiers)
				{
					if (modifier.type == type)
					{
						firstModifierFound = modifier;
						return true;
					}
				}
			}
			firstModifierFound = null;
			return false;
		}

		public bool HasModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType modifierType, UpgradeType upgradeType)
		{
			ChallengeModifier firstModifierFound;
			return TryGetModifierOfTypeWithUpgradeTypeParameter(modifierType, upgradeType, out firstModifierFound);
		}

		public bool TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType modifierType, UpgradeType upgradeType, out ChallengeModifier firstModifierFound)
		{
			foreach (ChallengeData challenge in challenges)
			{
				if (challenge == null)
				{
					continue;
				}
				foreach (ChallengeModifier modifier in challenge.modifiers)
				{
					if (modifier.type == modifierType && modifier.upgradeType == upgradeType)
					{
						firstModifierFound = modifier;
						return true;
					}
				}
			}
			firstModifierFound = null;
			return false;
		}

		public bool HasModifierOfTypeWithIntParameter(ChallengeModifierType modifierType, int intParameter)
		{
			ChallengeModifier firstModifierFound;
			return TryGetModifierOfTypeWithIntParameter(modifierType, intParameter, out firstModifierFound);
		}

		public bool TryGetModifierOfTypeWithIntParameter(ChallengeModifierType modifierType, int intData, out ChallengeModifier firstModifierFound)
		{
			foreach (ChallengeData challenge in challenges)
			{
				if (challenge == null)
				{
					continue;
				}
				foreach (ChallengeModifier modifier in challenge.modifiers)
				{
					if (modifier.type == modifierType && modifier.intParameter == intData)
					{
						firstModifierFound = modifier;
						return true;
					}
				}
			}
			firstModifierFound = null;
			return false;
		}

		public void RemoveChallengesForEndless()
		{
			bool num = HasModifierOfType(ChallengeModifierType.StraightRoadCostMultiplier) || HasModifierOfType(ChallengeModifierType.DiagonalRoadCostMultiplier) || HasModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.UpgradeRoadCostMultiplier, UpgradeType.Bridge) || HasModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.UpgradeRoadCostMultiplier, UpgradeType.Tunnel);
			bool flag = HasModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.UpgradeRoadCostMultiplier, UpgradeType.Motorway);
			bool flag2 = HasModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.UnlimitedUpgrade, UpgradeType.Concrete);
			UpgradeDatabaseModel model = _simulation.GetModel<UpgradeDatabaseModel>();
			challenges.Clear();
			int num2 = 0;
			if (num)
			{
				int num3 = 0;
				ModelListEnumerator<TileModel> enumerator = _simulation.GetModels<TileModel>().GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileModel current = enumerator.Current;
					if (current.Tile.ContentType != TileContentType.None)
					{
						continue;
					}
					TileDirectionBitfield.Enumerator enumerator2 = current.Tile.GetTwoLaneRoads(RoadState.Live).GetEnumerator();
					while (enumerator2.MoveNext())
					{
						TileDirection current2 = enumerator2.Current;
						Tile tile = current.GetAdjacentTileModelInDirection(current2).Tile;
						if (tile.ContentType == TileContentType.None)
						{
							num3 += _behaviour.GetConcreteCostForConnection(current.Tile, tile);
						}
					}
				}
				num3 /= 2;
				int usedUpgradeCount = model.GetUsedUpgradeCount(UpgradeType.Concrete);
				num2 += usedUpgradeCount - num3;
			}
			if (flag)
			{
				ModelListEnumerator<MotorwayModel> enumerator3 = _simulation.GetModels<MotorwayModel>().GetEnumerator();
				while (enumerator3.MoveNext())
				{
					MotorwayModel current3 = enumerator3.Current;
					num2 += current3.ConcreteCost;
					current3.ConcreteCost = 0;
				}
			}
			if (num2 > 0)
			{
				model.MothballUpgrade(UpgradeType.Concrete, num2);
				model.ReleaseMothballedUpgrade(UpgradeType.Concrete, num2);
			}
			else if (num2 < 0)
			{
				num2 = -num2;
				model.AddUpgradeToTotal(UpgradeType.Concrete, num2);
			}
			if (flag2)
			{
				int amount = _city.Definition.upgradeDefinitions.startingPackages.First((UpgradePackageDefinition definition) => definition.type == UpgradeType.Concrete).amount;
				int num4 = _city.Definition.upgradeDefinitions.weeklyChoicePackages.Max((WeeklyUpgradeDefinition definition) => definition.package.additionalConcrete);
				int num5 = _clock.ExpansionWeek * num4 + amount;
				int usedUpgradeCount2 = model.GetUsedUpgradeCount(UpgradeType.Concrete);
				int amount2 = Mathf.Max(num5 - usedUpgradeCount2, amount) - model.GetAvailableUpgradeCount(UpgradeType.Concrete);
				model.ApplyUpgradePackage(new UpgradePackageDefinition
				{
					amount = amount2,
					type = UpgradeType.Concrete,
					additionalConcrete = 0
				});
			}
		}

		public void Inspect()
		{
		}

		public void Reset()
		{
			challenges.Clear();
			challengeType = MapChallenge.ChallengeType.None;
			cityChallengeIndex = -1;
			timeEnd = 0;
			timeStart = 0;
			initialSeed = 0uL;
		}

		public void OnDeserialized(IScope context)
		{
			bool flag = false;
			int num = 0;
			while (num < challenges.Count)
			{
				if (challenges[num] == null)
				{
					challenges.RemoveAt(num);
					flag = true;
				}
				else
				{
					num++;
				}
			}
			if (flag)
			{
				Log.Error("Found a null challenge in a deserialized game! Check that the ChallengeDatabase contains all of the available challenge modifiers.");
			}
		}
	}
}
