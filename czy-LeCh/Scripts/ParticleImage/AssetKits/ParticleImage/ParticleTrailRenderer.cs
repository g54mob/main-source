using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace AssetKits.ParticleImage
{
	[AddComponentMenu("UI/Particle Image/Trail Renderer")]
	public class ParticleTrailRenderer : MaskableGraphic
	{
		private ParticleImage _particle;

		private Mesh _trailMesh;

		private Mesh.MeshDataArray _trailMeshDataArray;

		private Mesh.MeshData _trailMeshData;

		private int offset;

		private int trisOffset;

		private int trisCount;

		public Mesh trailMesh
		{
			get
			{
				if (_trailMesh == null)
				{
					_trailMesh = new Mesh();
					_trailMesh.MarkDynamic();
				}
				return _trailMesh;
			}
		}

		public ParticleImage particle
		{
			get
			{
				return _particle;
			}
			set
			{
				_particle = value;
			}
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
		}

		protected override void UpdateGeometry()
		{
		}

		public void PrepareMeshData(int vertexCount, int particleCount)
		{
			trisCount = (vertexCount - particleCount) * 6;
			_trailMeshDataArray = Mesh.AllocateWritableMeshData(1);
			_trailMeshData = _trailMeshDataArray[0];
			_trailMeshData.SetVertexBufferParams(vertexCount * 2, new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0), new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.Float32, 4, 1));
			_trailMeshData.SetIndexBufferParams(trisCount, IndexFormat.UInt16);
			offset = 0;
			trisOffset = 0;
		}

		public void UpdateMeshData(NativeArray<Vector3> points, NativeArray<int> tris, NativeArray<Color> cols)
		{
			NativeArray<Vector3> vertexData = _trailMeshData.GetVertexData<Vector3>();
			NativeArray<Color> vertexData2 = _trailMeshData.GetVertexData<Color>(1);
			NativeArray<ushort> indexData = _trailMeshData.GetIndexData<ushort>();
			for (int i = 0; i < points.Length; i++)
			{
				vertexData[i + offset] = points[i];
			}
			for (int j = 0; j < cols.Length; j++)
			{
				vertexData2[j + offset] = cols[j];
			}
			for (int k = 0; k < tris.Length; k++)
			{
				indexData[k + trisOffset] = (ushort)(tris[k] + offset);
			}
			offset += points.Length;
			trisOffset += tris.Length;
		}

		public void SetMeshData()
		{
			SetMeshData(_trailMeshDataArray, _trailMeshData, trisCount);
		}

		public void SetMeshData(Mesh.MeshDataArray meshDataArray, Mesh.MeshData meshData, int triCount)
		{
			meshData.subMeshCount = 1;
			meshData.SetSubMesh(0, new SubMeshDescriptor(0, triCount));
			Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, trailMesh, MeshUpdateFlags.DontRecalculateBounds);
			trailMesh.RecalculateBounds();
			base.canvasRenderer.SetMesh(trailMesh);
			SetMaterialDirty();
		}

		public void Clear()
		{
			trailMesh.Clear();
			base.canvasRenderer.SetMesh(trailMesh);
			SetMaterialDirty();
		}
	}
}
