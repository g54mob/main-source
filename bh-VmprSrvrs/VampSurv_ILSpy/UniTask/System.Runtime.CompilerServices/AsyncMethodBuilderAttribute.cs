namespace System.Runtime.CompilerServices;

internal sealed class AsyncMethodBuilderAttribute : Attribute
{
	private readonly Type _003CBuilderType_003Ek__BackingField;

	public Type BuilderType => _003CBuilderType_003Ek__BackingField;

	public AsyncMethodBuilderAttribute(Type builderType)
	{
		_003CBuilderType_003Ek__BackingField = builderType;
	}
}
