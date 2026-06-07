using System;

namespace FluffyUnderware.Curvy
{
	public struct TcbParameters : IEquatable<TcbParameters>
	{
		public float StartTension { get; set; }

		public float EndTension { get; set; }

		public float StartContinuity { get; set; }

		public float EndContinuity { get; set; }

		public float StartBias { get; set; }

		public float EndBias { get; set; }

		public bool Equals(TcbParameters other)
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

		public static bool operator ==(TcbParameters left, TcbParameters right)
		{
			return false;
		}

		public static bool operator !=(TcbParameters left, TcbParameters right)
		{
			return false;
		}
	}
}
