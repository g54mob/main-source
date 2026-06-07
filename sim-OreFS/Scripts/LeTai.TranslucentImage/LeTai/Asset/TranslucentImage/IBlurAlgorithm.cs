using UnityEngine;
using UnityEngine.Rendering;

namespace LeTai.Asset.TranslucentImage
{
	public interface IBlurAlgorithm
	{
		void Init(BlurConfig config, bool isBirp);

		void Blur(CommandBuffer cmd, RenderTargetIdentifier src, Rect srcCropRegion, Rect activeRegion, BackgroundFill backgroundFill, RenderTexture target);

		int GetScratchesCount();

		void GetScratchDescriptor(int index, ref RenderTextureDescriptor descriptor);

		void SetScratch(int index, RenderTargetIdentifier value);
	}
}
