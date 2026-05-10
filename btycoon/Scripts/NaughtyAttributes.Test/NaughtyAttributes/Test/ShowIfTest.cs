using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ShowIfTest : MonoBehaviour
	{
		public bool show1;

		public bool show2;

		public ShowIfEnum enum1;

		[EnumFlags]
		public ShowIfEnumFlag enum2;

		[ShowIf(EConditionOperator.And, new string[] { "show1", "show2" })]
		[ReorderableList]
		public int[] showIfAll;

		[ShowIf(EConditionOperator.Or, new string[] { "show1", "show2" })]
		[ReorderableList]
		public int[] showIfAny;

		[ShowIf("enum1", ShowIfEnum.Case0)]
		[ReorderableList]
		public int[] showIfEnum;

		[ShowIf("enum2", ShowIfEnumFlag.Flag0)]
		[ReorderableList]
		public int[] showIfEnumFlag;

		[ShowIf("enum2", ShowIfEnumFlag.Flag0 | ShowIfEnumFlag.Flag1)]
		[ReorderableList]
		public int[] showIfEnumFlagMulti;

		public ShowIfNest1 nest1;
	}
}
