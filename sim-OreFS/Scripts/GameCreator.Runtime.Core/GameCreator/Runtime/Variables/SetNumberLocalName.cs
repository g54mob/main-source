using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the numeric value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetNumberLocalName : PropertyTypeSetNumber
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueNumber.TYPE_ID);

		public static PropertySetNumber Create => new PropertySetNumber(new SetNumberLocalName());

		public override string String => m_Variable.ToString();

		public override void Set(double value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override double Get(Args args)
		{
			return (double)m_Variable.Get(args);
		}
	}
}
