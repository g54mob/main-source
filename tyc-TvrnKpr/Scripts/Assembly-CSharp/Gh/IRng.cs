namespace Gh
{
	public interface IRng
	{
		int Seed { get; }

		bool FlipCoin();

		float Random(float min = 0f, float max = 1f);

		int RandomInt(int min = 0, int max = 2147483647);

		void Skip(int count);

		float RandomSign();
	}
}
