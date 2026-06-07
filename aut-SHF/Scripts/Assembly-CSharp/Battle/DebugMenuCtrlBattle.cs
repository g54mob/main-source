using Libs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
	public class DebugMenuCtrlBattle : SingletonMonoBehaviour<DebugMenuCtrlBattle>
	{
		[SerializeField]
		private CanvasGroup contents;

		[SerializeField]
		private TextMeshProUGUI currentTimeText;

		[SerializeField]
		private TextMeshProUGUI skipTimeText;

		[SerializeField]
		private TextMeshProUGUI nextCheckPointText;

		[SerializeField]
		private Button skipButton;

		[SerializeField]
		private Transform unitParent;

		[SerializeField]
		private Text unitCounterText;

		[SerializeField]
		private TextMeshProUGUI expText;

		[SerializeField]
		private TextMeshProUGUI moneyText;

		[SerializeField]
		private TextMeshProUGUI miniascapeLevelText;

		[SerializeField]
		private TextMeshProUGUI levelText;

		[SerializeField]
		private TextMeshProUGUI levelIncreaseText;

		public bool IsAutoSallyMode { get; private set; }

		private void Awake()
		{
		}

		public void UpdateDebugMenu(bool enable)
		{
		}

		public void ToggleDebugMenu()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void ToggleAuto()
		{
		}

		public void AddMoney(int money)
		{
		}

		public void ChangeGameLevel(int value)
		{
		}

		public void ToggleSkipInteract(bool interactable)
		{
		}

		public void DebugWaveClear()
		{
		}

		public void UpdateCurrentTimeText()
		{
		}

		public void DebugSkipWave()
		{
		}

		public void UpdateUI()
		{
		}
	}
}
