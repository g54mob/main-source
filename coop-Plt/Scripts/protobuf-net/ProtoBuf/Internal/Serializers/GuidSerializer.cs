using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class GuidSerializer : IRuntimeProtoSerializerNode
	{
		private enum Variant
		{
			BclGuid = 0,
			GuidString = 1,
			GuidBytes = 2
		}

		private readonly Variant _variant;

		private static GuidSerializer s_Legacy;

		private static GuidSerializer s_String;

		private static GuidSerializer s_Bytes;

		private static readonly Type expectedType = typeof(Guid);

		public Type ExpectedType => expectedType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		internal static GuidSerializer Create(CompatibilityLevel compatibilityLevel, DataFormat dataFormat)
		{
			if (compatibilityLevel < CompatibilityLevel.Level300)
			{
				return s_Legacy ?? (s_Legacy = new GuidSerializer(Variant.BclGuid));
			}
			if (dataFormat == DataFormat.FixedSize)
			{
				return s_Bytes ?? (s_Bytes = new GuidSerializer(Variant.GuidBytes));
			}
			return s_String ?? (s_String = new GuidSerializer(Variant.GuidString));
		}

		private GuidSerializer(Variant variant)
		{
			_variant = variant;
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			switch (_variant)
			{
			case Variant.GuidString:
				BclHelpers.WriteGuidString(ref state, (Guid)value);
				break;
			case Variant.GuidBytes:
				BclHelpers.WriteGuidBytes(ref state, (Guid)value);
				break;
			default:
				BclHelpers.WriteGuid(ref state, (Guid)value);
				break;
			}
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return _variant switch
			{
				Variant.GuidString => BclHelpers.ReadGuidString(ref state), 
				Variant.GuidBytes => BclHelpers.ReadGuidBytes(ref state), 
				_ => BclHelpers.ReadGuid(ref state), 
			};
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.EmitStateBasedWrite(_variant switch
			{
				Variant.GuidString => "WriteGuidString", 
				Variant.GuidBytes => "WriteGuidBytes", 
				_ => "WriteGuid", 
			}, valueFrom, typeof(BclHelpers));
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			Type typeFromHandle = typeof(BclHelpers);
			ctx.EmitStateBasedRead(typeFromHandle, _variant switch
			{
				Variant.GuidString => "ReadGuidString", 
				Variant.GuidBytes => "ReadGuidBytes", 
				_ => "ReadGuid", 
			}, ExpectedType);
		}
	}
}
