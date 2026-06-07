using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Euler Global Name Variable")]
	[Category("Variables/Euler Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("Returns the euler rotation value of a Global Name Variable")]
	public class GetRotationEulerGlobalName : PropertyTypeGetRotation
	{
		[SerializeField]
		protected FieldGetGlobalName m_Variable = new FieldGetGlobalName(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Quaternion Get(Args args)
		{
			return Quaternion.Euler(m_Variable.Get<Vector3>(args));
		}
	}
}
