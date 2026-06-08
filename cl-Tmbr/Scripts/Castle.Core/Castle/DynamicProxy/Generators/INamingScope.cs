namespace Castle.DynamicProxy.Generators
{
	internal interface INamingScope
	{
		INamingScope ParentScope { get; }

		string GetUniqueName(string suggestedName);

		INamingScope SafeSubScope();
	}
}
