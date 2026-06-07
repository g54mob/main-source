using System.Collections.Generic;
using Brewery.NPC.Simple;
using UnityEngine;

namespace Brewery.Map
{
	public class NPCHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		[Header("Components (Auto-discovered)")]
		private SimpleNPCController npcController;

		[Header("Display Settings")]
		[SerializeField]
		private bool showLocationInfo;

		[SerializeField]
		private bool showActivityInfo;

		[SerializeField]
		private bool showStatusInfo;

		[SerializeField]
		private float interactionRange;

		private bool componentsFound;

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

		private void AddLocationSection(List<HoverInfoSection> sections)
		{
		}

		private void AddActivitySection(List<HoverInfoSection> sections)
		{
		}

		private void AddStatusSection(List<HoverInfoSection> sections)
		{
		}

		private void AddActionHints(List<HoverInfoSection> sections)
		{
		}

		private string GetStatusBadge()
		{
			return null;
		}

		private string GetLocationText()
		{
			return null;
		}

		private string GetActivityText()
		{
			return null;
		}

		private string GetDetailedActivityText()
		{
			return null;
		}

		private string GetDrinkingStatusText(SimpleNPCController.DrinkingStatus status)
		{
			return null;
		}

		private Color GetDrinkingStatusColor(SimpleNPCController.DrinkingStatus status)
		{
			return default(Color);
		}
	}
}
