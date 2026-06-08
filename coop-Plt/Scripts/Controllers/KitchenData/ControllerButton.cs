using System;
using Platforms;

namespace KitchenData
{
	public struct ControllerButton : IEquatable<ControllerButton>
	{
		public ControllerType Controller;

		public string Button;

		public ControllerButton(ControllerType c, string b)
		{
			Controller = c;
			Button = b;
		}

		public bool Equals(ControllerButton other)
		{
			if (Controller == other.Controller)
			{
				return Button == other.Button;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is ControllerButton other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((int)Controller * 397) ^ ((Button != null) ? Button.GetHashCode() : 0);
		}

		public static bool operator ==(ControllerButton left, ControllerButton right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ControllerButton left, ControllerButton right)
		{
			return !left.Equals(right);
		}
	}
}
