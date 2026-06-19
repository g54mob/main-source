namespace Pug.UnityExtensions
{
	public class RandomDeterministic
	{
		private int state;

		private const int RAND_MAX = int.MaxValue;

		private const ulong RAND_MAX_UL = 2147483647uL;

		private const float RAND_MAX_MINUS_ONE_F = 2.1474836E+09f;

		public RandomDeterministic()
			: this(1337)
		{
		}

		public RandomDeterministic(int seed)
		{
			state = seed;
		}

		public void Seed(int seed)
		{
			state = seed;
		}

		public int NextInt()
		{
			state = (int)((ulong)((long)state * 48271L) % 2147483647uL);
			return state;
		}

		public float NextFloat()
		{
			return (float)NextInt() / 2.1474836E+09f;
		}

		public int Range(int min, int max)
		{
			return min + NextInt() % (max - min);
		}

		public float Range(float min, float max)
		{
			return min + (float)NextInt() / 2.1474836E+09f * (max - min);
		}
	}
}
