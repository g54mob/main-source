using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

namespace Enviro
{
	public class EnviroVolumetricCloudRenderer
	{
		public Camera camera;

		public Material raymarchMat;

		public Material reprojectMat;

		public Material depthMat;

		public Material blendAndLightingMat;

		public Material shadowMat;

		public RenderTexture[] fullBuffer;

		public int fullBufferIndex;

		public RenderTexture undersampleBuffer;

		public RenderTexture downsampledDepth;

		public Matrix4x4 prevV;

		public int frame;

		public bool firstFrame = true;

		public TextureHandle[] fullBufferHandles;

		public TextureHandle undersampleBufferHandle;

		public TextureHandle downsampledDepthHandle;

		public RTHandle[] fullBufferRTHandles;

		public RTHandle undersampleRTBufferHandle;

		public RTHandle downsampledRTDepthHandle;
	}
}
