using System;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal class SimpleCompiledSerializer<T> : CompiledSerializer, ISerializer<T>, IFactory<T>
	{
		protected readonly ProtoSerializer<T> serializer;

		protected readonly ProtoDeserializer<T> deserializer;

		private readonly Func<ISerializationContext, T> factory;

		public SimpleCompiledSerializer(IProtoTypeSerializer head, RuntimeTypeModel model)
			: base(head)
		{
			try
			{
				serializer = CompilerContext.BuildSerializer<T>(model.Scope, head, model);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("Unable to bind serializer: " + ex.Message, ex);
			}
			try
			{
				deserializer = CompilerContext.BuildDeserializer<T>(model.Scope, head, model);
			}
			catch (Exception ex2)
			{
				throw new InvalidOperationException("Unable to bind deserializer: " + ex2.Message, ex2);
			}
			factory = CompilerContext.BuildFactory<T>(model.Scope, head, model);
		}

		T ISerializer<T>.Read(ref ProtoReader.State state, T value)
		{
			return deserializer(ref state, value);
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			return deserializer(ref state, TypeHelper<T>.FromObject(value));
		}

		void ISerializer<T>.Write(ref ProtoWriter.State state, T value)
		{
			serializer(ref state, value);
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			serializer(ref state, TypeHelper<T>.FromObject(value));
		}

		T IFactory<T>.Create(ISerializationContext context)
		{
			if (factory != null)
			{
				return factory(context);
			}
			return default(T);
		}
	}
}
