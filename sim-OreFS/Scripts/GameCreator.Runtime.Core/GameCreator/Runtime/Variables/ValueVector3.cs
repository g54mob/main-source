using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	[Title("Vector3")]
	[Category("Values/Vector3")]
	public class ValueVector3 : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("vector3");

		[SerializeField]
		private Vector3 m_Value = Vector3.zero;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(Vector3);

		public override bool CanSave => true;

		public override TValue Copy => new ValueVector3
		{
			m_Value = m_Value
		};

		public ValueVector3()
		{
		}

		public ValueVector3(Vector2 value)
			: this()
		{
			m_Value = value;
		}

		public ValueVector3(Vector3 value)
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
			m_Value = ((value is Vector3 vector) ? vector : Vector3.zero);
		}

		public override string ToString()
		{
			return m_Value.ToString();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInit()
		{
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueVector3), CreateValue), typeof(Vector3));
		}

		private static ValueVector3 CreateValue(object value)
		{
			return new ValueVector3((value is Vector3 vector) ? vector : default(Vector3));
		}
	}
}
