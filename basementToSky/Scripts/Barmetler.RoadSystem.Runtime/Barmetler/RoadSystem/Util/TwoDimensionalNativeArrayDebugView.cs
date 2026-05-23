using JetBrains.Annotations;

namespace Barmetler.RoadSystem.Util
{
	internal sealed class TwoDimensionalNativeArrayDebugView<T> where T : struct
	{
		private TwoDimensionalNativeArray<T> _array;

		[UsedImplicitly]
		public T[] Items => _array.ToArray();

		public TwoDimensionalNativeArrayDebugView(TwoDimensionalNativeArray<T> array)
		{
			_array = array;
		}
	}
}
