using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

namespace LeTai.Asset.TranslucentImage.UniversalRP
{
	[MovedFrom("LeTai.Asset.TranslucentImage.LWRP")]
	internal struct TISPassData
	{
		public RenderTargetIdentifier cameraColorTarget;

		public TranslucentImageSource blurSource;

		public IBlurAlgorithm blurAlgorithm;

		public bool isPreviewing;
	}
}
