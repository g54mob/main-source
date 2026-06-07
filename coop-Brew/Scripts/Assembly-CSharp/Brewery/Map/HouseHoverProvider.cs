using System.Collections.Generic;
using Property;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Map
{
	public class HouseHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		public enum HouseState
		{
			Unknown = 0,
			ForSale = 1,
			UnderConstruction = 2,
			NeedsFurnishing = 3,
			ReadyForRent = 4,
			Rented = 5,
			RentReady = 6
		}

		[Header("Icon Definitions")]
		[Tooltip("Icon to show when house is for sale (not purchased) - ICON A")]
		[SerializeField]
		private MapIconDefinition forSaleIcon;

		[Tooltip("Icon to show when house is under construction - ICON B")]
		[SerializeField]
		private MapIconDefinition constructionIcon;

		[Tooltip("Icon to show when house needs furnishing - ICON C")]
		[SerializeField]
		private MapIconDefinition furnishingIcon;

		[Tooltip("Icon to show when house is ready to rent to NPC (fully built & furnished) - ICON D")]
		[SerializeField]
		private MapIconDefinition readyToRentIcon;

		[Tooltip("Icon to show when house has rent available to collect - ICON E (pulsing)")]
		[SerializeField]
		private MapIconDefinition rentReadyIcon;

		[Header("Display Settings")]
		[SerializeField]
		private bool showLocationInfo;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private House house;

		private PlotForSaleSignInteractable forSaleSign;

		private PlotBuildingController buildController;

		private MapIconTarget mapIconTarget;

		private PropertyManager propertyManager;

		private HouseState lastState;

		private bool isSubscribedToNetworkList;

		private float initRetryTimer;

		private const float INIT_RETRY_INTERVAL = 0.5f;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void TryInitializePropertyManager()
		{
		}

		private void UnsubscribeFromPropertyManager()
		{
		}

		private void OnHouseOwnershipListChanged(NetworkListEvent<HouseOwnership> changeEvent)
		{
		}

		private void OnOwnershipChangedDetailed(string houseId, ulong newOwnerId)
		{
		}

		private void UpdateHouseState()
		{
		}

		private HouseState DetermineHouseState()
		{
			return default(HouseState);
		}

		private void UpdateMapIcon(HouseState state)
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

		private void AddStatusSection(List<HoverInfoSection> sections)
		{
		}

		private void AddDetailsSection(List<HoverInfoSection> sections)
		{
		}

		public HouseState GetCurrentState()
		{
			return default(HouseState);
		}

		public void RefreshState()
		{
		}
	}
}
