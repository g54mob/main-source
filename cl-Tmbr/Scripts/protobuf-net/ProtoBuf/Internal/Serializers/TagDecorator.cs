using System;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class TagDecorator : ProtoDecoratorBase, IProtoTypeSerializer, IRuntimeProtoSerializerNode
	{
		private readonly bool strict;

		private readonly int fieldNumber;

		private readonly WireType wireType;

		SerializerFeatures IProtoTypeSerializer.Features => wireType.AsFeatures();

		bool IProtoTypeSerializer.IsSubType
		{
			get
			{
				if (Tail is IProtoTypeSerializer protoTypeSerializer)
				{
					return protoTypeSerializer.IsSubType;
				}
				return false;
			}
		}

		bool IProtoTypeSerializer.ShouldEmitCreateInstance
		{
			get
			{
				if (Tail is IProtoTypeSerializer protoTypeSerializer)
				{
					return protoTypeSerializer.ShouldEmitCreateInstance;
				}
				return false;
			}
		}

		public override Type ExpectedType => Tail.ExpectedType;

		Type IProtoTypeSerializer.BaseType => ExpectedType;

		public override bool RequiresOldValue => Tail.RequiresOldValue;

		public override bool ReturnsValue => Tail.ReturnsValue;

		private bool NeedsHint => (wireType & (WireType)(-8)) != 0;

		bool IProtoTypeSerializer.HasInheritance => false;

		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			if (Tail is IProtoTypeSerializer protoTypeSerializer)
			{
				return protoTypeSerializer.HasCallbacks(callbackType);
			}
			return false;
		}

		public bool CanCreateInstance()
		{
			if (Tail is IProtoTypeSerializer protoTypeSerializer)
			{
				return protoTypeSerializer.CanCreateInstance();
			}
			return false;
		}

		public object CreateInstance(ISerializationContext source)
		{
			return ((IProtoTypeSerializer)Tail).CreateInstance(source);
		}

		public void Callback(object value, TypeModel.CallbackType callbackType, ISerializationContext context)
		{
			(Tail as IProtoTypeSerializer)?.Callback(value, callbackType, context);
		}

		public void EmitCallback(CompilerContext ctx, Local valueFrom, TypeModel.CallbackType callbackType)
		{
			((IProtoTypeSerializer)Tail).EmitCallback(ctx, valueFrom, callbackType);
		}

		public void EmitCreateInstance(CompilerContext ctx, bool callNoteObject)
		{
			((IProtoTypeSerializer)Tail).EmitCreateInstance(ctx, callNoteObject);
		}

		public TagDecorator(int fieldNumber, WireType wireType, bool strict, IRuntimeProtoSerializerNode tail)
			: base(tail)
		{
			this.fieldNumber = fieldNumber;
			this.wireType = wireType;
			this.strict = strict;
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			if (strict)
			{
				state.Assert(wireType);
			}
			else if (NeedsHint)
			{
				state.Hint(wireType);
			}
			return Tail.Read(ref state, value);
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			if (Tail is IDirectRuntimeWriteNode directRuntimeWriteNode && directRuntimeWriteNode.CanDirectWrite(wireType))
			{
				directRuntimeWriteNode.DirectWrite(fieldNumber, wireType, ref state, value);
				return;
			}
			state.WriteFieldHeader(fieldNumber, wireType);
			Tail.Write(ref state, value);
		}

		void IProtoTypeSerializer.EmitReadRoot(CompilerContext ctx, Local valueFrom)
		{
			EmitRead(ctx, valueFrom);
		}

		void IProtoTypeSerializer.EmitWriteRoot(CompilerContext ctx, Local valueFrom)
		{
			EmitWrite(ctx, valueFrom);
		}

		protected override void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			if (Tail is IDirectWriteNode directWriteNode && directWriteNode.CanEmitDirectWrite(wireType))
			{
				directWriteNode.EmitDirectWrite(fieldNumber, wireType, ctx, valueFrom);
				return;
			}
			ctx.LoadState();
			ctx.LoadValue(fieldNumber);
			ctx.LoadValue((int)wireType);
			ctx.EmitCall(typeof(ProtoWriter.State).GetMethod("WriteFieldHeader"));
			Tail.EmitWrite(ctx, valueFrom);
		}

		public bool CanEmitDirectWrite()
		{
			if (Tail is IDirectWriteNode directWriteNode)
			{
				return directWriteNode.CanEmitDirectWrite(wireType);
			}
			return false;
		}

		public void EmitDirectWrite(CompilerContext ctx, Local valueFrom)
		{
			((IDirectWriteNode)Tail).EmitDirectWrite(fieldNumber, wireType, ctx, valueFrom);
		}

		protected override void EmitRead(CompilerContext ctx, Local valueFrom)
		{
			if (strict || NeedsHint)
			{
				ctx.LoadState();
				ctx.LoadValue((int)wireType);
				string name = (strict ? "Assert" : "Hint");
				ctx.EmitCall(typeof(ProtoReader.State).GetMethod(name, new Type[1] { typeof(WireType) }));
			}
			Tail.EmitRead(ctx, valueFrom);
		}
	}
}
