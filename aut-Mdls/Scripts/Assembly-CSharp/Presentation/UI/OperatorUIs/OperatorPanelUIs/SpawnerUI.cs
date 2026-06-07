using System.Collections.Generic;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Presentation.UI.Menus;
using Presentation.UI.OperatorUIs.OperatorPanelUIs.Spawner;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class SpawnerUI : FactoryPanelUIMenu
	{
		[Header("Spawner UI")]
		[SerializeField]
		private Transform _resourcesParent;

		[SerializeField]
		private NonShapeResourceDataButton _originalResourceButton;

		private SpawnerBehaviour _behaviour;

		private readonly List<NonShapeResourceDataButton> _buttons = new List<NonShapeResourceDataButton>();

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as SpawnerBehaviour;
			InitResourceGrid();
		}

		private void InitResourceGrid()
		{
			if (_buttons.Count == 0)
			{
				_buttons.Add(_originalResourceButton);
				_originalResourceButton.Initalize(SetResourceData);
			}
			IReadOnlyList<ResourceDataSO> resourceDatas = _behaviour.GetResourceDatas();
			int i;
			for (i = 0; i < resourceDatas.Count; i++)
			{
				NonShapeResourceDataButton nonShapeResourceDataButton;
				if (i < _buttons.Count)
				{
					nonShapeResourceDataButton = _buttons[i];
				}
				else
				{
					nonShapeResourceDataButton = Object.Instantiate(_originalResourceButton, _resourcesParent);
					nonShapeResourceDataButton.Initalize(SetResourceData);
					_buttons.Add(nonShapeResourceDataButton);
				}
				nonShapeResourceDataButton.SetResourceData(resourceDatas[i] as NonShapeResourceDataSO);
				nonShapeResourceDataButton.SetIsSelected(_behaviour.ChosenResourceData.ID == resourceDatas[i].ID);
				nonShapeResourceDataButton.gameObject.SetActive(value: true);
			}
			for (; i > _buttons.Count; i++)
			{
				_buttons[i].gameObject.SetActive(value: false);
			}
		}

		public void SetResourceData(ResourceDataSO resourceData)
		{
			_behaviour.SetChosenResourceIndex(resourceData.ID);
			for (int i = 0; i < _buttons.Count; i++)
			{
				bool isSelected = _behaviour.ChosenResourceDataIndex == i;
				_buttons[i].SetIsSelected(isSelected);
			}
			HideMenu();
		}
	}
}
