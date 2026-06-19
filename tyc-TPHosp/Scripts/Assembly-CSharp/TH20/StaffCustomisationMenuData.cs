using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class StaffCustomisationMenuData : MonoBehaviour
	{
		public GameObject RowPrefab;

		public GraphicRaycaster GraphicRaycaster;

		public DynamicButton CloseButton;

		public Table Table;

		public StaffCustomisationOptions StaffCustomisationOptions;

		public RectTransform ViewFinderRectTransform;

		public RectTransform PanelRectTransform;

		public float ViewFinderBorder;

		public Button LeftCycleButton;

		public Button RightCycleButton;

		public TMP_Text StaffNameText;

		[Header("Staff Tabs")]
		public DynamicButton DoctorsButton;

		public DynamicButton NursesButton;

		public DynamicButton AssistantsButton;

		public DynamicButton JanitorsButton;

		public ButtonAnimator DoctorsButtonAnimator;

		public ButtonAnimator NursesButtonAnimator;

		public ButtonAnimator AssistantsButtonAnimator;

		public ButtonAnimator JanitorsButtonAnimator;

		[Header("Apply All Button")]
		public DynamicButton ApplyToAllButton;

		public ButtonAnimator ApplyToAllButtonAnimator;

		public Localize ApplyToAllLocalize;

		public LocalisedString ApplyToAllDoctorsString;

		public LocalisedString ApplyToAllNursesString;

		public LocalisedString ApplyToAllAssistantsString;

		public LocalisedString ApplyToAllJanitorsString;

		[Header("Default Row")]
		public LocalisedString DefaultRowName;

		public Sprite DefaultDoctorIcon;

		public Sprite DefaultNurseIcon;

		public Sprite DefaultAssistantIcon;

		public Sprite DefaultJanitorIcon;
	}
}
