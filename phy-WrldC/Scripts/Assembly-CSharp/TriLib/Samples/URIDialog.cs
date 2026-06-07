using System;
using UnityEngine;
using UnityEngine.UI;

namespace TriLib.Samples
{
	public class URIDialog : MonoBehaviour
	{
		[SerializeField]
		private Button _okButton;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private InputField _uriText;

		[SerializeField]
		private InputField _extensionText;

		[SerializeField]
		private GameObject _rendererGameObject;

		public static URIDialog Instance { get; private set; }

		public string Filename
		{
			get
			{
				return _uriText.text;
			}
			set
			{
				_uriText.text = value;
			}
		}

		public string Extension
		{
			get
			{
				return _extensionText.text;
			}
			set
			{
				_extensionText.text = value;
			}
		}

		protected void Awake()
		{
			_cancelButton.onClick.AddListener(HideDialog);
			_uriText.onValueChanged.AddListener(UpdateExtension);
			Instance = this;
		}

		public void ShowDialog(Action<string, string> onOk)
		{
			_okButton.onClick.RemoveAllListeners();
			_okButton.onClick.AddListener(delegate
			{
				if (onOk != null)
				{
					onOk(Filename, Extension);
				}
				HideDialog();
			});
			_rendererGameObject.SetActive(value: true);
		}

		public void HideDialog()
		{
			_rendererGameObject.SetActive(value: false);
		}

		private void UpdateExtension(string text)
		{
			_extensionText.text = FileUtils.GetFileExtension(text);
		}
	}
}
