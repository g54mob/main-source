using System.Collections.Generic;

namespace FullSerializerSave.RuntimeTests
{
	public interface ITestProvider
	{
		IEnumerable<TestItem> GetValues();
	}
}
