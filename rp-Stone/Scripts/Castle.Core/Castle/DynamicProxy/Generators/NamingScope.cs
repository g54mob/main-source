using System.Collections.Generic;

namespace Castle.DynamicProxy.Generators
{
	public class NamingScope : INamingScope
	{
		private readonly IDictionary<string, int> names = new Dictionary<string, int>();

		private readonly INamingScope parentScope;

		public INamingScope ParentScope => parentScope;

		public NamingScope()
		{
		}

		private NamingScope(INamingScope parent)
		{
			parentScope = parent;
		}

		public string GetUniqueName(string suggestedName)
		{
			if (!names.TryGetValue(suggestedName, out var value))
			{
				names.Add(suggestedName, 0);
				return suggestedName;
			}
			value++;
			names[suggestedName] = value;
			return suggestedName + "_" + value;
		}

		public INamingScope SafeSubScope()
		{
			return new NamingScope(this);
		}
	}
}
