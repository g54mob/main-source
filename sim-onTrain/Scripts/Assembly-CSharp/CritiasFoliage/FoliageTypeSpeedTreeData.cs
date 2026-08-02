using System;
using UnityEngine;

namespace CritiasFoliage
{
	[Serializable]
	public class FoliageTypeSpeedTreeData
	{
		public GameObject m_SpeedTreeWindObject;

		public MeshRenderer m_SpeedTreeWindObjectMesh;

		public Vector4 m_Size;

		public Vector4[] m_VertBillboardU;

		public Vector4[] m_VertBillboardV;

		public BillboardRenderer m_BillboardRenderer;

		public Material m_BillboardMaterial;
	}
}
