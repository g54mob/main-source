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

		public TCustom Value => customValue;

		public TEnum EnumValue => enumValue;

		public bool UseCustom => useCustom;

		public PowerEnum(TEnum enumValue, TCustom customValue, bool useCustom)
		{
			this.enumValue = enumValue;
			this.customValue = customValue;
			this.useCustom = useCustom;
		}

		public PowerEnum(TEnum enumValue, TCustom customValue)
		{
			this.enumValue = enumValue;
			this.customValue = customValue;
			useCustom = this.customValue != null;
		}

		public PowerEnum(TEnum enumValue)
			: this()
		{
			this.enumValue = enumValue;
		}

		public PowerEnum()
		{
			customValue = null;
			useCustom = false;
		}
	}
}
