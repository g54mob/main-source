using System;
using MessagePack;
using UnityEngine;

namespace Controllers
{
	[Serializable]
	[MessagePackObject(false)]
	public struct SerializableVector2
	{
		[Key(0)]
		public float x;

		[Key(1)]
		public float y;

		public SerializableVector2(Vector2 vector)
		{
			x = vector.x;
			y = vector.y;
		}

		public Vector2 ToVector2()
		{
			return new Vector2(x, y);
		}
	}
}
