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
		public Vector2 enableIfAll = new Vector2(0.25f, 0.75f);

		[EnableIf(EConditionOperator.Or, new string[] { "GetEnable1", "GetEnable2" })]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfAny = new Vector2(0.25f, 0.75f);

		[EnableIf("GetEnum1", EnableIfEnum.Case2)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfEnum = new Vector2(0.25f, 0.75f);

		[EnableIf("GetEnum2", EnableIfEnumFlag.Flag0)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfEnumFlag;

		[EnableIf("GetEnum2", EnableIfEnumFlag.Flag0 | EnableIfEnumFlag.Flag1)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 enableIfEnumFlagMulti;

		public bool GetEnable1()
		{
			return enable1;
		}

		public bool GetEnable2()
		{
			return enable2;
		}

		public EnableIfEnum GetEnum1()
		{
			return enum1;
		}

		public EnableIfEnumFlag GetEnum2()
		{
			return enum2;
		}
	}
}
