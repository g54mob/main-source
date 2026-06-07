using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	[Description("Returns the Vector3 value of a Local Name Variable")]
	public class GetScaleLocalName : PropertyTypeGetScale
	{
		[SerializeField]
		protected FieldGetLocalName m_Variable = new FieldGetLocalName(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Vector3 Get(Args args)
		{
			return m_Variable.Get<Vector3>(args);
		}
	}
}
