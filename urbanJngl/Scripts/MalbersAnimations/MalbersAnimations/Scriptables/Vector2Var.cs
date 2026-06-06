using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Vector2", order = 1000)]
	public class Vector2Var : ScriptableVar
	{
		[SerializeField]
		private Vector2 value = Vector2.zero;

		public Action<Vector2> OnValueChanged = delegate
		{
		};

		public virtual Vector2 Value
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

		public float x
		{
			get
			{
				return value.x;
			}
			set
			{
				this.value.x = value;
			}
		}

		public float y
		{
			get
			{
				return value.y;
			}
			set
			{
				this.value.y = value;
			}
		}

		public void SetValue(Vector2Var var)
		{
			Value = var.Value;
		}

		public void SetX(float var)
		{
			value.x = var;
		}

		public void SetY(float var)
		{
			value.y = var;
		}

		public static implicit operator Vector2(Vector2Var reference)
		{
			return reference.Value;
		}
	}
}
