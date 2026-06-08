namespace LaundryBear
{
	public interface IMaskable
	{
		int Layer { get; }

		bool IsMaskedBy(int mask);
	}
}
