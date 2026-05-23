using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.MenuData;
using TMPro;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class FurnaceUI : FactoryPanelUIMenu
	{
		[Header("FurnaceUI UI")]
		[SerializeField]
		private TextMeshProUGUI _polyrockAmountText;

		[SerializeField]
		private TextMeshProUGUI _polyrockTotalText;

		[SerializeField]
		private Transform _progressBar;

		[SerializeField]
		private PolyRockResourceDataSO _polyRockResourceData;

		private Vector3 _progressBarScale = Vector3.one;

		private FurnaceBehaviour _furnaceBehaviour;

		private int _currentVoxelAmount = -1;

		private int _maxVoxelAmount;

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.ShowMenu(menuData);
			_furnaceBehaviour = _factoryObjectBehaviour as FurnaceBehaviour;
			BuildUI();
		}

		private void Update()
		{
			UpdateUI();
		}

		private void BuildUI()
		{
			_maxVoxelAmount = _furnaceBehaviour.VoxelCountNeeded;
			_polyrockTotalText.SetText($"/{(_maxVoxelAmount / _polyRockResourceData.VoxelValue).ToString()}");
			UpdateUI();
		}

		private void UpdateUI()
		{
			if (_furnaceBehaviour.CurrentVoxelCount != _currentVoxelAmount)
			{
				_currentVoxelAmount = _furnaceBehaviour.CurrentVoxelCount;
				_progressBarScale.x = (float)_currentVoxelAmount / (float)_maxVoxelAmount;
				_progressBar.localScale = _progressBarScale;
				_polyrockAmountText.SetText(_furnaceBehaviour.CurrentPolyrockCount.ToString());
			}
		}
	}
}
