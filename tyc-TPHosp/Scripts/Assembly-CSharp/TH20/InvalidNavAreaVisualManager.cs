using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class InvalidNavAreaVisualManager : MustCallDestroy
	{
		private RoomItemVisualEdit.Config _roomItemEditConfig;

		private readonly GameObject _gameObject;

		private readonly MeshFilter _meshFilter;

		private readonly MeshRenderer _meshRenderer;

		private float _alpha;

		private readonly MaterialPropertyBlock _materialPropertyBlock;

		public InvalidNavAreaVisualManager(RoomItemVisualEdit.Config roomItemEditConfig)
		{
			_roomItemEditConfig = roomItemEditConfig;
			_gameObject = new GameObject("Nav Fail Visual");
			_gameObject.transform.position = Vector3.zero;
			_gameObject.transform.rotation = Quaternion.identity;
			_meshFilter = _gameObject.AddComponent<MeshFilter>();
			_meshFilter.mesh = new Mesh();
			_meshRenderer = _gameObject.AddComponent<MeshRenderer>();
			_meshRenderer.materials = _roomItemEditConfig.NavInvalidMaterials;
			_materialPropertyBlock = new MaterialPropertyBlock();
		}

		public override void Destroy()
		{
			Object.Destroy(_gameObject);
			base.Destroy();
		}

		public void Update()
		{
			Color color = _roomItemEditConfig.NavInvalidMaterials[0].color;
			Color color2 = _roomItemEditConfig.NavInvalidMaterials[1].color;
			_alpha = Mathf.Max(_alpha - _roomItemEditConfig.NavInvalidFadeSpeed * Time.unscaledDeltaTime, 0f);
			_materialPropertyBlock.SetColor("_Color", new Color(color.r, color.g, color.b, color.a * _alpha));
			_meshRenderer.SetPropertyBlock(_materialPropertyBlock, 0);
			_materialPropertyBlock.SetColor("_Color", new Color(color2.r, color2.g, color2.b, color2.a * _alpha));
			_meshRenderer.SetPropertyBlock(_materialPropertyBlock, 1);
			if (_alpha <= 0f)
			{
				_meshFilter.mesh.Clear();
			}
		}

		public void ShowUnreachableNavIsland(NavMesh navMesh, int islandID)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			NavMeshAreaLookup areaLookup = navMesh.AreaLookup;
			Vector3[] vertices = areaLookup.Vertices;
			areaLookup.GetIslandTriangles(islandID, list2);
			areaLookup.GetIslandBoundaryLineList(islandID, list);
			List<Vector3> list3 = new List<Vector3>();
			List<Vector3> list4 = new List<Vector3>();
			List<Vector2> list5 = new List<Vector2>();
			Vector3[] array = vertices;
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 vector = array[i];
				list3.Add(new Vector3(vector.x, _roomItemEditConfig.LineElevation, vector.z));
				list4.Add(Vector3.up);
				list5.Add(new Vector2(vector.x, vector.z) * _roomItemEditConfig.TextureUVTile);
			}
			List<int> list6 = new List<int>();
			for (int j = 0; j < list.Count; j += 2)
			{
				Vector3 start = vertices[list[j]];
				Vector3 end = vertices[list[j + 1]];
				UIVertex[] quad = CreateLineSegment(start, end);
				AddQuad(quad, list3, list4, list5, list6);
			}
			Mesh mesh = _meshFilter.mesh;
			mesh.Clear();
			mesh.SetVertices(list3);
			mesh.SetNormals(list4);
			mesh.SetUVs(0, list5);
			mesh.subMeshCount = 2;
			mesh.SetTriangles(list2.ToArray(), 0);
			mesh.SetTriangles(list6, 1);
			_meshRenderer.SetPropertyBlock(_materialPropertyBlock);
			_alpha = Mathf.Min(_alpha + _roomItemEditConfig.NavInvalidFadeSpeed * 2f * Time.unscaledDeltaTime, 1f);
		}

		private UIVertex[] CreateLineSegment(Vector3 start, Vector3 end)
		{
			float x = Vector3.Distance(start, end) / _roomItemEditConfig.NavInvalidLineThickness;
			Vector3 vector = new Vector3(start.z - end.z, 0f, end.x - start.x).normalized * _roomItemEditConfig.NavInvalidLineThickness / 2f;
			return new UIVertex[4]
			{
				new UIVertex
				{
					position = start - vector,
					uv0 = new Vector2(0f, 0f)
				},
				new UIVertex
				{
					position = start,
					uv0 = new Vector2(0f, 1f)
				},
				new UIVertex
				{
					position = end,
					uv0 = new Vector2(x, 1f)
				},
				new UIVertex
				{
					position = end - vector,
					uv0 = new Vector2(x, 0f)
				}
			};
		}

		private void AddQuad(UIVertex[] quad, List<Vector3> vertices, List<Vector3> normals, List<Vector2> uv, List<int> tri)
		{
			int count = vertices.Count;
			for (int i = 0; i < quad.Length; i++)
			{
				UIVertex uIVertex = quad[i];
				vertices.Add(new Vector3(uIVertex.position.x, _roomItemEditConfig.LineElevation + 0.01f, uIVertex.position.z));
				normals.Add(Vector3.up);
				uv.Add(uIVertex.uv0);
			}
			tri.Add(count);
			tri.Add(count + 1);
			tri.Add(count + 2);
			tri.Add(count + 2);
			tri.Add(count + 3);
			tri.Add(count);
		}
	}
}
