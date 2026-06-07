using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.DroneSkins;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class ShowDroneSkins : MonoBehaviour
	{
		public TweenPosition DroneSkinsTween;

		public EnumChooser DroneSkinSetChooser;

		public InputSlider SkinSlider;

		public FloatInputSlider PivotXSlider;

		public FloatInputSlider PivotYSlider;

		public FloatInputSlider ZOrderSlider;

		public DroneSkinSelector SkinSelector;

		public GameObject SkinSettingsParent;

		public GameObject LockedGameObject;

		private List<DronePart> _selectedItems = new List<DronePart>();

		private bool _wasInvisible;

		public void Start()
		{
			SkinSlider.Init(0, 360, 9);
			SkinSlider.ValueChanged += SkinSlider_ValueChanged;
			PivotXSlider.Init(-1f, 1f, 21);
			PivotXSlider.ValueChanged += PivotXSlider_ValueChanged;
			PivotYSlider.Init(-1f, 1f, 21);
			PivotYSlider.ValueChanged += PivotYSlider_ValueChanged;
			ZOrderSlider.Init(-1f, 1f, 21);
			ZOrderSlider.ValueChanged += ZOrderSlider_ValueChanged;
			DroneSkinSetChooser.SelectionChanged += DroneSkinSetChooser_SelectionChanged;
			SkinSelector.SelectionChanged += SkinSelector_SelectionChanged;
		}

		private void SkinSelector_SelectionChanged(DroneSkinItem value, bool storeChange)
		{
			if (value != null)
			{
				foreach (DronePart selectedItem in _selectedItems)
				{
					selectedItem.SelectedSkin = value.Skin;
				}
				SkinSettingsParent.gameObject.SetActive(true);
				if (storeChange)
				{
					BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.DroneSkin);
				}
				return;
			}
			foreach (DronePart selectedItem2 in _selectedItems)
			{
				selectedItem2.SelectedSkin = null;
			}
			SkinSettingsParent.gameObject.SetActive(false);
			if (storeChange)
			{
				BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.DroneSkin);
			}
		}

		private void DroneSkinSetChooser_SelectionChanged(Enum value)
		{
			EDroneSkinSet eDroneSkinSet = (EDroneSkinSet)(object)value;
			SkinSelector.Init(eDroneSkinSet, true);
			LockedGameObject.SetActive(false);
			if (eDroneSkinSet == EDroneSkinSet.None)
			{
				foreach (DronePart selectedItem in _selectedItems)
				{
					selectedItem.SelectedSkin = null;
				}
				SkinSelector.gameObject.SetActive(false);
				SkinSettingsParent.gameObject.SetActive(false);
			}
			else
			{
				if (!BaseSingleton<DroneSkinManager>.Instance.IsSetUnlocked(eDroneSkinSet))
				{
					LockedGameObject.SetActive(true);
				}
				SkinSelector.gameObject.SetActive(true);
				SkinSettingsParent.gameObject.SetActive(true);
			}
		}

		private void ZOrderSlider_ValueChanged(float value)
		{
			foreach (DronePart selectedItem in _selectedItems)
			{
				selectedItem.SkinZOrder = value;
			}
			BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.SkinZOrder);
		}

		private void PivotYSlider_ValueChanged(float value)
		{
			foreach (DronePart selectedItem in _selectedItems)
			{
				selectedItem.SkinPivotY = value;
			}
			BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.SkinPivotY);
		}

		private void PivotXSlider_ValueChanged(float value)
		{
			foreach (DronePart selectedItem in _selectedItems)
			{
				selectedItem.SkinPivotX = value;
			}
			BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.SkinPivotX);
		}

		private void SkinSlider_ValueChanged(int value)
		{
			foreach (DronePart selectedItem in _selectedItems)
			{
				selectedItem.SkinRotation = value;
			}
			BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.DroneSkinRotation);
		}

		public void OnDestroy()
		{
			SkinSlider.ValueChanged -= SkinSlider_ValueChanged;
			PivotXSlider.ValueChanged -= PivotXSlider_ValueChanged;
			PivotYSlider.ValueChanged -= PivotYSlider_ValueChanged;
			ZOrderSlider.ValueChanged -= ZOrderSlider_ValueChanged;
			DroneSkinSetChooser.SelectionChanged -= DroneSkinSetChooser_SelectionChanged;
			SkinSelector.SelectionChanged -= SkinSelector_SelectionChanged;
		}

		public void Update()
		{
			if (ItemSelector.SelectedItems.Count < 1 || DragAndDropHelper.DraggedItem != null)
			{
				DroneSkinsTween.Play(false);
				foreach (Transform item in base.transform)
				{
					item.gameObject.SetActive(false);
				}
				_wasInvisible = true;
				return;
			}
			List<DronePart> list = ItemSelector.SelectedItems.ToList();
			if (_wasInvisible)
			{
				foreach (Transform item2 in base.transform)
				{
					item2.gameObject.SetActive(true);
				}
				_wasInvisible = false;
			}
			else if (_selectedItems != null && _selectedItems.Count == list.Count && (_selectedItems.Count != 1 || _selectedItems.SequenceEqual(list)))
			{
				return;
			}
			_selectedItems = list;
			DronePart dronePart = ItemSelector.SelectedItems.First();
			SkinSlider.CurrentValue = dronePart.SkinRotation;
			PivotXSlider.CurrentValue = dronePart.SkinPivotX;
			PivotYSlider.CurrentValue = dronePart.SkinPivotY;
			ZOrderSlider.CurrentValue = dronePart.SkinZOrder;
			DroneSkin droneSkin = null;
			bool flag = false;
			for (int i = 0; i < _selectedItems.Count; i++)
			{
				DroneSkin selectedSkin = _selectedItems[i].SelectedSkin;
				if (i == 0)
				{
					droneSkin = selectedSkin;
				}
				else if (!object.Equals(selectedSkin, droneSkin))
				{
					flag = true;
					break;
				}
			}
			if (droneSkin != null)
			{
				DroneSkinSetChooser.Init<EDroneSkinSet>(droneSkin.Set, flag);
				SkinSelector.ResetPreviousValues();
				if (!flag)
				{
					SkinSelector.SetPreviousValues(droneSkin.Height, droneSkin.Width);
					SkinSelector.Init(droneSkin.Set, true);
				}
			}
			else
			{
				DroneSkinSetChooser.Init<EDroneSkinSet>(EDroneSkinSet.None, flag);
				SkinSelector.gameObject.SetActive(false);
				SkinSettingsParent.gameObject.SetActive(false);
			}
			if (flag)
			{
				SkinSelector.gameObject.SetActive(false);
				SkinSettingsParent.gameObject.SetActive(false);
			}
		}
	}
}
