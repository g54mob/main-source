using System.Collections.Generic;

namespace FullSerializer.RuntimeTests
{
	public interface ITestProvider
	{
		IEnumerable<TestItem> GetValues();
	}
}
