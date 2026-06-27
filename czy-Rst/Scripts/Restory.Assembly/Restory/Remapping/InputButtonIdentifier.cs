using Rewired;

namespace Restory.Remapping
{
	public struct InputButtonIdentifier
	{
		public string ActionId;

		public AxisRange AxisRange;

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			InputButtonIdentifier inputButtonIdentifier = (InputButtonIdentifier)obj;
			if (ActionId == inputButtonIdentifier.ActionId)
			{
				return AxisRange == inputButtonIdentifier.AxisRange;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ActionId.GetHashCode() ^ AxisRange.GetHashCode();
		}

		public override string ToString()
		{
			return $"{ActionId}_{AxisRange}";
		}

		public static bool operator ==(InputButtonIdentifier a, InputButtonIdentifier b)
		{
			if (a.ActionId == b.ActionId)
			{
				return a.AxisRange == b.AxisRange;
			}
			return false;
		}

		public static bool operator !=(InputButtonIdentifier a, InputButtonIdentifier b)
		{
			if (!(a.ActionId != b.ActionId))
			{
				return a.AxisRange != b.AxisRange;
			}
			return true;
		}
	}
}
