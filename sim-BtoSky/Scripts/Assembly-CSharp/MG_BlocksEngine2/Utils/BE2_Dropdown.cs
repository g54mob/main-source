using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Utils
{
	public class BE2_Dropdown
	{
		private Transform _transform;

		private Dropdown _legacyComponent;

		private TMP_Dropdown _tmpComponent;

		private bool _isNull;

		public bool isNull => _isNull;

		public int value
		{
			get
			{
				if ((bool)_tmpComponent)
				{
					return _tmpComponent.value;
				}
				if ((bool)_legacyComponent)
				{
					return _legacyComponent.value;
				}
				return -1;
			}
			set
			{
				if ((bool)_tmpComponent)
				{
					_tmpComponent.value = value;
				}
				else if ((bool)_legacyComponent)
				{
					_legacyComponent.value = value;
				}
			}
		}

		public float captionTextpreferredWidth
		{
			get
			{
				if ((bool)_tmpComponent)
				{
					return _tmpComponent.captionText.preferredWidth;
				}
				if ((bool)_legacyComponent)
				{
					return _legacyComponent.captionText.preferredWidth;
				}
				return -1f;
			}
		}

		public UnityEvent<int> onValueChanged
		{
			get
			{
				if ((bool)_tmpComponent)
				{
					return _tmpComponent.onValueChanged;
				}
				if ((bool)_legacyComponent)
				{
					return _legacyComponent.onValueChanged;
				}
				return null;
			}
		}

		public bool enabled
		{
			get
			{
				if ((bool)_tmpComponent)
				{
					return _tmpComponent.enabled;
				}
				if ((bool)_legacyComponent)
				{
					return _legacyComponent.enabled;
				}
				return false;
			}
			set
			{
				if ((bool)_tmpComponent)
				{
					_tmpComponent.enabled = value;
				}
				else if ((bool)_legacyComponent)
				{
					_legacyComponent.enabled = value;
				}
			}
		}

		public BE2_Dropdown(Transform transform)
		{
			_transform = transform;
		}

		private void Init()
		{
			_legacyComponent = _transform.GetComponent<Dropdown>();
			_tmpComponent = _transform.GetComponent<TMP_Dropdown>();
			_isNull = ((!_legacyComponent && !_tmpComponent) ? true : false);
		}

		public static BE2_Dropdown GetBE2Component(Transform transform)
		{
			BE2_Dropdown bE2_Dropdown = new BE2_Dropdown(transform);
			bE2_Dropdown.Init();
			if (!bE2_Dropdown.isNull)
			{
				return bE2_Dropdown;
			}
			return null;
		}

		public static BE2_Dropdown GetBE2ComponentInChildren(Transform transform)
		{
			Dropdown componentInChildren = transform.GetComponentInChildren<Dropdown>();
			if (componentInChildren != null)
			{
				return GetBE2Component(componentInChildren.transform);
			}
			TMP_Dropdown componentInChildren2 = transform.GetComponentInChildren<TMP_Dropdown>();
			if (componentInChildren2 != null)
			{
				return GetBE2Component(componentInChildren2.transform);
			}
			return null;
		}

		public static BE2_Dropdown[] GetBE2ComponentsInChildren(Transform transform)
		{
			List<BE2_Dropdown> list = new List<BE2_Dropdown>();
			BE2_Dropdown bE2Component = GetBE2Component(transform);
			if (bE2Component != null && !bE2Component.isNull)
			{
				list.Add(bE2Component);
				bE2Component.Init();
			}
			foreach (Transform item in transform)
			{
				bE2Component = GetBE2Component(item);
				if (bE2Component != null && !bE2Component.isNull)
				{
					list.Add(bE2Component);
					bE2Component.Init();
				}
				list.AddRange(GetBE2ComponentsInChildren(item));
			}
			return list.ToArray();
		}

		public void ClearOptions()
		{
			if ((bool)_tmpComponent)
			{
				_tmpComponent.ClearOptions();
			}
			else if ((bool)_legacyComponent)
			{
				_legacyComponent.ClearOptions();
			}
		}

		public void AddOption(string option)
		{
			if ((bool)_tmpComponent)
			{
				_tmpComponent.options.Add(new TMP_Dropdown.OptionData(option));
			}
			else if ((bool)_legacyComponent)
			{
				_legacyComponent.options.Add(new Dropdown.OptionData(option));
			}
		}

		public string GetOptionTextAtIndex(int index)
		{
			if ((bool)_tmpComponent)
			{
				return _tmpComponent.options[index].text;
			}
			if ((bool)_legacyComponent)
			{
				return _legacyComponent.options[index].text;
			}
			return "";
		}

		public string GetSelectedOptionText()
		{
			if ((bool)_tmpComponent)
			{
				return _tmpComponent.options[_tmpComponent.value].text;
			}
			if ((bool)_legacyComponent)
			{
				return _legacyComponent.options[_legacyComponent.value].text;
			}
			return "";
		}

		public int GetOptionsCount()
		{
			if ((bool)_tmpComponent)
			{
				return _tmpComponent.options.Count;
			}
			if ((bool)_legacyComponent)
			{
				return _legacyComponent.options.Count;
			}
			return -1;
		}

		public int GetIndexOf(string text)
		{
			if ((bool)_tmpComponent)
			{
				return _tmpComponent.options.FindIndex((TMP_Dropdown.OptionData option) => option.text == text);
			}
			if ((bool)_legacyComponent)
			{
				return _legacyComponent.options.FindIndex((Dropdown.OptionData option) => option.text == text);
			}
			return -1;
		}

		public void RefreshShownValue()
		{
			if ((bool)_tmpComponent)
			{
				_tmpComponent.RefreshShownValue();
			}
			else if ((bool)_legacyComponent)
			{
				_legacyComponent.RefreshShownValue();
			}
		}
	}
}
