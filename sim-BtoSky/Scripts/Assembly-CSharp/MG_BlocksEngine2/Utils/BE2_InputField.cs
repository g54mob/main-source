using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Utils
{
	public class BE2_InputField
	{
		private Transform _transform;

		private InputField _legacyComponent;

		private TMP_InputField _tmpComponent;

		private bool _isNull;

		public bool isNull => _isNull;

		public UnityEvent<string> onEndEdit
		{
			get
			{
				if ((bool)_tmpComponent)
				{
					return _tmpComponent.onEndEdit;
				}
				if ((bool)_legacyComponent)
				{
					return _legacyComponent.onEndEdit;
				}
				return null;
			}
		}

		public UnityEvent<string> onValueChanged
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

		public float preferredWidth
		{
			get
			{
				if ((bool)_tmpComponent)
				{
					return _tmpComponent.preferredWidth;
				}
				if ((bool)_legacyComponent)
				{
					return _legacyComponent.preferredWidth;
				}
				return 0f;
			}
		}

		public string text
		{
			get
			{
				if ((bool)_tmpComponent)
				{
					return _tmpComponent.text;
				}
				if ((bool)_legacyComponent)
				{
					return _legacyComponent.text;
				}
				return "";
			}
			set
			{
				if ((bool)_tmpComponent)
				{
					_tmpComponent.text = value;
				}
				else if ((bool)_legacyComponent)
				{
					_legacyComponent.text = value;
				}
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

		public BE2_InputField(Transform transform)
		{
			_transform = transform;
		}

		private void Init()
		{
			_legacyComponent = _transform.GetComponent<InputField>();
			_tmpComponent = _transform.GetComponent<TMP_InputField>();
			_isNull = ((!_legacyComponent && !_tmpComponent) ? true : false);
		}

		public static BE2_InputField GetBE2Component(Transform transform)
		{
			BE2_InputField bE2_InputField = new BE2_InputField(transform);
			bE2_InputField.Init();
			if (!bE2_InputField.isNull)
			{
				return bE2_InputField;
			}
			return null;
		}

		public static BE2_InputField GetBE2ComponentInChildren(Transform transform)
		{
			InputField componentInChildren = transform.GetComponentInChildren<InputField>();
			if (componentInChildren != null)
			{
				return GetBE2Component(componentInChildren.transform);
			}
			TMP_InputField componentInChildren2 = transform.GetComponentInChildren<TMP_InputField>();
			if (componentInChildren2 != null)
			{
				return GetBE2Component(componentInChildren2.transform);
			}
			return null;
		}

		public static BE2_InputField[] GetBE2ComponentsInChildren(Transform transform)
		{
			List<BE2_InputField> list = new List<BE2_InputField>();
			BE2_InputField bE2Component = GetBE2Component(transform);
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
	}
}
