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

		[HideIf(EConditionOperator.And, new string[] { "Hide1", "Hide2" })]
		[AllowNesting]
		public int hideIfAll;

		[HideIf(EConditionOperator.Or, new string[] { "Hide1", "Hide2" })]
		[AllowNesting]
		public int hideIfAny;

		[HideIf("Enum1", HideIfEnum.Case1)]
		[AllowNesting]
		public int hideIfEnum;

		[HideIf("Enum2", HideIfEnumFlag.Flag0)]
		[AllowNesting]
		public int hideIfEnumFlag;

		[HideIf("Enum2", HideIfEnumFlag.Flag0 | HideIfEnumFlag.Flag1)]
		[AllowNesting]
		public int hideIfEnumFlagMulti;

		public HideIfNest2 nest2;

		public bool Hide1 => hide1;

		public bool Hide2 => hide2;

		public HideIfEnum Enum1 => enum1;

		public HideIfEnumFlag Enum2 => enum2;
	}
}
