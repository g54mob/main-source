using System.Collections.Generic;

namespace FullSerializerSave.RuntimeTests
{
	public class PrivateFieldsProvider : TestProvider<PrivateHolder>
	{
		public override bool Compare(PrivateHolder before, PrivateHolder after)
		{
			return before.Equals(after);
		}

		public override IEnumerable<PrivateHolder> GetValues()
		{
			PrivateHolder privateHolder = new PrivateHolder();
			privateHolder.Setup();
			yield return privateHolder;
		}
	}
}
