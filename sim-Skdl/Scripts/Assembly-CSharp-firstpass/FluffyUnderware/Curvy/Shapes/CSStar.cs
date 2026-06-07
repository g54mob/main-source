using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Shapes
{
	[CurvyShapeInfo("2D/Star", true)]
	[RequireComponent(typeof(CurvySpline))]
	[AddComponentMenu("Curvy/Shapes/Star")]
	public class CSStar : CurvyShape2D
	{
		private const int MinSides = 2;

		[SerializeField]
		[Positive(Tooltip = "Number of Sides", MinValue = 2f)]
		private int m_Sides;

		[SerializeField]
		[Positive]
		private float m_OuterRadius;

		[SerializeField]
		[RangeEx(0f, 1f, null, null)]
		private float m_OuterRoundness;

		[SerializeField]
		[Positive]
		private float m_InnerRadius;

		[SerializeField]
		[RangeEx(0f, 1f, null, null)]
		private float m_InnerRoundness;

		public int Sides
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float OuterRadius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OuterRoundness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float InnerRadius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float InnerRoundness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void OnValidate()
		{
		}

		protected override void ApplyShape()
		{
		}
	}
}
