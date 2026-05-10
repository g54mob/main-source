using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class HideIfNest2
	{
		public bool hide1;

		public bool hide2;

		public HideIfEnum enum1;

		[EnumFlags]
		public HideIfEnumFlag enum2;

		[HideIf(EConditionOperator.And, new string[] { "GetHide1", "GetHide2" })]
		[MinMaxSlider(0f, 1f)]
		public Vector2 hideIfAll;

		[HideIf(EConditionOperator.Or, new string[] { "GetHide1", "GetHide2" })]
		[MinMaxSlider(0f, 1f)]
		public Vector2 hideIfAny;

		[HideIf("GetEnum1", HideIfEnum.Case2)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 hideIfEnum;

		[HideIf("GetEnum2", HideIfEnumFlag.Flag0)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 hideIfEnumFlag;

		[HideIf("GetEnum2", HideIfEnumFlag.Flag0 | HideIfEnumFlag.Flag1)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 hideIfEnumFlagMulti;

		public bool GetHide1()
		{
			return false;
		}

		public bool GetHide2()
		{
			return false;
		}

		public HideIfEnum GetEnum1()
		{
			return default(HideIfEnum);
		}

		public HideIfEnumFlag GetEnum2()
		{
			return default(HideIfEnumFlag);
		}
	}
}
