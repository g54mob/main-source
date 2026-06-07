using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Euler Local List Variable")]
	[Category("Variables/Euler Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the euler rotation value of a Local List Variable")]
	public class GetRotationEulerLocalList : PropertyTypeGetRotation
	{
		[SerializeField]
		protected FieldGetLocalList m_Variable = new FieldGetLocalList(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Quaternion Get(Args args)
		{
			return Quaternion.Euler(m_Variable.Get<Vector3>(args));
		}
	}
}
