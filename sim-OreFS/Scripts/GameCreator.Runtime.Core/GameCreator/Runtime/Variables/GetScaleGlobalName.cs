using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("Returns the Vector3 value of a Global Name Variable")]
	public class GetScaleGlobalName : PropertyTypeGetScale
	{
		[SerializeField]
		protected FieldGetGlobalName m_Variable = new FieldGetGlobalName(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Vector3 Get(Args args)
		{
			return m_Variable.Get<Vector3>(args);
		}
	}
}
