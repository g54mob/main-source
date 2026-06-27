using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices.Quality;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Devices/DevicePriceEstimationSettings", fileName = "DevicePriceEstimationSettings")]
	public class DevicePriceEstimationSettings : ScriptableObject
	{
		[SerializeField]
		private List<QualityFactor> qualityFactors = new List<QualityFactor>();

		[SerializeField]
		[Range(0f, 1f)]
		private float generatedDeviceDirtyElementPaymentModifier = 0.3f;

		[SerializeField]
		private int generatedDeviceDirtyElementPaymentFixedPrice = 300;

		[SerializeField]
		private int paintPaymentFixedPrice = 300;

		[SerializeField]
		private int paintPalettePaymentFixedPrice = 300;

		[SerializeField]
		private int hackingPaymentFixedPrice = 300;

		public Dictionary<DeviceQualityBase, float> QualityFactors => qualityFactors.ToDictionary((QualityFactor x) => x.Quality, (QualityFactor x) => x.Factor);

		public float GeneratedDeviceDirtyElementPaymentModifier => generatedDeviceDirtyElementPaymentModifier;

		public int GeneratedDeviceDirtyElementPaymentFixedPrice => generatedDeviceDirtyElementPaymentFixedPrice;

		public int PaintPaymentFixedPrice => paintPaymentFixedPrice;

		public int PaintPalettePaymentFixedPrice => paintPalettePaymentFixedPrice;

		public int HackingPaymentFixedPrice => hackingPaymentFixedPrice;
	}
}
