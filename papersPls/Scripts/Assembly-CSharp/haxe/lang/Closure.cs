namespace haxe.lang
{
	public class Closure : VarArgsBase
	{
		public object obj;

		public string field;

		public int hash;

		public Closure(object obj, string field, int hash)
			: base(0, 0)
		{
		}

		public override object __hx_invokeDynamic(object[] dynArgs)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
