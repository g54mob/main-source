namespace Assets.Scripts.UI.HUD;

public class ScoreContainer
{
	public string header;

	public string description;

	public bool isPositive;

	public bool useSfx;

	public float sizeMultiplier = 1f;

	public ScoreContainer(string header, string description, bool isPositive, bool useSfx, float sizeMultiplier)
	{
		this.header = header;
		this.description = description;
		float num = default(float);
		this.sizeMultiplier = num;
		bool flag = default(bool);
		this.useSfx = flag;
		this.isPositive = isPositive;
	}
}
