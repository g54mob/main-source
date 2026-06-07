using JetBrains.Annotations;

namespace Barmetler.RoadSystem.Util
{
	internal sealed class ExtendedTwoDimensionalNativeArrayDebugView<T> where T : struct
	{
		private ExtendedTwoDimensionalNativeArray<T> _array;

		[UsedImplicitly]
		public T[] Items => _array.ToArray();

		public ExtendedTwoDimensionalNativeArrayDebugView(ExtendedTwoDimensionalNativeArray<T> array)
		{
			_array = array;
		}
	}
}
