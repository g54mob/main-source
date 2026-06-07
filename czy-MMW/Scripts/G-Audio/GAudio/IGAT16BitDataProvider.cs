namespace GAudio
{
	public interface IGAT16BitDataProvider
	{
		short[] SampleData { get; }

		int Length { get; }
	}
}
