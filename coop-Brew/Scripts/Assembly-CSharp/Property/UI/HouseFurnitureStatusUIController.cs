using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Property.UI
{
	public class HouseFurnitureStatusUIController : MonoBehaviour
	{
		[Header("UI Setup")]
		[SerializeField]
		private UIDocument uiDocument;

		[SerializeField]
		private VisualTreeAsset furnitureItemTemplate;

		[Header("Animation")]
		[SerializeField]
		private float slideDistance;

		[SerializeField]
		private float animationDuration;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement root;

		private VisualElement panel;

		private Label houseNameLabel;

		private Label ownershipLabel;

		private Label progressCountLabel;

		private VisualElement progressBarFill;

		private Label currentValueLabel;

		private Label potentialValueLabel;

		private VisualElement furnitureList;

		private Label hintLabel;

		private bool isVisible;

		private string currentHouseId;

		private PlotForSaleSignInteractable currentHouseSign;

		private PlotBuildingController currentBuildController;

		public static HouseFurnitureStatusUIController Instance { get; private set; }

		public bool IsVisible => false;

		public string CurrentHouseId => null;

		private static string GetFurnitureDisplayName(FurnitureType type)
		{
			return null;
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitializeUI()
		{
		}

		public void ShowForHouse(PlotForSaleSignInteractable houseSign)
		{
		}

		public void Hide()
		{
		}

		public void RefreshUI()
		{
		}

		private void UpdateUI()
		{
		}

		private void UpdateConstructionUI()
		{
		}

		private void UpdateFurnitureList(List<(FurnitureType type, bool isValid, string reason)> statuses)
		{
		}

		private VisualElement CreateFurnitureItem(FurnitureType type, bool isValid, string statusText)
		{
			return null;
		}

		private bool IsLocalPlayerOwner()
		{
			return false;
		}
	}
}
