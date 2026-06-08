using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CGroupSelector : IComponentData
	{
		public Bounds Bounds;

		public float Progress;

		public bool Handled;
	}
}
