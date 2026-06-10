using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.Tools;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.View
{
	public class AnimalPenView : NSEipix.Base.View
	{
		[SerializeField]
		private MeshFilter meshFilter;

		[SerializeField]
		private MeshRenderer meshRenderer;

		private AnimalPenInstance pen;

		private Vector3 center;

		private Mesh mesh;

		private float alpha;

		private float targetAlpha;

		private float speed = 1.15f;

		private bool refreshMeshScheduled;

		private void Update()
		{
			float num = speed * Time.unscaledDeltaTime;
			if (alpha > targetAlpha)
			{
				num *= -1f;
			}
			if (Mathf.Abs(num) > Mathf.Abs(targetAlpha - alpha))
			{
				num = Mathf.Sign(num) * Mathf.Abs(targetAlpha - alpha);
			}
			alpha += num;
			meshRenderer.material.SetColor("_StockpileColor", new Color(1f, 0.6f, 0.2f));
			meshRenderer.material.SetFloat("_Opacity", alpha);
			if (refreshMeshScheduled)
			{
				refreshMeshScheduled = false;
				RefreshMeshInstant();
			}
		}

		public void Init(AnimalPenInstance pen)
		{
			this.pen = pen;
			RefreshMeshInstant();
			alpha = 0.65f;
			targetAlpha = 0f;
		}

		public void OnSelected()
		{
			targetAlpha = 0.25f;
		}

		public void OnDeselected()
		{
			targetAlpha = 0f;
		}

		public void RefreshMesh()
		{
			refreshMeshScheduled = true;
		}

		private void RefreshMeshInstant()
		{
			HashSet<Vec3Int> hashSet = new HashSet<Vec3Int>();
			foreach (Region region in pen.Regions)
			{
				foreach (MapNode node in region.Nodes)
				{
					hashSet.Add(node.Position);
				}
			}
			int count = hashSet.Count;
			Vec3Int gridPos;
			if (count == 0)
			{
				gridPos = Vec3Int.zero;
			}
			else
			{
				Vec3Int a = Vec3Int.zero;
				foreach (Vec3Int item in hashSet)
				{
					a += item;
				}
				gridPos = a / count;
			}
			center = GridUtils.GetWorldPosition(gridPos);
			List<Vector3> vertices = new List<Vector3>();
			List<int> triangles = new List<int>();
			foreach (Vec3Int item2 in hashSet)
			{
				MeshDataUtils.AppendUnitQuad(ref vertices, ref triangles, GridUtils.GetWorldPosition(item2) - center);
			}
			if (mesh == null)
			{
				mesh = MeshDataUtils.ToMesh(ref vertices, ref triangles);
			}
			else
			{
				mesh.Clear(keepVertexLayout: false);
				mesh.SetVertices(vertices);
				mesh.SetTriangles(triangles, 0);
			}
			meshFilter.sharedMesh = mesh;
			base.transform.localPosition = center;
		}
	}
}
