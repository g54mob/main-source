using UnityEngine;
using UnityEngine.UI;

namespace SkywardRay.FileBrowser
{
	public class SfbInputField : MonoBehaviour
	{
		public SfbInputFieldType type;

		public string text;

		private SfbInternal fileBrowser;

		private InputField inputField;

		private string defaultText;

		private static char[] invalidCharsPath;

		private static char[] invalidCharsFileName;

		private void Start()
		{
		}

		public void Init()
		{
		}

		public bool IsTextDefault()
		{
			return false;
		}

		public void SetText(string s)
		{
		}

		public string GetText()
		{
			return null;
		}

		public void Submit()
		{
		}

		public void OnSubmit(string input)
		{
		}

		private void InternalOnSubmit(string input)
		{
		}

		public bool IsValidInput(string input)
		{
			return false;
		}
	}
}
