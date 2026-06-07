namespace UltimateReplay.Core
{
	public struct ReplayEvent : IReplaySerialize
	{
		public byte eventID;

		public ReplayState eventData;

		public void OnReplaySerialize(ReplayState state)
		{
			state.Write(eventID);
			byte value = (byte)eventData.Size;
			state.Write(value);
			state.Write(eventData);
		}

		public void OnReplayDeserialize(ReplayState state)
		{
			eventID = state.ReadByte();
			byte bytes = state.ReadByte();
			eventData = state.ReadState(bytes);
		}
	}
}
