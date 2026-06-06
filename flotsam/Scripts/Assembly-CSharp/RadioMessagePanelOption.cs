using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadioMessagePanelOption : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _titleField;

	[SerializeField]
	private TextMeshProUGUI _descriptionField;

	[SerializeField]
	private Button _button;

	[SerializeField]
	private Image _illustrationImage;

	[SerializeField]
	private Image _senderIcon;

	[SerializeField]
	private TextMeshProUGUI _senderLabel;

	[Header("Animator")]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _animatorParameterIsNew = "IsNew";

	[SerializeField]
	private string _animatorParameterIsDialogueOption = "IsDialogueOption";

	public RadioMessage RadioMessage { get; private set; }

	private void OnEnable()
	{
		if (RadioMessage != null && (bool)_animator)
		{
			_animator.SetBool(_animatorParameterIsNew, RadioMessage.IsNew);
			_animator.SetBool(_animatorParameterIsDialogueOption, RadioMessage.IsDialogueOption);
		}
	}

	public void Initialize(RadioMessage radioMessage)
	{
		RadioMessage = radioMessage;
		RadioMessage.OnOption();
		_titleField.text = radioMessage.Properties.Title;
		_descriptionField.text = radioMessage.Properties.Description;
		_illustrationImage.overrideSprite = radioMessage.Properties.Illustration;
		_senderLabel.text = radioMessage.Properties.GetSenderName();
		_senderIcon.overrideSprite = radioMessage.Properties.GetSenderIcon();
		OnEnable();
	}

	public void Select()
	{
		_button.Select();
	}

	public void OnClick()
	{
		RadioMessageEvent.DispatchReceived(RadioMessage);
		GameManager.UIManager.ClosePanel(PanelID.RadioMessagePanel);
	}
}
