using System;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators.Emitters
{
	public class ConstructorEmitter : IMemberEmitter
	{
		private readonly ConstructorBuilder builder;

		private readonly AbstractTypeEmitter maintype;

		private ConstructorCodeBuilder constructorCodeBuilder;

		public virtual ConstructorCodeBuilder CodeBuilder
		{
			get
			{
				if (constructorCodeBuilder == null)
				{
					constructorCodeBuilder = new ConstructorCodeBuilder(maintype.BaseType, builder.GetILGenerator());
				}
				return constructorCodeBuilder;
			}
		}

		public ConstructorBuilder ConstructorBuilder => builder;

		public MemberInfo Member => builder;

		public Type ReturnType => typeof(void);

		private bool ImplementedByRuntime => (builder.MethodImplementationFlags & MethodImplAttributes.CodeTypeMask) != 0;

		protected internal ConstructorEmitter(AbstractTypeEmitter maintype, ConstructorBuilder builder)
		{
			this.maintype = maintype;
			this.builder = builder;
		}

		internal ConstructorEmitter(AbstractTypeEmitter maintype, params ArgumentReference[] arguments)
		{
			this.maintype = maintype;
			Type[] parameterTypes = ArgumentsUtil.InitializeAndConvert(arguments);
			builder = maintype.TypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
		}

		public virtual void EnsureValidCodeBlock()
		{
			if (!ImplementedByRuntime && CodeBuilder.IsEmpty)
			{
				CodeBuilder.InvokeBaseConstructor();
				CodeBuilder.AddStatement(new ReturnStatement());
			}
		}

		public virtual void Generate()
		{
			if (!ImplementedByRuntime)
			{
				CodeBuilder.Generate(this, builder.GetILGenerator());
			}
		}
	}
}
