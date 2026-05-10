using System;
using UnityEngine;

namespace _Code.Rooms
{
	[Serializable]
	public sealed class RoomObjectState<T> where T : Enum
	{
		public T Name { get; private set; }

		public Sprite Sprite { get; private set; }

		public Vector2 PositionShift { get; set; }

		public Vector2 ScaleShift { get; set; }

		public bool CannotInteract { get; private set; }
	}
}
