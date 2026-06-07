using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns the Material value of a Global List Variable")]
	public class GetMaterialGlobalList : PropertyTypeGetMaterial
	{
		[SerializeField]
		protected FieldGetGlobalList m_Variable = new FieldGetGlobalList(ValueMaterial.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Material Get(Args args)
		{
			return m_Variable.Get<Material>(args);
		}
	}
}
