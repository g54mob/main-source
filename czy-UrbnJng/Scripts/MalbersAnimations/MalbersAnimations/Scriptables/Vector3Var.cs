using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Vector3", order = 1000)]
	public class Vector3Var : ScriptableVar
	{
		[SerializeField]
		private Vector3 value = Vector3.zero;

		public Action<Vector3> OnValueChanged = delegate
		{
		};

		public virtual Vector3 Value
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

		public float z
		{
			get
			{
				return value.z;
			}
			set
			{
				this.value.z = value;
			}
		}

		public void SetValue(Vector3Var var)
		{
			Value = var.Value;
		}

		public void SetValue(Vector3 var)
		{
			Value = var;
		}

		public void SetValuePosition(Transform var)
		{
			Value = var.position;
		}

		public void SetValuePosition(Component var)
		{
			Value = var.transform.position;
		}

		public void SetValuePosition(GameObject var)
		{
			Value = var.transform.position;
		}

		public void SetValuePositionLocal(Transform var)
		{
			Value = var.localPosition;
		}

		public void SetValuePositionLocal(Component var)
		{
			Value = var.transform.localPosition;
		}

		public void SetValuePositionLocal(GameObject var)
		{
			Value = var.transform.localPosition;
		}

		public void SetValueRotation(Transform var)
		{
			Value = var.rotation.eulerAngles;
		}

		public void SetValueRotation(Component var)
		{
			Value = var.transform.rotation.eulerAngles;
		}

		public void SetValueRotation(GameObject var)
		{
			Value = var.transform.rotation.eulerAngles;
		}

		public void SetValueRotationLocal(Transform var)
		{
			Value = var.localRotation.eulerAngles;
		}

		public void SetValueRotationLocal(Component var)
		{
			Value = var.transform.localRotation.eulerAngles;
		}

		public void SetValueRotationLocal(GameObject var)
		{
			Value = var.transform.localRotation.eulerAngles;
		}

		public void SetValueScale(Transform var)
		{
			Value = var.lossyScale;
		}

		public void SetValueScale(Component var)
		{
			Value = var.transform.lossyScale;
		}

		public void SetValueScale(GameObject var)
		{
			Value = var.transform.lossyScale;
		}

		public void SetValueScaleLocal(Transform var)
		{
			Value = var.localScale;
		}

		public void SetValueScaleLocal(Component var)
		{
			Value = var.transform.localScale;
		}

		public void SetValueScaleLocal(GameObject var)
		{
			Value = var.transform.localScale;
		}

		public void SetPosition(Transform var)
		{
			var.position = Value;
		}

		public void SetPositionLocal(Transform var)
		{
			var.localPosition = Value;
		}

		public void SetFromTransform_Up(Transform var)
		{
			Value = var.transform.up;
		}

		public void SetFromTransform_Down(Transform var)
		{
			Value = -var.transform.up;
		}

		public void SetFromTransform_Forward(Transform var)
		{
			Value = var.transform.up;
		}

		public void SetFromTransform_Backward(Transform var)
		{
			Value = -var.transform.forward;
		}

		public void SetFromTransform_Right(Transform var)
		{
			Value = var.transform.right;
		}

		public void SetFromTransform_Left(Transform var)
		{
			Value = -var.transform.right;
		}

		public void SetX(float var)
		{
			value.x = var;
		}

		public void SetY(float var)
		{
			value.y = var;
		}

		public void SetZ(float var)
		{
			value.z = var;
		}

		public static implicit operator Vector3(Vector3Var reference)
		{
			return reference.Value;
		}

		public static implicit operator Vector2(Vector3Var reference)
		{
			return reference.Value;
		}
	}
}
