using System;
using MessagePack;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct DrinkData
	{
		[Key(0)]
		public int Component1;

		[Key(1)]
		public int Component2;

		[Key(2)]
		public int Component3;

		public static DrinkData Create(int a = 0, int b = 0, int c = 0)
		{
			return new DrinkData
			{
				Component1 = a,
				Component2 = b,
				Component3 = c
			};
		}

		public static Color GetColour(int a)
		{
			return a switch
			{
				0 => Color.green, 
				1 => Color.blue, 
				2 => Color.cyan, 
				3 => Color.magenta, 
				4 => Color.red, 
				5 => Color.yellow, 
				_ => Color.black, 
			};
		}

		public int Score(DrinkData other)
		{
			return 0 + (is_any(Component1) ? 1 : 0) + (is_any(Component2) ? 1 : 0) + (is_any(Component3) ? 1 : 0);
			bool is_any(int value)
			{
				if (value != -1)
				{
					if (value != other.Component1 && value != other.Component2)
					{
						return value == other.Component3;
					}
					return true;
				}
				return false;
			}
		}

		public bool Equals(DrinkData other)
		{
			if (Component1 == other.Component1 && Component2 == other.Component2)
			{
				return Component3 == other.Component3;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is DrinkData other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((Component1 * 397) ^ Component2) * 397) ^ Component3;
		}

		public static bool operator ==(DrinkData left, DrinkData right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(DrinkData left, DrinkData right)
		{
			return !left.Equals(right);
		}
	}
}
