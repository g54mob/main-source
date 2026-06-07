using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconToggleOn), ColorTheme.Type.Red)]
	[Title("Boolean")]
	[Category("Values/Boolean")]
	public class ValueBool : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("boolean");

		[SerializeField]
		private bool m_Value;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(bool);

		public override bool CanSave => true;

		public override TValue Copy => new ValueBool
		{
			m_Value = m_Value
		};

		public ValueBool()
		{
		}

		public ValueBool(bool value)
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
			m_Value = value is bool && (bool)value;
		}

		public override string ToString()
		{
			if (!m_Value)
			{
				return "False";
			}
			return "True";
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInit()
		{
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueBool), CreateValue), typeof(bool));
		}

		private static ValueBool CreateValue(object value)
		{
			return new ValueBool(value is bool flag && flag);
		}
	}
}
