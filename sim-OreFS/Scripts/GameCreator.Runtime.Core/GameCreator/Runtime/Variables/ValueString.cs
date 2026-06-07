using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconString), ColorTheme.Type.Yellow)]
	[Title("String")]
	[Category("Values/String")]
	public class ValueString : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("string");

		[SerializeField]
		private string m_Value = string.Empty;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(string);

		public override bool CanSave => true;

		public override TValue Copy => new ValueString
		{
			m_Value = m_Value
		};

		public ValueString()
		{
		}

		public ValueString(string value)
			: this()
		{
			m_Value = value;
		}

		protected override object Get()
		{
			return m_Value;
		}

		protected override void Set(object value)
		{
			m_Value = value?.ToString() ?? string.Empty;
		}

		public override string ToString()
		{
			if (!string.IsNullOrEmpty(m_Value))
			{
				return "\"" + m_Value + "\"";
			}
			return string.Empty;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInit()
		{
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueString), CreateValue), typeof(string));
		}

		private static ValueString CreateValue(object value)
		{
			return new ValueString(value?.ToString() ?? string.Empty);
		}
	}
}
