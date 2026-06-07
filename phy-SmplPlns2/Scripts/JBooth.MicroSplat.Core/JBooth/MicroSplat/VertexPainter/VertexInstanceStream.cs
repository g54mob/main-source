using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace JBooth.MicroSplat.VertexPainter
{
	[ExecuteInEditMode]
	public class VertexInstanceStream : MonoBehaviour
	{
		public bool keepRuntimeData;

		[HideInInspector]
		[SerializeField]
		private Color[] _colors;

		[HideInInspector]
		[SerializeField]
		private List<Vector4> _uv1;

		[HideInInspector]
		[SerializeField]
		private List<Vector4> _uv2;

		[HideInInspector]
		[SerializeField]
		private Vector3[] _positions;

		private bool enforcedColorChannels;

		private Mesh meshStream;

		public Color[] colors
		{
			get
			{
				return _colors;
			}
			set
			{
				enforcedColorChannels = _colors != null && (value == null || _colors.Length == value.Length);
				_colors = value;
				Apply();
			}
		}

		public List<Vector4> uv1
		{
			get
			{
				return _uv1;
			}
			set
			{
				_uv1 = value;
				Apply();
			}
		}

		public List<Vector4> uv2
		{
			get
			{
				return _uv2;
			}
			set
			{
				_uv2 = value;
				Apply();
			}
		}

		public Vector3[] positions
		{
			get
			{
				return _positions;
			}
			set
			{
				_positions = value;
				Apply();
			}
		}

		private void Start()
		{
			Apply(!keepRuntimeData);
			if (keepRuntimeData)
			{
				MeshFilter component = GetComponent<MeshFilter>();
				_positions = component.sharedMesh.vertices;
			}
		}

		private void OnDestroy()
		{
			if (!Application.isPlaying)
			{
				MeshRenderer component = GetComponent<MeshRenderer>();
				if (component != null)
				{
					component.additionalVertexStreams = null;
				}
			}
		}

		private void EnforceOriginalMeshHasColors(Mesh stream)
		{
			if (!enforcedColorChannels)
			{
				enforcedColorChannels = true;
				MeshFilter component = GetComponent<MeshFilter>();
				Color[] array = component.sharedMesh.colors;
				if (stream != null && stream.colors.Length != 0 && (array == null || array.Length == 0))
				{
					component.sharedMesh.colors = stream.colors;
				}
			}
		}

		public Mesh Apply(bool markNoLongerReadable = true)
		{
			MeshRenderer component = GetComponent<MeshRenderer>();
			MeshFilter component2 = GetComponent<MeshFilter>();
			if (component != null && component2 != null && component2.sharedMesh != null)
			{
				int vertexCount = component2.sharedMesh.vertexCount;
				Mesh mesh = meshStream;
				if (mesh == null || vertexCount != mesh.vertexCount)
				{
					if (mesh != null)
					{
						Object.DestroyImmediate(mesh);
					}
					IndexFormat indexFormat = component2.sharedMesh.indexFormat;
					mesh = new Mesh();
					mesh.indexFormat = indexFormat;
					mesh.vertices = new Vector3[component2.sharedMesh.vertexCount];
					mesh.vertices = component2.sharedMesh.vertices;
					mesh.MarkDynamic();
					mesh.triangles = component2.sharedMesh.triangles;
					meshStream = mesh;
					mesh.hideFlags = HideFlags.HideAndDontSave;
				}
				if (_positions != null && _positions.Length == vertexCount)
				{
					mesh.vertices = _positions;
				}
				if (_colors != null && _colors.Length == vertexCount)
				{
					mesh.colors = _colors;
				}
				else
				{
					mesh.colors = null;
				}
				if (_uv1 != null && _uv1.Count == vertexCount)
				{
					mesh.SetUVs(1, _uv1);
				}
				else
				{
					mesh.uv2 = null;
				}
				if (_uv2 != null && _uv2.Count == vertexCount)
				{
					mesh.SetUVs(2, _uv2);
				}
				else
				{
					mesh.uv3 = null;
				}
				EnforceOriginalMeshHasColors(mesh);
				if (!Application.isPlaying || Application.isEditor)
				{
					markNoLongerReadable = false;
				}
				mesh.UploadMeshData(markNoLongerReadable);
				component.additionalVertexStreams = mesh;
				return mesh;
			}
			return null;
		}
	}
}
