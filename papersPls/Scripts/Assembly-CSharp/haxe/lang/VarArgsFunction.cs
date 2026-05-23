namespace haxe.lang
{
	public class VarArgsFunction : VarArgsBase
	{
		public Function fun;

		public VarArgsFunction(Function fun)
			: base(0, 0)
		{
		}

		public override object __hx_invokeDynamic(object[] dynArgs)
		{
			return null;
		}
	}
}
