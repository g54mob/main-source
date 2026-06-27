using System;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	[Serializable]
	public class HeldElement
	{
		[SerializeField]
		private ElementData elementData;

		[SerializeField]
		private int heldAmount;

		public ElementData ElementData => elementData;

		public int HeldAmount => heldAmount;

		public HeldElement(ElementData elementData, int initialAmount)
		{
			this.elementData = elementData;
			heldAmount = initialAmount;
		}

		public bool TryToAddMoreOfHeldElement(ElementData elementToAdd, int amountToAdd)
		{
			if (elementToAdd.IsIdenticalTo(elementData))
			{
				heldAmount += amountToAdd;
				return true;
			}
			return false;
		}
	}
}
