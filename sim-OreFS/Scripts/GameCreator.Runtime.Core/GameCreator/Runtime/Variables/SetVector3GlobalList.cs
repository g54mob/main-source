using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Description("Sets the Vector3 value of a Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	public class SetVector3GlobalList : PropertyTypeSetVector3
	{
		[SerializeField]
		protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueVector3.TYPE_ID);

		public static PropertySetVector3 Create => new PropertySetVector3(new SetVector3GlobalList());

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
