using System;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal class ExternalSerializer
	{
		internal static IProtoTypeSerializer Create(Type target, Type serializer)
		{
			return (IProtoTypeSerializer)Activator.CreateInstance(typeof(ExternalSerializer<, >).MakeGenericType(serializer, target), nonPublic: true);
		}
	}
	internal sealed class ExternalSerializer<TProvider, T> : IRuntimeProtoSerializerNode, IExternalSerializer, ICompiledSerializer, IProtoTypeSerializer where TProvider : class
	{
		object IExternalSerializer.Service => Serializer;

		private static ISerializer<T> Serializer => SerializerCache<TProvider, T>.InstanceField;

		public Type ExpectedType => typeof(T);

		bool IRuntimeProtoSerializerNode.RequiresOldValue => true;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		SerializerFeatures IProtoTypeSerializer.Features => Serializer.Features;

		Type IProtoTypeSerializer.BaseType => ExpectedType;

		bool IProtoTypeSerializer.ShouldEmitCreateInstance => false;

		bool IProtoTypeSerializer.HasInheritance => false;

		bool IProtoTypeSerializer.IsSubType => false;

		void IRuntimeProtoSerializerNode.Write(ref ProtoWriter.State state, object value)
		{
			Serializer.Write(ref state, TypeHelper<T>.FromObject(value));
		}

		object IRuntimeProtoSerializerNode.Read(ref ProtoReader.State state, object value)
		{
			return Serializer.Read(ref state, TypeHelper<T>.FromObject(value));
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return Serializer is IFactory<T>;
		}

		object IProtoTypeSerializer.CreateInstance(ISerializationContext context)
		{
			if (Serializer is IFactory<T> factory)
			{
				return factory.Create(context);
			}
			return null;
		}

		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, ISerializationContext context)
		{
		}

		bool IProtoTypeSerializer.HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return false;
		}

		void IProtoTypeSerializer.EmitCreateInstance(CompilerContext ctx, bool callNoteObject)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void IProtoTypeSerializer.EmitCallback(CompilerContext ctx, Local valueFrom, TypeModel.CallbackType callbackType)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void IProtoTypeSerializer.EmitReadRoot(CompilerContext ctx, Local entity)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void IProtoTypeSerializer.EmitWriteRoot(CompilerContext ctx, Local entity)
		{
			ThrowHelper.ThrowNotSupportedException();
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(typeof(T), valueFrom);
			if (ctx.NonPublic || RuntimeTypeModel.IsFullyPublic(typeof(TProvider)))
			{
				ctx.EmitCall(typeof(SerializerCache).GetMethod("Get").MakeGenericMethod(typeof(TProvider), typeof(T)));
			}
			else
			{
				ctx.LoadState();
				ctx.EmitCall(typeof(ProtoWriter.State).GetMethod("GetSerializer").MakeGenericMethod(typeof(T)));
			}
			ctx.LoadState();
			ctx.LoadValue(local);
			ctx.EmitCall(typeof(ISerializer<T>).GetMethod("Write"));
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			using Local local = ctx.GetLocalWithValue(typeof(T), entity);
			if (ctx.NonPublic || RuntimeTypeModel.IsFullyPublic(typeof(TProvider)))
			{
				ctx.EmitCall(typeof(SerializerCache).GetMethod("Get").MakeGenericMethod(typeof(TProvider), typeof(T)));
			}
			else
			{
				ctx.LoadState();
				ctx.EmitCall(typeof(ProtoReader.State).GetMethod("GetSerializer").MakeGenericMethod(typeof(T)));
			}
			ctx.LoadState();
			ctx.LoadValue(local);
			ctx.EmitCall(typeof(ISerializer<T>).GetMethod("Read"));
			ctx.StoreValue(entity);
		}
	}
}
