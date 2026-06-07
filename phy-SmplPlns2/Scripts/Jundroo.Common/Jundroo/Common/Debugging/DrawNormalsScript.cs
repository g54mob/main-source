using System;
using UnityEngine;

namespace Jundroo.Common.Debugging
{
	public class DrawNormalsScript : MonoBehaviour
	{
		[Serializable]
		private class NormalsDrawData
		{
			protected enum DrawType
			{
				Never = 0,
				Selected = 1,
				Always = 2
			}

			[SerializeField]
			protected DrawType _draw = DrawType.Selected;

			[SerializeField]
			protected float _length = 0.3f;

			[SerializeField]
			protected Color _normalColor;

			private const float _baseSize = 0.0125f;

			private Color _baseColor = new Color32(byte.MaxValue, 133, 0, byte.MaxValue);

			public NormalsDrawData(Color normalColor, bool draw)
			{
				_normalColor = normalColor;
				_draw = (draw ? DrawType.Selected : DrawType.Never);
			}

			public bool CanDraw(bool isSelected)
			{
				if (_draw != DrawType.Always)
				{
					return _draw == DrawType.Selected && isSelected;
				}
				return true;
			}

			public void Draw(Vector3 from, Vector3 direction)
			{
				Gizmos.color = _baseColor;
				Gizmos.DrawWireSphere(from, 0.0125f);
				Gizmos.color = _normalColor;
				Gizmos.DrawRay(from, direction * _length);
			}
		}

		[SerializeField]
		private NormalsDrawData _faceNormals = new NormalsDrawData(new Color32(34, 221, 221, 155), draw: false);

		[SerializeField]
		private MeshFilter _meshFilter;

		[SerializeField]
		private NormalsDrawData _vertexNormals = new NormalsDrawData(new Color32(200, byte.MaxValue, 195, 127), draw: true);

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
			OnDrawNormals(isSelected: true);
		}

		private void OnDrawNormals(bool isSelected)
		{
			if (_meshFilter == null)
			{
				_meshFilter = GetComponent<MeshFilter>();
				if (_meshFilter == null)
				{
					return;
				}
			}
			Mesh sharedMesh = _meshFilter.sharedMesh;
			if (_faceNormals.CanDraw(isSelected))
			{
				int[] triangles = sharedMesh.triangles;
				Vector3[] vertices = sharedMesh.vertices;
				for (int i = 0; i < triangles.Length; i += 3)
				{
					Vector3 vector = base.transform.TransformPoint(vertices[triangles[i]]);
					Vector3 vector2 = base.transform.TransformPoint(vertices[triangles[i + 1]]);
					Vector3 vector3 = base.transform.TransformPoint(vertices[triangles[i + 2]]);
					Vector3 vector4 = (vector + vector2 + vector3) / 3f;
					Vector3 direction = Vector3.Cross(vector2 - vector, vector3 - vector);
					direction /= direction.magnitude;
					_faceNormals.Draw(vector4, direction);
				}
			}
			if (_vertexNormals.CanDraw(isSelected))
			{
				Vector3[] vertices2 = sharedMesh.vertices;
				Vector3[] normals = sharedMesh.normals;
				for (int j = 0; j < vertices2.Length; j++)
				{
					_vertexNormals.Draw(base.transform.TransformPoint(vertices2[j]), base.transform.TransformVector(normals[j]));
				}
			}
		}
	}
}
