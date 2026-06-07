using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Description("Sets the Material value of a Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class SetMaterialGlobalName : PropertyTypeSetMaterial
	{
		[SerializeField]
		protected FieldSetGlobalName m_Variable = new FieldSetGlobalName(ValueMaterial.TYPE_ID);

		public static PropertySetMaterial Create => new PropertySetMaterial(new SetMaterialGlobalName());

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
