using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Devices.Quality
{
	public abstract class DeviceQualityBase : RestoryEntityInfoBase
	{
		[SerializeField]
		private string localizationKey;

		public string LocalizationKey => localizationKey;
	}
}
