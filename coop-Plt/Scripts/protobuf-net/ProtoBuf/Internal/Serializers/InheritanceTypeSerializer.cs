using System;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class InheritanceTypeSerializer<TBase, T> : TypeSerializer<T>, ISubTypeSerializer<T> where TBase : class where T : class, TBase
	{
		public override bool HasInheritance => true;

		internal override Type BaseType => typeof(TBase);

		public override bool IsSubType => true;

		public override void Write(ref ProtoWriter.State state, T value)
		{
			state.WriteBaseType((TBase)value);
		}

		public override T Read(ref ProtoReader.State state, T value)
		{
			return state.ReadBaseType<TBase, T>(value);
		}

		T ISubTypeSerializer<T>.ReadSubType(ref ProtoReader.State state, SubTypeState<T> value)
		{
			value.OnBeforeDeserialize(_subTypeOnBeforeDeserialize);
			DeserializeBody(ref state, ref value, delegate(ref SubTypeState<T> s)
			{
				return s.Value;
			}, delegate(ref SubTypeState<T> s, T v)
			{
				s.Value = v;
			});
			T value2 = value.Value;
			Callback(ref value2, TypeModel.CallbackType.AfterDeserialize, state.Context);
			return value2;
		}

		void ISubTypeSerializer<T>.WriteSubType(ref ProtoWriter.State state, T value)
		{
			SerializeImpl(ref state, value);
		}

		public override void EmitReadRoot(CompilerContext context, Local valueFrom)
		{
			if (context.IsService)
			{
				using (Local local = context.GetLocalWithValue(typeof(T), valueFrom))
				{
					context.LoadSelfAsService<ISubTypeSerializer<TBase>, TBase>(CompatibilityLevel.NotSpecified, DataFormat.Default);
					context.LoadState();
					context.LoadSerializationContext(typeof(ISerializationContext));
					context.LoadValue(local);
					context.EmitCall(typeof(SubTypeState<TBase>).GetMethod("Create", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(T)));
					context.EmitCall(typeof(ISubTypeSerializer<TBase>).GetMethod("ReadSubType", BindingFlags.Instance | BindingFlags.Public));
					if (typeof(T) != typeof(TBase))
					{
						context.Cast(typeof(T));
					}
					return;
				}
			}
			context.LoadState();
			context.LoadValue(valueFrom);
			context.LoadSelfAsService<ISubTypeSerializer<TBase>, TBase>(CompatibilityLevel.NotSpecified, DataFormat.Default);
			context.EmitCall(typeof(ProtoReader.State).GetMethod("ReadBaseType", BindingFlags.Instance | BindingFlags.Public).MakeGenericMethod(typeof(TBase), typeof(T)));
		}

		public override void EmitWriteRoot(CompilerContext context, Local valueFrom)
		{
			using Local local = context.GetLocalWithValue(typeof(T), valueFrom);
			if (context.IsService)
			{
				context.LoadSelfAsService<ISubTypeSerializer<TBase>, TBase>(CompatibilityLevel.NotSpecified, DataFormat.Default);
				context.LoadState();
				context.LoadValue(local);
				context.EmitCall(typeof(ISubTypeSerializer<TBase>).GetMethod("WriteSubType", BindingFlags.Instance | BindingFlags.Public));
			}
			else
			{
				context.LoadState();
				context.LoadValue(local);
				context.LoadSelfAsService<ISubTypeSerializer<TBase>, TBase>(CompatibilityLevel.NotSpecified, DataFormat.Default);
				context.EmitCall(typeof(ProtoWriter).GetMethod("WriteBaseType", BindingFlags.Instance | BindingFlags.Public).MakeGenericMethod(typeof(TBase)));
			}
		}
	}
}
