using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class DecimalSerializer : IRuntimeProtoSerializerNode
	{
		private enum Variant
		{
			BclDecimal = 0,
			String = 1
		}

		private static DecimalSerializer s_BclDecimal;

		private static DecimalSerializer s_String;

		private readonly Variant _variant;

		private static readonly Type expectedType = typeof(decimal);

		bool IRuntimeProtoSerializerNode.IsScalar => _variant == Variant.String;

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		public static DecimalSerializer Create(CompatibilityLevel compatibilityLevel)
		{
			if (compatibilityLevel < CompatibilityLevel.Level300)
			{
				return s_BclDecimal ?? (s_BclDecimal = new DecimalSerializer(Variant.BclDecimal));
			}
			return s_String ?? (s_String = new DecimalSerializer(Variant.String));
		}

		private DecimalSerializer(Variant variant)
		{
			_variant = variant;
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			Variant variant = _variant;
			decimal num = ((variant != Variant.String) ? BclHelpers.ReadDecimal(ref state) : BclHelpers.ReadDecimalString(ref state));
			return num;
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			Variant variant = _variant;
			if (variant == Variant.String)
			{
				BclHelpers.WriteDecimalString(ref state, (decimal)value);
			}
			else
			{
				BclHelpers.WriteDecimal(ref state, (decimal)value);
			}
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			Variant variant = _variant;
			string methodName = ((variant != Variant.String) ? "WriteDecimal" : "WriteDecimalString");
			ctx.EmitStateBasedWrite(methodName, valueFrom, typeof(BclHelpers));
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			Type typeFromHandle = typeof(BclHelpers);
			Variant variant = _variant;
			string methodName = ((variant != Variant.String) ? "ReadDecimal" : "ReadDecimalString");
			ctx.EmitStateBasedRead(typeFromHandle, methodName, ExpectedType);
		}
	}
}
