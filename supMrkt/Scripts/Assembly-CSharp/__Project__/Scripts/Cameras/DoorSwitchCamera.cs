using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using __Project__.Scripts.Computer.Management.CustomizationTab;
using __Project__.Scripts.UI;

namespace __Project__.Scripts.Cameras
{
	public class DoorSwitchCamera : MonoBehaviour
	{
		[HideInInspector]
		public int currentIndex;

		[SerializeField]
		private CinemachineVirtualCamera m_NameCamera;

		[SerializeField]
		private DoorSwitchOverlay m_SelectionUI;

		[SerializeField]
		private ChangeNameOverlay m_ChangeNameUI;

		[SerializeField]
		private EntranceChangeOverlay m_EntranceChangeUI;

		private ComputerInteraction m_ComputerInteraction;

		private List<GameObject> m_FrontWalls;

		private GameObject m_DoorSection;

		[SerializeField]
		private Vector3 m_OffsetToTarget;

		private float m_Price;

		[SerializeField]
		private float m_StartZ;

		[SerializeField]
		private float m_DefaultZScale;

		private CustomizationType m_CurrentType;

		[SerializeField]
		private List<GameObject> m_ObjectsToHide;

		private bool m_IsClosing;

		private int m_cachedIndex;

		public bool IsAnythingChanged => false;

		public void Initialize(float price, CustomizationType type)
		{
		}

		private void SwitchUI(bool willOpen)
		{
		}

		public void CloseCamera()
		{
		}

		public void CalculatePosition(int doorIndex, bool isInitial)
		{
		}

		public void SwitchIndex(bool isLeft)
		{
		}

		public void SwitchIndex_Order(int index)
		{
		}

		public void Reset()
		{
		}

		private void Update()
		{
		}

		private void GetFrontSectionsFromSectionManager()
		{
		}

		public void GameStartLogic()
		{
		}
	}
}
