using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Shapes
{
	[AddComponentMenu("Curvy/Shapes/Rounded Rectangle")]
	[RequireComponent(typeof(CurvySpline))]
	[CurvyShapeInfo("2D/Rounded Rectangle", true)]
	public class CSRoundedRectangle : CurvyShape2D
	{
		[SerializeField]
		[Positive]
		private float m_Width;

		[Positive]
		[SerializeField]
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
