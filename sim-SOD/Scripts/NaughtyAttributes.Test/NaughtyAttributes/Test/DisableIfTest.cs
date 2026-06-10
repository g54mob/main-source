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

		[ReorderableList]
		[DisableIf(EConditionOperator.Or, new string[] { "disable1", "disable2" })]
		public int[] disableIfAny;

		[ReorderableList]
		[DisableIf("enum1", DisableIfEnum.Case0)]
		public int[] disableIfEnum;

		[ReorderableList]
		[DisableIf("enum2", DisableIfEnumFlag.Flag0)]
		public int[] disableIfEnumFlag;

		[ReorderableList]
		[DisableIf("enum2", DisableIfEnumFlag.Flag0 | DisableIfEnumFlag.Flag1)]
		public int[] disableIfEnumFlagMulti;

		public DisableIfNest1 nest1;
	}
}
