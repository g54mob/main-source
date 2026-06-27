using System;
using System.Collections.Generic;
using Restory.Data.Elements;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Shops.Devices
{
	[Serializable]
	public class ElementsBoxData
	{
		[SerializeField]
		private ElementsBoxInfo info;

		[SerializeField]
		private List<ElementData> elements;

		public ElementsBoxInfo Info => info;

		public IReadOnlyCollection<ElementData> Elements => elements;

		public ElementsBoxData(ElementsBoxInfo info, IEnumerable<ElementData> elements)
		{
			this.info = info;
			this.elements = new List<ElementData>(elements);
		}
	}
}
