using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.GUIControllerElements
{
	[CreateAssetMenu(menuName = "Restory/Controllers/ControllerId", fileName = "New ControllerId")]
	public sealed class ControllerId : RestoryEntityInfoBase
	{
		[SerializeField]
		private string localizationNameKey = string.Empty;

		public string LocalizationNameKey => localizationNameKey;
	}
}
