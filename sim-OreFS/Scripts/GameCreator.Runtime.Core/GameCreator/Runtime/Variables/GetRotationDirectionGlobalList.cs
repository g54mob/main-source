using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Direction Global List Variable")]
	[Category("Variables/Direction Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns the direction vector value of a Global List Variable")]
	public class GetRotationDirectionGlobalList : PropertyTypeGetRotation
	{
		[SerializeField]
		protected FieldGetGlobalList m_Variable = new FieldGetGlobalList(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Quaternion Get(Args args)
		{
			return Quaternion.LookRotation(m_Variable.Get<Vector3>(args));
		}
	}
}
