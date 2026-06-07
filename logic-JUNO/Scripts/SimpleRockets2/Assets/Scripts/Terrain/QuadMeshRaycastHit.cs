using UnityEngine;

namespace Assets.Scripts.Terrain
{
	public class QuadMeshRaycastHit
	{
		public Vector3 FramePosition { get; }

		public bool Hit { get; set; }

		public QuadScript Quad { get; }

		public QuadMeshRaycastHit(bool hit, QuadScript quad, Vector3 framePosition)
		{
			Hit = hit;
			Quad = quad;
			FramePosition = framePosition;
		}
	}
}
