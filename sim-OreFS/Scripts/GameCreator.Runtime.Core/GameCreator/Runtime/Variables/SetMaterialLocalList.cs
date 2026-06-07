using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the Material value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetMaterialLocalList : PropertyTypeSetMaterial
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueMaterial.TYPE_ID);

		public static PropertySetMaterial Create => new PropertySetMaterial(new SetMaterialLocalList());

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
