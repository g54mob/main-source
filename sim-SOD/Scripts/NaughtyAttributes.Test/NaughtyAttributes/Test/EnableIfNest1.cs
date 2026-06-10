using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class EnableIfNest1
	{
		public bool enable1;

		public bool enable2;

		public EnableIfEnum enum1;

		[EnumFlags]
		public EnableIfEnumFlag enum2;

		[AllowNesting]
		[EnableIf(EConditionOperator.And, new string[] { "Enable1", "Enable2" })]
		public int enableIfAll;

		[AllowNesting]
		[EnableIf(EConditionOperator.Or, new string[] { "Enable1", "Enable2" })]
		public int enableIfAny;

		[EnableIf("Enum1", EnableIfEnum.Case1)]
		[AllowNesting]
		public int enableIfEnum;

		[AllowNesting]
		[EnableIf("Enum2", EnableIfEnumFlag.Flag0)]
		public int enableIfEnumFlag;

		[AllowNesting]
		[EnableIf("Enum2", EnableIfEnumFlag.Flag0 | EnableIfEnumFlag.Flag1)]
		public int enableIfEnumFlagMulti;

		public EnableIfNest2 nest2;

		public bool Enable1 => false;

		public bool Enable2 => false;

		public EnableIfEnum Enum1 => default(EnableIfEnum);

		public EnableIfEnumFlag Enum2 => default(EnableIfEnumFlag);
	}
}
