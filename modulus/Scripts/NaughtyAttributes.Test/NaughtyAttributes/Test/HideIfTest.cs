using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class HideIfTest : MonoBehaviour
	{
		public bool hide1;

		public bool hide2;

		public HideIfEnum enum1;

		[EnumFlags]
		public HideIfEnumFlag enum2;

		[HideIf(EConditionOperator.And, new string[] { "hide1", "hide2" })]
		[ReorderableList]
		public int[] hideIfAll;

		[HideIf(EConditionOperator.Or, new string[] { "hide1", "hide2" })]
		[ReorderableList]
		public int[] hideIfAny;

		[HideIf("enum1", HideIfEnum.Case0)]
		[ReorderableList]
		public int[] hideIfEnum;

		[HideIf("enum2", HideIfEnumFlag.Flag0)]
		[ReorderableList]
		public int[] hideIfEnumFlag;

		[HideIf("enum2", HideIfEnumFlag.Flag0 | HideIfEnumFlag.Flag1)]
		[ReorderableList]
		public int[] hideIfEnumFlagMulti;

		public HideIfNest1 nest1;
	}
}
