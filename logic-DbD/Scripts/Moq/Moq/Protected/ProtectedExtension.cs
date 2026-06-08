using System.ComponentModel;

namespace Moq.Protected
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ProtectedExtension
	{
		public static IProtectedMock<T> Protected<T>(this Mock<T> mock) where T : class
		{
			Guard.NotNull(mock, "mock");
			return new ProtectedMock<T>(mock);
		}
	}
}
