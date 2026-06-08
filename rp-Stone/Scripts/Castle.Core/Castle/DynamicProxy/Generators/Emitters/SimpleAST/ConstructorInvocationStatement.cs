using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class ConstructorInvocationStatement : Statement
	{
		private readonly Expression[] args;

		private readonly ConstructorInfo cmethod;

		public ConstructorInvocationStatement(ConstructorInfo method, params Expression[] args)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			cmethod = method;
			this.args = args;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldarg_0);
			Expression[] array = args;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Emit(member, gen);
			}
			gen.Emit(OpCodes.Call, cmethod);
		}
	}
}
