using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the Game Object value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetGameObjectLocalList : PropertyTypeSetGameObject
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueGameObject.TYPE_ID);

		public static PropertySetGameObject Create => new PropertySetGameObject(new SetGameObjectLocalList());

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
