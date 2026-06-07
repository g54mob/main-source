using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices
{
	public static class Helper
	{
		internal class Allocation
		{
			public int Size { get; private set; }

			public object CachedData { get; private set; }

			public bool? IsCachedArrayElementAllocated { get; private set; }

			public Allocation(int size)
			{
			}

			public void SetCachedData(object data, bool? isCachedArrayElementAllocated = null)
			{
			}
		}

		private class DelegateHolder
		{
			public Delegate Public { get; private set; }

			public Delegate Private { get; private set; }

			public Delegate[] StructDelegates { get; private set; }

			public ulong? NotificationId { get; set; }

			public DelegateHolder(Delegate publicDelegate, Delegate privateDelegate, params Delegate[] structDelegates)
			{
			}
		}

		private static Dictionary<IntPtr, Allocation> s_Allocations;

		private static Dictionary<IntPtr, DelegateHolder> s_Callbacks;

		private static Dictionary<string, DelegateHolder> s_StaticCallbacks;

		public static int GetAllocationCount()
		{
			return 0;
		}

		public static bool IsOperationComplete(Result result)
		{
			return false;
		}

		[PreserveSig]
		private static extern int EOS_EResult_IsOperationComplete(Result result);

		public static string ToHexString(byte[] byteArray)
		{
			return null;
		}

		internal static bool TryMarshalGet<T>(T[] source, out uint target)
		{
			target = default(uint);
			return false;
		}

		internal static bool TryMarshalGet<T>(IntPtr source, out T target) where T : Handle, new()
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<TSource, TTarget>(TSource source, out TTarget target) where TTarget : ISettable, new()
		{
			target = default(TTarget);
			return false;
		}

		internal static bool TryMarshalGet(int source, out bool target)
		{
			target = default(bool);
			return false;
		}

		internal static bool TryMarshalGet(long source, out DateTimeOffset? target)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<T>(IntPtr source, out T[] target, int arrayLength, bool isElementAllocated)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<T>(IntPtr source, out T[] target, uint arrayLength, bool isElementAllocated)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<T>(IntPtr source, out T[] target, int arrayLength)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<T>(IntPtr source, out T[] target, uint arrayLength)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<TSource, TTarget>(TSource[] source, out TTarget[] target) where TSource : struct where TTarget : class, ISettable, new()
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<TSource, TTarget>(IntPtr source, out TTarget[] target, int arrayLength) where TSource : struct where TTarget : class, ISettable, new()
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<TSource, TTarget>(IntPtr source, out TTarget[] target, uint arrayLength) where TSource : struct where TTarget : class, ISettable, new()
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<T>(IntPtr source, out T? target) where T : struct
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet(byte[] source, out string target)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet(IntPtr source, out object target)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet(IntPtr source, out string target)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<T, TEnum>(T source, out T target, TEnum currentEnum, TEnum comparisonEnum)
		{
			target = default(T);
			return false;
		}

		internal static bool TryMarshalGet<TTarget, TEnum>(ISettable source, out TTarget target, TEnum currentEnum, TEnum comparisonEnum) where TTarget : ISettable, new()
		{
			target = default(TTarget);
			return false;
		}

		internal static bool TryMarshalGet<TEnum>(int source, out bool? target, TEnum currentEnum, TEnum comparisonEnum)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<T, TEnum>(T source, out T? target, TEnum currentEnum, TEnum comparisonEnum) where T : struct
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<T, TEnum>(IntPtr source, out T target, TEnum currentEnum, TEnum comparisonEnum) where T : Handle, new()
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<TEnum>(IntPtr source, out IntPtr? target, TEnum currentEnum, TEnum comparisonEnum)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<TEnum>(IntPtr source, out string target, TEnum currentEnum, TEnum comparisonEnum)
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<TInternal, TPublic>(IntPtr source, out TPublic target) where TInternal : struct where TPublic : class, ISettable, new()
		{
			target = null;
			return false;
		}

		internal static bool TryMarshalGet<TCallbackInfoInternal, TCallbackInfo>(IntPtr callbackInfoAddress, out TCallbackInfo callbackInfo, out IntPtr clientDataAddress) where TCallbackInfoInternal : struct, ICallbackInfoInternal where TCallbackInfo : class, ISettable, new()
		{
			callbackInfo = null;
			clientDataAddress = default(IntPtr);
			return false;
		}

		internal static bool TryMarshalSet<T>(ref T target, T source)
		{
			return false;
		}

		internal static bool TryMarshalSet<TTarget>(ref TTarget target, object source) where TTarget : ISettable, new()
		{
			return false;
		}

		internal static bool TryMarshalSet(ref IntPtr target, Handle source)
		{
			return false;
		}

		internal static bool TryMarshalSet<T>(ref IntPtr target, T? source) where T : struct
		{
			return false;
		}

		internal static bool TryMarshalSet<T>(ref IntPtr target, T[] source, bool isElementAllocated)
		{
			return false;
		}

		internal static bool TryMarshalSet<T>(ref IntPtr target, T[] source)
		{
			return false;
		}

		internal static bool TryMarshalSet<T>(ref IntPtr target, T[] source, out int arrayLength, bool isElementAllocated)
		{
			arrayLength = default(int);
			return false;
		}

		internal static bool TryMarshalSet<T>(ref IntPtr target, T[] source, out uint arrayLength, bool isElementAllocated)
		{
			arrayLength = default(uint);
			return false;
		}

		internal static bool TryMarshalSet<T>(ref IntPtr target, T[] source, out uint arrayLength)
		{
			arrayLength = default(uint);
			return false;
		}

		internal static bool TryMarshalSet(ref long target, DateTimeOffset? source)
		{
			return false;
		}

		internal static bool TryMarshalSet(ref int target, bool source)
		{
			return false;
		}

		internal static bool TryMarshalSet(ref byte[] target, string source, int length)
		{
			return false;
		}

		internal static bool TryMarshalSet(ref IntPtr target, string source)
		{
			return false;
		}

		internal static bool TryMarshalSet<T, TEnum>(ref T target, T source, ref TEnum currentEnum, TEnum comparisonEnum, IDisposable disposable = null)
		{
			return false;
		}

		internal static bool TryMarshalSet<TTarget, TEnum>(ref TTarget target, ISettable source, ref TEnum currentEnum, TEnum comparisonEnum, IDisposable disposable = null) where TTarget : ISettable, new()
		{
			return false;
		}

		internal static bool TryMarshalSet<T, TEnum>(ref T target, T? source, ref TEnum currentEnum, TEnum comparisonEnum, IDisposable disposable = null) where T : struct
		{
			return false;
		}

		internal static bool TryMarshalSet<TEnum>(ref IntPtr target, Handle source, ref TEnum currentEnum, TEnum comparisonEnum, IDisposable disposable = null)
		{
			return false;
		}

		internal static bool TryMarshalSet<TEnum>(ref IntPtr target, string source, ref TEnum currentEnum, TEnum comparisonEnum, IDisposable disposable = null)
		{
			return false;
		}

		internal static bool TryMarshalSet<TEnum>(ref int target, bool? source, ref TEnum currentEnum, TEnum comparisonEnum, IDisposable disposable = null)
		{
			return false;
		}

		internal static bool TryMarshalSet<TInternal, TPublic>(ref IntPtr target, TPublic source) where TInternal : struct, ISettable where TPublic : class
		{
			return false;
		}

		internal static bool TryMarshalSet<TInternal, TPublic>(ref IntPtr target, TPublic[] source, out int arrayLength) where TInternal : struct, ISettable where TPublic : class
		{
			arrayLength = default(int);
			return false;
		}

		internal static bool TryMarshalSet<TInternal, TPublic>(ref IntPtr target, TPublic[] source, out uint arrayLength) where TInternal : struct, ISettable where TPublic : class
		{
			arrayLength = default(uint);
			return false;
		}

		internal static bool TryMarshalSet<TInternal, TPublic>(ref IntPtr target, TPublic[] source, out int arrayLength, bool isElementAllocated) where TInternal : struct, ISettable where TPublic : class
		{
			arrayLength = default(int);
			return false;
		}

		internal static bool TryMarshalSet<TInternal, TPublic>(ref IntPtr target, TPublic[] source, out uint arrayLength, bool isElementAllocated) where TInternal : struct, ISettable where TPublic : class
		{
			arrayLength = default(uint);
			return false;
		}

		internal static bool TryMarshalCopy(IntPtr target, byte[] source)
		{
			return false;
		}

		internal static bool TryMarshalAllocate(ref IntPtr target, int size, out Allocation allocation)
		{
			allocation = null;
			return false;
		}

		internal static bool TryMarshalAllocate(ref IntPtr target, uint size, out Allocation allocation)
		{
			allocation = null;
			return false;
		}

		internal static bool TryMarshalDispose<TDisposable>(ref TDisposable disposable) where TDisposable : IDisposable
		{
			return false;
		}

		internal static bool TryMarshalDispose(ref IntPtr value)
		{
			return false;
		}

		internal static bool TryMarshalDispose<TEnum>(ref IntPtr member, TEnum currentEnum, TEnum comparisonEnum)
		{
			return false;
		}

		internal static T GetDefault<T>()
		{
			return default(T);
		}

		internal static void AddCallback(ref IntPtr clientDataAddress, object clientData, Delegate publicDelegate, Delegate privateDelegate, params Delegate[] structDelegates)
		{
		}

		internal static void AddStaticCallback(string key, Delegate publicDelegate, Delegate privateDelegate)
		{
		}

		internal static bool TryAssignNotificationIdToCallback(IntPtr clientDataAddress, ulong notificationId)
		{
			return false;
		}

		internal static bool TryRemoveCallbackByNotificationId(ulong notificationId)
		{
			return false;
		}

		internal static bool TryGetAndRemoveCallback<TCallback, TCallbackInfoInternal, TCallbackInfo>(IntPtr callbackInfoAddress, out TCallback callback, out TCallbackInfo callbackInfo) where TCallback : class where TCallbackInfoInternal : struct, ICallbackInfoInternal where TCallbackInfo : class, ICallbackInfo, ISettable, new()
		{
			callback = null;
			callbackInfo = null;
			return false;
		}

		internal static bool TryGetStructCallback<TDelegate, TCallbackInfoInternal, TCallbackInfo>(IntPtr callbackInfoAddress, out TDelegate callback, out TCallbackInfo callbackInfo) where TDelegate : class where TCallbackInfoInternal : struct, ICallbackInfoInternal where TCallbackInfo : class, ISettable, new()
		{
			callback = null;
			callbackInfo = null;
			return false;
		}

		private static bool TryAllocate<T>(ref IntPtr target, T source)
		{
			return false;
		}

		private static bool TryAllocate<T>(ref IntPtr target, T? source) where T : struct
		{
			return false;
		}

		private static bool TryAllocate(ref IntPtr target, string source)
		{
			return false;
		}

		private static bool TryAllocate<T>(ref IntPtr target, T[] source, bool isElementAllocated)
		{
			return false;
		}

		private static bool TryAllocateCacheOnly<T>(ref IntPtr target, T source)
		{
			return false;
		}

		private static bool TryRelease(ref IntPtr target)
		{
			return false;
		}

		private static bool TryFetch<T>(IntPtr source, out T target)
		{
			target = default(T);
			return false;
		}

		private static bool TryFetch<T>(IntPtr source, out T? target) where T : struct
		{
			target = null;
			return false;
		}

		private static bool TryFetch<T>(IntPtr source, out T[] target, int arrayLength, bool isElementAllocated)
		{
			target = null;
			return false;
		}

		private static bool TryFetch(IntPtr source, out string target)
		{
			target = null;
			return false;
		}

		private static bool TryConvert<THandle>(IntPtr source, out THandle target) where THandle : Handle, new()
		{
			target = null;
			return false;
		}

		internal static bool TryConvert<TSource, TTarget>(TSource source, out TTarget target) where TTarget : ISettable, new()
		{
			target = default(TTarget);
			return false;
		}

		private static bool TryConvert(Handle source, out IntPtr target)
		{
			target = default(IntPtr);
			return false;
		}

		private static bool TryConvert(byte[] source, out string target)
		{
			target = null;
			return false;
		}

		private static bool TryConvert(string source, out byte[] target, int length)
		{
			target = null;
			return false;
		}

		private static bool TryConvert(string source, out byte[] target)
		{
			target = null;
			return false;
		}

		private static bool TryConvert<T>(T[] source, out int target)
		{
			target = default(int);
			return false;
		}

		private static bool TryConvert<T>(T[] source, out uint target)
		{
			target = default(uint);
			return false;
		}

		internal static bool TryConvert<TSource, TTarget>(TSource[] source, out TTarget[] target) where TTarget : ISettable, new()
		{
			target = null;
			return false;
		}

		private static bool TryConvert(int source, out bool target)
		{
			target = default(bool);
			return false;
		}

		private static bool TryConvert(bool source, out int target)
		{
			target = default(int);
			return false;
		}

		private static bool TryConvert(DateTimeOffset? source, out long target)
		{
			target = default(long);
			return false;
		}

		private static bool TryConvert(long source, out DateTimeOffset? target)
		{
			target = null;
			return false;
		}

		private static bool CanRemoveCallback<TCallbackInfo>(IntPtr clientDataAddress, TCallbackInfo callbackInfo) where TCallbackInfo : ICallbackInfo
		{
			return false;
		}

		private static bool TryGetAndRemoveCallback<TCallback, TCallbackInfo>(IntPtr clientDataAddress, TCallbackInfo callbackInfo, out TCallback callback) where TCallback : class where TCallbackInfo : ICallbackInfo
		{
			callback = null;
			return false;
		}

		internal static bool TryGetStaticCallback<TCallback>(string key, out TCallback callback) where TCallback : class
		{
			callback = null;
			return false;
		}

		private static bool TryGetStructCallback<TCallback>(IntPtr clientDataAddress, out TCallback structCallback) where TCallback : class
		{
			structCallback = null;
			return false;
		}
	}
}
