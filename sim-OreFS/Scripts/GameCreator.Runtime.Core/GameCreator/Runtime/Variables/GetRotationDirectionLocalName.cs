using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Direction Local Name Variable")]
	[Category("Variables/Direction Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	[Description("Returns the direction vector value of a Local Name Variable")]
	public class GetRotationDirectionLocalName : PropertyTypeGetRotation
	{
		[SerializeField]
		protected FieldGetLocalName m_Variable = new FieldGetLocalName(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Quaternion Get(Args args)
		{
			return Quaternion.LookRotation(m_Variable.Get<Vector3>(args));
		}
	}
}
