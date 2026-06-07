using System;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class VideoCheckSetting3DUIView : MonoBehaviour
	{
		[SerializeField]
		private ConfirmationModal3DUIView _modal;

		public Button3DUIView applyButton;

		public Button3DUIView revertButton;

		private void Start()
		{
		}

		public void ConfirmSettingsWithUser(Action onConfirm, Action onCancelAndRevert)
		{
		}
	}
}
