using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	[Description("Returns the Game Object value of a Local Name Variable")]
	public class GetGameObjectLocalName : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected FieldGetLocalName m_Variable = new FieldGetLocalName(ValueGameObject.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override GameObject Get(Args args)
		{
			return m_Variable.Get<GameObject>(args);
		}
	}
}
