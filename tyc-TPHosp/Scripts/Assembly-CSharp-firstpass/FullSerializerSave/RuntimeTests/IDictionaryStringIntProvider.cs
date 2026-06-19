using System.Collections.Generic;
using System.Linq;

namespace FullSerializerSave.RuntimeTests
{
	public class IDictionaryStringIntProvider : TestProvider<IDictionary<string, int>>
	{
		public override bool Compare(IDictionary<string, int> before, IDictionary<string, int> after)
		{
			if (before.Except(after).Count() == 0)
			{
				return after.Except(before).Count() == 0;
			}
			return false;
		}

		public override IEnumerable<IDictionary<string, int>> GetValues()
		{
			yield return new Dictionary<string, int>
			{
				{ "ok", 3 },
				{
					string.Empty,
					2
				}
			};
		}
	}
}
