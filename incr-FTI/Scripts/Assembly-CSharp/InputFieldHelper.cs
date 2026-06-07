using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_InputField))]
public class InputFieldHelper : MonoBehaviour, ISubmitHandler, IEventSystemHandler, ICancelHandler
{
	public delegate void InputFieldDelegate(InputFieldHelper sender);

	private TMP_InputField inputField;

	public InputFieldDelegate inputFieldDelegate;

	public OnChanged onGamepadTextEnteredDelegate;

	private void Awake()
	{
		inputField = GetComponent<TMP_InputField>();
	}

	public string GetInputFieldText()
	{
		return inputField.text;
	}

	public void OnSubmit(BaseEventData eventData)
	{
		inputFieldDelegate?.Invoke(this);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		UserInput.DidEnterTextInput = true;
	}

	private void OnDisable()
	{
		UserInput.DidExitTextInput = true;
	}

	public void OnCancel(BaseEventData eventData)
	{
		NavigateBackToParent();
	}

	public void NavigateBackToParent()
	{
	}

	public static void ConfigureInputFieldBehavior(TMP_InputField inputField, OnChanged onChangedDelegate)
	{
		if (!(null == inputField) && inputField.TryGetComponent<InputFieldHelper>(out var component))
		{
			component.onGamepadTextEnteredDelegate = onChangedDelegate;
		}
	}
}
