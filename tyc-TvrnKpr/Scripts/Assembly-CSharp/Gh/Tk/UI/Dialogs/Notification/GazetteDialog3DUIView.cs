using I18n;
using UnityEngine;
using UnityEngine.UI;

namespace Gh.Tk.UI.Dialogs.Notification
{
	public class GazetteDialog3DUIView : BaseNotificationDialog3DUIView
	{
		[SerializeField]
		private TextMeshProUGUII18n _gazetteTitle;

		[SerializeField]
		private TextMeshProUGUII18n _priceText;

		[SerializeField]
		private TextMeshProUGUII18n _dateText;

		[SerializeField]
		private TextMeshProUGUII18n _topStoryHeadline;

		[SerializeField]
		private TextMeshProUGUII18n _topStoryText;

		[SerializeField]
		private TextBlock3DUIView[] _sideStoryTexts;

		[SerializeField]
		private Button3DUIView _discardButton;

		[SerializeField]
		private Image _image;

		private DissolveArea3DUIView _dissolveArea;

		protected override void Awake()
		{
		}

		public override void SetUIData(UINotificationData data)
		{
		}

		protected override void ClearAll()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void UpdateDissolveMaterials()
		{
		}
	}
}
