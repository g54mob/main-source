using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Description("Sets the Game Object value of a Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	public class SetGameObjectGlobalList : PropertyTypeSetGameObject
	{
		[SerializeField]
		protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueGameObject.TYPE_ID);

		public static PropertySetGameObject Create => new PropertySetGameObject(new SetGameObjectGlobalList());

		public override string String => m_Variable.ToString();

		public override void Set(GameObject value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override GameObject Get(Args args)
		{
			return m_Variable.Get(args) as GameObject;
		}
	}
}
