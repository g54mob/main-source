using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Transform", order = 3000)]
	public class TransformVar : ScriptableVar
	{
		[SerializeField]
		private Transform value;

		public Action<Transform> OnValueChanged = delegate
		{
		};

		public virtual Transform Value
		{
			get
			{
				return value;
			}
			set
			{
				if (value != this.value)
				{
					this.value = value;
					OnValueChanged(value);
				}
			}
		}

		public virtual void SetValue(TransformVar var)
		{
			Value = var.Value;
		}

		public virtual void SetNull()
		{
			Value = null;
		}

		public virtual void SetValue(Transform var)
		{
			Value = var;
		}

		public virtual void SetValue(GameObject var)
		{
			Value = var.transform;
		}

		public virtual void SetValue(Component var)
		{
			Value = var.transform;
		}

		public virtual void ApplyPositionTo(Transform var)
		{
			var.position = Value.position;
		}

		public virtual void SetVector3Value(Vector3Var var)
		{
			var.Value = Value.position;
		}
	}
}
