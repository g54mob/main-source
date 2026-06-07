using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the Vector3 value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetVector3LocalList : PropertyTypeSetVector3
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueVector3.TYPE_ID);

		public static PropertySetVector3 Create => new PropertySetVector3(new SetVector3LocalList());

		public override string String => m_Variable.ToString();

		public override void Set(Vector3 value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override Vector3 Get(Args args)
		{
			return (Vector3)m_Variable.Get(args);
		}
	}
}
