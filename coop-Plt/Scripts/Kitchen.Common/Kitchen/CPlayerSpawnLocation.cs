using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CPlayerSpawnLocation : IComponentData
	{
		public int Index;

		public Vector3 Location;
	}
}
