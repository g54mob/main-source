using System;

namespace FluffyUnderware.Curvy.Generator
{
	public struct SamplePointsPatch : IEquatable<SamplePointsPatch>
	{
		public int Start;

		public int Count;

		public int End
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int TriangleCount => 0;

		public SamplePointsPatch(int start)
		{
			Start = 0;
			Count = 0;
		}

		public override string ToString()
		{
			return null;
		}

		public bool Equals(SamplePointsPatch other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(SamplePointsPatch left, SamplePointsPatch right)
		{
			return false;
		}

		public static bool operator !=(SamplePointsPatch left, SamplePointsPatch right)
		{
			return false;
		}
	}
}
