using System;
using Loxodon.Framework.Observables;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[DefaultExecutionOrder(100)]
	public abstract class AbstractLocalized<T> : MonoBehaviour where T : Component
	{
		[SerializeField]
		private string key;

		protected T target;

		protected IObservableProperty value;

		public string Key
		{
			get
			{
				return key;
			}
			set
			{
				if (!string.IsNullOrEmpty(value) && !value.Equals(key))
				{
					key = value;
					OnKeyChanged();
				}
			}
		}

		protected virtual void OnKeyChanged()
		{
			if (value != null)
			{
				value.ValueChanged -= OnValueChanged;
			}
			if (base.enabled && !(target == null) && !string.IsNullOrEmpty(key))
			{
				Localization current = Localization.Current;
				value = current.GetValue(key);
				value.ValueChanged += OnValueChanged;
				OnValueChanged(value, EventArgs.Empty);
			}
		}

		protected virtual void OnEnable()
		{
			if (target == null)
			{
				target = GetComponent<T>();
			}
			if (!(target == null))
			{
				OnKeyChanged();
			}
		}

		protected virtual void OnDisable()
		{
			if (value != null)
			{
				value.ValueChanged -= OnValueChanged;
				value = null;
			}
		}

		protected abstract void OnValueChanged(object sender, EventArgs e);
	}
}
