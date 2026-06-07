using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconTexture), ColorTheme.Type.Blue)]
	[Title("Texture")]
	[Category("References/Texture")]
	public class ValueTexture : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("texture");

		[SerializeField]
		private Texture m_Value;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(Texture);

		public override bool CanSave => false;

		public override TValue Copy => new ValueTexture
		{
			m_Value = m_Value
		};

		public ValueTexture()
		{
		}

		public ValueTexture(Texture value)
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
			m_Value = ((value is Texture texture) ? texture : null);
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
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueTexture), CreateValue), typeof(Texture));
		}

		private static ValueTexture CreateValue(object value)
		{
			return new ValueTexture(value as Texture);
		}
	}
}
