using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class RoofComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Roof;

		[SerializeField]
		private string id;

		[SerializeField]
		private int maxLength;

		[SerializeField]
		private IntIntDictionary heightScaling = SerializableDictionary<int, int>.CreateNew<IntIntDictionary>();

		[SerializeField]
		private bool halfRoof;

		private Dictionary<int, int> lengthHeight = new Dictionary<int, int>();

		public BuildingType ComponentType => componentType;

		public int MaxLength => maxLength;

		public bool HalfRoof => halfRoof;

		public int GetHeight(int currentLength)
		{
			if (lengthHeight.Count == 0)
			{
				int[] array = heightScaling.Dictionary.Keys.ToArray();
				Array.Sort(array);
				int num = 1;
				for (int i = 0; i < array.Length; i++)
				{
					for (int j = num; j <= array[i]; j++)
					{
						lengthHeight.Add(j, heightScaling.Dictionary[array[i]]);
					}
					num = array[i] + 1;
				}
			}
			currentLength = Mathf.Clamp(currentLength, 1, maxLength);
			return lengthHeight[currentLength];
		}

		public override string GetID()
		{
			return id;
		}
	}
}
