using System;
using System.Globalization;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconNumber), ColorTheme.Type.Blue)]
	[Title("Number")]
	[Category("Values/Number")]
	public class ValueNumber : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("number");

		[SerializeField]
		private double m_Value;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(double);

		public override bool CanSave => true;

		public override TValue Copy => new ValueNumber
		{
			m_Value = m_Value
		};

		public ValueNumber()
		{
		}

		public ValueNumber(float value)
			: this()
		{
			m_Value = value;
		}

		public ValueNumber(double value)
			: this()
		{
			m_Value = value;
		}

		public ValueNumber(int value)
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
			double value2 = ((value is double num) ? num : ((value is float num2) ? ((double)num2) : ((!(value is int num3)) ? 0.0 : ((double)num3))));
			m_Value = value2;
		}

		public override string ToString()
		{
			return m_Value.ToString(CultureInfo.InvariantCulture);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInit()
		{
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueNumber), CreateValue), typeof(double));
		}

		private static ValueNumber CreateValue(object value)
		{
			if (!(value is double value2))
			{
				if (value is float value3)
				{
					return new ValueNumber(value3);
				}
				return new ValueNumber(0);
			}
			return new ValueNumber(value2);
		}
	}
}
