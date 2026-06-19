using System;

namespace TH20
{
	public static class AssetIDGenerator
	{
		private static readonly Random RandomInstance = new Random();

		public static int GenerateUniqueID()
		{
			return RandomInstance.Next(int.MinValue, 0);
		}
	}
}
