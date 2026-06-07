using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BirdPanel : Panel
{
	[Tooltip("Image component for the birds portrait.")]
	public Image ImagePortrait;

	[Space]
	[Tooltip("Localized text when the bird needs to be rescued.")]
	[SerializeField]
	private LocalizedString _needsRescuingText = "";

	[Header("Buttons")]
	[SerializeField]
	[Tooltip("Button which focuses the camera on the selected bird.")]
	private Button _focusButton;

	[SerializeField]
	[Tooltip("Button which focuses the camera on the house of the selected bird.")]
	private Button _houseButton;

	[SerializeField]
	[Tooltip("Button to release the selected bird.")]
	private Button _releaseButton;

	[Header("Other")]
	[Tooltip("Reference to the panels inventory view.")]
	public InventoryView InventoryView;

	[Header("Happiness Bar")]
	[SerializeField]
	private Slider _happinessBar;

	[SerializeField]
	private Tooltip _happinessBarTooltip;

	[SerializeField]
	private Image _happinessBarIcon;

	[SerializeField]
	private ChildGameObjectCache _happinessBarDividerPrefab;

	[Header("Sprites")]
	[SerializeField]
	private Image _happinessIcon;

	[Header("Text Labels")]
	[SerializeField]
	[Tooltip("Text component for the birds name.")]
	private TextMeshProUGUI _textName;

	[SerializeField]
	[Tooltip("Text component for the birds task description.")]
	private TextMeshProUGUI _taskText;

	[HideInInspector]
	public Bird Bird { get; private set; }

	private void Update()
	{
		if ((bool)Bird)
		{
			UpdatePanel();
		}
		else
		{
			Close();
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (context is Bird bird && base.Open(id, context))
		{
			Bird = bird;
			UpdatePanel();
			InventoryView.Initialize(bird.Inventory);
			ImagePortrait.sprite = bird.Descriptor.Portrait;
			return true;
		}
		return false;
	}

	private void UpdateName(string name, bool dialogFeedback)
	{
		PopUpDialog.Instance.InputEvent -= UpdateName;
		if (dialogFeedback)
		{
			Bird.Descriptor.SetName(name);
		}
	}

	private void UpdatePanel()
	{
		if (base.gameObject.activeInHierarchy)
		{
			IconProperties iconProperties = Bird.ReturnHappinessIcon();
			_textName.text = Bird.Name;
			_happinessBar.maxValue = Bird.HappinessMaxValue;
			_happinessBar.value = Mathf.Max(0, Bird.Happiness);
			_happinessBarDividerPrefab.Reset();
			for (int i = 0; (float)i < _happinessBar.maxValue; i++)
			{
				_happinessBarDividerPrefab.Get(active: true);
			}
			_happinessBarDividerPrefab.Trim();
			_happinessBarIcon.sprite = iconProperties.Sprite;
			_happinessBarTooltip.LocalizedText = iconProperties.TooltipText;
			_happinessIcon.sprite = Bird.HappinessIcon;
			_houseButton.interactable = Bird.BirdHouse != null;
			_releaseButton.interactable = Bird.Community.IsPlayerCommunity();
			if (Bird.Community != null)
			{
				string text = "";
				text = ((!Bird.Community.IsPlayerCommunity() && Bird.CanBeRescued) ? ((string)_needsRescuingText) : ((string)Bird.ReturnTaskDescription()));
				_taskText.text = text;
			}
		}
	}

	public override void Close()
	{
		if (base.gameObject.activeSelf)
		{
			if ((bool)Bird)
			{
				Selector.Deselect(Bird.gameObject);
			}
			base.Close();
		}
	}

	public void LockOnDrifter()
	{
		if ((bool)Bird && GameManager.WorldManager.IsInBoatRadius(Bird.transform.position))
		{
			CameraController.Instance.Lock(Bird.gameObject);
		}
	}

	public void PopUpNameChange()
	{
		if (Bird.Community.IsPlayerCommunity() && PopUpDialog.Instance.TryPopUpInput(GameManager.Settings.UISettings.InputNameChangeAgent))
		{
			PopUpDialog.Instance.InputEvent += UpdateName;
		}
	}

	public void LockOnHouse()
	{
		if (Bird.BirdHouse != null)
		{
			CameraController.Instance.Lock(Bird.BirdHouse.gameObject);
			Selector.Select(Bird.BirdHouse.gameObject, ObjectType.Buildable);
		}
	}

	public void PopUpFreeBirdDialog()
	{
		Bird.AskToFreeBird();
	}
}
