using System;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal class SubValueSerializer<T> : SubItemSerializer, IDirectWriteNode
	{
		private ISerializer<T> _customSerializer;

		public override bool IsSubType => false;

		public override Type ExpectedType => typeof(T);

		private ISerializer<T> CustomSerializer
		{
			get
			{
				object obj;
				if ((object)base.MetaType.SerializerType != null)
				{
					obj = _customSerializer;
					if (obj == null)
					{
						return CreateExternal();
					}
				}
				else
				{
					obj = null;
				}
				return (ISerializer<T>)obj;
			}
		}

		private ISerializer<T> CreateExternal()
		{
			return _customSerializer = (ISerializer<T>)SerializerCache.GetInstance(base.MetaType.SerializerType, typeof(T));
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			SerializerFeatures category = GetCategory();
			switch (category)
			{
			case SerializerFeatures.CategoryMessage:
			case SerializerFeatures.CategoryMessageWrappedAtRoot:
				state.WriteMessage(SerializerFeatures.CategoryRepeated, TypeHelper<T>.FromObject(value), CustomSerializer);
				break;
			case SerializerFeatures.CategoryScalar:
				CustomSerializer.Write(ref state, TypeHelper<T>.FromObject(value));
				break;
			default:
				category.ThrowInvalidCategory();
				break;
			}
		}

		private SerializerFeatures GetCategory()
		{
			return CustomSerializer?.Features.GetCategory() ?? SerializerFeatures.CategoryMessage;
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			SerializerFeatures category = GetCategory();
			switch (category)
			{
			case SerializerFeatures.CategoryMessage:
			case SerializerFeatures.CategoryMessageWrappedAtRoot:
				return state.ReadMessage(SerializerFeatures.CategoryRepeated, TypeHelper<T>.FromObject(value), CustomSerializer);
			case SerializerFeatures.CategoryScalar:
				return CustomSerializer.Read(ref state, TypeHelper<T>.FromObject(value));
			default:
				category.ThrowInvalidCategory();
				return null;
			}
		}

		protected override WireType GetDefaultWireType(ref DataFormat dataFormat)
		{
			ISerializer<T> customSerializer = CustomSerializer;
			if (customSerializer != null)
			{
				SerializerFeatures features = customSerializer.Features;
				if (features.GetCategory() == SerializerFeatures.CategoryScalar)
				{
					return features.GetWireType();
				}
			}
			return base.GetDefaultWireType(ref dataFormat);
		}

		public override void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			SerializerFeatures category = GetCategory();
			switch (GetCategory())
			{
			case SerializerFeatures.CategoryMessage:
			case SerializerFeatures.CategoryMessageWrappedAtRoot:
				SubItemSerializer.EmitWriteMessage<T>(null, WireType.String, ctx, valueFrom, null, applyRecursionCheck: true, base.MetaType.SerializerType);
				break;
			case SerializerFeatures.CategoryScalar:
			{
				using Local local = ctx.GetLocalWithValue(typeof(T), valueFrom);
				SubItemSerializer.EmitLoadCustomSerializer(ctx, base.MetaType.SerializerType, typeof(T));
				ctx.LoadState();
				ctx.LoadValue(local);
				ctx.EmitCall(typeof(ISerializer<T>).GetMethod("Write", BindingFlags.Instance | BindingFlags.Public));
				break;
			}
			default:
				category.ThrowInvalidCategory();
				break;
			}
		}

		public override void EmitRead(CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(typeof(T), valueFrom);
			SerializerFeatures category = GetCategory();
			switch (category)
			{
			case SerializerFeatures.CategoryMessage:
			case SerializerFeatures.CategoryMessageWrappedAtRoot:
				SubItemSerializer.EmitReadMessage<T>(ctx, local, null, base.MetaType.SerializerType);
				break;
			case SerializerFeatures.CategoryScalar:
				SubItemSerializer.EmitLoadCustomSerializer(ctx, base.MetaType.SerializerType, typeof(T));
				ctx.LoadState();
				ctx.LoadValue(local);
				ctx.EmitCall(typeof(ISerializer<T>).GetMethod("Read", BindingFlags.Instance | BindingFlags.Public));
				break;
			default:
				category.ThrowInvalidCategory();
				break;
			}
		}

		bool IDirectWriteNode.CanEmitDirectWrite(WireType wireType)
		{
			SerializerFeatures category = GetCategory();
			if (category == SerializerFeatures.CategoryMessage || category == SerializerFeatures.CategoryMessageWrappedAtRoot)
			{
				return wireType switch
				{
					WireType.String => true, 
					WireType.StartGroup => true, 
					_ => false, 
				};
			}
			return false;
		}

		void IDirectWriteNode.EmitDirectWrite(int fieldNumber, WireType wireType, CompilerContext ctx, Local valueFrom)
		{
			SubItemSerializer.EmitWriteMessage<T>(fieldNumber, wireType, ctx, valueFrom, null, applyRecursionCheck: true, base.MetaType.SerializerType);
		}
	}
}
