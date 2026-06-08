using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal abstract class TypeSerializer
	{
		public static IProtoTypeSerializer Create(Type forType, int[] fieldNumbers, IRuntimeProtoSerializerNode[] serializers, MethodInfo[] baseCtorCallbacks, bool isRootType, bool useConstructor, bool assertKnownType, CallbackSet callbacks, Type constructType, MethodInfo factory, Type rootType, SerializerFeatures features)
		{
			TypeSerializer typeSerializer = (TypeSerializer)(((object)rootType != null) ? Activator.CreateInstance(typeof(InheritanceTypeSerializer<, >).MakeGenericType(rootType, forType), nonPublic: true) : Activator.CreateInstance(typeof(TypeSerializer<>).MakeGenericType(forType), nonPublic: true));
			typeSerializer.Init(fieldNumbers, serializers, baseCtorCallbacks, isRootType, useConstructor, assertKnownType, callbacks, constructType, factory, features);
			return (IProtoTypeSerializer)typeSerializer;
		}

		internal abstract void Init(int[] fieldNumbers, IRuntimeProtoSerializerNode[] serializers, MethodInfo[] baseCtorCallbacks, bool isRootType, bool useConstructor, bool assertKnownType, CallbackSet callbacks, Type constructType, MethodInfo factory, SerializerFeatures features);
	}
	internal class TypeSerializer<T> : TypeSerializer, ISerializer<T>, IFactory<T>, IProtoTypeSerializer, IRuntimeProtoSerializerNode
	{
		protected delegate T StateGetter<TState>(ref TState state);

		protected delegate void StateSetter<TState>(ref TState state, T value);

		private Type constructType;

		private IRuntimeProtoSerializerNode[] serializers;

		private int[] fieldNumbers;

		private bool isRootType;

		private bool useConstructor;

		private bool isExtensible;

		private bool hasConstructor;

		private bool assertKnownType;

		private CallbackSet callbacks;

		private MethodInfo[] baseCtorCallbacks;

		private MethodInfo factory;

		private static readonly Type iextensible = typeof(IExtensible);

		protected Action<T, ISerializationContext> _subTypeOnBeforeDeserialize;

		public virtual bool HasInheritance => false;

		public virtual bool IsSubType => false;

		public Type ExpectedType => typeof(T);

		internal virtual Type BaseType => typeof(T);

		Type IProtoTypeSerializer.BaseType => BaseType;

		public SerializerFeatures Features { get; private set; }

		private bool CanHaveInheritance
		{
			get
			{
				if (ExpectedType.IsClass || ExpectedType.IsInterface)
				{
					return !ExpectedType.IsSealed;
				}
				return false;
			}
		}

		bool IRuntimeProtoSerializerNode.RequiresOldValue => true;

		bool IRuntimeProtoSerializerNode.ReturnsValue => false;

		bool IProtoTypeSerializer.ShouldEmitCreateInstance
		{
			get
			{
				if ((object)factory == null)
				{
					return !useConstructor;
				}
				return true;
			}
		}

		public virtual void EmitReadRoot(CompilerContext context, Local valueFrom)
		{
			((IRuntimeProtoSerializerNode)this).EmitRead(context, valueFrom);
		}

		public virtual void EmitWriteRoot(CompilerContext context, Local valueFrom)
		{
			((IRuntimeProtoSerializerNode)this).EmitWrite(context, valueFrom);
		}

		T IFactory<T>.Create(ISerializationContext context)
		{
			return (T)CreateInstance(context);
		}

		public virtual void Write(ref ProtoWriter.State state, T value)
		{
			SerializeImpl(ref state, value);
		}

		public virtual T Read(ref ProtoReader.State state, T value)
		{
			if (value == null)
			{
				value = (T)CreateInstance(state.Context);
			}
			Callback(ref value, TypeModel.CallbackType.BeforeDeserialize, state.Context);
			DeserializeBody(ref state, ref value, delegate(ref T o)
			{
				return o;
			}, delegate(ref T o, T v)
			{
				o = v;
			});
			Callback(ref value, TypeModel.CallbackType.AfterDeserialize, state.Context);
			return value;
		}

		void IRuntimeProtoSerializerNode.Write(ref ProtoWriter.State state, object value)
		{
			Write(ref state, TypeHelper<T>.FromObject(value));
		}

		object IRuntimeProtoSerializerNode.Read(ref ProtoReader.State state, object value)
		{
			return Read(ref state, TypeHelper<T>.FromObject(value));
		}

		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			if (!isRootType)
			{
				return false;
			}
			if (callbacks != null && (object)callbacks[callbackType] != null)
			{
				return true;
			}
			for (int i = 0; i < serializers.Length; i++)
			{
				if (serializers[i].ExpectedType != ExpectedType && ((IProtoTypeSerializer)serializers[i]).HasCallbacks(callbackType))
				{
					return true;
				}
			}
			return false;
		}

		internal override void Init(int[] fieldNumbers, IRuntimeProtoSerializerNode[] serializers, MethodInfo[] baseCtorCallbacks, bool isRootType, bool useConstructor, bool assertKnownType, CallbackSet callbacks, Type constructType, MethodInfo factory, SerializerFeatures features)
		{
			Array.Sort(fieldNumbers, serializers);
			Features = features;
			bool flag = false;
			Type expectedType = ExpectedType;
			for (int i = 0; i < fieldNumbers.Length; i++)
			{
				if (i != 0 && fieldNumbers[i] == fieldNumbers[i - 1])
				{
					throw new InvalidOperationException("Duplicate field-number detected; " + fieldNumbers[i] + " on: " + expectedType.FullName);
				}
				if (!flag && serializers[i].ExpectedType != expectedType)
				{
					flag = true;
				}
			}
			this.factory = factory;
			if ((object)constructType == null)
			{
				constructType = expectedType;
			}
			else if (!expectedType.IsAssignableFrom(constructType))
			{
				throw new InvalidOperationException(expectedType.FullName + " cannot be assigned from " + constructType.FullName);
			}
			this.constructType = constructType;
			this.serializers = serializers;
			this.fieldNumbers = fieldNumbers;
			this.callbacks = callbacks;
			this.isRootType = isRootType;
			this.useConstructor = useConstructor;
			this.assertKnownType = assertKnownType;
			if (baseCtorCallbacks != null)
			{
				MethodInfo[] array = baseCtorCallbacks;
				foreach (MethodInfo methodInfo in array)
				{
					if (!methodInfo.ReflectedType.IsAssignableFrom(expectedType))
					{
						throw new InvalidOperationException("Trying to assign incompatible callback to " + expectedType.FullName);
					}
				}
				if (baseCtorCallbacks.Length == 0)
				{
					baseCtorCallbacks = null;
				}
			}
			this.baseCtorCallbacks = baseCtorCallbacks;
			if ((object)Nullable.GetUnderlyingType(expectedType) != null)
			{
				throw new ArgumentException("Cannot create a TypeSerializer for nullable types", "forType");
			}
			if (iextensible.IsAssignableFrom(expectedType))
			{
				if (expectedType.IsValueType || !isRootType || flag)
				{
					throw new NotSupportedException("IExtensible is not supported in structs or classes with inheritance");
				}
				isExtensible = true;
			}
			hasConstructor = !constructType.IsAbstract && (object)Helpers.GetConstructor(constructType, Type.EmptyTypes, nonPublic: true) != null;
			if (constructType != expectedType && useConstructor && !hasConstructor)
			{
				throw new ArgumentException("The supplied default implementation cannot be created: " + constructType.FullName, "constructType");
			}
			if (HasInheritance && callbacks != null)
			{
				_subTypeOnBeforeDeserialize = delegate(T val, ISerializationContext ctx)
				{
					Callback(ref val, TypeModel.CallbackType.BeforeDeserialize, ctx);
				};
			}
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return true;
		}

		object IProtoTypeSerializer.CreateInstance(ISerializationContext context)
		{
			return CreateInstance(context);
		}

		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, ISerializationContext context)
		{
			if (isRootType && callbacks != null)
			{
				InvokeCallback(callbacks[callbackType], value, context);
			}
		}

		public void Callback(ref T value, TypeModel.CallbackType callbackType, ISerializationContext context)
		{
			if (isRootType && callbacks != null)
			{
				object obj = value;
				InvokeCallback(callbacks[callbackType], obj, context);
				value = (T)obj;
			}
		}

		private IRuntimeProtoSerializerNode GetMoreSpecificSerializer(object value)
		{
			if (!CanHaveInheritance)
			{
				return null;
			}
			Type type = value.GetType();
			if (type == ExpectedType)
			{
				return null;
			}
			for (int i = 0; i < serializers.Length; i++)
			{
				IRuntimeProtoSerializerNode runtimeProtoSerializerNode = serializers[i];
				if (runtimeProtoSerializerNode is IProtoTypeSerializer protoTypeSerializer && protoTypeSerializer.IsSubType && runtimeProtoSerializerNode.ExpectedType.IsAssignableFrom(type))
				{
					return runtimeProtoSerializerNode;
				}
			}
			if (type == constructType)
			{
				return null;
			}
			if (assertKnownType)
			{
				TypeModel.ThrowUnexpectedSubtype(ExpectedType, type);
			}
			return null;
		}

		protected void SerializeImpl(ref ProtoWriter.State state, T value)
		{
			Callback(ref value, TypeModel.CallbackType.BeforeSerialize, state.Context);
			if (CanHaveInheritance)
			{
				GetMoreSpecificSerializer(value)?.Write(ref state, value);
			}
			for (int i = 0; i < serializers.Length; i++)
			{
				IRuntimeProtoSerializerNode runtimeProtoSerializerNode = serializers[i];
				if (!(runtimeProtoSerializerNode is IProtoTypeSerializer protoTypeSerializer) || !protoTypeSerializer.IsSubType)
				{
					runtimeProtoSerializerNode.Write(ref state, value);
				}
			}
			if (isExtensible)
			{
				state.AppendExtensionData((IExtensible)(object)value);
			}
			Callback(ref value, TypeModel.CallbackType.AfterSerialize, state.Context);
		}

		protected void DeserializeBody<TState>(ref ProtoReader.State state, ref TState bodyState, StateGetter<TState> getter, StateSetter<TState> setter)
		{
			int num = 0;
			int num2 = 0;
			int num3;
			while ((num3 = state.ReadFieldHeader()) > 0)
			{
				bool flag = false;
				if (num3 < num)
				{
					num = (num2 = 0);
				}
				for (int i = num2; i < fieldNumbers.Length; i++)
				{
					if (fieldNumbers[i] != num3)
					{
						continue;
					}
					IRuntimeProtoSerializerNode runtimeProtoSerializerNode = serializers[i];
					if (runtimeProtoSerializerNode is IProtoTypeSerializer protoTypeSerializer && protoTypeSerializer.IsSubType)
					{
						bodyState = (TState)runtimeProtoSerializerNode.Read(ref state, bodyState);
					}
					else
					{
						T val = getter(ref bodyState);
						object obj = val;
						object obj2 = runtimeProtoSerializerNode.Read(ref state, obj);
						if (runtimeProtoSerializerNode.ReturnsValue)
						{
							setter(ref bodyState, (T)obj2);
						}
						else if (ExpectedType.IsValueType)
						{
							setter(ref bodyState, (T)obj);
						}
					}
					num2 = i;
					num = num3;
					flag = true;
					break;
				}
				if (!flag)
				{
					if (isExtensible)
					{
						T val2 = getter(ref bodyState);
						state.AppendExtensionData((IExtensible)(object)val2);
					}
					else
					{
						state.SkipField();
					}
				}
			}
		}

		private object InvokeCallback(MethodInfo method, object obj, ISerializationContext serializationContext)
		{
			object result = null;
			if ((object)method != null)
			{
				ParameterInfo[] parameters = method.GetParameters();
				object[] array;
				bool flag;
				if (parameters.Length == 0)
				{
					array = null;
					flag = true;
				}
				else
				{
					array = new object[parameters.Length];
					flag = true;
					for (int i = 0; i < array.Length; i++)
					{
						Type parameterType = parameters[i].ParameterType;
						object obj2;
						if (parameterType == typeof(ISerializationContext))
						{
							obj2 = serializationContext;
						}
						else if (parameterType == typeof(SerializationContext))
						{
							obj2 = SerializationContext.AsSerializationContext(serializationContext);
						}
						else if (parameterType == typeof(StreamingContext))
						{
							obj2 = SerializationContext.AsStreamingContext(serializationContext);
						}
						else if (parameterType == typeof(Type))
						{
							obj2 = constructType;
						}
						else
						{
							obj2 = null;
							flag = false;
						}
						array[i] = obj2;
					}
				}
				if (!flag)
				{
					throw CallbackSet.CreateInvalidCallbackSignature(method);
				}
				result = method.Invoke(obj, array);
			}
			return result;
		}

		private object CreateInstance(ISerializationContext context)
		{
			if ((object)factory != null)
			{
				return InvokeCallback(factory, null, context);
			}
			if (useConstructor)
			{
				if (!hasConstructor)
				{
					TypeModel.ThrowCannotCreateInstance(constructType);
				}
				return Activator.CreateInstance(constructType, nonPublic: true);
			}
			return BclHelpers.GetUninitializedObject(constructType);
		}

		private void LoadFromState(CompilerContext ctx, Local value)
		{
			if (HasInheritance)
			{
				Type type = typeof(SubTypeState<>).MakeGenericType(typeof(T));
				PropertyInfo property = type.GetProperty("Value");
				ctx.LoadAddress(value, type);
				ctx.EmitCall(property.GetGetMethod());
			}
			else
			{
				ctx.LoadValue(value);
			}
		}

		private void WriteToState(CompilerContext ctx, Local state, Local value, Type type)
		{
			if (HasInheritance)
			{
				Type type2 = typeof(SubTypeState<>).MakeGenericType(typeof(T));
				PropertyInfo property = type2.GetProperty("Value");
				if (value == null)
				{
					using (Local local = new Local(ctx, type))
					{
						ctx.LoadValue(value);
						ctx.StoreValue(local);
						ctx.LoadAddress(state, type2);
						ctx.LoadValue(local);
						ctx.EmitCall(property.GetSetMethod());
						return;
					}
				}
				ctx.LoadAddress(state, type2);
				ctx.LoadValue(value);
				ctx.EmitCall(property.GetSetMethod());
			}
			else
			{
				ctx.LoadValue(value);
				ctx.StoreValue(state);
			}
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			Type expectedType = ExpectedType;
			using Local local = ctx.GetLocalWithValue(expectedType, valueFrom);
			EmitCallbackIfNeeded(ctx, local, TypeModel.CallbackType.BeforeSerialize);
			CodeLabel label = ctx.DefineLabel();
			if (CanHaveInheritance)
			{
				if (serializers.Any((IRuntimeProtoSerializerNode x) => x is IProtoTypeSerializer protoTypeSerializer3 && protoTypeSerializer3.IsSubType))
				{
					ctx.LoadValue(local);
					ctx.EmitCall(typeof(TypeModel).GetMethod("IsSubType", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(T)));
					ctx.BranchIfFalse(label, @short: false);
					for (int num = 0; num < serializers.Length; num++)
					{
						IRuntimeProtoSerializerNode runtimeProtoSerializerNode = serializers[num];
						Type expectedType2 = runtimeProtoSerializerNode.ExpectedType;
						if (!(runtimeProtoSerializerNode is IProtoTypeSerializer protoTypeSerializer) || !protoTypeSerializer.IsSubType)
						{
							continue;
						}
						CodeLabel label2 = ctx.DefineLabel();
						ctx.LoadValue(local);
						ctx.TryCast(expectedType2);
						using Local local2 = new Local(ctx, expectedType2);
						ctx.StoreValue(local2);
						ctx.LoadValue(local2);
						ctx.BranchIfFalse(label2, @short: false);
						if (expectedType2.IsValueType)
						{
							ctx.LoadValue(local);
							ctx.CastFromObject(expectedType2);
							runtimeProtoSerializerNode.EmitWrite(ctx, null);
						}
						else
						{
							runtimeProtoSerializerNode.EmitWrite(ctx, local2);
						}
						ctx.Branch(label, @short: false);
						ctx.MarkLabel(label2);
					}
				}
				if (assertKnownType)
				{
					MethodInfo method = (((object)constructType == null || !(constructType != ExpectedType)) ? TypeSerializerMethodCache.ThrowUnexpectedSubtype[1].MakeGenericMethod(ExpectedType) : TypeSerializerMethodCache.ThrowUnexpectedSubtype[2].MakeGenericMethod(ExpectedType, constructType));
					ctx.LoadValue(local);
					ctx.EmitCall(method);
				}
			}
			ctx.MarkLabel(label);
			for (int num2 = 0; num2 < serializers.Length; num2++)
			{
				IRuntimeProtoSerializerNode runtimeProtoSerializerNode2 = serializers[num2];
				if (!(runtimeProtoSerializerNode2 is IProtoTypeSerializer protoTypeSerializer2) || !protoTypeSerializer2.IsSubType)
				{
					runtimeProtoSerializerNode2.EmitWrite(ctx, local);
				}
			}
			if (isExtensible)
			{
				ctx.EmitStateBasedWrite("AppendExtensionData", local);
			}
			EmitCallbackIfNeeded(ctx, local, TypeModel.CallbackType.AfterSerialize);
		}

		private static void EmitInvokeCallback(CompilerContext ctx, MethodInfo method, Type constructType, Type type, Local valueFrom)
		{
			if ((object)method == null)
			{
				return;
			}
			if (!method.IsStatic)
			{
				if (type.IsValueType)
				{
					ctx.LoadAddress(valueFrom, type);
				}
				else
				{
					ctx.LoadValue(valueFrom);
				}
			}
			ParameterInfo[] parameters = method.GetParameters();
			bool flag = true;
			for (int i = 0; i < parameters.Length; i++)
			{
				Type parameterType = parameters[i].ParameterType;
				if (parameterType == typeof(ISerializationContext) || parameterType == typeof(StreamingContext) || parameterType == typeof(SerializationContext))
				{
					ctx.LoadSerializationContext(parameterType);
				}
				else if (parameterType == typeof(Type))
				{
					Type type2 = constructType ?? type;
					ctx.LoadValue(type2);
				}
				else
				{
					flag = false;
				}
			}
			if (flag)
			{
				ctx.EmitCall(method);
				if ((object)constructType != null && method.ReturnType == typeof(object))
				{
					ctx.CastFromObject(type);
				}
				return;
			}
			throw CallbackSet.CreateInvalidCallbackSignature(method);
		}

		private void EmitCallbackIfNeeded(CompilerContext ctx, Local valueFrom, TypeModel.CallbackType callbackType)
		{
			if (isRootType && ((IProtoTypeSerializer)this).HasCallbacks(callbackType))
			{
				if (HasInheritance && callbackType == TypeModel.CallbackType.BeforeDeserialize)
				{
					ThrowHelper.ThrowInvalidOperationException("Should be using sub-type-state API");
				}
				else if (HasInheritance && callbackType == TypeModel.CallbackType.AfterDeserialize)
				{
					LoadFromState(ctx, valueFrom);
					((IProtoTypeSerializer)this).EmitCallback(ctx, (Local)null, callbackType);
				}
				else
				{
					((IProtoTypeSerializer)this).EmitCallback(ctx, valueFrom, callbackType);
				}
			}
		}

		void IProtoTypeSerializer.EmitCallback(CompilerContext ctx, Local valueFrom, TypeModel.CallbackType callbackType)
		{
			bool flag = false;
			if (CanHaveInheritance)
			{
				for (int i = 0; i < serializers.Length; i++)
				{
					IRuntimeProtoSerializerNode runtimeProtoSerializerNode = serializers[i];
					if (runtimeProtoSerializerNode.ExpectedType != ExpectedType && ((IProtoTypeSerializer)runtimeProtoSerializerNode).HasCallbacks(callbackType))
					{
						flag = true;
						break;
					}
				}
			}
			MethodInfo methodInfo = callbacks?[callbackType];
			if ((object)methodInfo != null || flag)
			{
				EmitInvokeCallback(ctx, methodInfo, null, ExpectedType, valueFrom);
				if (flag && BaseType != ExpectedType)
				{
					throw new NotSupportedException("Currently, serializatation callbacks are limited to the base-type in a hierarchy, but " + ExpectedType.NormalizeName() + " defines callbacks; this may be resolved in later versions; it is recommended to make the serialization callbacks 'virtual' methods on " + BaseType.NormalizeName() + "; or for the best compatibility with other serializers (DataContractSerializer, etc) - make the callbacks non-virtual methods on " + BaseType.NormalizeName() + " that *call* protected virtual methods on " + BaseType.NormalizeName());
				}
			}
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local valueFrom)
		{
			Type type = (HasInheritance ? typeof(SubTypeState<>).MakeGenericType(ExpectedType) : ExpectedType);
			using Local local = ctx.GetLocalWithValue(type, valueFrom);
			using Local local2 = new Local(ctx, typeof(int));
			if (!ExpectedType.IsValueType && !HasInheritance)
			{
				EmitCreateIfNull(ctx, local);
			}
			if (HasCallbacks(TypeModel.CallbackType.BeforeDeserialize))
			{
				if (HasInheritance)
				{
					MethodInfo methodInfo = callbacks?[TypeModel.CallbackType.BeforeDeserialize];
					if ((object)methodInfo != null)
					{
						ctx.LoadAddress(local, type);
						FieldInfo field = ctx.Scope.DefineSubTypeStateCallbackField<T>(methodInfo);
						ctx.LoadValue(field, checkAccessibility: false);
						ctx.EmitCall(type.GetMethod("OnBeforeDeserialize"));
					}
				}
				else
				{
					EmitCallbackIfNeeded(ctx, local, TypeModel.CallbackType.BeforeDeserialize);
				}
			}
			CodeLabel codeLabel = ctx.DefineLabel();
			CodeLabel label = ctx.DefineLabel();
			ctx.Branch(codeLabel, @short: false);
			ctx.MarkLabel(label);
			foreach (BasicList.Group<IRuntimeProtoSerializerNode> contiguousGroup in BasicList.GetContiguousGroups(fieldNumbers, serializers))
			{
				CodeLabel label2 = ctx.DefineLabel();
				int count = contiguousGroup.Items.Count;
				if (count == 1)
				{
					ctx.LoadValue(local2);
					ctx.LoadValue(contiguousGroup.First);
					CodeLabel codeLabel2 = ctx.DefineLabel();
					ctx.BranchIfEqual(codeLabel2, @short: true);
					ctx.Branch(label2, @short: false);
					WriteFieldHandler(ctx, ExpectedType, local, codeLabel2, codeLabel, contiguousGroup.Items[0]);
				}
				else
				{
					ctx.LoadValue(local2);
					ctx.LoadValue(contiguousGroup.First);
					ctx.Subtract();
					CodeLabel[] array = new CodeLabel[count];
					for (int i = 0; i < count; i++)
					{
						array[i] = ctx.DefineLabel();
					}
					ctx.Switch(array);
					ctx.Branch(label2, @short: false);
					for (int j = 0; j < count; j++)
					{
						WriteFieldHandler(ctx, ExpectedType, local, array[j], codeLabel, contiguousGroup.Items[j]);
					}
				}
				ctx.MarkLabel(label2);
			}
			ctx.LoadState();
			if (isExtensible)
			{
				LoadFromState(ctx, local);
				ctx.EmitCall(typeof(ProtoReader.State).GetMethod("AppendExtensionData", new Type[1] { typeof(IExtensible) }));
			}
			else
			{
				ctx.EmitCall(typeof(ProtoReader.State).GetMethod("SkipField", Type.EmptyTypes));
			}
			ctx.MarkLabel(codeLabel);
			ctx.EmitStateBasedRead("ReadFieldHeader", typeof(int));
			ctx.CopyValue();
			ctx.StoreValue(local2);
			ctx.LoadValue(0);
			ctx.BranchIfGreater(label, @short: false);
			if (HasCallbacks(TypeModel.CallbackType.AfterDeserialize))
			{
				EmitCallbackIfNeeded(ctx, local, TypeModel.CallbackType.AfterDeserialize);
			}
			if (HasInheritance)
			{
				LoadFromState(ctx, local);
			}
			else if (valueFrom != null && !local.IsSame(valueFrom))
			{
				LoadFromState(ctx, local);
				ctx.StoreValue(valueFrom);
			}
		}

		private void WriteFieldHandler(CompilerContext ctx, Type expected, Local loc, CodeLabel handler, CodeLabel @continue, IRuntimeProtoSerializerNode serializer)
		{
			ctx.MarkLabel(handler);
			bool flag = false;
			if (HasInheritance)
			{
				if (serializer is IProtoTypeSerializer protoTypeSerializer && protoTypeSerializer.IsSubType)
				{
					flag = true;
					serializer.EmitRead(ctx, loc);
				}
				else
				{
					LoadFromState(ctx, loc);
					serializer.EmitRead(ctx, null);
				}
			}
			else
			{
				serializer.EmitRead(ctx, loc);
			}
			if (!flag && serializer.ReturnsValue)
			{
				WriteToState(ctx, loc, null, serializer.ExpectedType);
			}
			ctx.Branch(@continue, @short: false);
		}

		void IProtoTypeSerializer.EmitCreateInstance(CompilerContext ctx, bool callNoteObject)
		{
			if ((object)factory != null)
			{
				EmitInvokeCallback(ctx, factory, constructType, ExpectedType, null);
			}
			else if (!useConstructor)
			{
				ctx.LoadValue(constructType);
				ctx.EmitCall(typeof(BclHelpers).GetMethod("GetUninitializedObject"));
				ctx.Cast(ExpectedType);
			}
			else if (constructType.IsClass && hasConstructor)
			{
				ctx.EmitCtor(constructType);
			}
			else
			{
				ctx.LoadValue(ExpectedType);
				ctx.LoadNullRef();
				ctx.EmitCall(typeof(TypeModel).GetMethod("ThrowCannotCreateInstance", BindingFlags.Static | BindingFlags.Public));
				ctx.LoadNullRef();
				callNoteObject = false;
			}
			if (callNoteObject || baseCtorCallbacks != null)
			{
				using (Local local = new Local(ctx, ExpectedType))
				{
					ctx.StoreValue(local);
					ctx.LoadValue(local);
				}
			}
		}

		private void EmitCreateIfNull(CompilerContext ctx, Local storage)
		{
			if (!ExpectedType.IsValueType)
			{
				CodeLabel label = ctx.DefineLabel();
				ctx.LoadValue(storage);
				ctx.BranchIfTrue(label, @short: false);
				((IProtoTypeSerializer)this).EmitCreateInstance(ctx, true);
				ctx.StoreValue(storage);
				ctx.MarkLabel(label);
			}
		}
	}
}
