using UnityEngine;

namespace VolumetricLines.Utils
{
	public static class TransformExtensionMethods
	{
		public static float GetGlobalUniformScaleForLineWidth(this Transform trans)
		{
			return (trans.lossyScale.x + trans.lossyScale.y + trans.lossyScale.z) / 3f;
		}
	}
}
