using System.Collections.Generic;
using Jundroo.Common.Meshes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class AdaptiveNoseConeScript : PartModifierScript
	{
		private class AdaptiveVertex
		{
			public bool Corner { get; set; }

			public int Index { get; set; }

			public Vector3 OriginalVertex { get; set; }

			public AdaptiveVertex(Vector3 v, int index, bool corner)
			{
				OriginalVertex = v;
				Index = index;
				Corner = corner;
			}
		}

		private List<AdaptiveVertex> _adaptiveVertices = new List<AdaptiveVertex>();

		private MeshFilter _meshFilter;

		public AdaptiveNoseConeData AdaptiveNoseCone { get; set; }

		public void OnModifierInitialized()
		{
			_meshFilter = base.transform.Find("Mesh").GetComponent<MeshFilter>();
			Vector3[] vertices = _meshFilter.mesh.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 v = vertices[i];
				if (Utilities.CompareFloats(v.x, 0f, 0.01f))
				{
					if (Utilities.CompareFloats(Mathf.Abs(v.y), 0.2f, 0.01f) || Utilities.CompareFloats(Mathf.Abs(v.z), 0.2f, 0.01f))
					{
						AdaptiveVertex item = new AdaptiveVertex(v, i, corner: true);
						_adaptiveVertices.Add(item);
					}
					else if (Utilities.CompareFloats(Mathf.Abs(v.y), 0.125f, 0.01f) || Utilities.CompareFloats(Mathf.Abs(v.z), 0.125f, 0.01f))
					{
						AdaptiveVertex item2 = new AdaptiveVertex(v, i, corner: false);
						_adaptiveVertices.Add(item2);
					}
				}
			}
		}

		public void SetScale(Vector3 scale)
		{
			AdaptiveNoseCone.Scale = scale;
			base.transform.localScale = scale;
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				if (scale.x > 1f || scale.y > 1f || scale.z > 0f)
				{
					float z = -0.25f;
					Vector3 vector = new Vector3(scale.x / 4f - 0.25f, scale.y / 4f - 0.25f, z);
					base.PartScript.AttachPointScripts[0].gameObject.SetActive(value: true);
					base.PartScript.AttachPointScripts[1].gameObject.SetActive(value: true);
					base.PartScript.AttachPointScripts[2].gameObject.SetActive(value: true);
					base.PartScript.AttachPointScripts[3].gameObject.SetActive(value: true);
					base.PartScript.AttachPointScripts[0].transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
					base.PartScript.AttachPointScripts[1].transform.localPosition = new Vector3(0f - vector.x, vector.y, vector.z);
					base.PartScript.AttachPointScripts[2].transform.localPosition = new Vector3(0f - vector.x, 0f - vector.y, vector.z);
					base.PartScript.AttachPointScripts[3].transform.localPosition = new Vector3(vector.x, 0f - vector.y, vector.z);
				}
				else
				{
					base.PartScript.AttachPointScripts[0].gameObject.SetActive(value: false);
					base.PartScript.AttachPointScripts[1].gameObject.SetActive(value: false);
					base.PartScript.AttachPointScripts[2].gameObject.SetActive(value: false);
					base.PartScript.AttachPointScripts[3].gameObject.SetActive(value: false);
				}
			}
			UpdateMesh(scale);
		}

		private void UpdateMesh(Vector3 scale)
		{
			Vector3[] vertices = _meshFilter.mesh.vertices;
			foreach (AdaptiveVertex adaptiveVertex in _adaptiveVertices)
			{
				Vector3 originalVertex = adaptiveVertex.OriginalVertex;
				float num = 0.25f - Mathf.Abs(originalVertex.y);
				float num2 = 0.25f - Mathf.Abs(originalVertex.z);
				float num3 = originalVertex.y / Mathf.Abs(originalVertex.y);
				float num4 = originalVertex.z / Mathf.Abs(originalVertex.z);
				originalVertex.y = num3 * (0.25f - num / scale.y);
				originalVertex.z = num4 * (0.25f - num2 / scale.x);
				vertices[adaptiveVertex.Index] = originalVertex;
			}
			_meshFilter.mesh.vertices = vertices;
			NormalSolver.RecalculateNormals(_meshFilter.mesh, 60f, 0);
		}
	}
}
