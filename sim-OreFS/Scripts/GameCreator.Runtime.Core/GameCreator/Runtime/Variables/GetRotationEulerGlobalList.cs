using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Euler Global List Variable")]
	[Category("Variables/Euler Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns the euler rotation value of a Global List Variable")]
	public class GetRotationEulerGlobalList : PropertyTypeGetRotation
	{
		[SerializeField]
		protected FieldGetGlobalList m_Variable = new FieldGetGlobalList(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Quaternion Get(Args args)
		{
			return Quaternion.Euler(m_Variable.Get<Vector3>(args));
		}
	}
}
