using System;
using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.Construction
{
	[Serializable]
	public class SlotMeshFilterPair
	{
		[SerializeField]
		private string slotName;

		[SerializeField]
		private List<MeshFilter> meshFilters;

		private Dictionary<MeshFilter, Vector3> originalScaleByMeshFilter = new Dictionary<MeshFilter, Vector3>();

		private Dictionary<MeshFilter, Quaternion> originalRotationByMeshFilter = new Dictionary<MeshFilter, Quaternion>();

		public string SlotName => slotName;

		public List<MeshFilter> MeshFilters => meshFilters;

		public Vector3 GetOriginalScale(MeshFilter meshFilter)
		{
			if (!originalScaleByMeshFilter.ContainsKey(meshFilter))
			{
				originalScaleByMeshFilter.Add(meshFilter, meshFilter.transform.localScale);
			}
			return originalScaleByMeshFilter[meshFilter];
		}

		public Quaternion GetOriginalRotation(MeshFilter meshFilter)
		{
			if (!originalRotationByMeshFilter.ContainsKey(meshFilter))
			{
				originalRotationByMeshFilter.Add(meshFilter, meshFilter.transform.localRotation);
			}
			return originalRotationByMeshFilter[meshFilter];
		}

		public void ApplyFilter(MeshFilter meshFilter)
		{
			meshFilters.Add(meshFilter);
		}

		public void ApplyMeshById(string meshAddress)
		{
			Mesh meshByAddress = MonoRepository<MeshRepository, KeyGameObjectPair>.Instance.GetMeshByAddress(meshAddress);
			ApplyMesh(meshByAddress);
		}

		public void ApplyMesh(Mesh mesh)
		{
			foreach (MeshFilter meshFilter in meshFilters)
			{
				if (!(meshFilter == null))
				{
					meshFilter.sharedMesh = mesh;
				}
			}
		}

		public void ApplyRotation(float rotation, bool flipX, bool flipZ)
		{
			foreach (MeshFilter meshFilter in meshFilters)
			{
				if (!(meshFilter == null))
				{
					meshFilter.transform.localRotation = GetOriginalRotation(meshFilter) * Quaternion.Euler(Vector3.up * rotation);
					Vector3 originalScale = GetOriginalScale(meshFilter);
					meshFilter.transform.localScale = Vector3.right * (originalScale.x * (flipX ? (-1f) : 1f)) + Vector3.up * originalScale.y + Vector3.forward * (originalScale.z * (flipZ ? (-1f) : 1f));
				}
			}
		}
	}
}
