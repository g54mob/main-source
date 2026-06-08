namespace Bindito.Core
{
	public interface ISingleBindingBuilder<TBound> : IBindingBuilder<TBound>, IScopeAssignee where TBound : class
	{
	}
}
