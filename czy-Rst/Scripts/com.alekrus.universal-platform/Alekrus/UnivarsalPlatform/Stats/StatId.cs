namespace Alekrus.UnivarsalPlatform.Stats
{
	public struct StatId
	{
		public string Id;

		public StatId(string parId)
		{
			Id = parId;
		}

		public static implicit operator StatId(string value)
		{
			return new StatId(value);
		}

		public static implicit operator string(StatId value)
		{
			return value.Id;
		}

		public override string ToString()
		{
			return Id.ToString();
		}
	}
}
