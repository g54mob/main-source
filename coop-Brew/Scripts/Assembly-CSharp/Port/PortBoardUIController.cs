using System;
using System.Collections.Generic;
using Brewery.Core;
using Brewery.Data;
using Brewery.Items;
using InventorySystem;
using Synty.AnimationBaseLocomotion.Samples;
using UI.Core;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Port
{
	[RequireComponent(typeof(UIDocument))]
	public class PortBoardUIController : MonoBehaviour, IUIPanel
	{
		[Header("UI Document")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement overlayContainer;

		private VisualElement panelRoot;

		private Button closeButton;

		private Label repLabel;

		private Label tierLabel;

		private VisualElement repProgressFill;

		private Label repProgressLabel;

		private VisualElement docksContainer;

		private VisualElement activeContractsList;

		private Label noActiveLabel;

		private Label materialsLabel;

		private VisualElement cheatSection;

		private bool isUIVisible;

		private InventoryManager playerInventory;

		private SampleCameraController cameraController;

		private Sprite _crateIconSprite;

		private bool _crateIconLookedUp;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public static PortBoardUIController Instance { get; private set; }

		public void Close()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void SetupUI()
		{
		}

		public void ShowUI()
		{
		}

		public void HideUI()
		{
		}

		private void RebuildUI()
		{
		}

		private void UpdateHeader()
		{
		}

		private void UpdateDocks()
		{
		}

		private VisualElement CreateContractRow(PortContract contract)
		{
			return null;
		}

		private void UpdateActiveContracts()
		{
		}

		private bool HasDeliveryProgress(PortContract c)
		{
			return false;
		}

		private float GetOverallProgress(PortContract c)
		{
			return 0f;
		}

		private string FormatContractProgress(PortContract c)
		{
			return null;
		}

		private string GetDepartureTimeText(DockedShipState ship, int currentDay)
		{
			return null;
		}

		private void UpdateFooter()
		{
		}

		private VisualElement BuildDrinkRequirementRow(PortContract contract)
		{
			return null;
		}

		private VisualElement BuildCatalystRequirementRow(string catalystId, int qty)
		{
			return null;
		}

		private Sprite GetCrateIconSprite()
		{
			return null;
		}

		private Sprite GetCatalystSprite(string catalystId)
		{
			return null;
		}

		private string FormatDrinkRequirement(PortContract contract)
		{
			return null;
		}

		private void RegisterDrinkHover(VisualElement target, PortContract contract)
		{
		}

		private void RegisterRewardHover(VisualElement target, Item rewardItem, int qty)
		{
		}

		private void RegisterCatalystHover(VisualElement target, string catalystId, int qty)
		{
		}

		private BeerDataSnapshot BuildBeverageSnapshotForContract(PortContract contract)
		{
			return default(BeerDataSnapshot);
		}

		private static void TryAddCatalyst(BreweryDatabase db, FixedString64Bytes id, List<CatalystData> dest)
		{
		}

		private Item GetDrinkItemForContract(PortContract contract)
		{
			return null;
		}

		private string FormatTags(BrewTag tags)
		{
			return null;
		}

		private string FormatCatalystName(string catalystId)
		{
			return null;
		}

		private string GetTierName(int tier)
		{
			return null;
		}

		private int GetTierForDock(int dockIndex)
		{
			return 0;
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnPortDataChanged()
		{
		}

		private void BuildCheatSection()
		{
		}

		private Button MakeCheatButton(string text, Action onClick)
		{
			return null;
		}

		private void UpdateCheatSection()
		{
		}

		private void FindPlayerInventory()
		{
		}

		private void FindCameraController()
		{
		}
	}
}
