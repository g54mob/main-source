using System;
using System.Reflection;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class DefaultValueDecorator : ProtoDecoratorBase
	{
		private readonly object defaultValue;

		public override Type ExpectedType => Tail.ExpectedType;

		public override bool RequiresOldValue => Tail.RequiresOldValue;

		public override bool ReturnsValue => Tail.ReturnsValue;

		public DefaultValueDecorator(object defaultValue, IRuntimeProtoSerializerNode tail)
			: base(tail)
		{
			if (defaultValue == null)
			{
				throw new ArgumentNullException("defaultValue");
			}
			Type type = defaultValue.GetType();
			if (type != tail.ExpectedType)
			{
				throw new ArgumentException("Default value is of incorrect type", "defaultValue");
			}
			this.defaultValue = defaultValue;
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			if (!object.Equals(value, defaultValue))
			{
				Tail.Write(ref state, value);
			}
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			return Tail.Read(ref state, value);
		}

		protected override void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			CodeLabel label = ctx.DefineLabel();
			using (Local local = ctx.GetLocalWithValue(ExpectedType, valueFrom))
			{
				ctx.LoadValue(local);
				EmitBranchIfDefaultValue(ctx, label);
				Tail.EmitWrite(ctx, local);
			}
			ctx.MarkLabel(label);
		}

		private void EmitBeq(CompilerContext ctx, CodeLabel label, Type type)
		{
			ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
			if ((uint)(typeCode - 3) <= 11u)
			{
				ctx.BranchIfEqual(label, @short: false);
				return;
			}
			MethodInfo method = type.GetMethod("op_Equality", BindingFlags.Static | BindingFlags.Public, null, new Type[2] { type, type }, null);
			if ((object)method == null || method.ReturnType != typeof(bool))
			{
				throw new InvalidOperationException("No suitable equality operator found for default-values of type: " + type.FullName);
			}
			ctx.EmitCall(method);
			ctx.BranchIfTrue(label, @short: false);
		}

		private void EmitBranchIfDefaultValue(CompilerContext ctx, CodeLabel label)
		{
			Type expectedType = ExpectedType;
			switch (Helpers.GetTypeCode(expectedType))
			{
			case ProtoTypeCode.Boolean:
				if ((bool)defaultValue)
				{
					ctx.BranchIfTrue(label, @short: false);
				}
				else
				{
					ctx.BranchIfFalse(label, @short: false);
				}
				break;
			case ProtoTypeCode.Byte:
				if ((byte)defaultValue == 0)
				{
					ctx.BranchIfFalse(label, @short: false);
					break;
				}
				ctx.LoadValue((byte)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.SByte:
				if ((sbyte)defaultValue == 0)
				{
					ctx.BranchIfFalse(label, @short: false);
					break;
				}
				ctx.LoadValue((sbyte)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.Int16:
				if ((short)defaultValue == 0)
				{
					ctx.BranchIfFalse(label, @short: false);
					break;
				}
				ctx.LoadValue((short)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.UInt16:
				if ((ushort)defaultValue == 0)
				{
					ctx.BranchIfFalse(label, @short: false);
					break;
				}
				ctx.LoadValue((ushort)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.Int32:
				if ((int)defaultValue == 0)
				{
					ctx.BranchIfFalse(label, @short: false);
					break;
				}
				ctx.LoadValue((int)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.UInt32:
				if ((uint)defaultValue == 0)
				{
					ctx.BranchIfFalse(label, @short: false);
					break;
				}
				ctx.LoadValue((int)(uint)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.Char:
				if ((char)defaultValue == '\0')
				{
					ctx.BranchIfFalse(label, @short: false);
					break;
				}
				ctx.LoadValue((char)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.Int64:
				ctx.LoadValue((long)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.UInt64:
				ctx.LoadValue((long)(ulong)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.Double:
				ctx.LoadValue((double)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.Single:
				ctx.LoadValue((float)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.String:
				ctx.LoadValue((string)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.Decimal:
			{
				decimal value = (decimal)defaultValue;
				ctx.LoadValue(value);
				EmitBeq(ctx, label, expectedType);
				break;
			}
			case ProtoTypeCode.TimeSpan:
			{
				TimeSpan timeSpan = (TimeSpan)defaultValue;
				if (timeSpan == TimeSpan.Zero)
				{
					ctx.LoadValue(typeof(TimeSpan).GetField("Zero"));
				}
				else
				{
					ctx.LoadValue(timeSpan.Ticks);
					ctx.EmitCall(typeof(TimeSpan).GetMethod("FromTicks"));
				}
				EmitBeq(ctx, label, expectedType);
				break;
			}
			case ProtoTypeCode.Guid:
				ctx.LoadValue((Guid)defaultValue);
				EmitBeq(ctx, label, expectedType);
				break;
			case ProtoTypeCode.DateTime:
				ctx.LoadValue(((DateTime)defaultValue).ToBinary());
				ctx.EmitCall(typeof(DateTime).GetMethod("FromBinary"));
				EmitBeq(ctx, label, expectedType);
				break;
			default:
				throw new NotSupportedException("Type cannot be represented as a default value: " + expectedType.FullName);
			}
		}

		protected override void EmitRead(CompilerContext ctx, Local valueFrom)
		{
			Tail.EmitRead(ctx, valueFrom);
		}
	}
}
