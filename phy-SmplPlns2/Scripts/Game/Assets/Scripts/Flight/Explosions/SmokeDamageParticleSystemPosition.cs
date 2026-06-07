using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class SmokeDamageParticleSystemPosition
	{
		private Vector3[] _normals;

		private int[] _triangles;

		private Vector3[] _vertices;

		public int EmitterCount { get; private set; }

		public bool Enabled { get; set; }

		public Vector3 Normal { get; private set; }

		public Vector3 Position { get; private set; }

		public SmokeDamageParticleSystemProxyObject ProxyObject { get; private set; }

		public float Size { get; private set; }

		public int VertexCount => _vertices.Length;

		public SmokeDamageParticleSystemPosition(Vector3 position, Vector3 normal, float size, int emitterCount, SmokeDamageParticleSystem system)
		{
			Position = position;
			Normal = normal;
			Size = size;
			EmitterCount = emitterCount;
			Enabled = true;
			ProxyObject = SmokeDamageParticleSystemProxyObject.Create(system, this);
			BuildMeshData();
		}

		public void UpdateMesh(Vector3[] vertices, Vector3[] normals, int[] triangles, int vertexIndex, int normalIndex, int triangleIndex)
		{
			Array.Copy(_vertices, 0, vertices, vertexIndex, _vertices.Length);
			Array.Copy(_normals, 0, normals, normalIndex, _normals.Length);
			for (int i = 0; i < _triangles.Length; i++)
			{
				triangles[i + triangleIndex] = _triangles[i] + vertexIndex;
			}
		}

		private void BuildMeshData()
		{
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, Normal);
			float num = Size / 2f;
			float num2 = 0f - num;
			if (EmitterCount < 1)
			{
				_vertices = new Vector3[0];
			}
			else if (EmitterCount == 1)
			{
				_vertices = new Vector3[3];
				_vertices[0] = Position + quaternion * new Vector3(0f, 0f, num);
				_vertices[1] = Position + quaternion * new Vector3(num, 0f, num2);
				_vertices[2] = Position + quaternion * new Vector3(num2, 0f, num2);
			}
			else
			{
				_vertices = new Vector3[4];
				_vertices[0] = Position + quaternion * new Vector3(num, 0f, num);
				_vertices[1] = Position + quaternion * new Vector3(num, 0f, num2);
				_vertices[2] = Position + quaternion * new Vector3(num2, 0f, num2);
				_vertices[3] = Position + quaternion * new Vector3(num2, 0f, num);
			}
			_normals = new Vector3[_vertices.Length];
			for (int i = 0; i < _vertices.Length; i++)
			{
				_normals[i] = Normal;
			}
			_triangles = new int[3 * EmitterCount];
			for (int j = 0; j < EmitterCount; j++)
			{
				if (j % 2 == 0)
				{
					int num3 = j * 3;
					_triangles[num3] = 0;
					_triangles[num3 + 1] = 1;
					_triangles[num3 + 2] = 2;
				}
				else
				{
					int num4 = j * 3;
					_triangles[num4] = 0;
					_triangles[num4 + 1] = 2;
					_triangles[num4 + 2] = 3;
				}
			}
		}
	}
}
