using System;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class InheritanceCompiledSerializer<TBase, T> : CompiledSerializer, ISerializer<T>, ISubTypeSerializer<T>, IFactory<T> where TBase : class where T : class, TBase
	{
		private readonly ProtoSerializer<T> subTypeSerializer;

		private readonly ProtoSubTypeDeserializer<T> subTypeDeserializer;

		private readonly Func<ISerializationContext, T> factory;

		T ISerializer<T>.Read(ref ProtoReader.State state, T value)
		{
			return state.ReadBaseType<TBase, T>(value);
		}

		T IFactory<T>.Create(ISerializationContext context)
		{
			Func<ISerializationContext, T> func = factory;
			if (func == null)
			{
				return null;
			}
			return func(context);
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadBaseType<TBase, T>(TypeHelper<T>.FromObject(value));
		}

		void ISerializer<T>.Write(ref ProtoWriter.State state, T value)
		{
			state.WriteBaseType((TBase)value);
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteBaseType((TBase)TypeHelper<T>.FromObject(value));
		}

		void ISubTypeSerializer<T>.WriteSubType(ref ProtoWriter.State state, T value)
		{
			subTypeSerializer(ref state, value);
		}

		T ISubTypeSerializer<T>.ReadSubType(ref ProtoReader.State state, SubTypeState<T> value)
		{
			return subTypeDeserializer(ref state, value);
		}

		public InheritanceCompiledSerializer(IProtoTypeSerializer head, RuntimeTypeModel model)
			: base(head)
		{
			try
			{
				subTypeSerializer = CompilerContext.BuildSerializer<T>(model.Scope, head, model);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("Unable to bind serializer: " + ex.Message, ex);
			}
			try
			{
				subTypeDeserializer = CompilerContext.BuildSubTypeDeserializer<T>(model.Scope, head, model);
			}
			catch (Exception ex2)
			{
				throw new InvalidOperationException("Unable to bind deserializer: " + ex2.Message, ex2);
			}
			factory = CompilerContext.BuildFactory<T>(model.Scope, head, model);
		}
	}
}
