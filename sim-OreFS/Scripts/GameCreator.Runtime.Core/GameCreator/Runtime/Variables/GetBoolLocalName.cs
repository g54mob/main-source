using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	[Description("Returns the boolean value of a Local Name Variable")]
	public class GetBoolLocalName : PropertyTypeGetBool
	{
		[SerializeField]
		protected FieldGetLocalName m_Variable = new FieldGetLocalName(ValueBool.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override bool Get(Args args)
		{
			return m_Variable.Get<bool>(args);
		}
	}
}
