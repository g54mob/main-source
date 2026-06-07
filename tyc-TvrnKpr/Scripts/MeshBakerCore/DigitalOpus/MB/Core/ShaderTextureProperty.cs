using System;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	[Serializable]
	public class ShaderTextureProperty
	{
		public string name;

		public bool isNormalMap;

		public bool isGammaCorrected;

		[HideInInspector]
		public bool isNormalDontKnow;

		public ShaderTextureProperty(string n, bool norm)
		{
		}

		public ShaderTextureProperty(string n, bool norm, bool isGamma, bool isNormalDontKnow)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static string[] GetNames(List<ShaderTextureProperty> props)
		{
			return null;
		}
	}
}
