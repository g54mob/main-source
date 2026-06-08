using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal abstract class SubItemSerializer : IProtoTypeSerializer, IRuntimeProtoSerializerNode
	{
		private static readonly Dictionary<int, MethodInfo> s_WriteMessage = (from method in typeof(ProtoWriter.State).GetMethods(BindingFlags.Instance | BindingFlags.Public)
			where method.Name == "WriteMessage" && method.IsGenericMethodDefinition && method.GetGenericArguments().Length == 1
			select new
			{
				ArgCount = method.GetParameters().Length,
				Method = method
			}).ToDictionary(x => x.ArgCount, x => x.Method);

		private static readonly Dictionary<int, MethodInfo> s_WriteGroup = (from method in typeof(ProtoWriter.State).GetMethods(BindingFlags.Instance | BindingFlags.Public)
			where method.Name == "WriteGroup" && method.IsGenericMethodDefinition && method.GetGenericArguments().Length == 1
			select new
			{
				ArgCount = method.GetParameters().Length,
				Method = method
			}).ToDictionary(x => x.ArgCount, x => x.Method);

		private static readonly MethodInfo s_ReadMessage = (from method in typeof(ProtoReader.State).GetMethods(BindingFlags.Instance | BindingFlags.Public)
			where method.Name == "ReadMessage" && method.IsGenericMethodDefinition && method.GetGenericArguments().Length == 1 && method.GetParameters().Length == 3
			select method).Single();

		SerializerFeatures IProtoTypeSerializer.Features
		{
			get
			{
				ThrowHelper.ThrowNotImplementedException("Features");
				return SerializerFeatures.CategoryRepeated;
			}
		}

		public abstract bool IsSubType { get; }

		public abstract Type ExpectedType { get; }

		public virtual Type BaseType => ExpectedType;

		bool IProtoTypeSerializer.HasInheritance => false;

		bool IProtoTypeSerializer.ShouldEmitCreateInstance
		{
			get
			{
				if (Proxy.Serializer is IProtoTypeSerializer protoTypeSerializer)
				{
					return protoTypeSerializer.ShouldEmitCreateInstance;
				}
				return false;
			}
		}

		bool IRuntimeProtoSerializerNode.RequiresOldValue => true;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		protected ISerializerProxy Proxy => MetaType;

		protected MetaType MetaType { get; private set; }

		public abstract void Write(ref ProtoWriter.State state, object value);

		public abstract object Read(ref ProtoReader.State state, object value);

		public abstract void EmitWrite(CompilerContext ctx, Local valueFrom);

		public abstract void EmitRead(CompilerContext ctx, Local valueFrom);

		void IProtoTypeSerializer.EmitReadRoot(CompilerContext ctx, Local valueFrom)
		{
			((IRuntimeProtoSerializerNode)this).EmitRead(ctx, valueFrom);
		}

		void IProtoTypeSerializer.EmitWriteRoot(CompilerContext ctx, Local valueFrom)
		{
			((IRuntimeProtoSerializerNode)this).EmitWrite(ctx, valueFrom);
		}

		bool IProtoTypeSerializer.HasCallbacks(TypeModel.CallbackType callbackType)
		{
			if (Proxy.Serializer is IProtoTypeSerializer protoTypeSerializer)
			{
				return protoTypeSerializer.HasCallbacks(callbackType);
			}
			return false;
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			if (Proxy.Serializer is IProtoTypeSerializer protoTypeSerializer)
			{
				return protoTypeSerializer.CanCreateInstance();
			}
			return false;
		}

		void IProtoTypeSerializer.EmitCallback(CompilerContext ctx, Local valueFrom, TypeModel.CallbackType callbackType)
		{
			((IProtoTypeSerializer)Proxy.Serializer).EmitCallback(ctx, valueFrom, callbackType);
		}

		void IProtoTypeSerializer.EmitCreateInstance(CompilerContext ctx, bool callNoteObject)
		{
			((IProtoTypeSerializer)Proxy.Serializer).EmitCreateInstance(ctx, callNoteObject);
		}

		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, ISerializationContext context)
		{
			((IProtoTypeSerializer)Proxy.Serializer).Callback(value, callbackType, context);
		}

		object IProtoTypeSerializer.CreateInstance(ISerializationContext source)
		{
			return ((IProtoTypeSerializer)Proxy.Serializer).CreateInstance(source);
		}

		protected static void EmitLoadCustomSerializer(CompilerContext ctx, Type serializerType, Type forType)
		{
			MemberInfo underlyingProvider = RuntimeTypeModel.GetUnderlyingProvider(serializerType, forType);
			RuntimeTypeModel.EmitProvider(underlyingProvider, ctx.IL);
		}

		public static void EmitWriteMessage<T>(int? fieldNumber, WireType wireType, CompilerContext ctx, Local value = null, FieldInfo serializer = null, bool applyRecursionCheck = true, Type serializerType = null)
		{
			using Local local = ctx.GetLocalWithValue(typeof(T), value);
			ctx.LoadState();
			if (fieldNumber.HasValue)
			{
				ctx.LoadValue(fieldNumber.Value);
			}
			ctx.LoadValue((!applyRecursionCheck) ? 1024 : 0);
			ctx.LoadValue(local);
			LoadSerializer<T>(ctx, serializer, serializerType);
			Dictionary<int, MethodInfo> dictionary = ((wireType != WireType.StartGroup) ? s_WriteMessage : s_WriteGroup);
			Dictionary<int, MethodInfo> dictionary2 = dictionary;
			ctx.EmitCall(dictionary2[fieldNumber.HasValue ? 4 : 3].MakeGenericMethod(typeof(T)));
		}

		private static void LoadSerializer<T>(CompilerContext ctx, FieldInfo serializer, Type serializerType)
		{
			if ((object)serializerType != null && (ctx.NonPublic || RuntimeTypeModel.IsFullyPublic(serializerType)))
			{
				EmitLoadCustomSerializer(ctx, serializerType, typeof(T));
			}
			else if ((object)serializer != null)
			{
				ctx.LoadValue(serializer, checkAccessibility: false);
			}
			else
			{
				ctx.LoadSelfAsService<ISerializer<T>, T>(CompatibilityLevel.NotSpecified, DataFormat.Default);
			}
		}

		public static void EmitReadMessage<T>(CompilerContext ctx, Local value = null, FieldInfo serializer = null, Type serializerType = null)
		{
			ctx.LoadState();
			ctx.LoadValue(0);
			if (value == null)
			{
				if (TypeHelper<T>.IsReferenceType)
				{
					ctx.LoadNullRef();
				}
				else
				{
					using Local local = new Local(ctx, typeof(T));
					ctx.InitLocal(typeof(T), local);
					ctx.LoadValue(local);
				}
			}
			else
			{
				ctx.LoadValue(value);
			}
			LoadSerializer<T>(ctx, serializer, serializerType);
			ctx.EmitCall(s_ReadMessage.MakeGenericMethod(typeof(T)));
		}

		internal static IRuntimeProtoSerializerNode Create(Type type, MetaType metaType, ref DataFormat dataFormat, out WireType defaultWireType)
		{
			SubItemSerializer subItemSerializer = (SubItemSerializer)Activator.CreateInstance(typeof(SubValueSerializer<>).MakeGenericType(type), nonPublic: true);
			subItemSerializer.MetaType = metaType ?? throw new ArgumentNullException("metaType");
			defaultWireType = subItemSerializer.GetDefaultWireType(ref dataFormat);
			return subItemSerializer;
		}

		protected virtual WireType GetDefaultWireType(ref DataFormat dataFormat)
		{
			if (dataFormat != DataFormat.Group)
			{
				return WireType.String;
			}
			return WireType.StartGroup;
		}

		internal static IRuntimeProtoSerializerNode Create(Type actualType, MetaType metaType, Type parentType)
		{
			SubItemSerializer subItemSerializer = (SubItemSerializer)Activator.CreateInstance(typeof(SubTypeSerializer<, >).MakeGenericType(parentType, actualType), nonPublic: true);
			subItemSerializer.MetaType = metaType ?? throw new ArgumentNullException("metaType");
			return subItemSerializer;
		}
	}
}
