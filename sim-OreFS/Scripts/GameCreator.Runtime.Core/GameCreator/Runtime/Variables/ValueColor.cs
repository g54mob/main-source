using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconColor), ColorTheme.Type.Pink)]
	[Title("Color")]
	[Category("Values/Color")]
	public class ValueColor : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("color");

		[SerializeField]
		[ColorUsage(true, true)]
		private Color m_Value = Color.black;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(Color);

		public override bool CanSave => true;

		public override TValue Copy => new ValueColor
		{
			m_Value = m_Value
		};

		public ValueColor()
		{
		}

		public ValueColor(Color value)
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
			m_Value = ((value is Color color) ? color : Color.black);
		}

		public override string ToString()
		{
			if (!(m_Value.a >= 1f))
			{
				return "#" + ColorUtility.ToHtmlStringRGBA(m_Value);
			}
			return "#" + ColorUtility.ToHtmlStringRGB(m_Value);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInit()
		{
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueColor), CreateValue), typeof(Color));
		}

		private static ValueColor CreateValue(object value)
		{
			return new ValueColor((value is Color color) ? color : default(Color));
		}
	}
}
