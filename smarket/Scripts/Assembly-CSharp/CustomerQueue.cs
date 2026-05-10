using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class CustomerQueue
{
	public const int LIMIT = 5;

	private List<Customer> m_Queue;

	[SerializeField]
	private Transform m_QueueStartPosition;

	[SerializeField]
	private float m_QueueEntryOffset;

	public int Length => 0;

	public Customer Current => null;

	public bool HasCapacity => false;

	public event Action QueueUpdated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public bool Enqueue(Customer customer)
	{
		return false;
	}

	public Customer Dequeue()
	{
		return null;
	}

	public int GetIndexFor(Customer customer)
	{
		return 0;
	}

	public Vector3 GetQueueRotationFor(int index)
	{
		return default(Vector3);
	}

	public Vector3 GetQueueRotationFor(Customer customer)
	{
		return default(Vector3);
	}

	public Vector3 GetQueuePositionFor(int index)
	{
		return default(Vector3);
	}

	public Vector3 GetQueuePositionFor(Customer value)
	{
		return default(Vector3);
	}

	public void Remove(Customer customer)
	{
	}

	public void Clear()
	{
	}
}
