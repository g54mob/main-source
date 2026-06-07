using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoatEntry : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _name;

	[SerializeField]
	private Image _image;

	[SerializeField]
	private Button _moveButton;

	[SerializeField]
	private BoatMovementCursorProperties _movementCursorProperties;

	private Boat _boat;

	public void Initialize(Boat boat)
	{
		_boat = boat;
		_name.text = boat.Buildable.Name;
		_image.sprite = boat.Buildable.Properties.IconSprite;
		_moveButton.interactable = _boat.CanBeMoved;
	}

	private void Update()
	{
		if (!(_boat == null))
		{
			_moveButton.interactable = _boat.CanBeMoved;
		}
	}

	public void SelectBoat()
	{
		if (!(_boat == null))
		{
			Selector.Select(_boat.gameObject, ObjectType.Buildable);
		}
	}

	public void Move()
	{
		if (!(_boat == null))
		{
			_movementCursorProperties.Initialize(_boat.Buildable, _boat.Buildable.VisualIndex);
			GameManager.CursorManager.Activate(_movementCursorProperties);
			GameManager.UIManager.ClosePanel(PanelID.BuildablePanel);
		}
	}
}
