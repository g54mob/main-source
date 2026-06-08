using System;
using UnityEngine;

namespace KitchenData
{
	public struct ControllerIcon : IEquatable<ControllerIcon>
	{
		public Color Color;

		public Sprite Sprite;

		public bool Equals(ControllerIcon other)
		{
			if (Color.Equals(other.Color))
			{
				return object.Equals(Sprite, other.Sprite);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is ControllerIcon other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (Color.GetHashCode() * 397) ^ ((Sprite != null) ? Sprite.GetHashCode() : 0);
		}

		public static bool operator ==(ControllerIcon left, ControllerIcon right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ControllerIcon left, ControllerIcon right)
		{
			return !left.Equals(right);
		}

		public ControllerIcon(Color c, Sprite s)
		{
			Color = c;
			Sprite = s;
		}
	}
}
