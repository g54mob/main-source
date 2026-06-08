using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Generators.Emitters
{
	[DebuggerDisplay("{builder.Name}")]
	public class MethodEmitter : IMemberEmitter
	{
		private readonly MethodBuilder builder;

		private readonly GenericTypeParameterBuilder[] genericTypeParams;

		private ArgumentReference[] arguments;

		private MethodCodeBuilder codebuilder;

		public ArgumentReference[] Arguments => arguments;

		public virtual MethodCodeBuilder CodeBuilder
		{
			get
			{
				if (codebuilder == null)
				{
					codebuilder = new MethodCodeBuilder(builder.GetILGenerator());
				}
				return codebuilder;
			}
		}

		public GenericTypeParameterBuilder[] GenericTypeParams => genericTypeParams;

		public MethodBuilder MethodBuilder => builder;

		public MemberInfo Member => builder;

		public Type ReturnType => builder.ReturnType;

		private bool ImplementedByRuntime => (builder.MethodImplementationFlags & MethodImplAttributes.CodeTypeMask) != 0;

		protected internal MethodEmitter(MethodBuilder builder)
		{
			this.builder = builder;
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
			Dictionary<string, GenericTypeParameterBuilder> genericArgumentsMap = GenericUtil.GetGenericArgumentsMap(owner);
			Type returnType = GenericUtil.ExtractCorrectType(methodToUseAsATemplate.ReturnType, genericArgumentsMap);
			ParameterInfo[] parameters = methodToUseAsATemplate.GetParameters();
			Type[] parameters2 = GenericUtil.ExtractParametersTypes(parameters, genericArgumentsMap);
			genericTypeParams = GenericUtil.CopyGenericArguments(methodToUseAsATemplate, builder, genericArgumentsMap);
			SetParameters(parameters2);
			SetReturnType(returnType);
			SetSignature(returnType, methodToUseAsATemplate.ReturnParameter, parameters2, parameters);
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
				CodeBuilder.AddStatement(new NopStatement());
				CodeBuilder.AddStatement(new ReturnStatement());
			}
		}

		public virtual void Generate()
		{
			if (!ImplementedByRuntime)
			{
				codebuilder.Generate(this, builder.GetILGenerator());
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
			catch (FormatException) when (from.ParameterType.GetTypeInfo().IsEnum)
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
					if (parameterType.IsNullableType() || parameterType.GetTypeInfo().IsValueType)
					{
						return;
					}
				}
				else if (parameterType.IsNullableType())
				{
					type = from.ParameterType.GetGenericArguments()[0];
					if (type.GetTypeInfo().IsEnum || type.IsAssignableFrom(obj.GetType()))
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
			Array.Reverse((Array)requiredCustomModifiers);
			Type[] optionalCustomModifiers = returnParameter.GetOptionalCustomModifiers();
			Array.Reverse((Array)optionalCustomModifiers);
			int num = baseMethodParameters.Length;
			Type[][] array = new Type[num][];
			Type[][] array2 = new Type[num][];
			for (int i = 0; i < num; i++)
			{
				array[i] = baseMethodParameters[i].GetRequiredCustomModifiers();
				Array.Reverse((Array)array[i]);
				array2[i] = baseMethodParameters[i].GetOptionalCustomModifiers();
				Array.Reverse((Array)array2[i]);
			}
			builder.SetSignature(returnType, requiredCustomModifiers, optionalCustomModifiers, parameters, array, array2);
		}
	}
}
