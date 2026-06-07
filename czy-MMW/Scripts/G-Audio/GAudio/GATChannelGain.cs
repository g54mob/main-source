namespace GAudio
{
	public class GATChannelGain
	{
		protected float _gain;

		public int ChannelNumber { get; protected set; }

		public virtual float Gain
		{
			get
			{
				return _gain;
			}
			protected set
			{
				_gain = value;
			}
		}

		public GATChannelGain(int ichannelnumber, float igain)
		{
			ChannelNumber = ichannelnumber;
			Gain = igain;
		}
	}
}
