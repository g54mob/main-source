using System.Collections.Generic;
using DV.OriginShift;
using UnityEngine;

namespace DV.WorldTools
{
	public class DistantTerrain : MonoBehaviour
	{
		public Transform trackingReference;

		public float step = 16f;

		public float worldScale = 16384f;

		public float singleTerrainSize = 256f;

		private Vector4 currentScaleOffset;

		private List<Material> materials = new List<Material>();

		private int initiallyDisabledCount;

		private void Start()
		{
			for (int i = 0; i < base.transform.childCount && !base.transform.GetChild(i).gameObject.activeSelf; i++)
			{
				initiallyDisabledCount++;
			}
			FindMaterials();
			UpdateBounds();
		}

		private void OnDisable()
		{
			currentScaleOffset = new Vector4(worldScale, worldScale, 0f, 0f);
			UpdateMaterials();
		}

		private void FindMaterials()
		{
			materials.Clear();
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (IsTerrainMesh(meshRenderer) && !materials.Contains(meshRenderer.sharedMaterial))
				{
					materials.Add(meshRenderer.sharedMaterial);
				}
			}
		}

		private void UpdateMaterials()
		{
			foreach (Material material in materials)
			{
				if (material.HasProperty("_MapScaleOffset"))
				{
					material.SetVector("_MapScaleOffset", currentScaleOffset);
				}
			}
		}

		private void UpdateBounds()
		{
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (IsTerrainMesh(meshRenderer))
				{
					MeshFilter component = meshRenderer.GetComponent<MeshFilter>();
					Bounds bounds = component.sharedMesh.bounds;
					component.sharedMesh.bounds = new Bounds(new Vector3(bounds.center.x, 500f, bounds.center.z), new Vector3(bounds.size.x, 1000f, bounds.size.z));
				}
			}
		}

		private bool IsTerrainMesh(MeshRenderer mr)
		{
			if ((bool)mr.sharedMaterial)
			{
				return mr.sharedMaterial.HasProperty("_WorldNormalmap");
			}
			return false;
		}

		private void LateUpdate()
		{
			if (trackingReference != null)
			{
				Vector3 vector = trackingReference.AbsolutePosition();
				float a = Mathf.Min(vector.x, vector.z);
				a = Mathf.Min(a, worldScale - vector.x);
				a = Mathf.Min(a, worldScale - vector.z);
				for (int i = 0; i < initiallyDisabledCount; i++)
				{
					bool flag = (float)(i + 1) * singleTerrainSize + 1f > a;
					GameObject gameObject = base.transform.GetChild(i).gameObject;
					if (gameObject.activeSelf != flag)
					{
						gameObject.SetActive(flag);
					}
				}
			}
			Vector3 position = base.transform.position;
			position.x = (float)Mathf.RoundToInt(trackingReference.position.x / step) * step;
			position.z = (float)Mathf.RoundToInt(trackingReference.position.z / step) * step;
			base.transform.position = position;
			Vector3 currentMove = DV.OriginShift.OriginShift.currentMove;
			Vector4 vector2 = new Vector4(worldScale, worldScale, 0f - currentMove.x, 0f - currentMove.z);
			if (vector2 != currentScaleOffset)
			{
				currentScaleOffset = vector2;
				UpdateMaterials();
			}
		}
	}
}
