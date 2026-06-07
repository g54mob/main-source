using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Sprite Var", order = 2000)]
	public class SpriteVar : ScriptableVar
	{
		[SerializeField]
		private Sprite value;

		public Action<Sprite> OnValueChanged = delegate
		{
		};

		public virtual Sprite Value
		{
			get
			{
				return value;
			}
			set
			{
				if (this.value != value)
				{
					this.value = value;
					OnValueChanged(value);
				}
			}
		}

		public virtual void SetValue(SpriteVar var)
		{
			Value = var.Value;
		}

		public virtual void SetValue(Sprite var)
		{
			Value = var;
		}
	}
}
