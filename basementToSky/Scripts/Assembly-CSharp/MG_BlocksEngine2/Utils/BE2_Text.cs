using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Utils
{
	public class BE2_Text
	{
		private Transform _transform;

		private Text _textComponent;

		private TMP_Text _tmpComponent;

		private bool _isNull;

		public bool isNull => _isNull;

		public string text
		{
			get
			{
				if ((bool)_tmpComponent)
				{
					return _tmpComponent.text;
				}
				if ((bool)_textComponent)
				{
					return _textComponent.text;
				}
				return "";
			}
			set
			{
				if ((bool)_tmpComponent)
				{
					_tmpComponent.text = value;
				}
				else if ((bool)_textComponent)
				{
					_textComponent.text = value;
				}
			}
		}

		public bool raycastTarget
		{
			get
			{
				if ((bool)_tmpComponent)
				{
					return _tmpComponent.raycastTarget;
				}
				if ((bool)_textComponent)
				{
					return _textComponent.raycastTarget;
				}
				return false;
			}
			set
			{
				if ((bool)_tmpComponent)
				{
					_tmpComponent.raycastTarget = value;
				}
				else if ((bool)_textComponent)
				{
					_textComponent.raycastTarget = value;
				}
			}
		}

		public BE2_Text(Transform transform)
		{
			_transform = transform;
		}

		private void Init()
		{
			_textComponent = _transform.GetComponent<Text>();
			_tmpComponent = _transform.GetComponent<TMP_Text>();
			_isNull = ((!_textComponent && !_tmpComponent) ? true : false);
		}

		public static BE2_Text GetBE2Text(Transform transform)
		{
			BE2_Text bE2_Text = new BE2_Text(transform);
			bE2_Text.Init();
			if (!bE2_Text.isNull)
			{
				return bE2_Text;
			}
			return null;
		}

		public static BE2_Text GetBE2TextInChildren(Transform transform)
		{
			Text componentInChildren = transform.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				return GetBE2Text(componentInChildren.transform);
			}
			TMP_Text componentInChildren2 = transform.GetComponentInChildren<TMP_Text>();
			if (componentInChildren2 != null)
			{
				return GetBE2Text(componentInChildren2.transform);
			}
			return null;
		}

		public static BE2_Text[] GetBE2TextsInChildren(Transform transform)
		{
			List<BE2_Text> list = new List<BE2_Text>();
			BE2_Text bE2Text = GetBE2Text(transform);
			if (bE2Text != null && !bE2Text.isNull)
			{
				list.Add(bE2Text);
				bE2Text.Init();
			}
			foreach (Transform item in transform)
			{
				bE2Text = GetBE2Text(item);
				if (bE2Text != null && !bE2Text.isNull)
				{
					list.Add(bE2Text);
					bE2Text.Init();
				}
				list.AddRange(GetBE2TextsInChildren(item));
			}
			return list.ToArray();
		}

		public T GetComponent<T>()
		{
			return _transform.GetComponent<T>();
		}
	}
}
