using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the Game Object value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetGameObjectLocalName : PropertyTypeSetGameObject
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueGameObject.TYPE_ID);

		public static PropertySetGameObject Create => new PropertySetGameObject(new SetGameObjectLocalName());

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
