using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Direction Global Name Variable")]
	[Category("Variables/Direction Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("Returns the direction vector value of a Global Name Variable")]
	public class GetRotationDirectionGlobalName : PropertyTypeGetRotation
	{
		[SerializeField]
		protected FieldGetGlobalName m_Variable = new FieldGetGlobalName(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Quaternion Get(Args args)
		{
			return Quaternion.LookRotation(m_Variable.Get<Vector3>(args));
		}
	}
}
