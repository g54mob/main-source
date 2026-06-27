using Helpers.Ranges;
using Restory.Data.Elements.ElementTypes;
using Restory.Gameplay.TimeSystems;
using UnityEngine;

namespace Restory.Gameplay.DeliveryRandomParts
{
	[CreateAssetMenu(fileName = "DeliveryRandomPartsSettings", menuName = "Restory/DeliveryRandomParts/DeliveryRandomPartsSettings")]
	public class DeliveryRandomPartsSettings : ScriptableObject
	{
		[SerializeField]
		[Min(1f)]
		private int deliveryFrequencyInDays = 2;

		[SerializeField]
		private TimeOfDay deliveryTimeOfDay;

		[SerializeField]
		private IntRange numberPartsInPack = new IntRange(1, 3);

		[SerializeField]
		private bool uniquePartsInPack;

		[SerializeField]
		[Range(0f, 1f)]
		private float chanceContamination;

		[SerializeField]
		[Range(0f, 1f)]
		private float chanceSoldering;

		[SerializeField]
		private DirtType dirtTypeForSoldering;

		public int DeliveryFrequencyInDays => deliveryFrequencyInDays;

		public TimeOfDay DeliveryTimeOfDay => deliveryTimeOfDay;

		public IntRange NumberPartsInPack => numberPartsInPack;

		public bool UniquePartsInPack => uniquePartsInPack;

		public float ChanceContamination => chanceContamination;

		public float ChanceSoldering => chanceSoldering;

		public DirtType DirtTypeForSoldering => dirtTypeForSoldering;
	}
}
