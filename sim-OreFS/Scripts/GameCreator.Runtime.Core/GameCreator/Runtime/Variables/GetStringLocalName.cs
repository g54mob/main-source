using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	[Description("Returns the string value of a Local Name Variable")]
	public class GetStringLocalName : PropertyTypeGetString
	{
		[SerializeField]
		protected FieldGetLocalName m_Variable = new FieldGetLocalName(ValueString.TYPE_ID);

		public static PropertyGetString Create => new PropertyGetString(new GetStringLocalName());

		public override string String => m_Variable.ToString();

		public override string Get(Args args)
		{
			return m_Variable.Get<string>(args);
		}
	}
}
