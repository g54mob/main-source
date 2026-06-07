using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Compatibility;

namespace NUnit.Framework.Constraints
{
	public class NUnitEqualityComparer
	{
		public class FailurePoint
		{
			public long Position;

			public object ExpectedValue;

			public object ActualValue;

			public bool ExpectedHasData;

			public bool ActualHasData;
		}

		private bool caseInsensitive;

		private bool compareAsCollection;

		private List<EqualityAdapter> externalComparers = new List<EqualityAdapter>();

		private List<FailurePoint> failurePoints;

		private static readonly int BUFFER_SIZE = 4096;

		private static readonly Type GameObjectType = Type.GetType("UnityEngine.Object, UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");

		public static NUnitEqualityComparer Default => new NUnitEqualityComparer();

		public bool IgnoreCase
		{
			get
			{
				return caseInsensitive;
			}
			set
			{
				caseInsensitive = value;
			}
		}

		public bool CompareAsCollection
		{
			get
			{
				return compareAsCollection;
			}
			set
			{
				compareAsCollection = value;
			}
		}

		public IList<EqualityAdapter> ExternalComparers => externalComparers;

		public IList<FailurePoint> FailurePoints => failurePoints;

		public bool WithSameOffset { get; set; }

		public bool AreEqual(object x, object y, ref Tolerance tolerance)
		{
			failurePoints = new List<FailurePoint>();
			CheckGameObjectReference(ref x);
			CheckGameObjectReference(ref y);
			if (x == null && y == null)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			if (x == y)
			{
				return true;
			}
			Type type = x.GetType();
			Type type2 = y.GetType();
			Type type3 = (NUnit.Compatibility.TypeExtensions.GetTypeInfo(type).IsGenericType ? type.GetGenericTypeDefinition() : null);
			Type type4 = (NUnit.Compatibility.TypeExtensions.GetTypeInfo(type2).IsGenericType ? type2.GetGenericTypeDefinition() : null);
			EqualityAdapter externalComparer = GetExternalComparer(x, y);
			if (externalComparer != null)
			{
				return externalComparer.AreEqual(x, y);
			}
			if (type.IsArray && type2.IsArray && !compareAsCollection)
			{
				return ArraysEqual((Array)x, (Array)y, ref tolerance);
			}
			if (x is IDictionary && y is IDictionary)
			{
				return DictionariesEqual((IDictionary)x, (IDictionary)y, ref tolerance);
			}
			if (x is DictionaryEntry && y is DictionaryEntry)
			{
				return DictionaryEntriesEqual((DictionaryEntry)x, (DictionaryEntry)y, ref tolerance);
			}
			if ((object)type3 == typeof(KeyValuePair<, >) && (object)type4 == typeof(KeyValuePair<, >))
			{
				Tolerance tolerance2 = Tolerance.Exact;
				object value = type.GetProperty("Key").GetValue(x, null);
				object value2 = type2.GetProperty("Key").GetValue(y, null);
				object value3 = type.GetProperty("Value").GetValue(x, null);
				object value4 = type2.GetProperty("Value").GetValue(y, null);
				return AreEqual(value, value2, ref tolerance2) && AreEqual(value3, value4, ref tolerance);
			}
			if (x is string && y is string)
			{
				return StringsEqual((string)x, (string)y);
			}
			if (x is Stream && y is Stream)
			{
				return StreamsEqual((Stream)x, (Stream)y);
			}
			if (x is char && y is char)
			{
				return CharsEqual((char)x, (char)y);
			}
			if (x is DirectoryInfo && y is DirectoryInfo)
			{
				return DirectoriesEqual((DirectoryInfo)x, (DirectoryInfo)y);
			}
			if (Numerics.IsNumericType(x) && Numerics.IsNumericType(y))
			{
				return Numerics.AreEqual(x, y, ref tolerance);
			}
			if (x is DateTimeOffset && y is DateTimeOffset)
			{
				DateTimeOffset dateTimeOffset = (DateTimeOffset)x;
				DateTimeOffset dateTimeOffset2 = (DateTimeOffset)y;
				bool flag;
				if (tolerance != null && tolerance.Value is TimeSpan)
				{
					TimeSpan timeSpan = (TimeSpan)tolerance.Value;
					flag = (dateTimeOffset - dateTimeOffset2).Duration() <= timeSpan;
				}
				else
				{
					flag = dateTimeOffset == dateTimeOffset2;
				}
				if (flag && WithSameOffset)
				{
					flag = dateTimeOffset.Offset == dateTimeOffset2.Offset;
				}
				return flag;
			}
			if (tolerance != null && tolerance.Value is TimeSpan)
			{
				TimeSpan timeSpan2 = (TimeSpan)tolerance.Value;
				if (x is DateTime && y is DateTime)
				{
					return ((DateTime)x - (DateTime)y).Duration() <= timeSpan2;
				}
				if (x is TimeSpan && y is TimeSpan)
				{
					return ((TimeSpan)x - (TimeSpan)y).Duration() <= timeSpan2;
				}
			}
			MethodInfo methodInfo = FirstImplementsIEquatableOfSecond(type, type2);
			if ((object)methodInfo != null)
			{
				return InvokeFirstIEquatableEqualsSecond(x, y, methodInfo);
			}
			if ((object)type != type2 && (object)(methodInfo = FirstImplementsIEquatableOfSecond(type2, type)) != null)
			{
				return InvokeFirstIEquatableEqualsSecond(y, x, methodInfo);
			}
			if (x is IEnumerable && y is IEnumerable)
			{
				return EnumerablesEqual((IEnumerable)x, (IEnumerable)y, ref tolerance);
			}
			return x.Equals(y);
		}

		private static MethodInfo FirstImplementsIEquatableOfSecond(Type first, Type second)
		{
			KeyValuePair<Type, MethodInfo> keyValuePair = default(KeyValuePair<Type, MethodInfo>);
			foreach (KeyValuePair<Type, MethodInfo> equatableGenericArgument in GetEquatableGenericArguments(first))
			{
				if (equatableGenericArgument.Key.IsAssignableFrom(second) && ((object)keyValuePair.Key == null || keyValuePair.Key.IsAssignableFrom(equatableGenericArgument.Key)))
				{
					keyValuePair = equatableGenericArgument;
				}
			}
			return keyValuePair.Value;
		}

		private static IList<KeyValuePair<Type, MethodInfo>> GetEquatableGenericArguments(Type type)
		{
			List<KeyValuePair<Type, MethodInfo>> list = new List<KeyValuePair<Type, MethodInfo>>();
			Type[] interfaces = type.GetInterfaces();
			foreach (Type type2 in interfaces)
			{
				if (NUnit.Compatibility.TypeExtensions.GetTypeInfo(type2).IsGenericType && type2.GetGenericTypeDefinition().Equals(typeof(IEquatable<>)))
				{
					list.Add(new KeyValuePair<Type, MethodInfo>(type2.GetGenericArguments()[0], type2.GetMethod("Equals")));
				}
			}
			return list;
		}

		private static bool InvokeFirstIEquatableEqualsSecond(object first, object second, MethodInfo equals)
		{
			try
			{
				return (object)equals != null && (bool)equals.Invoke(first, new object[1] { second });
			}
			catch (TargetInvocationException)
			{
				return first.Equals(second);
			}
		}

		private EqualityAdapter GetExternalComparer(object x, object y)
		{
			foreach (EqualityAdapter externalComparer in externalComparers)
			{
				if (externalComparer.CanCompare(x, y))
				{
					return externalComparer;
				}
			}
			return null;
		}

		private bool ArraysEqual(Array x, Array y, ref Tolerance tolerance)
		{
			int rank = x.Rank;
			if (rank != y.Rank)
			{
				return false;
			}
			for (int i = 1; i < rank; i++)
			{
				if (x.GetLength(i) != y.GetLength(i))
				{
					return false;
				}
			}
			return EnumerablesEqual(x, y, ref tolerance);
		}

		private bool DictionariesEqual(IDictionary x, IDictionary y, ref Tolerance tolerance)
		{
			if (x.Count != y.Count)
			{
				return false;
			}
			CollectionTally collectionTally = new CollectionTally(this, x.Keys);
			if (!collectionTally.TryRemove(y.Keys) || collectionTally.Count > 0)
			{
				return false;
			}
			foreach (object key in x.Keys)
			{
				if (!AreEqual(x[key], y[key], ref tolerance))
				{
					return false;
				}
			}
			return true;
		}

		private bool DictionaryEntriesEqual(DictionaryEntry x, DictionaryEntry y, ref Tolerance tolerance)
		{
			Tolerance tolerance2 = Tolerance.Exact;
			return AreEqual(x.Key, y.Key, ref tolerance2) && AreEqual(x.Value, y.Value, ref tolerance);
		}

		private bool CollectionsEqual(ICollection x, ICollection y, ref Tolerance tolerance)
		{
			IEnumerator enumerator = null;
			IEnumerator enumerator2 = null;
			try
			{
				enumerator = x.GetEnumerator();
				enumerator2 = y.GetEnumerator();
				int num = 0;
				bool flag;
				bool flag2;
				while (true)
				{
					flag = enumerator.MoveNext();
					flag2 = enumerator2.MoveNext();
					if (!flag && !flag2)
					{
						return true;
					}
					if (flag != flag2 || !AreEqual(enumerator.Current, enumerator2.Current, ref tolerance))
					{
						break;
					}
					num++;
				}
				FailurePoint failurePoint = new FailurePoint();
				failurePoint.Position = num;
				failurePoint.ExpectedHasData = flag;
				if (flag)
				{
					failurePoint.ExpectedValue = enumerator.Current;
				}
				failurePoint.ActualHasData = flag2;
				if (flag2)
				{
					failurePoint.ActualValue = enumerator2.Current;
				}
				failurePoints.Insert(0, failurePoint);
				return false;
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
				if (enumerator2 is IDisposable disposable2)
				{
					disposable2.Dispose();
				}
			}
		}

		private bool StringsEqual(string x, string y)
		{
			string text = (caseInsensitive ? x.ToLower() : x);
			string value = (caseInsensitive ? y.ToLower() : y);
			return text.Equals(value);
		}

		private bool CharsEqual(char x, char y)
		{
			char c = (caseInsensitive ? char.ToLower(x) : x);
			char c2 = (caseInsensitive ? char.ToLower(y) : y);
			return c == c2;
		}

		private bool EnumerablesEqual(IEnumerable x, IEnumerable y, ref Tolerance tolerance)
		{
			IEnumerator enumerator = null;
			IEnumerator enumerator2 = null;
			try
			{
				enumerator = x.GetEnumerator();
				enumerator2 = y.GetEnumerator();
				int num = 0;
				bool flag;
				bool flag2;
				while (true)
				{
					flag = enumerator.MoveNext();
					flag2 = enumerator2.MoveNext();
					if (!flag && !flag2)
					{
						return true;
					}
					if (flag != flag2 || !AreEqual(enumerator.Current, enumerator2.Current, ref tolerance))
					{
						break;
					}
					num++;
				}
				FailurePoint failurePoint = new FailurePoint();
				failurePoint.Position = num;
				failurePoint.ExpectedHasData = flag;
				if (flag)
				{
					failurePoint.ExpectedValue = enumerator.Current;
				}
				failurePoint.ActualHasData = flag2;
				if (flag2)
				{
					failurePoint.ActualValue = enumerator2.Current;
				}
				failurePoints.Insert(0, failurePoint);
				return false;
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
				if (enumerator2 is IDisposable disposable2)
				{
					disposable2.Dispose();
				}
			}
		}

		private static bool DirectoriesEqual(DirectoryInfo x, DirectoryInfo y)
		{
			if (x.Attributes != y.Attributes || x.CreationTime != y.CreationTime || x.LastAccessTime != y.LastAccessTime)
			{
				return false;
			}
			return new SamePathConstraint(x.FullName).ApplyTo(y.FullName).IsSuccess;
		}

		private bool StreamsEqual(Stream x, Stream y)
		{
			if (x == y)
			{
				return true;
			}
			if (!x.CanRead)
			{
				throw new ArgumentException("Stream is not readable", "expected");
			}
			if (!y.CanRead)
			{
				throw new ArgumentException("Stream is not readable", "actual");
			}
			if (!x.CanSeek)
			{
				throw new ArgumentException("Stream is not seekable", "expected");
			}
			if (!y.CanSeek)
			{
				throw new ArgumentException("Stream is not seekable", "actual");
			}
			if (x.Length != y.Length)
			{
				return false;
			}
			byte[] array = new byte[BUFFER_SIZE];
			byte[] array2 = new byte[BUFFER_SIZE];
			BinaryReader binaryReader = new BinaryReader(x);
			BinaryReader binaryReader2 = new BinaryReader(y);
			long position = x.Position;
			long position2 = y.Position;
			try
			{
				binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
				binaryReader2.BaseStream.Seek(0L, SeekOrigin.Begin);
				for (long num = 0L; num < x.Length; num += BUFFER_SIZE)
				{
					binaryReader.Read(array, 0, BUFFER_SIZE);
					binaryReader2.Read(array2, 0, BUFFER_SIZE);
					for (int i = 0; i < BUFFER_SIZE; i++)
					{
						if (array[i] != array2[i])
						{
							FailurePoint failurePoint = new FailurePoint();
							failurePoint.Position = num + i;
							failurePoint.ExpectedHasData = true;
							failurePoint.ExpectedValue = array[i];
							failurePoint.ActualHasData = true;
							failurePoint.ActualValue = array2[i];
							failurePoints.Insert(0, failurePoint);
							return false;
						}
					}
				}
			}
			finally
			{
				x.Position = position;
				y.Position = position2;
			}
			return true;
		}

		internal static void CheckGameObjectReference<T>(ref T value)
		{
			if (value == null || (object)GameObjectType == null || !GameObjectType.IsInstanceOfType(value))
			{
				return;
			}
			MethodInfo method = GameObjectType.GetMethod("GetInstanceID");
			if ((object)method != null)
			{
				object obj = method.Invoke(value, null);
				if ((int)obj == 0)
				{
					value = default(T);
				}
			}
		}
	}
}
