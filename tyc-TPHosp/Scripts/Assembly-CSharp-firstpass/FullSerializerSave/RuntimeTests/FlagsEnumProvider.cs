using System.Collections.Generic;

namespace FullSerializerSave.RuntimeTests
{
	public class FlagsEnumProvider : TestProvider<SimpleFlagsEnum>
	{
		public override bool Compare(SimpleFlagsEnum before, SimpleFlagsEnum after)
		{
			return before == after;
		}

		public override IEnumerable<SimpleFlagsEnum> GetValues()
		{
			yield return SimpleFlagsEnum.A;
			yield return SimpleFlagsEnum.A | SimpleFlagsEnum.B;
			yield return SimpleFlagsEnum.B | SimpleFlagsEnum.C | SimpleFlagsEnum.D | SimpleFlagsEnum.E;
		}
	}
}
