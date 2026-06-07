using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconSprite), ColorTheme.Type.Purple)]
	[Title("Sprite")]
	[Category("References/Sprite")]
	public class ValueSprite : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("sprite");

		[SerializeField]
		private Sprite m_Value;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(Sprite);

		public override bool CanSave => false;

		public override TValue Copy => new ValueSprite
		{
			m_Value = m_Value
		};

		public ValueSprite()
		{
		}

		public ValueSprite(Sprite value)
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
			m_Value = ((value is Sprite sprite) ? sprite : null);
		}

		public override string ToString()
		{
			if (!(m_Value != null))
			{
				return "(none)";
			}
			return m_Value.name;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInit()
		{
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueSprite), CreateValue), typeof(Sprite));
		}

		private static ValueSprite CreateValue(object value)
		{
			return new ValueSprite(value as Sprite);
		}
	}
}
