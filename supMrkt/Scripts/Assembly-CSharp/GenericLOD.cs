using System;
using System.Collections.Generic;
using UnityEngine;

public class GenericLOD : MonoBehaviour
{
	private class LODGroupRegistry : IDisposable
	{
		public readonly LODGroupDefinition Definition;

		public CullingGroup CullingGroup;

		public List<LODInstance> Instances;

		public List<GenericLODGroup> Groups;

		private BoundingSphere[] m_BoundingSpheres;

		private int m_InstanceCount;

		public LODGroupRegistry(LODGroupDefinition definition)
		{
		}

		private void OnStateChanged(CullingGroupEvent ev)
		{
		}

		public void Dispose()
		{
		}

		public void Remove()
		{
		}

		public void RemoveGroup(GenericLODGroup group)
		{
		}

		private void UpdateBoundingSpheres()
		{
		}

		public void AddGroup(GenericLODGroup group)
		{
		}

		public void UpdateGroupSphere(GenericLODGroup group)
		{
		}
	}

	private static GenericLOD m_Instance;

	private static Dictionary<int, LODGroupRegistry> m_Entries;

	public static GenericLOD Instance => null;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Load()
	{
	}

	public void SetCamera(Camera camera)
	{
	}

	private void OnDestroy()
	{
	}

	public void DefineGroup(int groupId, LODGroupDefinition definition)
	{
	}

	public void Register(int groupId, GenericLODGroup group)
	{
	}

	public void Unregister(int groupId, GenericLODGroup group)
	{
	}

	public void UpdateGroupSphere(GenericLODGroup group)
	{
	}
}
