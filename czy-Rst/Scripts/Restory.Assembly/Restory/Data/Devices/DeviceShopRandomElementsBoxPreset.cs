using System;
using Helpers.Ranges;
using Restory.Data.Elements;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;

namespace Restory.Data.Devices
{
	[Serializable]
	public class DeviceShopRandomElementsBoxPreset : IRandomnessWeightHolder
	{
		[SerializeField]
		private ElementsBoxInfo boxInfo;

		[SerializeField]
		private IntRange elementsCount;

		[SerializeField]
		[Range(0f, 100f)]
		private int dirtyElementsPercent;

		[SerializeField]
		[Range(0f, 100f)]
		private int brokenElementsPercent;

		[SerializeField]
		[Min(0.1f)]
		private float priceModifier = 1f;

		[SerializeField]
		private bool mustContainUniqueElements = true;

		[SerializeField]
		[Min(1f)]
		private int weight = 1;

		public int Weight => weight;

		public ElementsBoxInfo BoxInfo => boxInfo;

		public IntRange ElementsCount => elementsCount;

		public int DirtyElementsPercent => dirtyElementsPercent;

		public int BrokenElementsPercent => brokenElementsPercent;

		public float PriceModifier => priceModifier;

		public bool MustContainUniqueElements => mustContainUniqueElements;

		public DeviceShopRandomElementsBoxPreset(ElementsBoxInfo boxInfo, IntRange elementsCount, int dirtyElementsPercent, int brokenElementsPercent, float priceModifier, bool mustContainUniqueElements, int weight = 1)
		{
			this.boxInfo = boxInfo;
			this.elementsCount = elementsCount;
			this.dirtyElementsPercent = Mathf.Clamp(dirtyElementsPercent, 0, 100);
			this.brokenElementsPercent = Mathf.Clamp(brokenElementsPercent, 0, 100);
			this.priceModifier = Mathf.Max(0.1f, priceModifier);
			this.mustContainUniqueElements = mustContainUniqueElements;
			this.weight = Mathf.Max(1, weight);
		}
	}
}
