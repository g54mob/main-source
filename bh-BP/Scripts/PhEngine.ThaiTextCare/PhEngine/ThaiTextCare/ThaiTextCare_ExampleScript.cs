using TMPro;
using UnityEngine;

namespace PhEngine.ThaiTextCare
{
	public class ThaiTextCare_ExampleScript : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField inputField;

		[SerializeField]
		private TMP_InputField separatorInputField;

		[SerializeField]
		private TMP_Text outputText;

		[SerializeField]
		private TMP_Text wordCountText;

		[SerializeField]
		private ThaiTextNurse nurse;

		private void Start()
		{
		}

		private void OnOriginalMessageChanged(string input)
		{
		}

		private void OnSeparatorChanged(string value)
		{
		}

		private void RefreshWordCount(int count)
		{
		}
	}
}
