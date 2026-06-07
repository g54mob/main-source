using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace DV.Shops
{
	public class ShelfPlacer : MonoBehaviour
	{
		[Serializable]
		public class ShelfDefinition
		{
			public Transform leftEnd;

			public Transform rightEnd;

			public float depth;

			[NonSerialized]
			public float length;

			[NonSerialized]
			public List<float2> availableSpaces = new List<float2>();

			public bool TryGetEmptySpace(float length, Unity.Mathematics.Random random, out float2 space)
			{
				space = default(float2);
				if (availableSpaces.Count == 0)
				{
					return false;
				}
				int num = 0;
				while (num < 30)
				{
					num++;
					int index = random.NextInt(0, availableSpaces.Count);
					float2 obj = availableSpaces[index];
					float x = obj.x;
					float y = obj.y;
					if (!(y - x < length))
					{
						float num2 = y - x - length;
						float num3 = random.NextFloat();
						float num4 = num2 * num3;
						float num5 = num2 - num4;
						availableSpaces.RemoveAtSwapBack(index);
						if (num4 > 0f)
						{
							availableSpaces.Add(new float2(x, x + num4));
						}
						if (num5 > 0f)
						{
							availableSpaces.Add(new float2(y - num5, y));
						}
						space = new float2(x + num4, y - num5);
						return true;
					}
				}
				return false;
			}
		}

		public float depth = 0.387f;

		public ShelfDefinition[] shelves;

		private void Awake()
		{
			InitializeEmptyShelves();
		}

		public void InitializeEmptyShelves()
		{
			ShelfDefinition[] array = shelves;
			foreach (ShelfDefinition shelfDefinition in array)
			{
				shelfDefinition.length = math.distance(shelfDefinition.leftEnd.position, shelfDefinition.rightEnd.position);
				shelfDefinition.availableSpaces = new List<float2>
				{
					new float2(0f, shelfDefinition.length)
				};
			}
		}

		public bool TryPlaceOnAnyShelf(ShelfItem item, Unity.Mathematics.Random random)
		{
			int num = random.NextInt(0, shelves.Length);
			for (int i = 0; i < shelves.Length; i++)
			{
				ShelfDefinition shelfDefinition = shelves[(i + num) % shelves.Length];
				if (!(item.Depth > shelfDefinition.depth))
				{
					if (item.Width > shelfDefinition.length)
					{
						Debug.LogError("Found item that's longer than the shelf length: " + item.name, base.gameObject);
					}
					if (shelfDefinition.TryGetEmptySpace(item.Width, random, out var space))
					{
						item.transform.position = Vector3.Lerp(shelfDefinition.leftEnd.position, shelfDefinition.rightEnd.position, Mathf.InverseLerp(0f, shelfDefinition.length, (space.x + space.y) / 2f));
						item.transform.rotation = shelfDefinition.leftEnd.rotation;
						return true;
					}
				}
			}
			return false;
		}
	}
}
