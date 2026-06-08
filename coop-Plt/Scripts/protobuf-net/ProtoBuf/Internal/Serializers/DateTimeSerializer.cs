using System;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class DateTimeSerializer : IRuntimeProtoSerializerNode
	{
		private static readonly Type expectedType = typeof(DateTime);

		private static DateTimeSerializer s_Timestamp;

		private readonly bool _includeKind;

		private readonly bool _useTimestamp;

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		public static DateTimeSerializer Create(CompatibilityLevel compatibilityLevel, TypeModel model)
		{
			if (compatibilityLevel < CompatibilityLevel.Level240)
			{
				return new DateTimeSerializer(useTimestamp: false, model.HasOption(TypeModel.TypeModelOptions.IncludeDateTimeKind));
			}
			return s_Timestamp ?? (s_Timestamp = new DateTimeSerializer(useTimestamp: true, includeKind: false));
		}

		private DateTimeSerializer(bool useTimestamp, bool includeKind)
		{
			_useTimestamp = useTimestamp;
			_includeKind = includeKind;
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			if (_useTimestamp)
			{
				return BclHelpers.ReadTimestamp(ref state);
			}
			return BclHelpers.ReadDateTime(ref state);
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			if (_useTimestamp)
			{
				BclHelpers.WriteTimestamp(ref state, (DateTime)value);
			}
			else if (_includeKind)
			{
				BclHelpers.WriteDateTimeWithKind(ref state, (DateTime)value);
			}
			else
			{
				BclHelpers.WriteDateTime(ref state, (DateTime)value);
			}
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite(_useTimestamp ? "WriteTimestamp" : (_includeKind ? "WriteDateTimeWithKind" : "WriteDateTime"), valueFrom, typeof(BclHelpers));
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			if (_useTimestamp)
			{
				ctx.LoadValue(entity);
			}
			ctx.EmitStateBasedRead(typeof(BclHelpers), _useTimestamp ? "ReadTimestamp" : "ReadDateTime", ExpectedType);
		}
	}
}
