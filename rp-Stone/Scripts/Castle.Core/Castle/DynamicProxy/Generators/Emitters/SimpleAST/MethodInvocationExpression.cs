using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class MethodInvocationExpression : Expression
	{
		protected readonly Expression[] args;

		protected readonly MethodInfo method;

		protected readonly Reference owner;

		public bool VirtualCall { get; set; }

		public MethodInvocationExpression(MethodInfo method, params Expression[] args)
			: this(SelfReference.Self, method, args)
		{
		}

		public MethodInvocationExpression(MethodEmitter method, params Expression[] args)
			: this(SelfReference.Self, method.MethodBuilder, args)
		{
		}

		public MethodInvocationExpression(Reference owner, MethodEmitter method, params Expression[] args)
			: this(owner, method.MethodBuilder, args)
		{
		}

		public MethodInvocationExpression(Reference owner, MethodInfo method, params Expression[] args)
		{
			this.owner = owner;
			this.method = method;
			this.args = args;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(owner, gen);
			Expression[] array = args;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Emit(member, gen);
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
