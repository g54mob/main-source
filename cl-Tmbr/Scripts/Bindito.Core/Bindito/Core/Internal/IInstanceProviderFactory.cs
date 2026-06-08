namespace Bindito.Core.Internal
{
	public interface IInstanceProviderFactory
	{
		InstanceProvider CreateInstanceProvider(Binding binding);
	}
}
