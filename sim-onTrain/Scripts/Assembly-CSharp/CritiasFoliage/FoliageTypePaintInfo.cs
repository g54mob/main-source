using System;
using UnityEngine;

namespace CritiasFoliage
{
	[Serializable]
	public class FoliageTypePaintInfo
	{
		public bool m_SurfaceAlign;

		public Vector2 m_SurfaceAlignInfluence = new Vector2(1f, 1f);

		public Vector2 m_YOffset = new Vector2(0f, 0f);

		public bool m_PaintEnabled;
	}
}
