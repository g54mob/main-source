using System.Collections.Generic;

public class MultilayerAnimation : AsciiAnimation
{
	public List<AsciiAnimation> additionalLayers;

	public override void Play()
	{
		base.Play();
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			additionalLayers[i].Play();
		}
	}

	public override void Stop()
	{
		base.Stop();
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			additionalLayers[i].Stop();
		}
	}

	public override void Pause()
	{
		base.Pause();
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			additionalLayers[i].Pause();
		}
	}

	protected override void Start()
	{
		base.Start();
		base.OnLoop += HandleOnLoop;
	}

	private void HandleOnLoop(AsciiAnimation animation)
	{
		for (int i = 0; i < additionalLayers.Count; i++)
		{
			if (additionalLayers[i].looping)
			{
				additionalLayers[i].ElapsedTime = base.ElapsedTime;
				continue;
			}
			additionalLayers[i].Stop();
			additionalLayers[i].Play();
		}
	}
}
