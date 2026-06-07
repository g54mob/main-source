using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Description("Sets the Material value of a Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	public class SetMaterialGlobalList : PropertyTypeSetMaterial
	{
		[SerializeField]
		protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueMaterial.TYPE_ID);

		public static PropertySetMaterial Create => new PropertySetMaterial(new SetMaterialGlobalList());

		public override string String => m_Variable.ToString();

		public override void Set(Material value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override Material Get(Args args)
		{
			return m_Variable.Get(args) as Material;
		}
	}
}
