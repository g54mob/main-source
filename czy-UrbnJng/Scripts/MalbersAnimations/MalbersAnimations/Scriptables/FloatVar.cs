using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Float", order = 1000)]
	public class FloatVar : ScriptableVar
	{
		[SerializeField]
		protected float value;

		public Action<float> OnValueChanged = delegate
		{
		};

		public virtual float Value
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

		public virtual void SetValue(FloatVar var)
		{
			Value = var.Value;
		}

		public virtual void Add(FloatVar var)
		{
			Value += var.Value;
		}

		public virtual void Add(float var)
		{
			Value += var;
		}

		public static implicit operator float(FloatVar reference)
		{
			return reference.Value;
		}
	}
}
