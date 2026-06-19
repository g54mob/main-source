using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class InboxMenuData : MonoBehaviour
	{
		[SerializeField]
		public GraphicRaycaster GraphicRaycaster;

		[SerializeField]
		public DynamicButton CloseButton;

		[SerializeField]
		public GameObject InboxMessageRowPrefab;

		[Space]
		[SerializeField]
		public Table MessagesTable;

		[SerializeField]
		public TMP_Text MessageTitleText;

		[Header("Inbox Message Count")]
		[SerializeField]
		public TMP_Text InboxMessageCountText;

		[SerializeField]
		public GameObject InboxMessageCountGameObject;

		[Header("Tabs")]
		[SerializeField]
		public DynamicButton InboxButton;

		[SerializeField]
		public DynamicButton ArchiveButton;

		[SerializeField]
		public ButtonAnimator InboxButtonAnimator;

		[SerializeField]
		public ButtonAnimator ArchiveButtonAnimator;

		[Header("Choices")]
		[SerializeField]
		public DynamicButton[] ChoiceButtons;

		[SerializeField]
		public ButtonAnimator[] ChoiceButtonAnimators;

		[SerializeField]
		public RectTransform[] ChoiceTransforms;

		[Header("Mug Shot")]
		[SerializeField]
		public RectTransform Mugshot;

		[SerializeField]
		public RawImage MugshotImage;

		[Header("Contents Panels")]
		[SerializeField]
		public GameObject StandardContentsPanel;

		[SerializeField]
		public InboxStandardContentsData StandardContentsData;

		[SerializeField]
		public GameObject ChallengeContentsPanel;

		[SerializeField]
		public InboxChallengeContentsData ChallengeContentsData;

		[SerializeField]
		public GameObject StaffChallengeContentsPanel;

		[SerializeField]
		public InboxStaffChallengeContentsData StaffChallengeContentsData;

		[SerializeField]
		public GameObject StaffPromotionContentsPanel;

		[SerializeField]
		public InboxStaffPromotionContentsData StaffPromotionContentsData;

		[SerializeField]
		public GameObject StaffResignationContentsPanel;

		[SerializeField]
		public InboxStaffResignationLetterContentsData StaffResignationContentsData;

		[SerializeField]
		public GameObject StaffSuccessContentsPanel;

		[SerializeField]
		public InboxStaffSuccessLetterContentsData StaffSuccessContentsData;

		[SerializeField]
		public GameObject StaffWarningContentsPanel;

		[SerializeField]
		public InboxStaffWarningLetterContentsData StaffWarningContentsData;

		[SerializeField]
		public GameObject StaffTrainingContentsPanel;

		[SerializeField]
		public InboxStaffTrainingRequiredContentsData StaffTrainingContentsData;
	}
}
