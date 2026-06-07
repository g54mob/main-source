using UnityEngine;
using UnityEngine.Splines;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Transform/Spline Translator")]
	[SelectionBase]
	public class SplineTranslator : MSimpleTransformer
	{
		[Tooltip("Attach a Unity Spline here!")]
		[RequiredField]
		public SplineContainer spline;

		public Vector3 offset;

		public float Start;

		public float End = 1f;

		[Tooltip("Use the spline tangent to rotate the object along the trajectory")]
		public bool RotateAlongTanget = true;

		[Tooltip("Clear the Y Rotation of the Tangent")]
		public bool ClearYTangent;

		[Hide("RotateAlongTanget")]
		[Tooltip("Use the spline's up vector to orient the object.")]
		public bool UseSplineUpVector = true;

		private float difference;

		private void Awake()
		{
			base.Inverted = false;
			difference = End - Start;
		}

		public override void Evaluate(float curveValue)
		{
			if (spline == null || !(Object != null))
			{
				return;
			}
			float t = Mathf.Lerp(Start, End, m_Curve.Evaluate(curveValue)) % 1f;
			Vector3 position = spline.EvaluatePosition(t);
			if (RotateAlongTanget)
			{
				Vector3 vector = spline.EvaluateTangent(t);
				if (ClearYTangent)
				{
					vector = Vector3.ProjectOnPlane(vector, Vector3.up);
				}
				Vector3 upwards = (UseSplineUpVector ? ((Vector3)spline.EvaluateUpVector(t)) : Vector3.up);
				Quaternion quaternion2 = Quaternion.LookRotation(vector, upwards);
				Object.rotation = quaternion2 * Quaternion.Euler(offset);
			}
			if (!float.IsNaN(position.x))
			{
				Object.position = position;
			}
		}

		protected override void Pre_End()
		{
			if (loopType == LoopType.Once && endType == EndType.Additive)
			{
				Start += difference;
				End += difference;
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
			End = Start + difference;
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
			float end = End;
			float start = Start;
			Start = end;
			End = start;
			Evaluate(base.value);
			MTools.SetDirty(this);
		}
	}
}
