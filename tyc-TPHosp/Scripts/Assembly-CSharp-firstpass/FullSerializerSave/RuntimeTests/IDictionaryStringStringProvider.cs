using System.Collections.Generic;
using System.Linq;

namespace FullSerializerSave.RuntimeTests
{
	public class IDictionaryStringStringProvider : TestProvider<IDictionary<string, string>>
	{
		public override bool Compare(IDictionary<string, string> before, IDictionary<string, string> after)
		{
			if (before.Except(after).Count() == 0)
			{
				return after.Except(before).Count() == 0;
			}
			return false;
		}

		public override IEnumerable<IDictionary<string, string>> GetValues()
		{
			yield return new Dictionary<string, string> { 
			{
				string.Empty,
				null
			} };
		}
	}
}
