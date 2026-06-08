using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CBounds : IComponentData
	{
		public Bounds Bounds;
	}
}
