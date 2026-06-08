namespace Castle.DynamicProxy.Generators
{
	public interface INamingScope
	{
		INamingScope ParentScope { get; }

		string GetUniqueName(string suggestedName);

		INamingScope SafeSubScope();
	}
}
