using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the numeric value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetNumberLocalList : PropertyTypeSetNumber
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueNumber.TYPE_ID);

		public static PropertySetNumber Create => new PropertySetNumber(new SetNumberLocalList());

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
