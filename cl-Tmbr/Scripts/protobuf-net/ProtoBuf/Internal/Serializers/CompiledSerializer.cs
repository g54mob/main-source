using System;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal abstract class CompiledSerializer : IProtoTypeSerializer, IRuntimeProtoSerializerNode, ICompiledSerializer
	{
		protected readonly IProtoTypeSerializer head;

		bool IRuntimeProtoSerializerNode.IsScalar => head.IsScalar;

		public SerializerFeatures Features => head.Features;

		bool IProtoTypeSerializer.IsSubType => head.IsSubType;

		Type IProtoTypeSerializer.BaseType => head.BaseType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => head.RequiresOldValue;

		bool IRuntimeProtoSerializerNode.ReturnsValue => head.ReturnsValue;

		public Type ExpectedType => head.ExpectedType;

		bool IProtoTypeSerializer.HasInheritance => head.HasInheritance;

		bool IProtoTypeSerializer.ShouldEmitCreateInstance => head.ShouldEmitCreateInstance;

		bool IProtoTypeSerializer.HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return head.HasCallbacks(callbackType);
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return head.CanCreateInstance();
		}

		object IProtoTypeSerializer.CreateInstance(ISerializationContext context)
		{
			return head.CreateInstance(context);
		}

		public void Callback(object value, TypeModel.CallbackType callbackType, ISerializationContext context)
		{
			head.Callback(value, callbackType, context);
		}

		public static ICompiledSerializer Wrap(IProtoTypeSerializer head, RuntimeTypeModel model)
		{
			ICompiledSerializer compiledSerializer = head as ICompiledSerializer;
			if (compiledSerializer == null)
			{
				ConstructorInfo constructorInfo;
				try
				{
					constructorInfo = ((!head.IsSubType) ? Helpers.GetConstructor(typeof(SimpleCompiledSerializer<>).MakeGenericType(head.BaseType), new Type[2]
					{
						typeof(IProtoTypeSerializer),
						typeof(RuntimeTypeModel)
					}, nonPublic: true) : Helpers.GetConstructor(typeof(InheritanceCompiledSerializer<, >).MakeGenericType(head.BaseType, head.ExpectedType), new Type[2]
					{
						typeof(IProtoTypeSerializer),
						typeof(RuntimeTypeModel)
					}, nonPublic: true));
				}
				catch (Exception innerException)
				{
					throw new InvalidOperationException("Unable to wrap " + head.BaseType.NormalizeName() + "/" + head.ExpectedType.NormalizeName(), innerException);
				}
				try
				{
					compiledSerializer = (CompiledSerializer)constructorInfo.Invoke(new object[2] { head, model });
				}
				catch (TargetInvocationException ex)
				{
					throw new InvalidOperationException("Unable to wrap " + head.BaseType.NormalizeName() + "/" + head.ExpectedType.NormalizeName() + ": " + ex.InnerException.Message + " (" + head.GetType().NormalizeName() + ")", ex.InnerException);
				}
			}
			return compiledSerializer;
		}

		protected CompiledSerializer(IProtoTypeSerializer head)
		{
			this.head = head;
		}

		public abstract void Write(ref ProtoWriter.State state, object value);

		public abstract object Read(ref ProtoReader.State state, object value);

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			head.EmitWrite(ctx, valueFrom);
		}

		void IProtoTypeSerializer.EmitWriteRoot(CompilerContext ctx, Local valueFrom)
		{
			head.EmitWriteRoot(ctx, valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local valueFrom)
		{
			head.EmitRead(ctx, valueFrom);
		}

		void IProtoTypeSerializer.EmitReadRoot(CompilerContext ctx, Local valueFrom)
		{
			head.EmitReadRoot(ctx, valueFrom);
		}

		void IProtoTypeSerializer.EmitCallback(CompilerContext ctx, Local valueFrom, TypeModel.CallbackType callbackType)
		{
			head.EmitCallback(ctx, valueFrom, callbackType);
		}

		void IProtoTypeSerializer.EmitCreateInstance(CompilerContext ctx, bool callNoteObject)
		{
			head.EmitCreateInstance(ctx, callNoteObject);
		}
	}
}
