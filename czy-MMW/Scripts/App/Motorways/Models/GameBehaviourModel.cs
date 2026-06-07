using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using JetBrains.Annotations;
using Motorways.Processes;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class GameBehaviourModel : IModel, IReusable, IReleasedFromScopeHandler, TileModel.IObserver
	{
		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("GameBehaviourModel");

		[Dependency]
		private IScope _scope;

		[Dependency]
		private UpgradeDatabaseModel _upgrades;

		[Dependency]
		private ActiveChallengesModel _challenges;

		[Dependency]
		private City _city;

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private PseudorandomGenerator _pseudorandomGenerator;

		public bool CanGameOver = true;

		public bool AllowSecondDestinationStartUpgraded => _city.Rules.AllowSecondDestinationStartUpgraded;

		public bool MysteryUpgradesActive => _challenges.HasModifierOfType(ChallengeModifierType.MysteryUpgrades);

		public bool UsesBonusTrees => _challenges.HasModifierOfType(ChallengeModifierType.BonusTrees);

		public bool ShouldHideStaticUpgrades => _city?.Rules?.ShouldHideStaticUpgrades == true;

		public int GetNumberOfUpgradeOptionsPerWeek()
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.UnlimitedUpgrades))
			{
				return 0;
			}
			int numberOfUpgradeOptionsPerWeek = _city.Rules.GetNumberOfUpgradeOptionsPerWeek();
			if (numberOfUpgradeOptionsPerWeek > 1)
			{
				if (_challenges.HasModifierOfType(ChallengeModifierType.ForceWeeklyUpgrade))
				{
					return 1;
				}
				if (_challenges.TryGetModifierOfType(ChallengeModifierType.SetUpgradeChoiceCount, out var firstModifierFound))
				{
					if (firstModifierFound.intParameter > 0)
					{
						return firstModifierFound.intParameter;
					}
					if (_challenges.TryGetModifierOfType(ChallengeModifierType.OverrideFreeConcreteAmount, out var firstModifierFound2) && firstModifierFound2.intParameter == 0)
					{
						return 0;
					}
					return 1;
				}
			}
			return numberOfUpgradeOptionsPerWeek;
		}

		public List<WeeklyUpgradeDefinition> GetWeeklyUpgradeChoiceOptions()
		{
			List<WeeklyUpgradeDefinition> list = new List<WeeklyUpgradeDefinition>();
			list.AddRange(_city.Definition.upgradeDefinitions.weeklyChoicePackages);
			if (_challenges.TryGetModifierOfType(ChallengeModifierType.SetUpgradeChoiceCount, out var firstModifierFound) && firstModifierFound.intParameter == 0)
			{
				list.Clear();
			}
			if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.AwardedUpgradeAmountMultiplier, UpgradeType.Concrete, out var firstModifierFound2))
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].package.additionalConcrete > 0)
					{
						list[i] = list[i].NewCopy();
						list[i].package.additionalConcrete = (int)(long)Fix64.Max(firstModifierFound2.fix64Parameter * (Fix64)list[i].package.additionalConcrete, Fix64.One);
					}
				}
			}
			if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.OverrideFreeConcreteAmount, UpgradeType.Concrete, out var firstModifierFound3))
			{
				for (int j = 0; j < list.Count; j++)
				{
					list[j] = list[j].NewCopy();
					list[j].package.additionalConcrete = firstModifierFound3.intParameter;
				}
			}
			if (_challenges.TryGetModifierOfType(ChallengeModifierType.ForceWeeklyUpgrade, out var firstModifierFound4))
			{
				ChallengeModifier firstModifierFound5;
				bool flag = _challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.AwardedUpgradeAmountMultiplier, firstModifierFound4.upgradeType, out firstModifierFound5);
				for (int k = 0; k < list.Count; k++)
				{
					if (list[k].package.type == firstModifierFound4.upgradeType)
					{
						WeeklyUpgradeDefinition weeklyUpgradeDefinition = list[k].NewCopy();
						list.Clear();
						if (flag)
						{
							weeklyUpgradeDefinition.package.amount = (int)(long)Fix64.Max(firstModifierFound5.fix64Parameter * (Fix64)weeklyUpgradeDefinition.package.amount, Fix64.One);
						}
						weeklyUpgradeDefinition.maxPackageCount = 0;
						weeklyUpgradeDefinition.startingWeek = 0;
						weeklyUpgradeDefinition.lastWeek = 0;
						list.Add(weeklyUpgradeDefinition);
						return list;
					}
				}
				Diagnostics.FailAssert("We failed to find a weekly upgrade choice for upgrade type '{0}', this challenge may be incompatible with city: '{1}'!", firstModifierFound4.upgradeType, _city.Definition.name);
				return list;
			}
			for (int l = 0; l < list.Count; l++)
			{
				if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.AwardedUpgradeAmountMultiplier, list[l].package.type, out var firstModifierFound6))
				{
					list[l] = list[l].NewCopy();
					list[l].package.amount = (int)(long)Fix64.Max(firstModifierFound6.fix64Parameter * (Fix64)list[l].package.amount, Fix64.One);
				}
				if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.PreventWeeklyUpgrade, list[l].package.type, out var _))
				{
					list.RemoveAt(l);
					l--;
				}
				else if (HasUnlimitedOfUpgrade(list[l].package.type))
				{
					list.RemoveAt(l);
					l--;
				}
			}
			if (list.Count == 0)
			{
				bool flag2 = true;
				if (_challenges.TryGetModifierOfType(ChallengeModifierType.OverrideFreeConcreteAmount, out var firstModifierFound8) && firstModifierFound8.intParameter == 0)
				{
					flag2 = false;
				}
				if (flag2)
				{
					WeeklyUpgradeDefinition defaultConcretePackage = GetDefaultConcretePackage();
					list.Add(defaultConcretePackage);
				}
			}
			return list;
		}

		public UpgradeChoice GenerateNextUpgradeChoices()
		{
			if (_city.Rules.GetNumberOfUpgradeOptionsPerWeek() == 9)
			{
				return GenerateAllAvailableUpgradeChoices();
			}
			UpgradeChoice upgradeChoice = _scope.Get<UpgradeChoice>();
			upgradeChoice.isFree = false;
			List<UpgradePackageDefinition> list = new List<UpgradePackageDefinition>();
			List<Fix64> list2 = new List<Fix64>();
			Fix64 zero = Fix64.Zero;
			foreach (WeeklyUpgradeDefinition weeklyUpgradeChoiceOption in GetWeeklyUpgradeChoiceOptions())
			{
				int upgradeWeekMetric = _city.Rules.UpgradeWeekMetric;
				bool flag = upgradeWeekMetric >= weeklyUpgradeChoiceOption.startingWeek;
				bool flag2 = weeklyUpgradeChoiceOption.lastWeek <= 0;
				bool flag3 = upgradeWeekMetric <= weeklyUpgradeChoiceOption.lastWeek;
				bool flag4 = weeklyUpgradeChoiceOption.maxPackageCount <= 0;
				bool flag5 = _upgrades.NumberOfPackagesTakenOf(weeklyUpgradeChoiceOption.package.type) < weeklyUpgradeChoiceOption.maxPackageCount;
				if (flag && (flag2 || flag3) && (flag4 || flag5))
				{
					list.Add(weeklyUpgradeChoiceOption.package);
					Fix64 fix = CalculateUpgradePackageWeight(weeklyUpgradeChoiceOption);
					list2.Add(fix);
					zero += fix;
				}
				else
				{
					Log.Info($"Rejecting {weeklyUpgradeChoiceOption.package.type}: isOnOrAfterStartingWeek: {flag}, isLastWeekInvalid: {flag2}, isOnOrBeforeLastWeek: {flag3}, isMaxPackageCountInvalid: {flag4}, hasNotTakenMaxUpgrades: {flag5}");
				}
			}
			int numberOfUpgradeOptionsPerWeek = GetNumberOfUpgradeOptionsPerWeek();
			for (int i = 0; i < numberOfUpgradeOptionsPerWeek; i++)
			{
				if (list.Count <= 0)
				{
					break;
				}
				Fix64 fix2 = _pseudorandomGenerator.Fix64() * zero;
				bool flag6 = false;
				for (int j = 0; j < list.Count; j++)
				{
					fix2 -= list2[j];
					if (fix2 <= Fix64.Zero)
					{
						upgradeChoice.choices.Add(list[j]);
						list.RemoveAt(j);
						flag6 = true;
						break;
					}
				}
				if (!flag6 && list.Count > 0)
				{
					upgradeChoice.choices.Add(list[list.Count - 1]);
					list.RemoveAt(list.Count - 1);
				}
			}
			foreach (UpgradePackageDefinition item in list)
			{
				_upgrades.OnUpgradeNotPresented(item.type);
			}
			foreach (UpgradePackageDefinition choice in upgradeChoice.choices)
			{
				_upgrades.OnUpgradePresented(choice.type);
			}
			upgradeChoice.ShuffleChoices(_pseudorandomGenerator);
			return upgradeChoice;
		}

		private UpgradeChoice GenerateAllAvailableUpgradeChoices()
		{
			if (_upgrades.TotalGrantedUpgradesCount >= _constants.MaxUpgradeChoicesAwardedInExpertMode)
			{
				return GenerateConcreteOnlyUpgradeChoice();
			}
			UpgradeChoice upgradeChoice = _scope.Get<UpgradeChoice>();
			upgradeChoice.isFree = false;
			foreach (WeeklyUpgradeDefinition weeklyUpgradeChoiceOption in GetWeeklyUpgradeChoiceOptions())
			{
				bool flag = true;
				foreach (UpgradePackageDefinition choice in upgradeChoice.choices)
				{
					if (weeklyUpgradeChoiceOption.package.type == choice.type)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					upgradeChoice.choices.Add(weeklyUpgradeChoiceOption.package);
					_upgrades.OnUpgradePresented(weeklyUpgradeChoiceOption.package.type);
				}
				else
				{
					Log.Info($"Rejecting {weeklyUpgradeChoiceOption.package.type}: Upgrade type already included in this upgrade choice package");
				}
			}
			for (int i = 0; i < upgradeChoice.choices.Count; i++)
			{
				if (upgradeChoice.choices[i].type == _upgrades.LastClaimedPackageType)
				{
					upgradeChoice.disabledOptions |= (DisabledUpgradeOptions)(1 << i + 1);
					break;
				}
			}
			return upgradeChoice;
		}

		private UpgradeChoice GenerateConcreteOnlyUpgradeChoice()
		{
			WeeklyUpgradeDefinition defaultConcretePackage = GetDefaultConcretePackage();
			UpgradeChoice upgradeChoice = _scope.Get<UpgradeChoice>();
			upgradeChoice.isFree = false;
			upgradeChoice.choices.Add(defaultConcretePackage.package);
			_upgrades.OnUpgradePresented(defaultConcretePackage.package.type);
			return upgradeChoice;
		}

		private Fix64 CalculateUpgradePackageWeight(WeeklyUpgradeDefinition weeklyUpgrade)
		{
			return (weeklyUpgrade.baseWeight + weeklyUpgrade.weightIncreaseWhenNotOffered * (Fix64)_upgrades.WeeksSinceUpgradePresented(weeklyUpgrade.package.type) + GetExtraWeightFromExpectedTimeline(weeklyUpgrade)) * GetMultiplierRelativeToUpgrades(weeklyUpgrade);
		}

		private Fix64 GetExtraWeightFromExpectedTimeline(WeeklyUpgradeDefinition weeklyUpgrade)
		{
			if (weeklyUpgrade.expectedUpgradeTimeline == null || weeklyUpgrade.expectedUpgradeTimeline.Count == 0)
			{
				return Fix64.Zero;
			}
			int upgradeWeekMetric = _city.Rules.UpgradeWeekMetric;
			for (int num = weeklyUpgrade.expectedUpgradeTimeline.Count - 1; num >= 0; num--)
			{
				ExpectedUpgradeTimeline expectedUpgradeTimeline = weeklyUpgrade.expectedUpgradeTimeline[num];
				if (expectedUpgradeTimeline.week <= upgradeWeekMetric && _upgrades.GetTotalUpgradeCount(weeklyUpgrade.package.type) < expectedUpgradeTimeline.expectedUpgradeCount)
				{
					return expectedUpgradeTimeline.bonusWeightIfNotMet;
				}
			}
			return Fix64.Zero;
		}

		private Fix64 GetMultiplierRelativeToUpgrades(WeeklyUpgradeDefinition weeklyUpgrade)
		{
			if (weeklyUpgrade.relativeUpgradeMultiplierCurve.length == 0)
			{
				return Fix64.One;
			}
			int availableUpgradeCount = _upgrades.GetAvailableUpgradeCount(weeklyUpgrade.relativeUpgradeType);
			return (Fix64)weeklyUpgrade.relativeUpgradeMultiplierCurve.Evaluate(availableUpgradeCount);
		}

		private WeeklyUpgradeDefinition GetDefaultConcretePackage()
		{
			int num = 0;
			WeeklyUpgradeDefinition[] weeklyChoicePackages = _city.Definition.upgradeDefinitions.weeklyChoicePackages;
			for (int i = 0; i < weeklyChoicePackages.Length; i++)
			{
				UpgradePackageDefinition package = weeklyChoicePackages[i].package;
				num = Mathf.Max(num, package.additionalConcrete);
			}
			if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.AwardedUpgradeAmountMultiplier, UpgradeType.Concrete, out var firstModifierFound))
			{
				num = (int)(long)Fix64.Max(firstModifierFound.fix64Parameter * (Fix64)num, Fix64.One);
			}
			return new WeeklyUpgradeDefinition
			{
				package = 
				{
					type = UpgradeType.Concrete,
					amount = num
				},
				relativeUpgradeMultiplierCurve = new AnimationCurve()
			};
		}

		public bool HasGotRules()
		{
			return _city?.Rules != null;
		}

		public bool HasUnlimitedOfUpgrade(UpgradeType type)
		{
			if (!FeatureToggle.IsFeatureEnabled(Feature.UnlimitedUpgrades))
			{
				GameRules rules = _city.Rules;
				ChallengeModifier firstModifierFound;
				if (rules == null || !rules.HasUnlimitedUpgrades)
				{
					return _challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.UnlimitedUpgrade, type, out firstModifierFound);
				}
			}
			return true;
		}

		public bool ShouldShowUpgradeCount()
		{
			if (_city == null || _city.Rules == null)
			{
				return true;
			}
			return _city.Rules.ShowUpgradeCounters;
		}

		public int GetAmountOfStartingUpgradesForType(UpgradeType type)
		{
			if (type == UpgradeType.House || type == UpgradeType.Destination || type == UpgradeType.DoubleDestination)
			{
				if (!(_city.Rules is CreativeGameRules))
				{
					return 0;
				}
				return 1;
			}
			int num = 0;
			UpgradePackageDefinition[] startingPackages = _city.Definition.upgradeDefinitions.startingPackages;
			for (int i = 0; i < startingPackages.Length; i++)
			{
				UpgradePackageDefinition upgradePackageDefinition = startingPackages[i];
				if (upgradePackageDefinition.type == type)
				{
					num = upgradePackageDefinition.amount;
				}
			}
			if (!_city.Definition.UsesUpgradeType(type))
			{
				return 0;
			}
			if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.StartWithUpgrade, type, out var firstModifierFound))
			{
				num = firstModifierFound.intParameter;
			}
			else if (HasUnlimitedOfUpgrade(type))
			{
				num = 1;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.StartWithTenMotorways) && type == UpgradeType.Motorway)
			{
				num += 10;
			}
			return num;
		}

		public BuildingPlacer.WeightEvaluationLevel GetDefaultBuildingWeightEvaluationLevel(CityTileType buildingType)
		{
			if (buildingType == CityTileType.Demand && _challenges.HasModifierOfType(ChallengeModifierType.DestinationsIgnoreTileWeights))
			{
				return BuildingPlacer.WeightEvaluationLevel.IgnoreWeights;
			}
			if (buildingType == CityTileType.Supply && _challenges.HasModifierOfType(ChallengeModifierType.HousesIgnoreTileWeights))
			{
				return BuildingPlacer.WeightEvaluationLevel.IgnoreWeights;
			}
			return BuildingPlacer.WeightEvaluationLevel.ExclusivelyUseWeightedTiles;
		}

		public bool DoesBuildingStartUpgraded(int groupIndex)
		{
			if (_challenges.HasModifierOfType(ChallengeModifierType.AllDestinationsStartUpgraded))
			{
				return true;
			}
			if (_challenges.HasModifierOfTypeWithIntParameter(ChallengeModifierType.AllDestinationsOfGroupStartUpgraded, groupIndex))
			{
				return true;
			}
			return false;
		}

		public bool TileSupportsCircleDestinations(int groupIndex, Vector2Int position)
		{
			if (_challenges.HasModifierOfType(ChallengeModifierType.DestinationsNeverUpgrade))
			{
				return false;
			}
			if (_challenges.HasModifierOfType(ChallengeModifierType.DestinationUpgradesIgnoreWeights))
			{
				return true;
			}
			return _city.Definition.TileSupportsCircleDestinations(groupIndex, position);
		}

		public Fix64 GetDemandMultiplierForBuilding(DestinationModel destination)
		{
			Fix64 demandMultiplier = destination.demandMultiplier;
			if (_challenges.TryGetModifierOfTypeWithIntParameter(ChallengeModifierType.ChangeDemandOfGroupIndex, destination.GroupIndex, out var firstModifierFound))
			{
				demandMultiplier *= firstModifierFound.fix64Parameter;
			}
			return demandMultiplier * _city.Rules.GetDemandMultiplierForDestination(destination);
		}

		public bool ForceDoubleDestinations()
		{
			return _challenges.HasModifierOfType(ChallengeModifierType.ForceDoubleDestinations);
		}

		public bool UseDestinationDeadzonesFor(CityTileType buildingType)
		{
			if (_city.Rules.NoDestinationDeadzoneForHouses)
			{
				return false;
			}
			switch (buildingType)
			{
			case CityTileType.Supply:
				return !_challenges.HasModifierOfType(ChallengeModifierType.NoDestinationDeadzoneForHouses);
			case CityTileType.Demand:
				return !_challenges.HasModifierOfType(ChallengeModifierType.NoDestinationDeadzoneForDestinations);
			default:
				Log.Error("Unhandled building type {0}. Using deadzones.", buildingType);
				return true;
			}
		}

		public bool BuildingSpawnsAreAffectedByOtherBuildings()
		{
			if (_challenges.HasModifierOfType(ChallengeModifierType.BuildingsIgnoreOtherBuildings))
			{
				return false;
			}
			if (_city.Rules.BuildingsIgnoreOtherBuildings)
			{
				return false;
			}
			return true;
		}

		public Fix64 GetLaneSpeed(LaneModel lane)
		{
			Fix64 maxSpeedOnMotorways;
			if (lane.connection.IsMotorway)
			{
				maxSpeedOnMotorways = _constants.maxSpeedOnMotorways;
				if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.ChangeUpgradeLaneSpeed, UpgradeType.Motorway, out var firstModifierFound))
				{
					maxSpeedOnMotorways *= firstModifierFound.fix64Parameter;
				}
				return maxSpeedOnMotorways;
			}
			if (lane.connection.IsRoundabout)
			{
				maxSpeedOnMotorways = _constants.roundaboutSpeedMultiplier;
				if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.ChangeUpgradeLaneSpeed, UpgradeType.Roundabout, out var firstModifierFound2))
				{
					maxSpeedOnMotorways *= firstModifierFound2.fix64Parameter;
				}
			}
			else
			{
				maxSpeedOnMotorways = _constants.defaultLaneSpeed;
			}
			if ((lane.connection.input.type != RoadType.Roundabout || lane.connection.output.type != RoadType.Roundabout) && lane.connection.input.type != RoadType.Motorway)
			{
				TileDirection direction = lane.connection.input.direction;
				TileDirection direction2 = lane.connection.output.direction;
				TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(direction);
				int distanceBetweenDirections = TileUtilities.GetDistanceBetweenDirections(direction2, oppositeDirection);
				if (distanceBetweenDirections == 2)
				{
					maxSpeedOnMotorways *= _constants.rightAngleTurnSpeedMultiplier;
				}
				else if (distanceBetweenDirections >= 3)
				{
					maxSpeedOnMotorways *= _constants.sharpTurnSpeedMultiplier;
				}
				if (distanceBetweenDirections >= 2 && distanceBetweenDirections < 4 && _challenges.TryGetModifierOfType(ChallengeModifierType.SharpTurnSpeedMultiplier, out var firstModifierFound3))
				{
					maxSpeedOnMotorways *= firstModifierFound3.fix64Parameter;
				}
			}
			if (lane.OutboundLanes.Count > 1 && !lane.connection.IsUTurn && !lane.connection.IsRoundabout)
			{
				int num = 0;
				bool flag = true;
				foreach (LaneModel outboundLane in lane.OutboundLanes)
				{
					if ((outboundLane.roadChunk != null && outboundLane.roadChunk.IsControlled) || outboundLane.connection.input.type == RoadType.Roundabout || outboundLane.connection.output.type == RoadType.Roundabout)
					{
						flag = false;
						break;
					}
					if (outboundLane.state != RoadState.Mothballed || !outboundLane.connection.IsUTurn)
					{
						num++;
					}
				}
				if (flag && num > 1)
				{
					maxSpeedOnMotorways *= _constants.intersectionSpeedMultiplier;
				}
			}
			return maxSpeedOnMotorways;
		}

		public bool CanDrawRoadOn(TileContentType contentType)
		{
			if (_challenges.HasModifierOfType(ChallengeModifierType.IndestructibleTrees))
			{
				return contentType == TileContentType.None;
			}
			if (contentType != TileContentType.None)
			{
				return contentType == TileContentType.Tree;
			}
			return true;
		}

		public int GetConcreteCostForMotorway(Vector2Int startCoordinates, Vector2Int endCoordinates)
		{
			if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.UpgradeRoadCostMultiplier, UpgradeType.Motorway, out var firstModifierFound))
			{
				return GameRules.GetMotorwayLength(startCoordinates, endCoordinates) * firstModifierFound.intParameter;
			}
			return 0;
		}

		public int GetConcreteCostForConnection([NotNull] Tile origin, [NotNull] Tile destination)
		{
			return GetConcreteCostForConnection(origin.Coordinates, origin.ContentType, destination.Coordinates, destination.ContentType);
		}

		public int GetConcreteCostForConnection(ITilemap tilemap, Vector2Int originCoordinates, Vector2Int destinationCoordinates)
		{
			Tile tile = tilemap.GetTile(originCoordinates);
			Tile tile2 = tilemap.GetTile(destinationCoordinates);
			return GetConcreteCostForConnection(originCoordinates, tile?.ContentType ?? TileContentType.None, destinationCoordinates, tile2?.ContentType ?? TileContentType.None);
		}

		public int GetConcreteCostForConnection(Vector2Int originCoordinates, TileContentType originContent, Vector2Int destinationCoordinates, TileContentType destinationContent)
		{
			if (!Diagnostics.Verify(originContent == TileContentType.None || originContent == TileContentType.Tree || originContent == TileContentType.House))
			{
				return 0;
			}
			if (!Diagnostics.Verify(destinationContent == TileContentType.None || destinationContent == TileContentType.Tree || destinationContent == TileContentType.House))
			{
				return 0;
			}
			if (originContent == TileContentType.House || destinationContent == TileContentType.House)
			{
				return 0;
			}
			TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(originCoordinates, destinationCoordinates);
			if (!Diagnostics.Verify(directionBetweenAdjacentCoordinates != TileDirection.None, "Can't price a connection between non-adjacent coordinates."))
			{
				return 0;
			}
			int num = 1;
			ChallengeModifier firstModifierFound2;
			if (TileUtilities.IsDirectionDiagonal(directionBetweenAdjacentCoordinates))
			{
				if (_challenges.TryGetModifierOfType(ChallengeModifierType.DiagonalRoadCostMultiplier, out var firstModifierFound))
				{
					num *= firstModifierFound.intParameter;
				}
			}
			else if (_challenges.TryGetModifierOfType(ChallengeModifierType.StraightRoadCostMultiplier, out firstModifierFound2))
			{
				num *= firstModifierFound2.intParameter;
			}
			ChallengeModifier firstModifierFound4;
			if (_city.Definition.TileIsOverWater(originCoordinates) || _city.Definition.TileIsOverWater(destinationCoordinates))
			{
				if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.UpgradeRoadCostMultiplier, UpgradeType.Bridge, out var firstModifierFound3))
				{
					num *= firstModifierFound3.intParameter;
				}
			}
			else if ((_city.Definition.TileIsUnderAMountain(originCoordinates) || _city.Definition.TileIsUnderAMountain(destinationCoordinates)) && _challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.UpgradeRoadCostMultiplier, UpgradeType.Tunnel, out firstModifierFound4))
			{
				num *= firstModifierFound4.intParameter;
			}
			return num;
		}

		public bool OverridesGameModeWithExpert()
		{
			return _challenges.HasModifierOfType(ChallengeModifierType.OverrideGameModeWithExpert);
		}

		public void Inspect()
		{
		}

		public void OnReleasedFromScope(IScope scope)
		{
		}

		public void Reset()
		{
			CanGameOver = true;
		}

		public void OnTileModelChanged(TileModel model)
		{
			if (_city.Definition.TileIsOverWater(model.Coordinates))
			{
				if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.ChangeUpgradeLaneSpeed, UpgradeType.Bridge, out var firstModifierFound))
				{
					model.roadChunk.SetLaneSpeedLimitScale(firstModifierFound.fix64Parameter);
				}
			}
			else if (_city.Definition.TileIsUnderAMountain(model.Coordinates))
			{
				if (_challenges.TryGetModifierOfTypeWithUpgradeTypeParameter(ChallengeModifierType.ChangeUpgradeLaneSpeed, UpgradeType.Tunnel, out var firstModifierFound2))
				{
					model.roadChunk.SetLaneSpeedLimitScale(firstModifierFound2.fix64Parameter);
				}
			}
			else if (_city.Rules.RoadsBecomePermanentOverTime)
			{
				model.roadChunk.SetSpeedLimitScaleOnDirections(~model.Tile.GetPermanentDirections(), _constants.DryingRoadSpeedMultiplier, resetOtherDirections: true);
				model.roadChunk.UpdateLaneCosts();
			}
		}
	}
}
