using System;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal static class RepeatedDecorator
	{
		public static IRuntimeProtoSerializerNode Create(RepeatedSerializerStub stub, int fieldNumber, SerializerFeatures features, CompatibilityLevel compatibilityLevel, DataFormat dataFormat)
		{
			if (stub == null)
			{
				ThrowHelper.ThrowArgumentNullException("stub", "No suitable repeated serializer resolved for " + stub.ForType.NormalizeName());
			}
			_ = stub.Serializer;
			return (IRuntimeProtoSerializerNode)Activator.CreateInstance(typeof(RepeatedDecorator<, >).MakeGenericType(stub.ForType, stub.ItemType), fieldNumber, features, compatibilityLevel, dataFormat, stub);
		}

		internal static IRepeatedSerializer<T> GetSerializer<T>(MemberInfo original)
		{
			MemberInfo underlyingProvider = RuntimeTypeModel.GetUnderlyingProvider(original, typeof(T));
			MemberInfo memberInfo = underlyingProvider;
			object obj;
			if (!(memberInfo is FieldInfo fieldInfo))
			{
				if (!(memberInfo is MethodInfo methodInfo) || !methodInfo.IsStatic)
				{
					goto IL_0057;
				}
				obj = methodInfo.Invoke(null, null);
			}
			else
			{
				if (!fieldInfo.IsStatic)
				{
					goto IL_0057;
				}
				obj = fieldInfo.GetValue(null);
			}
			goto IL_005a;
			IL_0057:
			obj = null;
			goto IL_005a;
			IL_005a:
			object obj2 = obj;
			if (obj2 is IRepeatedSerializer<T> result)
			{
				return result;
			}
			ThrowHelper.ThrowInvalidOperationException("No suitable repeated serializer resolved for " + typeof(T).NormalizeName());
			return null;
		}
	}
	internal sealed class RepeatedDecorator<TCollection, T> : IRuntimeProtoSerializerNode, ICompiledSerializer
	{
		private readonly int _fieldNumber;

		private readonly SerializerFeatures _features;

		private readonly CompatibilityLevel _compatibilityLevel;

		private readonly DataFormat _dataFormat;

		private readonly RepeatedSerializerStub _stub;

		private RepeatedSerializer<TCollection, T> Serializer => (RepeatedSerializer<TCollection, T>)_stub.Serializer;

		public Type ExpectedType => typeof(TCollection);

		public bool RequiresOldValue => true;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		public RepeatedDecorator(int fieldNumber, SerializerFeatures features, CompatibilityLevel compatibilityLevel, DataFormat dataFormat, RepeatedSerializerStub stub)
		{
			_stub = stub;
			_fieldNumber = fieldNumber;
			_features = features;
			_compatibilityLevel = ValueMember.GetEffectiveCompatibilityLevel(compatibilityLevel, dataFormat);
			_dataFormat = dataFormat;
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return Serializer.ReadRepeated(ref state, _features, (TCollection)value, TypeModel.GetInbuiltSerializer<T>(_compatibilityLevel, _dataFormat));
		}

		public void EmitRead(CompilerContext ctx, Local valueFrom)
		{
			_ = Serializer;
			MethodInfo method = typeof(RepeatedSerializer<TCollection, T>).GetMethod("ReadRepeated");
			using Local local = ctx.GetLocalWithValue(ExpectedType, valueFrom);
			_stub.EmitProvider(ctx);
			ctx.LoadState();
			ctx.LoadValue((int)_features);
			ctx.LoadValue(local);
			ctx.LoadSelfAsService<ISerializer<T>, T>(_compatibilityLevel, _dataFormat);
			ctx.EmitCall(method);
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			Serializer.WriteRepeated(ref state, _fieldNumber, _features, (TCollection)value, TypeModel.GetInbuiltSerializer<T>(_compatibilityLevel, _dataFormat));
		}

		public void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			MethodInfo method = typeof(RepeatedSerializer<TCollection, T>).GetMethod("WriteRepeated");
			using Local local = ctx.GetLocalWithValue(ExpectedType, valueFrom);
			_stub.EmitProvider(ctx);
			ctx.LoadState();
			ctx.LoadValue(_fieldNumber);
			ctx.LoadValue((int)_features);
			ctx.LoadValue(local);
			ctx.LoadSelfAsService<ISerializer<T>, T>(_compatibilityLevel, _dataFormat);
			ctx.EmitCall(method);
		}
	}
}
