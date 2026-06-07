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
	public class FloatSettingControl : MonoBehaviour
	{
		public UILabel Name;

		public FloatInputSlider Slider;

		private FieldInfo _fieldInfo;

		private List<DronePart> _parentObjects;

		private UndoManager.EStoreReason _storeReason;

		public void Init(string title, float min, float max, int steps, FieldInfo fieldInfo, List<DronePart> parentObjects, UndoManager.EStoreReason storeReason)
		{
			Name.text = title + ":";
			_storeReason = storeReason;
			_parentObjects = parentObjects;
			_fieldInfo = fieldInfo;
			float num = 0f;
			bool valueUnknown = false;
			for (int i = 0; i < parentObjects.Count; i++)
			{
				DronePart obj = parentObjects[i];
				float num2 = (float)fieldInfo.GetValue(obj);
				if (i == 0)
				{
					num = num2;
				}
				else if ((double)Math.Abs(num - num2) > 0.0001)
				{
					valueUnknown = true;
					break;
				}
			}
			Slider.Init(min, max, steps, num, valueUnknown);
			Slider.ValueChanged += Slider_ValueChanged;
		}

		public void OnTooltip(bool show)
		{
			if (Name.processedText != Name.text)
			{
				NimbatusToolTip.Show(Name.text, show);
			}
		}

		public void OnDestroy()
		{
			Slider.ValueChanged -= Slider_ValueChanged;
		}

		private void Slider_ValueChanged(float value)
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
