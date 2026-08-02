using System;
using UnityEngine;

namespace CritiasFoliage
{
	[Serializable]
	public class FoliagePaintParameters
	{
		[Range(1f, 100f)]
		public float m_BrushSize = 2f;

		[Range(1f, 100f)]
		public float m_FoliageDensity = 50f;

		public bool m_SlopeFilter;

		public Vector2 m_SlopeAngles = new Vector2(0f, 180f);

		public bool m_ScaleUniform = true;

		public Vector2 m_ScaleUniformXYZ = new Vector2(1f, 1f);

		public Vector2 m_ScaleX = new Vector2(1f, 1f);

		public Vector2 m_ScaleY = new Vector2(1f, 1f);

		public Vector2 m_ScaleZ = new Vector2(1f, 1f);

		public bool m_RotateYOnly = true;

		public Vector2 m_RandomRotation = new Vector2(0f, 360f);

		public bool m_StaticOnly;
	}
}
