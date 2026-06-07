using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class ShowLEDDetails : SerializedMonoBehaviour
	{
		public TweenPosition Tween;

		private List<LEDColorButton> _colors;

		private List<LEDPart> _selectedItems;

		public LEDColorButton SelectedColor { get; private set; }

		public void Start()
		{
			_colors = GetComponentsInChildren<LEDColorButton>().ToList();
			foreach (LEDColorButton color in _colors)
			{
				color.Init(this);
			}
		}

		public void Select(LEDColorButton ledColorButton)
		{
			SelectedColor = ledColorButton;
			foreach (LEDPart selectedItem in _selectedItems)
			{
				Color ledColor = SelectedColor.LedColor;
				selectedItem.Color = ledColor;
			}
			BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.LedColor);
		}

		public void Update()
		{
			if (!ItemSelector.CanBeEdited<LEDPart>(false))
			{
				_selectedItems = null;
				foreach (Transform item2 in base.transform)
				{
					item2.gameObject.SetActive(false);
				}
				Tween.Play(false);
				return;
			}
			foreach (Transform item3 in base.transform)
			{
				item3.gameObject.SetActive(true);
			}
			Tween.Play(true);
			List<LEDPart> list = ItemSelector.SelectedItems.OfType<LEDPart>().ToList();
			if (_selectedItems != null && _selectedItems.Count == list.Count && (_selectedItems.Count != 1 || _selectedItems.SequenceEqual(list)))
			{
				return;
			}
			_selectedItems = list;
			LEDPart item = (LEDPart)ItemSelector.SelectedItems.First();
			SelectedColor = _colors.FirstOrDefault((LEDColorButton c) => c.LedColor == item.Color);
			if (!(SelectedColor == null))
			{
				return;
			}
			SelectedColor = _colors.First();
			foreach (LEDPart selectedItem in _selectedItems)
			{
				Color ledColor = SelectedColor.LedColor;
				selectedItem.Color = ledColor;
			}
		}
	}
}
