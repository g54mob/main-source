using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class Deed3DUIView : SimpleInputDialog3DUIView
	{
		[SerializeField]
		private BasicAnimationEventObserver _eventObserver;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private TextMeshProI18n _pageCountTextElement;

		private bool _isStamping;

		protected override void Awake()
		{
		}

		private void UpdateTavernName()
		{
		}

		private string FormatTitle(string text)
		{
			return null;
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override bool CanClose(ShowHideAnimationSpeed speed, bool forceClose)
		{
			return false;
		}
	}
}
