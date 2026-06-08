namespace GRP
{
	public struct Id
	{
		public ulong value;

		public Id(ulong value)
		{
			this.value = 0uL;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static implicit operator ulong(Id id)
		{
			return 0uL;
		}

		public static implicit operator Id(ulong id)
		{
			return default(Id);
		}

		public static bool operator ==(Id a, Id b)
		{
			return false;
		}

		public static bool operator !=(Id a, Id b)
		{
			return false;
		}
	}
}
