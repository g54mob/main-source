using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the Material value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetMaterialLocalName : PropertyTypeSetMaterial
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueMaterial.TYPE_ID);

		public static PropertySetMaterial Create => new PropertySetMaterial(new SetMaterialLocalName());

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
