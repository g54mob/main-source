using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class DisableIfNest1
	{
		public bool disable1;

		public bool disable2;

		public DisableIfEnum enum1;

		[EnumFlags]
		public DisableIfEnumFlag enum2;

		[DisableIf(EConditionOperator.And, new string[] { "Disable1", "Disable2" })]
		[AllowNesting]
		public int disableIfAll = 1;

		[DisableIf(EConditionOperator.Or, new string[] { "Disable1", "Disable2" })]
		[AllowNesting]
		public int disableIfAny = 2;

		[DisableIf("Enum1", DisableIfEnum.Case1)]
		[AllowNesting]
		public int disableIfEnum = 3;

		[DisableIf("Enum2", DisableIfEnumFlag.Flag0)]
		[AllowNesting]
		public int disableIfEnumFlag;

		[DisableIf("Enum2", DisableIfEnumFlag.Flag0 | DisableIfEnumFlag.Flag1)]
		[AllowNesting]
		public int disableIfEnumFlagMulti;

		public DisableIfNest2 nest2;

		public bool Disable1 => disable1;

		public bool Disable2 => disable2;

		public DisableIfEnum Enum1 => enum1;

		public DisableIfEnumFlag Enum2 => enum2;
	}
}
