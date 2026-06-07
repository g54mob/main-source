using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RescueableSeagullInfo : UIBehaviour, IPointerDownHandler, IEventSystemHandler
{
	[Tooltip("Image that will display the agent's portrait.")]
	[SerializeField]
	private Image _portraitImage;

	private AnimalDescriptor _descriptor;

	public void Initialize(AnimalDescriptor descriptor)
	{
		_descriptor = descriptor;
		_portraitImage.sprite = descriptor.Portrait;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			Select();
		}
	}

	public void Select()
	{
		if (_descriptor != null && (bool)_descriptor.Actor)
		{
			CameraController.Instance.Lock(_descriptor.Actor.gameObject);
			GameManager.UIManager.DisplayPanel(_descriptor);
		}
	}
}
