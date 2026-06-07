using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("Returns the Material value of a Global Name Variable")]
	public class GetMaterialGlobalName : PropertyTypeGetMaterial
	{
		[SerializeField]
		protected FieldGetGlobalName m_Variable = new FieldGetGlobalName(ValueMaterial.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Material Get(Args args)
		{
			return m_Variable.Get<Material>(args);
		}
	}
}
