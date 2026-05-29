using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class EnableIfTest : MonoBehaviour
	{
		public bool enable1;

		public bool enable2;

		public EnableIfEnum enum1;

		[EnumFlags]
		public EnableIfEnumFlag enum2;

		[EnableIf(EConditionOperator.And, new string[] { "enable1", "enable2" })]
		[ReorderableList]
		public int[] enableIfAll;

		[EnableIf(EConditionOperator.Or, new string[] { "enable1", "enable2" })]
		[ReorderableList]
		public int[] enableIfAny;

		[EnableIf("enum1", EnableIfEnum.Case0)]
		[ReorderableList]
		public int[] enableIfEnum;

		[EnableIf("enum2", EnableIfEnumFlag.Flag0)]
		[ReorderableList]
		public int[] enableIfEnumFlag;

		[EnableIf("enum2", EnableIfEnumFlag.Flag0 | EnableIfEnumFlag.Flag1)]
		[ReorderableList]
		public int[] enableIfEnumFlagMulti;

		public EnableIfNest1 nest1;
	}
}
