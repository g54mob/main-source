using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class ErrorPopup : BasePopup
	{
		[SerializeField]
		private TextMeshProUGUI _Description;

		private PopupManager _manager;

		public void Initialize(PopupManager manager, string id, string error, bool textIsLocalizationTerm = true)
		{
		}
	}
}
