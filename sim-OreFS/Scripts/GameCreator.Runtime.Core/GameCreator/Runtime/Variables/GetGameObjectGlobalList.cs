using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns the Game Object value of a Global List Variable")]
	public class GetGameObjectGlobalList : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected FieldGetGlobalList m_Variable = new FieldGetGlobalList(ValueGameObject.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override GameObject Get(Args args)
		{
			return m_Variable.Get<GameObject>(args);
		}
	}
}
