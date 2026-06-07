using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.SettingControls;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using Sirenix.Utilities;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class ShowDronePartDetails : MonoBehaviour
	{
		public TweenPosition Tween;

		public FloatSettingControl FloatInputPrefab;

		public BoolSettingControl BoolInputPrefab;

		public EnumSettingControl EnumInputPrefab;

		public ButtonControl ButtonControlPrefab;

		public FlagEnumSettingControl FlagEnumInputPrefab;

		public IntSettingControl IntInputPrefab;

		public UIGrid ControlGrid;

		private List<DronePart> _selectedItems;

		public void Update()
		{
			if (!ItemSelector.CanBeEdited<DronePart>(true))
			{
				_selectedItems = null;
				Tween.Play(false);
				{
					foreach (Transform item in base.transform)
					{
						item.gameObject.SetActive(false);
					}
					return;
				}
			}
			foreach (Transform item2 in base.transform)
			{
				item2.gameObject.SetActive(true);
			}
			Tween.Play(true);
			List<DronePart> list = ItemSelector.SelectedItems.ToList();
			if (_selectedItems != null && _selectedItems.Count == list.Count && (_selectedItems.Count != 1 || _selectedItems.SequenceEqual(list)))
			{
				return;
			}
			_selectedItems = list;
			foreach (Transform item3 in ControlGrid.transform)
			{
				UnityEngine.Object.Destroy(item3.gameObject);
			}
			DronePart dronePart = ItemSelector.SelectedItems.First();
			List<DronePart> parentObjects = ItemSelector.SelectedItems.ToList();
			if (dronePart != null)
			{
				FieldInfo[] fields = dronePart.GetType().GetFields();
				foreach (FieldInfo fieldInfo in fields)
				{
					FloatSetting attribute = fieldInfo.GetAttribute<FloatSetting>(true);
					if (attribute != null)
					{
						UnityEngine.Object.Instantiate(FloatInputPrefab, ControlGrid.transform).Init(attribute.Name, attribute.GetMinValue(dronePart), attribute.GetMaxValue(dronePart), attribute.GetSteps(dronePart), fieldInfo, parentObjects, attribute.StoreReason);
					}
					IntSetting attribute2 = fieldInfo.GetAttribute<IntSetting>(true);
					if (attribute2 != null)
					{
						UnityEngine.Object.Instantiate(IntInputPrefab, ControlGrid.transform).Init(attribute2.Name, attribute2.GetMinValue(dronePart), attribute2.GetMaxValue(dronePart), attribute2.GetSteps(dronePart), fieldInfo, parentObjects, attribute2.StoreReason);
					}
					BoolSetting attribute3 = fieldInfo.GetAttribute<BoolSetting>(true);
					if (attribute3 != null)
					{
						UnityEngine.Object.Instantiate(BoolInputPrefab, ControlGrid.transform).Init(attribute3.Name, fieldInfo, parentObjects, attribute3.StoreReason);
					}
					EnumSetting attribute4 = fieldInfo.GetAttribute<EnumSetting>(true);
					if (attribute4 != null)
					{
						if (fieldInfo.FieldType.GetAttribute<FlagsAttribute>(true) == null)
						{
							UnityEngine.Object.Instantiate(EnumInputPrefab, ControlGrid.transform).Init(attribute4.Name, fieldInfo, parentObjects, attribute4.StoreReason);
						}
						else
						{
							UnityEngine.Object.Instantiate(FlagEnumInputPrefab, ControlGrid.transform).Init(attribute4.Name, fieldInfo, parentObjects, attribute4.StoreReason, attribute4.GetRows(dronePart));
						}
					}
				}
				MethodInfo[] methods = dronePart.GetType().GetMethods();
				foreach (MethodInfo methodInfo in methods)
				{
					ButtonSetting attribute5 = methodInfo.GetAttribute<ButtonSetting>(true);
					if (attribute5 != null)
					{
						UnityEngine.Object.Instantiate(ButtonControlPrefab, ControlGrid.transform).Init(attribute5.Name, parentObjects, methodInfo, attribute5.StoreReason);
					}
				}
			}
			ControlGrid.Reposition();
		}
	}
}
