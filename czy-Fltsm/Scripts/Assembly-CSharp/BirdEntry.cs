using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BirdEntry : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]
	private Button _button;

	[SerializeField]
	[Tooltip("This is an empty entry. Used as blueprint for new birds in the birdhouse panel.")]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	[Tooltip("Image that shows current state of bird.")]
	private Image _stateImage;

	[SerializeField]
	[Tooltip("Tooltip for state icon of bird entry.")]
	private Tooltip _taskTooltip;

	[Space]
	[SerializeField]
	[Tooltip("Image that shows happiness of bird.")]
	private Image _happinessImage;

	[SerializeField]
	[Tooltip("Tooltip for happiness icon of bird.")]
	private Tooltip _happinessTooltip;

	[Header("Animation")]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _animatorParameterEnabled = "Enabled";

	public Bird Bird { get; private set; }

	public void Initialize(Bird bird)
	{
		Bird = bird;
		_taskTooltip.Bird = Bird;
		_happinessTooltip.Bird = Bird;
		UpdateEntry();
	}

	public void UpdateEntry()
	{
		if (Bird == null)
		{
			_button.interactable = false;
			_nameText.text = string.Empty;
			SetIconAndTooltip(null, _stateImage, _taskTooltip);
			SetIconAndTooltip(null, _happinessImage, _happinessTooltip);
			if (_animator != null)
			{
				_animator.SetBool(_animatorParameterEnabled, value: false);
			}
		}
		else
		{
			_button.interactable = true;
			_nameText.text = Bird.Name;
			SetIconAndTooltip(Bird.ReturnStateIcon(), _stateImage, _taskTooltip);
			SetIconAndTooltip(Bird.ReturnHappinessIcon(), _happinessImage, _happinessTooltip);
			if (_animator != null)
			{
				_animator.SetBool(_animatorParameterEnabled, value: true);
			}
		}
	}

	public void SelectBird()
	{
		if (Selector.ReturnIsSelected(Bird.gameObject))
		{
			CameraController.Instance.Lock(Bird.gameObject);
		}
		else
		{
			GameManager.UIManager.DisplayPanel(Bird);
		}
	}

	private void SetIconAndTooltip(IconProperties icon, Image image, Tooltip tooltip)
	{
		if (icon == null)
		{
			image.gameObject.SetActive(value: false);
			return;
		}
		image.gameObject.SetActive(value: true);
		image.sprite = icon.Sprite;
		tooltip.enabled = (string)icon.TooltipText != null;
		tooltip.LocalizedText = icon.TooltipText;
	}
}
