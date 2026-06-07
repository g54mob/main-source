using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.SettingControls
{
	public class EnumSettingControl : MonoBehaviour
	{
		public UILabel Name;

		public EnumChooser EnumChooser;

		private List<DronePart> _parentObjects;

		private FieldInfo _fieldInfo;

		private UndoManager.EStoreReason _storeReason;

		public void Init(string title, FieldInfo fieldInfo, List<DronePart> parentObjects, UndoManager.EStoreReason storeReason)
		{
			_parentObjects = parentObjects;
			_fieldInfo = fieldInfo;
			_storeReason = storeReason;
			Name.text = title + ":";
			Type fieldType = fieldInfo.FieldType;
			Enum obj = null;
			bool unknownValue = false;
			for (int i = 0; i < parentObjects.Count; i++)
			{
				DronePart obj2 = parentObjects[i];
				Enum obj3 = (Enum)fieldInfo.GetValue(obj2);
				if (i == 0)
				{
					obj = obj3;
				}
				else if (!object.Equals(obj3, obj))
				{
					unknownValue = true;
					break;
				}
			}
			EnumChooser.Init(Enum.GetValues(fieldType), obj, unknownValue);
			EnumChooser.SelectionChanged += EnumChooser_SelectionChanged;
		}

		public void OnDestroy()
		{
			EnumChooser.SelectionChanged -= EnumChooser_SelectionChanged;
		}

		public void OnTooltip(bool show)
		{
			if (Name.processedText != Name.text)
			{
				NimbatusToolTip.Show(Name.text, show);
			}
		}

		private void EnumChooser_SelectionChanged(Enum value)
		{
			if (_parentObjects.Count == 1)
			{
				DronePart dronePart = _parentObjects.First();
				if (dronePart != null)
				{
					_fieldInfo.SetValue(dronePart, value);
					BaseSingleton<UndoManager>.Instance.Store(_storeReason, dronePart);
				}
				return;
			}
			bool flag = false;
			foreach (DronePart parentObject in _parentObjects)
			{
				if (parentObject != null)
				{
					_fieldInfo.SetValue(parentObject, value);
					flag = true;
				}
			}
			if (flag)
			{
				BaseSingleton<UndoManager>.Instance.Store(_storeReason);
			}
		}
	}
}
