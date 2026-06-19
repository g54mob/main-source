using TMPro;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class ShowPassword : MonoBehaviour
	{
		[Header("Resources")]
		public TMP_InputField inputField;

		public GameObject showObject;

		public GameObject hideObject;

		private void OnEnable()
		{
			HidePassword();
		}

		public void TogglePassword()
		{
			if (inputField != null && inputField.contentType == TMP_InputField.ContentType.Standard)
			{
				inputField.contentType = TMP_InputField.ContentType.Password;
				inputField.ForceLabelUpdate();
				showObject.SetActive(value: true);
				hideObject.SetActive(value: false);
			}
			else if (inputField != null && inputField.contentType == TMP_InputField.ContentType.Password)
			{
				inputField.contentType = TMP_InputField.ContentType.Standard;
				inputField.ForceLabelUpdate();
				showObject.SetActive(value: false);
				hideObject.SetActive(value: true);
			}
		}

		public void HidePassword()
		{
			if (inputField != null && inputField.contentType == TMP_InputField.ContentType.Standard)
			{
				inputField.contentType = TMP_InputField.ContentType.Password;
				inputField.ForceLabelUpdate();
				showObject.SetActive(value: true);
				hideObject.SetActive(value: false);
			}
		}
	}
}
