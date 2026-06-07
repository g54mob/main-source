using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class EnablerBool : TEnablerValueCommon
	{
		public enum Bool
		{
			Off = 0,
			On = 1
		}

		[SerializeField]
		private Bool m_Value;

		public bool Value
		{
			get
			{
				return m_Value switch
				{
					Bool.Off => false, 
					Bool.On => true, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			set
			{
				Bool value2 = (value ? Bool.On : Bool.Off);
				m_Value = value2;
			}
		}

		public EnablerBool()
			: this(isEnabled: false, value: true)
		{
		}

		public EnablerBool(bool value)
			: this(isEnabled: false, value)
		{
		}

		public EnablerBool(bool isEnabled, bool value)
			: base(isEnabled)
		{
			Value = value;
		}
	}
}
