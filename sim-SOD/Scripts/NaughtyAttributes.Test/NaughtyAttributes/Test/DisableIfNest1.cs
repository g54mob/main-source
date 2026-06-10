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
		public int disableIfAll;

		[AllowNesting]
		[DisableIf(EConditionOperator.Or, new string[] { "Disable1", "Disable2" })]
		public int disableIfAny;

		[AllowNesting]
		[DisableIf("Enum1", DisableIfEnum.Case1)]
		public int disableIfEnum;

		[AllowNesting]
		[DisableIf("Enum2", DisableIfEnumFlag.Flag0)]
		public int disableIfEnumFlag;

		[AllowNesting]
		[DisableIf("Enum2", DisableIfEnumFlag.Flag0 | DisableIfEnumFlag.Flag1)]
		public int disableIfEnumFlagMulti;

		public DisableIfNest2 nest2;

		public bool Disable1 => false;

		public bool Disable2 => false;

		public DisableIfEnum Enum1 => default(DisableIfEnum);

		public DisableIfEnumFlag Enum2 => default(DisableIfEnumFlag);
	}
}
