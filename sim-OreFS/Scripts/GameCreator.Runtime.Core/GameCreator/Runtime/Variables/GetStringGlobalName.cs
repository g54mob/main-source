using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("Returns the string value of a Global Name Variable")]
	public class GetStringGlobalName : PropertyTypeGetString
	{
		[SerializeField]
		protected FieldGetGlobalName m_Variable = new FieldGetGlobalName(ValueString.TYPE_ID);

		public static PropertyGetString Create => new PropertyGetString(new GetStringGlobalName());

		public override string String => m_Variable.ToString();

		public override string Get(Args args)
		{
			return m_Variable.Get<string>(args);
		}
	}
}
