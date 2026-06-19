namespace Origin
{
	internal class Random
	{
		private static uint s_seed = 0u;

		private static uint RAND_MAX = 32767u;

		public static void srand(uint seed)
		{
			s_seed = seed;
		}

		public static uint rand()
		{
			s_seed = s_seed * 214013 + 2531011;
			return (s_seed >> 16) & RAND_MAX;
		}
	}
}
