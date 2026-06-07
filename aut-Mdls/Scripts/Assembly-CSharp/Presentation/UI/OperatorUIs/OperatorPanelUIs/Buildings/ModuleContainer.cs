using Logic.Factory;
using Presentation.FactoryFloor.Toolbar;
using TMPro;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.Buildings
{
	public class ModuleContainer : MonoBehaviour
	{
		[SerializeField]
		private ModuleButton _moduleButton;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		[SerializeField]
		private TextMeshProUGUI _totalText;

		[SerializeField]
		private TextMeshProUGUI _speedPerMinText;

		[SerializeField]
		private Transform _craneIconParent;

		[SerializeField]
		[LocaKey]
		private string _perMinLocaKey;

		public void Build(Texture2D moduleTexture, ModuleViewerData moduleViewerData, int index = 0)
		{
			_moduleButton.SetModuleIcon(moduleTexture, moduleViewerData, index);
		}

		public void Build(Sprite moduleSprite, int index = 0)
		{
			_moduleButton.SetModuleIcon(moduleSprite, index);
		}

		public void UpdateAmounts(int amount, int total, int smallestAmountOfResources, int smallestMultiplier)
		{
			int cranes = total * smallestMultiplier / smallestAmountOfResources;
			EnableCraneIcons(cranes);
			string text = ((amount == 0) ? $"<color=red>{amount}</color>" : amount.ToString());
			_amountText.SetText(text);
			_totalText.SetText($"/{total}");
		}

		public void UpdateAmounts(int amount, int total)
		{
			DisableCraneIcons();
			string text = ((amount == 0) ? $"<color=red>{amount}</color>" : amount.ToString());
			_amountText.SetText(text);
			_totalText.SetText($"/{total}");
		}

		private void EnableCraneIcons(int cranes)
		{
			for (int i = 0; i < _craneIconParent.childCount; i++)
			{
				_craneIconParent.GetChild(i).gameObject.SetActive(i < cranes);
			}
		}

		private void DisableCraneIcons()
		{
			for (int i = 0; i < _craneIconParent.childCount; i++)
			{
				_craneIconParent.GetChild(i).gameObject.SetActive(value: false);
			}
		}

		public void ShowSpeedPerMin(int moduleCount, int processTicksToSupplyAllModules)
		{
			int num = Mathf.RoundToInt((float)FactoryUpdater.Instance.GetUnscaledStepsPerSecond() * 60f / (float)processTicksToSupplyAllModules * (float)moduleCount);
			_speedPerMinText.SetText(string.Format(LocalizationUtility.GetLocalizedText(_perMinLocaKey), num));
			_speedPerMinText.gameObject.SetActive(value: true);
		}

		public void HideSpeedPerMin()
		{
			_speedPerMinText.gameObject.SetActive(value: false);
		}
	}
}
