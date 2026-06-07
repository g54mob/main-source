using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("Returns the Game Object value of a Global Name Variable")]
	public class GetGameObjectGlobalName : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected FieldGetGlobalName m_Variable = new FieldGetGlobalName(ValueGameObject.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override GameObject Get(Args args)
		{
			return m_Variable.Get<GameObject>(args);
		}
	}
}
