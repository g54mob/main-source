using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class DisableIfTest : MonoBehaviour
	{
		public bool disable1;

		public bool disable2;

		public DisableIfEnum enum1;

		[EnumFlags]
		public DisableIfEnumFlag enum2;

		[DisableIf(EConditionOperator.And, new string[] { "disable1", "disable2" })]
		[ReorderableList]
		public int[] disableIfAll;

		[DisableIf(EConditionOperator.Or, new string[] { "disable1", "disable2" })]
		[ReorderableList]
		public int[] disableIfAny;

		[DisableIf("enum1", DisableIfEnum.Case0)]
		[ReorderableList]
		public int[] disableIfEnum;

		[DisableIf("enum2", DisableIfEnumFlag.Flag0)]
		[ReorderableList]
		public int[] disableIfEnumFlag;

		[DisableIf("enum2", DisableIfEnumFlag.Flag0 | DisableIfEnumFlag.Flag1)]
		[ReorderableList]
		public int[] disableIfEnumFlagMulti;

		public DisableIfNest1 nest1;
	}
}
