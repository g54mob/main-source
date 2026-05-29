using TMPro;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;
using __Project__.Scripts.UI;

namespace __Project__.Scripts.Cheating
{
	public class CheatCanvas : MonoBehaviour
	{
		private GamePadUIPanel m_GamepadUIPanel;

		private CheatManager m_CheatManager;

		private MissionType m_MissionType;

		[SerializeField]
		private TMP_InputField m_LevelInputField;

		[SerializeField]
		private CustomDropdown m_MissionTypeDropdown;

		public void SetMissionType()
		{
		}

		private void OnEnable()
		{
		}

		public void FillShelves()
		{
		}

		public void ClearAllShelves()
		{
		}

		public void AddMoney()
		{
		}

		public void SpeedUpTime()
		{
		}

		public void IncreaseCheckoutCount()
		{
		}

		public void MaxLevel()
		{
		}

		public void ChangeLevel()
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

		public void RestartAllMissions()
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

		public void PassMissionByType()
		{
		}

		public void RestartMissionByType()
		{
		}
	}
}
