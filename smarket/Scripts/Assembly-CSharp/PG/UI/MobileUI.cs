using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PG.UI
{
	public class MobileUI : MonoBehaviour
	{
		public CarControllerInput UserInput;

		public PlayerController PlayerController;

		public TextMeshProUGUI CurrentControlText;

		public List<BaseControls> AllControls;

		[Header("Buttons")]
		public Button NextGearBtn;

		public Button PrevGearBtn;

		public Button SwitchLightsBtn;

		public Button SwitchLeftTurnSignalBtn;

		public Button SwitchRightTurnSignalBtn;

		public Button SwitchAlarmBtn;

		public Button ConnectTrailerBtn;

		public Button ResetCarBtn;

		public Button ChangeViewBtn;

		public Button RestoreCarBtn;

		public Button RestartSceneBtn;

		public Button SetNextCarBtn;

		public Button ExitFromCar;

		private int SelectedIndex;

		public Button SelectNextControl;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnSelectNextControl()
		{
		}

		private void SelectControl(int index)
		{
		}
	}
}
