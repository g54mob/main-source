using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class TimeSpanSerializer : IRuntimeProtoSerializerNode
	{
		private static TimeSpanSerializer s_Legacy;

		private static TimeSpanSerializer s_Duration;

		private static readonly Type expectedType = typeof(TimeSpan);

		private readonly bool _useDuration;

		bool IRuntimeProtoSerializerNode.IsScalar => false;

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		public static TimeSpanSerializer Create(CompatibilityLevel compatibilityLevel)
		{
			object obj;
			if (compatibilityLevel < CompatibilityLevel.Level240)
			{
				obj = s_Legacy;
				if (obj == null)
				{
					return s_Legacy = new TimeSpanSerializer(useDuration: false);
				}
			}
			else
			{
				obj = s_Duration ?? (s_Duration = new TimeSpanSerializer(useDuration: true));
			}
			return (TimeSpanSerializer)obj;
		}

		private TimeSpanSerializer(bool useDuration)
		{
			_useDuration = useDuration;
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			if (_useDuration)
			{
				return BclHelpers.ReadDuration(ref state);
			}
			return BclHelpers.ReadTimeSpan(ref state);
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			if (_useDuration)
			{
				BclHelpers.WriteDuration(ref state, (TimeSpan)value);
			}
			else
			{
				BclHelpers.WriteTimeSpan(ref state, (TimeSpan)value);
			}
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite(_useDuration ? "WriteDuration" : "WriteTimeSpan", valueFrom, typeof(BclHelpers));
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			if (_useDuration)
			{
				ctx.LoadValue(entity);
			}
			ctx.EmitStateBasedRead(typeof(BclHelpers), _useDuration ? "ReadDuration" : "ReadTimeSpan", ExpectedType);
		}
	}
}
