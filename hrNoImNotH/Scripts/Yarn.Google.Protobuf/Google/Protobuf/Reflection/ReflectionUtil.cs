using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Google.Protobuf.Reflection
{
	internal static class ReflectionUtil
	{
		private interface IReflectionHelper
		{
			Func<IMessage, int> CreateFuncIMessageInt32(MethodInfo method);

			Action<IMessage> CreateActionIMessage(MethodInfo method);

			Func<IMessage, object> CreateFuncIMessageObject(MethodInfo method);

			Action<IMessage, object> CreateActionIMessageObject(MethodInfo method);

			Func<IMessage, bool> CreateFuncIMessageBool(MethodInfo method);
		}

		internal interface IExtensionReflectionHelper
		{
			object GetExtension(IMessage message);

			void SetExtension(IMessage message, object value);

			bool HasExtension(IMessage message);

			void ClearExtension(IMessage message);
		}

		private interface IExtensionSetReflector
		{
			Func<IMessage, bool> CreateIsInitializedCaller();
		}

		private sealed class ReflectionHelper<T1, T2> : IReflectionHelper
		{
			public Func<IMessage, int> CreateFuncIMessageInt32(MethodInfo method)
			{
				return null;
			}

			public Action<IMessage> CreateActionIMessage(MethodInfo method)
			{
				return null;
			}

			public Func<IMessage, object> CreateFuncIMessageObject(MethodInfo method)
			{
				return null;
			}

			public Action<IMessage, object> CreateActionIMessageObject(MethodInfo method)
			{
				return null;
			}

			public Func<IMessage, bool> CreateFuncIMessageBool(MethodInfo method)
			{
				return null;
			}
		}

		private sealed class ExtensionReflectionHelper<T1, T3> : IExtensionReflectionHelper where T1 : IExtendableMessage<T1>
		{
			private readonly Extension extension;

			public ExtensionReflectionHelper(Extension extension)
			{
			}

			public object GetExtension(IMessage message)
			{
				return null;
			}

			public bool HasExtension(IMessage message)
			{
				return false;
			}

			public void SetExtension(IMessage message, object value)
			{
			}

			public void ClearExtension(IMessage message)
			{
			}
		}

		private sealed class ExtensionSetReflector<T1> : IExtensionSetReflector where T1 : IExtendableMessage<T1>
		{
			public Func<IMessage, bool> CreateIsInitializedCaller()
			{
				return null;
			}
		}

		public enum SampleEnum
		{
			X = 0
		}

		internal static readonly Type[] EmptyTypes;

		private static bool CanConvertEnumFuncToInt32Func { get; }

		static ReflectionUtil()
		{
		}

		internal static void ForceInitialize<T>()
		{
		}

		internal static Func<IMessage, object> CreateFuncIMessageObject(MethodInfo method)
		{
			return null;
		}

		internal static Func<IMessage, int> CreateFuncIMessageInt32(MethodInfo method)
		{
			return null;
		}

		internal static Action<IMessage, object> CreateActionIMessageObject(MethodInfo method)
		{
			return null;
		}

		internal static Action<IMessage> CreateActionIMessage(MethodInfo method)
		{
			return null;
		}

		internal static Func<IMessage, bool> CreateFuncIMessageBool(MethodInfo method)
		{
			return null;
		}

		[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Type parameter members are preserved with DynamicallyAccessedMembers on GeneratedClrTypeInfo.ctor clrType parameter.")]
		[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "Type definition is explicitly specified and type argument is always a message type.")]
		internal static Func<IMessage, bool> CreateIsInitializedCaller([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type msg)
		{
			return null;
		}

		[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Type parameter members are preserved with DynamicallyAccessedMembers on GeneratedClrTypeInfo.ctor clrType parameter.")]
		internal static IExtensionReflectionHelper CreateExtensionHelper(Extension extension)
		{
			return null;
		}

		[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Type parameter members are preserved with DynamicallyAccessedMembers on GeneratedClrTypeInfo.ctor clrType parameter.")]
		private static IReflectionHelper GetReflectionHelper(Type t1, Type t2)
		{
			return null;
		}

		private static bool CheckCanConvertEnumFuncToInt32Func()
		{
			return false;
		}

		public static SampleEnum SampleEnumMethod()
		{
			return default(SampleEnum);
		}
	}
}
