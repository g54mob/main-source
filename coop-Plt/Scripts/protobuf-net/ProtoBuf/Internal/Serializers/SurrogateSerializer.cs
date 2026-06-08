using System;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class SurrogateSerializer<T> : IProtoTypeSerializer, IRuntimeProtoSerializerNode, ISerializer<T>
	{
		private readonly Type declaredType;

		private readonly MethodInfo toTail;

		private readonly MethodInfo fromTail;

		private readonly IRuntimeProtoSerializerNode rootTail;

		private readonly SerializerFeatures features;

		public SerializerFeatures Features => features;

		bool IProtoTypeSerializer.IsSubType => false;

		bool IProtoTypeSerializer.ShouldEmitCreateInstance => false;

		public bool ReturnsValue => rootTail.ReturnsValue;

		public bool RequiresOldValue => rootTail.RequiresOldValue;

		public Type ExpectedType => typeof(T);

		Type IProtoTypeSerializer.BaseType => ExpectedType;

		bool IProtoTypeSerializer.HasInheritance => false;

		bool IProtoTypeSerializer.HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return false;
		}

		void IProtoTypeSerializer.EmitCallback(CompilerContext ctx, Local valueFrom, TypeModel.CallbackType callbackType)
		{
		}

		void IProtoTypeSerializer.EmitCreateInstance(CompilerContext ctx, bool callNoteObject)
		{
			throw new NotSupportedException();
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return false;
		}

		object IProtoTypeSerializer.CreateInstance(ISerializationContext source)
		{
			throw new NotSupportedException();
		}

		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, ISerializationContext context)
		{
		}

		T ISerializer<T>.Read(ref ProtoReader.State state, T value)
		{
			return (T)Read(ref state, value);
		}

		void ISerializer<T>.Write(ref ProtoWriter.State state, T value)
		{
			Write(ref state, value);
		}

		public SurrogateSerializer(Type declaredType, MethodInfo toTail, MethodInfo fromTail, IRuntimeProtoSerializerNode rootTail, SerializerFeatures features)
		{
			this.declaredType = declaredType;
			this.rootTail = rootTail;
			this.toTail = toTail ?? GetConversion(toTail: true);
			this.fromTail = fromTail ?? GetConversion(toTail: false);
			this.features = features;
		}

		private static bool HasCast(Type type, Type from, Type to, out MethodInfo op)
		{
			MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			Type type2 = null;
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.ReturnType != to)
				{
					continue;
				}
				ParameterInfo[] parameters = methodInfo.GetParameters();
				if (parameters.Length != 1 || !(parameters[0].ParameterType == from))
				{
					continue;
				}
				if ((object)type2 == null)
				{
					type2 = typeof(ProtoConverterAttribute);
					if ((object)type2 == null)
					{
						break;
					}
				}
				if (methodInfo.IsDefined(type2, inherit: true))
				{
					op = methodInfo;
					return true;
				}
			}
			foreach (MethodInfo methodInfo2 in methods)
			{
				if ((!(methodInfo2.Name != "op_Implicit") || !(methodInfo2.Name != "op_Explicit")) && !(methodInfo2.ReturnType != to))
				{
					ParameterInfo[] parameters = methodInfo2.GetParameters();
					if (parameters.Length == 1 && parameters[0].ParameterType == from)
					{
						op = methodInfo2;
						return true;
					}
				}
			}
			op = null;
			return false;
		}

		public MethodInfo GetConversion(bool toTail)
		{
			Type to = (toTail ? declaredType : ExpectedType);
			Type type = (toTail ? ExpectedType : declaredType);
			if (HasCast(declaredType, type, to, out var op) || HasCast(ExpectedType, type, to, out op))
			{
				return op;
			}
			throw new InvalidOperationException("No suitable conversion operator found for surrogate: " + ExpectedType.FullName + " / " + declaredType.FullName);
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			rootTail.Write(ref state, toTail.Invoke(null, new object[1] { value }));
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			object[] array = new object[1];
			if (rootTail.RequiresOldValue)
			{
				array[0] = value;
				value = toTail.Invoke(null, array);
			}
			else
			{
				value = null;
			}
			array[0] = rootTail.Read(ref state, value);
			return fromTail.Invoke(null, array);
		}

		void IProtoTypeSerializer.EmitReadRoot(CompilerContext ctx, Local valueFrom)
		{
			((IRuntimeProtoSerializerNode)this).EmitRead(ctx, valueFrom);
		}

		void IProtoTypeSerializer.EmitWriteRoot(CompilerContext ctx, Local valueFrom)
		{
			((IRuntimeProtoSerializerNode)this).EmitWrite(ctx, valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local valueFrom)
		{
			using Local local = (rootTail.RequiresOldValue ? new Local(ctx, declaredType) : null);
			if (rootTail.RequiresOldValue)
			{
				ctx.LoadValue(valueFrom);
				ctx.EmitCall(toTail);
				ctx.StoreValue(local);
			}
			rootTail.EmitRead(ctx, local);
			ctx.LoadValue(local);
			ctx.EmitCall(fromTail);
			ctx.StoreValue(valueFrom);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.LoadValue(valueFrom);
			ctx.EmitCall(toTail);
			rootTail.EmitWrite(ctx, null);
		}
	}
}
