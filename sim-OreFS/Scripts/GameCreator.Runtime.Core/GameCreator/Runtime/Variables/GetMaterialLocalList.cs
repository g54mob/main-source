using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the Material value of a Local List Variable")]
	public class GetMaterialLocalList : PropertyTypeGetMaterial
	{
		[SerializeField]
		protected FieldGetLocalList m_Variable = new FieldGetLocalList(ValueMaterial.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Material Get(Args args)
		{
			return m_Variable.Get<Material>(args);
		}
	}
}
