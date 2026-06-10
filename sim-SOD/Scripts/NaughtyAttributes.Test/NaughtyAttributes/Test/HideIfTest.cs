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

		[ReorderableList]
		[HideIf(EConditionOperator.Or, new string[] { "hide1", "hide2" })]
		public int[] hideIfAny;

		[ReorderableList]
		[HideIf("enum1", HideIfEnum.Case0)]
		public int[] hideIfEnum;

		[ReorderableList]
		[HideIf("enum2", HideIfEnumFlag.Flag0)]
		public int[] hideIfEnumFlag;

		[HideIf("enum2", HideIfEnumFlag.Flag0 | HideIfEnumFlag.Flag1)]
		[ReorderableList]
		public int[] hideIfEnumFlagMulti;

		public HideIfNest1 nest1;
	}
}
