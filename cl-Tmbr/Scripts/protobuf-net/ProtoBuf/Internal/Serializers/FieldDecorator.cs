using System;
using System.Reflection;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class FieldDecorator : ProtoDecoratorBase
	{
		private readonly FieldInfo field;

		public override Type ExpectedType { get; }

		public override bool RequiresOldValue => true;

		public override bool ReturnsValue => false;

		public FieldDecorator(Type forType, FieldInfo field, IRuntimeProtoSerializerNode tail)
			: base(tail)
		{
			if (tail == null)
			{
				ThrowHelper.ThrowArgumentNullException("tail");
			}
			if ((object)field == null)
			{
				ThrowHelper.ThrowArgumentNullException("field");
			}
			if ((object)forType == null)
			{
				ThrowHelper.ThrowArgumentNullException("forType");
			}
			ExpectedType = forType;
			this.field = field;
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			value = field.GetValue(value);
			if (value != null)
			{
				Tail.Write(ref state, value);
			}
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			object obj = Tail.Read(ref state, Tail.RequiresOldValue ? field.GetValue(value) : null);
			if (obj != null)
			{
				field.SetValue(value, obj);
			}
			return null;
		}

		protected override void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.LoadAddress(valueFrom, ExpectedType);
			ctx.LoadValue(field);
			ctx.WriteNullCheckedTail(field.FieldType, Tail, null);
		}

		protected override void EmitRead(CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(ExpectedType, valueFrom);
			if (Tail.RequiresOldValue)
			{
				ctx.LoadAddress(local, ExpectedType);
				ctx.LoadValue(field);
			}
			ctx.ReadNullCheckedTail(field.FieldType, Tail, null);
			MemberInfo member = field;
			ctx.CheckAccessibility(ref member);
			if (member is FieldInfo)
			{
				if (!Tail.ReturnsValue)
				{
					return;
				}
				Type type = PropertyDecorator.ChooseReadLocalType(field.FieldType, Tail.ExpectedType);
				using Local local2 = new Local(ctx, type);
				ctx.StoreValue(local2);
				if (field.FieldType.IsValueType)
				{
					ctx.LoadAddress(local, ExpectedType);
					ctx.LoadValue(local2);
					ctx.StoreValue(field);
					return;
				}
				CodeLabel label = ctx.DefineLabel();
				ctx.LoadValue(local2);
				ctx.BranchIfFalse(label, @short: true);
				ctx.LoadAddress(local, ExpectedType);
				ctx.LoadValue(local2);
				if (!field.FieldType.IsValueType && !type.IsValueType && !field.FieldType.IsAssignableFrom(type))
				{
					ctx.Cast(field.FieldType);
				}
				ctx.StoreValue(field);
				ctx.MarkLabel(label);
				return;
			}
			if (Tail.ReturnsValue)
			{
				ctx.DiscardValue();
			}
		}
	}
}
