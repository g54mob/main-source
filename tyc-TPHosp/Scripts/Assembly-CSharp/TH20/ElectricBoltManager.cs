using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	[DontSave]
	public class ElectricBoltManager : MustCallDestroy
	{
		private Level _level;

		private Mesh _boltMesh;

		private Material _electricBoltMaterial;

		private ElectricBoltManagerConfig _config;

		private int _count;

		private MaterialPropertyBlock _materialPropertyBlock;

		[DontSave]
		private Dictionary<Camera, CommandBuffer> _cameraBoltCommandBuffers;

		private Matrix4x4[] _matrices;

		private float[] _remainingTime;

		private Vector2[] _seed;

		public ElectricBoltManager(Level level, ElectricBoltManagerConfig config)
		{
			_level = level;
			_config = config;
			_matrices = new Matrix4x4[_config.Capacity];
			_remainingTime = new float[_config.Capacity];
			_seed = new Vector2[_config.Capacity];
			_electricBoltMaterial = _config.ElectricBoltMaterial;
			_boltMesh = BoltMesh(3, 32);
			_materialPropertyBlock = new MaterialPropertyBlock();
			_cameraBoltCommandBuffers = new Dictionary<Camera, CommandBuffer>();
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(OnPreRender));
		}

		private static Mesh BoltMesh(int edges, int crossSections)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			list.Add(new Vector3(0f, 0f, 0f));
			list2.Add(new Vector3(0f, 0f, -1f));
			for (int i = 0; i <= crossSections + 1; i++)
			{
				float num = (float)i / (float)(crossSections + 1);
				for (int j = 0; j < edges; j++)
				{
					float f = (float)j * 2f * (float)Math.PI / (float)edges;
					float num2 = Mathf.Sin(f);
					float num3 = Mathf.Cos(f);
					list.Add(new Vector3(num2 * (1f - num), num3 * (1f - num), num));
					list2.Add(new Vector3(num2, num3, 0f));
				}
			}
			list.Add(new Vector3(0f, 0f, 1f));
			list2.Add(new Vector3(0f, 0f, 1f));
			List<int> list3 = new List<int>();
			for (int k = 0; k < edges; k++)
			{
				list3.Add(0);
				list3.Add(1 + (k + 1) % edges);
				list3.Add(1 + (k + 2) % edges);
			}
			for (int l = 0; l < crossSections + 1; l++)
			{
				int num4 = 1 + l * edges;
				for (int m = 0; m < edges; m++)
				{
					list3.Add(num4 + m % edges);
					list3.Add(num4 + m % edges + edges);
					list3.Add(num4 + (m + 1) % edges);
					list3.Add(num4 + (m + 1) % edges);
					list3.Add(num4 + m % edges + edges);
					list3.Add(num4 + (m + 1) % edges + edges);
				}
			}
			for (int n = 0; n < edges; n++)
			{
				int num5 = 1 + (crossSections + 1) * edges;
				list3.Add(list.Count - 1);
				list3.Add(num5 + (n + 2) % edges);
				list3.Add(num5 + (n + 1) % edges);
			}
			Mesh mesh = new Mesh();
			mesh.SetVertices(list);
			mesh.SetNormals(list2);
			mesh.SetIndices(list3.ToArray(), MeshTopology.Triangles, 0);
			mesh.RecalculateBounds();
			mesh.UploadMeshData(markNoLongerReadable: true);
			return mesh;
		}

		public void SpawnBolt(Vector3 position, Quaternion rotation, float duration)
		{
			if (_count < _config.Capacity)
			{
				_matrices[_count] = Matrix4x4.TRS(position, rotation, _config.DefaultScale);
				_remainingTime[_count] = duration;
				_seed[_count] = new Vector2(UnityEngine.Random.value, UnityEngine.Random.value);
				_count++;
			}
		}

		private void RemoveAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException();
			}
			_count--;
			if (index < _count)
			{
				Array.Copy(_matrices, index + 1, _matrices, index, _count - index);
				Array.Copy(_remainingTime, index + 1, _remainingTime, index, _count - index);
				Array.Copy(_seed, index + 1, _seed, index, _count - index);
			}
			_matrices[_count] = default(Matrix4x4);
			_remainingTime[_count] = 0f;
			_seed[_count] = default(Vector2);
		}

		public void Update()
		{
			int num = 0;
			while (num < _count)
			{
				_remainingTime[num] -= Time.deltaTime;
				if (_remainingTime[num] < 0f)
				{
					RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
		}

		private void OnPreRender(Camera camera)
		{
			if ((camera.cameraType == CameraType.Game || camera.cameraType == CameraType.SceneView) && !(camera.name == "PreRenderCamera") && (camera.cameraType != CameraType.Game || camera.enabled) && (_level.MetagameMap.CameraLogic == null || !(camera == _level.MetagameMap.CameraLogic.CameraComponent)))
			{
				CommandBuffer orCreate = CommandBufferUtils.GetOrCreate(_cameraBoltCommandBuffers, camera, CameraEvent.AfterForwardAlpha, "Electric Bolt");
				_materialPropertyBlock.Clear();
				for (int i = 0; i < _count; i++)
				{
					_materialPropertyBlock.SetVector("_Seed", _seed[i]);
					orCreate.DrawMesh(_boltMesh, _matrices[i], _electricBoltMaterial, 0, 0, _materialPropertyBlock);
				}
			}
		}

		public override void Destroy()
		{
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(OnPreRender));
			foreach (KeyValuePair<Camera, CommandBuffer> cameraBoltCommandBuffer in _cameraBoltCommandBuffers)
			{
				cameraBoltCommandBuffer.Value.Release();
			}
			_cameraBoltCommandBuffers.Clear();
			UnityEngine.Object.Destroy(_boltMesh);
			base.Destroy();
		}
	}
}
