using System;
using System.Runtime.InteropServices;

namespace LitMotion
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct NoOptions : IMotionOptions, IEquatable<NoOptions>
	{
		public bool Equals(NoOptions other)
		{
			return true;
		}

		public override bool Equals(object obj)
		{
			return obj is NoOptions;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
