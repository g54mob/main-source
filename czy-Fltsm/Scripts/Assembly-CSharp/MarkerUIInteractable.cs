using UnityEngine;
using UnityEngine.UI;

public class MarkerUIInteractable : UIInteractable
{
	[Tooltip("Cursor properties of the marker that will be activated when interacting with this UI element.")]
	[SerializeField]
	private MarkerCursorProperties _markerCursorProperties;

	[Tooltip("The boat type required to activate marker.")]
	[SerializeField]
	private BoatType _boatTypeRequired;

	[Header("UI")]
	[Tooltip("The normal sprite of the marker icon.")]
	[SerializeField]
	private Sprite _enabledSprite;

	[Tooltip("The grey sprite of the marker icon. ")]
	[SerializeField]
	private Sprite _disabledSprite;

	[Tooltip("The image component of the gameObject.")]
	[SerializeField]
	private Image _image;

	private Image[] _attachedImages;

	protected override void Start()
	{
		base.Start();
		_attachedImages = GetComponentsInChildren<Image>();
		UpdateButtonState();
		Community.PlayerCommunity.BoatsUpdatedEvent += UpdateButtonState;
		Community.PlayerCommunity.AgentsUpdatedEvent += UpdateButtonState;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		Community.PlayerCommunity.BoatsUpdatedEvent -= UpdateButtonState;
		Community.PlayerCommunity.AgentsUpdatedEvent -= UpdateButtonState;
	}

	public void UpdateButtonState()
	{
		bool flag = true;
		if (_boatTypeRequired != BoatType.None)
		{
			flag = Community.PlayerCommunity.ReturnHasBoatOfType(_boatTypeRequired);
		}
		EnableButton(flag);
	}

	public override void Interact()
	{
		base.Interact();
		GameManager.CursorManager.Activate(_markerCursorProperties);
	}

	private void EnableButton(bool enabled)
	{
		base.IsInteractable = enabled;
		_image.sprite = (enabled ? _enabledSprite : _disabledSprite);
	}
}
