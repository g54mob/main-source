using System;
using System.Linq;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class AnyTypeSerializer<T> : IRuntimeProtoSerializerNode, IDirectWriteNode, IDirectRuntimeWriteNode
	{
		private readonly SerializerFeatures _features;

		private readonly CompatibilityLevel _compatibilityLevel;

		private readonly DataFormat _dataFormat;

		private static readonly MethodInfo ReadAnyT = AnyTypeSerializer.ReadAnyT.MakeGenericMethod(typeof(T));

		private static readonly MethodInfo WriteAnyT = AnyTypeSerializer.WriteAnyT.MakeGenericMethod(typeof(T));

		bool IRuntimeProtoSerializerNode.IsScalar => _features.IsScalar();

		public Type ExpectedType => typeof(T);

		bool IRuntimeProtoSerializerNode.RequiresOldValue => true;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		public AnyTypeSerializer(SerializerFeatures features, CompatibilityLevel compatibilityLevel, DataFormat dataFormat)
		{
			_features = features;
			_compatibilityLevel = compatibilityLevel;
			_dataFormat = dataFormat;
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return state.ReadAny(_features, (T)value);
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			throw new NotSupportedException("Only DirectWrite should be used");
		}

		void IDirectRuntimeWriteNode.DirectWrite(int fieldNumber, WireType wireType, ref ProtoWriter.State state, object value)
		{
			state.WriteAny(fieldNumber, _features | wireType.AsFeatures(), (T)value);
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			throw new NotSupportedException("Only EmitDirectWrite should be used");
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			using Local local = ctx.GetLocalWithValue(typeof(T), entity);
			ctx.LoadState();
			ctx.LoadValue((int)_features);
			ctx.LoadValue(local);
			ctx.LoadSelfAsService<ISerializer<T>, T>(_compatibilityLevel, _dataFormat);
			ctx.EmitCall(ReadAnyT);
		}

		bool IDirectWriteNode.CanEmitDirectWrite(WireType wireType)
		{
			return true;
		}

		bool IDirectRuntimeWriteNode.CanDirectWrite(WireType wireType)
		{
			return true;
		}

		void IDirectWriteNode.EmitDirectWrite(int fieldNumber, WireType wireType, CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(typeof(T), valueFrom);
			ctx.LoadState();
			ctx.LoadValue(fieldNumber);
			ctx.LoadValue((int)(_features | wireType.AsFeatures()));
			ctx.LoadValue(local);
			ctx.LoadSelfAsService<ISerializer<T>, T>(_compatibilityLevel, _dataFormat);
			ctx.EmitCall(WriteAnyT);
		}
	}
	internal static class AnyTypeSerializer
	{
		internal static readonly MethodInfo ReadAnyT = FindSerializerFeaturesMethod(typeof(ProtoReader.State), "ReadAny");

		internal static readonly MethodInfo WriteAnyT = FindSerializerFeaturesMethod(typeof(ProtoWriter.State), "WriteAny");

		private static bool FindSerializerFeaturesMethodFilter(MemberInfo member, object state)
		{
			if (member is MethodInfo methodInfo && state is string text && member.Name == text)
			{
				ParameterInfo[] parameters = methodInfo.GetParameters();
				foreach (ParameterInfo parameterInfo in parameters)
				{
					if (parameterInfo.ParameterType == typeof(SerializerFeatures))
					{
						return true;
					}
				}
			}
			return false;
		}

		private static MethodInfo FindSerializerFeaturesMethod(Type type, string name)
		{
			return (MethodInfo)type.FindMembers(MemberTypes.Method, BindingFlags.Instance | BindingFlags.Public, FindSerializerFeaturesMethodFilter, name).Single();
		}

		internal static IRuntimeProtoSerializerNode Create(Type memberType, SerializerFeatures features, CompatibilityLevel compatibilityLevel, DataFormat dataFormat)
		{
			return (IRuntimeProtoSerializerNode)Activator.CreateInstance(typeof(AnyTypeSerializer<>).MakeGenericType(memberType), features, compatibilityLevel, dataFormat);
		}
	}
}
