namespace HumanAPI
{
	public class SteamConsume : SteamPort, IPostEndReset
	{
		public NodeOutput output;

		public int EnableAfterCheckpoint = -1;

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
				return 0f;
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
			if (!isOpenSystem)
			{
				output.SetValue(pressure);
			}
			else
			{
				output.SetValue(0f);
			}
		}

		void IPostEndReset.PostEndResetState(int checkpoint)
		{
			if (EnableAfterCheckpoint != -1)
			{
				output.SetValue((checkpoint > EnableAfterCheckpoint) ? 1 : 0);
			}
		}
	}
}
