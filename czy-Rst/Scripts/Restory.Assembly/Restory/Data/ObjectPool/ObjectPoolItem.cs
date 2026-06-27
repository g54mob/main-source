using System;
using Helpers.Ranges;
using UnityEngine;

namespace Restory.Data.ObjectPool
{
	[Serializable]
	public class ObjectPoolItem
	{
		public GameObject Prefab;

		public IntRange Size = new IntRange(1, 10);
	}
}
