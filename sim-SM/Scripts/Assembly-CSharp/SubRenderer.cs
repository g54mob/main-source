using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class SubRenderer : IDisposable
{
	public class BatchedRegisterHandle
	{
		private List<RenderableInstance> m_Instances;

		private readonly bool m_Unregister;

		public bool IsForUnregister => false;

		public BatchedRegisterHandle(bool unregister)
		{
		}

		public void Add(RenderableInstance renderer)
		{
		}

		public IEnumerable<RenderableInstance> Iterate()
		{
			return null;
		}
	}

	public class PerCallData
	{
		public HashSet<RenderableInstance> Instances;

		public Material Material;

		public int Submesh;

		public uint IDOffset;
	}

	private RenderParams m_RParams;

	private Dictionary<Mesh, PerCallData> m_Meshes;

	private List<Mesh> m_UniqueMeshes;

	private GraphicsBuffer.IndirectDrawIndexedArgs[] m_CommandData;

	private uint m_Capacity;

	private GraphicsBuffer m_CommandBuffer;

	public const uint InstanceDataSize = 128u;

	private InstanceData[] m_InstanceData;

	private ComputeBuffer m_InstanceDataBuffer;

	private NativeArray<AABB> m_AABBs;

	private uint m_InstanceCount;

	public bool Enabled { get; set; }

	public int Id { get; set; }

	public SubRenderer(int id, Material material)
	{
	}

	public SubRenderer(int id, Material material, uint capacity, uint instanceCapacity = 1000u)
	{
	}

	public void SetInstanceCapacity(uint capacity)
	{
	}

	public void SetCapacity(uint capacity)
	{
	}

	private void AddInstance(RenderableInstance instance)
	{
	}

	private void EnsureCapacity()
	{
	}

	public void Register(RenderableInstance instance)
	{
	}

	public BatchedRegisterHandle BeginRegisterBatch()
	{
		return null;
	}

	public BatchedRegisterHandle BeginUnregisterBatch()
	{
		return null;
	}

	public void EndBatch(BatchedRegisterHandle handle)
	{
	}

	public void RemoveInstance(RenderableInstance instance)
	{
	}

	public void Unregister(RenderableInstance instance)
	{
	}

	public void UpdateInstances()
	{
	}

	public void Render()
	{
	}

	public void Dispose()
	{
	}

	public void SetTexture(string name, Texture value)
	{
	}

	public void SetFloat(string name, float value)
	{
	}

	public void SetMatrix(string name, Matrix4x4 value)
	{
	}

	public void SetVector(string name, Vector4 value)
	{
	}

	public void ClearInstanceData()
	{
	}
}
