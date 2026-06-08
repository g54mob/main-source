using System;
using MessagePack;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public struct SerializableBounds
	{
		[Key(0)]
		public SerializableVector3 center;

		[Key(1)]
		public SerializableVector3 size;

		public SerializableBounds(Bounds bounds)
		{
			center = new SerializableVector3(bounds.center);
			size = new SerializableVector3(bounds.size);
		}

		[SerializationConstructor]
		public SerializableBounds(SerializableVector3 Center, SerializableVector3 Size)
		{
			center = Center;
			size = Size;
		}

		public Bounds ToBounds()
		{
			return new Bounds(center.ToVector3(), size.ToVector3());
		}
	}
}
