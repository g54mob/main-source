namespace BCnEncoder.Shared
{
	internal struct Bc2AlphaBlock
	{
		public ulong alphas;

		public readonly byte GetAlpha(int index)
		{
			ulong num = (ulong)(15L << index * 4);
			int num2 = index * 4;
			return (byte)(((alphas & num) >> num2) * 17);
		}

		public void SetAlpha(int index, byte alpha)
		{
			ulong num = (ulong)(15L << index * 4);
			int num2 = index * 4;
			alphas &= ~num;
			byte b = (byte)(alpha / 17);
			alphas |= (ulong)((long)(b & 0xF) << num2);
		}
	}
}
