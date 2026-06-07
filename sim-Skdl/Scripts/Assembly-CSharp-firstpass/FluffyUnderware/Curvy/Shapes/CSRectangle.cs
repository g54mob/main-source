using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Shapes
{
	[CurvyShapeInfo("2D/Rectangle", true)]
	[RequireComponent(typeof(CurvySpline))]
	[AddComponentMenu("Curvy/Shapes/Rectangle")]
	public class CSRectangle : CurvyShape2D
	{
		[Positive]
		[SerializeField]
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
