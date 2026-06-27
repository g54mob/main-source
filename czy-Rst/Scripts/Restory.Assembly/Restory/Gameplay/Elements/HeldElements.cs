using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	[Serializable]
	public class HeldElements
	{
		[SerializeField]
		private List<HeldElement> allHeldElements = new List<HeldElement>();

		public List<HeldElement> AllHeldElements => allHeldElements;

		public void AddElement(ElementData elementData, int amount = 1)
		{
			foreach (HeldElement allHeldElement in allHeldElements)
			{
				if (allHeldElement.TryToAddMoreOfHeldElement(elementData, amount))
				{
					return;
				}
			}
			allHeldElements.Add(new HeldElement(elementData, amount));
		}

		public void AddElement(HeldElement elementToAdd)
		{
			foreach (HeldElement allHeldElement in allHeldElements)
			{
				if (allHeldElement.TryToAddMoreOfHeldElement(elementToAdd.ElementData, elementToAdd.HeldAmount))
				{
					return;
				}
			}
			allHeldElements.Add(elementToAdd);
		}

		public void Clear()
		{
			allHeldElements.Clear();
		}
	}
}
