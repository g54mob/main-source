using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.SettingControls
{
	public class BoolSettingControl : MonoBehaviour
	{
		public UILabel Name;

		public UIButton Button;

		public UIToggle Toggle;

		private bool _currentValue;

		private FieldInfo _fieldInfo;

		private List<DronePart> _parentObjects;

		private UndoManager.EStoreReason _storeReason;

		public void Init(string title, FieldInfo fieldInfo, List<DronePart> parentObjects, UndoManager.EStoreReason storeReason)
		{
			Name.text = title + ":";
			_storeReason = storeReason;
			_parentObjects = parentObjects;
			_fieldInfo = fieldInfo;
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < parentObjects.Count; i++)
			{
				DronePart obj = parentObjects[i];
				bool flag3 = (bool)fieldInfo.GetValue(obj);
				if (i == 0)
				{
					flag = flag3;
				}
				else if (flag3 != flag)
				{
					flag2 = true;
					break;
				}
			}
			Name.text = title + ":";
			_currentValue = flag;
			_parentObjects = parentObjects;
			_fieldInfo = fieldInfo;
			Toggle.value = _currentValue;
			if (flag2)
			{
				Button.gameObject.SetActive(true);
				EventDelegate.Add(Button.onClick, Click);
			}
			else
			{
				Button.gameObject.SetActive(false);
			}
		}

		private void Click()
		{
			Button.gameObject.SetActive(false);
			Toggle.value = false;
		}

		public void OnDestroy()
		{
			EventDelegate.Remove(Button.onClick, Click);
		}

		public void OnTooltip(bool show)
		{
			if (Name.processedText != Name.text)
			{
				NimbatusToolTip.Show(Name.text, show);
			}
		}

		public void Update()
		{
			if (Toggle.value == _currentValue)
			{
				return;
			}
			_currentValue = Toggle.value;
			if (_parentObjects.Count == 1)
			{
				DronePart dronePart = _parentObjects.First();
				if (dronePart != null)
				{
					_fieldInfo.SetValue(dronePart, _currentValue);
					BaseSingleton<UndoManager>.Instance.Store(_storeReason, dronePart);
				}
				return;
			}
			bool flag = false;
			foreach (DronePart parentObject in _parentObjects)
			{
				if (parentObject != null)
				{
					_fieldInfo.SetValue(parentObject, _currentValue);
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
