using System;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class ObjectSequence<T>
	{
		public enum Iteration
		{
			Ordered = 0,
			Random = 1
		}

		public T startObject;

		public T endObject;

		public T[] objects;

		public Iteration iteration;

		[SerializeField]
		[HideInInspector]
		private int _randomSeed;

		[SerializeField]
		[HideInInspector]
		private int index;

		[SerializeField]
		[HideInInspector]
		private System.Random randomizer;

		public int randomSeed
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public T GetFirst()
		{
			return default(T);
		}

		public T GetLast()
		{
			return default(T);
		}

		public T Next()
		{
			return default(T);
		}
	}
}
