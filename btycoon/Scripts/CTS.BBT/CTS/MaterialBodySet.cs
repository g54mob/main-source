using UnityEngine;

namespace CTS
{
	public struct MaterialBodySet
	{
		public EBodyMaterial bodyPart;

		public Material material;

		public static MaterialBodySet Create(Material material)
		{
			string name = material.name;
			if (name.Contains("Top"))
			{
				return new MaterialBodySet
				{
					material = material,
					bodyPart = EBodyMaterial.Top
				};
			}
			if (name.Contains("Bot"))
			{
				return new MaterialBodySet
				{
					material = material,
					bodyPart = EBodyMaterial.Bottom
				};
			}
			if (name.Contains("Shoes"))
			{
				return new MaterialBodySet
				{
					material = material,
					bodyPart = EBodyMaterial.Shoes
				};
			}
			if (name.Contains("Fullbody"))
			{
				return new MaterialBodySet
				{
					material = material,
					bodyPart = EBodyMaterial.FullBody
				};
			}
			return new MaterialBodySet
			{
				material = material,
				bodyPart = EBodyMaterial.Top
			};
		}
	}
}
