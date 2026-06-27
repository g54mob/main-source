using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.Utils
{
	public class MaterialsPool : IDisposable
	{
		private Dictionary<Material, Material> originalToInstanceDictionary = new Dictionary<Material, Material>();

		public Material GetSingleCopy(Material original)
		{
			if (originalToInstanceDictionary.TryGetValue(original, out var value))
			{
				return value;
			}
			value = new Material(original);
			originalToInstanceDictionary[original] = value;
			return value;
		}

		public void Dispose()
		{
			foreach (Material value in originalToInstanceDictionary.Values)
			{
				UnityEngine.Object.Destroy(value);
			}
			originalToInstanceDictionary.Clear();
		}
	}
}
