using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal
{
	internal abstract class DynamicStub
	{
		private class NilStub : DynamicStub
		{
			public static readonly NilStub Instance = new NilStub();

			protected NilStub()
			{
			}

			protected override bool TryDeserializeRoot(TypeModel model, ref ProtoReader.State state, ref object value, bool autoCreate)
			{
				return false;
			}

			protected override bool TryDeserialize(ObjectScope scope, TypeModel model, ref ProtoReader.State state, ref object value)
			{
				return false;
			}

			protected override bool TrySerializeRoot(TypeModel model, ref ProtoWriter.State state, object value)
			{
				return false;
			}

			protected override bool TrySerializeAny(int fieldNumber, SerializerFeatures features, TypeModel model, ref ProtoWriter.State state, object value)
			{
				return false;
			}

			protected override bool TryDeepClone(TypeModel model, ref object value)
			{
				return false;
			}

			protected override bool IsKnownType(TypeModel model, CompatibilityLevel ambient)
			{
				return false;
			}

			protected override bool CanSerialize(TypeModel model, out SerializerFeatures features)
			{
				features = SerializerFeatures.CategoryRepeated;
				return false;
			}

			protected override Type GetEffectiveType()
			{
				return null;
			}
		}

		private sealed class ConcreteStub<T> : DynamicStub
		{
			protected override Type GetEffectiveType()
			{
				return typeof(T);
			}

			protected override bool TryDeserializeRoot(TypeModel model, ref ProtoReader.State state, ref object value, bool autoCreate)
			{
				ISerializer<T> serializer = TypeModel.TryGetSerializer<T>(model);
				if (serializer == null)
				{
					return false;
				}
				bool flag = !autoCreate && value == null;
				long position = state.GetPosition();
				value = state.DeserializeRoot(TypeHelper<T>.FromObject(value), serializer);
				if (flag && position == state.GetPosition())
				{
					value = null;
				}
				return true;
			}

			protected override bool TryDeserialize(ObjectScope scope, TypeModel model, ref ProtoReader.State state, ref object value)
			{
				ISerializer<T> serializer = TypeModel.TryGetSerializer<T>(model);
				if (serializer == null)
				{
					return false;
				}
				T value2 = TypeHelper<T>.FromObject(value);
				switch (scope)
				{
				case ObjectScope.LikeRoot:
					value2 = state.ReadAsRoot(value2, serializer);
					break;
				case ObjectScope.NakedMessage:
				case ObjectScope.Scalar:
					value2 = serializer.Read(ref state, value2);
					break;
				case ObjectScope.WrappedMessage:
					value2 = state.ReadMessage(SerializerFeatures.CategoryRepeated, value2, serializer);
					break;
				default:
					return false;
				}
				value = value2;
				return true;
			}

			protected override bool IsKnownType(TypeModel model, CompatibilityLevel ambient)
			{
				return model?.IsKnownType<T>(ambient) ?? false;
			}

			protected override bool CanSerialize(TypeModel model, out SerializerFeatures features)
			{
				ISerializer<T> serializer;
				try
				{
					serializer = TypeModel.TryGetSerializer<T>(model);
				}
				catch
				{
					features = SerializerFeatures.CategoryRepeated;
					return false;
				}
				if (serializer == null)
				{
					features = SerializerFeatures.CategoryRepeated;
					return false;
				}
				features = serializer.Features;
				return true;
			}

			protected override bool TrySerializeRoot(TypeModel model, ref ProtoWriter.State state, object value)
			{
				ISerializer<T> serializer = TypeModel.TryGetSerializer<T>(model);
				if (serializer == null)
				{
					return false;
				}
				state.SerializeRoot(TypeHelper<T>.FromObject(value), serializer);
				return true;
			}

			protected override bool TrySerializeAny(int fieldNumber, SerializerFeatures features, TypeModel model, ref ProtoWriter.State state, object value)
			{
				ISerializer<T> serializer = TypeModel.TryGetSerializer<T>(model);
				if (serializer == null)
				{
					return false;
				}
				T value2 = TypeHelper<T>.FromObject(value);
				CheckAnyAuxFlow(features, serializer);
				if ((features & SerializerFeatures.CategoryMessageWrappedAtRoot) == SerializerFeatures.CategoryMessageWrappedAtRoot)
				{
					if (fieldNumber != 1)
					{
						ThrowHelper.ThrowInvalidOperationException($"Special root-like wrapping is limited to field {1}");
					}
					state.WriteAsRoot(value2, serializer);
				}
				else
				{
					state.WriteAny(fieldNumber, features, value2, serializer);
				}
				return true;
			}

			private static void CheckAnyAuxFlow(SerializerFeatures features, ISerializer<T> serializer)
			{
				if ((features & (SerializerFeatures)1073741824) != SerializerFeatures.CategoryRepeated && serializer.Features.GetCategory() == SerializerFeatures.CategoryMessageWrappedAtRoot)
				{
					ThrowHelper.ThrowNotImplementedException("Tell Marc: ambiguous category in an any/aux flow for " + typeof(T).NormalizeName());
				}
			}

			protected override bool TryDeepClone(TypeModel model, ref object value)
			{
				if (TypeModel.TryGetSerializer<T>(model) == null)
				{
					return false;
				}
				value = model.DeepClone(TypeHelper<T>.FromObject(value));
				return true;
			}
		}

		private static readonly Hashtable s_byType = new Hashtable { 
		{
			typeof(object),
			NilStub.Instance
		} };

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool TryDeserializeRoot(Type type, TypeModel model, ref ProtoReader.State state, ref object value, bool autoCreate)
		{
			return Get(type).TryDeserializeRoot(model, ref state, ref value, autoCreate);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool TrySerializeRoot(Type type, TypeModel model, ref ProtoWriter.State state, object value)
		{
			do
			{
				if (Get(type).TrySerializeRoot(model, ref state, value))
				{
					return true;
				}
				type = type.BaseType;
			}
			while ((object)type != null && type != typeof(object));
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool TryDeserialize(ObjectScope scope, Type type, TypeModel model, ref ProtoReader.State state, ref object value)
		{
			return Get(type).TryDeserialize(scope, model, ref state, ref value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool TrySerializeAny(int fieldNumber, SerializerFeatures features, Type type, TypeModel model, ref ProtoWriter.State state, object value)
		{
			do
			{
				if (Get(type).TrySerializeAny(fieldNumber, features, model, ref state, value))
				{
					return true;
				}
				type = type.BaseType;
			}
			while ((object)type != null && type != typeof(object));
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool TryDeepClone(Type type, TypeModel model, ref object value)
		{
			do
			{
				if (Get(type).TryDeepClone(model, ref value))
				{
					return true;
				}
				type = type.BaseType;
			}
			while ((object)type != null && type != typeof(object));
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsKnownType(Type type, TypeModel model, CompatibilityLevel ambient)
		{
			return Get(type).IsKnownType(model, ambient);
		}

		internal static bool CanSerialize(Type type, TypeModel model, out SerializerFeatures features)
		{
			return Get(type).CanSerialize(model, out features);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static DynamicStub Get(Type type)
		{
			return ((DynamicStub)s_byType[type]) ?? SlowGet(type);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static DynamicStub SlowGet(Type type)
		{
			if ((object)type == null)
			{
				return NilStub.Instance;
			}
			DynamicStub dynamicStub = null;
			Type type2 = null;
			if (!type.IsGenericParameter)
			{
				type2 = ((!type.IsValueType) ? ResolveProxies(type) : Nullable.GetUnderlyingType(type));
			}
			else
			{
				dynamicStub = NilStub.Instance;
			}
			if (dynamicStub == null)
			{
				if ((object)type2 != null && type2 != type)
				{
					dynamicStub = Get(type2);
				}
				if (dynamicStub == null)
				{
					dynamicStub = TryCreateConcrete(typeof(ConcreteStub<>), new Type[1] { type });
				}
			}
			lock (s_byType)
			{
				s_byType[type] = dynamicStub;
				return dynamicStub;
			}
			static Type ResolveProxies(Type type3)
			{
				if ((object)type3 == null)
				{
					return null;
				}
				if (type3.IsGenericParameter)
				{
					return null;
				}
				string fullName = type3.FullName;
				if (fullName != null && fullName.StartsWith("System.Data.Entity.DynamicProxies."))
				{
					return type3.BaseType;
				}
				Type[] interfaces = type3.GetInterfaces();
				Type[] array = interfaces;
				foreach (Type type4 in array)
				{
					switch (type4.FullName)
					{
					case "NHibernate.Proxy.INHibernateProxy":
					case "NHibernate.Proxy.DynamicProxy.IProxy":
					case "NHibernate.Intercept.IFieldInterceptorAccessor":
						return type3.BaseType;
					}
				}
				return null;
			}
			static DynamicStub TryCreateConcrete(Type typeDef, Type[] args)
			{
				try
				{
					return (DynamicStub)Activator.CreateInstance(typeDef.MakeGenericType(args), nonPublic: true);
				}
				catch
				{
					return NilStub.Instance;
				}
			}
		}

		protected abstract bool TryDeserializeRoot(TypeModel model, ref ProtoReader.State state, ref object value, bool autoCreate);

		protected abstract bool TryDeserialize(ObjectScope scope, TypeModel model, ref ProtoReader.State state, ref object value);

		protected abstract bool TrySerializeRoot(TypeModel model, ref ProtoWriter.State state, object value);

		protected abstract bool TrySerializeAny(int fieldNumber, SerializerFeatures features, TypeModel model, ref ProtoWriter.State state, object value);

		protected abstract bool TryDeepClone(TypeModel model, ref object value);

		protected abstract bool IsKnownType(TypeModel model, CompatibilityLevel ambient);

		protected abstract bool CanSerialize(TypeModel model, out SerializerFeatures features);

		internal static bool IsTypeEquivalent(Type expected, Type actual)
		{
			if ((object)expected != actual)
			{
				return Get(expected) == Get(actual);
			}
			return true;
		}

		internal static Type GetEffectiveType(Type type)
		{
			object obj;
			if ((object)type != null)
			{
				obj = Get(type).GetEffectiveType();
				if (obj == null)
				{
					return type;
				}
			}
			else
			{
				obj = null;
			}
			return (Type)obj;
		}

		protected abstract Type GetEffectiveType();
	}
}
