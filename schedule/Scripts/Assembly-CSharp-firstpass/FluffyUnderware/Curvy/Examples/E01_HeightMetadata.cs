using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class E01_HeightMetadata : CurvyInterpolatableMetadataBase<float>
	{
		[RangeEx(0f, 1f, null, null, Slider = true)]
		[SerializeField]
		private float m_Height;

		public override float MetaDataValue => 0f;

		public override float Interpolate(CurvyInterpolatableMetadataBase<float> nextMetadata, float interpolationTime)
		{
			return 0f;
		}
	}
}
