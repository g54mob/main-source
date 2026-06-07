using UnityEngine;

[CreateAssetMenu(fileName = "GaussianBlur.asset", menuName = "GaussianBlur", order = 42)]
public class GaussianBlur : ScriptableObject
{
	public enum Channel
	{
		RGBA = 0,
		R = 1,
		G = 2,
		B = 3,
		A = 4
	}

	public class Params
	{
		public float scale = 1f;

		public float stepSize = 1f;

		public int numPasses = 1;

		public Channel channel;

		public Params()
		{
		}

		public Params(float scale_, float stepSize_ = 1f, int numPasses_ = 1, Channel channel_ = Channel.RGBA)
		{
			scale = scale_;
			stepSize = stepSize_;
			numPasses = numPasses_;
			channel = channel_;
		}
	}

	public Shader shader;

	private Material material;

	public RenderTargetPool.Temp BlurToTemp(RenderTexture target, Params p)
	{
		return BlurToTemp(target, p.scale, p.stepSize, p.numPasses, p.channel);
	}

	public RenderTargetPool.Temp BlurToTemp(RenderTexture target, float scale, float stepSize = 1f, int numPasses = 1, Channel channel = Channel.RGBA)
	{
		if (material == null)
		{
			material = new Material(shader);
		}
		if (channel == Channel.RGBA)
		{
			material.DisableKeyword("GAUSSIAN_SELECTCHANNELS");
		}
		else
		{
			material.EnableKeyword("GAUSSIAN_SELECTCHANNELS");
			if (channel == Channel.R)
			{
				material.SetVector("_OnlyChannels", new Vector4(1f, 0f, 0f, 0f));
			}
			if (channel == Channel.G)
			{
				material.SetVector("_OnlyChannels", new Vector4(0f, 1f, 0f, 0f));
			}
			if (channel == Channel.B)
			{
				material.SetVector("_OnlyChannels", new Vector4(0f, 0f, 1f, 0f));
			}
			if (channel == Channel.A)
			{
				material.SetVector("_OnlyChannels", new Vector4(0f, 0f, 0f, 1f));
			}
		}
		RenderTargetPool.Temp temp = RenderTargetPool.CreateTemp(target, scale);
		RenderTargetPool.Temp temp2 = RenderTargetPool.CreateTemp(target, scale);
		temp.rt.filterMode = FilterMode.Bilinear;
		temp2.rt.filterMode = FilterMode.Bilinear;
		RenderTarget.BlitBilinear(target, temp);
		for (int i = 0; i < numPasses; i++)
		{
			material.SetVector("_BlurStep", new Vector4(stepSize, 0f, 0f, 0f));
			RenderTarget.Blit((RenderTexture)temp, temp2, material);
			material.SetVector("_BlurStep", new Vector4(0f, stepSize, 0f, 0f));
			RenderTarget.Blit((RenderTexture)temp2, temp, material);
		}
		temp2.Release();
		return temp;
	}
}
