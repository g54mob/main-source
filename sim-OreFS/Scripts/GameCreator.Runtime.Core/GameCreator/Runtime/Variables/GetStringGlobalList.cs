using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns the string value of a Global List Variable")]
	public class GetStringGlobalList : PropertyTypeGetString
	{
		[SerializeField]
		protected FieldGetGlobalList m_Variable = new FieldGetGlobalList(ValueString.TYPE_ID);

		public static PropertyGetString Create => new PropertyGetString(new GetStringGlobalList());

		public override string String => m_Variable.ToString();

		public override string Get(Args args)
		{
			return m_Variable.Get<string>(args);
		}
	}
}
