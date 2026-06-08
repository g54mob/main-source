using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CCustomerTablePlacement : IComponentData
	{
		public Vector3 SeatPosition;

		public Vector3 TablePosition;
	}
}
