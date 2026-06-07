using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldButton : MonoBehaviour
{
	public InputActionReference holdActionReference;

	public Image fillImage;

	public float holdDuration = 2f;

	public bool modifyScale;

	public float scaleValue = 1.2f;

	public UnityEvent onHoldComplete;

	private float holdTime;

	private Vector3 originalScale;

	private bool isListening;

	private void Awake()
	{
		originalScale = base.transform.localScale;
	}

	private void OnEnable()
	{
		holdActionReference.action.performed += OnHoldPerformed;
		holdActionReference.action.canceled += OnHoldCanceled;
	}

	private void OnDisable()
	{
		holdActionReference.action.performed -= OnHoldPerformed;
		holdActionReference.action.canceled -= OnHoldCanceled;
	}

	private void Update()
	{
		if (isListening && holdActionReference.action.IsPressed())
		{
			holdTime += Time.unscaledDeltaTime;
			fillImage.fillAmount = holdTime / holdDuration;
			if (modifyScale)
			{
				float num = Mathf.Lerp(1f, scaleValue, holdTime / holdDuration);
				base.transform.localScale = originalScale * num;
			}
			if (holdTime >= holdDuration)
			{
				onHoldComplete.Invoke();
				ResetHold();
			}
		}
	}

	public void StartListening()
	{
		isListening = true;
		holdActionReference.action.Enable();
	}

	public void StopListening()
	{
		isListening = false;
		ResetHold();
		holdActionReference.action.Disable();
	}

	private void ResetHold()
	{
		holdTime = 0f;
		fillImage.fillAmount = 0f;
		if (modifyScale)
		{
			base.transform.localScale = originalScale;
		}
	}

	private void OnHoldPerformed(InputAction.CallbackContext context)
	{
		_ = isListening;
	}

	private void OnHoldCanceled(InputAction.CallbackContext context)
	{
		ResetHold();
	}
}
