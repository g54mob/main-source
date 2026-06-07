using System;
using UnityEngine;

namespace Document
{
	[Serializable]
	public struct DocElementPosition
	{
		public Vector2 position;

		public Vector2 size;

		public DocElementPosition(Vector2 position, Vector2 size)
		{
			this.position = default(Vector2);
			this.size = default(Vector2);
		}
	}
}
