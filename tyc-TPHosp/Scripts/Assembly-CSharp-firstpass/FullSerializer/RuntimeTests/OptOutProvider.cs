using System.Collections.Generic;

namespace FullSerializer.RuntimeTests
{
	public class OptOutProvider : TestProvider<OptOut>
	{
		public override bool Compare(OptOut before, OptOut after)
		{
			if (before.publicField == after.publicField && before.publicAutoProperty == after.publicAutoProperty && before.publicManualProperty == after.publicManualProperty && before.GetPrivateField() == after.GetPrivateField() && before.GetPrivateAutoProperty() == after.GetPrivateAutoProperty() && before.GetIgnoredField() != after.GetIgnoredField())
			{
				return before.GetIgnoredAutoProperty() != after.GetIgnoredAutoProperty();
			}
			return false;
		}

		public override IEnumerable<OptOut> GetValues()
		{
			yield return new OptOut(1, 1, 1, 1, 1, 1, 1);
		}
	}
}
