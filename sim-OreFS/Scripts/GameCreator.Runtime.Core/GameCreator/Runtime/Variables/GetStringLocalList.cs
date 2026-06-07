using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the string value of a Local List Variable")]
	public class GetStringLocalList : PropertyTypeGetString
	{
		[SerializeField]
		protected FieldGetLocalList m_Variable = new FieldGetLocalList(ValueString.TYPE_ID);

		public static PropertyGetString Create => new PropertyGetString(new GetStringLocalList());

		public override string String => m_Variable.ToString();

		public override string Get(Args args)
		{
			return m_Variable.Get<string>(args);
		}
	}
}
