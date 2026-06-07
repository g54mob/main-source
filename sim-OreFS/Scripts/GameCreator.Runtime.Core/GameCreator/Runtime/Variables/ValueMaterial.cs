using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconMaterial), ColorTheme.Type.Blue)]
	[Title("Material")]
	[Category("References/Material")]
	public class ValueMaterial : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("material");

		[SerializeField]
		private Material m_Value;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(Material);

		public override bool CanSave => false;

		public override TValue Copy => new ValueMaterial
		{
			m_Value = m_Value
		};

		public ValueMaterial()
		{
		}

		public ValueMaterial(Material value)
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
			m_Value = value as Material;
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
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueMaterial), CreateValue), typeof(Material));
		}

		private static ValueMaterial CreateValue(object value)
		{
			return new ValueMaterial(value as Material);
		}
	}
}
