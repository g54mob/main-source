using System;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class UriDecorator : ProtoDecoratorBase
	{
		private static readonly Type expectedType = typeof(Uri);

		public override bool IsScalar => true;

		public override Type ExpectedType => expectedType;

		public override bool RequiresOldValue => false;

		public override bool ReturnsValue => true;

		public UriDecorator(IRuntimeProtoSerializerNode tail)
			: base(tail)
		{
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			Tail.Write(ref state, ((Uri)value).OriginalString);
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			string text = (string)Tail.Read(ref state, null);
			if (text.Length != 0)
			{
				return new Uri(text, UriKind.RelativeOrAbsolute);
			}
			return null;
		}

		protected override void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.LoadValue(valueFrom);
			ctx.LoadValue(typeof(Uri).GetProperty("OriginalString"));
			Tail.EmitWrite(ctx, null);
		}

		protected override void EmitRead(CompilerContext ctx, Local valueFrom)
		{
			Tail.EmitRead(ctx, valueFrom);
			ctx.CopyValue();
			CodeLabel label = ctx.DefineLabel();
			CodeLabel label2 = ctx.DefineLabel();
			ctx.LoadValue(typeof(string).GetProperty("Length"));
			ctx.BranchIfTrue(label, @short: true);
			ctx.DiscardValue();
			ctx.LoadNullRef();
			ctx.Branch(label2, @short: true);
			ctx.MarkLabel(label);
			ctx.LoadValue(0);
			ctx.EmitCtor(typeof(Uri), typeof(string), typeof(UriKind));
			ctx.MarkLabel(label2);
		}
	}
}
