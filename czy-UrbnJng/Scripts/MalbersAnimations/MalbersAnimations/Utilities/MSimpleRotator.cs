using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Transform/Simple Rotator")]
	[SelectionBase]
	public class MSimpleRotator : MSimpleTransformer
	{
		public Vector3Reference axis = new Vector3Reference(Vector3.up);

		[ContextMenuItem("Invert", "InvertStartEnd")]
		public FloatReference startAngle;

		[ContextMenuItem("Invert", "InvertStartEnd")]
		public FloatReference endAngle = new FloatReference(90f);

		private float difference;

		private void Awake()
		{
			base.Inverted = false;
			difference = (float)endAngle - (float)startAngle;
		}

		public override void Evaluate(float value)
		{
			float t = m_Curve.Evaluate(value);
			Quaternion localRotation = Quaternion.AngleAxis(Mathf.LerpUnclamped(startAngle, endAngle, t), axis);
			Object.localRotation = localRotation;
		}

		protected override void Pre_End()
		{
			if (loopType == LoopType.Once && endType == EndType.Additive)
			{
				startAngle.Value = endAngle.Value;
				endAngle.Value += difference;
			}
		}

		protected override void Pos_End()
		{
			if (loopType == LoopType.Once && endType == EndType.Invert)
			{
				InvertStartEnd();
			}
		}

		[ContextMenu("Invert Value")]
		public void Invert_Value()
		{
			if (base.Playing)
			{
				Debug.Log("Cannot invert value while playing");
				return;
			}
			base.Inverted = !base.Inverted;
			difference *= -1f;
			endAngle.Value = startAngle.Value + difference;
		}

		[ContextMenu("Invert Value +")]
		public void Invert_Value_Positive()
		{
			if (base.Inverted)
			{
				Invert_Value();
			}
		}

		[ContextMenu("Invert Value -")]
		public void Invert_Value_Negative()
		{
			if (!base.Inverted)
			{
				Invert_Value();
			}
		}

		[ContextMenu("Invert Start - End")]
		private void InvertStartEnd()
		{
			FloatReference floatReference = startAngle;
			FloatReference floatReference2 = endAngle;
			float num = endAngle.Value;
			float num2 = startAngle.Value;
			float num3 = (floatReference.Value = num);
			num3 = (floatReference2.Value = num2);
			Evaluate(base.value);
			MTools.SetDirty(this);
		}
	}
}
