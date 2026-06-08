using System;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Appliance", menuName = "Kitchen/Appliance")]
	public class Appliance : LocalisedGameDataObject<ApplianceInfo>, IHasPrefab, IEffectPropertySource, IUpgrade
	{
		[Serializable]
		public struct ApplianceProcesses
		{
			public Process Process;

			public bool IsAutomatic;

			public float Speed;

			public ProcessValidity Validity;
		}

		[Serializable]
		public struct Section
		{
			public string Title;

			[TextArea]
			public string Description;

			public string RangeDescription;
		}

		public GameObject Prefab;

		public GameObject HeldAppliancePrefab;

		public List<ApplianceProcesses> Processes;

		public List<IApplianceProperty> Properties;

		public IEffectRange EffectRange;

		public IEffectCondition EffectCondition;

		public IEffectType EffectType;

		public EffectRepresentation EffectRepresentation;

		public bool IsNonInteractive;

		public OccupancyLayer Layer;

		public bool ForceHighInteractionPriority;

		[HideInInspector]
		public int PurchaseCost = 1;

		public EntryAnimation EntryAnimation;

		public ExitAnimation ExitAnimation;

		public bool SkipRotationAnimation;

		[Header("Shop")]
		public bool IsPurchasable;

		public Season RestrictedToSeason;

		public bool IsPurchasableAsUpgrade;

		public DecorationType ThemeRequired;

		public ShoppingTags ShoppingTags;

		public RarityTier RarityTier;

		public PriceTier PriceTier = PriceTier.Medium;

		public ShopRequirementFilter ShopRequirementFilter;

		public List<Appliance> RequiresForShop = new List<Appliance>();

		public List<Process> RequiresProcessForShop = new List<Process>();

		public List<Item> RequiresIngredientForShop = new List<Item>();

		public List<MenuPhase> RequiresPhaseForShop = new List<MenuPhase>();

		public bool StapleWhenMissing;

		public bool SellOnlyAsDuplicate;

		public bool SellOnlyAsUnique;

		public bool PreventSale;

		[Header("Upgrading")]
		public List<Appliance> Upgrades = new List<Appliance>();

		public List<Appliance> Enchantments = new List<Appliance>();

		public bool IsAnUpgrade;

		public bool IsNonCrated;

		public Item CrateItem;

		[NonSerialized]
		[HideInInspector]
		public string Name = "Appliance";

		[NonSerialized]
		[HideInInspector]
		public string Description = "A little something for your restaurant";

		[NonSerialized]
		[HideInInspector]
		public List<Section> Sections;

		[NonSerialized]
		[HideInInspector]
		public List<string> Tags;

		GameObject IHasPrefab.Prefab => Prefab;

		int IUpgrade.MaximumUpgradeCount => 0;

		string IUpgrade.UpgradeName => Name;

		string IUpgrade.UpgradeDescription => Description;

		int IUpgrade.ID => ID;

		IEffectRange IEffectPropertySource.EffectRange => EffectRange;

		IEffectCondition IEffectPropertySource.EffectCondition => EffectCondition;

		IEffectType IEffectPropertySource.EffectType => EffectType;

		EffectRepresentation IEffectPropertySource.EffectInformation => EffectRepresentation;

		public bool HasUpgrades => Upgrades.Count > 0;

		public bool HasEnchantments => Enchantments.Count > 0;

		protected override void InitialiseDefaults()
		{
			Info = new LocalisationObject<ApplianceInfo>();
			Processes = new List<ApplianceProcesses>();
			Properties = new List<IApplianceProperty>();
			Sections = new List<Section>();
			Tags = new List<string>();
			RequiresForShop = new List<Appliance>();
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			Sections = new List<Section>();
			Tags = new List<string>();
			if (Info == null)
			{
				return false;
			}
			ApplianceInfo applianceInfo = Info.Get(locale);
			if (applianceInfo == null)
			{
				return false;
			}
			Name = subs.Parse(applianceInfo.Name);
			Description = subs.Parse(applianceInfo.Description);
			foreach (Section section in applianceInfo.Sections)
			{
				Sections.Add(new Section
				{
					Title = subs.Parse(section.Title),
					Description = subs.Parse(section.Description),
					RangeDescription = subs.Parse(section.RangeDescription)
				});
			}
			foreach (string tag in applianceInfo.Tags)
			{
				Tags.Add(subs.Parse(tag));
			}
			return true;
		}

		public static int GetPrice(PriceTier tier)
		{
			return tier switch
			{
				PriceTier.Free => 0, 
				PriceTier.VeryCheap => 5, 
				PriceTier.Cheap => 20, 
				PriceTier.MediumCheap => 40, 
				PriceTier.Medium => 60, 
				PriceTier.Expensive => 120, 
				PriceTier.VeryExpensive => 250, 
				PriceTier.ExtremelyExpensive => 1250, 
				PriceTier.DecoCheap => 30, 
				PriceTier.DecoMediumCheap => 40, 
				PriceTier.DecoMedium => 60, 
				PriceTier.DecoExpensive => 100, 
				_ => 0, 
			};
		}

		public override void SetupForGame()
		{
			base.SetupForGame();
			PurchaseCost = GetPrice(PriceTier);
			IsAnUpgrade = false;
		}

		public override void SetupFinal()
		{
			if (Upgrades.IsNullOrEmpty())
			{
				return;
			}
			foreach (Appliance upgrade in Upgrades)
			{
				upgrade.IsAnUpgrade = true;
			}
		}

		public bool GetProperty<T>(out T result)
		{
			result = default(T);
			if (Properties == null)
			{
				return false;
			}
			foreach (IApplianceProperty property in Properties)
			{
				if (property is T val)
				{
					result = val;
					return true;
				}
			}
			return false;
		}
	}
}
