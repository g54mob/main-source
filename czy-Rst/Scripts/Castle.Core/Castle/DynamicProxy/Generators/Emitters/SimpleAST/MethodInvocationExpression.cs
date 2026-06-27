using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class MethodInvocationExpression : IExpression, IExpressionOrStatement, IStatement
	{
		protected readonly IExpression[] args;

		protected readonly MethodInfo method;

		protected readonly Reference owner;

		public bool VirtualCall { get; set; }

		public MethodInvocationExpression(MethodInfo method, params IExpression[] args)
			: this(SelfReference.Self, method, args)
		{
		}

		public MethodInvocationExpression(MethodEmitter method, params IExpression[] args)
			: this(SelfReference.Self, method.MethodBuilder, args)
		{
		}

		public MethodInvocationExpression(Reference owner, MethodEmitter method, params IExpression[] args)
			: this(owner, method.MethodBuilder, args)
		{
		}

		public MethodInvocationExpression(Reference owner, MethodInfo method, params IExpression[] args)
		{
			this.owner = owner;
			this.method = method;
			this.args = args;
		}

		public void Emit(ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(owner, gen);
			IExpression[] array = args;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Emit(gen);
			}
			if (VirtualCall)
			{
				gen.Emit(OpCodes.Callvirt, method);
			}
			else
			{
				gen.Emit(OpCodes.Call, method);
			}
		}
	}
}
