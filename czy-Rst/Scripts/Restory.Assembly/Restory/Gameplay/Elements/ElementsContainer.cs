using System.Collections.Generic;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementsContainer : MonoBehaviour
	{
		private readonly HeldElements heldElements = new HeldElements();

		public IReadOnlyCollection<HeldElement> HeldElements => heldElements.AllHeldElements;

		public void AddElement(HeldElement elementData)
		{
			heldElements.AddElement(elementData);
		}

		public void Clear()
		{
			heldElements.Clear();
		}
	}
}
