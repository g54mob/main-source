using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Shapes
{
	[AddComponentMenu("Curvy/Shapes/Circle")]
	[RequireComponent(typeof(CurvySpline))]
	[CurvyShapeInfo("2D/Circle", true)]
	public class CSCircle : CurvyShape2D
	{
		private const int MinCount = 2;

		[Positive(MinValue = 2f, Tooltip = "Number of Control Points")]
		[SerializeField]
		private int m_Count;

		[SerializeField]
		[Positive]
		private float m_Radius;

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

		protected override void ApplyShape()
		{
		}
	}
}
