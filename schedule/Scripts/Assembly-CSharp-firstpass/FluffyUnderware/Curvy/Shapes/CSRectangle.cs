using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Shapes
{
	[AddComponentMenu("Curvy/Shapes/Rectangle")]
	[RequireComponent(typeof(CurvySpline))]
	[CurvyShapeInfo("2D/Rectangle", true)]
	public class CSRectangle : CurvyShape2D
	{
		[SerializeField]
		[Positive]
		private float m_Width;

		[SerializeField]
		[Positive]
		private float m_Height;

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

		protected override void ApplyShape()
		{
		}
	}
}
