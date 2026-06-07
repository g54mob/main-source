namespace GAudio
{
	public interface IRetainable
	{
		int RetainCount { get; }

		void Retain();

		void Release();
	}
}
