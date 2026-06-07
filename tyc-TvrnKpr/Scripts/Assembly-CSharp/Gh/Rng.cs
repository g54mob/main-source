using System;
using Gh.Tk;

namespace Gh
{
	[PersistenceOptIn]
	public class Rng : IRng, IPersistable, ICustomSaveState
	{
		[PersistenceOptIn]
		private int _seed;

		private XXHash _hash;

		[PersistenceOptIn]
		private int _currentHash;

		internal static IRng instance;

		public int Seed => 0;

		private Rng()
		{
		}

		private Rng(int seed)
		{
		}

		public static IRng CreateRng(int seed)
		{
			return null;
		}

		void IRng.Skip(int number)
		{
		}

		public static void Skip(int number)
		{
		}

		bool IRng.FlipCoin()
		{
			return false;
		}

		float IRng.RandomSign()
		{
			return 0f;
		}

		public static float RandomSign()
		{
			return 0f;
		}

		public static bool FlipCoin()
		{
			return false;
		}

		float IRng.Random(float min, float max)
		{
			return 0f;
		}

		public static float Random(float min = 0f, float max = 1f)
		{
			return 0f;
		}

		int IRng.RandomInt(int min, int max)
		{
			return 0;
		}

		public static int RandomInt(int min = 0, int max = 2147483647)
		{
			return 0;
		}

		public static void SetNew()
		{
		}

		public static IDisposable UseTemporaryNewSeed(int seed)
		{
			return null;
		}

		public static IDisposable UseTemporaryNewSeedFromUnityRandom()
		{
			return null;
		}

		public void RestoreState(IDataStore state)
		{
		}

		public void SaveState(IDataStore data)
		{
		}
	}
}
