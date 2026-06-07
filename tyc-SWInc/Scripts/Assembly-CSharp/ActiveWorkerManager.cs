using System;
using System.Collections.Generic;
using AltSerialize;
using UnityEngine;

[Serializable]
public class ActiveWorkerManager : IAltSerializable
{
	public class WorkerNode
	{
		public uint ID;

		public SDateTime Time;

		public WorkerNode Last;

		public WorkerNode Next;

		public WorkerNode(uint id, SDateTime time)
		{
			ID = id;
			Time = time;
		}
	}

	public WorkerNode Root;

	public WorkerNode Latest;

	public Dictionary<uint, WorkerNode> Workers = new Dictionary<uint, WorkerNode>();

	public int Count
	{
		get
		{
			return Workers.Count;
		}
	}

	public bool CanCache
	{
		get
		{
			return true;
		}
	}

	public void UpdateWorker(uint id, SDateTime time)
	{
		RefreshWorkers(time);
		WorkerNode value;
		if (Workers.TryGetValue(id, out value))
		{
			value.Time = time;
			if (value != Root || value != Latest)
			{
				RemoveNode(value);
				AddNode(value);
			}
		}
		else
		{
			WorkerNode workerNode = new WorkerNode(id, time);
			Workers[id] = workerNode;
			AddNode(workerNode);
		}
	}

	public void RefreshWorkers(SDateTime time)
	{
		while (Root != null && Root.Time.IsDistanceBigger(time, 60))
		{
			Workers.Remove(Root.ID);
			RemoveNode(Root);
		}
	}

	public void RemoveNode(WorkerNode node)
	{
		if (node == Root)
		{
			Root = node.Next;
		}
		if (node == Latest)
		{
			Latest = node.Last;
		}
		if (node.Last != null)
		{
			node.Last.Next = node.Next;
		}
		if (node.Next != null)
		{
			node.Next.Last = node.Last;
		}
		node.Last = null;
		node.Next = null;
	}

	public void AddNode(WorkerNode node)
	{
		if (Latest != null)
		{
			Latest.Next = node;
			node.Last = Latest;
			Latest = node;
		}
		Latest = node;
		if (Root == null)
		{
			Root = node;
		}
	}

	public void Serialize(AltSerializer serializer, int depth)
	{
		int count = Count;
		serializer.Write(count);
		int num = 0;
		WorkerNode workerNode = Root;
		while (workerNode != null)
		{
			if (num >= count)
			{
				Debug.LogError(string.Format("Mismatch between node count in worker manager: dict {0} - linked {1}", count, num));
				break;
			}
			serializer.Write(workerNode.ID);
			serializer.Serialize(workerNode.Time, depth);
			workerNode = workerNode.Next;
			num++;
		}
	}

	public IAltSerializable Deserialize(AltSerializer deserializer)
	{
		int num = deserializer.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			uint num2 = deserializer.ReadUInt32();
			SDateTime time = (SDateTime)deserializer.Deserialize();
			WorkerNode workerNode = new WorkerNode(num2, time);
			Workers[num2] = workerNode;
			AddNode(workerNode);
		}
		return this;
	}
}
