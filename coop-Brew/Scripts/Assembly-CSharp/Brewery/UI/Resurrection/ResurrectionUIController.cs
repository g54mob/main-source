using System.Collections.Generic;
using Brewery.NPC.Resurrection;
using Synty.AnimationBaseLocomotion.Samples;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.UI.Resurrection
{
	[RequireComponent(typeof(UIDocument))]
	public class ResurrectionUIController : MonoBehaviour, IUIPanel
	{
		[Header("UI Document")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement rootElement;

		private VisualElement panel;

		private Button closeButton;

		private Label moneyCostLabel;

		private Label wineCostLabel;

		private Label deadCountLabel;

		private ScrollView npcListScroll;

		private VisualElement npcList;

		private Label noDeadLabel;

		private Label totalMoneyLabel;

		private Label totalWineLabel;

		private Button resurrectAllButton;

		private bool isUIVisible;

		private bool isInitialized;

		private SampleCameraController cameraController;

		private readonly List<VisualElement> npcItemElements;

		private bool subscribedToEvents;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public static ResurrectionUIController Instance { get; private set; }

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

		private void InitializeUI()
		{
		}

		public void ShowUI()
		{
		}

		public void HideUI()
		{
		}

		private void PopulateDeadNPCList()
		{
		}

		private VisualElement CreateDeadNPCItem(DeadNPCEntry entry, ResurrectionConfig config, int queueIndex)
		{
			return null;
		}

		private void ShowNoDeadState(bool show)
		{
		}

		private void UpdateCostDisplay()
		{
		}

		private bool CanAffordSingle()
		{
			return false;
		}

		private int GetMaxAffordableCount(int deadCount)
		{
			return 0;
		}

		private void OnResurrectSingleClicked(string npcId)
		{
		}

		private void OnResurrectAllClicked()
		{
		}

		private void SubscribeToEvents()
		{
		}

		private void UnsubscribeFromEvents()
		{
		}

		private void OnDeadNPCListChanged()
		{
		}

		private void FindCameraController()
		{
		}
	}
}
