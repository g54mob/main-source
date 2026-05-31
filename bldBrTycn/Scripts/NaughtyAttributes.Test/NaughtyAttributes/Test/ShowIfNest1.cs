using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ShowIfNest1
	{
		public bool show1;

		public bool show2;

		public ShowIfEnum enum1;

		[EnumFlags]
		public ShowIfEnumFlag enum2;

		[ShowIf(EConditionOperator.And, new string[] { "Show1", "Show2" })]
		[AllowNesting]
		public int showIfAll;

		[ShowIf(EConditionOperator.Or, new string[] { "Show1", "Show2" })]
		[AllowNesting]
		public int showIfAny;

		[ShowIf("Enum1", ShowIfEnum.Case1)]
		[AllowNesting]
		public int showIfEnum;

		[ShowIf("Enum2", ShowIfEnumFlag.Flag0)]
		[AllowNesting]
		public int showIfEnumFlag;

		[ShowIf("Enum2", ShowIfEnumFlag.Flag0 | ShowIfEnumFlag.Flag1)]
		[AllowNesting]
		public int showIfEnumFlagMulti;

		public ShowIfNest2 nest2;

		public bool Show1 => show1;

		public bool Show2 => show2;

		public ShowIfEnum Enum1 => enum1;

		public ShowIfEnumFlag Enum2 => enum2;
	}
}
