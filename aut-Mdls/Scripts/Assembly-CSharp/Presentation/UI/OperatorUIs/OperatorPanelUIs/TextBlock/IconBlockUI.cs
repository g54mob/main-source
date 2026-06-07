using System.Collections.Generic;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Presentation.UI.Menus;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.TextBlock
{
	public class IconBlockUI : FactoryPanelUIMenu
	{
		[Header("Icon Block")]
		[SerializeField]
		private TextBlockIconButton _iconButtonPrefab;

		private IconBlockBehaviour _behaviour;

		private readonly List<TextBlockIconButton> _iconButtons = new List<TextBlockIconButton>();

		private int _selectedIndex;

		protected override void HandleOnAwake()
		{
			base.HandleOnAwake();
			_iconButtonPrefab.gameObject.SetActive(value: false);
			_iconButtons.Add(_iconButtonPrefab);
		}

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as IconBlockBehaviour;
			foreach (int orCreatePoolElement in GetOrCreatePoolElements(_behaviour.DisplayIcons.Count, _iconButtons, _iconButtonPrefab))
			{
				_iconButtons[orCreatePoolElement].Setup(_behaviour.DisplayIcons[orCreatePoolElement], orCreatePoolElement, OnSelectIconButtonClicked);
				_iconButtons[_selectedIndex].SetIsSelected(selected: false);
			}
			_selectedIndex = _behaviour.Configuration.IconIndex;
			_iconButtons[_selectedIndex].SetIsSelected(selected: true);
		}

		private void OnSelectIconButtonClicked(int iconIndex)
		{
			_behaviour.Configuration.IconIndex = iconIndex;
			_behaviour.NotifyConfigurationChanged();
			_iconButtons[_selectedIndex].SetIsSelected(selected: false);
			_selectedIndex = iconIndex;
			_iconButtons[_selectedIndex].SetIsSelected(selected: true);
		}

		public static IEnumerable<int> GetOrCreatePoolElements<T>(int count, List<T> pool, T prefab) where T : Component
		{
			int index;
			for (index = 0; index < count; index++)
			{
				if (index >= pool.Count)
				{
					T item = Object.Instantiate(prefab, prefab.transform.parent);
					pool.Add(item);
				}
				yield return index;
				pool[index].gameObject.SetActive(value: true);
			}
			for (; index < pool.Count; index++)
			{
				pool[index].gameObject.SetActive(value: false);
			}
		}
	}
}
