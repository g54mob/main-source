using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Blue)]
	[Title("Game Object")]
	[Category("References/Game Object")]
	public class ValueGameObject : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("game-object");

		[SerializeField]
		private GameObject m_Value;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(GameObject);

		public override bool CanSave => false;

		public override TValue Copy => new ValueGameObject
		{
			m_Value = m_Value
		};

		public ValueGameObject()
		{
		}

		public ValueGameObject(GameObject value)
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
			m_Value = value as GameObject;
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
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueGameObject), CreateValue), typeof(GameObject));
		}

		private static ValueGameObject CreateValue(object value)
		{
			return new ValueGameObject(value as GameObject);
		}
	}
}
