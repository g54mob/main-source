using System;
using UnityEngine;

namespace CritiasFoliage
{
	[Serializable]
	public class FoliageType
	{
		public int m_Hash;

		public string m_Name;

		public FoliageTypeRuntimeData m_RuntimeData;

		public Bounds m_Bounds;

		[SerializeField]
		private EFoliageType m_Type;

		[SerializeField]
		private bool m_IsGrassType;

		[SerializeField]
		private bool m_IsSpeedTreeType;

		[SerializeField]
		private EFoliageRenderType m_RenderType;

		[SerializeField]
		private bool m_RenderIndirect;

		public GameObject m_Prefab;

		public FoliageTypeRenderInfo m_RenderInfo;

		public bool m_EnableCollision;

		public bool m_EnableBend;

		public float m_BendDistance = 1f;

		public float m_BendPower = 2f;

		private bool m_RuntimeDataCreated;

		public EFoliageType Type
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type = value;
				switch (m_Type)
				{
				case EFoliageType.SPEEDTREE_GRASS:
				case EFoliageType.OTHER_GRASS:
					m_IsGrassType = true;
					break;
				case EFoliageType.SPEEDTREE_TREE:
				case EFoliageType.SPEEDTREE_TREE_BILLBOARD:
				case EFoliageType.OTHER_TREE:
					m_IsGrassType = false;
					break;
				}
				if (m_Type == EFoliageType.SPEEDTREE_GRASS || m_Type == EFoliageType.SPEEDTREE_TREE || m_Type == EFoliageType.SPEEDTREE_TREE_BILLBOARD)
				{
					m_IsSpeedTreeType = true;
				}
				else
				{
					m_IsSpeedTreeType = false;
				}
				if (m_RenderType == EFoliageRenderType.INSTANCED_INDIRECT && !m_IsGrassType)
				{
					RenderType = EFoliageRenderType.INSTANCED;
				}
			}
		}

		public EFoliageRenderType RenderType
		{
			get
			{
				return m_RenderType;
			}
			set
			{
				m_RenderType = value;
				m_RenderIndirect = value == EFoliageRenderType.INSTANCED_INDIRECT;
			}
		}

		public bool RenderIndirect => m_RenderIndirect;

		public bool IsGrassType => m_IsGrassType;

		public bool IsSpeedTreeType => m_IsSpeedTreeType;

		public bool IsRuntimeInitialized
		{
			get
			{
				return m_RuntimeDataCreated;
			}
			set
			{
				m_RuntimeDataCreated = true;
			}
		}

		public void UpdateValues()
		{
			if (m_IsSpeedTreeType)
			{
				FoliageTypeSpeedTreeData speedTreeData = m_RuntimeData.m_SpeedTreeData;
				Material billboardMaterial = m_RuntimeData.m_SpeedTreeData.m_BillboardMaterial;
				if (billboardMaterial != null)
				{
					billboardMaterial.SetFloat("CRITIAS_MaxFoliageTypeDistance", m_RenderInfo.m_MaxDistance);
					billboardMaterial.SetFloat("CRITIAS_MaxFoliageTypeDistanceSqr", m_RenderInfo.m_MaxDistance * m_RenderInfo.m_MaxDistance);
					billboardMaterial.SetVectorArray("_UVVert_U", speedTreeData.m_VertBillboardU);
					billboardMaterial.SetVectorArray("_UVVert_V", speedTreeData.m_VertBillboardV);
					billboardMaterial.SetVector("_UVHorz_U", speedTreeData.m_VertBillboardU[0]);
					billboardMaterial.SetVector("_UVHorz_V", speedTreeData.m_VertBillboardV[0]);
					billboardMaterial.SetColor("_HueVariation", m_RenderInfo.m_Hue);
					billboardMaterial.SetColor("_Color", m_RenderInfo.m_Color);
				}
				if (m_IsGrassType)
				{
					m_RuntimeData.m_LODDataGrass.m_Material.SetColor("_HueVariation", m_RenderInfo.m_Hue);
					m_RuntimeData.m_LODDataGrass.m_Material.SetColor("_Color", m_RenderInfo.m_Color);
				}
				else
				{
					for (int i = 0; i < m_RuntimeData.m_LODDataTree.Length; i++)
					{
						for (int j = 0; j < m_RuntimeData.m_LODDataTree[i].m_Materials.Length; j++)
						{
							m_RuntimeData.m_LODDataTree[i].m_Materials[j].SetColor("_Color", m_RenderInfo.m_Color);
						}
					}
				}
			}
			if (!IsGrassType)
			{
				LODGroup component = m_Prefab.GetComponent<LODGroup>();
				LOD[] groupLods = ((component != null) ? component.GetLODs() : null);
				FoliageTypeUtilities.UpdateDistancesLOD(m_RuntimeData.m_LODDataTree, groupLods, m_RenderInfo.m_MaxDistance, m_RenderInfo.m_LODTransition, IsSpeedTreeType);
			}
		}

		public void CopyBlock()
		{
			m_RuntimeData.CopyBlock();
		}
	}
}
