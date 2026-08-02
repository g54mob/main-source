using System;
using UnityEngine;

namespace CritiasFoliage
{
	[Serializable]
	public class FoliageTypeRuntimeData
	{
		public FoliageTypeLODTree[] m_LODDataTree;

		public FoliageTypeLODGrass m_LODDataGrass;

		public MaterialPropertyBlock m_TypeMPB;

		public FoliageTypeSpeedTreeData m_SpeedTreeData;

		public void CopyBlock()
		{
			m_SpeedTreeData.m_SpeedTreeWindObjectMesh.GetPropertyBlock(m_TypeMPB);
		}
	}
}
