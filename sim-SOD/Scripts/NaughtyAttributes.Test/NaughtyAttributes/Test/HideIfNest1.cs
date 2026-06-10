using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class HideIfNest1
	{
		public bool hide1;

		public bool hide2;

		public HideIfEnum enum1;

		[EnumFlags]
		public HideIfEnumFlag enum2;

		[AllowNesting]
		[HideIf(EConditionOperator.And, new string[] { "Hide1", "Hide2" })]
		public int hideIfAll;

		[AllowNesting]
		[HideIf(EConditionOperator.Or, new string[] { "Hide1", "Hide2" })]
		public int hideIfAny;

		[AllowNesting]
		[HideIf("Enum1", HideIfEnum.Case1)]
		public int hideIfEnum;

		[AllowNesting]
		[HideIf("Enum2", HideIfEnumFlag.Flag0)]
		public int hideIfEnumFlag;

		[AllowNesting]
		[HideIf("Enum2", HideIfEnumFlag.Flag0 | HideIfEnumFlag.Flag1)]
		public int hideIfEnumFlagMulti;

		public HideIfNest2 nest2;

		public bool Hide1 => false;

		public bool Hide2 => false;

		public HideIfEnum Enum1 => default(HideIfEnum);

		public HideIfEnumFlag Enum2 => default(HideIfEnumFlag);
	}
}
