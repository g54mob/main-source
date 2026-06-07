using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player.Tech;
using Assets.Source.Util;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Source.Player
{
	public class TechNode
	{
		public delegate void OnTechNodeUnlock(GamePlayer player);

		public static TechNode IndenturedServitude;

		public static TechNode IndenturedServitude2;

		public static TechNode IndenturedServitude3;

		public static TechNode LogisticHub0;

		public static TechNode LogisticHub1;

		public static TechNode LogisticHub2;

		public const float GlobalCostMultiplier = 40f;

		private static Dictionary<string, TechNode> _allTech;

		private static List<TechNode> _orderedTech;

		private static int _currentOrdinal;

		private static TechNode[][] _tierUpgrades;

		public readonly string Identifier;

		public readonly int Ordinal;

		public string Name;

		public string StaticDescription;

		public bool DynamicDescription;

		public string GenerateIconType;

		public string IconName;

		public Vector2Int AbsolutePosition;

		public Vector2Int RelativePosition;

		public int Tier = 1;

		public bool Hidden;

		public bool RequiresGlitchedFrame;

		public TechNodeType NodeType;

		public TechConnectionType ConnectionType;

		public List<ItemType> CostItems;

		public double CostMultiplier = 1.0;

		public TechNode Previous;

		public OnTechNodeUnlock OnUnlock;

		public string UpgradedFrame;

		public int UpgradedTier;

		public FrameUpgradeType UpgradeType;

		public double UpgradeMultiplier = 1.0;

		public double LowerTierMultiplier = 1.0;

		public int UpgradeFlag;

		private Sprite _generatedIcon;

		public static int Count => _currentOrdinal;

		public static IEnumerable<TechNode> Nodes => _orderedTech;

		public string Description => _getDynamicDescription();

		public Vector2Int Position
		{
			get
			{
				if (!(RelativePosition == Vector2Int.zero))
				{
					return Previous.Position + RelativePosition;
				}
				return AbsolutePosition;
			}
		}

		public Dictionary<ItemType, BigInteger> Cost { private get; set; }

		public bool IsAvailable
		{
			get
			{
				if (GamePlayer.Current.TechTier >= Tier)
				{
					if (Previous != null)
					{
						return GamePlayer.Current.HasTech(Previous);
					}
					return true;
				}
				return false;
			}
		}

		public bool IsPurchased => GamePlayer.Current.HasTech(this);

		public Sprite Icon
		{
			get
			{
				if (GenerateIconType == null)
				{
					return SpriteLibrary.Get(IconName);
				}
				return _getGeneratedIcon();
			}
		}

		static TechNode()
		{
			_allTech = new Dictionary<string, TechNode>();
			_orderedTech = new List<TechNode>();
			_tierUpgrades = new TechNode[13][];
			new Tier1();
			new Tier2();
			new Tier3();
			new Tier4();
			new Tier5();
			new Tier6();
			new Tier7();
			new Tier8();
			new Tier9();
			new Tier10();
			new Tier11();
			new Tier12();
			IndenturedServitude = "t6u_indentured_servitude";
			IndenturedServitude2 = "t6u_indentured_servitude_2";
			IndenturedServitude3 = "t6u_indentured_servitude_3";
			LogisticHub0 = "t3u_logistics_hub_0";
			LogisticHub1 = "t3u_logistics_hub_1";
			LogisticHub2 = "t3u_logistics_hub_2";
		}

		public TechNode(string id)
		{
			Identifier = id;
			Ordinal = _currentOrdinal++;
			Name = "@" + id + "_name";
			StaticDescription = "@" + id + "_desc";
		}

		public Dictionary<ItemType, BigInteger> GetCost()
		{
			if (Cost == null && CostItems != null)
			{
				Cost = GameMath.CreateItemCost(Identifier, Tier, CostMultiplier * (double)GetDefaultCostMultiplier() * 40.0, CostItems);
			}
			return Cost;
		}

		public void ResetCost()
		{
			Cost = null;
		}

		public float GetDefaultCostMultiplier()
		{
			return NodeType switch
			{
				TechNodeType.Frame => 1.5f, 
				TechNodeType.Upgrade => 1.5f, 
				TechNodeType.Tier => 29f * (1f + (float)GamePlayer.Current.Prestige * 0.5f), 
				TechNodeType.Manual => 4.5f, 
				TechNodeType.Utility => 1.8f, 
				TechNodeType.Placement => 3.8f, 
				TechNodeType.Ability => 1.5f, 
				_ => 1f, 
			};
		}

		private Sprite _getGeneratedIcon()
		{
			if (_generatedIcon == null)
			{
				_generatedIcon = UpgradeIconGenerator.CreateUpgradeIcon(Tier, GenerateIconType, SpriteLibrary.Get(IconName));
			}
			return _generatedIcon;
		}

		private string _getDynamicDescription()
		{
			string text = "";
			if (UpgradedFrame != null)
			{
				text = WorldManager.Instance.GetFramePrefabSet(UpgradedFrame).GetPreview().ItemHint?.DisplayNameLowercase ?? "";
			}
			string text2 = UpgradeType switch
			{
				FrameUpgradeType.Speed => "@TechDynamicDescriptionSpeed", 
				FrameUpgradeType.Productivity => "@TechDynamicDescriptionProd", 
				_ => "", 
			};
			return Translation.TranslateOnly(DynamicDescription ? "@TechDynamicDescription" : StaticDescription, text, text2, GameMath.FormatPercentage(UpgradeMultiplier - 1.0));
		}

		public static void Add(TechNode node)
		{
			_allTech[node.Identifier] = node;
			_orderedTech.Add(node);
			if (node.UpgradedFrame != null)
			{
				FrameUpgrade.Add(new FrameUpgrade(node.UpgradedFrame, node));
			}
		}

		public static TechNode Get(string id)
		{
			return _allTech[id];
		}

		public static TechNode Get(int ordinal)
		{
			return _orderedTech[ordinal];
		}

		public static TechNode[] GetTierUpgrades(int tier)
		{
			int num = tier - 1;
			if (_tierUpgrades[num] == null)
			{
				List<TechNode> list = new List<TechNode>();
				foreach (TechNode value in _allTech.Values)
				{
					if (value.UpgradedTier >= tier)
					{
						list.Add(value);
					}
				}
				_tierUpgrades[num] = list.ToArray();
			}
			return _tierUpgrades[num];
		}

		public static implicit operator string(TechNode node)
		{
			return node.Identifier;
		}

		public static implicit operator TechNode(string id)
		{
			return Get(id);
		}
	}
}
