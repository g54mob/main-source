using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Bool", order = 1000)]
	public class BoolVar : ScriptableVar
	{
		[SerializeField]
		private bool value;

		public Action<bool> OnValueChanged = delegate
		{
		};

		public virtual bool Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
				OnValueChanged(value);
			}
		}

		public virtual void SetValue(BoolVar var)
		{
			SetValue(var.Value);
		}

		public virtual void SetValue(bool var)
		{
			Value = var;
		}

		public virtual void SetValueInverted(bool var)
		{
			Value = !var;
		}

		public virtual void Toggle()
		{
			Value = !Value;
		}

		public virtual void UpdateValue()
		{
			OnValueChanged?.Invoke(value);
		}

		public static implicit operator bool(BoolVar reference)
		{
			return reference.Value;
		}
	}
}
