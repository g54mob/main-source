using System.Collections.Generic;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class PointerUI : FactoryPanelUIMenu
	{
		[SerializeField]
		private PointerUIButton _colourButtonPrefab;

		private PointerBehaviour _behaviour;

		private readonly List<PointerUIButton> _buttons = new List<PointerUIButton>();

		protected override void Initialized()
		{
			base.Initialized();
			_behaviour = _factoryObjectBehaviour as PointerBehaviour;
			_colourButtonPrefab.gameObject.SetActive(value: false);
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.ShowMenu(menuData);
			int i;
			for (i = 0; i < _behaviour.AllMaterials.Count; i++)
			{
				if (i >= _buttons.Count)
				{
					PointerUIButton item = Object.Instantiate(_colourButtonPrefab, _colourButtonPrefab.transform.parent);
					_buttons.Add(item);
				}
				_buttons[i].Register(HandleSelected, i, _behaviour.AllMaterials[i].UIButtonColour);
				_buttons[i].gameObject.SetActive(value: true);
			}
			for (; i < _buttons.Count; i++)
			{
				_buttons[i].gameObject.SetActive(value: false);
			}
		}

		private void HandleSelected(int colourIndex)
		{
			_behaviour.SelectColor(colourIndex);
		}

		public override void HideMenu()
		{
			for (int i = 0; i < _buttons.Count; i++)
			{
				_buttons[i].Unregister();
			}
			base.HideMenu();
		}
	}
}
