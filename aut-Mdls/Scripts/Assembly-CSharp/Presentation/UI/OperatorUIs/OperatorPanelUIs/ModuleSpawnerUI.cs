using System.Collections.Generic;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.Shapes;
using Presentation.UI.Menus;
using Presentation.UI.OperatorUIs.OperatorPanelUIs.Spawner;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class ModuleSpawnerUI : FactoryPanelUIMenu
	{
		[Header("Spawner UI")]
		[SerializeField]
		private Transform _resourcesParent;

		[SerializeField]
		private ModuleSpawnerResourceButton _originalResourceButton;

		private ModuleSpawnerBehaviour _behaviour;

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as ModuleSpawnerBehaviour;
			InitResourceGrid();
		}

		private void InitResourceGrid()
		{
			IReadOnlyList<ShapeData> shapeDatas = _behaviour.ShapeDatas;
			for (int i = _resourcesParent.childCount - 1; i < shapeDatas.Count; i++)
			{
				Object.Instantiate(_originalResourceButton, _resourcesParent);
			}
			for (int j = 1; j < shapeDatas.Count + 1; j++)
			{
				ModuleSpawnerResourceButton component = _resourcesParent.GetChild(j).GetComponent<ModuleSpawnerResourceButton>();
				component.SetShapeData(shapeDatas[j - 1], j - 1);
				component.SetIsSelected(_behaviour.ChosenIndex == j - 1);
				component.gameObject.SetActive(value: true);
			}
			for (int num = _resourcesParent.childCount; num > shapeDatas.Count + 1; num--)
			{
				_resourcesParent.GetChild(num).gameObject.SetActive(value: false);
			}
		}

		public void SetIndex(int index)
		{
			_behaviour.SetChosenResourceIndex(index);
			for (int i = 1; i < _behaviour.ShapeDatas.Count + 1; i++)
			{
				_resourcesParent.GetChild(i).GetComponent<ModuleSpawnerResourceButton>().SetIsSelected(index == i - 1);
			}
			HideMenu();
		}
	}
}
