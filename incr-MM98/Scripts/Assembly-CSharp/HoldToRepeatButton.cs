using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HoldToRepeatButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerExitHandler
{
	[Header("Hold Settings")]
	[SerializeField]
	[Tooltip("Delay before auto-repeat starts (in seconds)")]
	private float initialDelay = 0.5f;

	[SerializeField]
	[Tooltip("Time between each auto-repeat trigger (in seconds)")]
	private float repeatInterval = 0.2f;

	private Button _button;

	private Coroutine _holdCoroutine;

	private bool _isHolding;

	private void Awake()
	{
		_button = GetComponent<Button>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (_button.interactable)
		{
			_isHolding = true;
			_holdCoroutine = StartCoroutine(HoldRoutine());
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		StopHolding();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		StopHolding();
	}

	private void OnDisable()
	{
		StopHolding();
	}

	private void StopHolding()
	{
		_isHolding = false;
		if (_holdCoroutine != null)
		{
			StopCoroutine(_holdCoroutine);
			_holdCoroutine = null;
		}
	}

	private IEnumerator HoldRoutine()
	{
		yield return new WaitForSeconds(initialDelay);
		while (_isHolding && _button.interactable)
		{
			_button.onClick.Invoke();
			yield return new WaitForSeconds(repeatInterval);
		}
	}
}
