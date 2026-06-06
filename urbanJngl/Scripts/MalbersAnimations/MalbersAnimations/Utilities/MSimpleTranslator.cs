using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Transform/Simple Translator")]
	[SelectionBase]
	public class MSimpleTranslator : MSimpleTransformer
	{
		[ContextMenuItem("Invert", "InvertStartEnd")]
		public Vector3Reference start;

		[ContextMenuItem("Invert", "InvertStartEnd")]
		public Vector3Reference end = new Vector3Reference(new Vector3(0f, 2f, 0f));

		public bool Gizmos = true;

		private Vector3 difference;

		private void Awake()
		{
			base.Inverted = false;
			difference = end.Value - start.Value;
		}

		public override void Evaluate(float curveValue)
		{
			float t = m_Curve.Evaluate(curveValue);
			Vector3 position = base.transform.TransformPoint(Vector3.Lerp(start, end, t));
			Object.position = position;
		}

		protected override void Pre_End()
		{
			if (loopType == LoopType.Once && endType == EndType.Additive)
			{
				start.Value = end.Value;
				end.Value += difference;
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
				Debug.Log("Cannot invert value while playing. Use this when Star and End Delay is greater than zero");
				return;
			}
			base.Inverted = !base.Inverted;
			difference *= -1f;
			end.Value = start.Value + difference;
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
			Vector3Reference vector3Reference = start;
			Vector3Reference vector3Reference2 = end;
			Vector3 vector = end.Value;
			Vector3 vector2 = start.Value;
			Vector3 vector3 = (vector3Reference.Value = vector);
			vector3 = (vector3Reference2.Value = vector2);
			Evaluate(base.value);
			MTools.SetDirty(this);
		}
	}
}
