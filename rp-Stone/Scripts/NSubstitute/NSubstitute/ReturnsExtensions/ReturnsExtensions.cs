using System.Threading.Tasks;
using NSubstitute.Core;

namespace NSubstitute.ReturnsExtensions
{
	public static class ReturnsExtensions
	{
		public static ConfiguredCall ReturnsNull<T>(this T value) where T : class
		{
			return value.Returns(null, new T[0]);
		}

		public static ConfiguredCall ReturnsNullForAnyArgs<T>(this T value) where T : class
		{
			return value.ReturnsForAnyArgs(null, new T[0]);
		}

		public static ConfiguredCall ReturnsNull<T>(this Task<T> value) where T : class
		{
			return value.Returns(null, new T[0]);
		}

		public static ConfiguredCall ReturnsNull<T>(this ValueTask<T> value) where T : class
		{
			return value.Returns(null, new T[0]);
		}

		public static ConfiguredCall ReturnsNullForAnyArgs<T>(this Task<T> value) where T : class
		{
			return value.ReturnsForAnyArgs(null, new T[0]);
		}

		public static ConfiguredCall ReturnsNullForAnyArgs<T>(this ValueTask<T> value) where T : class
		{
			return value.ReturnsForAnyArgs(null, new T[0]);
		}
	}
}
