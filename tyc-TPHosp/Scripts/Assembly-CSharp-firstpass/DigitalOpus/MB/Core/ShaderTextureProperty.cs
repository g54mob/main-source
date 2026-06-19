using System;
using System.Collections.Generic;

namespace DigitalOpus.MB.Core
{
	[Serializable]
	public class ShaderTextureProperty
	{
		public string name;

		public bool isNormalMap;

		public ShaderTextureProperty(string n, bool norm)
		{
			name = n;
			isNormalMap = norm;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ShaderTextureProperty))
			{
				return false;
			}
			ShaderTextureProperty shaderTextureProperty = (ShaderTextureProperty)obj;
			if (!name.Equals(shaderTextureProperty.name))
			{
				return false;
			}
			if (isNormalMap != shaderTextureProperty.isNormalMap)
			{
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static string[] GetNames(List<ShaderTextureProperty> props)
		{
			string[] array = new string[props.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = props[i].name;
			}
			return array;
		}
	}
}
