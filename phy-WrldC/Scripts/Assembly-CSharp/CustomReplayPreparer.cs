using UltimateReplay;
using UltimateReplay.Core;

public class CustomReplayPreparer : DefaultReplayPreparer
{
	public override void PrepareForPlayback(ReplayObject replayObject)
	{
		base.PrepareForPlayback(replayObject);
	}

	public override void PrepareForGameplay(ReplayObject replayObject)
	{
		base.PrepareForGameplay(replayObject);
		ParticlesLifeControl component = replayObject.GetComponent<ParticlesLifeControl>();
		if (component != null)
		{
			component.ShouldStopControl = false;
		}
		DecalLifeControl component2 = replayObject.GetComponent<DecalLifeControl>();
		if (component2 != null)
		{
			component2.ShouldStopControl = false;
		}
	}
}
