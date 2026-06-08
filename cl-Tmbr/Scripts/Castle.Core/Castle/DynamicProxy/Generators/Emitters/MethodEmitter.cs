using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Generators.Emitters
{
	[DebuggerDisplay("{builder.Name}")]
	internal class MethodEmitter : IMemberEmitter
	{
		private readonly MethodBuilder builder;

		private readonly CodeBuilder codeBuilder;

		private readonly GenericTypeParameterBuilder[] genericTypeParams;

		private ArgumentReference[] arguments;

		public ArgumentReference[] Arguments => arguments;

		public CodeBuilder CodeBuilder => codeBuilder;

		public GenericTypeParameterBuilder[] GenericTypeParams => genericTypeParams;

		public MethodBuilder MethodBuilder => builder;

		public MemberInfo Member => builder;

		public Type ReturnType => builder.ReturnType;

		private bool ImplementedByRuntime => (builder.MethodImplementationFlags & MethodImplAttributes.CodeTypeMask) != 0;

		protected internal MethodEmitter(MethodBuilder builder)
		{
			this.builder = builder;
			codeBuilder = new CodeBuilder();
		}

		internal MethodEmitter(AbstractTypeEmitter owner, string name, MethodAttributes attributes)
			: this(owner.TypeBuilder.DefineMethod(name, attributes))
		{
		}

		internal MethodEmitter(AbstractTypeEmitter owner, string name, MethodAttributes attributes, Type returnType, params Type[] argumentTypes)
			: this(owner, name, attributes)
		{
			SetParameters(argumentTypes);
			SetReturnType(returnType);
		}

		internal MethodEmitter(AbstractTypeEmitter owner, string name, MethodAttributes attributes, MethodInfo methodToUseAsATemplate)
			: this(owner, name, attributes)
		{
			Type returnType = methodToUseAsATemplate.ReturnType;
			ParameterInfo[] parameters = methodToUseAsATemplate.GetParameters();
			Type[] types = ArgumentsUtil.GetTypes(parameters);
			genericTypeParams = GenericUtil.CopyGenericArguments(methodToUseAsATemplate, builder);
			SetParameters(types);
			SetReturnType(returnType);
			SetSignature(returnType, methodToUseAsATemplate.ReturnParameter, types, parameters);
			DefineParameters(parameters);
		}

		public void DefineCustomAttribute(CustomAttributeBuilder attribute)
		{
			builder.SetCustomAttribute(attribute);
		}

		public void SetParameters(Type[] paramTypes)
		{
			builder.SetParameters(paramTypes);
			arguments = ArgumentsUtil.ConvertToArgumentReference(paramTypes);
			ArgumentsUtil.InitializeArgumentsByPosition(arguments, MethodBuilder.IsStatic);
		}

		public virtual void EnsureValidCodeBlock()
		{
			if (!ImplementedByRuntime && CodeBuilder.IsEmpty)
			{
				if (ReturnType == typeof(void))
				{
					CodeBuilder.AddStatement(new ReturnStatement());
				}
				else
				{
					CodeBuilder.AddStatement(new ReturnStatement(new DefaultValueExpression(ReturnType)));
				}
			}
		}

		public virtual void Generate()
		{
			if (!ImplementedByRuntime)
			{
				codeBuilder.Generate(builder.GetILGenerator());
			}
		}

		private void DefineParameters(ParameterInfo[] parameters)
		{
			foreach (ParameterInfo parameterInfo in parameters)
			{
				ParameterBuilder parameterBuilder = builder.DefineParameter(parameterInfo.Position + 1, parameterInfo.Attributes, parameterInfo.Name);
				foreach (CustomAttributeInfo nonInheritableAttribute in parameterInfo.GetNonInheritableAttributes())
				{
					parameterBuilder.SetCustomAttribute(nonInheritableAttribute.Builder);
				}
				if ((parameterInfo.Attributes & ParameterAttributes.HasDefault) != ParameterAttributes.None)
				{
					try
					{
						CopyDefaultValueConstant(parameterInfo, parameterBuilder);
					}
					catch
					{
					}
				}
			}
		}

		private void CopyDefaultValueConstant(ParameterInfo from, ParameterBuilder to)
		{
			object obj;
			try
			{
				obj = from.DefaultValue;
			}
			catch (FormatException) when (from.ParameterType == typeof(DateTime))
			{
				obj = null;
			}
			catch (FormatException) when (from.ParameterType.IsEnum)
			{
				obj = null;
			}
			if (obj is Missing)
			{
				return;
			}
			try
			{
				to.SetConstant(obj);
			}
			catch (ArgumentException)
			{
				Type parameterType = from.ParameterType;
				Type type = parameterType;
				if (obj == null)
				{
					if (parameterType.IsNullableType() || parameterType.IsValueType)
					{
						return;
					}
				}
				else if (parameterType.IsNullableType())
				{
					type = from.ParameterType.GetGenericArguments()[0];
					if (type.IsEnum || type.IsAssignableFrom(obj.GetType()))
					{
						return;
					}
				}
				try
				{
					object constant = Convert.ChangeType(obj, type, CultureInfo.InvariantCulture);
					to.SetConstant(constant);
					return;
				}
				catch
				{
				}
				throw;
			}
		}

		private void SetReturnType(Type returnType)
		{
			builder.SetReturnType(returnType);
		}

		private void SetSignature(Type returnType, ParameterInfo returnParameter, Type[] parameters, ParameterInfo[] baseMethodParameters)
		{
			Type[] requiredCustomModifiers = returnParameter.GetRequiredCustomModifiers();
			Array.Reverse(requiredCustomModifiers);
			Type[] optionalCustomModifiers = returnParameter.GetOptionalCustomModifiers();
			Array.Reverse(optionalCustomModifiers);
			int num = baseMethodParameters.Length;
			Type[][] array = new Type[num][];
			Type[][] array2 = new Type[num][];
			for (int i = 0; i < num; i++)
			{
				array[i] = baseMethodParameters[i].GetRequiredCustomModifiers();
				Array.Reverse(array[i]);
				array2[i] = baseMethodParameters[i].GetOptionalCustomModifiers();
				Array.Reverse(array2[i]);
			}
			builder.SetSignature(returnType, requiredCustomModifiers, optionalCustomModifiers, parameters, array, array2);
		}
	}
}
