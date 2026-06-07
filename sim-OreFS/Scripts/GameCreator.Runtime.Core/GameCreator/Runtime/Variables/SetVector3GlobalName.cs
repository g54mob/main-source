using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Description("Sets the Vector3 value of a Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class SetVector3GlobalName : PropertyTypeSetVector3
	{
		[SerializeField]
		protected FieldSetGlobalName m_Variable = new FieldSetGlobalName(ValueVector3.TYPE_ID);

		public static PropertySetVector3 Create => new PropertySetVector3(new SetVector3GlobalName());

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
