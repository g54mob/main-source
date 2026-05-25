namespace HumanAPI
{
	public class SteamSource : SteamPort
	{
		public NodeInput pressure;

		public override bool isOpen
		{
			get
			{
				return false;
			}
		}

		public override float ownPressure
		{
			get
			{
				return pressure.value;
			}
		}

		public override SteamPort connectedPort
		{
			get
			{
				return null;
			}
		}

		public override void ApplySystemState(bool isOpenSystem, float pressure)
		{
		}

		public override void Process()
		{
			base.Process();
			SteamSystem.Recalculate(node);
		}
	}
}
