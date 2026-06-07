using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

namespace MagicaCloth2
{
	public class ExTransformAccessArray : IDisposable
	{
		private TransformAccessArray transformArray;

		private int nativeLength;

		private Queue<int> emptyStack;

		private Dictionary<int, MagicaObjectId> useIndexDict;

		private Dictionary<MagicaObjectId, int> indexDict;

		private Dictionary<MagicaObjectId, int> referenceDict;

		public int Count => 0;

		public int Length => 0;

		public Transform this[int index] => null;

		public ExTransformAccessArray(int capacity, int desiredJobCount = -1)
		{
		}

		public void Dispose()
		{
		}

		public TransformAccessArray GetTransformAccessArray()
		{
			return default(TransformAccessArray);
		}

		public int Add(Transform element)
		{
			return 0;
		}

		public void Remove(int index)
		{
		}

		public bool Exist(int index)
		{
			return false;
		}

		public bool Exist(Transform element)
		{
			return false;
		}

		public int GetIndex(Transform element)
		{
			return 0;
		}

		public void Clear()
		{
		}
	}
}
