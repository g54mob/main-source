using System;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TavernUnlockedDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private BaseInteractable3DUIView _continueButton;

		[SerializeField]
		private BaseInteractable3DUIView _stayButton;

		[SerializeField]
		private SimpleCinemaBars3DUIView _cinemaBars;

		[SerializeField]
		private TextBlock3DUIView _messageText;

		private string _tavernLevel;

		private Action _onStayed;

		[SerializeField]
		private SpriteRenderer _image;

		protected override void Awake()
		{
		}

		public void SetData(string tavernLevel, Action onStayed)
		{
		}

		private void DisplayImage()
		{
		}

		private void SetMessage()
		{
		}

		private void SaveAndGo()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Opened()
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void PlayTavernUnlockSound()
		{
		}
	}
}
