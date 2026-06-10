using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ShowIfNest2
	{
		public bool show1;

		public bool show2;

		public ShowIfEnum enum1;

		[EnumFlags]
		public ShowIfEnumFlag enum2;

		[MinMaxSlider(0f, 1f)]
		[ShowIf(EConditionOperator.And, new string[] { "GetShow1", "GetShow2" })]
		public Vector2 showIfAll;

		[MinMaxSlider(0f, 1f)]
		[ShowIf(EConditionOperator.Or, new string[] { "GetShow1", "GetShow2" })]
		public Vector2 showIfAny;

		[MinMaxSlider(0f, 1f)]
		[ShowIf("GetEnum1", ShowIfEnum.Case2)]
		public Vector2 showIfEnum;

		[MinMaxSlider(0f, 1f)]
		[ShowIf("GetEnum2", ShowIfEnumFlag.Flag0)]
		public Vector2 showIfEnumFlag;

		[ShowIf("GetEnum2", ShowIfEnumFlag.Flag0 | ShowIfEnumFlag.Flag1)]
		[MinMaxSlider(0f, 1f)]
		public Vector2 showIfEnumFlagMulti;

		public bool GetShow1()
		{
			return false;
		}

		public bool GetShow2()
		{
			return false;
		}

		public ShowIfEnum GetEnum1()
		{
			return default(ShowIfEnum);
		}

		public ShowIfEnumFlag GetEnum2()
		{
			return default(ShowIfEnumFlag);
		}
	}
}
