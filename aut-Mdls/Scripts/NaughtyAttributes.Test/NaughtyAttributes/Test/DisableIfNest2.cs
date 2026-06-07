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

		[DisableIf(EConditionOperator.And, new string[] { "GetDisable1", "GetDisable2" })]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfAll = new Vector2(0.25f, 0.75f);

		[DisableIf(EConditionOperator.Or, new string[] { "GetDisable1", "GetDisable2" })]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfAny = new Vector2(0.25f, 0.75f);

		[DisableIf("GetEnum1", DisableIfEnum.Case2)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfEnum = new Vector2(0.25f, 0.75f);

		[DisableIf("GetEnum2", DisableIfEnumFlag.Flag0)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 disableIfEnumFlag;

		[DisableIf("GetEnum2", DisableIfEnumFlag.Flag0 | DisableIfEnumFlag.Flag1)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 disableIfEnumFlagMulti;

		public bool GetDisable1()
		{
			return disable1;
		}

		public bool GetDisable2()
		{
			return disable2;
		}

		public DisableIfEnum GetEnum1()
		{
			return enum1;
		}

		public DisableIfEnumFlag GetEnum2()
		{
			return enum2;
		}
	}
}
