using System;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal class ConstructorEmitter : IMemberEmitter
	{
		private readonly ConstructorBuilder builder;

		private readonly CodeBuilder codeBuilder;

		private readonly AbstractTypeEmitter mainType;

		public CodeBuilder CodeBuilder => codeBuilder;

		public ConstructorBuilder ConstructorBuilder => builder;

		public MemberInfo Member => builder;

		public Type ReturnType => typeof(void);

		private bool ImplementedByRuntime => (builder.MethodImplementationFlags & MethodImplAttributes.CodeTypeMask) != 0;

		protected internal ConstructorEmitter(AbstractTypeEmitter mainType, ConstructorBuilder builder)
		{
			this.mainType = mainType;
			this.builder = builder;
			codeBuilder = new CodeBuilder();
		}

		internal ConstructorEmitter(AbstractTypeEmitter mainType, params ArgumentReference[] arguments)
		{
			this.mainType = mainType;
			Type[] parameterTypes = ArgumentsUtil.InitializeAndConvert(arguments);
			builder = mainType.TypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
			codeBuilder = new CodeBuilder();
		}

		public virtual void EnsureValidCodeBlock()
		{
			if (!ImplementedByRuntime && CodeBuilder.IsEmpty)
			{
				CodeBuilder.AddStatement(new ConstructorInvocationStatement(mainType.BaseType));
				CodeBuilder.AddStatement(new ReturnStatement());
			}
		}

		public virtual void Generate()
		{
			if (!ImplementedByRuntime)
			{
				CodeBuilder.Generate(builder.GetILGenerator());
			}
		}
	}
}
