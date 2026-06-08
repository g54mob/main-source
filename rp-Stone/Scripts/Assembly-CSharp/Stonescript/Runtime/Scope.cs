namespace Stonescript.Runtime
{
	public class Scope : StonescriptObject
	{
		public Scope()
		{
		}

		public Scope(string name, StonescriptObject owner = null)
			: base(name, owner)
		{
		}

		public Scope(StonescriptObject owner)
			: base(owner)
		{
		}

		public new Scope Init()
		{
			base.Init();
			return this;
		}

		public new Scope Init(StonescriptObject parent)
		{
			base.Init(parent);
			return this;
		}

		public new Scope Init(string name, StonescriptObject parent = null)
		{
			base.Init(name, parent);
			return this;
		}
	}
}
