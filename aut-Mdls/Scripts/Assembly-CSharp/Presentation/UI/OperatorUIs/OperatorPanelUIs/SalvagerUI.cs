using System.Collections.Generic;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Presentation.UI.Menus;
using Presentation.UI.OperatorUIs.OperatorPanelUIs.Spawner;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class SalvagerUI : FactoryPanelUIMenu
	{
		[Header("Salvager UI")]
		[SerializeField]
		private Transform _resourcesParent;

		[SerializeField]
		private NonShapeResourceDataButton _originalResourceButton;

		private SalvagerBehaviour _behaviour;

		private readonly List<NonShapeResourceDataButton> _buttons = new List<NonShapeResourceDataButton>();

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as SalvagerBehaviour;
			InitResourceGrid();
		}

		private void InitResourceGrid()
		{
			if (_buttons.Count == 0)
			{
				_buttons.Add(_originalResourceButton);
				_originalResourceButton.Initalize(SetResourceData);
			}
			int i;
			for (i = 0; i < _behaviour.DataShards.Count; i++)
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
				SalvagerBehaviour.NonShapeResourcePair nonShapeResourcePair = _behaviour.DataShards[i];
				if (nonShapeResourcePair.ShowInUI != null && !nonShapeResourcePair.ShowInUI.Value)
				{
					_buttons[i].gameObject.SetActive(value: false);
					continue;
				}
				nonShapeResourceDataButton.SetResourceData(nonShapeResourcePair.Data);
				nonShapeResourceDataButton.SetIsSelected(_behaviour.ChosenResourceData.Data.ID == nonShapeResourcePair.Data.ID);
				nonShapeResourceDataButton.gameObject.SetActive(value: true);
			}
			for (; i > _buttons.Count; i++)
			{
				_buttons[i].gameObject.SetActive(value: false);
			}
		}

		public void SetResourceData(ResourceDataSO resourceData)
		{
			for (int i = 0; i < _buttons.Count; i++)
			{
				bool flag = resourceData.ID == _behaviour.DataShards[i].Data.ID;
				_buttons[i].SetIsSelected(flag);
				if (flag)
				{
					_behaviour.SetChosenResourceIndex(i);
				}
			}
			HideMenu();
		}
	}
}
