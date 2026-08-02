using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rhizomatic.UI
{
	public abstract class UIAdapter<TValue> : MonoBehaviour
	{
		private bool _interactable;

		public TValue value { get; private set; }

		public bool interactable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action<TValue> onValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<TValue> onStartEdit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<TValue> onEndEdit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected abstract void UpdateView();

		public void SetValue(TValue value)
		{
		}

		public void SetValueWithoutNotify(TValue value)
		{
		}

		protected void ValueChanged(TValue value)
		{
		}

		protected void StartEdit()
		{
		}

		protected void EndEdit()
		{
		}
	}
}
