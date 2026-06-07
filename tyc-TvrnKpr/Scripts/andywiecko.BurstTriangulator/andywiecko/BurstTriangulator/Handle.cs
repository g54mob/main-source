namespace andywiecko.BurstTriangulator
{
	public readonly struct Handle
	{
		private readonly ulong gcHandle;

		public Handle(ulong gcHandle)
		{
			this.gcHandle = 0uL;
		}

		public void Free()
		{
		}
	}
}
