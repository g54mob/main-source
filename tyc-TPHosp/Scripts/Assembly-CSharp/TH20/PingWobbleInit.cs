namespace TH20
{
	public class PingWobbleInit : PingInit
	{
		public float WobbleSpeed = 2.3f;

		public float WobbleAmount = 5f;

		public float ScaleSpeed = 3f;

		public float ScaleAmount = 0.3f;

		public override PingBehaviour CreateBehaviour()
		{
			return new PingWobble(this);
		}
	}
}
