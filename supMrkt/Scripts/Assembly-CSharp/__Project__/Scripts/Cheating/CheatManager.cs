using System.Collections.Generic;
using MyBox;
using UnityEngine;
using UnityEngine.InputSystem;

namespace __Project__.Scripts.Cheating
{
	public class CheatManager : MonoBehaviour
	{
		[ReadOnly(new string[] { })]
		public bool IsBusy;

		public List<ProductSO> ProductSos;

		[SerializeField]
		private CheatCanvas m_CheatCanvas;

		[SerializeField]
		private GameObject m_Panel;

		private List<DisplaySlot> m_AllDisplaySlots;

		private List<ProductSO> m_TempSOs;

		private List<RackSlot> m_AllRackSlots;

		private MissionSystem m_MissionSystem;

		public void OnCheatManager(InputAction.CallbackContext ctx)
		{
		}

		private void Start()
		{
		}

		public void SwitchPanel(bool willOpen)
		{
		}

		public void SpawnProductOnEmptyShelf()
		{
		}

		public void ClearAllShelfs()
		{
		}

		public void SpawnBoxOnEmptyRack()
		{
		}

		public void AddMoney()
		{
		}

		public void SpeedTime()
		{
		}

		public void IncreaseCheckoutCount()
		{
		}

		public void MaxLevel()
		{
		}

		public void ChangeLevel(int targetLevel)
		{
		}

		public void PassOnboarding()
		{
		}

		public void RestartOnboarding()
		{
		}

		public void PassAllMissions()
		{
		}

		private void PassVeggiesPurchaseMission()
		{
		}

		private void PassVeggiesLicenceMission()
		{
		}

		private void PassShoplifterMission()
		{
		}

		private void PassBatMission()
		{
		}

		private void PassCrateEnableMission()
		{
		}

		private void PassCrateBuyMission()
		{
		}

		private void PassTabletOrderMission()
		{
		}

		private void PassTabletBuyMission()
		{
		}

		private void PassPaintMission()
		{
		}

		private void PassStoreNameMission()
		{
		}

		private void PassSectionMission()
		{
		}

		private void PassLicenceMission()
		{
		}

		private void PassShelfMission()
		{
		}

		private void PassCheckoutMission()
		{
		}

		private void PassCleaningMission()
		{
		}

		public void RestartAllMissions()
		{
		}

		private void RestartVeggiesPurchaseMission()
		{
		}

		private void RestartVeggiesLicenceMission()
		{
		}

		private void RestartShoplifterMission()
		{
		}

		private void RestartBatMission()
		{
		}

		private void RestartCrateEnableMission()
		{
		}

		private void RestartCrateBuyMission()
		{
		}

		private void RestartTabletOrderMission()
		{
		}

		private void RestartTabletBuyMission()
		{
		}

		private void RestartPaintMission()
		{
		}

		private void RestartStoreNameMission()
		{
		}

		private void RestartSectionMission()
		{
		}

		private void RestartLicenceMission()
		{
		}

		private void RestartShelfMission()
		{
		}

		private void RestartCheckoutMission()
		{
		}

		private void RestartCleaningMission()
		{
		}

		public void PassMissionById(MissionType missionType)
		{
		}

		public void RestartMissionById(MissionType missionType)
		{
		}

		public void WholeSaleOffer()
		{
		}

		public void SpawnShoplifter()
		{
		}

		public void SpawnGarbage()
		{
		}
	}
}
