using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;

namespace Assets.Source.World
{
	public class FrameUpgrade
	{
		public const float CostMultiplier = 20f;

		private static Dictionary<string, List<FrameUpgrade>> _upgradesByFrame = new Dictionary<string, List<FrameUpgrade>>();

		private static Dictionary<string, FrameUpgrade> _upgradesByTech = new Dictionary<string, FrameUpgrade>();

		public readonly string Frame;

		public TechNode RequiredTech;

		private Dictionary<ItemType, int> _calcCost;

		public int FrameOrdinal { get; private set; }

		public string Name => RequiredTech.Name;

		public string Description => RequiredTech.Description;

		public bool IsAvailable => GamePlayer.Current.HasTech(RequiredTech);

		public FrameUpgradeType UpgradeType => RequiredTech.UpgradeType;

		public float UpgradeMultiplier => RequiredTech.UpgradeMultiplier;

		public float UpgradeFlag => RequiredTech.UpgradeFlag;

		public FrameUpgrade(string frameId, TechNode requiredTech)
		{
			Frame = frameId;
			RequiredTech = requiredTech;
		}

		public IEnumerable<KeyValuePair<ItemType, int>> GetCost()
		{
			if (_calcCost == null)
			{
				_calcCost = GameMath.CreateItemCost("Upgrade" + RequiredTech.Identifier, WorldFrame.GetPreview(Frame).Tier, 20f, RequiredTech.CostItems);
			}
			return _calcCost;
		}

		public static void Add(FrameUpgrade upgrade)
		{
			_upgradesByTech.Add(upgrade.RequiredTech, upgrade);
			List<FrameUpgrade> value = null;
			if (!_upgradesByFrame.TryGetValue(upgrade.Frame, out value))
			{
				value = new List<FrameUpgrade>();
				_upgradesByFrame[upgrade.Frame] = value;
			}
			upgrade.FrameOrdinal = value.Count;
			value.Add(upgrade);
		}

		public static List<FrameUpgrade> GetUpgrades(string id)
		{
			if (_upgradesByFrame.TryGetValue(id, out var value))
			{
				return value;
			}
			return new List<FrameUpgrade>(0);
		}

		public static FrameUpgrade Get(string frameId, int ordinal)
		{
			return _upgradesByFrame[frameId][ordinal];
		}

		public static FrameUpgrade Get(TechNode tech)
		{
			return _upgradesByTech[tech.Identifier];
		}
	}
}
