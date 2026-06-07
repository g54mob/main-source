using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class TextureBlenderMaterialPropertyCacheHelper
	{
		private struct MaterialPropertyPair
		{
			public Material material;

			public string property;

			public MaterialPropertyPair(Material m, string prop)
			{
				material = null;
				property = null;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		private Dictionary<MaterialPropertyPair, object> nonTexturePropertyValuesForSourceMaterials;

		private bool AllNonTexturePropertyValuesAreEqual(string prop)
		{
			return false;
		}

		public void CacheMaterialProperty(Material m, string property, object value)
		{
		}

		public object GetValueIfAllSourceAreTheSameOrDefault(string property, object defaultValue)
		{
			return null;
		}
	}
}
