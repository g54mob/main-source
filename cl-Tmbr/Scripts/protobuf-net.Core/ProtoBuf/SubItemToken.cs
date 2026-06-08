using System.Runtime.InteropServices;

namespace ProtoBuf
{
	[StructLayout(LayoutKind.Auto)]
	public readonly struct SubItemToken
	{
		internal readonly long value64;

		public override string ToString()
		{
			if (value64 < 0)
			{
				return $"Group {-value64}";
			}
			if (value64 == long.MaxValue)
			{
				return "Message (restores to end when ended)";
			}
			return "Message (restores to value64 when ended)";
		}

		public override int GetHashCode()
		{
			return value64.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is SubItemToken subItemToken)
			{
				return subItemToken.value64 == value64;
			}
			return false;
		}

		internal SubItemToken(long value)
		{
			value64 = value;
		}
	}
}
