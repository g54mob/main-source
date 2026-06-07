using System;
using TMPro;
using UnityEngine;

namespace UIScripts.InfoHandles
{
	public abstract class ValueTextHandle<T> : ValueInfoHandle<T> where T : IComparable<T>
	{
		public TextMeshProUGUI text;

		public Color color
		{
			get
			{
				return text.color;
			}
			set
			{
				text.color = value;
			}
		}

		protected virtual void Awake()
		{
			text = GetComponent<TextMeshProUGUI>();
			UpdateValue(value, check: false);
		}
	}
}
