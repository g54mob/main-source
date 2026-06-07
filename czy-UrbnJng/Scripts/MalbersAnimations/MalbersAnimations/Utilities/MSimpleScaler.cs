using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Transform/Simple Scaler")]
	[SelectionBase]
	public class MSimpleScaler : MSimpleTransformer
	{
		[ContextMenuItem("Invert", "InvertStartEnd")]
		public Vector3Reference startScale = new Vector3Reference(Vector3.one);

		[ContextMenuItem("Invert", "InvertStartEnd")]
		public Vector3Reference endScale = new Vector3Reference(new Vector3(1.5f, 1.5f, 1.5f));

		private Vector3 difference;

		private void Awake()
		{
			base.Inverted = false;
			difference = endScale.Value - startScale.Value;
		}

		public override void Evaluate(float position)
		{
			Object.localScale = Vector3.LerpUnclamped(startScale, endScale, m_Curve.Evaluate(position));
		}

		protected override void Pre_End()
		{
			if (loopType == LoopType.Once && endType == EndType.Additive)
			{
				startScale.Value = endScale.Value;
				endScale.Value += difference;
			}
		}

		protected override void Pos_End()
		{
			if (loopType == LoopType.Once && endType == EndType.Invert)
			{
				InvertStartEnd();
			}
		}

		public void Invert_Value()
		{
			if (base.Playing)
			{
				Debug.Log("Cannot invert value while playing");
				return;
			}
			base.Inverted = !base.Inverted;
			difference *= -1f;
			endScale.Value = startScale.Value + difference;
			Debug.Log("Position Value Inverted");
		}

		public void Invert_Value_Positive()
		{
			if (base.Inverted)
			{
				Invert_Value();
			}
		}

		public void Invert_Value_Negative()
		{
			if (!base.Inverted)
			{
				Invert_Value();
			}
		}

		private void InvertStartEnd()
		{
			Vector3Reference vector3Reference = startScale;
			Vector3Reference vector3Reference2 = endScale;
			Vector3 vector = endScale.Value;
			Vector3 vector2 = startScale.Value;
			Vector3 vector3 = (vector3Reference.Value = vector);
			vector3 = (vector3Reference2.Value = vector2);
			Evaluate(0f);
			MTools.SetDirty(this);
		}

		protected override void Reset()
		{
			base.Reset();
			if (startScale.UseConstant)
			{
				startScale.Value = Object.localScale;
			}
		}
	}
}
