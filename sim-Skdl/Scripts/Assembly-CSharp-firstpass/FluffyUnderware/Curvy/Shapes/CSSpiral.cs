using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Shapes
{
	[RequireComponent(typeof(CurvySpline))]
	[AddComponentMenu("Curvy/Shapes/Spiral")]
	[CurvyShapeInfo("3D/Spiral", false)]
	public class CSSpiral : CurvyShape2D
	{
		[SerializeField]
		[Positive(Tooltip = "Number of Control Points per full Circle")]
		private int m_Count;

		[Positive(Tooltip = "Number of Full Circles")]
		[SerializeField]
		private float m_Circles;

		[Positive(Tooltip = "Base Radius")]
		[SerializeField]
		private float m_Radius;

		[Label(Tooltip = "Radius Multiplicator")]
		[SerializeField]
		private AnimationCurve m_RadiusFactor;

		[SerializeField]
		private AnimationCurve m_Z;

		public int Count
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Circles
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationCurve RadiusFactor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AnimationCurve Z
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void ApplyShape()
		{
		}
	}
}
