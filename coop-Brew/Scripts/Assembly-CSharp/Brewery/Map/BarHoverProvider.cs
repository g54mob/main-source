using System.Collections.Generic;
using BarUpgrade;
using Brewery.Bar;
using Brewery.NPC.Simple;
using InventorySystem;
using UnityEngine;

namespace Brewery.Map
{
	public class BarHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		[Header("Components (Auto-discovered)")]
		private SimpleBarLocation barLocation;

		private BarUpgradeManager upgradeManager;

		private BarFactionAttractionManager factionManager;

		private BarInventoryManager inventoryManager;

		[Header("Display Settings")]
		[SerializeField]
		private int maxFactionsToShow;

		[SerializeField]
		private bool showInventory;

		[SerializeField]
		private bool showRevenue;

		[SerializeField]
		private bool showNavigation;

		[SerializeField]
		private bool showPerformance;

		[SerializeField]
		private bool showUpgradeInfo;

		[SerializeField]
		private float interactionRange;

		private bool componentsFound;

		private float lastRevenueCheck;

		private float previousRevenue;

		private float revenuePerHour;

		private void Awake()
		{
		}

		private void FindComponents()
		{
		}

		public string GetHoverTitle()
		{
			return null;
		}

		public string GetHoverSubtitle()
		{
			return null;
		}

		public List<HoverInfoSection> GetHoverSections()
		{
			return null;
		}

		public bool ShouldShowHover()
		{
			return false;
		}

		private void AddNavigationSection(List<HoverInfoSection> sections)
		{
		}

		private void AddOccupancySection(List<HoverInfoSection> sections)
		{
		}

		private void AddPerformanceSection(List<HoverInfoSection> sections)
		{
		}

		private void AddInventorySection(List<HoverInfoSection> sections)
		{
		}

		private void AddFactionSection(List<HoverInfoSection> sections)
		{
		}

		private void AddUpgradeSection(List<HoverInfoSection> sections)
		{
		}

		private void AddAlertsSection(List<HoverInfoSection> sections)
		{
		}

		private void AddInteractionHints(List<HoverInfoSection> sections)
		{
		}

		private void UpdateRevenuePerHour(float currentRevenue)
		{
		}

		private int EstimateUpgradeCost(int currentLevel)
		{
			return 0;
		}
	}
}
