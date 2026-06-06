using System.Collections.Generic;
using Brewery.NPC.Data;
using Brewery.NPC.Simple;
using UnityEngine;

namespace Brewery.Map
{
	public class VisitorHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		[Header("Components (Auto-discovered)")]
		private VisitorNPCInteraction visitorInteraction;

		private SimpleNPCController npcController;

		private MapIconTarget mapIconTarget;

		[Header("Display Settings")]
		[SerializeField]
		private bool showLocationInfo;

		[SerializeField]
		private float interactionRange;

		private bool componentsFound;

		private string cachedNpcId;

		private NPCProfile cachedProfile;

		private bool initializedAsVisitor;

		private bool isSubscribedToEvents;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void SubscribeToEvents()
		{
		}

		private void UnsubscribeFromEvents()
		{
		}

		private void OnHouseRentedToVisitor(string houseId, string npcId)
		{
		}

		private void FindComponents()
		{
		}

		private void UpdateMapIconVisibility()
		{
		}

		private bool IsCurrentlyVisitor()
		{
			return false;
		}

		public void Initialize(NPCProfile profile)
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

		public void RefreshVisibility()
		{
		}

		public bool ShouldShowHover()
		{
			return false;
		}

		private void AddLocationSection(List<HoverInfoSection> sections)
		{
		}

		private void AddStatusSection(List<HoverInfoSection> sections)
		{
		}

		private void AddActionHints(List<HoverInfoSection> sections)
		{
		}

		private NPCProfile GetProfile()
		{
			return null;
		}
	}
}
