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

		[EnableIf(EConditionOperator.And, new string[] { "Enable1", "Enable2" })]
		[AllowNesting]
		public int enableIfAll;

		[EnableIf(EConditionOperator.Or, new string[] { "Enable1", "Enable2" })]
		[AllowNesting]
		public int enableIfAny;

		[EnableIf("Enum1", EnableIfEnum.Case1)]
		[AllowNesting]
		public int enableIfEnum;

		[EnableIf("Enum2", EnableIfEnumFlag.Flag0)]
		[AllowNesting]
		public int enableIfEnumFlag;

		[EnableIf("Enum2", EnableIfEnumFlag.Flag0 | EnableIfEnumFlag.Flag1)]
		[AllowNesting]
		public int enableIfEnumFlagMulti;

		public EnableIfNest2 nest2;

		public bool Enable1 => enable1;

		public bool Enable2 => enable2;

		public EnableIfEnum Enum1 => enum1;

		public EnableIfEnumFlag Enum2 => enum2;
	}
}
