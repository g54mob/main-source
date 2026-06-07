using UnityEngine;

namespace Assets.Scripts.Craft
{
	public struct CraftLocalBounds
	{
		public Vector3 Offset { get; set; }

		public Vector3 Size { get; set; }

		public CraftLocalBounds(Vector3 size, Vector3 offset)
		{
			Size = size;
			Offset = offset;
		}
	}
}
