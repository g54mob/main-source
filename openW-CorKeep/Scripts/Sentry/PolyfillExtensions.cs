using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

[EditorBrowsable(EditorBrowsableState.Never)]
[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
internal static class PolyfillExtensions
{
	private static ConcurrentDictionary<ParameterInfo, NullabilityInfo> parameterCache = new ConcurrentDictionary<ParameterInfo, NullabilityInfo>();

	private static ConcurrentDictionary<PropertyInfo, NullabilityInfo> propertyCache = new ConcurrentDictionary<PropertyInfo, NullabilityInfo>();

	private static ConcurrentDictionary<EventInfo, NullabilityInfo> eventCache = new ConcurrentDictionary<EventInfo, NullabilityInfo>();

	private static ConcurrentDictionary<FieldInfo, NullabilityInfo> fieldCache = new ConcurrentDictionary<FieldInfo, NullabilityInfo>();

	private const long TicksPerMicrosecond = 10000000L;

	public static NullabilityInfo GetNullabilityInfo(this MemberInfo info)
	{
		if (info is PropertyInfo info2)
		{
			return info2.GetNullabilityInfo();
		}
		if (info is EventInfo info3)
		{
			return info3.GetNullabilityInfo();
		}
		if (info is FieldInfo info4)
		{
			return info4.GetNullabilityInfo();
		}
		throw new ArgumentException("Unsupported type:" + info.GetType().FullName);
	}

	public static NullabilityState GetNullability(this MemberInfo info)
	{
		return GetReadOrWriteState(info.GetNullabilityInfo());
	}

	public static bool IsNullable(this MemberInfo info)
	{
		NullabilityInfo nullabilityInfo = info.GetNullabilityInfo();
		return IsNullable(info.Name, nullabilityInfo);
	}

	public static NullabilityInfo GetNullabilityInfo(this FieldInfo info)
	{
		return fieldCache.GetOrAdd(info, (FieldInfo inner) => new NullabilityInfoContext().Create(inner));
	}

	public static NullabilityState GetNullability(this FieldInfo info)
	{
		return GetReadOrWriteState(info.GetNullabilityInfo());
	}

	public static bool IsNullable(this FieldInfo info)
	{
		NullabilityInfo nullabilityInfo = info.GetNullabilityInfo();
		return IsNullable(info.Name, nullabilityInfo);
	}

	public static NullabilityInfo GetNullabilityInfo(this EventInfo info)
	{
		return eventCache.GetOrAdd(info, (EventInfo inner) => new NullabilityInfoContext().Create(inner));
	}

	public static NullabilityState GetNullability(this EventInfo info)
	{
		return GetReadOrWriteState(info.GetNullabilityInfo());
	}

	public static bool IsNullable(this EventInfo info)
	{
		NullabilityInfo nullabilityInfo = info.GetNullabilityInfo();
		return IsNullable(info.Name, nullabilityInfo);
	}

	public static NullabilityInfo GetNullabilityInfo(this PropertyInfo info)
	{
		return propertyCache.GetOrAdd(info, (PropertyInfo inner) => new NullabilityInfoContext().Create(inner));
	}

	public static NullabilityState GetNullability(this PropertyInfo info)
	{
		return GetReadOrWriteState(info.GetNullabilityInfo());
	}

	public static bool IsNullable(this PropertyInfo info)
	{
		NullabilityInfo nullabilityInfo = info.GetNullabilityInfo();
		return IsNullable(info.Name, nullabilityInfo);
	}

	public static NullabilityInfo GetNullabilityInfo(this ParameterInfo info)
	{
		return parameterCache.GetOrAdd(info, (ParameterInfo inner) => new NullabilityInfoContext().Create(inner));
	}

	public static NullabilityState GetNullability(this ParameterInfo info)
	{
		return GetReadOrWriteState(info.GetNullabilityInfo());
	}

	public static bool IsNullable(this ParameterInfo info)
	{
		NullabilityInfo nullabilityInfo = info.GetNullabilityInfo();
		return IsNullable(info.Name, nullabilityInfo);
	}

	private static NullabilityState GetReadOrWriteState(NullabilityInfo nullability)
	{
		if (nullability.ReadState == NullabilityState.Unknown)
		{
			return nullability.WriteState;
		}
		return nullability.ReadState;
	}

	private static NullabilityState GetKnownState(string name, NullabilityInfo nullability)
	{
		NullabilityState readState = nullability.ReadState;
		if (readState != NullabilityState.Unknown)
		{
			return readState;
		}
		NullabilityState writeState = nullability.WriteState;
		if (writeState != NullabilityState.Unknown)
		{
			return writeState;
		}
		throw new Exception("The nullability of '" + nullability.Type.FullName + "." + name + "' is unknown. Assembly: " + nullability.Type.Assembly.FullName + ".");
	}

	private static bool IsNullable(string name, NullabilityInfo nullability)
	{
		return GetKnownState(name, nullability) == NullabilityState.Nullable;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtokensource.cancelasync")]
	public static Task CancelAsync(this CancellationTokenSource target)
	{
		target.Cancel();
		return Task.CompletedTask;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstreamasync#system-net-http-httpclient-getstreamasync(system-string-system-threading-cancellationtoken)")]
	public static async Task<Stream> GetStreamAsync(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken = default(CancellationToken))
	{
		_ = 1;
		try
		{
			HttpResponseMessage obj = await httpClient.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			obj.EnsureSuccessStatusCode();
			return await obj.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (OperationCanceledException ex) when (ex.CancellationToken != cancellationToken && cancellationToken.IsCancellationRequested)
		{
			throw new OperationCanceledException(ex.Message, ex.InnerException, cancellationToken);
		}
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstreamasync#system-net-http-httpclient-getstreamasync(system-uri-system-threading-cancellationtoken)")]
	public static Task<Stream> GetStreamAsync(this HttpClient httpClient, Uri requestUri, CancellationToken cancellationToken = default(CancellationToken))
	{
		return httpClient.GetStreamAsync(requestUri.ToString(), cancellationToken);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getbytearrayasync#system-net-http-httpclient-getbytearrayasync(system-string-system-threading-cancellationtoken)")]
	public static async Task<byte[]> GetByteArrayAsync(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken = default(CancellationToken))
	{
		_ = 1;
		try
		{
			using HttpResponseMessage response = await httpClient.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (OperationCanceledException ex) when (ex.CancellationToken != cancellationToken && cancellationToken.IsCancellationRequested)
		{
			throw new OperationCanceledException(ex.Message, ex.InnerException, cancellationToken);
		}
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getbytearrayasync#system-net-http-httpclient-getbytearrayasync(system-uri-system-threading-cancellationtoken)")]
	public static Task<byte[]> GetByteArrayAsync(this HttpClient httpClient, Uri requestUri, CancellationToken cancellationToken = default(CancellationToken))
	{
		return httpClient.GetByteArrayAsync(requestUri.ToString(), cancellationToken);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstringasync#system-net-http-httpclient-getstringasync(system-string-system-threading-cancellationtoken)")]
	public static async Task<string> GetStringAsync(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken = default(CancellationToken))
	{
		_ = 1;
		try
		{
			using HttpResponseMessage response = await httpClient.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (OperationCanceledException ex) when (ex.CancellationToken != cancellationToken && cancellationToken.IsCancellationRequested)
		{
			throw new OperationCanceledException(ex.Message, ex.InnerException, cancellationToken);
		}
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstringasync#system-net-http-httpclient-getstringasync(system-uri-system-threading-cancellationtoken)")]
	public static Task<string> GetStringAsync(this HttpClient httpClient, Uri requestUri, CancellationToken cancellationToken = default(CancellationToken))
	{
		return httpClient.GetStringAsync(requestUri.ToString(), cancellationToken);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent.readasstreamasync#system-net-http-httpcontent-readasstreamasync(system-threading-cancellationtoken)")]
	public static Task<Stream> ReadAsStreamAsync(this HttpContent httpContent, CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		return httpContent.ReadAsStreamAsync();
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent.readasbytearrayasync#system-net-http-httpcontent-readasbytearrayasync(system-threading-cancellationtoken)")]
	public static Task<byte[]> ReadAsByteArrayAsync(this HttpContent httpContent, CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		return httpContent.ReadAsByteArrayAsync();
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent.readasstringasync#system-net-http-httpcontent-readasstringasync(system-threading-cancellationtoken)")]
	public static Task<string> ReadAsStringAsync(this HttpContent httpContent, CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		return httpContent.ReadAsStringAsync();
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.maxby#system-linq-enumerable-maxby-2(system-collections-generic-ienumerable((-0))-system-func((-0-1)))")]
	public static TSource? MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return source.MaxBy(keySelector, null);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.maxby?view=net-8.0#system-linq-enumerable-maxby-2(system-collections-generic-ienumerable((-0))-system-func((-0-1))-system-collections-generic-icomparer((-1)))")]
	public static TSource? MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
	{
		return source.OrderByDescending(keySelector, comparer).FirstOrDefault();
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.minby#system-linq-enumerable-minby-2(system-collections-generic-ienumerable((-0))-system-func((-0-1)))")]
	public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return source.MinBy(keySelector, null);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.minby?view=net-8.0#system-linq-enumerable-minby-2(system-collections-generic-ienumerable((-0))-system-func((-0-1))-system-collections-generic-icomparer((-1)))")]
	public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
	{
		return source.OrderBy(keySelector, comparer).FirstOrDefault();
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.skiplast")]
	public static IEnumerable<TSource> SkipLast<TSource>(this IEnumerable<TSource> source, int count)
	{
		return source.Reverse().Skip(count).Reverse();
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.collectionextensions.getvalueordefault")]
	public static TValue? GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> target, TKey key)
	{
		if (target.TryGetValue(key, out TValue value))
		{
			return value;
		}
		return default(TValue);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.collectionextensions.getvalueordefault#system-collections-generic-collectionextensions-getvalueordefault-2(system-collections-generic-ireadonlydictionary((-0-1))-0-1)")]
	public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> target, TKey key, TValue defaultValue = default(TValue))
	{
		if (target.TryGetValue(key, out TValue value))
		{
			return value;
		}
		return defaultValue;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair-2.deconstruct")]
	public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> target, out TKey key, out TValue value)
	{
		key = target.Key;
		value = target.Value;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.contains#system-memoryextensions-contains-1(system-readonlyspan((-0))-0)")]
	public static bool Contains<T>(this ReadOnlySpan<T> target, T value) where T : IEquatable<T>
	{
		for (int i = 0; i < target.Length; i++)
		{
			if (target[i].Equals(value))
			{
				return true;
			}
		}
		return false;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.contains#system-memoryextensions-contains-1(system-span((-0))-0)")]
	public static bool Contains<T>(this Span<T> target, T value) where T : IEquatable<T>
	{
		for (int i = 0; i < target.Length; i++)
		{
			if (target[i].Equals(value))
			{
				return true;
			}
		}
		return false;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.sequenceequal#system-memoryextensions-sequenceequal-1(system-readonlyspan((-0))-system-readonlyspan((-0)))")]
	public static bool SequenceEqual(this ReadOnlySpan<char> target, string other)
	{
		return target.SequenceEqual(MemoryExtensions.AsSpan(other));
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.sequenceequal#system-memoryextensions-sequenceequal-1(system-span((-0))-system-readonlyspan((-0)))")]
	public static bool SequenceEqual(this Span<char> target, string other)
	{
		return target.SequenceEqual(MemoryExtensions.AsSpan(other));
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.startswith#system-memoryextensions-startswith-1(system-readonlyspan((-0))-system-readonlyspan((-0)))")]
	public static bool StartsWith(this ReadOnlySpan<char> target, string other, StringComparison comparison = StringComparison.CurrentCulture)
	{
		return target.StartsWith(MemoryExtensions.AsSpan(other), comparison);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.startswith#system-memoryextensions-startswith-1(system-span((-0))-system-readonlyspan((-0)))")]
	public static bool StartsWith(this Span<char> target, string other)
	{
		return target.StartsWith(MemoryExtensions.AsSpan(other));
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.endswith#system-memoryextensions-endswith-1(system-readonlyspan((-0))-system-readonlyspan((-0)))")]
	public static bool EndsWith(this ReadOnlySpan<char> target, string other, StringComparison comparison = StringComparison.CurrentCulture)
	{
		return target.EndsWith(MemoryExtensions.AsSpan(other), comparison);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.endswith#system-memoryextensions-endswith-1(system-span((-0))-system-readonlyspan((-0)))")]
	public static bool EndsWith(this Span<char> target, string other)
	{
		return target.EndsWith(MemoryExtensions.AsSpan(other));
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.timespan.nanoseconds")]
	public static int Nanoseconds(this TimeSpan target)
	{
		return (int)(target.TicksComponent() % 10000000) * 100;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.nanosecond")]
	public static int Nanosecond(this DateTime target)
	{
		return (int)(target.TicksComponent() % 10000000) * 100;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.nanosecond")]
	public static int Nanosecond(this DateTimeOffset target)
	{
		return (int)(target.TicksComponent() % 10000000) * 100;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.timespan.microseconds")]
	public static int Microseconds(this TimeSpan target)
	{
		return (int)(target.TicksComponent() % 10000000) * 1000;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.microsecond")]
	public static int Microsecond(this DateTime target)
	{
		return (int)(target.TicksComponent() % 10000000) * 1000;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.microsecond")]
	public static int Microsecond(this DateTimeOffset target)
	{
		return (int)(target.TicksComponent() % 10000000) * 1000;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.addmicroseconds")]
	public static DateTime AddMicroseconds(this DateTime target, double microseconds)
	{
		return target.AddMilliseconds(microseconds / 1000.0);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.addmicroseconds")]
	public static DateTimeOffset AddMicroseconds(this DateTimeOffset target, double microseconds)
	{
		return target.AddMilliseconds(microseconds / 1000.0);
	}

	private static long TicksComponent(this TimeSpan target)
	{
		TimeSpan timeSpan = new TimeSpan(target.Days, target.Hours, target.Minutes, 0);
		return (target - timeSpan).Ticks;
	}

	private static long TicksComponent(this DateTime target)
	{
		DateTime dateTime = new DateTime(target.Year, target.Month, target.Day, target.Hour, target.Minute, 0, target.Kind);
		return (target - dateTime).Ticks;
	}

	private static long TicksComponent(this DateTimeOffset target)
	{
		DateTimeOffset dateTimeOffset = new DateTimeOffset(target.Year, target.Month, target.Day, target.Hour, target.Minute, 0, target.Offset);
		return (target - dateTimeOffset).Ticks;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.readasync#system-io-stream-readasync(system-memory((system-byte))-system-threading-cancellationtoken)")]
	public static ValueTask<int> ReadAsync(this Stream target, Memory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!MemoryMarshal.TryGetArray((ReadOnlyMemory<byte>)buffer, out ArraySegment<byte> segment))
		{
			segment = new ArraySegment<byte>(buffer.ToArray());
		}
		return new ValueTask<int>(target.ReadAsync(segment.Array, segment.Offset, segment.Count, cancellationToken));
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.writeasync#system-io-stream-writeasync(system-readonlymemory((system-byte))-system-threading-cancellationtoken)")]
	public static ValueTask WriteAsync(this Stream target, ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!MemoryMarshal.TryGetArray(buffer, out var segment))
		{
			segment = new ArraySegment<byte>(buffer.ToArray());
		}
		return new ValueTask(target.WriteAsync(segment.Array, segment.Offset, segment.Count, cancellationToken));
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync#system-io-stream-copytoasync(system-io-stream-system-threading-cancellationtoken)")]
	public static Task CopyToAsync(this Stream target, Stream destination, CancellationToken cancellationToken = default(CancellationToken))
	{
		return target.CopyToAsync(destination, 81920, cancellationToken);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.string.copyto")]
	public static void CopyTo(this string target, Span<char> destination)
	{
		MemoryExtensions.AsSpan(target).CopyTo(destination);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.string.trycopyto")]
	public static bool TryCopyTo(this string target, Span<char> destination)
	{
		return MemoryExtensions.AsSpan(target).TryCopyTo(destination);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.string.gethashcode#system-string-gethashcode(system-stringcomparison)")]
	public static int GetHashCode(this string target, StringComparison comparisonType)
	{
		return FromComparison(comparisonType).GetHashCode(target);
	}

	private static StringComparer FromComparison(StringComparison comparison)
	{
		switch (comparison)
		{
		case StringComparison.CurrentCulture:
			return StringComparer.CurrentCulture;
		case StringComparison.CurrentCultureIgnoreCase:
			return StringComparer.CurrentCultureIgnoreCase;
		case StringComparison.InvariantCulture:
			return StringComparer.InvariantCulture;
		case StringComparison.InvariantCultureIgnoreCase:
			return StringComparer.InvariantCultureIgnoreCase;
		case StringComparison.Ordinal:
			return StringComparer.Ordinal;
		case StringComparison.OrdinalIgnoreCase:
			return StringComparer.OrdinalIgnoreCase;
		default:
		{
			global::_003CPrivateImplementationDetails_003E.ThrowInvalidOperationException();
			StringComparer result = default(StringComparer);
			return result;
		}
		}
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.string.contains#system-string-contains(system-string-system-stringcomparison)")]
	public static bool Contains(this string target, string value, StringComparison comparisonType)
	{
		return target.IndexOf(value, comparisonType) >= 0;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.string.contains#system-string-contains(system-char)")]
	public static bool StartsWith(this string target, char value)
	{
		if (target.Length == 0)
		{
			return false;
		}
		return target[0] == value;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.string.contains#system-string-contains(system-char)")]
	public static bool EndsWith(this string target, char value)
	{
		if (target.Length == 0)
		{
			return false;
		}
		int num = target.Length - 1;
		if (num < target.Length)
		{
			return target[num] == value;
		}
		return false;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.string.split#system-string-split(system-char-system-stringsplitoptions)")]
	public static string[] Split(this string target, char separator, StringSplitOptions options = StringSplitOptions.None)
	{
		return target.Split(new char[1] { separator }, options);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.string.split#system-string-split(system-char-system-int32-system-stringsplitoptions)")]
	public static string[] Split(this string target, char separator, int count, StringSplitOptions options = StringSplitOptions.None)
	{
		return target.Split(new char[1] { separator }, count, options);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.string.contains#system-string-contains(system-char)")]
	public static bool Contains(this string target, char value)
	{
		return target.IndexOf(value) >= 0;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.copyto#system-text-stringbuilder-copyto(system-int32-system-span((system-char))-system-int32)")]
	public static void CopyTo(this StringBuilder target, int sourceIndex, Span<char> destination, int count)
	{
		int num = 0;
		while (sourceIndex != target.Length && num != count)
		{
			destination[num] = target[sourceIndex];
			num++;
			sourceIndex++;
		}
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append#system-text-stringbuilder-append(system-readonlyspan((system-char)))")]
	public static StringBuilder Append(this StringBuilder target, ReadOnlySpan<char> value)
	{
		if (value.Length <= 0)
		{
			return target;
		}
		target.Append(value.ToArray());
		return target;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.equals#system-text-stringbuilder-equals(system-readonlyspan((system-char)))")]
	public static bool Equals(this StringBuilder target, ReadOnlySpan<char> span)
	{
		if (target.Length != span.Length)
		{
			return false;
		}
		for (int i = 0; i < target.Length; i++)
		{
			char num = target[i];
			char c = span[i];
			if (num != c)
			{
				return false;
			}
		}
		return true;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.waitasync#system-threading-tasks-task-waitasync(system-threading-cancellationtoken)")]
	public static Task WaitAsync(this Task target, CancellationToken cancellationToken)
	{
		return target.WaitAsync(Timeout.InfiniteTimeSpan, cancellationToken);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.waitasync#system-threading-tasks-task-waitasync(system-timespan)")]
	public static async Task WaitAsync(this Task target, TimeSpan timeout)
	{
		CancellationTokenSource cancellationSource = new CancellationTokenSource();
		try
		{
			await target.WaitAsync(timeout, cancellationSource.Token);
		}
		finally
		{
			cancellationSource.Cancel();
			cancellationSource.Dispose();
		}
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.waitasync#system-threading-tasks-task-waitasync(system-timespan-system-threading-cancellationtoken)")]
	public static async Task WaitAsync(this Task task, TimeSpan timeout, CancellationToken cancellationToken)
	{
		Task delayTask = Task.Delay(timeout, cancellationToken);
		if (await Task.WhenAny(task, delayTask) == delayTask)
		{
			throw new TimeoutException($"Execution did not complete within the time allotted {timeout.TotalMilliseconds} ms");
		}
		await task;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.waitasync#system-threading-tasks-task-waitasync(system-threading-cancellationtoken)")]
	public static Task<TResult> WaitAsync<TResult>(this Task<TResult> task, CancellationToken cancellationToken)
	{
		return task.WaitAsync(Timeout.InfiniteTimeSpan, cancellationToken);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.waitasync#system-threading-tasks-task-1-waitasync(system-threading-cancellationtoken)")]
	public static async Task<TResult> WaitAsync<TResult>(this Task<TResult> task, TimeSpan timeout)
	{
		CancellationTokenSource cancellationSource = new CancellationTokenSource();
		try
		{
			return await task.WaitAsync(timeout, cancellationSource.Token);
		}
		finally
		{
			cancellationSource.Cancel();
			cancellationSource.Dispose();
		}
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.waitasync#system-threading-tasks-task-1-waitasync(system-timespan-system-threading-cancellationtoken)")]
	public static async Task<TResult> WaitAsync<TResult>(this Task<TResult> task, TimeSpan timeout, CancellationToken cancellationToken)
	{
		Task delayTask = Task.Delay(timeout, cancellationToken);
		if (await Task.WhenAny(task, delayTask) == delayTask)
		{
			throw new TimeoutException($"Execution did not complete within the time allotted {timeout.TotalMilliseconds} ms");
		}
		return await task;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader.readasync#system-io-textreader-readasync(system-memory((system-char))-system-threading-cancellationtoken)")]
	public static ValueTask<int> ReadAsync(this TextReader target, Memory<char> buffer, CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		if (!MemoryMarshal.TryGetArray((ReadOnlyMemory<char>)buffer, out ArraySegment<char> segment))
		{
			segment = new ArraySegment<char>(buffer.ToArray());
		}
		return new ValueTask<int>(target.ReadAsync(segment.Array, segment.Offset, segment.Count));
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader.readtoendasync#system-io-textreader-readtoendasync(system-threading-cancellationtoken)")]
	public static Task<string> ReadToEndAsync(this TextReader target, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		return target.ReadToEndAsync();
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.writeasync#system-io-textwriter-writeasync(system-readonlymemory((system-char))-system-threading-cancellationtoken)")]
	public static ValueTask WriteAsync(this TextWriter target, ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		if (!MemoryMarshal.TryGetArray(buffer, out var segment))
		{
			segment = new ArraySegment<char>(buffer.ToArray());
		}
		return new ValueTask(target.WriteAsync(segment.Array, segment.Offset, segment.Count));
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.writelineasync#system-io-textwriter-writelineasync(system-readonlymemory((system-char))-system-threading-cancellationtoken)")]
	public static ValueTask WriteLineAsync(this TextWriter target, ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		if (!MemoryMarshal.TryGetArray(buffer, out var segment))
		{
			segment = new ArraySegment<char>(buffer.ToArray());
		}
		return new ValueTask(target.WriteLineAsync(segment.Array, segment.Offset, segment.Count));
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.write#system-io-textwriter-write(system-readonlyspan((system-char)))")]
	public static void Write(this TextWriter target, ReadOnlySpan<char> buffer)
	{
		ArrayPool<char> shared = ArrayPool<char>.Shared;
		char[] array = shared.Rent(buffer.Length);
		try
		{
			buffer.CopyTo(new Span<char>(array));
			target.Write(array, 0, buffer.Length);
		}
		finally
		{
			shared.Return(array);
		}
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.writeline#system-io-textwriter-writeline(system-readonlyspan((system-char)))")]
	public static void WriteLine(this TextWriter target, ReadOnlySpan<char> buffer)
	{
		ArrayPool<char> shared = ArrayPool<char>.Shared;
		char[] array = shared.Rent(buffer.Length);
		try
		{
			buffer.CopyTo(new Span<char>(array));
			target.WriteLine(array, 0, buffer.Length);
		}
		finally
		{
			shared.Return(array);
		}
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.sbyte.tryformat")]
	public static bool TryFormat(this sbyte target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.byte.tryformat")]
	public static bool TryFormat(this byte target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.int16.tryformat")]
	public static bool TryFormat(this short target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.uint16.tryformat")]
	public static bool TryFormat(this ushort target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryformat")]
	public static bool TryFormat(this int target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.uint32.tryformat")]
	public static bool TryFormat(this uint target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.int64.tryformat")]
	public static bool TryFormat(this long target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.uint64.tryformat")]
	public static bool TryFormat(this ulong target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.single.tryformat")]
	public static bool TryFormat(this float target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.double.tryformat")]
	public static bool TryFormat(this double target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.decimal.tryformat")]
	public static bool TryFormat(this decimal target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.boolean.tryformat")]
	public static bool TryFormat(this bool target, Span<char> destination, out int charsWritten)
	{
		string result = target.ToString();
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.tryformat")]
	public static bool TryFormat(this DateTimeOffset target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryformat")]
	public static bool TryFormat(this DateTime target, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		string result = ((format.Length != 0) ? target.ToString(format.ToString(), provider) : target.ToString(provider));
		return CopyToSpan(destination, out charsWritten, result);
	}

	private static bool CopyToSpan(Span<char> destination, out int charsWritten, string result)
	{
		if (result.Length == 0)
		{
			charsWritten = 0;
			return true;
		}
		charsWritten = result.Length;
		return result.TryCopyTo(destination);
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.reflection.memberinfo.hassamemetadatadefinitionas")]
	public static bool HasSameMetadataDefinitionAs(this MemberInfo target, MemberInfo other)
	{
		if (target.MetadataToken == other.MetadataToken)
		{
			return target.Module.Equals(other.Module);
		}
		return false;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.type.isgenericmethodparameter")]
	public static bool IsGenericMethodParameter(this Type target)
	{
		if (target.IsGenericParameter)
		{
			return target.DeclaringMethod != null;
		}
		return false;
	}

	[Description("https://learn.microsoft.com/en-us/dotnet/api/system.type.getmemberwithsamemetadatadefinitionas")]
	internal static MemberInfo GetMemberWithSameMetadataDefinitionAs(this Type type, MemberInfo member)
	{
		MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (MemberInfo memberInfo in members)
		{
			if (HasSameMetadataDefinitionAs(memberInfo, member))
			{
				return memberInfo;
			}
		}
		throw new MissingMemberException(type.FullName, member.Name);
	}

	public static Stream ReadAsStream(this HttpContent content, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!(content is SerializableHttpContent serializableHttpContent))
		{
			return content.ReadAsStreamAsync(cancellationToken).Result;
		}
		return serializableHttpContent.ReadAsStream(cancellationToken);
	}

	public static void WriteRawValue(this Utf8JsonWriter writer, byte[] utf8Json)
	{
		using JsonDocument jsonDocument = JsonDocument.Parse(utf8Json);
		jsonDocument.RootElement.WriteTo(writer);
	}
}
