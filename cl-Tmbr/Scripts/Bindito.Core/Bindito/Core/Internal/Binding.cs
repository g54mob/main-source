namespace Bindito.Core.Internal
{
	public class Binding
	{
		public ProvisionBinding ProvisionBinding { get; }

		public Scope Scope { get; }

		public bool Exported { get; }

		public Binding(ProvisionBinding provisionBinding, Scope scope, bool exported)
		{
			Scope = scope;
			ProvisionBinding = provisionBinding;
			Exported = exported;
		}

		public override string ToString()
		{
			return string.Format("({0}, {1}, {2})", ProvisionBinding, Scope, Exported ? "Exported" : "Unexported");
		}
	}
}
