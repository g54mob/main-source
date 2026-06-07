using System.Collections.Generic;

namespace FSG.MeshAnimator
{
	public static class AllocatedArray<T>
	{
		private static T defaultValue;

		private static List<T[]> allocatedArrays;

		private static T[] AllocateArray(int size)
		{
			return null;
		}

		public static T[] Get(int size)
		{
			return null;
		}

		public static void Return(T[] array, bool resetValues = true)
		{
		}
	}
	public static class AllocatedArray
	{
		public static T[] Get<T>(int size)
		{
			return null;
		}

		public static void Return<T>(T[] array, bool resetValues = true)
		{
		}
	}
}
