namespace RetroLauncher
{
	public struct GadgetId
	{
		public GadgetType type;

		public ulong id;

		public GadgetId(string value)
		{
			type = default(GadgetType);
			id = 0uL;
		}

		public GadgetId(GadgetType type, ulong id)
		{
			this.type = default(GadgetType);
			this.id = 0uL;
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
	}
}
