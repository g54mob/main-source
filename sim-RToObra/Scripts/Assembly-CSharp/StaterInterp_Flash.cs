public class StaterInterp_Flash : StaterInterp
{
	private int count;

	public StaterInterp_Flash(int count_)
	{
		count = count_;
	}

	public override float InterpImpl(float interp)
	{
		if (interp >= 0.999f)
		{
			return 1f;
		}
		return (!(interp * (float)count % 1f < 0.5f)) ? 1f : 0f;
	}
}
