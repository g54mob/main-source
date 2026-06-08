namespace MoonSharp.Interpreter.Interop.StandardDescriptors.HardwiredDescriptors
{
	public abstract class HardwiredMethodMemberDescriptor : FunctionMemberDescriptorBase
	{
		public override DynValue Execute(Script script, object obj, ScriptExecutionContext context, CallbackArguments args)
		{
			return null;
		}

		private int CalcArgsCount(object[] pars)
		{
			return 0;
		}

		protected abstract object Invoke(Script script, object obj, object[] pars, int argscount);
	}
}
