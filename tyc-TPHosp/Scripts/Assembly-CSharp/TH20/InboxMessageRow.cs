using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class InboxMessageRow : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _messageTitleText;

		[SerializeField]
		private DynamicButton _rowButton;

		[SerializeField]
		private Image _rowSelectedImage;

		[SerializeField]
		private Image _messageIcon;

		public TMP_Text MessageTitleText => _messageTitleText;

		public DynamicButton RowButton => _rowButton;

		public Image RowSelectedImage => _rowSelectedImage;

		public Image MessageIcon => _messageIcon;
	}
}
