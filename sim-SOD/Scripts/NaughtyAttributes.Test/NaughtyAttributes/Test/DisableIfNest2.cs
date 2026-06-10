using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class DisableIfNest2
	{
		public bool disable1;

		public bool disable2;

		public DisableIfEnum enum1;

		[EnumFlags]
		public DisableIfEnumFlag enum2;

		[MinMaxSlider(0f, 1f)]
		[DisableIf(EConditionOperator.And, new string[] { "GetDisable1", "GetDisable2" })]
		public Vector2 enableIfAll;

		[DisableIf(EConditionOperator.Or, new string[] { "GetDisable1", "GetDisable2" })]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfAny;

		[MinMaxSlider(0f, 1f)]
		[DisableIf("GetEnum1", DisableIfEnum.Case2)]
		public Vector2 enableIfEnum;

		[MinMaxSlider(0f, 1f)]
		[DisableIf("GetEnum2", DisableIfEnumFlag.Flag0)]
		public Vector2 disableIfEnumFlag;

		[MinMaxSlider(0f, 1f)]
		[DisableIf("GetEnum2", DisableIfEnumFlag.Flag0 | DisableIfEnumFlag.Flag1)]
		public Vector2 disableIfEnumFlagMulti;

		public bool GetDisable1()
		{
			return false;
		}

		public bool GetDisable2()
		{
			return false;
		}

		public DisableIfEnum GetEnum1()
		{
			return default(DisableIfEnum);
		}

		public DisableIfEnumFlag GetEnum2()
		{
			return default(DisableIfEnumFlag);
		}
	}
}
