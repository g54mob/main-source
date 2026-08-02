using System;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[Serializable]
	public class ItemGenerator
	{
		public enum Method
		{
			Specific = 0,
			RandomFromCategory = 1,
			Random = 2
		}

		[SerializeField]
		public Method GenerateMethod;

		[DatabaseCategory]
		[SerializeField]
		public string Category;

		[DatabaseItem]
		[SerializeField]
		public string Name;

		[SerializeField]
		[MinMax(1f, 100f, false)]
		private Vector2Int CountRange = new Vector2Int(1, 100);

		public int GetRandomCount()
		{
			return Mathf.Clamp(UnityEngine.Random.Range(CountRange.x, CountRange.y + 1), 1, 100);
		}
	}
}
