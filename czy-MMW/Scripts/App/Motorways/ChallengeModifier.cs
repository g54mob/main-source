using System;
using FixMath;
using UnityEngine.Serialization;

namespace Motorways
{
	[Serializable]
	public class ChallengeModifier
	{
		public ChallengeModifierType type;

		public UpgradeType upgradeType;

		public int intParameter;

		[FormerlySerializedAs("fix64Paramter")]
		public Fix64 fix64Parameter;

		private string PluralS
		{
			get
			{
				if (intParameter != 1)
				{
					return "s";
				}
				return "";
			}
		}

		public override string ToString()
		{
			switch (type)
			{
			case ChallengeModifierType.StartWithUpgrade:
				return $"Start with {intParameter} {upgradeType}{PluralS}";
			case ChallengeModifierType.PreventWeeklyUpgrade:
				return $"Prevent Weekly Upgrade ({upgradeType})";
			case ChallengeModifierType.ForceWeeklyUpgrade:
				return $"Exclusive Weekly Upgrade {upgradeType}";
			case ChallengeModifierType.AwardedUpgradeAmountMultiplier:
				return $"{fix64Parameter} {upgradeType} awarded";
			case ChallengeModifierType.SetUpgradeChoiceCount:
				return $"Offer {intParameter} weekly upgrade choice{PluralS}";
			case ChallengeModifierType.OverrideFreeConcreteAmount:
				return $"Give {intParameter} free concrete";
			case ChallengeModifierType.DestinationsIgnoreTileWeights:
				return "Destinations Ignore Tile Weights";
			case ChallengeModifierType.ChangeDemandOfGroupIndex:
				return $"Multiply demand group {intParameter} by {fix64Parameter}";
			case ChallengeModifierType.DestinationUpgradesIgnoreWeights:
				return "Destination Upgrades Ignore Weights";
			case ChallengeModifierType.DestinationsNeverUpgrade:
				return "Destinations Never Upgrade";
			case ChallengeModifierType.AllDestinationsStartUpgraded:
				return "All Destinations Start Upgraded";
			case ChallengeModifierType.AllDestinationsOfGroupStartUpgraded:
				return $"All Destinations of group {intParameter} start upgraded";
			case ChallengeModifierType.HousesIgnoreTileWeights:
				return "Houses Ignore Weights";
			case ChallengeModifierType.ForceDoubleDestinations:
				return "All Destinations Are Doubles";
			case ChallengeModifierType.NoDestinationDeadzoneForDestinations:
				return "Destinations Ignore Deadzone for Destinations";
			case ChallengeModifierType.NoDestinationDeadzoneForHouses:
				return "Destinations Ignore Deadzone for Houses";
			case ChallengeModifierType.BuildingsIgnoreOtherBuildings:
				return "Building Spawns Ignore Other Buildings";
			case ChallengeModifierType.UnlimitedUpgrade:
				return $"Unlimited {upgradeType}";
			case ChallengeModifierType.IndestructibleTrees:
				return "Indestructible Trees";
			case ChallengeModifierType.BonusTrees:
				return "Bonus Trees";
			case ChallengeModifierType.MysteryUpgrades:
				return "Mystery Upgrades";
			case ChallengeModifierType.ChangeUpgradeLaneSpeed:
				return $"Change {upgradeType} Lane Speed by {fix64Parameter}";
			case ChallengeModifierType.StraightRoadCostMultiplier:
				return $"Multiply Straight Road Cost By {intParameter}";
			case ChallengeModifierType.DiagonalRoadCostMultiplier:
				return $"Multiply Diagonal Road Cost By {intParameter}";
			case ChallengeModifierType.UpgradeRoadCostMultiplier:
				return $"Multiply {upgradeType} Road Cost By {intParameter}";
			case ChallengeModifierType.SharpTurnSpeedMultiplier:
				return $"Multiply 90 and 45 turn speed by {fix64Parameter}";
			case ChallengeModifierType.OverrideGameModeWithExpert:
				return "Go to Expert mode";
			default:
				Diagnostics.FailAssert("Please fill out the ChallengeModifier `ToString` for {0}", type);
				return base.ToString();
			}
		}

		public string ToFilenameString()
		{
			return type switch
			{
				ChallengeModifierType.StartWithUpgrade => string.Format("startwith{0}{1}{2}", intParameter, "_", upgradeType), 
				ChallengeModifierType.PreventWeeklyUpgrade => string.Format("remove{0}{1}", "_", upgradeType), 
				ChallengeModifierType.ForceWeeklyUpgrade => string.Format("exclusive{0}{1}", "_", upgradeType), 
				ChallengeModifierType.AwardedUpgradeAmountMultiplier => string.Format("{0}{1}{2}{3}awarded", fix64Parameter, "_", upgradeType, "_"), 
				ChallengeModifierType.SetUpgradeChoiceCount => string.Format("{0}{1}upgradechoice", intParameter, "_"), 
				ChallengeModifierType.OverrideFreeConcreteAmount => string.Format("freeconcrete{0}{1}", "_", intParameter), 
				ChallengeModifierType.DestinationsIgnoreTileWeights => "destinationsignoreweights", 
				ChallengeModifierType.ChangeDemandOfGroupIndex => string.Format("group{0}{1}{2}demandmultiplier", "_", intParameter, "_"), 
				ChallengeModifierType.DestinationUpgradesIgnoreWeights => "circlesignoreweights", 
				ChallengeModifierType.DestinationsNeverUpgrade => "nocircles", 
				ChallengeModifierType.AllDestinationsStartUpgraded => "allcircles", 
				ChallengeModifierType.AllDestinationsOfGroupStartUpgraded => string.Format("group{0}{1}{2}allcircles", "_", intParameter, "_"), 
				ChallengeModifierType.HousesIgnoreTileWeights => "housesignoreweights", 
				ChallengeModifierType.ForceDoubleDestinations => "forcedoubles", 
				ChallengeModifierType.NoDestinationDeadzoneForDestinations => "nodestinationdeadzone", 
				ChallengeModifierType.NoDestinationDeadzoneForHouses => "nohousedeadzone", 
				ChallengeModifierType.BuildingsIgnoreOtherBuildings => "spawnsignorebuildings", 
				ChallengeModifierType.UnlimitedUpgrade => string.Format("unlimited{0}{1}", "_", upgradeType), 
				ChallengeModifierType.IndestructibleTrees => "indestructibletrees", 
				ChallengeModifierType.BonusTrees => "bonustrees", 
				ChallengeModifierType.MysteryUpgrades => "mysteryupgrades", 
				ChallengeModifierType.ChangeUpgradeLaneSpeed => string.Format("{0}lanespeed{1}{2}", upgradeType, "_", fix64Parameter), 
				ChallengeModifierType.StraightRoadCostMultiplier => string.Format("straightroadcost{0}{1}", "_", intParameter), 
				ChallengeModifierType.DiagonalRoadCostMultiplier => string.Format("diagonalroadcost{0}{1}", "_", intParameter), 
				ChallengeModifierType.UpgradeRoadCostMultiplier => string.Format("{0}{1}roadcost{2}{3}", upgradeType, "_", "_", intParameter), 
				ChallengeModifierType.SharpTurnSpeedMultiplier => string.Format("sharpturnspeed{0}{1}", "_", fix64Parameter), 
				ChallengeModifierType.OverrideGameModeWithExpert => "expert", 
				_ => string.Format("TYPE{0}{1}{2}INVALID", "_", type, "_"), 
			};
		}

		public float GetLocalizationParameter()
		{
			return type switch
			{
				ChallengeModifierType.StartWithUpgrade => intParameter, 
				ChallengeModifierType.SetUpgradeChoiceCount => intParameter, 
				ChallengeModifierType.OverrideFreeConcreteAmount => intParameter, 
				ChallengeModifierType.ChangeDemandOfGroupIndex => intParameter, 
				ChallengeModifierType.AllDestinationsOfGroupStartUpgraded => intParameter, 
				ChallengeModifierType.StraightRoadCostMultiplier => intParameter, 
				ChallengeModifierType.DiagonalRoadCostMultiplier => intParameter, 
				ChallengeModifierType.UpgradeRoadCostMultiplier => intParameter, 
				ChallengeModifierType.SharpTurnSpeedMultiplier => (float)fix64Parameter, 
				_ => -1f, 
			};
		}

		public bool IsCompatibleWithMap(MapDefinition city)
		{
			if (type == ChallengeModifierType.ForceWeeklyUpgrade)
			{
				return CityHasUpgradeType(city);
			}
			return true;
		}

		private bool CityHasUpgradeType(MapDefinition city)
		{
			return city.HasUpgradeType(upgradeType);
		}

		public bool IsCompatibleWith(ChallengeModifier otherModifier)
		{
			switch (type)
			{
			case ChallengeModifierType.StartWithUpgrade:
				if (OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.StartWithUpgrade))
				{
					return OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.UnlimitedUpgrade);
				}
				return false;
			case ChallengeModifierType.ForceWeeklyUpgrade:
				if (OtherModifierAllowsWeeklyUpgradeChoices(otherModifier) && otherModifier.type != ChallengeModifierType.PreventWeeklyUpgrade && otherModifier.type != ChallengeModifierType.OverrideGameModeWithExpert && OtherModifierTypeIsDifferentOrUpgradeTypeIsSame(otherModifier, ChallengeModifierType.AwardedUpgradeAmountMultiplier) && otherModifier.type != ChallengeModifierType.MysteryUpgrades && otherModifier.type != ChallengeModifierType.UnlimitedUpgrade && OtherModifierTypeIsDifferentOrUpgradeTypeIsSame(otherModifier, ChallengeModifierType.UpgradeRoadCostMultiplier))
				{
					return OtherModifierTypeIsDifferentOrUpgradeTypeIsSame(otherModifier, ChallengeModifierType.ChangeUpgradeLaneSpeed);
				}
				return false;
			case ChallengeModifierType.PreventWeeklyUpgrade:
				if (OtherModifierAllowsWeeklyUpgrades(otherModifier) && otherModifier.type != ChallengeModifierType.ForceWeeklyUpgrade && otherModifier.type != ChallengeModifierType.PreventWeeklyUpgrade && otherModifier.type != ChallengeModifierType.OverrideGameModeWithExpert && OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.AwardedUpgradeAmountMultiplier) && OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.ChangeUpgradeLaneSpeed) && OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.UpgradeRoadCostMultiplier))
				{
					return otherModifier.type != ChallengeModifierType.UnlimitedUpgrade;
				}
				return false;
			case ChallengeModifierType.AwardedUpgradeAmountMultiplier:
				if (OtherModifierTypeIsDifferentOrUpgradeTypeIsSame(otherModifier, ChallengeModifierType.ForceWeeklyUpgrade) && OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.PreventWeeklyUpgrade) && OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.AwardedUpgradeAmountMultiplier) && OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.UnlimitedUpgrade))
				{
					return OtherModifierAllowsWeeklyUpgrades(otherModifier);
				}
				return false;
			case ChallengeModifierType.SetUpgradeChoiceCount:
				if (otherModifier.type != ChallengeModifierType.SetUpgradeChoiceCount && otherModifier.type != ChallengeModifierType.ForceWeeklyUpgrade && otherModifier.type != ChallengeModifierType.OverrideGameModeWithExpert)
				{
					if (intParameter != 0 || otherModifier.type == ChallengeModifierType.ChangeUpgradeLaneSpeed || otherModifier.type == ChallengeModifierType.UpgradeRoadCostMultiplier || otherModifier.type == ChallengeModifierType.AwardedUpgradeAmountMultiplier || otherModifier.type == ChallengeModifierType.PreventWeeklyUpgrade || otherModifier.type == ChallengeModifierType.MysteryUpgrades)
					{
						if (intParameter == 1)
						{
							return otherModifier.type != ChallengeModifierType.MysteryUpgrades;
						}
						return false;
					}
					return true;
				}
				return false;
			case ChallengeModifierType.UnlimitedUpgrade:
				if (OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.StartWithUpgrade) && OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.AwardedUpgradeAmountMultiplier) && otherModifier.type != ChallengeModifierType.ForceWeeklyUpgrade && otherModifier.type != ChallengeModifierType.OverrideGameModeWithExpert && otherModifier.type != ChallengeModifierType.UnlimitedUpgrade && otherModifier.type != ChallengeModifierType.PreventWeeklyUpgrade && (otherModifier.type != ChallengeModifierType.UpgradeRoadCostMultiplier || upgradeType != UpgradeType.Concrete) && (otherModifier.type != ChallengeModifierType.StraightRoadCostMultiplier || upgradeType != UpgradeType.Concrete))
				{
					if (otherModifier.type == ChallengeModifierType.DiagonalRoadCostMultiplier)
					{
						return upgradeType != UpgradeType.Concrete;
					}
					return true;
				}
				return false;
			case ChallengeModifierType.OverrideFreeConcreteAmount:
				return otherModifier.type != type;
			case ChallengeModifierType.DestinationsIgnoreTileWeights:
				return otherModifier.type != type;
			case ChallengeModifierType.ChangeDemandOfGroupIndex:
				if (otherModifier.type == type)
				{
					return otherModifier.intParameter != intParameter;
				}
				return true;
			case ChallengeModifierType.DestinationUpgradesIgnoreWeights:
				if (otherModifier.type != type)
				{
					return otherModifier.type != ChallengeModifierType.DestinationsNeverUpgrade;
				}
				return false;
			case ChallengeModifierType.DestinationsNeverUpgrade:
				if (otherModifier.type != type && otherModifier.type != ChallengeModifierType.AllDestinationsStartUpgraded && otherModifier.type != ChallengeModifierType.DestinationUpgradesIgnoreWeights)
				{
					return otherModifier.type != ChallengeModifierType.AllDestinationsOfGroupStartUpgraded;
				}
				return false;
			case ChallengeModifierType.AllDestinationsStartUpgraded:
				if (otherModifier.type != type && otherModifier.type != ChallengeModifierType.DestinationsNeverUpgrade)
				{
					return otherModifier.type != ChallengeModifierType.AllDestinationsOfGroupStartUpgraded;
				}
				return false;
			case ChallengeModifierType.AllDestinationsOfGroupStartUpgraded:
				if ((otherModifier.type != type || otherModifier.intParameter != intParameter) && otherModifier.type != ChallengeModifierType.DestinationsNeverUpgrade)
				{
					return otherModifier.type != ChallengeModifierType.AllDestinationsStartUpgraded;
				}
				return false;
			case ChallengeModifierType.MysteryUpgrades:
				if (otherModifier.type != type)
				{
					return OtherModifierAllowsWeeklyUpgradeChoices(otherModifier);
				}
				return false;
			case ChallengeModifierType.ChangeUpgradeLaneSpeed:
				if (otherModifier.type != type && OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.PreventWeeklyUpgrade) && OtherModifierTypeIsDifferentOrUpgradeTypeIsSame(otherModifier, ChallengeModifierType.ForceWeeklyUpgrade))
				{
					return OtherModifierAllowsWeeklyUpgrades(otherModifier);
				}
				return false;
			case ChallengeModifierType.StraightRoadCostMultiplier:
			case ChallengeModifierType.DiagonalRoadCostMultiplier:
				if (otherModifier.type != type)
				{
					if (otherModifier.type == ChallengeModifierType.UnlimitedUpgrade)
					{
						return otherModifier.upgradeType != UpgradeType.Concrete;
					}
					return true;
				}
				return false;
			case ChallengeModifierType.UpgradeRoadCostMultiplier:
				if (otherModifier.type != type && OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(otherModifier, ChallengeModifierType.PreventWeeklyUpgrade) && OtherModifierTypeIsDifferentOrUpgradeTypeIsSame(otherModifier, ChallengeModifierType.ForceWeeklyUpgrade) && (otherModifier.type != ChallengeModifierType.UnlimitedUpgrade || otherModifier.upgradeType != UpgradeType.Concrete))
				{
					return OtherModifierAllowsWeeklyUpgrades(otherModifier);
				}
				return false;
			case ChallengeModifierType.HousesIgnoreTileWeights:
			case ChallengeModifierType.ForceDoubleDestinations:
			case ChallengeModifierType.NoDestinationDeadzoneForDestinations:
			case ChallengeModifierType.NoDestinationDeadzoneForHouses:
			case ChallengeModifierType.BuildingsIgnoreOtherBuildings:
			case ChallengeModifierType.IndestructibleTrees:
			case ChallengeModifierType.BonusTrees:
			case ChallengeModifierType.SharpTurnSpeedMultiplier:
				return otherModifier.type != type;
			default:
				return true;
			}
		}

		private bool OtherModifierTypeIsDifferentOrUpgradeTypeIsDifferent(ChallengeModifier otherModifier, ChallengeModifierType bannedType)
		{
			if (otherModifier.type == bannedType)
			{
				return upgradeType != otherModifier.upgradeType;
			}
			return true;
		}

		private bool OtherModifierTypeIsDifferentOrUpgradeTypeIsSame(ChallengeModifier otherModifier, ChallengeModifierType bannedType)
		{
			if (otherModifier.type == bannedType)
			{
				return upgradeType == otherModifier.upgradeType;
			}
			return true;
		}

		private bool OtherModifierAllowsWeeklyUpgrades(ChallengeModifier otherModifier)
		{
			if (otherModifier.type == ChallengeModifierType.SetUpgradeChoiceCount)
			{
				return otherModifier.intParameter != 0;
			}
			return true;
		}

		private bool OtherModifierAllowsWeeklyUpgradeChoices(ChallengeModifier otherModifier)
		{
			if ((otherModifier.type != ChallengeModifierType.SetUpgradeChoiceCount || otherModifier.intParameter > 1) && otherModifier.type != ChallengeModifierType.ForceWeeklyUpgrade)
			{
				return otherModifier.type != ChallengeModifierType.OverrideGameModeWithExpert;
			}
			return false;
		}

		public bool UsesUpgradeType()
		{
			switch (type)
			{
			case ChallengeModifierType.OverrideFreeConcreteAmount:
				upgradeType = UpgradeType.Concrete;
				return true;
			case ChallengeModifierType.StartWithUpgrade:
			case ChallengeModifierType.PreventWeeklyUpgrade:
			case ChallengeModifierType.ForceWeeklyUpgrade:
			case ChallengeModifierType.AwardedUpgradeAmountMultiplier:
			case ChallengeModifierType.UnlimitedUpgrade:
			case ChallengeModifierType.UpgradeRoadCostMultiplier:
				return true;
			default:
				return false;
			}
		}
	}
}
