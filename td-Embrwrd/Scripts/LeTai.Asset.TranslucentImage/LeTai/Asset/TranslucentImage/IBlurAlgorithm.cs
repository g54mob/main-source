using UnityEngine;
using UnityEngine.Rendering;

namespace LeTai.Asset.TranslucentImage
{
	public interface IBlurAlgorithm
	{
		void Init(BlurConfig config, bool isBirp);

		void Blur(CommandBuffer cmd, RenderTargetIdentifier src, Rect srcCropRegion, Rect activeRegion, BackgroundFill backgroundFill, RenderTexture target);

		int GetScratchesCount(float targetWidth, float targetHeight);

		void GetNextScratchDescriptor(ref RenderTextureDescriptor prevDescriptor);

		void SetScratch(int index, RenderTargetIdentifier value);
	}
}
