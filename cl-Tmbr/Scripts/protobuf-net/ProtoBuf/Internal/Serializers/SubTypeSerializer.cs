using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class SubTypeSerializer<TParent, TChild> : SubItemSerializer, IDirectWriteNode where TParent : class where TChild : class, TParent
	{
		private static readonly Dictionary<int, MethodInfo> s_WriteSubType = (from method in typeof(ProtoWriter.State).GetMethods(BindingFlags.Instance | BindingFlags.Public)
			where method.Name == "WriteSubType" && method.IsGenericMethod
			select new
			{
				ArgCount = method.GetParameters().Length,
				Method = method
			}).ToDictionary(x => x.ArgCount, x => x.Method);

		public override bool IsSubType => true;

		public override Type ExpectedType => typeof(TChild);

		public override Type BaseType => typeof(TParent);

		public override void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteSubType((TChild)value);
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			SubTypeState<TParent> subTypeState = (SubTypeState<TParent>)value;
			subTypeState.ReadSubType<TChild>(ref state);
			return subTypeState;
		}

		public override void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(typeof(TChild), valueFrom);
			ctx.LoadState();
			ctx.LoadValue(local);
			ctx.LoadSelfAsService<ISubTypeSerializer<TChild>, TChild>(CompatibilityLevel.NotSpecified, DataFormat.Default);
			ctx.EmitCall(s_WriteSubType[2].MakeGenericMethod(typeof(TChild)));
		}

		bool IDirectWriteNode.CanEmitDirectWrite(WireType wireType)
		{
			return wireType == WireType.String;
		}

		void IDirectWriteNode.EmitDirectWrite(int fieldNumber, WireType wireType, CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(typeof(TChild), valueFrom);
			ctx.LoadState();
			ctx.LoadValue(fieldNumber);
			ctx.LoadValue(local);
			ctx.LoadSelfAsService<ISubTypeSerializer<TChild>, TChild>(CompatibilityLevel.NotSpecified, DataFormat.Default);
			ctx.EmitCall(s_WriteSubType[3].MakeGenericMethod(typeof(TChild)));
		}

		public override void EmitRead(CompilerContext ctx, Local valueFrom)
		{
			Type typeFromHandle = typeof(SubTypeState<TParent>);
			ctx.LoadAddress(valueFrom, typeFromHandle);
			ctx.LoadState();
			ctx.LoadSelfAsService<ISubTypeSerializer<TChild>, TChild>(CompatibilityLevel.NotSpecified, DataFormat.Default);
			ctx.EmitCall(typeFromHandle.GetMethod("ReadSubType").MakeGenericMethod(typeof(TChild)));
		}
	}
}
