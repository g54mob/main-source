using UnityEngine;
using UnityEngine.UI;

namespace TriLib.Samples
{
	public class ErrorDialog : MonoBehaviour
	{
		[SerializeField]
		private Button _okButton;

		[SerializeField]
		private InputField _errorText;

		[SerializeField]
		private GameObject _rendererGameObject;

		public static ErrorDialog Instance { get; private set; }

		public string Text
		{
			get
			{
				return _errorText.text;
			}
			set
			{
				_errorText.text = value;
			}
		}

		protected void Awake()
		{
			_okButton.onClick.AddListener(HideDialog);
			Instance = this;
		}

		public void ShowDialog(string text)
		{
			Text = text;
			_rendererGameObject.SetActive(value: true);
		}

		public void HideDialog()
		{
			_rendererGameObject.SetActive(value: false);
		}
	}
}
