using Gh.UI;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class CreditsDialog3DUIView : BaseDialog3DUIView
	{
		public bool isAutoScrollActive;

		[Header("Config")]
		[SerializeField]
		private float _scrollTime;

		[Header("References")]
		[SerializeField]
		private ScrollableUIView _scrollableUIView;

		[SerializeField]
		private DragScrollDetector _dragScrollDetector;

		[SerializeField]
		private TMP_Text _playerNameText;

		protected override void Awake()
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

		private void Update()
		{
		}

		private void UpdateScroll(float deltaTime)
		{
		}
	}
}
