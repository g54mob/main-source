using System.Collections.Generic;
using Brewery.NPC.TradingSystem;
using UnityEngine;

namespace Brewery.Map
{
	public class LocationHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		[Header("Location Configuration")]
		[Tooltip("The locked trade that unlocks this location.")]
		[SerializeField]
		private LockedTrade requiredLockedTrade;

		[Tooltip("Display name for this location")]
		[SerializeField]
		private string locationName;

		[Tooltip("Description of what this location is for")]
		[TextArea(2, 4)]
		[SerializeField]
		private string locationDescription;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public LockedTrade RequiredLockedTrade => null;

		public string LocationName => null;

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

		private void AddOwnedStatusSection(List<HoverInfoSection> sections)
		{
		}

		private void AddLockedStatusSection(List<HoverInfoSection> sections)
		{
		}

		private void AddUnlockRequirementsSection(List<HoverInfoSection> sections)
		{
		}

		private void AddInfoSection(List<HoverInfoSection> sections)
		{
		}

		private static string L(string key, string fallback)
		{
			return null;
		}

		private bool IsPurchased()
		{
			return false;
		}

		public bool IsUnlocked()
		{
			return false;
		}
	}
}
