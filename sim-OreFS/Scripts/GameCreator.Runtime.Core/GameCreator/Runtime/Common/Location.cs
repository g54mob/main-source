using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public readonly struct Location : ILocation
	{
		public static readonly Location None = new Location(default(PositionNone), default(RotationNone));

		[field: NonSerialized]
		private IPosition Position { get; }

		[field: NonSerialized]
		private IRotation Rotation { get; }

		public bool HasPosition(GameObject source)
		{
			return Position?.HasPosition(source) ?? false;
		}

		public bool HasRotation(GameObject source)
		{
			return Rotation?.HasRotation(source) ?? false;
		}

		public Vector3 GetPosition(GameObject source)
		{
			return Position?.GetPosition(source) ?? default(Vector3);
		}

		public Quaternion GetRotation(GameObject source)
		{
			return Rotation?.GetRotation(source) ?? default(Quaternion);
		}

		public Location(Vector3 position)
		{
			Position = new PositionConstant(position);
			Rotation = default(RotationNone);
		}

		public Location(Quaternion rotation)
		{
			Position = default(PositionNone);
			Rotation = new RotationConstant(rotation);
		}

		public Location(Vector3 position, Quaternion rotation)
		{
			Position = new PositionConstant(position);
			Rotation = new RotationConstant(rotation);
		}

		public Location(Marker marker)
		{
			Position = new PositionMarker(marker);
			Rotation = new RotationMarker(marker);
		}

		public Location(IPosition position, IRotation rotation)
		{
			Position = position;
			Rotation = rotation;
		}
	}
}
