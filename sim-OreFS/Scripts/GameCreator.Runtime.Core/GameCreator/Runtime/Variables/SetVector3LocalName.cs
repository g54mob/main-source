using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the Vector3 value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetVector3LocalName : PropertyTypeSetVector3
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueVector3.TYPE_ID);

		public static PropertySetVector3 Create => new PropertySetVector3(new SetVector3LocalName());

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
