using System;
using System.Buffers;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal static class RepeatedSerializers
	{
		[StructLayout(LayoutKind.Auto)]
		private readonly struct MethodTuple
		{
			public string Name => Method.Name;

			private MethodInfo Method { get; }

			public int GenericArgCount { get; }

			public MethodInfo Construct(Type[] targs)
			{
				if (GenericArgCount != 0)
				{
					return Method.MakeGenericMethod(targs);
				}
				return Method;
			}

			public MethodTuple(MethodInfo method)
			{
				Method = method;
				GenericArgCount = (method.IsGenericMethodDefinition ? method.GetGenericArguments().Length : 0);
			}
		}

		private sealed class Registration
		{
			public bool ExactOnly { get; }

			public int Priority { get; }

			private Func<Type, Type, Type[], MemberInfo> Implementation { get; }

			public MemberInfo Resolve(Type root, Type current)
			{
				Type[] arg = (current.IsGenericType ? current.GetGenericArguments() : ((!current.IsArray) ? Type.EmptyTypes : new Type[1] { current.GetElementType() }));
				return Implementation?.Invoke(root, current, arg);
			}

			public Registration(int priority, Func<Type, Type, Type[], MemberInfo> implementation, bool exactOnly)
			{
				Priority = priority;
				Implementation = implementation;
				ExactOnly = exactOnly;
			}
		}

		private static readonly Hashtable s_providers;

		private static readonly Hashtable s_methodsPerDeclaringType;

		private static readonly Hashtable s_knownTypes;

		private static readonly Registration s_Array;

		private static readonly Type[] NotSupportedFlavors;

		private static readonly MethodInfo s_NestedNotSupported;

		private static readonly MethodInfo s_GeneralNotSupported;

		private static MemberInfo Resolve(Type declaringType, string methodName, Type[] targs)
		{
			if (targs == null)
			{
				targs = Type.EmptyTypes;
			}
			MethodTuple[] array = (MethodTuple[])s_methodsPerDeclaringType[declaringType];
			if (array == null)
			{
				MethodInfo[] methods = declaringType.GetMethods(BindingFlags.Static | BindingFlags.Public);
				array = Array.ConvertAll(methods, (MethodInfo m) => new MethodTuple(m));
				lock (s_methodsPerDeclaringType)
				{
					s_methodsPerDeclaringType[declaringType] = array;
				}
			}
			MethodTuple[] array2 = array;
			for (int num = 0; num < array2.Length; num++)
			{
				MethodTuple methodTuple = array2[num];
				if (methodTuple.Name == methodName && targs.Length == methodTuple.GenericArgCount)
				{
					return methodTuple.Construct(targs);
				}
			}
			return null;
		}

		static RepeatedSerializers()
		{
			s_methodsPerDeclaringType = new Hashtable();
			s_knownTypes = new Hashtable();
			s_Array = new Registration(0, (Type root, Type current, Type[] targs) => (!(root == current)) ? null : Resolve(typeof(RepeatedSerializer), "CreateVector", targs), exactOnly: true);
			NotSupportedFlavors = new Type[7]
			{
				typeof(ArraySegment<>),
				typeof(Span<>),
				typeof(ReadOnlySpan<>),
				typeof(Memory<>),
				typeof(ReadOnlyMemory<>),
				typeof(ReadOnlySequence<>),
				typeof(IMemoryOwner<>)
			};
			s_NestedNotSupported = typeof(RepeatedSerializer).GetMethod("CreateNestedDataNotSupported");
			s_GeneralNotSupported = typeof(RepeatedSerializer).GetMethod("CreateNotSupported");
			s_providers = new Hashtable();
			Add(typeof(List<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateList", (root == current) ? targs : new Type[2]
			{
				root,
				targs[0]
			}), exactOnly: false);
			Add(typeof(ImmutableArray<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableArray", targs));
			Add(typeof(ImmutableDictionary<, >), (Type root, Type current, Type[] targs) => Resolve(typeof(MapSerializer), "CreateImmutableDictionary", targs));
			Add(typeof(ImmutableSortedDictionary<, >), (Type root, Type current, Type[] targs) => Resolve(typeof(MapSerializer), "CreateImmutableSortedDictionary", targs));
			Add(typeof(IImmutableDictionary<, >), (Type root, Type current, Type[] targs) => Resolve(typeof(MapSerializer), "CreateIImmutableDictionary", targs));
			Add(typeof(ImmutableList<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableList", targs));
			Add(typeof(IImmutableList<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableIList", targs));
			Add(typeof(ImmutableHashSet<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableHashSet", targs));
			Add(typeof(ImmutableSortedSet<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableSortedSet", targs));
			Add(typeof(IImmutableSet<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableISet", targs));
			Add(typeof(ImmutableQueue<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableQueue", targs));
			Add(typeof(IImmutableQueue<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableIQueue", targs));
			Add(typeof(ImmutableStack<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableStack", targs));
			Add(typeof(IImmutableStack<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateImmutableIStack", targs));
			Add(typeof(ConcurrentDictionary<, >), (Type root, Type current, Type[] targs) => Resolve(typeof(MapSerializer), "CreateConcurrentDictionary", new Type[3]
			{
				root,
				targs[0],
				targs[1]
			}), exactOnly: false);
			Add(typeof(ConcurrentBag<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateConcurrentBag", new Type[2]
			{
				root,
				targs[0]
			}), exactOnly: false);
			Add(typeof(ConcurrentQueue<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateConcurrentQueue", new Type[2]
			{
				root,
				targs[0]
			}), exactOnly: false);
			Add(typeof(ConcurrentStack<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateConcurrentStack", new Type[2]
			{
				root,
				targs[0]
			}), exactOnly: false);
			Add(typeof(IProducerConsumerCollection<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateIProducerConsumerCollection", new Type[2]
			{
				root,
				targs[0]
			}), exactOnly: false);
			Add(typeof(Dictionary<, >), (Type root, Type current, Type[] targs) => Resolve(typeof(MapSerializer), "CreateDictionary", (root == current) ? targs : new Type[3]
			{
				root,
				targs[0],
				targs[1]
			}), exactOnly: false);
			Add(typeof(IDictionary<, >), (Type root, Type current, Type[] targs) => Resolve(typeof(MapSerializer), "CreateDictionary", new Type[3]
			{
				root,
				targs[0],
				targs[1]
			}), exactOnly: false);
			Add(typeof(Queue<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateQueue", new Type[2]
			{
				root,
				targs[0]
			}), exactOnly: false);
			Add(typeof(Stack<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateStack", new Type[2]
			{
				root,
				targs[0]
			}), exactOnly: false);
			Add(typeof(IEnumerable<>), (Type root, Type current, Type[] targs) => Resolve(typeof(RepeatedSerializer), "CreateEnumerable", new Type[2]
			{
				root,
				targs[0]
			}), exactOnly: false);
		}

		public static void Add(Type type, Func<Type, Type, Type[], MemberInfo> implementation, bool exactOnly = true)
		{
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException("type");
			}
			lock (s_providers)
			{
				Registration value = new Registration(s_providers.Count + 1, implementation, exactOnly);
				s_providers.Add(type, value);
			}
			lock (s_knownTypes)
			{
				s_knownTypes.Clear();
			}
		}

		internal static RepeatedSerializerStub TryGetRepeatedProvider(Type type)
		{
			if ((object)type == null || type == typeof(string))
			{
				return null;
			}
			RepeatedSerializerStub repeatedSerializerStub = (RepeatedSerializerStub)s_knownTypes[type];
			if (repeatedSerializerStub == null)
			{
				Type genericTypeDefinition;
				if (type.IsGenericType && Array.IndexOf(NotSupportedFlavors, genericTypeDefinition = type.GetGenericTypeDefinition()) >= 0)
				{
					if (genericTypeDefinition == typeof(Span<>) || genericTypeDefinition == typeof(ReadOnlySpan<>))
					{
						throw new NotSupportedException("Serialization cannot work with [ReadOnly]Span<T>; [ReadOnly]Memory<T> may be enabled later");
					}
					repeatedSerializerStub = NotSupported(s_GeneralNotSupported, type, type.GetGenericArguments()[0]);
				}
				else
				{
					MemberInfo providerForType = GetProviderForType(type);
					if ((object)providerForType == null)
					{
						repeatedSerializerStub = ((!type.IsArray || !(type != typeof(byte[]))) ? RepeatedSerializerStub.Empty : NotSupported(s_GeneralNotSupported, type, type.GetElementType()));
					}
					else
					{
						repeatedSerializerStub = RepeatedSerializerStub.Create(type, providerForType);
						if (TestIfNestedNotSupported(repeatedSerializerStub))
						{
							repeatedSerializerStub = NotSupported(s_NestedNotSupported, repeatedSerializerStub.ForType, repeatedSerializerStub.ItemType);
						}
					}
				}
				lock (s_knownTypes)
				{
					s_knownTypes[type] = repeatedSerializerStub;
				}
			}
			if (!repeatedSerializerStub.IsEmpty)
			{
				return repeatedSerializerStub;
			}
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static RepeatedSerializerStub NotSupported(MethodInfo kind, Type collectionType, Type itemType)
		{
			return RepeatedSerializerStub.Create(collectionType, kind.MakeGenericMethod(collectionType, itemType));
		}

		private static bool TestIfNestedNotSupported(RepeatedSerializerStub repeated)
		{
			if ((object)repeated?.ItemType == null)
			{
				return false;
			}
			if (!repeated.IsMap && (repeated.ItemType == repeated.ForType || TryGetRepeatedProvider(repeated.ItemType) != null))
			{
				return true;
			}
			return false;
		}

		private static MemberInfo GetProviderForType(Type type)
		{
			if ((object)type == null)
			{
				return null;
			}
			if (type.IsArray)
			{
				if (type == typeof(byte[]))
				{
					return null;
				}
				Type type2 = type.GetElementType().MakeArrayType();
				if (!(type2 == type))
				{
					return null;
				}
				return s_Array.Resolve(type, type2);
			}
			MemberInfo bestMatch = null;
			int bestMatchPriority = int.MaxValue;
			bool bestIsAmbiguous = false;
			Type type3 = type;
			while ((object)type3 != null && type3 != typeof(object))
			{
				if (TryGetProvider(type, type3, bestMatchPriority, out var member, out var priority))
				{
					Consider(member, priority);
				}
				type3 = type3.BaseType;
			}
			Type[] interfaces = type.GetInterfaces();
			foreach (Type current in interfaces)
			{
				if (TryGetProvider(type, current, bestMatchPriority, out var member2, out var priority2))
				{
					Consider(member2, priority2);
				}
			}
			if (!bestIsAmbiguous)
			{
				return bestMatch;
			}
			return null;
			void Consider(MemberInfo memberInfo, int num)
			{
				if (num < bestMatchPriority)
				{
					bestMatch = memberInfo;
					bestMatchPriority = num;
					bestIsAmbiguous = false;
				}
				else if (num == bestMatchPriority && !object.Equals(bestMatch, memberInfo))
				{
					bestIsAmbiguous = true;
				}
			}
		}

		private static bool TryGetProvider(Type root, Type current, int bestMatchPriority, out MemberInfo member, out int priority)
		{
			Registration registration = (Registration)s_providers[current];
			if (registration == null && current.IsGenericType)
			{
				registration = (Registration)s_providers[current.GetGenericTypeDefinition()];
			}
			if (registration == null || registration.Priority > bestMatchPriority || (registration.ExactOnly && root != current))
			{
				member = null;
				priority = 0;
				return false;
			}
			member = registration.Resolve(root, current);
			priority = registration.Priority;
			return true;
		}
	}
}
