using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Description("Sets the Game Object value of a Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class SetGameObjectGlobalName : PropertyTypeSetGameObject
	{
		[SerializeField]
		protected FieldSetGlobalName m_Variable = new FieldSetGlobalName(ValueGameObject.TYPE_ID);

		public static PropertySetGameObject Create => new PropertySetGameObject(new SetGameObjectGlobalName());

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
