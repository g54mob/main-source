using UnityEngine;
using UnityEngine.Rendering;

namespace Aura2API
{
	public class SwappableRenderTexture
	{
		private RenderTexture[] _buffers;

		private int _readId;

		private int _writeId = 1;

		public RenderTexture ReadBuffer => _buffers[_readId];

		public RenderTexture WriteBuffer => _buffers[_writeId];

		public SwappableRenderTexture(int width, int height, int depth, RenderTextureFormat format, RenderTextureReadWrite sRgbSampling, TextureWrapMode wrapMode, FilterMode filterMode)
		{
			_buffers = new RenderTexture[2];
			_buffers[0] = CreateRenderTexture(width, height, depth, format, sRgbSampling, wrapMode, filterMode);
			_buffers[1] = CreateRenderTexture(width, height, depth, format, sRgbSampling, wrapMode, filterMode);
		}

		public SwappableRenderTexture(int width, int height, RenderTextureFormat format, RenderTextureReadWrite sRgbSampling, TextureWrapMode wrapMode, FilterMode filterMode)
			: this(width, height, -1, format, sRgbSampling, wrapMode, filterMode)
		{
		}

		private RenderTexture CreateRenderTexture(int width, int height, int depth, RenderTextureFormat format, RenderTextureReadWrite sRgbSampling, TextureWrapMode wrapMode, FilterMode filterMode)
		{
			RenderTexture renderTexture = new RenderTexture(width, height, 0, format, sRgbSampling);
			if (depth > 0)
			{
				renderTexture.dimension = TextureDimension.Tex3D;
				renderTexture.volumeDepth = depth;
			}
			renderTexture.wrapMode = wrapMode;
			renderTexture.filterMode = filterMode;
			renderTexture.enableRandomWrite = true;
			renderTexture.Create();
			return renderTexture;
		}

		public void Swap()
		{
			int readId = _readId;
			_readId = _writeId;
			_writeId = readId;
		}

		public void Release()
		{
			_buffers[0].Release();
			_buffers[0].Destroy();
			_buffers[0] = null;
			_buffers[1].Release();
			_buffers[1].Destroy();
			_buffers[1] = null;
			_buffers = null;
		}
	}
}
