using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSpin : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	private float totalSpin;

	private Vector2 lastPosition;

	private bool mouseSpinning;

	public Transform playerRenderer;

	private float maxSpin;

	private float controllerSpin;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void AddSpin(float spin)
	{
	}
}
