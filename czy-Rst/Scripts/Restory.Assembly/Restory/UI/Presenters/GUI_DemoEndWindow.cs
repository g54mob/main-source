using System;
using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public sealed class GUI_DemoEndWindow : MonoBehaviour
	{
		[SerializeField]
		private Button closeButton;

		private Action onCloseButtonClickedCallback;

		public event Action OnCloseButtonClicked;

		private void OnEnable()
		{
			closeButton.onClick.AddListener(ResolveCloseButtonClicked);
		}

		private void OnDisable()
		{
			if (closeButton.MonoShellExists())
			{
				closeButton.onClick.RemoveListener(ResolveCloseButtonClicked);
				onCloseButtonClickedCallback = null;
			}
		}

		public void SetUp(Action onCloseButtonClickedCallback)
		{
			this.onCloseButtonClickedCallback = onCloseButtonClickedCallback;
		}

		private void ResolveCloseButtonClicked()
		{
			onCloseButtonClickedCallback?.Invoke();
			this.OnCloseButtonClicked?.Invoke();
		}
	}
}
