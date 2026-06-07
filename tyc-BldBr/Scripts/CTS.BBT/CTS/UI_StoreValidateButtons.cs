using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_StoreValidateButtons : CTSBehaviour
	{
		[field: SerializeField]
		public Button ResetButton { get; private set; }

		[field: SerializeField]
		public Button ValidateButton { get; private set; }

		[field: SerializeField]
		public TMP_Text ValidateText { get; private set; }

		[field: SerializeField]
		public GameObject InfoTextContainer { get; private set; }

		[field: SerializeField]
		public TMP_Text InfoText { get; private set; }
	}
}
