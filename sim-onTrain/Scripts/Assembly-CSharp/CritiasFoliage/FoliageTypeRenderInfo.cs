using System;
using UnityEngine;

namespace CritiasFoliage
{
	[Serializable]
	public struct FoliageTypeRenderInfo
	{
		public float m_MaxDistance;

		public float m_LODTransition;

		public bool m_CastShadow;

		public Color m_Hue;

		public Color m_Color;
	}
}
