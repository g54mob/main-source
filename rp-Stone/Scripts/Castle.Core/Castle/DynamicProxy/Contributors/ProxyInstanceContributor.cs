using System;
using System.Reflection;
using System.Runtime.Serialization;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Serialization;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Contributors
{
	public abstract class ProxyInstanceContributor : ITypeContributor
	{
		protected readonly Type targetType;

		private readonly string proxyTypeId;

		private readonly Type[] interfaces;

		protected ProxyInstanceContributor(Type targetType, Type[] interfaces, string proxyTypeId)
		{
			this.targetType = targetType;
			this.proxyTypeId = proxyTypeId;
			this.interfaces = interfaces ?? Type.EmptyTypes;
		}

		protected abstract Reference GetTargetReference(ClassEmitter emitter);

		private Expression GetTargetReferenceExpression(ClassEmitter emitter)
		{
			return GetTargetReference(emitter).ToExpression();
		}

		public virtual void Generate(ClassEmitter @class, ProxyGenerationOptions options)
		{
			FieldReference field = @class.GetField("__interceptors");
			ImplementGetObjectData(@class);
			ImplementProxyTargetAccessor(@class, field);
			foreach (CustomAttributeInfo nonInheritableAttribute in targetType.GetTypeInfo().GetNonInheritableAttributes())
			{
				@class.DefineCustomAttribute(nonInheritableAttribute.Builder);
			}
		}

		protected void ImplementProxyTargetAccessor(ClassEmitter emitter, FieldReference interceptorsField)
		{
			emitter.CreateMethod("DynProxyGetTarget", typeof(object)).CodeBuilder.AddStatement(new ReturnStatement(new ConvertExpression(typeof(object), targetType, GetTargetReferenceExpression(emitter))));
			MethodEmitter methodEmitter = emitter.CreateMethod("DynProxySetTarget", typeof(void), typeof(object));
			if (GetTargetReference(emitter) is FieldReference fieldReference)
			{
				methodEmitter.CodeBuilder.AddStatement(new AssignStatement(fieldReference, new ConvertExpression(fieldReference.Fieldbuilder.FieldType, methodEmitter.Arguments[0].ToExpression())));
			}
			else
			{
				methodEmitter.CodeBuilder.AddStatement(new ThrowStatement(typeof(InvalidOperationException), "Cannot change the target of the class proxy."));
			}
			methodEmitter.CodeBuilder.AddStatement(new ReturnStatement());
			emitter.CreateMethod("GetInterceptors", typeof(IInterceptor[])).CodeBuilder.AddStatement(new ReturnStatement(interceptorsField));
		}

		protected void ImplementGetObjectData(ClassEmitter emitter)
		{
			MethodEmitter methodEmitter = emitter.CreateMethod("GetObjectData", typeof(void), typeof(SerializationInfo), typeof(StreamingContext));
			ArgumentReference argumentReference = methodEmitter.Arguments[0];
			LocalReference localReference = methodEmitter.CodeBuilder.DeclareLocal(typeof(Type));
			methodEmitter.CodeBuilder.AddStatement(new AssignStatement(localReference, new MethodInvocationExpression(null, TypeMethods.StaticGetType, new ConstReference(typeof(ProxyObjectReference).AssemblyQualifiedName).ToExpression(), new ConstReference(1).ToExpression(), new ConstReference(0).ToExpression())));
			methodEmitter.CodeBuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(argumentReference, SerializationInfoMethods.SetType, localReference.ToExpression())));
			foreach (FieldReference allField in emitter.GetAllFields())
			{
				if (!allField.Reference.IsStatic && !allField.Reference.IsNotSerialized)
				{
					AddAddValueInvocation(argumentReference, methodEmitter, allField);
				}
			}
			LocalReference localReference2 = methodEmitter.CodeBuilder.DeclareLocal(typeof(string[]));
			methodEmitter.CodeBuilder.AddStatement(new AssignStatement(localReference2, new NewArrayExpression(interfaces.Length, typeof(string))));
			for (int i = 0; i < interfaces.Length; i++)
			{
				methodEmitter.CodeBuilder.AddStatement(new AssignArrayStatement(localReference2, i, new ConstReference(interfaces[i].AssemblyQualifiedName).ToExpression()));
			}
			methodEmitter.CodeBuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(argumentReference, SerializationInfoMethods.AddValue_Object, new ConstReference("__interfaces").ToExpression(), localReference2.ToExpression())));
			methodEmitter.CodeBuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(argumentReference, SerializationInfoMethods.AddValue_Object, new ConstReference("__baseType").ToExpression(), new ConstReference(emitter.BaseType.AssemblyQualifiedName).ToExpression())));
			methodEmitter.CodeBuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(argumentReference, SerializationInfoMethods.AddValue_Object, new ConstReference("__proxyGenerationOptions").ToExpression(), emitter.GetField("proxyGenerationOptions").ToExpression())));
			methodEmitter.CodeBuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(argumentReference, SerializationInfoMethods.AddValue_Object, new ConstReference("__proxyTypeId").ToExpression(), new ConstReference(proxyTypeId).ToExpression())));
			CustomizeGetObjectData(methodEmitter.CodeBuilder, argumentReference, methodEmitter.Arguments[1], emitter);
			methodEmitter.CodeBuilder.AddStatement(new ReturnStatement());
		}

		protected virtual void AddAddValueInvocation(ArgumentReference serializationInfo, MethodEmitter getObjectData, FieldReference field)
		{
			getObjectData.CodeBuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(serializationInfo, SerializationInfoMethods.AddValue_Object, new ConstReference(field.Reference.Name).ToExpression(), field.ToExpression())));
		}

		protected abstract void CustomizeGetObjectData(AbstractCodeBuilder builder, ArgumentReference serializationInfo, ArgumentReference streamingContext, ClassEmitter emitter);

		public void CollectElementsToProxy(IProxyGenerationHook hook, MetaType model)
		{
		}
	}
}
