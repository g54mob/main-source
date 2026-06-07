namespace Noesis
{
	public interface IProvideValueTarget
	{
		object TargetObject { get; }

		object TargetProperty { get; }
	}
}
