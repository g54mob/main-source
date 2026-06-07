namespace Stateless.Reflection
{
	public readonly struct TriggerInfo
	{
		public readonly object UnderlyingTrigger;

		internal TriggerInfo(object underlyingTrigger)
		{
			UnderlyingTrigger = underlyingTrigger;
		}

		public override string ToString()
		{
			return UnderlyingTrigger?.ToString() ?? "<null>";
		}
	}
}
