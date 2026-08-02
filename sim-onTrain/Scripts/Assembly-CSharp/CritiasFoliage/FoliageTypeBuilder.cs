using UnityEngine;

namespace CritiasFoliage
{
	public struct FoliageTypeBuilder
	{
		public EFoliageType m_Type;

		public GameObject m_Prefab;

		public Bounds m_Bounds;

		public FoliageTypeRenderInfo m_RenderInfo;

		public bool m_EnableCollision;

		public bool m_PaintEnabled;

		public FoliageTypePaintInfo m_PaintInfo;
	}
}
