using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns the Vector3 value of a Global List Variable")]
	public class GetDirectionGlobalList : PropertyTypeGetDirection
	{
		[SerializeField]
		protected FieldGetGlobalList m_Variable = new FieldGetGlobalList(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Vector3 Get(Args args)
		{
			return m_Variable.Get<Vector3>(args);
		}
	}
}
