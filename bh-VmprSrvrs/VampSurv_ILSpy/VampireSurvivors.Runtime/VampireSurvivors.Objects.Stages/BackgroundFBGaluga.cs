namespace VampireSurvivors.Objects.Stages;

public class BackgroundFBGaluga : BackgroundFBGaluga_Basic
{
	public override void Create()
	{
		base.Create();
	}

	public BackgroundFBGaluga()
	{
		base.DestructibleFrequency = 5000f;
		((BackgroundManager)this)._002Ector();
	}
}
