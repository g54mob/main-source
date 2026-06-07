using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReinforcementLearning
{
	public class ListReplayBuffer<T> : IReplayBuffer<T>
	{
		private List<T> buffer;

		private int maxBufferSize;

		public int MaxBufferSize
		{
			get
			{
				return maxBufferSize;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("MaxBufferSize must be greater than zero");
				}
				maxBufferSize = value;
				if (buffer.Count > maxBufferSize)
				{
					buffer.RemoveRange(0, buffer.Count - maxBufferSize);
				}
			}
		}

		public ListReplayBuffer(int maxBufferSize)
		{
			if (maxBufferSize < 1)
			{
				throw new ArgumentOutOfRangeException("maxBufferSize must be greater than zero");
			}
			this.maxBufferSize = maxBufferSize;
			buffer = new List<T>(maxBufferSize);
		}

		public void Add(T obj)
		{
			if (buffer.Count == maxBufferSize)
			{
				buffer.RemoveAt(0);
			}
			buffer.Add(obj);
		}

		public T[] GetSamples(long samplesNumber)
		{
			if (samplesNumber < 0)
			{
				throw new ArgumentOutOfRangeException("samplesNumber must be non negative");
			}
			T[] array = new T[samplesNumber];
			if (samplesNumber > 0 && buffer.Count > 0)
			{
				for (int i = 0; i < samplesNumber; i++)
				{
					array[i] = buffer[UnityEngine.Random.Range(0, buffer.Count)];
				}
			}
			return array;
		}

		public T[] GetAllSamples()
		{
			return buffer.ToArray();
		}

		public long Count()
		{
			return buffer.Count;
		}

		public void Clear()
		{
			buffer.Clear();
		}
	}
}
