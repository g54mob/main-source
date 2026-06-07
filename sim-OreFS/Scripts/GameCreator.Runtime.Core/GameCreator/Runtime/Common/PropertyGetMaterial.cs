using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetMaterial : TPropertyGet<PropertyTypeGetMaterial, Material>
	{
		public PropertyGetMaterial()
			: base((PropertyTypeGetMaterial)new GetMaterialInstance())
		{
		}

		public PropertyGetMaterial(PropertyTypeGetMaterial defaultType)
			: base(defaultType)
		{
		}

		public PropertyGetMaterial(Material value)
			: base((PropertyTypeGetMaterial)new GetMaterialInstance(value))
		{
		}
	}
}
