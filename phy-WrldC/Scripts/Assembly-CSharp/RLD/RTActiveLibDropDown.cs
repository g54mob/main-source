using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RLD
{
	public class RTActiveLibDropDown : MonoBehaviour
	{
		private Dropdown _dropDown;

		private List<UnityAction<int>> _valueChangedListeners = new List<UnityAction<int>>();

		public int ActiveLibIndex => _dropDown.value;

		public void AddValueChangedListener(UnityAction<int> listener)
		{
			_dropDown.onValueChanged.AddListener(listener);
			_valueChangedListeners.Add(listener);
		}

		public void SetActiveLibIndex(int activeLibIndex)
		{
			_dropDown.onValueChanged.RemoveAllListeners();
			_dropDown.value = activeLibIndex;
			foreach (UnityAction<int> valueChangedListener in _valueChangedListeners)
			{
				_dropDown.onValueChanged.AddListener(valueChangedListener);
			}
		}

		public void ClearLibs()
		{
			_dropDown.ClearOptions();
		}

		public void SyncWithLibDb()
		{
			ClearLibs();
			if (MonoSingleton<RTPrefabLibDb>.Get.NumLibs != 0)
			{
				List<string> allLibNames = MonoSingleton<RTPrefabLibDb>.Get.GetAllLibNames();
				_dropDown.AddOptions(allLibNames);
				SetActiveLibIndex(MonoSingleton<RTPrefabLibDb>.Get.ActiveLibIndex);
			}
		}

		private void Awake()
		{
			_dropDown = base.gameObject.GetComponent<Dropdown>();
		}
	}
}
