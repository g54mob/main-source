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

		[ReorderableList]
		[EnableIf(EConditionOperator.And, new string[] { "enable1", "enable2" })]
		public int[] enableIfAll;

		[EnableIf(EConditionOperator.Or, new string[] { "enable1", "enable2" })]
		[ReorderableList]
		public int[] enableIfAny;

		[ReorderableList]
		[EnableIf("enum1", EnableIfEnum.Case0)]
		public int[] enableIfEnum;

		[ReorderableList]
		[EnableIf("enum2", EnableIfEnumFlag.Flag0)]
		public int[] enableIfEnumFlag;

		[ReorderableList]
		[EnableIf("enum2", EnableIfEnumFlag.Flag0 | EnableIfEnumFlag.Flag1)]
		public int[] enableIfEnumFlagMulti;

		public EnableIfNest1 nest1;
	}
}
