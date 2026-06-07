using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;
using __Project__.Scripts.Multiplayer.NetworkComputer;
using __Project__.Scripts.UI;

namespace __Project__.Scripts.Computer
{
	public class Computer : MonoBehaviour, IInteractable
	{
		[SerializeField]
		private GameObject m_PCCam;

		[SerializeField]
		private Transform m_PlayerPosition;

		[SerializeField]
		private FurniturePlacingMode m_PlacingMode;

		[SerializeField]
		private DesktopCanvas m_DesktopCanvas;

		[SerializeField]
		private PricingProductViewer m_PricingProductViewer;

		[SerializeField]
		private GameObject m_ComputerScreen;

		private bool m_IsOpen;

		private TransformData m_TransformData;

		public Action onLeftComputer;

		public Action onComputerInteract;

		[SerializeField]
		private GamePadUIPanel m_rootGamepadPanel;

		public Button lastOpenedTabButton;

		private List<CustomDropdown> m_Dropdowns;

		private List<NumpadSystem> m_Numpads;

		private List<VirtualKeyboard> m_Keyboards;

		[SerializeField]
		private List<GamePadUIPanel> m_gamePadUIPanels;

		private MarketShoppingCart m_MarketShoppingCart;

		private NetworkComputer m_NetworkComputer;

		public bool IsInPlacingMode;

		public InteractactableType Type => default(InteractactableType);

		public bool ContinousInteraction => false;

		public bool OpenPC
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public NetworkComputer NetworkComputer => null;

		public bool IsOccupied { get; set; }

		public PlayerInstance OccupiedPlayer { get; set; }

		public string InstantInteractionHint => null;

		public string HoldingInteractionHint => null;

		public string SecondInteractionHint => null;

		public string RepairInteractionHint => null;

		public bool NeedRepair { get; set; }

		public InteractionType InteractionType => default(InteractionType);

		public MarketShoppingCart MarketShoppingCart => null;

		private void SetCursor(bool isGamepad)
		{
		}

		public bool RemoteInteract(string userId)
		{
			return false;
		}

		private void Awake()
		{
		}

		public void LoadSaveProgress()
		{
		}

		public void LoadSaveNetworkSlave()
		{
		}

		public void SwitchScreen(bool isOpen)
		{
		}

		public bool InstantInteract()
		{
			return false;
		}

		public bool HoldingInteract()
		{
			return false;
		}

		public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
		{
			return false;
		}

		public void Back()
		{
		}

		public void InteractComputer_Network(PlayerInstance interactedPlayer, bool willOpen)
		{
		}

		public void FindDropdowns()
		{
		}

		public void CloseDropdowns()
		{
		}

		private void FindVirtualKeyboards()
		{
		}

		private void CloseNumpads()
		{
		}

		private void CloseKeyboards()
		{
		}

		public void CloseUIPanels()
		{
		}

		public void GamepadBack()
		{
		}

		private void HighlightLastSelectedTab()
		{
		}

		public void StartPlacingMode()
		{
		}

		public void PlaceComputer()
		{
		}

		public bool CustomInteract()
		{
			return false;
		}

		public void StartPlacingModeOrder(string userId)
		{
		}

		public void SwitchVending(bool willEnable)
		{
		}
	}
}
