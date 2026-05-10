using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Vending_Machine.VendingPanelGamepad
{
	public class VendingTrackerPanelGamepadHandler : MonoBehaviour
	{
		[SerializeField]
		private Button m_SetWaypointButton;

		[SerializeField]
		private Button m_HighlightOnMapButton;

		[SerializeField]
		private VendingGamepadHandler m_VendingGamepadHandler;

		private GamePadUIPanel m_ParentPanel;

		private List<VendingTrackerProductGamepadHandler> m_TrackerObjects;

		public void Initialize(GamePadUIPanel parentPanel)
		{
		}

		private void SetNeighborhoods()
		{
		}

		public void Focus()
		{
		}

		public void OnBack()
		{
		}
	}
}
