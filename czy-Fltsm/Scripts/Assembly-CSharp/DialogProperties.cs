using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Flotsam/UI/Dialog Properties/Base")]
public class DialogProperties : ScriptableObject
{
	public enum ID
	{
		None = 0,
		PlatformInitializationFailed = 1
	}

	[SerializeField]
	private ID _id;

	[SerializeField]
	private Sprite _icon;

	[Tooltip("Localized title for the dialog panel.")]
	[FormerlySerializedAs("LocalizedTitle")]
	public LocalizedString Title;

	[Tooltip("Localized message to display for this dialog panel.")]
	[FormerlySerializedAs("LocalizedContents")]
	public LocalizedString Message;

	public HorizontalAlignmentOptions MessageHorizontalAllignment = HorizontalAlignmentOptions.Left;

	public VerticalAlignmentOptions MessageVerticalAllignment = VerticalAlignmentOptions.Top;

	[Tooltip("Should the game pause when this pop-up opens?")]
	public bool PauseGame = true;

	[Tooltip("Max amount of characters (0 = infinite).")]
	[FormerlySerializedAs("_characterLimit")]
	public int CharacterLimit;

	[Tooltip("Use the big input panel instead of the big one.")]
	[FormerlySerializedAs("useBigPanel")]
	public bool BigPanel;

	[Tooltip("Dialog panel will time out and cancel.")]
	public bool Timed;

	[ConditionalHide("Timed")]
	[Tooltip("Duration for the time-out.")]
	public int TimeOut = 15;

	[Header("Regular Expression")]
	[Tooltip("The regular expression used to match characters that are not accepted.")]
	public string RegularExpression;

	[Tooltip("The error shown when the input does not match the regular expression")]
	public LocalizedString LocalizedRegularExpressionError;

	[Header("Buttons")]
	[Tooltip("Enable the cancel button.")]
	[FormerlySerializedAs("_cancelEnabled")]
	public bool EnableCancelButton;

	[Tooltip("The color for the cancel button.")]
	[FormerlySerializedAs("_cancelColor")]
	public Color CancelButtonColor = new Color(0.94509804f, 0.40392157f, 1f / 3f);

	[Tooltip("Text for the cancel button (will always be upper case).")]
	public LocalizedString LocalizedCancelButtonText = "";

	[Space]
	[Tooltip("Enable the confirm button.")]
	public bool EnableConfirmButton = true;

	[Tooltip("The color for the confirm button.")]
	public Color ConfirmButtonColor = new Color(39f / 85f, 57f / 85f, 0.45490196f);

	[Tooltip("Localized Text for the confirm button (will always be upper case).")]
	public LocalizedString LocalizedConfirmButtonText = "";

	public ID Id => _id;

	public Sprite Icon => _icon;

	public virtual string ReturnTitle()
	{
		return Title;
	}

	public virtual string ReturnMessage()
	{
		return Message;
	}
}
