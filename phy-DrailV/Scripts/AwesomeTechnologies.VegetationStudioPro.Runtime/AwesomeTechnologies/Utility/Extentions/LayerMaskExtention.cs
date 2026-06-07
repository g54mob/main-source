using UnityEngine;

namespace AwesomeTechnologies.Utility.Extentions
{
	public static class LayerMaskExtention
	{
		public static bool Contains(this LayerMask mask, int layer)
		{
			return (int)mask == ((int)mask | (1 << layer));
		}
	}
}
