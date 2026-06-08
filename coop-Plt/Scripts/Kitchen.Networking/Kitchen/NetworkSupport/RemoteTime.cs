namespace Kitchen.NetworkSupport
{
	public struct RemoteTime
	{
		public float Value;

		public static implicit operator RemoteTime(float v)
		{
			return new RemoteTime
			{
				Value = v
			};
		}

		public static implicit operator float(RemoteTime v)
		{
			return v.Value;
		}
	}
}
