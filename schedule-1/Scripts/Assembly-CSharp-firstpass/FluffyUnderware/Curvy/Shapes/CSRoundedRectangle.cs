using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Shapes
{
	[CurvyShapeInfo("2D/Rounded Rectangle", true)]
	[RequireComponent(typeof(CurvySpline))]
	[AddComponentMenu("Curvy/Shapes/Rounded Rectangle")]
	public class CSRoundedRectangle : CurvyShape2D
	{
		[SerializeField]
		[Positive]
		private float m_Width;

		[SerializeField]
		[Positive]
		private float m_Height;

		[Range(0f, 1f)]
		[SerializeField]
		private float m_Roundness;

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Roundness
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
