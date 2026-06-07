using System.Collections.Generic;
using Brewery.NPC.Data;
using InteractionSystem;
using InventorySystem;
using UnityEngine;

namespace Brewery.Map
{
	public class ShopHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		public enum ShopType
		{
			General = 0,
			LegalCatalysts = 1,
			IllegalItems = 2,
			Stations = 3,
			Brewery = 4,
			Equipment = 5
		}

		[Header("Shop Settings")]
		[SerializeField]
		private string shopName;

		[SerializeField]
		private ShopType shopType;

		[Header("Clerk Schedule")]
		[Tooltip("Work location ID to find the clerk's NPCProfile (e.g., 'Market1'). Leave empty to use default 9am-9pm.")]
		[SerializeField]
		private string workLocationId;

		[Header("Components (Auto-discovered)")]
		private InventoryManager inventoryManager;

		private IInteractable interactable;

		[Header("Display Settings")]
		[Tooltip("Show detailed inventory breakdown")]
		[SerializeField]
		private bool showInventoryDetails;

		[Tooltip("Show navigation/distance info")]
		[SerializeField]
		private bool showNavigation;

		[Tooltip("Show shop hours")]
		[SerializeField]
		private bool showHours;

		[Tooltip("Maximum featured items to show")]
		[SerializeField]
		private int maxFeaturedItems;

		[Tooltip("Interaction range for hints")]
		[SerializeField]
		private float interactionRange;

		private bool componentsFound;

		private NPCProfile cachedClerkProfile;

		private bool clerkProfileSearched;

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

		private void AddStatusSection(List<HoverInfoSection> sections)
		{
		}

		private void AddInventorySection(List<HoverInfoSection> sections)
		{
		}

		private void AddFeaturedItemsSection(List<HoverInfoSection> sections)
		{
		}

		private void AddInteractionHints(List<HoverInfoSection> sections)
		{
		}

		private string GetShopTypeDescription()
		{
			return null;
		}

		private bool IsShopOpen()
		{
			return false;
		}

		private int GetTotalItemCount()
		{
			return 0;
		}

		private int GetUniqueItemCount()
		{
			return 0;
		}

		private List<(string, int)> GetFeaturedItems(int max)
		{
			return null;
		}

		public void SetShopName(string name)
		{
		}

		public void SetShopType(ShopType type)
		{
		}

		private int GetOpeningHour()
		{
			return 0;
		}

		private int GetClosingHour()
		{
			return 0;
		}

		private NPCProfile FindClerkProfile()
		{
			return null;
		}
	}
}
