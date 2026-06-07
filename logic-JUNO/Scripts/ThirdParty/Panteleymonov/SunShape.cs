using UnityEngine;

namespace Panteleymonov
{
	[ExecuteInEditMode]
	[AddComponentMenu("Space/Star/SunShape")]
	public class SunShape : MonoBehaviour
	{
		public enum EMeshType
		{
			Billboard = 0,
			Prisma = 1
		}

		[Tooltip("Model of mesh for view body, Billboard, Prisma")]
		public EMeshType MeshType = EMeshType.Prisma;

		private void Start()
		{
			Build();
		}

		private void Update()
		{
		}

		private void OnValidate()
		{
			Build();
		}

		public void Build()
		{
			if (MeshType == EMeshType.Billboard)
			{
				MeshBillboard();
			}
			if (MeshType == EMeshType.Prisma)
			{
				MeshPrisma();
			}
			MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			Material[] sharedMaterials = meshRenderer.sharedMaterials;
			if (sharedMaterials[0] != null)
			{
				float num = (sharedMaterials[0].GetFloat("_Radius") + sharedMaterials[0].GetFloat("_RayString")) / sharedMaterials[0].GetFloat("_Zoom");
				if (float.IsNaN(num))
				{
					num = 1f;
				}
				base.transform.localScale = new Vector3(num, num, num);
			}
		}

		private MeshFilter PrepeareMesh()
		{
			MeshFilter meshFilter = GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			meshFilter.sharedMesh = new Mesh();
			meshFilter.sharedMesh.Clear();
			return meshFilter;
		}

		private void MeshBillboard()
		{
			PrepeareMesh().sharedMesh = SunGenerator.GetBilboard();
		}

		private void MeshPrisma()
		{
			PrepeareMesh().sharedMesh = SunGenerator.GetPrisma();
		}
	}
}
