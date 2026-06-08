using System;
using System.Reflection;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class MemberSpecifiedDecorator : ProtoDecoratorBase
	{
		private readonly MethodInfo getSpecified;

		private readonly MethodInfo setSpecified;

		public override Type ExpectedType => Tail.ExpectedType;

		public override bool RequiresOldValue => Tail.RequiresOldValue;

		public override bool ReturnsValue => Tail.ReturnsValue;

		public MemberSpecifiedDecorator(MethodInfo getSpecified, MethodInfo setSpecified, IRuntimeProtoSerializerNode tail)
			: base(tail)
		{
			if ((object)getSpecified == null && (object)setSpecified == null)
			{
				throw new InvalidOperationException();
			}
			this.getSpecified = getSpecified;
			this.setSpecified = setSpecified;
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			if ((object)getSpecified == null || (bool)getSpecified.Invoke(value, null))
			{
				Tail.Write(ref state, value);
			}
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			object result = Tail.Read(ref state, value);
			if ((object)setSpecified != null)
			{
				setSpecified.Invoke(value, new object[1] { true });
			}
			return result;
		}

		protected override void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			if ((object)getSpecified == null)
			{
				Tail.EmitWrite(ctx, valueFrom);
				return;
			}
			using Local local = ctx.GetLocalWithValue(ExpectedType, valueFrom);
			ctx.LoadAddress(local, ExpectedType);
			ctx.EmitCall(getSpecified);
			CodeLabel label = ctx.DefineLabel();
			ctx.BranchIfFalse(label, @short: false);
			Tail.EmitWrite(ctx, local);
			ctx.MarkLabel(label);
		}

		protected override void EmitRead(CompilerContext ctx, Local valueFrom)
		{
			if ((object)setSpecified == null)
			{
				Tail.EmitRead(ctx, valueFrom);
				return;
			}
			using Local local = ctx.GetLocalWithValue(ExpectedType, valueFrom);
			Tail.EmitRead(ctx, local);
			ctx.LoadAddress(local, ExpectedType);
			ctx.LoadValue(1);
			ctx.EmitCall(setSpecified);
		}
	}
}
