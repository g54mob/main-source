using System;
using System.Runtime.InteropServices;

namespace DepthFirstScheduler
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Unit : IEquatable<Unit>
	{
		private static readonly Unit @default;

		public static Unit Default => @default;

		public static bool operator ==(Unit first, Unit second)
		{
			return true;
		}

		public static bool operator !=(Unit first, Unit second)
		{
			return false;
		}

		public bool Equals(Unit other)
		{
			return true;
		}

		public override bool Equals(object obj)
		{
			return obj is Unit;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return "()";
		}
	}
}
