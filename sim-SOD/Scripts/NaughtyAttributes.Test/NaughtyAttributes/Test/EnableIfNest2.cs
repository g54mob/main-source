using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class EnableIfNest2
	{
		public bool enable1;

		public bool enable2;

		public EnableIfEnum enum1;

		[EnumFlags]
		public EnableIfEnumFlag enum2;

		[EnableIf(EConditionOperator.And, new string[] { "GetEnable1", "GetEnable2" })]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfAll;

		[MinMaxSlider(0f, 1f)]
		[EnableIf(EConditionOperator.Or, new string[] { "GetEnable1", "GetEnable2" })]
		public Vector2 enableIfAny;

		[EnableIf("GetEnum1", EnableIfEnum.Case2)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfEnum;

		[EnableIf("GetEnum2", EnableIfEnumFlag.Flag0)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfEnumFlag;

		[MinMaxSlider(0f, 1f)]
		[EnableIf("GetEnum2", EnableIfEnumFlag.Flag0 | EnableIfEnumFlag.Flag1)]
		public Vector2 enableIfEnumFlagMulti;

		public bool GetEnable1()
		{
			return false;
		}

		public bool GetEnable2()
		{
			return false;
		}

		public EnableIfEnum GetEnum1()
		{
			return default(EnableIfEnum);
		}

		public EnableIfEnumFlag GetEnum2()
		{
			return default(EnableIfEnumFlag);
		}
	}
}
