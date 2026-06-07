using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the Vector3 value of a Local List Variable")]
	public class GetScaleLocalList : PropertyTypeGetScale
	{
		[SerializeField]
		protected FieldGetLocalList m_Variable = new FieldGetLocalList(ValueVector3.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Vector3 Get(Args args)
		{
			return m_Variable.Get<Vector3>(args);
		}
	}
}
