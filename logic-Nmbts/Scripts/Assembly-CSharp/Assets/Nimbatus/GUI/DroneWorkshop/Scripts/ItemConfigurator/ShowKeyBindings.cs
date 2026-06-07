using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class ShowKeyBindings : MonoBehaviour
	{
		public TweenPosition KeyBindTween;

		private List<BindableDronePart> _selectedItems;

		public KeyBindingUi KeyBindPrefab;

		public EventKeyBindingUi EventKeyBindPrefab;

		public UIGrid KeyBindList;

		public void Update()
		{
			if (!ItemSelector.CanBeEdited<BindableDronePart>(false))
			{
				_selectedItems = null;
				KeyBindTween.Play(false);
				return;
			}
			KeyBindTween.Play(true);
			List<BindableDronePart> list = ItemSelector.SelectedItems.Cast<BindableDronePart>().ToList();
			if (_selectedItems != null && _selectedItems.Count == list.Count && (_selectedItems.Count != 1 || _selectedItems.SequenceEqual(list)))
			{
				return;
			}
			_selectedItems = list;
			(from Transform child in KeyBindList.transform
				select child.gameObject).ToList().ForEach(Object.DestroyImmediate);
			BindableDronePart bindableDronePart = _selectedItems.First();
			for (int num = 0; num < bindableDronePart.KeyBindings.Count; num++)
			{
				List<KeyBinding> list2 = new List<KeyBinding>();
				foreach (BindableDronePart selectedItem in _selectedItems)
				{
					list2.Add(selectedItem.KeyBindings[num]);
				}
				KeyBindingUi keyBindingUi = Object.Instantiate(KeyBindPrefab);
				keyBindingUi.transform.position = KeyBindList.transform.position;
				keyBindingUi.transform.parent = KeyBindList.transform;
				keyBindingUi.transform.localScale = Vector3.one;
				keyBindingUi.Init(list2);
			}
			if (bindableDronePart is SensorPart)
			{
				SensorPart sensorPart = bindableDronePart as SensorPart;
				for (int num2 = 0; num2 < sensorPart.EventBindings.Count; num2++)
				{
					List<EventKeyBinding> list3 = new List<EventKeyBinding>();
					foreach (SensorPart item in _selectedItems.OfType<SensorPart>())
					{
						list3.Add(item.EventBindings[num2]);
					}
					EventKeyBindingUi eventKeyBindingUi = Object.Instantiate(EventKeyBindPrefab);
					eventKeyBindingUi.transform.position = KeyBindList.transform.position;
					eventKeyBindingUi.transform.parent = KeyBindList.transform;
					eventKeyBindingUi.transform.localScale = Vector3.one;
					eventKeyBindingUi.Init(list3);
				}
			}
			KeyBindList.Reposition();
		}
	}
}
