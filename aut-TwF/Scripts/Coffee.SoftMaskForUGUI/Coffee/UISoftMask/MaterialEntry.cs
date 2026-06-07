using UnityEngine;

namespace Coffee.UISoftMask
{
	internal class MaterialEntry
	{
		public Material material;

		public int referenceCount;

		public void Release()
		{
			if ((bool)material)
			{
				Object.Destroy(material);
			}
			material = null;
		}
	}
}
