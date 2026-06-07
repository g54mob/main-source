using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Integer", order = 1000)]
	public class IntVar : ScriptableVar
	{
		[SerializeField]
		private int value;

		public Action<int> OnValueChanged = delegate
		{
		};

		public virtual int Value
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

		public virtual void SetValue(IntVar var)
		{
			Value = var.Value;
		}

		public virtual void Add(IntVar var)
		{
			Value += var.Value;
		}

		public virtual void Add(int var)
		{
			Value += var;
		}

		public virtual void Multiply(int var)
		{
			Value *= var;
		}

		public virtual void Multiply(IntVar var)
		{
			Value *= var;
		}

		public virtual void Divide(IntVar var)
		{
			Value /= var;
		}

		public static implicit operator int(IntVar reference)
		{
			return reference.Value;
		}
	}
}
