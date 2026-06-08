using Rhizomatic.ImUI;

namespace GRP
{
	public struct TransmitterState
	{
		public TransmitterMode mode;

		public float range;

		public float offset;

		public TransmitterState(TransmitterMode mode, float range, float offset = 0f)
		{
			this.mode = default(TransmitterMode);
			this.range = 0f;
			this.offset = 0f;
		}

		public static void OnUI<T>(T part, ImUIBuilder ui) where T : Part, IWithTransmitter
		{
		}
	}
}
