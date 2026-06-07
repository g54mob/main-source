public class Piggy : Module
{
	public override void Init()
	{
		Count();
	}

	public void Count()
	{
		counter = base.board.GetNetworkCount(this);
	}
}
