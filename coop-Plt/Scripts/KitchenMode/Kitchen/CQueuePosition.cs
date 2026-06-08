using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CQueuePosition : IComponentData
	{
		public int QueuePosition;

		public Vector3 Position;
	}
}
