using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Direction Local List Variable")]
	[Category("Variables/Direction Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the direction vector value of a Local List Variable")]
	public class GetRotationDirectionLocalList : PropertyTypeGetRotation
	{
		[SerializeField]
		protected FieldGetLocalList m_Variable = new FieldGetLocalList(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Quaternion Get(Args args)
		{
			return Quaternion.LookRotation(m_Variable.Get<Vector3>(args));
		}
	}
}
