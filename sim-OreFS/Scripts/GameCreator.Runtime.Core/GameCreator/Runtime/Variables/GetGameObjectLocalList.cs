using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the Game Object value of a Local List Variable")]
	public class GetGameObjectLocalList : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected FieldGetLocalList m_Variable = new FieldGetLocalList(ValueGameObject.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override GameObject Get(Args args)
		{
			return m_Variable.Get<GameObject>(args);
		}
	}
}
