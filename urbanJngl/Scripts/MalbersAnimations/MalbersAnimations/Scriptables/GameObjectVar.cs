using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Game Object", order = 3000)]
	public class GameObjectVar : ScriptableVar
	{
		[SerializeField]
		[HideInInspector]
		private GameObject value;

		public Action<GameObject> OnValueChanged;

		public virtual GameObject Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
				OnValueChanged?.Invoke(value);
			}
		}

		public virtual void SetValue(GameObjectVar var)
		{
			Value = var.Value;
		}

		public virtual void SetNull(GameObjectVar var)
		{
			Value = null;
		}

		public virtual void SetValue(GameObject var)
		{
			Value = var;
		}

		public virtual void SetValue(Component var)
		{
			Value = var.gameObject;
		}
	}
}
