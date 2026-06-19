using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class RoomLightingDebug : MonoBehaviour
	{
		private readonly List<Bounds> _bounds = new List<Bounds>();

		public List<Bounds> BoundsToRender => _bounds;

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			foreach (Bounds bound in _bounds)
			{
				Gizmos.DrawWireCube(bound.center, bound.size);
			}
		}
	}
}
