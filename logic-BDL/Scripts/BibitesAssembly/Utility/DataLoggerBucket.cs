using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
	public class DataLoggerBucket<T> : ISaveable
	{
		private UnityEvent<T> dataPushedIn = new UnityEvent<T>();

		private UnityEvent<T> dataPushedOut = new UnityEvent<T>();

		public readonly int size;

		internal readonly int feedRatio;

		public readonly bool serialFeeding;

		public int n;

		private int cnt;

		private int bucketDepth;

		[ItemCanBeNull]
		internal T[] data;

		internal readonly DataLoggerBucket<T> feedingBucket;

		public int index0;

		public int nChildren;

		private int nPushedSinceLastAsk;

		private readonly bool hasFeedingBucket;

		public T this[int index]
		{
			get
			{
				if (index >= size)
				{
					if (feedingBucket == null)
					{
						throw new ArgumentOutOfRangeException();
					}
					return feedingBucket[index - size];
				}
				return data[RealI(index)];
			}
			set
			{
				if (index < size)
				{
					data[RealI(index)] = value;
					return;
				}
				if (feedingBucket != null)
				{
					feedingBucket[index - size] = value;
					return;
				}
				throw new ArgumentOutOfRangeException();
			}
		}

		public int nBuckets
		{
			get
			{
				DataLoggerBucket<T> dataLoggerBucket = feedingBucket;
				if (dataLoggerBucket == null)
				{
					return 1;
				}
				return dataLoggerBucket.nBuckets + 1;
			}
		}

		public int newDataSinceLastAsk
		{
			get
			{
				int result = nPushedSinceLastAsk + (feedingBucket?.newDataSinceLastAsk ?? 0);
				nPushedSinceLastAsk = 0;
				return result;
			}
		}

		public int nData => n + (feedingBucket?.nData ?? 0);

		public bool full => n == size;

		public bool feedingBucketsFull => feedingBucket?.full ?? full;

		public int RealI(int i)
		{
			return (index0 + i) % size;
		}

		public DataLoggerBucket<T> BucketOfIndex(int index)
		{
			if (index >= size)
			{
				return feedingBucket?.BucketOfIndex(index - size);
			}
			return this;
		}

		public DataLoggerBucket<T> GetBucketFromDepth(int depth)
		{
			if (depth >= 1)
			{
				return feedingBucket?.GetBucketFromDepth(depth - 1);
			}
			return this;
		}

		public DataLoggerBucket(LogLikeFormat format, int depth = 1, bool isSerial = false, int nParents = 0)
		{
			size = format.size;
			feedRatio = format.feedRatio;
			serialFeeding = isSerial;
			nChildren = depth - 1;
			bucketDepth = nParents;
			data = new T[size];
			hasFeedingBucket = depth > 1;
			if (hasFeedingBucket)
			{
				feedingBucket = new DataLoggerBucket<T>(format, depth - 1, isSerial, bucketDepth + 1);
			}
		}

		public DataLoggerBucket(LogLikeFormat[] formats, bool isSerial = false, int nParents = 0)
		{
			if (formats.Length >= 1)
			{
				nChildren = formats.Length - 1;
				size = formats[0].size;
				feedRatio = formats[0].feedRatio;
				serialFeeding = isSerial;
				bucketDepth = nParents;
				data = new T[size];
				hasFeedingBucket = formats.Length > 1;
				if (hasFeedingBucket)
				{
					feedingBucket = new DataLoggerBucket<T>(formats.Skip(1).ToArray(), isSerial, bucketDepth + 1);
				}
			}
		}

		public void Push(T newData)
		{
			index0--;
			if (index0 < 0)
			{
				index0 = size - 1;
			}
			bool num = n >= size;
			if (n < size)
			{
				n++;
			}
			if (nPushedSinceLastAsk < size)
			{
				nPushedSinceLastAsk++;
			}
			if (hasFeedingBucket)
			{
				cnt++;
				if (serialFeeding && cnt > size)
				{
					cnt -= feedRatio;
					feedingBucket.Push(data[index0]);
				}
				else if (!serialFeeding && cnt >= feedRatio)
				{
					cnt -= feedRatio;
					feedingBucket.Push(newData);
				}
			}
			if (num)
			{
				dataPushedOut.Invoke(data[index0]);
			}
			data[index0] = newData;
			dataPushedIn.Invoke(newData);
		}

		public void SubscribeToPushedIn(UnityAction<T> action, bool subscribeToFeedingBuckets = true)
		{
			dataPushedIn.AddListener(action);
			if (subscribeToFeedingBuckets && feedingBucket != null)
			{
				feedingBucket.SubscribeToPushedIn(action);
			}
		}

		public void SubscribeToPushedOut(UnityAction<T> action, bool subscribeToFeedingBuckets = true)
		{
			dataPushedOut.AddListener(action);
			if (subscribeToFeedingBuckets && feedingBucket != null)
			{
				feedingBucket.SubscribeToPushedOut(action);
			}
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			T[] allData = GetAllData();
			if (typeof(ISaveable).IsAssignableFrom(typeof(T)) || typeof(ISaveableArray).IsAssignableFrom(typeof(T)))
			{
				jObject["data"] = SerializationHelper.SerializeCollection(allData);
			}
			else
			{
				jObject["data"] = JToken.FromObject(allData);
			}
			AddPushCountersToJObj(jObject);
			return jObject;
		}

		public T[] GetAllData()
		{
			T[] array = new T[nData];
			int num = 0;
			for (int i = 0; i < nChildren + 1; i++)
			{
				DataLoggerBucket<T> bucketFromDepth = GetBucketFromDepth(i);
				for (int j = 0; j < bucketFromDepth.n; j++)
				{
					array[num] = bucketFromDepth[j];
					num++;
				}
			}
			return array;
		}

		public T[] GetAllDataWithAcc()
		{
			T[] array = new T[nData];
			int num = 0;
			for (int i = 0; i < nChildren + 1; i++)
			{
				DataLoggerBucket<T> bucketFromDepth = GetBucketFromDepth(i);
				for (int j = 0; j < bucketFromDepth.n + bucketFromDepth.feedRatio; j++)
				{
					array[num] = bucketFromDepth[j];
					num++;
				}
			}
			return array;
		}

		public int[] GetNDatas()
		{
			int[] array = new int[nChildren + 1];
			for (int i = 0; i <= nChildren; i++)
			{
				array[i] = GetBucketFromDepth(i).n;
			}
			return array;
		}

		public int[] GetPushCounters()
		{
			int[] array = new int[nChildren + 1];
			for (int i = 0; i <= nChildren; i++)
			{
				array[i] = GetBucketFromDepth(i).cnt;
			}
			return array;
		}

		public int[] GetPushCountersNewFormat()
		{
			int[] array = new int[nChildren + 1];
			for (int i = 0; i <= nChildren; i++)
			{
				DataLoggerBucket<T> bucketFromDepth = GetBucketFromDepth(i);
				array[i] = ((bucketFromDepth.n == bucketFromDepth.size) ? Mathf.Max(0, bucketFromDepth.feedRatio - (bucketFromDepth.n - bucketFromDepth.cnt)) : 0);
			}
			return array;
		}

		public void AddPushCountersToJObj(JObject obj)
		{
			obj["cnts"] = JToken.FromObject(GetPushCounters());
			if (!serialFeeding)
			{
				obj["nDatas"] = JToken.FromObject(GetNDatas());
			}
		}

		public void LoadState(JObject state)
		{
			if (state["data"].HasValues)
			{
				T[] array = new T[state["data"].Count()];
				if (typeof(ISaveable).IsAssignableFrom(typeof(T)) || typeof(ISaveableArray).IsAssignableFrom(typeof(T)))
				{
					SerializationHelper.DeserializeCollection(array, (JArray)state["data"]);
				}
				else
				{
					array = state["data"].ToObject<T[]>();
				}
				int[] cnts = state["cnts"].ToObject<int[]>();
				if (!serialFeeding)
				{
					int[] ns = state["nDatas"].ToObject<int[]>();
					FillBuckets(array, cnts, ns);
				}
				else
				{
					FillBuckets(array, cnts);
				}
				T[] array2 = array;
				foreach (T arg in array2)
				{
					dataPushedIn.Invoke(arg);
				}
			}
		}

		public void FillBuckets(T[] allData, int[] cnts, int[] ns = null)
		{
			int num = allData.Length;
			int num2 = 0;
			DataLoggerBucket<T> dataLoggerBucket = this;
			int num3 = 0;
			int num4 = 0;
			for (num3 = 0; num3 < num; num3++)
			{
				dataLoggerBucket.data[num2] = allData[num3];
				num2++;
				if (num2 >= ((ns != null) ? ns[num4] : dataLoggerBucket.size))
				{
					dataLoggerBucket.index0 = 0;
					dataLoggerBucket.n = ((ns != null) ? ns[num4] : dataLoggerBucket.size);
					dataLoggerBucket.nPushedSinceLastAsk = dataLoggerBucket.size;
					num2 -= ((ns != null) ? ns[num4] : dataLoggerBucket.size);
					if (dataLoggerBucket.feedingBucket == null)
					{
						break;
					}
					num4++;
					dataLoggerBucket = dataLoggerBucket.feedingBucket;
				}
			}
			if (num2 < ((ns != null) ? ns[num4] : dataLoggerBucket.size) && num2 > 0)
			{
				dataLoggerBucket.index0 = 0;
				dataLoggerBucket.n = num2;
				dataLoggerBucket.nPushedSinceLastAsk = num2;
			}
			for (int i = 0; i < cnts.Length; i++)
			{
				GetBucketFromDepth(i).cnt = cnts[i];
			}
			foreach (T arg in allData)
			{
				dataPushedIn.Invoke(arg);
			}
		}
	}
}
