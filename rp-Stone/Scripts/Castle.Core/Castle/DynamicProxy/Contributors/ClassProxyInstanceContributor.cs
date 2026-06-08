using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Contributors
{
	public class ClassProxyInstanceContributor : ProxyInstanceContributor
	{
		private readonly bool delegateToBaseGetObjectData;

		private readonly bool implementISerializable;

		private ConstructorInfo serializationConstructor;

		private readonly IList<FieldReference> serializedFields = new List<FieldReference>();

		public ClassProxyInstanceContributor(Type targetType, IList<MethodInfo> methodsToSkip, Type[] interfaces, string typeId)
			: base(targetType, interfaces, typeId)
		{
			if (targetType.IsSerializable)
			{
				implementISerializable = true;
				delegateToBaseGetObjectData = VerifyIfBaseImplementsGetObjectData(targetType, methodsToSkip);
			}
		}

		protected override Reference GetTargetReference(ClassEmitter emitter)
		{
			return SelfReference.Self;
		}

		public override void Generate(ClassEmitter @class, ProxyGenerationOptions options)
		{
			FieldReference field = @class.GetField("__interceptors");
			if (implementISerializable)
			{
				ImplementGetObjectData(@class);
				Constructor(@class);
			}
			ImplementProxyTargetAccessor(@class, field);
			foreach (CustomAttributeInfo nonInheritableAttribute in targetType.GetTypeInfo().GetNonInheritableAttributes())
			{
				@class.DefineCustomAttribute(nonInheritableAttribute.Builder);
			}
		}

		protected override void AddAddValueInvocation(ArgumentReference serializationInfo, MethodEmitter getObjectData, FieldReference field)
		{
			serializedFields.Add(field);
			base.AddAddValueInvocation(serializationInfo, getObjectData, field);
		}

		protected override void CustomizeGetObjectData(AbstractCodeBuilder codebuilder, ArgumentReference serializationInfo, ArgumentReference streamingContext, ClassEmitter emitter)
		{
			codebuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(serializationInfo, SerializationInfoMethods.AddValue_Bool, new ConstReference("__delegateToBase").ToExpression(), new ConstReference(delegateToBaseGetObjectData).ToExpression())));
			if (!delegateToBaseGetObjectData)
			{
				EmitCustomGetObjectData(codebuilder, serializationInfo);
			}
			else
			{
				EmitCallToBaseGetObjectData(codebuilder, serializationInfo, streamingContext);
			}
		}

		private void EmitCustomGetObjectData(AbstractCodeBuilder codebuilder, ArgumentReference serializationInfo)
		{
			LocalReference localReference = codebuilder.DeclareLocal(typeof(MemberInfo[]));
			LocalReference localReference2 = codebuilder.DeclareLocal(typeof(object[]));
			MethodInvocationExpression expression = new MethodInvocationExpression(null, FormatterServicesMethods.GetSerializableMembers, new TypeTokenExpression(targetType));
			codebuilder.AddStatement(new AssignStatement(localReference, expression));
			MethodInvocationExpression expression2 = new MethodInvocationExpression(null, TypeUtilMethods.Sort, localReference.ToExpression());
			codebuilder.AddStatement(new AssignStatement(localReference, expression2));
			MethodInvocationExpression expression3 = new MethodInvocationExpression(null, FormatterServicesMethods.GetObjectData, SelfReference.Self.ToExpression(), localReference.ToExpression());
			codebuilder.AddStatement(new AssignStatement(localReference2, expression3));
			MethodInvocationExpression expression4 = new MethodInvocationExpression(serializationInfo, SerializationInfoMethods.AddValue_Object, new ConstReference("__data").ToExpression(), localReference2.ToExpression());
			codebuilder.AddStatement(new ExpressionStatement(expression4));
		}

		private void EmitCallToBaseGetObjectData(AbstractCodeBuilder codebuilder, ArgumentReference serializationInfo, ArgumentReference streamingContext)
		{
			MethodInfo method = targetType.GetMethod("GetObjectData", new Type[2]
			{
				typeof(SerializationInfo),
				typeof(StreamingContext)
			});
			codebuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(method, serializationInfo.ToExpression(), streamingContext.ToExpression())));
		}

		private void Constructor(ClassEmitter emitter)
		{
			if (delegateToBaseGetObjectData)
			{
				GenerateSerializationConstructor(emitter);
			}
		}

		private void GenerateSerializationConstructor(ClassEmitter emitter)
		{
			ArgumentReference argumentReference = new ArgumentReference(typeof(SerializationInfo));
			ArgumentReference argumentReference2 = new ArgumentReference(typeof(StreamingContext));
			ConstructorEmitter constructorEmitter = emitter.CreateConstructor(argumentReference, argumentReference2);
			constructorEmitter.CodeBuilder.AddStatement(new ConstructorInvocationStatement(serializationConstructor, argumentReference.ToExpression(), argumentReference2.ToExpression()));
			foreach (FieldReference serializedField in serializedFields)
			{
				MethodInvocationExpression right = new MethodInvocationExpression(argumentReference, SerializationInfoMethods.GetValue, new ConstReference(serializedField.Reference.Name).ToExpression(), new TypeTokenExpression(serializedField.Reference.FieldType));
				constructorEmitter.CodeBuilder.AddStatement(new AssignStatement(serializedField, new ConvertExpression(serializedField.Reference.FieldType, typeof(object), right)));
			}
			constructorEmitter.CodeBuilder.AddStatement(new ReturnStatement());
		}

		private bool VerifyIfBaseImplementsGetObjectData(Type baseType, IList<MethodInfo> methodsToSkip)
		{
			if (!typeof(ISerializable).IsAssignableFrom(baseType))
			{
				return false;
			}
			if (baseType.IsDelegateType())
			{
				return false;
			}
			MethodInfo methodInfo = baseType.GetInterfaceMap(typeof(ISerializable)).TargetMethods[0];
			if (methodInfo.IsPrivate)
			{
				return false;
			}
			if (!methodInfo.IsVirtual || methodInfo.IsFinal)
			{
				throw new ArgumentException($"The type {baseType.FullName} implements ISerializable, but GetObjectData is not marked as virtual. Dynamic Proxy needs types implementing ISerializable to mark GetObjectData as virtual to ensure correct serialization process.");
			}
			methodsToSkip.Add(methodInfo);
			serializationConstructor = baseType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[2]
			{
				typeof(SerializationInfo),
				typeof(StreamingContext)
			}, null);
			if (serializationConstructor == null)
			{
				throw new ArgumentException($"The type {baseType.FullName} implements ISerializable, but failed to provide a deserialization constructor");
			}
			return true;
		}
	}
}
