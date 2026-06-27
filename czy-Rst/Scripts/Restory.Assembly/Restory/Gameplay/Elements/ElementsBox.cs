using System.Collections.Generic;
using Restory.Gameplay.Shops.Devices;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementsBox : MonoBehaviour
	{
		private readonly List<ElementData> elements = new List<ElementData>();

		public IReadOnlyCollection<ElementData> Elements => elements;

		public void Init(ElementsBoxData boxData)
		{
			elements.Clear();
			if (boxData.Elements == null)
			{
				return;
			}
			foreach (ElementData element in boxData.Elements)
			{
				elements.Add(element);
			}
		}

		public void Clear()
		{
			elements.Clear();
		}
	}
}
