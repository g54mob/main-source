using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Material Color")]
	[Category("Materials/Material Color")]
	[Image(typeof(IconMaterial), ColorTheme.Type.Yellow)]
	[Description("Returns the material's color")]
	public class GetColorMaterialsMaterial : PropertyTypeGetColor
	{
		[SerializeField]
		protected PropertyGetMaterial m_Material = new PropertyGetMaterial();

		public override string String => $"{m_Material} Color";

		public override Color Get(Args args)
		{
			Material material = m_Material.Get(args);
			if (!(material != null))
			{
				return default(Color);
			}
			return material.color;
		}

		public static PropertyGetColor Create(GameObject gameObject)
		{
			return new PropertyGetColor(new GetColorMaterialsMaterial());
		}
	}
}
