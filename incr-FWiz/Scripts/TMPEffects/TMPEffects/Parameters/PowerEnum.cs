using System;
using UnityEngine;

namespace TMPEffects.Parameters
{
	[Serializable]
	public abstract class PowerEnum<TEnum, TCustom> where TEnum : Enum where TCustom : UnityEngine.Object
	{
		[SerializeField]
		private TEnum enumValue;

		[SerializeField]
		private TCustom customValue;

		[SerializeField]
		protected bool useCustom;

		public TCustom Value => null;

		public TEnum EnumValue => default(TEnum);

		public bool UseCustom => false;

		public PowerEnum(TEnum enumValue, TCustom customValue, bool useCustom)
		{
		}

		public PowerEnum(TEnum enumValue, TCustom customValue)
		{
		}

		public PowerEnum(TEnum enumValue)
		{
		}

		public PowerEnum()
		{
		}
	}
}
