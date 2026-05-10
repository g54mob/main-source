namespace Animancer
{
	public interface IHasEvents
	{
		AnimancerEvent.Sequence Events { get; }

		ref AnimancerEvent.Sequence.Serializable SerializedEvents { get; }
	}
}
