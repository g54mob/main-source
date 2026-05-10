using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.MeshData
{
	[Serializable]
	public class MeshGroup
	{
		[SerializeField]
		private List<MeshRenderer> m_renderers;

		[SerializeField]
		private Material m_originalMaterial;

		[SerializeField]
		private MeshGroupMaterialType m_materialType;

		public int xlu => 0;

		public IReadOnlyList<MeshRenderer> xlv => null;

		public Material xlw => null;

		public MeshGroupMaterialType xlx => default(MeshGroupMaterialType);

		public IReadOnlyList<Material> iiw()
		{
			return null;
		}

		public void iix(Material a)
		{
		}

		public void iiy(bool a)
		{
		}

		private Material iiz(MeshRenderer a)
		{
			return null;
		}

		private void ija(MeshRenderer a, Material b)
		{
		}
	}
}
